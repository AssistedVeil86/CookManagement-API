using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookManagement.VSA.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeIntToDouble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "UserRecords",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2026, 1, 10, 22, 11, 9, 274, DateTimeKind.Unspecified).AddTicks(4001), new TimeSpan(0, -6, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2026, 1, 7, 15, 49, 12, 456, DateTimeKind.Unspecified).AddTicks(3366), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.AlterColumn<double>(
                name: "Remains",
                table: "UserRecords",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<double>(
                name: "InitialInventory",
                table: "UserRecords",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<double>(
                name: "FinalInventory",
                table: "UserRecords",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<double>(
                name: "Difference",
                table: "UserRecords",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<double>(
                name: "Damaged",
                table: "UserRecords",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<double>(
                name: "DailyMove",
                table: "UserRecords",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "UserRecords",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2026, 1, 10, 22, 11, 9, 274, DateTimeKind.Unspecified).AddTicks(3330), new TimeSpan(0, -6, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2026, 1, 7, 15, 49, 12, 456, DateTimeKind.Unspecified).AddTicks(1854), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.AlterColumn<double>(
                name: "Courtesy",
                table: "UserRecords",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$cB2aRwke1qM.tKH.BmQhBuo9SY.4xFgOU1e0M8qG8cOK7TevW9BxS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$pZ5knWvB2drorA.x0iSH/.R/eMUyQzA9xCM4lvTUyxbsZms.JDM5C");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$D2jELz.WRh80Rlpf1rhqzO0PJGQQSC6WY397TsN2rRRwf7lotNSMS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$MRhizFdZeAvEw6WCcIJpruHDWw1dBTSexwQRxGt8dNIxFNlmT9dj6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$WaobqhXU46V5Tni2sqFE5u.rZH570fe282kYOmji2BAJvLgFlHewK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$Et4Xni0J98xk78IoeQTH3uZXWhMnn4VMyuBNsonhqW7myaVV/ICSy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "$2a$11$KDv35iuu.esflAYmYD6dh.WeFFAwf6yW1GKsR1AcGyKxhPrb5VRdi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "$2a$11$xsQe8Jbu2KiH.WjLuTv29etltFOo8pEIRtRsCdyn2lPxaqyqPD1aq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "Password",
                value: "$2a$11$CkP6j0E3ai.tz50bpggYLOsTtVg4Zt4LMPM.Qw6ni.iT91Ykzwzsu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "Password",
                value: "$2a$11$7iVypxRYKrDBjjdxWGobYuXRT5mt1Ah7NM2ydth4j0BOTWe9gB0DW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "Password",
                value: "$2a$11$5OI5E71AEc0msfe6/DWwx.rfh9bzvGqqKzKQtwPiAgHi2n1tQ36tG");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "UserRecords",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2026, 1, 7, 15, 49, 12, 456, DateTimeKind.Unspecified).AddTicks(3366), new TimeSpan(0, -6, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2026, 1, 10, 22, 11, 9, 274, DateTimeKind.Unspecified).AddTicks(4001), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.AlterColumn<int>(
                name: "Remains",
                table: "UserRecords",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<int>(
                name: "InitialInventory",
                table: "UserRecords",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<int>(
                name: "FinalInventory",
                table: "UserRecords",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<int>(
                name: "Difference",
                table: "UserRecords",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<int>(
                name: "Damaged",
                table: "UserRecords",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<int>(
                name: "DailyMove",
                table: "UserRecords",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "UserRecords",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2026, 1, 7, 15, 49, 12, 456, DateTimeKind.Unspecified).AddTicks(1854), new TimeSpan(0, -6, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2026, 1, 10, 22, 11, 9, 274, DateTimeKind.Unspecified).AddTicks(3330), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.AlterColumn<int>(
                name: "Courtesy",
                table: "UserRecords",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldDefaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$aElS0hr6kgwIr0X.brMh5uuTvi73CQW5GABfYPFKusabGwUWdyO16");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$blGVpdghJa.CegLgvKG8qO9qUgqOaEHSJHizAWRiYQrAX9mziUMn2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$CjVUWTGXwxY4vNKRd0lYAexfYotn/r8yFde.CyP55bhkKgdYKXqUa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$WClTW5H6sFdmCCwpora9auu42eaf0A7I8XnvOZCp0GhFNOamqatfe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$sKvEiP3IeT6loYwNUNcH6uejIOvFJgX47eGzspu7zvoOavBhClpDu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$seXD2yWRfoHwwpOuoerdWOeq.JJVlMbE.PPtAXZQWgwYIAeOOJM1i");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "$2a$11$cc9VqcLdY8uKe8HXF/IXEuPahlEkZc6b6E6.zeM7CX1tgeo50Reo6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "$2a$11$DYn0HSFfeH3waYcTURasIOr2moezNVVfvWGv7vsq7STKwPce1P.ju");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "Password",
                value: "$2a$11$fiwD6A0qlX4pzdC339j8auS794DMzFBpnfu0WuRlcxLlJReZSWlrO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "Password",
                value: "$2a$11$mGbF86VoAmOWm0SednWlm.bbGnCmfigGOBpZVcHTT2O5nmmttujei");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "Password",
                value: "$2a$11$VXyDpEc.0Ib96s8LpT.51OKfNYAE6HnswSnvW0ZsMMRHr1NdC6wf.");
        }
    }
}
