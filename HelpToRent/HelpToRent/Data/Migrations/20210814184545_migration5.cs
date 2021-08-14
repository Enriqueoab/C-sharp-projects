using Microsoft.EntityFrameworkCore.Migrations;

namespace HelpToRent.Data.Migrations
{
    public partial class migration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BillId",
                table: "House",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DirectionsId",
                table: "House",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllBillsIncluded = table.Column<bool>(nullable: false),
                    BillComment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Direction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(nullable: true),
                    Town = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direction", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_House_BillId",
                table: "House",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_House_DirectionsId",
                table: "House",
                column: "DirectionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_House_Bill_BillId",
                table: "House",
                column: "BillId",
                principalTable: "Bill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_House_Direction_DirectionsId",
                table: "House",
                column: "DirectionsId",
                principalTable: "Direction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_House_Bill_BillId",
                table: "House");

            migrationBuilder.DropForeignKey(
                name: "FK_House_Direction_DirectionsId",
                table: "House");

            migrationBuilder.DropTable(
                name: "Bill");

            migrationBuilder.DropTable(
                name: "Direction");

            migrationBuilder.DropIndex(
                name: "IX_House_BillId",
                table: "House");

            migrationBuilder.DropIndex(
                name: "IX_House_DirectionsId",
                table: "House");

            migrationBuilder.DropColumn(
                name: "BillId",
                table: "House");

            migrationBuilder.DropColumn(
                name: "DirectionsId",
                table: "House");
        }
    }
}
