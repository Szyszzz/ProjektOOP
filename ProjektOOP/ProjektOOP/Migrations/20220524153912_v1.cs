using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjektOOP.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MakerId",
                table: "Engine");

            migrationBuilder.DropColumn(
                name: "MakerId",
                table: "Chassis");

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_ChassisId",
                table: "CarModels",
                column: "ChassisId");

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_EngineId",
                table: "CarModels",
                column: "EngineId");

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_MakerId",
                table: "CarModels",
                column: "MakerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarModels_CarMakers_MakerId",
                table: "CarModels",
                column: "MakerId",
                principalTable: "CarMakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarModels_Chassis_ChassisId",
                table: "CarModels",
                column: "ChassisId",
                principalTable: "Chassis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarModels_Engine_EngineId",
                table: "CarModels",
                column: "EngineId",
                principalTable: "Engine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarModels_CarMakers_MakerId",
                table: "CarModels");

            migrationBuilder.DropForeignKey(
                name: "FK_CarModels_Chassis_ChassisId",
                table: "CarModels");

            migrationBuilder.DropForeignKey(
                name: "FK_CarModels_Engine_EngineId",
                table: "CarModels");

            migrationBuilder.DropIndex(
                name: "IX_CarModels_ChassisId",
                table: "CarModels");

            migrationBuilder.DropIndex(
                name: "IX_CarModels_EngineId",
                table: "CarModels");

            migrationBuilder.DropIndex(
                name: "IX_CarModels_MakerId",
                table: "CarModels");

            migrationBuilder.AddColumn<int>(
                name: "MakerId",
                table: "Engine",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MakerId",
                table: "Chassis",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
