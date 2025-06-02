namespace Modelo
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Address? HomeAddres { get; set; }
        public Address? WordAddres { get; set; }

        public static int InstantCount = 0;
        public int ObjectCount = 0;

        public bool Validate()
        {
            return true;
        }

        public Customer Retrive()
        {
            return new Customer();
        }

        public void Save(Customer customer)
        {

        }
    }
}