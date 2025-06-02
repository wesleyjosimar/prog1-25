using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula05
{
    class OrderItem
    {
        public int Id { get; set; }
        public Product? Product { get; set; }
        public double Quantity { get; set; }
        public double PurchasePrice { get; set; }

        public bool Validate()
        {
            return true;
        }

        public OrderItem Retrive()
        {
            return new OrderItem();
        }

        public void Save(OrderItem orderItem)
        {

        }
    }
}
