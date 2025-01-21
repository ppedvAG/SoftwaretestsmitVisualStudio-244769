using ppedv.KuechenKompass.Data.EfCore.Tests.Infrastructure;

namespace ppedv.KuechenKompass.Data.EfCore.Tests.Tests
{
    [TestClass]
    public sealed class KuechenKompassDbTests
    {

        [TestMethod, TestCategory("KuechenKompass")]
        public void EnureCreated_CreatesDatabase()
        {
            using (var context = new KuechenKompassContext(TestDatabase.ConnectionString))
            {
                context.Database.EnsureDeleted();

                var success = context.Database.EnsureCreated();

                Assert.IsTrue(success, "Database konnte nicht erstellt werden");

                // Am Ende des using Blocks wird IDisposable aufgerufen und die Datenbankverbindung geschlossen
            }
        }
    }
}
