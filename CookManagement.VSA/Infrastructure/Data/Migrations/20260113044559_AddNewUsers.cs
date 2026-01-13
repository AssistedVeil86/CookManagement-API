using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookManagement.VSA.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNewUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "UserRecords",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2026, 1, 12, 22, 45, 56, 533, DateTimeKind.Unspecified).AddTicks(9163), new TimeSpan(0, -6, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2026, 1, 10, 22, 11, 9, 274, DateTimeKind.Unspecified).AddTicks(4001), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "UserRecords",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2026, 1, 12, 22, 45, 56, 533, DateTimeKind.Unspecified).AddTicks(8337), new TimeSpan(0, -6, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2026, 1, 10, 22, 11, 9, 274, DateTimeKind.Unspecified).AddTicks(3330), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$REAfSznGeEc/Znk77Htx7OX33HEulgxqicDF4Szd2yVUAC0HmQeZC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$Fuh8LvVLwEw3ertU3ZS0pO0Hl1vEQr7fM5OWCT4JhdQOgMeuWMnnS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$w7UpmeGBC8B2V7eWXYH93e7ptsEZibk8rvnoBXwXE6FP9UR/KxPNa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$OvurlxftIiFNcq4c3kDNnu6qJ5QQ4YCv149qcemIj65MSJzIuicZy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$4cINv0.do.dmaZYgHw27AOdAmvlluglpL.aK.s9HpOXvriZ1tGyti");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$aYFBaZkJFjJG3kJO2VBpzezRzQkRn.IK2M2bSxNTokpi2hA6YXe/u");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "$2a$11$nk/GVbJLCjUsNuQlv7cK5u9enEN.HhfFuEbxXC2sexeu0RzagMPqG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "$2a$11$rcVIjn1iZ/aWIDJjJ35truMlSFN/6waR5F6.G9f3H0ck7usmwecZa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "Password",
                value: "$2a$11$G3uQiwH.j9UdyiQGoHeghOttoYu0xW9W2SeBhQ8wtX9q4he4.MkcG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Name", "Password" },
                values: new object[] { "Lorebustillo", "$2a$11$loKK6dbPBuWGmai4HOfx6.nUMOLqIzD5XpnTy0VQEPBNE1OHoPaSm" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Name", "Password", "Role" },
                values: new object[] { "Elisanchez", "$2a$11$woU1KtL6iAv07y894MMpOuEqSnf4TRk6m.pX/xljv8cZgc2/5xkXS", "Bar" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "Password", "Role" },
                values: new object[] { 12, "AdminLinus", "$2a$11$S/80J1F/Tsfau6nkXBPaYufOqU59dnnnc2M12IHTPT17uKjevkyEi", "SuperAdmin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "UserRecords",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2026, 1, 10, 22, 11, 9, 274, DateTimeKind.Unspecified).AddTicks(4001), new TimeSpan(0, -6, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2026, 1, 12, 22, 45, 56, 533, DateTimeKind.Unspecified).AddTicks(9163), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "UserRecords",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2026, 1, 10, 22, 11, 9, 274, DateTimeKind.Unspecified).AddTicks(3330), new TimeSpan(0, -6, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2026, 1, 12, 22, 45, 56, 533, DateTimeKind.Unspecified).AddTicks(8337), new TimeSpan(0, -6, 0, 0, 0)));

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
                columns: new[] { "Name", "Password" },
                values: new object[] { "Gperez", "$2a$11$7iVypxRYKrDBjjdxWGobYuXRT5mt1Ah7NM2ydth4j0BOTWe9gB0DW" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Name", "Password", "Role" },
                values: new object[] { "AdminLinus", "$2a$11$5OI5E71AEc0msfe6/DWwx.rfh9bzvGqqKzKQtwPiAgHi2n1tQ36tG", "SuperAdmin" });
        }
    }
}
