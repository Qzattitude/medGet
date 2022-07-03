using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace medGet.Migrations
{
    public partial class PaymentPage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "OrderProduct",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25E46705-C687-4728-9A08-F81C0EAAFBE7",
                column: "ConcurrencyStamp",
                value: "37db2e79-c27e-4503-a16c-d5c5e23995f9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49F70FB3-4F6E-4168-A912-A38658510A9F",
                column: "ConcurrencyStamp",
                value: "9f749039-a778-48ca-bcf5-931adaea92e7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4DABBE26-AD0E-4EC7-AA6F-A615E951BD83",
                column: "ConcurrencyStamp",
                value: "a25a23c5-0725-4145-a3d2-93b5fa8d6a01");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "49F70FB3-4F6E-4168-A912-A38658510A9F",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "81f7510a-e918-4e2f-8e4e-23508543910a", "AQAAAAEAACcQAAAAEKgDWG/mfj9BfZHN1mrzdfojgpVLCFMpQsJu+iulqcPGeJxGw7h4HCBZTTypcYimCw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "OrderProduct");

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
    }
}
