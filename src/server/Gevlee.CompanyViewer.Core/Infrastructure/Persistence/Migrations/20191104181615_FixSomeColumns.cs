using Microsoft.EntityFrameworkCore.Migrations;

namespace Gevlee.CompanyViewer.Core.Infrastructure.Persistence.Migrations
{
    public partial class FixSomeColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "national_court_register_number",
                table: "company",
                maxLength: 9,
                nullable: false,
                comment: "National Court Register Number",
                oldClrType: typeof(string),
                oldType: "character varying(9)",
                oldMaxLength: 9);

            migrationBuilder.AlterColumn<string>(
                name: "national_business_registry_number",
                table: "company",
                maxLength: 9,
                nullable: false,
                comment: "National Business Registry Number",
                oldClrType: typeof(string),
                oldType: "character varying(9)",
                oldMaxLength: 9);

            migrationBuilder.AlterColumn<string>(
                name: "appartment_number",
                table: "address",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "national_court_register_number",
                table: "company",
                type: "character varying(9)",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 9,
                oldComment: "National Court Register Number");

            migrationBuilder.AlterColumn<string>(
                name: "national_business_registry_number",
                table: "company",
                type: "character varying(9)",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 9,
                oldComment: "National Business Registry Number");

            migrationBuilder.AlterColumn<string>(
                name: "appartment_number",
                table: "address",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);
        }
    }
}
