using Microsoft.EntityFrameworkCore.Migrations;

namespace Gevlee.CompanyViewer.Core.Infrastructure.Persistence.Migrations
{
    public partial class RemoveIpColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ip",
                table: "api_request");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ip",
                table: "api_request",
                type: "character varying(15)",
                maxLength: 15,
                nullable: true);
        }
    }
}
