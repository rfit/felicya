using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FelicyaDB.Migrations
{
    public partial class TestMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    ProjectName = table.Column<string>(maxLength: 128, nullable: false),
                    ProjectLeader = table.Column<string>(maxLength: 128, nullable: false),
                    ProjectOwner = table.Column<string>(maxLength: 128, nullable: false),
                    ProjectDescription = table.Column<string>(maxLength: 128, nullable: false),
                    ProjectNumber = table.Column<int>(nullable: false),
                    BudgetNumber = table.Column<int>(nullable: false),
                    ConstructionLeader = table.Column<string>(maxLength: 128, nullable: false),
                    YearOfConstruction = table.Column<int>(nullable: false),
                    FestivalDivision = table.Column<string>(maxLength: 128, nullable: false),
                    Location = table.Column<string>(maxLength: 128, nullable: false),
                    ConstructionPurpose = table.Column<string>(maxLength: 128, nullable: false),
                    PhysicalSize = table.Column<int>(nullable: false),
                    PhysicalCapacity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    MaterialId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    Type = table.Column<int>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Height = table.Column<double>(nullable: false),
                    Length = table.Column<double>(nullable: false),
                    Width = table.Column<double>(nullable: false),
                    NumberOfUnits = table.Column<int>(nullable: false),
                    Purpose = table.Column<string>(maxLength: 64, nullable: false),
                    Disposal = table.Column<string>(maxLength: 64, nullable: false),
                    ProjectId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.MaterialId);
                    table.ForeignKey(
                        name: "FK_Materials_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Materials_ProjectId",
                table: "Materials",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
