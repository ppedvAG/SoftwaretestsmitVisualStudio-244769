namespace ppedv.KuechenKompass.Model
{
    public class Order : Entity
        {
            public DateTime OrderDate { get; set; }
            public Customer Customer { get; set; }
            public Recipe Recipe { get; set; }
        }
}
