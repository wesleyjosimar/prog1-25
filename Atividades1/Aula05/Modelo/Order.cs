namespace Modelo
{
    public class Order
    {
        public int Id { get; set; }
        public Customer? Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public string? ShippingAddress { get; set; }
        public List<OrderItem>? OrderItems { get; set; }

        public bool Validate()
        {
            return true;
        }

        public Order Retrive()
        {
            return new Order();
        }

        public void Save(Order order)
        {

        }
    }
}
