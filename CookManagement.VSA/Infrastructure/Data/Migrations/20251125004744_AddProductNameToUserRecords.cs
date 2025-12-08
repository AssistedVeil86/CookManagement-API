using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookManagement.VSA.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddProductNameToUserRecords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserRecords_UserId",
                table: "UserRecords");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "UserRecords",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2025, 11, 24, 18, 47, 42, 767, DateTimeKind.Unspecified).AddTicks(8503), new TimeSpan(0, -6, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2025, 11, 21, 17, 6, 40, 992, DateTimeKind.Unspecified).AddTicks(7828), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "UserRecords",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2025, 11, 24, 18, 47, 42, 767, DateTimeKind.Unspecified).AddTicks(7734), new TimeSpan(0, -6, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2025, 11, 21, 17, 6, 40, 992, DateTimeKind.Unspecified).AddTicks(7209), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "UserRecords",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$6ssgrCTy2PpEFMHwJIy8IultnEW1G3e9Js9mA1JTzKbLmNFCGV5o2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$eB7Dw.gQjmDhvh1apI.LJuzMvaPeDXryxLgsPMW//TGzkEb0fj85i");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$GKxRzL6yrT/cFGHBN8xcbud9E53L2.PrfdgqIscpSASMH1HqO6M.K");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$iaVotQmmcaJ9eIxSizJnBuEZnmPa8h2WbAj7C5pdu6uu9qNYIjaSu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$obJ80dKMf4FCL1Wa4M2z1eNHUV/ctwCsWk0pKUC73k79X9hn7ohqe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$87M/S6.qvQTUcyPLQM6UjO3qhtpRu9E3T43eJs3QHPqR5bzw83Dg.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "$2a$11$EtKTjfk5UU1HrRup3ntVrevtEp.uIcNZ0BpiNblMcXCEpuUhEniy2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "$2a$11$NL2/i1p9mO2iJSGhLsi78.m1rAQ0t7BjPa3I5D6D6CkOyh9mLYiSe");

            migrationBuilder.CreateIndex(
                name: "IX_UserRecords_UserId_ProductCode_CreatedAt",
                table: "UserRecords",
                columns: new[] { "UserId", "ProductCode", "CreatedAt" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserRecords_UserId_ProductCode_CreatedAt",
                table: "UserRecords");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "UserRecords");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "UserRecords",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2025, 11, 21, 17, 6, 40, 992, DateTimeKind.Unspecified).AddTicks(7828), new TimeSpan(0, -6, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2025, 11, 24, 18, 47, 42, 767, DateTimeKind.Unspecified).AddTicks(8503), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "UserRecords",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2025, 11, 21, 17, 6, 40, 992, DateTimeKind.Unspecified).AddTicks(7209), new TimeSpan(0, -6, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2025, 11, 24, 18, 47, 42, 767, DateTimeKind.Unspecified).AddTicks(7734), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$JaoOStPmDDO9HWbUuN05KeCDWwPys.7LHodBjmT9/jYEkLzEzw.5y");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$Mw4w9xlG60dm3LYpCjYRKO5kH1trMDi/xMoscngwMRhPKQzm5k8T6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$iH4pYGoYXS7QA9uFiva8ieq5819Tuz0Bj3w85Ej4kAzbN1AbOFRnW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$dRMoGVaB1EsZvwfPln45AO0ENAjL1ZYK/kv6D3.mTgSuoJgUd3B66");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$L23/MqEO51XqsaGMf1GN7uy1gAN1FInGDCWcR6MwipYimt0ctjSma");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$pctrMKyRY5grOUJ.1b5FieFjifagvgSgQX4n2tTxfphYgLUleu0WG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "$2a$11$FrEmxVFv8FjW5Nc2wPA7COCeRK61B2gzXC5lhOt4bTEktbAf/anBu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "$2a$11$g/IWdXt6tTlhZJ/StmqKyuyfSHfx0YPL5GHINVBf.T8L7TdXE.huu");

            migrationBuilder.CreateIndex(
                name: "IX_UserRecords_UserId",
                table: "UserRecords",
                column: "UserId");
        }
    }
}
