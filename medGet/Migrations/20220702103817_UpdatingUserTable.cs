using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace medGet.Migrations
{
    public partial class UpdatingUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Contact",
                table: "AspNetUsers",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25E46705-C687-4728-9A08-F81C0EAAFBE7",
                column: "ConcurrencyStamp",
                value: "4f003904-6a02-4a41-bfd8-2c550ebe8e0e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49F70FB3-4F6E-4168-A912-A38658510A9F",
                column: "ConcurrencyStamp",
                value: "c9164498-269a-47e3-96f7-2cc3dab20133");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4DABBE26-AD0E-4EC7-AA6F-A615E951BD83",
                column: "ConcurrencyStamp",
                value: "dbbf42cd-e99a-4567-8f35-e3a88652275d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "49F70FB3-4F6E-4168-A912-A38658510A9F",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a74a3bb8-6893-410f-b584-98d55d8a1aea", "AQAAAAEAACcQAAAAEMuXq3x7qHEUHww0Gpolxun9jLPeHdrz2Y027cz/LcNenzy48VQknWfiIUHvf5zQHA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Contact",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25E46705-C687-4728-9A08-F81C0EAAFBE7",
                column: "ConcurrencyStamp",
                value: "356e5e51-1baa-4fdd-9cf2-46d2d77d2a28");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49F70FB3-4F6E-4168-A912-A38658510A9F",
                column: "ConcurrencyStamp",
                value: "661e0eac-4168-489b-b736-cd0b2be8d5ff");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4DABBE26-AD0E-4EC7-AA6F-A615E951BD83",
                column: "ConcurrencyStamp",
                value: "01fdd9de-0631-4b7b-92d2-cb33be3b1bfb");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "49F70FB3-4F6E-4168-A912-A38658510A9F",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ed5b96b7-e8e4-4f44-8a39-1d545d53e7eb", "AQAAAAEAACcQAAAAEFtZAIVbZyhYLih4NtDjQWtL+uu36gHImqTlNYkAWemsXJXNeLAVUu4kFv4K4sfJ6g==" });
        }
    }
}
