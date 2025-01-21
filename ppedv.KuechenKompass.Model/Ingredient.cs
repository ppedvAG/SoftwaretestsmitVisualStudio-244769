namespace ppedv.KuechenKompass.Model
{
    public class Ingredient : Entity
        {
            public string Name { get; set; }
            public decimal Weight { get; set; } // in grams
            public IngredientType Type { get; set; }
            public int KCal { get; set; }
        }
}
