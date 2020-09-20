using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BrewBuddyCore.Migrations
{
    public partial class TestBrews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brew",
                columns: table => new
                {
                    BrewID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Style = table.Column<string>(nullable: true),
                    Yield = table.Column<decimal>(nullable: false),
                    OriginalGravity = table.Column<decimal>(nullable: false),
                    FinalGravity = table.Column<decimal>(nullable: false),
                    ABV = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brew", x => x.BrewID);
                });

            migrationBuilder.CreateTable(
                name: "Ingredient",
                columns: table => new
                {
                    IngredientID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(nullable: false),
                    IngredientName = table.Column<string>(nullable: true),
                    BrewID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.IngredientID);
                    table.ForeignKey(
                        name: "FK_Ingredient_Brew_BrewID",
                        column: x => x.BrewID,
                        principalTable: "Brew",
                        principalColumn: "BrewID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    NoteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateLogged = table.Column<DateTime>(nullable: false),
                    NoteDescription = table.Column<string>(nullable: true),
                    BrewID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.NoteID);
                    table.ForeignKey(
                        name: "FK_Note_Brew_BrewID",
                        column: x => x.BrewID,
                        principalTable: "Brew",
                        principalColumn: "BrewID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Step",
                columns: table => new
                {
                    StepID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StepNote = table.Column<string>(nullable: true),
                    BrewID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Step", x => x.StepID);
                    table.ForeignKey(
                        name: "FK_Step_Brew_BrewID",
                        column: x => x.BrewID,
                        principalTable: "Brew",
                        principalColumn: "BrewID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_BrewID",
                table: "Ingredient",
                column: "BrewID");

            migrationBuilder.CreateIndex(
                name: "IX_Note_BrewID",
                table: "Note",
                column: "BrewID");

            migrationBuilder.CreateIndex(
                name: "IX_Step_BrewID",
                table: "Step",
                column: "BrewID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredient");

            migrationBuilder.DropTable(
                name: "Note");

            migrationBuilder.DropTable(
                name: "Step");

            migrationBuilder.DropTable(
                name: "Brew");
        }
    }
}
