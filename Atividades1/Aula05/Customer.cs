namespace Aula05
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? HomeAddres { get; set; }
        public string? WordAddres { get; set; }

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
