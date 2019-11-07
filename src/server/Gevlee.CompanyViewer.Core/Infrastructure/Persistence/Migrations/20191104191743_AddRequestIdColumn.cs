using Microsoft.EntityFrameworkCore.Migrations;

namespace Gevlee.CompanyViewer.Core.Infrastructure.Persistence.Migrations
{
    public partial class AddRequestIdColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "id",
                table: "api_request",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "pk_api_request",
                table: "api_request",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_api_request",
                table: "api_request");

            migrationBuilder.DropColumn(
                name: "id",
                table: "api_request");
        }
    }
}
