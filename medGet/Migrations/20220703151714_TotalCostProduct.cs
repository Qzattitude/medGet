using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace medGet.Migrations
{
    public partial class TotalCostProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "TotalCostProduct",
                table: "OrderProduct",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25E46705-C687-4728-9A08-F81C0EAAFBE7",
                column: "ConcurrencyStamp",
                value: "4777e683-50d6-4fcc-ac00-6d2a85424c49");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49F70FB3-4F6E-4168-A912-A38658510A9F",
                column: "ConcurrencyStamp",
                value: "793b545b-9fcb-4865-b603-83107534b529");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4DABBE26-AD0E-4EC7-AA6F-A615E951BD83",
                column: "ConcurrencyStamp",
                value: "1d37e9bb-16cf-4bda-a4c4-6db3105e6108");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "49F70FB3-4F6E-4168-A912-A38658510A9F",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "50c37b4e-4262-45b6-9e41-af2c528323a8", "AQAAAAEAACcQAAAAELBed0e0rpqJwQwlHtoqEBJaiYs/zAxkSC0vm4MSK5Z1gx2xQ9NGUke/TP31U9yC+w==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalCostProduct",
                table: "OrderProduct");

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
    }
}
