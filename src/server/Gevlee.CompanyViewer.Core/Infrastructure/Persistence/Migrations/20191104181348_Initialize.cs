using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Gevlee.CompanyViewer.Core.Infrastructure.Persistence.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    street = table.Column<string>(maxLength: 100, nullable: false),
                    house_number = table.Column<string>(maxLength: 10, nullable: false),
                    appartment_number = table.Column<string>(nullable: true),
                    postal_code = table.Column<string>(maxLength: 10, nullable: false),
                    city = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_address", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "company_search_request",
                columns: table => new
                {
                    search_phrase = table.Column<string>(nullable: false),
                    request_data = table.Column<string>(type: "jsonb", nullable: false),
                    timestamp = table.Column<DateTime>(nullable: false),
                    ip = table.Column<string>(maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "company",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(maxLength: 255, nullable: false),
                    tax_number = table.Column<string>(maxLength: 10, nullable: false),
                    national_business_registry_number = table.Column<string>(maxLength: 9, nullable: false),
                    national_court_register_number = table.Column<string>(maxLength: 9, nullable: false),
                    address_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_company", x => x.id);
                    table.ForeignKey(
                        name: "fk_company_address_address_id",
                        column: x => x.address_id,
                        principalTable: "address",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_company_address_id",
                table: "company",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "ix_company_national_business_registry_number",
                table: "company",
                column: "national_business_registry_number");

            migrationBuilder.CreateIndex(
                name: "ix_company_national_court_register_number",
                table: "company",
                column: "national_court_register_number");

            migrationBuilder.CreateIndex(
                name: "ix_company_tax_number",
                table: "company",
                column: "tax_number");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "company");

            migrationBuilder.DropTable(
                name: "company_search_request");

            migrationBuilder.DropTable(
                name: "address");
        }
    }
}
