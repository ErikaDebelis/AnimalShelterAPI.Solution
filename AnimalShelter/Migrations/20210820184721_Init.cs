using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalShelter.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cats",
                columns: table => new
                {
                    CatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cats", x => x.CatId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Dogs",
                columns: table => new
                {
                    DogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogs", x => x.DogId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SmallAnimals",
                columns: table => new
                {
                    SmallAnimalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmallAnimals", x => x.SmallAnimalId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "CatId", "Age", "Description", "Gender", "Name" },
                values: new object[,]
                {
                    { 1, 8, "Soft, Long-hair, Lynx-point Neva Masquerade Siberian cat. Beauty, grace, and silly all at once. Was absolutely royalty in a past life.", "Female", "Kimmy" },
                    { 2, 2, "Silly chonker. Very food motivated but a lovely companion and sweet natured. Is the yang to Betty's Yin- brother and sister- must adopt together.", "Male", "Max" },
                    { 3, 2, "Sweet lil angel. Can be anxious around crowds or new people but is so sweet and demure when comfy. LOVES worm toy. Is the yin to Max's Yang- brother and sisters- must adopt together.", "Female", "Betty" },
                    { 4, 1, "Silly cute goof. Loves to cuddle and play. Little sweet ragdoll.", "Male", "Spike" },
                    { 5, 1, "Big fluff and like bird toys. will eat any food in sight but is so sweet and lovey you won't even mind. Will be a chonker one day.", "Male", "Angel" }
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "DogId", "Age", "Description", "Gender", "Name" },
                values: new object[,]
                {
                    { 1, 8, "Lovely sweet baby- loves pets and licking the carpet lol.", "Female", "Cupcake" },
                    { 2, 10, "Gentle pup with a lot of heart. Mr. loves Cupcake adn belly rubs.", "Male", "Muffin" },
                    { 3, 2, "Cookie is gentle and polite. Loves to love.", "Female", "Cookie" },
                    { 4, 12, "The sweetest lil shih Tzu you'll ever meet. gets so excited to see you she pees a little but you don't mind cause its so sweet.", "Female", "Emma" },
                    { 5, 7, "Flamboyant lil boy with a tendency for drama. Very excitable fun pup.", "Male", "Frankenfurter" }
                });

            migrationBuilder.InsertData(
                table: "SmallAnimals",
                columns: new[] { "SmallAnimalId", "Age", "Description", "Gender", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Guinea Pig. Lovely sweet boy to humans- but doesnt play well with other hams. Loves to burrow.", "Male", "Bacon" },
                    { 2, 3, "Bunny. loves play time and is very excitable.", "Female", "Cardi Bun" },
                    { 3, 1, "Hamster. Loves to sleep and eat. a Lazy silly boy but is full of so much love.", "Male", "Hammond" },
                    { 4, 4, "Chinchilla. Loves having lots of room to play and explore in! This baby is super fun and so so SOFT. ", "Female", "Sage" },
                    { 5, 1, "Rat. Intelligent social boy with a sense of adventure.", "Male", "Goddric" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cats");

            migrationBuilder.DropTable(
                name: "Dogs");

            migrationBuilder.DropTable(
                name: "SmallAnimals");
        }
    }
}
