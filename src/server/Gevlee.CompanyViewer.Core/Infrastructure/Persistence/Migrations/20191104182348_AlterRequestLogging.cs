using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gevlee.CompanyViewer.Core.Infrastructure.Persistence.Migrations
{
    public partial class AlterRequestLogging : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "company_search_request");

            migrationBuilder.AlterColumn<string>(
                name: "national_court_register_number",
                table: "company",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(9)",
                oldMaxLength: 9,
                oldComment: "National Court Register Number");

            migrationBuilder.AlterColumn<string>(
                name: "national_business_registry_number",
                table: "company",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(9)",
                oldMaxLength: 9,
                oldComment: "National Business Registry Number");

            migrationBuilder.CreateTable(
                name: "api_request",
                columns: table => new
                {
                    timestamp = table.Column<DateTime>(nullable: false),
                    ip = table.Column<string>(maxLength: 15, nullable: true),
                    request_data = table.Column<string>(type: "jsonb", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "api_request");

            migrationBuilder.AlterColumn<string>(
                name: "national_court_register_number",
                table: "company",
                type: "character varying(9)",
                maxLength: 9,
                nullable: false,
                comment: "National Court Register Number",
                oldClrType: typeof(string),
                oldMaxLength: 9);

            migrationBuilder.AlterColumn<string>(
                name: "national_business_registry_number",
                table: "company",
                type: "character varying(9)",
                maxLength: 9,
                nullable: false,
                comment: "National Business Registry Number",
                oldClrType: typeof(string),
                oldMaxLength: 9);

            migrationBuilder.CreateTable(
                name: "company_search_request",
                columns: table => new
                {
                    ip = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    request_data = table.Column<string>(type: "jsonb", nullable: false),
                    search_phrase = table.Column<string>(type: "text", nullable: false),
                    timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                });
        }
    }
}
