using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FelicyaDB.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Projects_ProjectId",
                table: "Materials");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProjectId",
                table: "Materials",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CO2Measure",
                table: "Materials",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MaterialSort",
                table: "Materials",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Projects_ProjectId",
                table: "Materials",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Projects_ProjectId",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "CO2Measure",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "MaterialSort",
                table: "Materials");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProjectId",
                table: "Materials",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Projects_ProjectId",
                table: "Materials",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
