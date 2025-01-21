using Microsoft.EntityFrameworkCore;
using ppedv.KuechenKompass.Data.EfCore.InitialData;
using ppedv.KuechenKompass.Model;

namespace ppedv.KuechenKompass.Data.EfCore
{
    public class KuechenKompassContext : DbContext
    {
        private string connectionString;

        // Dieser Konstruktor wird von aussen mit ConnectionString aufgerufen
        public KuechenKompassContext(DbContextOptions options)
            : base(options)
        {
        }

        public KuechenKompassContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

#if DEBUG
        public KuechenKompassContext() 
            : this("Server=(localdb)\\swtests;Database=KuechenKompass;Trusted_Connection=True;MultipleActiveResultSets=true")
        {
        }
#endif

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if DEBUG
            // Zur Fehlersuche praktische Option für Debugging
            optionsBuilder.EnableSensitiveDataLogging();
#endif

            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Seed.Instance.SeedData(modelBuilder);

            modelBuilder.Entity<RecipeIngredient>()
                .HasKey(ri => new { ri.RecipeId, ri.IngredientId });

            modelBuilder.Entity<RecipeIngredient>()
                .HasOne(ri => ri.Recipe)
                .WithMany(r => r.RecipeIngredients)
                .HasForeignKey(ri => ri.RecipeId);

            modelBuilder.Entity<RecipeIngredient>()
                .HasOne(ri => ri.Ingredient)
                .WithMany(i => i.RecipeIngredients)
                .HasForeignKey(ri => ri.IngredientId);
        }

    }
}
