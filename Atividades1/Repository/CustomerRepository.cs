using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Repository
{
    public class CustomerRepository
    {
        public Customer Retrive(int id)
        {
            foreach (Customer c in CustomerData.Customers)
                if (c.Id == id)
                    return c;
            return null!;
        }

        public List<Customer> RetriveByName(string name)
        {
            List<Customer> ret = new List<Customer>();

            foreach (Customer c in CustomerData.Customers)
                if (c.Name!.ToLower().Contains(name.ToLower()))
                    ret.Add(c);

            return ret;
        }

        public List<Customer> RetriveAll()
        {
            return CustomerData.Customers;
        }

        public void Update(Customer newCustomer)
        {
            Customer oldCustomer = Retrive(newCustomer.Id);
            oldCustomer.Name = newCustomer.Name;
            oldCustomer.WordAddres = newCustomer.WordAddres;
            oldCustomer.HomeAddres = newCustomer.HomeAddres;
        }

        public void Save(Customer customer)
        {
            customer.Id = GetCount() + 1;
            CustomerData.Customers.Add(customer);
        }

        public bool Delete(Customer customer)
        {
            return CustomerData.Customers.Remove(customer);
        }

        public bool DeleteById(int id)
        {
            Customer customer = Retrive(id);

            if (customer != null)
                return Delete(customer);

            return false;
        }

        public int GetCount()
        {
            return CustomerData.Customers.Count;
        }
    }
}
