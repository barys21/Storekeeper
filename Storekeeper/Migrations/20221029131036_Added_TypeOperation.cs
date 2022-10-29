using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Storekeeper.Migrations
{
    public partial class Added_TypeOperation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeOperationId",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TypeOperations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOperations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_TypeOperationId",
                table: "Products",
                column: "TypeOperationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_TypeOperations_TypeOperationId",
                table: "Products",
                column: "TypeOperationId",
                principalTable: "TypeOperations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_TypeOperations_TypeOperationId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "TypeOperations");

            migrationBuilder.DropIndex(
                name: "IX_Products_TypeOperationId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TypeOperationId",
                table: "Products");
        }
    }
}
