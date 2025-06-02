﻿using Modelo;
namespace Repository
{
    class CustomerData
    {
        public static List<Customer> Customers { get; set; } = [];
        public static List<Product> Products { get; set; } = [];
        public static List<Order> Orders { get; set; } = [];
    }
}
