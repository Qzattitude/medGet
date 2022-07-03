using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace medGet.Migrations
{
    public partial class OrderProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OrderProductId",
                table: "PriceVariation",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    OrderStatus = table.Column<bool>(type: "bit", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductBrand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Qunatity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25E46705-C687-4728-9A08-F81C0EAAFBE7",
                column: "ConcurrencyStamp",
                value: "0cb751b5-a398-4c91-a4b9-560f667f103b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49F70FB3-4F6E-4168-A912-A38658510A9F",
                column: "ConcurrencyStamp",
                value: "0d22a007-5a31-46f8-9e35-de2a5b66347a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4DABBE26-AD0E-4EC7-AA6F-A615E951BD83",
                column: "ConcurrencyStamp",
                value: "29b5752d-99b1-48a3-a69e-4db971bc71b1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "49F70FB3-4F6E-4168-A912-A38658510A9F",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9d827460-6ae2-4667-ba56-02808dc4141a", "AQAAAAEAACcQAAAAEI57XZv2A++lLciloCRpEsh3JC0y37G2K7gDwbui8SRhKHLv006BqT9hb1E8b4Bsag==" });

            migrationBuilder.CreateIndex(
                name: "IX_PriceVariation_OrderProductId",
                table: "PriceVariation",
                column: "OrderProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_PriceVariation_OrderProduct_OrderProductId",
                table: "PriceVariation",
                column: "OrderProductId",
                principalTable: "OrderProduct",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PriceVariation_OrderProduct_OrderProductId",
                table: "PriceVariation");

            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.DropIndex(
                name: "IX_PriceVariation_OrderProductId",
                table: "PriceVariation");

            migrationBuilder.DropColumn(
                name: "OrderProductId",
                table: "PriceVariation");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25E46705-C687-4728-9A08-F81C0EAAFBE7",
                column: "ConcurrencyStamp",
                value: "3cd7917d-68bc-49c5-99b8-3e5c9665c351");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49F70FB3-4F6E-4168-A912-A38658510A9F",
                column: "ConcurrencyStamp",
                value: "3df44a10-e205-4c8d-9f36-a76425b14a17");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4DABBE26-AD0E-4EC7-AA6F-A615E951BD83",
                column: "ConcurrencyStamp",
                value: "9ae14bfc-27a2-4756-8f29-c3a229f43ed1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "49F70FB3-4F6E-4168-A912-A38658510A9F",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "27a5d840-91c8-4f52-b925-81120c0ad587", "AQAAAAEAACcQAAAAEK1PJllEAmf+XXqMRBhra8qFQeD/p/Pvdnd1PV0jlcd+TwuD+VAu6PTWalyYIkAiNA==" });
        }
    }
}
