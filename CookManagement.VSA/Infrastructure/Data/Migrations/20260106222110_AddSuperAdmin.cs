using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookManagement.VSA.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSuperAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "UserRecords",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2026, 1, 6, 16, 21, 7, 837, DateTimeKind.Unspecified).AddTicks(685), new TimeSpan(0, -6, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2026, 1, 5, 23, 20, 15, 856, DateTimeKind.Unspecified).AddTicks(9275), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "UserRecords",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2026, 1, 6, 16, 21, 7, 836, DateTimeKind.Unspecified).AddTicks(9910), new TimeSpan(0, -6, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2026, 1, 5, 23, 20, 15, 856, DateTimeKind.Unspecified).AddTicks(6818), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$I4X8ksAF1A9LpuYCJovTdOqaFiOZi9iWob2f29Aj0Dy8sOACo2RkC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$UrBn2xKd9Te9Md7J8Pv2Q.L6haROAxdXqSazrYPx4FeJNUT5k9ica");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$Gh1s1cSkkev33oEO2L/VYO3ZmYi8V6W0/Ud/wYbEJtO5kM7/qlqpm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$P/LUBKXEe.nk/hHg8.K3buVgHiuiK7HDM9Xu8t.HIeJL7nLYAV5DG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$ebKlOCnD3ID.n0QidvLko.ApfeZrzqikpH9cjv7iUT22TP6UYxt8W");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$6f38mluGfjYSXf6tpx0cxuCvMhBvjFbN/CKW7efF1oqSLhKzDrU8m");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "$2a$11$VsjxDiii/qHmmFI9xcNLWODPlOyG1CcEzt6n8pMq3sdXO7.wRpFGG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "$2a$11$eUwrJbrFNdso67l1CtxN8.u0yXyYccpLotc7ip/NJ9.YuOn9CbIXS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "Password",
                value: "$2a$11$pz9s0U.fDEZ7RJfTJVG8we9ruQgAEY3G.wc7nnglin80IEu3U7Hg2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "Password",
                value: "$2a$11$i1JEIIOkL/z84shhOGB.O.yd2..0RA9E6ksu2rIQo8rEjtTTW0Pkq");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "Password", "Role" },
                values: new object[] { 11, "AdminLinus", "$2a$11$FRGsD3hI7RQfAhnK.ue6kO96ujMWW72rfmNy9xNb44c8An6YJNAD6", "SuperAdmin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "UserRecords",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2026, 1, 5, 23, 20, 15, 856, DateTimeKind.Unspecified).AddTicks(9275), new TimeSpan(0, -6, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2026, 1, 6, 16, 21, 7, 837, DateTimeKind.Unspecified).AddTicks(685), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "UserRecords",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2026, 1, 5, 23, 20, 15, 856, DateTimeKind.Unspecified).AddTicks(6818), new TimeSpan(0, -6, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2026, 1, 6, 16, 21, 7, 836, DateTimeKind.Unspecified).AddTicks(9910), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$UEkM3opzq17e8AhGeGIUYe..KGetx6gKOcqrcaFl8vc0WmrMd4Nqa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$r3WNHTuc0SkY02S48LrK8.Zs0Z0NQ90MDbXxPy6Xv4RTMj3TVcs86");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$NxDwlOtpsljFJeyODG/G9eDBm8NxFKrT6/Uud.AFLSecTWgz.73um");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$8MNvFMZusRAWEHTu771bE.YwZfcsUUU.K2KhGMHpFHR5pzGd9l5hW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$3XqAMQKih2G84B/pW2hM9ex2bB5/AiQxt.F/0hrngUlnf7R5TQmb6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$uo9BQ6gw.QVUyZSyq6vIyO/ZLGZ1fj5e7HH2oYW7inTHLD/dliSvu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "$2a$11$Pjr/oI5YAGz3.e7fZEx8KuqLinbYvnhmmUS36D/pCLGtTiyPf20cO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "$2a$11$ri2dKmLr3SGlW5o2xbHC.OsAyGIC1v2niASUHVXquZFR95mazYGNm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "Password",
                value: "$2a$11$nhyctQDc2WkVHsCr.57bvO5fH3f0slzqmlxr7MH2U6ydz/7L94poq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "Password",
                value: "$2a$11$C6kpQ45UpxOzIt3bBVCKhOG6mFTxn.XlYtJyg3hHyf8nEr2cAOlsW");
        }
    }
}
