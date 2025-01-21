namespace ppedv.KuechenKompass.Model
{

    public static class ExampleData
    {
        public static List<Ingredient> GetExampleIngredients()
        {
            return new List<Ingredient>
            {
                new Ingredient { Name = "Tomato", Weight = 100, Type = IngredientType.Vegetable, KCal = 18 },
                new Ingredient { Name = "Apple", Weight = 150, Type = IngredientType.Fruit, KCal = 77 },
                new Ingredient { Name = "Chicken Breast", Weight = 200, Type = IngredientType.Meat, KCal = 165 },
                new Ingredient { Name = "Milk", Weight = 250, Type = IngredientType.Dairy, KCal = 42 },
                new Ingredient { Name = "Rice", Weight = 180, Type = IngredientType.Grain, KCal = 195 },
                new Ingredient { Name = "Salt", Weight = 5, Type = IngredientType.Spice, KCal = 0 },
                new Ingredient { Name = "Basil", Weight = 10, Type = IngredientType.Herb, KCal = 2 },
                new Ingredient { Name = "Olive Oil", Weight = 15, Type = IngredientType.Oil, KCal = 120 },
                new Ingredient { Name = "Sugar", Weight = 20, Type = IngredientType.Sweetener, KCal = 77 },
                new Ingredient { Name = "Egg", Weight = 50, Type = IngredientType.Other, KCal = 70 }
            };
        }
    }
}
