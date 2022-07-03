using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace medGet.Migrations
{
    public partial class CartEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25E46705-C687-4728-9A08-F81C0EAAFBE7",
                column: "ConcurrencyStamp",
                value: "344f4959-a731-4063-af36-bba6a440cf6d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49F70FB3-4F6E-4168-A912-A38658510A9F",
                column: "ConcurrencyStamp",
                value: "270bea98-8fa0-44d6-94b4-938e99231a7d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4DABBE26-AD0E-4EC7-AA6F-A615E951BD83",
                column: "ConcurrencyStamp",
                value: "6b21061e-426e-4ec1-ba1d-970d5d6be9ef");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "49F70FB3-4F6E-4168-A912-A38658510A9F",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ecdaef77-ed8f-48f8-a8d0-13c676bb922d", "AQAAAAEAACcQAAAAEJ/g/HvPQ7K06sCUW4tZBYutQvbGJhxXFdWXrLGif0oiifGIRM9C7u2DycenUHacgA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25E46705-C687-4728-9A08-F81C0EAAFBE7",
                column: "ConcurrencyStamp",
                value: "b24f3a95-3953-40e4-aafa-5b870f973ded");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49F70FB3-4F6E-4168-A912-A38658510A9F",
                column: "ConcurrencyStamp",
                value: "97e0be73-74d8-496f-8d0f-ac9800236a76");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4DABBE26-AD0E-4EC7-AA6F-A615E951BD83",
                column: "ConcurrencyStamp",
                value: "6f0a6923-4261-462c-bcec-8c7fcbbd4b55");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "49F70FB3-4F6E-4168-A912-A38658510A9F",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "21081643-a1fb-4b2f-b886-c02288f62771", "AQAAAAEAACcQAAAAEC8+ck/JZYjMlqY8gVgKycas1RyWzkD+HZkMKpT2u3FoaypyrZ/H6C1hk7BMuyYgog==" });
        }
    }
}
