using Aula05Projeto.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Modelo;
using Repository;

namespace Aula05Projeto.Controllers
{
    public class OrderController : Controller
    {
        private readonly IWebHostEnvironment environment;
        private readonly OrderRepository _orderRepository;
        private readonly CustomerRepository _customerRepository;
        private readonly ProductRepository _productRepository;

        public OrderController(IWebHostEnvironment environment)
        {
            this.environment = environment;
            _orderRepository = new OrderRepository();
            _customerRepository = new CustomerRepository();
            _productRepository = new ProductRepository();
        }

        public IActionResult Index()
        {
            return View(_orderRepository.RetrieveAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            OrderViewModel viewModel = new();
            viewModel.Customers = _customerRepository.RetrieveAll();

            var products = _productRepository.RetrieveAll();
            List<SelectedItem> items = [];
            foreach (var product in products)
            {
                items.Add(new SelectedItem()
                {
                    OrderItem = new()
                    {
                        Product = product
                    }
                });
            }
            viewModel.SelectedItems = items;

            return View(viewModel);
        }
        /*
        [HttpPost]
        public IActionResult Create(OrderViewModel viewModel)
        {
            _orderRepository.Save(viewModel);


            return View("Index");
        }
        */
    }
}
