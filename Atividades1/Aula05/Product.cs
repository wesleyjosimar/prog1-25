﻿namespace Aula05
{
    class Product
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public float CurrentPrice { get; set; }

        public bool Validate()
        {
            return true;
        }

        public Product Retrive()
        {
            return new Product();
        }

        public void Save(Product product)
        {

        }
    }
}
