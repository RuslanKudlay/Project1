using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class AddedComputerManufactyrerAndComputerModelTagAndComputerModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComputerManufactyrers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManufactyrerName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerManufactyrers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComtuperModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComputerManufactyrerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComtuperModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComtuperModels_ComputerManufactyrers_ComputerManufactyrerId",
                        column: x => x.ComputerManufactyrerId,
                        principalTable: "ComputerManufactyrers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComputerModelTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TagMeta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TagExpiration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComputerModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerModelTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComputerModelTags_ComtuperModels_ComputerModelId",
                        column: x => x.ComputerModelId,
                        principalTable: "ComtuperModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComputerModelTags_ComputerModelId",
                table: "ComputerModelTags",
                column: "ComputerModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ComtuperModels_ComputerManufactyrerId",
                table: "ComtuperModels",
                column: "ComputerManufactyrerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComputerModelTags");

            migrationBuilder.DropTable(
                name: "ComtuperModels");

            migrationBuilder.DropTable(
                name: "ComputerManufactyrers");
        }
    }
}
