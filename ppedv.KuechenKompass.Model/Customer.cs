namespace ppedv.KuechenKompass.Model
{
    public class Customer : Entity
        {
            public string Name { get; set; }
            public string Number { get; set; }
            public List<Order> Orders { get; set; } = new List<Order>();
        }
}
