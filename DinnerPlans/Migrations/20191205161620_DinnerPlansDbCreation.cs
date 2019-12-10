using Microsoft.EntityFrameworkCore.Migrations;

namespace DinnerPlans.Migrations
{
    public partial class DinnerPlansDbCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NutritionData",
                columns: table => new
                {
                    NutritionDataId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Calories = table.Column<decimal>(nullable: false),
                    CarbsGr = table.Column<decimal>(nullable: false),
                    ProteinsGr = table.Column<decimal>(nullable: false),
                    SugarsGr = table.Column<decimal>(nullable: false),
                    FatsGr = table.Column<decimal>(nullable: false),
                    SaltsGr = table.Column<decimal>(nullable: false),
                    SatFatsGr = table.Column<decimal>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutritionData", x => x.NutritionDataId);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    IngredientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Unit = table.Column<int>(nullable: false),
                    NutritionDataId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.IngredientId);
                    table.ForeignKey(
                        name: "FK_Ingredients_NutritionData_NutritionDataId",
                        column: x => x.NutritionDataId,
                        principalTable: "NutritionData",
                        principalColumn: "NutritionDataId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    RecipeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Instruction = table.Column<string>(nullable: true),
                    NutritionDataId = table.Column<int>(nullable: true),
                    TotalWeight = table.Column<decimal>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.RecipeId);
                    table.ForeignKey(
                        name: "FK_Recipes_NutritionData_NutritionDataId",
                        column: x => x.NutritionDataId,
                        principalTable: "NutritionData",
                        principalColumn: "NutritionDataId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IngredientEntry",
                columns: table => new
                {
                    IngredientEntryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientId = table.Column<int>(nullable: true),
                    Quantity = table.Column<decimal>(nullable: false),
                    RecipeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientEntry", x => x.IngredientEntryId);
                    table.ForeignKey(
                        name: "FK_IngredientEntry_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IngredientEntry_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientEntry_IngredientId",
                table: "IngredientEntry",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientEntry_RecipeId",
                table: "IngredientEntry",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_NutritionDataId",
                table: "Ingredients",
                column: "NutritionDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_NutritionDataId",
                table: "Recipes",
                column: "NutritionDataId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientEntry");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "NutritionData");
        }
    }
}
