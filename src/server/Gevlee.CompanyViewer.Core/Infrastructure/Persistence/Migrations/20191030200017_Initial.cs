using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Gevlee.CompanyViewer.Core.Infrastructure.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    street = table.Column<string>(nullable: false),
                    house_number = table.Column<string>(nullable: false),
                    appartment_number = table.Column<string>(nullable: true),
                    postal_code = table.Column<string>(nullable: false),
                    city = table.Column<string>(nullable: false)
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
                    request_data = table.Column<string>(nullable: false)
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
                    tax_number = table.Column<string>(nullable: false),
                    national_business_registry_number = table.Column<string>(nullable: false),
                    national_court_register = table.Column<string>(nullable: false),
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
                name: "ix_company_national_court_register",
                table: "company",
                column: "national_court_register");

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
