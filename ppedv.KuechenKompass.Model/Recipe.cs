namespace ppedv.KuechenKompass.Model
{
    public class Recipe : Entity
        {
            public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
            public string CookingInstructions { get; set; }
            public int KCal { get; set; }
            public int PreparationTime { get; set; } // in minutes
            public decimal Price { get; set; }
        }
}
