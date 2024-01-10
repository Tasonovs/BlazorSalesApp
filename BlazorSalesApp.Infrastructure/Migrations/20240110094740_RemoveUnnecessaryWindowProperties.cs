using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorSalesApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUnnecessaryWindowProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalSubElements",
                schema: "dbo",
                table: "Windows");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalSubElements",
                schema: "dbo",
                table: "Windows",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
