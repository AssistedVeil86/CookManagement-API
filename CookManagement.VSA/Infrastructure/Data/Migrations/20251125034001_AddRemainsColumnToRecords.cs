using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookManagement.VSA.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRemainsColumnToRecords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sales",
                table: "UserRecords",
                newName: "Remains");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "UserRecords",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2025, 11, 24, 21, 39, 58, 699, DateTimeKind.Unspecified).AddTicks(525), new TimeSpan(0, -6, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2025, 11, 24, 18, 47, 42, 767, DateTimeKind.Unspecified).AddTicks(8503), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "UserRecords",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2025, 11, 24, 21, 39, 58, 698, DateTimeKind.Unspecified).AddTicks(9447), new TimeSpan(0, -6, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2025, 11, 24, 18, 47, 42, 767, DateTimeKind.Unspecified).AddTicks(7734), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.AddColumn<int>(
                name: "DailyMove",
                table: "UserRecords",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Difference",
                table: "UserRecords",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Password" },
                values: new object[] { "Vcastro", "$2a$11$GogW2K8s3/nFwV35A5lrVOxqr0oZ4GIGudn133B2mLzZWpljvJsHe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "Password" },
                values: new object[] { "Gcastillo", "$2a$11$uReUIRY1XFBWeupJ7mbBzOaOmc9JBMJXWqaMSKAg.NrxC5WdwJ7rG" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "Password" },
                values: new object[] { "Pcasco", "$2a$11$chq.Uqy3Zphio/6QikjRHO7Da.J988FWmq5epVhS3zaBitbdeFdR." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "Password" },
                values: new object[] { "Alevaldez", "$2a$11$LYIkaw8bz4k3jobOJQ8ocOh3c.7KGUTaxcNet2tlWTU1L7GckJ.ee" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Name", "Password" },
                values: new object[] { "Marifonseca", "$2a$11$XGS1zwoQOMucVrHYLI3UueBr1w.bofRQLRoXevr4Q0oADro1xD4Jm" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Name", "Password" },
                values: new object[] { "Astridvalle", "$2a$11$eImC/rUCK3oV2LGfoKZEBuse1BqqK0fzRPWEk1i7TI66dtr1c6/6K" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Name", "Password" },
                values: new object[] { "SherMurillo", "$2a$11$5IqlqHB6155y4sN7Jpr2W.43Q/ZSKTSweUDvzbUUYQOE8CeUrPUFy" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Name", "Password" },
                values: new object[] { "Elinuñez", "$2a$11$.f6BYvO/MuOAVkg.B1yk8.0ZTkHe4st6AzEE6yT4CRQ.seLcC0rRi" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DailyMove",
                table: "UserRecords");

            migrationBuilder.DropColumn(
                name: "Difference",
                table: "UserRecords");

            migrationBuilder.RenameColumn(
                name: "Remains",
                table: "UserRecords",
                newName: "Sales");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "UserRecords",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2025, 11, 24, 18, 47, 42, 767, DateTimeKind.Unspecified).AddTicks(8503), new TimeSpan(0, -6, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2025, 11, 24, 21, 39, 58, 699, DateTimeKind.Unspecified).AddTicks(525), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "UserRecords",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2025, 11, 24, 18, 47, 42, 767, DateTimeKind.Unspecified).AddTicks(7734), new TimeSpan(0, -6, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2025, 11, 24, 21, 39, 58, 698, DateTimeKind.Unspecified).AddTicks(9447), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Password" },
                values: new object[] { "Víctor Castro", "$2a$11$6ssgrCTy2PpEFMHwJIy8IultnEW1G3e9Js9mA1JTzKbLmNFCGV5o2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "Password" },
                values: new object[] { "Gabriel Castillo", "$2a$11$eB7Dw.gQjmDhvh1apI.LJuzMvaPeDXryxLgsPMW//TGzkEb0fj85i" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "Password" },
                values: new object[] { "Perla Casco", "$2a$11$GKxRzL6yrT/cFGHBN8xcbud9E53L2.PrfdgqIscpSASMH1HqO6M.K" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "Password" },
                values: new object[] { "Alexis Valdez", "$2a$11$iaVotQmmcaJ9eIxSizJnBuEZnmPa8h2WbAj7C5pdu6uu9qNYIjaSu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Name", "Password" },
                values: new object[] { "María Fonseca", "$2a$11$obJ80dKMf4FCL1Wa4M2z1eNHUV/ctwCsWk0pKUC73k79X9hn7ohqe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Name", "Password" },
                values: new object[] { "Astrid Valle", "$2a$11$87M/S6.qvQTUcyPLQM6UjO3qhtpRu9E3T43eJs3QHPqR5bzw83Dg." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Name", "Password" },
                values: new object[] { "Sherlyn Murillo", "$2a$11$EtKTjfk5UU1HrRup3ntVrevtEp.uIcNZ0BpiNblMcXCEpuUhEniy2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Name", "Password" },
                values: new object[] { "Ilsi Padilla", "$2a$11$NL2/i1p9mO2iJSGhLsi78.m1rAQ0t7BjPa3I5D6D6CkOyh9mLYiSe" });
        }
    }
}
