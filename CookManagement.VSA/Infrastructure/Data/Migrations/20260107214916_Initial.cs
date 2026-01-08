using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CookManagement.VSA.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BarInventory",
                columns: table => new
                {
                    Code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Category = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    MinimumStock = table.Column<double>(type: "double precision", nullable: false, defaultValue: 0.0),
                    Product = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CurrentStock = table.Column<double>(type: "double precision", nullable: false, defaultValue: 0.0)
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
                    Category = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    MeasurementUnit = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    MinimumStock = table.Column<double>(type: "double precision", nullable: false, defaultValue: 0.0),
                    Product = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CurrentStock = table.Column<double>(type: "double precision", nullable: false, defaultValue: 0.0)
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
                    ProductName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    InitialInventory = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    FinalInventory = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    Difference = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    DailyMove = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    Entries = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    Courtesy = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    Damaged = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    Remains = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    InventoryType = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2026, 1, 7, 15, 49, 12, 456, DateTimeKind.Unspecified).AddTicks(1854), new TimeSpan(0, -6, 0, 0, 0))),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2026, 1, 7, 15, 49, 12, 456, DateTimeKind.Unspecified).AddTicks(3366), new TimeSpan(0, -6, 0, 0, 0)))
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
                    { 1, "Vcastro", "$2a$11$aElS0hr6kgwIr0X.brMh5uuTvi73CQW5GABfYPFKusabGwUWdyO16", "Admin" },
                    { 2, "Gcastillo", "$2a$11$blGVpdghJa.CegLgvKG8qO9qUgqOaEHSJHizAWRiYQrAX9mziUMn2", "Admin" },
                    { 3, "Pcasco", "$2a$11$CjVUWTGXwxY4vNKRd0lYAexfYotn/r8yFde.CyP55bhkKgdYKXqUa", "Admin" },
                    { 4, "Alevaldez", "$2a$11$WClTW5H6sFdmCCwpora9auu42eaf0A7I8XnvOZCp0GhFNOamqatfe", "Cocina" },
                    { 5, "Marifonseca", "$2a$11$sKvEiP3IeT6loYwNUNcH6uejIOvFJgX47eGzspu7zvoOavBhClpDu", "Cocina" },
                    { 6, "Astridvalle", "$2a$11$seXD2yWRfoHwwpOuoerdWOeq.JJVlMbE.PPtAXZQWgwYIAeOOJM1i", "Cocina" },
                    { 7, "SherMurillo", "$2a$11$cc9VqcLdY8uKe8HXF/IXEuPahlEkZc6b6E6.zeM7CX1tgeo50Reo6", "Bar" },
                    { 8, "Elinuñez", "$2a$11$DYn0HSFfeH3waYcTURasIOr2moezNVVfvWGv7vsq7STKwPce1P.ju", "Bar" },
                    { 9, "Jcastillo", "$2a$11$fiwD6A0qlX4pzdC339j8auS794DMzFBpnfu0WuRlcxLlJReZSWlrO", "Cocina" },
                    { 10, "Gperez", "$2a$11$mGbF86VoAmOWm0SednWlm.bbGnCmfigGOBpZVcHTT2O5nmmttujei", "Bar" },
                    { 11, "AdminLinus", "$2a$11$VXyDpEc.0Ib96s8LpT.51OKfNYAE6HnswSnvW0ZsMMRHr1NdC6wf.", "SuperAdmin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRecords_UserId_ProductCode_CreatedAt",
                table: "UserRecords",
                columns: new[] { "UserId", "ProductCode", "CreatedAt" });
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
