# CookManagement API — Agent Guide

## Project structure

```
CookManagement.VSA/          # Single project (net10.0)
├── Features/                # Vertical Slices by domain
│   ├── Authentication/      # Login only
│   ├── Inventory/           # GetInventory, UpdateStock, GetByLowStock
│   ├── Movements/           # CreateInitialCount, RegisterMovements, UpdateFinalCount
│   └── Users/               # CRUD + GetUserRecords (paginated)
├── Infrastructure/
│   ├── Auth/                # TokenService, PasswordHasher, JWT config
│   ├── Data/                # CookDbContext, EF migrations, DataExtensions
│   ├── Extensions/          # Service/Validation/Mapping/ClaimsPrincipal extensions
│   ├── Filters/             # ValidationFilter<T>, ExceptionFilter
│   └── TimeZones/           # TimeZoneService (business day boundaries)
└── Shared/
    ├── Entities/            # User, UserRecord, BarInventory, KitchenInventory
    ├── DTOs/                # UserRequest/Response, CountRequest
    ├── Enums/               # UserRole, InventoryType, MovementType
    ├── Exceptions/           # Custom (404/401/409/400) → ExceptionFilter
    └── Validators/          # FluentValidation validators
```

**Each slice** = one folder with `*Endpoint.cs`, `*Handler.cs`, `*Request.cs`, `*Response.cs` (optionally `*Validator.cs`). Endpoints are `static` extension methods on `RouteGroupBuilder`. Handlers are classes injected via constructor, contain all business logic.

**Feature registration** is centralized in `*EndpointsExtensions.cs` per feature — registers scoped handlers + maps route group + calls each endpoint extension.

## Key commands

```bash
dotnet run                   # Start API (dev: http://localhost:5068)
dotnet ef database update    # Apply EF migrations
dotnet build                 # Build
```

No tests exist in the repo.

## Framework & toolchain quirks

- **Target**: `net10.0` (not .NET 8 despite README and Dockerfile saying so).
- **API docs**: Scalar.AspNetCore at `/scalar` (not Swagger). Enabled only in Development.
- **Validation**: `WithRequestValidation<T>()` extension on `RouteHandlerBuilder` attaches `ValidationFilter<T>`. Validators auto-registered via `AddValidatorsFromAssemblyContaining<Program>()`.
- **Error handling**: Custom exception hierarchy (`CustomNotFoundException` → 404, `CustomConflictException` → 409, etc.) caught by `ExceptionFilter` → `ProblemDetails`.
- **Auth**: JWT Bearer (HMAC-SHA512), 1-hour expiry. Policies: `"AdminOnly"` (Admin role), `"SuperAdminOnly"` (SuperAdmin role). Roles: Admin, Bar, Cocina, SuperAdmin.
- **Mapping**: Static extension methods in `MappingExtensions.cs` (no AutoMapper).
- **Logging**: Serilog to console + rolling file `Logs/app-log-*.txt` (only `CookManagement.VSA.*` source contexts).
- **CORS**: Policy `"AllowReact"` — allows any origin/header/method.
- **Time zone**: `"Central America Standard Time"`. Business day: 10 AM – 2 AM+1.
- **DB**: PostgreSQL via Npgsql + EF Core Code First. Connection string in `appsettings.json` under `"ConnectionStrings:DefaultConnection"`.
- **Seed data**: 12 users (Admin, Cocina, Bar, SuperAdmin), all password `"GenericPassword"` (BCrypt, work factor 12).

## Key DI registration order (Program.cs)

1. `AddOpenApi()` — Microsoft.AspNetCore.OpenApi
2. `AddDatabase()` — EF + PostgreSQL
3. `ConfigureJwtAuth()` — JWT + policies
4. `ConfigureCors()` — CORS
5. `RegisterServices()` — TokenService, PasswordHasher, TimeZoneService
6. `RegisterValidators()` — FluentValidation
7. `Register*Handlers()` — Feature handler registrations

## Gotchas

- `appsettings.Development.json` is gitignored. Always check for local overrides.
- Dockerfile uses .NET 8 images but project targets `net10.0` — mismatch if building via Docker.
- All route groups have `.AddEndpointFilter<ExceptionFilter>()`. Custom exceptions thrown from handlers → `ProblemDetails`.
- Movement endpoints: group-level `.RequireAuthorization()`. Inventory & User endpoints: no group auth (handlers use `ClaimsPrincipalExtensions` manually).
- `GetUsers` hard-excludes user named "AdminLinus". `GetUserById` does not.
- `CountRequest` DTO shared between `CreateInitialCount` and `UpdateFinalCount`. `UserRequest` shared between `Create`/`Update` User.
- `RegisterMovement` with `Entry` type also increments inventory `CurrentStock`; other movement types only record.
- Composite index on UserRecords: `(UserId, ProductCode, CreatedAt)`.
- Launch URL defaults to `/scalar` not `/swagger`.
