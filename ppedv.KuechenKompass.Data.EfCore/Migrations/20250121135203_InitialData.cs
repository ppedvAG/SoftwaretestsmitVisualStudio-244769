using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ppedv.KuechenKompass.Data.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CookingInstructions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KCal = table.Column<int>(type: "int", nullable: false),
                    PreparationTime = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    KCal = table.Column<int>(type: "int", nullable: false),
                    RecipeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredients_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecipeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredients",
                columns: table => new
                {
                    RecipeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IngredientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredients", x => new { x.RecipeId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Created", "Modified", "Name", "Number" },
                values: new object[,]
                {
                    { new Guid("c11c2a87-a47a-4d20-a518-7a66dee010d3"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alice Johnson", "12345" },
                    { new Guid("d22d3b98-b58b-4e31-b629-8b77eee121e4"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bob Smith", "67890" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Created", "KCal", "Modified", "Name", "RecipeId", "Type", "Weight" },
                values: new object[,]
                {
                    { new Guid("38839014-e040-4f42-f28f-403311168710"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tomato", null, 0, 100m },
                    { new Guid("4994a115-f151-4f42-0390-514411179821"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 77, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Apple", null, 1, 150m },
                    { new Guid("5aa5b116-0261-4f42-1401-615522280932"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 165, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chicken Breast", null, 2, 200m },
                    { new Guid("6bb6c117-1371-4f42-2512-716633391043"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 42, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Milk", null, 3, 250m },
                    { new Guid("7cc7d118-2482-4f42-3623-827744402154"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 195, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rice", null, 4, 180m },
                    { new Guid("8dd8e119-3593-4f42-4734-938855513265"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Salt", null, 5, 5m },
                    { new Guid("9ee9f120-46a4-4f42-5845-a49966624376"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Basil", null, 6, 10m },
                    { new Guid("a00a1221-5715-4f42-6956-15a077735487"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 120, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Olive Oil", null, 7, 15m },
                    { new Guid("b11b2222-6826-4f42-7a67-26b188846598"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 77, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sugar", null, 8, 20m },
                    { new Guid("c22c3223-7937-4f42-8b78-37c2999576a9"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 70, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Egg", null, 9, 50m }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "CookingInstructions", "Created", "KCal", "Modified", "PreparationTime", "Price" },
                values: new object[,]
                {
                    { new Guid("05506e11-b71e-4f42-c95c-1e0011135417"), "Instructions for Recipe 3", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 700, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 60, 15.00m },
                    { new Guid("16617f12-c82f-4f42-d06d-2f1122246518"), "Instructions for Recipe 4", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 800, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 75, 18.00m },
                    { new Guid("27728f13-d930-4f42-e17e-302233357629"), "Instructions for Recipe 5", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 900, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 90, 20.00m },
                    { new Guid("e33e4c09-f59c-4f42-a73a-9c88fff132f5"), "Instructions for Recipe 1", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 500, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, 10.00m },
                    { new Guid("f44f5d10-a60d-4f42-b84b-0d9900024306"), "Instructions for Recipe 2", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 600, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 45, 12.00m }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Created", "CustomerId", "Modified", "OrderDate", "RecipeId" },
                values: new object[,]
                {
                    { new Guid("05516027-b81f-4f42-c05d-1f0011145519"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d22d3b98-b58b-4e31-b629-8b77eee121e4"), new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("05506e11-b71e-4f42-c95c-1e0011135417") },
                    { new Guid("16627128-c920-4f42-d16e-2f112225661a"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d22d3b98-b58b-4e31-b629-8b77eee121e4"), new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("16617f12-c82f-4f42-d06d-2f1122246518") },
                    { new Guid("27738229-d031-4f42-e27f-31223336772b"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c11c2a87-a47a-4d20-a518-7a66dee010d3"), new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("27728f13-d930-4f42-e17e-302233357629") },
                    { new Guid("d33d4e25-f69d-4f42-a83b-9d88fff233f6"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c11c2a87-a47a-4d20-a518-7a66dee010d3"), new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e33e4c09-f59c-4f42-a73a-9c88fff132f5") },
                    { new Guid("e44e5f26-a70e-4f42-b94c-0e9900034407"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c11c2a87-a47a-4d20-a518-7a66dee010d3"), new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f44f5d10-a60d-4f42-b84b-0d9900024306") }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "IngredientId", "RecipeId" },
                values: new object[,]
                {
                    { new Guid("7cc7d118-2482-4f42-3623-827744402154"), new Guid("05506e11-b71e-4f42-c95c-1e0011135417") },
                    { new Guid("8dd8e119-3593-4f42-4734-938855513265"), new Guid("05506e11-b71e-4f42-c95c-1e0011135417") },
                    { new Guid("9ee9f120-46a4-4f42-5845-a49966624376"), new Guid("16617f12-c82f-4f42-d06d-2f1122246518") },
                    { new Guid("a00a1221-5715-4f42-6956-15a077735487"), new Guid("16617f12-c82f-4f42-d06d-2f1122246518") },
                    { new Guid("b11b2222-6826-4f42-7a67-26b188846598"), new Guid("27728f13-d930-4f42-e17e-302233357629") },
                    { new Guid("c22c3223-7937-4f42-8b78-37c2999576a9"), new Guid("27728f13-d930-4f42-e17e-302233357629") },
                    { new Guid("38839014-e040-4f42-f28f-403311168710"), new Guid("e33e4c09-f59c-4f42-a73a-9c88fff132f5") },
                    { new Guid("4994a115-f151-4f42-0390-514411179821"), new Guid("e33e4c09-f59c-4f42-a73a-9c88fff132f5") },
                    { new Guid("5aa5b116-0261-4f42-1401-615522280932"), new Guid("f44f5d10-a60d-4f42-b84b-0d9900024306") },
                    { new Guid("6bb6c117-1371-4f42-2512-716633391043"), new Guid("f44f5d10-a60d-4f42-b84b-0d9900024306") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_RecipeId",
                table: "Ingredients",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_RecipeId",
                table: "Orders",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_IngredientId",
                table: "RecipeIngredients",
                column: "IngredientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "RecipeIngredients");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Recipes");
        }
    }
}
