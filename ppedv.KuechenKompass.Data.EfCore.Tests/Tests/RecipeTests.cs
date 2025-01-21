using ppedv.KuechenKompass.Data.EfCore.InitialData;
using ppedv.KuechenKompass.Data.EfCore.Tests.Infrastructure;
using ppedv.KuechenKompass.Model;

namespace ppedv.KuechenKompass.Data.EfCore.Tests.Tests
{
    [TestClass]
    public class RecipeTests
    {
        public KuechenKompassContext Context { get; private set; }

        [TestInitialize]
        public void Initialize()
        {
            Context = new TestDatabase().Context;
        }

        [TestCleanup]
        public void Cleanup()
        {
            // DB Connection beenden
            Context.Dispose();
        }

        [TestMethod, TestCategory("KuechenKompass")]
        public void Recipe_CountExistingRecipes_Returns5()
        {
            var recipeCount = Context.Recipes.Count();

            Assert.AreEqual(5, recipeCount);
        }

        #region CRUD Operationen testen

        [TestMethod, TestCategory("KuechenKompass")]
        public void Recipe_CreateNewRecipe_IncreasesCount()
        {
            var initialCount = Context.Recipes.Count();

            var newRecipe = new Recipe
            {
                Id = Guid.Parse("34445f26-a70e-4f42-b94c-0e9900034407"),
                CookingInstructions = "Instructions for New Recipe",
                KCal = 550,
                PreparationTime = 35,
                Price = 9.50m,
                Created = new DateTime(2023, 1, 1),
                Modified = new DateTime(2023, 1, 2)
            };

            Context.Recipes.Add(newRecipe);
            Context.SaveChanges();

            var newCount = Context.Recipes.Count();
            Assert.AreEqual(initialCount + 1, newCount);
        }

        [TestMethod, TestCategory("KuechenKompass")]
        public void Recipe_ReadExistingRecipe_ReturnsCorrectRecipe()
        {
            var recipe = Context.Recipes.Find(Seed.Recipe1Id);

            Assert.IsNotNull(recipe);
            Assert.AreEqual("Instructions for Recipe 1", recipe.CookingInstructions);
        }

        [TestMethod, TestCategory("KuechenKompass")]
        public void Recipe_UpdateExistingRecipe_ChangesAreSaved()
        {
            var recipe = Context.Recipes.Find(Seed.Recipe1Id);

            recipe.CookingInstructions = "Updated Instructions for Recipe 1";
            Context.SaveChanges();

            var updatedRecipe = Context.Recipes.Find(Seed.Recipe1Id);
            Assert.AreEqual("Updated Instructions for Recipe 1", updatedRecipe.CookingInstructions);
        }

        [TestMethod, TestCategory("KuechenKompass")]
        public void Recipe_DeleteExistingRecipe_DecreasesCount()
        {
            var initialCount = Context.Recipes.Count();
            var recipe = Context.Recipes.Find(Seed.Recipe1Id);

            Context.Recipes.Remove(recipe);
            Context.SaveChanges();

            var newCount = Context.Recipes.Count();
            Assert.AreEqual(initialCount - 1, newCount);
        }

        #endregion
    }
}
