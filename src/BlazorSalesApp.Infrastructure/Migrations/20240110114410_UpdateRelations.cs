using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorSalesApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubElements_Windows_WindowId",
                schema: "dbo",
                table: "SubElements");

            migrationBuilder.DropForeignKey(
                name: "FK_Windows_Orders_OrderId",
                schema: "dbo",
                table: "Windows");

            migrationBuilder.AlterColumn<long>(
                name: "OrderId",
                schema: "dbo",
                table: "Windows",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "WindowId",
                schema: "dbo",
                table: "SubElements",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SubElements_Windows_WindowId",
                schema: "dbo",
                table: "SubElements",
                column: "WindowId",
                principalSchema: "dbo",
                principalTable: "Windows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Windows_Orders_OrderId",
                schema: "dbo",
                table: "Windows",
                column: "OrderId",
                principalSchema: "dbo",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubElements_Windows_WindowId",
                schema: "dbo",
                table: "SubElements");

            migrationBuilder.DropForeignKey(
                name: "FK_Windows_Orders_OrderId",
                schema: "dbo",
                table: "Windows");

            migrationBuilder.AlterColumn<long>(
                name: "OrderId",
                schema: "dbo",
                table: "Windows",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "WindowId",
                schema: "dbo",
                table: "SubElements",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_SubElements_Windows_WindowId",
                schema: "dbo",
                table: "SubElements",
                column: "WindowId",
                principalSchema: "dbo",
                principalTable: "Windows",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Windows_Orders_OrderId",
                schema: "dbo",
                table: "Windows",
                column: "OrderId",
                principalSchema: "dbo",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
