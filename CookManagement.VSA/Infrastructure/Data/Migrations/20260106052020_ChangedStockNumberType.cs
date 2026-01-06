using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookManagement.VSA.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedStockNumberType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "UserRecords",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2026, 1, 5, 23, 20, 15, 856, DateTimeKind.Unspecified).AddTicks(9275), new TimeSpan(0, -6, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2026, 1, 5, 23, 10, 43, 745, DateTimeKind.Unspecified).AddTicks(6204), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "UserRecords",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2026, 1, 5, 23, 20, 15, 856, DateTimeKind.Unspecified).AddTicks(6818), new TimeSpan(0, -6, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2026, 1, 5, 23, 10, 43, 745, DateTimeKind.Unspecified).AddTicks(4683), new TimeSpan(0, -6, 0, 0, 0)));

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
                columns: new[] { "Name", "Password" },
                values: new object[] { "Gperez", "$2a$11$C6kpQ45UpxOzIt3bBVCKhOG6mFTxn.XlYtJyg3hHyf8nEr2cAOlsW" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "UserRecords",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2026, 1, 5, 23, 10, 43, 745, DateTimeKind.Unspecified).AddTicks(6204), new TimeSpan(0, -6, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2026, 1, 5, 23, 20, 15, 856, DateTimeKind.Unspecified).AddTicks(9275), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "UserRecords",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2026, 1, 5, 23, 10, 43, 745, DateTimeKind.Unspecified).AddTicks(4683), new TimeSpan(0, -6, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2026, 1, 5, 23, 20, 15, 856, DateTimeKind.Unspecified).AddTicks(6818), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$3AezbaC.YLPUWYtCmkGY6.WAA.H.N8mlfZw7sXtdenM1uJUuKKseK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$qUQIZiV5Jnic7itnXOp2J.xadN7PrFTykzhYm5qRykKnjRCAQkDeG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$pwGGSIG6XJQx8tzETPuaY.PsdgsZqwnmxpUUyKQ864GgylAZuHRsm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$aAKSAr5lEDF0OD6gT2uqCe44iHG7eY1v6/38wDvbprEya54kpRAYy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$eXByNJeqg0H6Re4cZmKLcON.iXIT3sPHtUEGBg/a10peWWKONYTIe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$V8lhroaK8s53lmsumjW1eOdr5GV/maX1QzKe5SyRknaXAxRNqVJ62");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "$2a$11$b1ZSxZSBZnr3rdAJrmrmYeQVJaFRmUVjTbo0SnhDXHsPjN8TLJJTe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "$2a$11$XRBD737y/io27CRd/v7Xl.HMti1oFKSvzvU0GC1fqDGYjGIIaq3z.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "Password",
                value: "$2a$11$JrTrO7Zy2n4lA/WDNruSzOOkTkOMIgwudeEFhtqBNmNc29fBZ3Oma");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Name", "Password" },
                values: new object[] { "Jcastillo", "$2a$11$dPXNSoECuKwQXGM3F4xO7.F37Lb9XTE.Bb2ntcYmr9n7OE8eYkB1." });
        }
    }
}
