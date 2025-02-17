using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class Seedingfordatadiffandregion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Walks_Difficulty_DifficultyId1",
                table: "Walks");

            migrationBuilder.DropForeignKey(
                name: "FK_Walks_Regions_RegionId1",
                table: "Walks");

            migrationBuilder.DropIndex(
                name: "IX_Walks_DifficultyId1",
                table: "Walks");

            migrationBuilder.DropIndex(
                name: "IX_Walks_RegionId1",
                table: "Walks");

            migrationBuilder.DeleteData(
                table: "Difficulty",
                keyColumn: "Id",
                keyValue: "11");

            migrationBuilder.DeleteData(
                table: "Difficulty",
                keyColumn: "Id",
                keyValue: "22");

            migrationBuilder.DeleteData(
                table: "Difficulty",
                keyColumn: "Id",
                keyValue: "33");

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: "10");

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: "20");

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: "30");

            migrationBuilder.DropColumn(
                name: "DifficultyId",
                table: "Walks");

            migrationBuilder.DropColumn(
                name: "DifficultyId1",
                table: "Walks");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "Walks");

            migrationBuilder.DropColumn(
                name: "RegionId1",
                table: "Walks");

            migrationBuilder.InsertData(
                table: "Difficulty",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "111", "Easy" },
                    { "222", "Medium" },
                    { "333", "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { "100", "Akl", "Auckland", "Akl.img" },
                    { "200", "Akl2", "Auckland2", "Akl2.img" },
                    { "300", "Akl3", "Auckland3", "Akl3.img" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulty",
                keyColumn: "Id",
                keyValue: "111");

            migrationBuilder.DeleteData(
                table: "Difficulty",
                keyColumn: "Id",
                keyValue: "222");

            migrationBuilder.DeleteData(
                table: "Difficulty",
                keyColumn: "Id",
                keyValue: "333");

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: "100");

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: "200");

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: "300");

            migrationBuilder.AddColumn<int>(
                name: "DifficultyId",
                table: "Walks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DifficultyId1",
                table: "Walks",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "Walks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RegionId1",
                table: "Walks",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Difficulty",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "11", "Easy" },
                    { "22", "Medium" },
                    { "33", "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { "10", "Akl", "Auckland", "Akl.img" },
                    { "20", "Akl2", "Auckland2", "Akl2.img" },
                    { "30", "Akl3", "Auckland3", "Akl3.img" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Walks_DifficultyId1",
                table: "Walks",
                column: "DifficultyId1");

            migrationBuilder.CreateIndex(
                name: "IX_Walks_RegionId1",
                table: "Walks",
                column: "RegionId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Walks_Difficulty_DifficultyId1",
                table: "Walks",
                column: "DifficultyId1",
                principalTable: "Difficulty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Walks_Regions_RegionId1",
                table: "Walks",
                column: "RegionId1",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
