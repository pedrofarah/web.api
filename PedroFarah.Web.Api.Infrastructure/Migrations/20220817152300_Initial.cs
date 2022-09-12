using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PedroFarah.Web.Api.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_ORDER",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DATE_TIME = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PERSON_DOCUMENT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AMOUNT = table.Column<double>(type: "float", nullable: false),
                    CASHBACK_AMOUNT = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ORDER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_PRODUCT_CATEGORY",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PRODUCT_CATEGORY", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_CASHBACK",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TB_PRODUCT_CATEGORY_ID = table.Column<long>(type: "bigint", nullable: false),
                    SUNDAY_VALUE = table.Column<double>(type: "float", nullable: false),
                    MONDAY_VALUE = table.Column<double>(type: "float", nullable: false),
                    TUESDAY_VALUE = table.Column<double>(type: "float", nullable: false),
                    WEDNESDAY_VALUE = table.Column<double>(type: "float", nullable: false),
                    THURSDAY_VALUE = table.Column<double>(type: "float", nullable: false),
                    FRIDAY_VALUE = table.Column<double>(type: "float", nullable: false),
                    SATURDAY_VALUE = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CASHBACK", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_CASHBACK_TB_PRODUCT_CATEGORY_TB_PRODUCT_CATEGORY_ID",
                        column: x => x.TB_PRODUCT_CATEGORY_ID,
                        principalTable: "TB_PRODUCT_CATEGORY",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "TB_PRODUCT",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PRICE = table.Column<double>(type: "float", nullable: false),
                    TB_PRODUCT_CATEGORY_ID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PRODUCT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_PRODUCT_TB_PRODUCT_CATEGORY_TB_PRODUCT_CATEGORY_ID",
                        column: x => x.TB_PRODUCT_CATEGORY_ID,
                        principalTable: "TB_PRODUCT_CATEGORY",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "TB_ORDER_ITEM",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TB_ORDER_ID = table.Column<long>(type: "bigint", nullable: false),
                    ITEM_NUMBER = table.Column<int>(type: "int", nullable: false),
                    TB_PRODUCT_ID = table.Column<long>(type: "bigint", nullable: false),
                    QUANTITY = table.Column<double>(type: "float", nullable: false),
                    AMOUNT = table.Column<double>(type: "float", nullable: false),
                    CASHBACK_AMOUNT = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ORDER_ITEM", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_ORDER_ITEM_TB_ORDER_TB_ORDER_ID",
                        column: x => x.TB_ORDER_ID,
                        principalTable: "TB_ORDER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_ORDER_ITEM_TB_PRODUCT_TB_PRODUCT_ID",
                        column: x => x.TB_PRODUCT_ID,
                        principalTable: "TB_PRODUCT",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "TB_PRODUCT_CATEGORY",
                columns: new[] { "ID", "NAME" },
                values: new object[,]
                {
                    { 1L, "SKOL" },
                    { 2L, "BRAHMA" },
                    { 3L, "STELLA" },
                    { 4L, "BOHEMIA" }
                });

            migrationBuilder.InsertData(
                table: "TB_CASHBACK",
                columns: new[] { "ID", "FRIDAY_VALUE", "MONDAY_VALUE", "TB_PRODUCT_CATEGORY_ID", "SATURDAY_VALUE", "SUNDAY_VALUE", "THURSDAY_VALUE", "TUESDAY_VALUE", "WEDNESDAY_VALUE" },
                values: new object[,]
                {
                    { 1L, 15.0, 7.0, 1L, 20.0, 25.0, 10.0, 6.0, 2.0 },
                    { 2L, 25.0, 5.0, 2L, 30.0, 30.0, 20.0, 10.0, 15.0 },
                    { 3L, 18.0, 3.0, 3L, 25.0, 35.0, 13.0, 5.0, 8.0 },
                    { 4L, 20.0, 10.0, 4L, 40.0, 40.0, 15.0, 15.0, 15.0 }
                });

            migrationBuilder.InsertData(
                table: "TB_PRODUCT",
                columns: new[] { "ID", "NAME", "PRICE", "TB_PRODUCT_CATEGORY_ID" },
                values: new object[,]
                {
                    { 1L, "SKOL 1L", 9.5, 1L },
                    { 2L, "BRAHMA 1L", 9.3000000000000007, 2L },
                    { 3L, "STELLA 1L", 7.4000000000000004, 3L },
                    { 4L, "BOHEMIA 1L", 8.9000000000000004, 4L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_CASHBACK_TB_PRODUCT_CATEGORY_ID",
                table: "TB_CASHBACK",
                column: "TB_PRODUCT_CATEGORY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ORDER_ITEM_TB_ORDER_ID",
                table: "TB_ORDER_ITEM",
                column: "TB_ORDER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ORDER_ITEM_TB_PRODUCT_ID",
                table: "TB_ORDER_ITEM",
                column: "TB_PRODUCT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PRODUCT_TB_PRODUCT_CATEGORY_ID",
                table: "TB_PRODUCT",
                column: "TB_PRODUCT_CATEGORY_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_CASHBACK");

            migrationBuilder.DropTable(
                name: "TB_ORDER_ITEM");

            migrationBuilder.DropTable(
                name: "TB_ORDER");

            migrationBuilder.DropTable(
                name: "TB_PRODUCT");

            migrationBuilder.DropTable(
                name: "TB_PRODUCT_CATEGORY");
        }
    }
}
