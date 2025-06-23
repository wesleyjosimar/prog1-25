﻿using Modelo;

namespace Aula05Projeto.ViewModels
{
    public class OrderViewModel
    {
        public List<Customer> Customers { get; set; } = [];
        public int? CustomerId { get; set; }
        public List<SelectedItem>? SelectedItems { get; set; }
    }

    public class SelectedItem
    {
        public bool? IsSelected { get; set; } = false;
        public OrderItem OrderItem { get; set; } = null!;
    }
}
