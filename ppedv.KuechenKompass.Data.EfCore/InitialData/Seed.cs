using Microsoft.EntityFrameworkCore;
using ppedv.KuechenKompass.Model;

namespace ppedv.KuechenKompass.Data.EfCore.InitialData
{
    public class Seed
    {
        public static readonly Guid Recipe1Id = Guid.Parse("e33e4c09-f59c-4f42-a73a-9c88fff132f5");

        internal readonly static Seed Instance = new Seed();

        private Seed()
        {

        }

        public void SeedData(ModelBuilder modelBuilder)
        {
            var customer1Id = Guid.Parse("c11c2a87-a47a-4d20-a518-7a66dee010d3");
            var customer2Id = Guid.Parse("d22d3b98-b58b-4e31-b629-8b77eee121e4");

            var recipe2Id = Guid.Parse("f44f5d10-a60d-4f42-b84b-0d9900024306");
            var recipe3Id = Guid.Parse("05506e11-b71e-4f42-c95c-1e0011135417");
            var recipe4Id = Guid.Parse("16617f12-c82f-4f42-d06d-2f1122246518");
            var recipe5Id = Guid.Parse("27728f13-d930-4f42-e17e-302233357629");

            var ingredient1Id = Guid.Parse("38839014-e040-4f42-f28f-403311168710");
            var ingredient2Id = Guid.Parse("4994a115-f151-4f42-0390-514411179821");
            var ingredient3Id = Guid.Parse("5aa5b116-0261-4f42-1401-615522280932");
            var ingredient4Id = Guid.Parse("6bb6c117-1371-4f42-2512-716633391043");
            var ingredient5Id = Guid.Parse("7cc7d118-2482-4f42-3623-827744402154");
            var ingredient6Id = Guid.Parse("8dd8e119-3593-4f42-4734-938855513265");
            var ingredient7Id = Guid.Parse("9ee9f120-46a4-4f42-5845-a49966624376");
            var ingredient8Id = Guid.Parse("a00a1221-5715-4f42-6956-15a077735487");
            var ingredient9Id = Guid.Parse("b11b2222-6826-4f42-7a67-26b188846598");
            var ingredient10Id = Guid.Parse("c22c3223-7937-4f42-8b78-37c2999576a9");

            var order1Id = Guid.Parse("d33d4e25-f69d-4f42-a83b-9d88fff233f6");
            var order2Id = Guid.Parse("e44e5f26-a70e-4f42-b94c-0e9900034407");
            var order3Id = Guid.Parse("05516027-b81f-4f42-c05d-1f0011145519");
            var order4Id = Guid.Parse("16627128-c920-4f42-d16e-2f112225661a");
            var order5Id = Guid.Parse("27738229-d031-4f42-e27f-31223336772b");

            var createdDate = new DateTime(2023, 1, 1);
            var modifiedDate = new DateTime(2023, 1, 2);

            var customer1 = new Customer { Id = customer1Id, Name = "Alice Johnson", Number = "12345", Created = createdDate, Modified = modifiedDate };
            var customer2 = new Customer { Id = customer2Id, Name = "Bob Smith", Number = "67890", Created = createdDate, Modified = modifiedDate };

            var recipe1 = new Recipe { Id = Recipe1Id, CookingInstructions = "Instructions for Recipe 1", KCal = 500, PreparationTime = 30, Price = 10.00m, Created = createdDate, Modified = modifiedDate };
            var recipe2 = new Recipe { Id = recipe2Id, CookingInstructions = "Instructions for Recipe 2", KCal = 600, PreparationTime = 45, Price = 12.00m, Created = createdDate, Modified = modifiedDate };
            var recipe3 = new Recipe { Id = recipe3Id, CookingInstructions = "Instructions for Recipe 3", KCal = 700, PreparationTime = 60, Price = 15.00m, Created = createdDate, Modified = modifiedDate };
            var recipe4 = new Recipe { Id = recipe4Id, CookingInstructions = "Instructions for Recipe 4", KCal = 800, PreparationTime = 75, Price = 18.00m, Created = createdDate, Modified = modifiedDate };
            var recipe5 = new Recipe { Id = recipe5Id, CookingInstructions = "Instructions for Recipe 5", KCal = 900, PreparationTime = 90, Price = 20.00m, Created = createdDate, Modified = modifiedDate };

            var ingredient1 = new Ingredient { Id = ingredient1Id, Name = "Tomato", Weight = 100, Type = IngredientType.Vegetable, KCal = 18, Created = createdDate, Modified = modifiedDate };
            var ingredient2 = new Ingredient { Id = ingredient2Id, Name = "Apple", Weight = 150, Type = IngredientType.Fruit, KCal = 77, Created = createdDate, Modified = modifiedDate };
            var ingredient3 = new Ingredient { Id = ingredient3Id, Name = "Chicken Breast", Weight = 200, Type = IngredientType.Meat, KCal = 165, Created = createdDate, Modified = modifiedDate };
            var ingredient4 = new Ingredient { Id = ingredient4Id, Name = "Milk", Weight = 250, Type = IngredientType.Dairy, KCal = 42, Created = createdDate, Modified = modifiedDate };
            var ingredient5 = new Ingredient { Id = ingredient5Id, Name = "Rice", Weight = 180, Type = IngredientType.Grain, KCal = 195, Created = createdDate, Modified = modifiedDate };
            var ingredient6 = new Ingredient { Id = ingredient6Id, Name = "Salt", Weight = 5, Type = IngredientType.Spice, KCal = 0, Created = createdDate, Modified = modifiedDate };
            var ingredient7 = new Ingredient { Id = ingredient7Id, Name = "Basil", Weight = 10, Type = IngredientType.Herb, KCal = 2, Created = createdDate, Modified = modifiedDate };
            var ingredient8 = new Ingredient { Id = ingredient8Id, Name = "Olive Oil", Weight = 15, Type = IngredientType.Oil, KCal = 120, Created = createdDate, Modified = modifiedDate };
            var ingredient9 = new Ingredient { Id = ingredient9Id, Name = "Sugar", Weight = 20, Type = IngredientType.Sweetener, KCal = 77, Created = createdDate, Modified = modifiedDate };
            var ingredient10 = new Ingredient { Id = ingredient10Id, Name = "Egg", Weight = 50, Type = IngredientType.Other, KCal = 70, Created = createdDate, Modified = modifiedDate };

            var order1 = new Order { Id = order1Id, OrderDate = createdDate, CustomerId = customer1Id, RecipeId = Recipe1Id, Created = createdDate, Modified = modifiedDate };
            var order2 = new Order { Id = order2Id, OrderDate = createdDate, CustomerId = customer1Id, RecipeId = recipe2Id, Created = createdDate, Modified = modifiedDate };
            var order3 = new Order { Id = order3Id, OrderDate = createdDate, CustomerId = customer2Id, RecipeId = recipe3Id, Created = createdDate, Modified = modifiedDate };
            var order4 = new Order { Id = order4Id, OrderDate = createdDate, CustomerId = customer2Id, RecipeId = recipe4Id, Created = createdDate, Modified = modifiedDate };
            var order5 = new Order { Id = order5Id, OrderDate = createdDate, CustomerId = customer1Id, RecipeId = recipe5Id, Created = createdDate, Modified = modifiedDate };

            modelBuilder.Entity<Customer>().HasData(customer1, customer2);
            modelBuilder.Entity<Order>().HasData(order1, order2, order3, order4, order5);
            modelBuilder.Entity<Recipe>().HasData(recipe1, recipe2, recipe3, recipe4, recipe5);
            modelBuilder.Entity<Ingredient>().HasData(ingredient1, ingredient2, ingredient3, ingredient4, ingredient5, ingredient6, ingredient7, ingredient8, ingredient9, ingredient10);

            // Adding ingredients to recipes
            modelBuilder.Entity<RecipeIngredient>().HasData(
                new RecipeIngredient { RecipeId = Recipe1Id, IngredientId = ingredient1Id },
                new RecipeIngredient { RecipeId = Recipe1Id, IngredientId = ingredient2Id },
                new RecipeIngredient { RecipeId = recipe2Id, IngredientId = ingredient3Id },
                new RecipeIngredient { RecipeId = recipe2Id, IngredientId = ingredient4Id },
                new RecipeIngredient { RecipeId = recipe3Id, IngredientId = ingredient5Id },
                new RecipeIngredient { RecipeId = recipe3Id, IngredientId = ingredient6Id },
                new RecipeIngredient { RecipeId = recipe4Id, IngredientId = ingredient7Id },
                new RecipeIngredient { RecipeId = recipe4Id, IngredientId = ingredient8Id },
                new RecipeIngredient { RecipeId = recipe5Id, IngredientId = ingredient9Id },
                new RecipeIngredient { RecipeId = recipe5Id, IngredientId = ingredient10Id }
            );
        }
    }
}
