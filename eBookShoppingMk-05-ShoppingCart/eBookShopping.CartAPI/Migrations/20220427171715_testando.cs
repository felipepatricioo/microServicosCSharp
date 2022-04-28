using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eBookShopping.CartAPI.Migrations
{
    public partial class testando : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cart_detail_cart_header_ProductId",
                table: "cart_detail");

            migrationBuilder.AlterColumn<string>(
                name: "coupon_code",
                table: "cart_header",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_cart_detail_product_ProductId",
                table: "cart_detail",
                column: "ProductId",
                principalTable: "product",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cart_detail_product_ProductId",
                table: "cart_detail");

            migrationBuilder.UpdateData(
                table: "cart_header",
                keyColumn: "coupon_code",
                keyValue: null,
                column: "coupon_code",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "coupon_code",
                table: "cart_header",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_cart_detail_cart_header_ProductId",
                table: "cart_detail",
                column: "ProductId",
                principalTable: "cart_header",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
