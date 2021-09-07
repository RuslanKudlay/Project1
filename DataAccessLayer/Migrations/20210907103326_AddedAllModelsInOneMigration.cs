using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class AddedAllModelsInOneMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComputerManufactyrers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ManufactyrerName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerManufactyrers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComtuperModels",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComputerManufactyrerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComtuperModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComtuperModels_ComputerManufactyrers_ComputerManufactyrerId",
                        column: x => x.ComputerManufactyrerId,
                        principalTable: "ComputerManufactyrers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComputerModelTags",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TagInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComputerModelId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SalesInfo_SalesDepartment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesInfo_DepartmentLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesInfo_DepartmentZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerModelTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComputerModelTags_ComtuperModels_ComputerModelId",
                        column: x => x.ComputerModelId,
                        principalTable: "ComtuperModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "Users");

            migrationBuilder.DropTable(
                name: "ComtuperModels");

            migrationBuilder.DropTable(
                name: "ComputerManufactyrers");
        }
    }
}
