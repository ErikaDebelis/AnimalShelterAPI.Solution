using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalShelter.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Dogs",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "DogId",
                keyValue: 1,
                column: "Size",
                value: "Small");

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "DogId",
                keyValue: 2,
                column: "Size",
                value: "Medium");

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "DogId",
                keyValue: 3,
                column: "Size",
                value: "Small");

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "DogId",
                keyValue: 4,
                column: "Size",
                value: "Medium");

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "DogId",
                keyValue: 5,
                column: "Size",
                value: "Large");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Size",
                table: "Dogs");
        }
    }
}
