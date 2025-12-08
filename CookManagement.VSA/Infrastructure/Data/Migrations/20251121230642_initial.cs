using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CookManagement.VSA.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BarInventory",
                columns: table => new
                {
                    Code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Product = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Category = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    MinimumStock = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    CurrentStock = table.Column<int>(type: "integer", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarInventory", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "KitchenInventory",
                columns: table => new
                {
                    Code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Product = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Category = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    MeasurementUnit = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    MinimumStock = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    CurrentStock = table.Column<int>(type: "integer", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KitchenInventory", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ProductCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    InitialInventory = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    FinalInventory = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    Sales = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    Entries = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    Courtesy = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    Damaged = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    InventoryType = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2025, 11, 21, 17, 6, 40, 992, DateTimeKind.Unspecified).AddTicks(7209), new TimeSpan(0, -6, 0, 0, 0))),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2025, 11, 21, 17, 6, 40, 992, DateTimeKind.Unspecified).AddTicks(7828), new TimeSpan(0, -6, 0, 0, 0)))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRecords_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { 1, "Víctor Castro", "$2a$11$JaoOStPmDDO9HWbUuN05KeCDWwPys.7LHodBjmT9/jYEkLzEzw.5y", "Admin" },
                    { 2, "Gabriel Castillo", "$2a$11$Mw4w9xlG60dm3LYpCjYRKO5kH1trMDi/xMoscngwMRhPKQzm5k8T6", "Admin" },
                    { 3, "Perla Casco", "$2a$11$iH4pYGoYXS7QA9uFiva8ieq5819Tuz0Bj3w85Ej4kAzbN1AbOFRnW", "Admin" },
                    { 4, "Alexis Valdez", "$2a$11$dRMoGVaB1EsZvwfPln45AO0ENAjL1ZYK/kv6D3.mTgSuoJgUd3B66", "Cocina" },
                    { 5, "María Fonseca", "$2a$11$L23/MqEO51XqsaGMf1GN7uy1gAN1FInGDCWcR6MwipYimt0ctjSma", "Cocina" },
                    { 6, "Astrid Valle", "$2a$11$pctrMKyRY5grOUJ.1b5FieFjifagvgSgQX4n2tTxfphYgLUleu0WG", "Cocina" },
                    { 7, "Sherlyn Murillo", "$2a$11$FrEmxVFv8FjW5Nc2wPA7COCeRK61B2gzXC5lhOt4bTEktbAf/anBu", "Bar" },
                    { 8, "Ilsi Padilla", "$2a$11$g/IWdXt6tTlhZJ/StmqKyuyfSHfx0YPL5GHINVBf.T8L7TdXE.huu", "Bar" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRecords_UserId",
                table: "UserRecords",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BarInventory");

            migrationBuilder.DropTable(
                name: "KitchenInventory");

            migrationBuilder.DropTable(
                name: "UserRecords");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
