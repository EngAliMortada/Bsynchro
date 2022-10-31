using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bsynchro.Migrations
{
    public partial class removebalancefromcustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Customers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "Customers",
                type: "decimal(20,0)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
