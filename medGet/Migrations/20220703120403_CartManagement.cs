using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace medGet.Migrations
{
    public partial class CartManagement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "Id",
                keyValue: new Guid("26b70257-1477-4ef5-af02-2077450838ba"));

            migrationBuilder.AddColumn<Guid>(
                name: "CartId",
                table: "OrderProduct",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CartId",
                table: "OrderProduct");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25E46705-C687-4728-9A08-F81C0EAAFBE7",
                column: "ConcurrencyStamp",
                value: "7bbd4e6b-ae7c-4db8-a408-63e41cc0c47e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49F70FB3-4F6E-4168-A912-A38658510A9F",
                column: "ConcurrencyStamp",
                value: "b60aad0a-f0a8-44b8-94e2-e95bcebd53fd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4DABBE26-AD0E-4EC7-AA6F-A615E951BD83",
                column: "ConcurrencyStamp",
                value: "5f9db436-2cae-4f2f-b457-37865e55a182");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "49F70FB3-4F6E-4168-A912-A38658510A9F",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "365102f0-f88e-4408-a489-53b7870d5b48", "AQAAAAEAACcQAAAAED/SrkkXgiId/Yh4jJ70+siMjCA3dTPCG+ArERHs4OJgWOVpYwNR3+obS3vv8sV24g==" });

            migrationBuilder.InsertData(
                table: "OrderProduct",
                columns: new[] { "Id", "OrderId", "OrderStatus", "Price", "ProductBrand", "ProductId", "Qunatity", "UserName" },
                values: new object[] { new Guid("26b70257-1477-4ef5-af02-2077450838ba"), null, false, 0f, null, new Guid("00000000-0000-0000-0000-000000000000"), 0, null });
        }
    }
}
