using Microsoft.EntityFrameworkCore;

namespace ppedv.KuechenKompass.Data.EfCore.Tests.Infrastructure
{
    internal class TestDatabase
    {
        public const string ConnectionString = "Server=(localdb)\\swtests;Database=KuechenKompassTest;Trusted_Connection=True;MultipleActiveResultSets=true";

        private static readonly object _lock = new object();
        private static bool _dbCreated = false;

        private KuechenKompassContext _dbContext;

        public KuechenKompassContext Context => _dbContext ??= CreateContext();

        private KuechenKompassContext CreateContext()
        {
            var dbContext = new KuechenKompassContext(ConnectionString);
            return dbContext;
        }

        public TestDatabase()
        {
            lock (_lock)
            {
                if (!_dbCreated)
                {
                    using var dbContext = CreateContext();

                    dbContext.Database.EnsureDeleted();

                    // Datenbank erzeugen
                    //dbContext.Database.EnsureCreated();

                    // Datenbank erzeugen und Daten migrieren
                    dbContext.Database.Migrate();

                    _dbCreated = true;
                }
            }
        }
    }
}
