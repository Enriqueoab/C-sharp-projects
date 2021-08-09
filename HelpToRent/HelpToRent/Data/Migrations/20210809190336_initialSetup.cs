using Microsoft.EntityFrameworkCore.Migrations;

namespace HelpToRent.Data.Migrations
{
    public partial class initialSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "House",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Direction = table.Column<string>(nullable: true),
                    Price = table.Column<float>(nullable: false),
                    Bills = table.Column<int>(nullable: false),
                    Deposit = table.Column<float>(nullable: false),
                    ContractPeriod = table.Column<int>(nullable: false),
                    ContactName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_House", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "House");
        }
    }
}
