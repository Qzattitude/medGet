using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace medGet.Migrations
{
    public partial class MedicineByPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BrandName",
                table: "PriceVariation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "PriceVariation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ElementsQuantity",
                table: "PriceVariation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GenericElements",
                table: "PriceVariation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MedicineType",
                table: "PriceVariation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UsedFor",
                table: "PriceVariation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
                value: "91ea3f54-2a25-47c9-a849-631c80439559");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49F70FB3-4F6E-4168-A912-A38658510A9F",
                column: "ConcurrencyStamp",
                value: "02b3de67-edac-46a5-a9ab-4e3e37fdb287");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4DABBE26-AD0E-4EC7-AA6F-A615E951BD83",
                column: "ConcurrencyStamp",
                value: "b38db271-6d47-401f-a273-d9c9e2e3680b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "49F70FB3-4F6E-4168-A912-A38658510A9F",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "21ed2ce0-78be-437d-bd12-fbab4d46f92e", "AQAAAAEAACcQAAAAEDR6nyy/1JWr3h13jDYXA32VAWYajHBzPRNEAUX5KdOhZu27asv6XlJRMxFdEJXkbA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrandName",
                table: "PriceVariation");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "PriceVariation");

            migrationBuilder.DropColumn(
                name: "ElementsQuantity",
                table: "PriceVariation");

            migrationBuilder.DropColumn(
                name: "GenericElements",
                table: "PriceVariation");

            migrationBuilder.DropColumn(
                name: "MedicineType",
                table: "PriceVariation");

            migrationBuilder.DropColumn(
                name: "UsedFor",
                table: "PriceVariation");

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
