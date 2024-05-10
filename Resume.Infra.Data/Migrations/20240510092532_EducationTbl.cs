using Microsoft.EntityFrameworkCore.Migrations;

namespace Resume.Infra.Data.Migrations
{
    public partial class EducationTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerLogo",
                table: "CustomerLogo");

            migrationBuilder.RenameTable(
                name: "CustomerLogo",
                newName: "CustomerLogos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerLogos",
                table: "CustomerLogos",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartDate = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    EndDate = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerLogos",
                table: "CustomerLogos");

            migrationBuilder.RenameTable(
                name: "CustomerLogos",
                newName: "CustomerLogo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerLogo",
                table: "CustomerLogo",
                column: "Id");
        }
    }
}
