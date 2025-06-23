using Aula05;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Modelo;
using Repository;

namespace Aula05Projeto.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IWebHostEnvironment environment;

        private CustomerRepository _customerRepository;

        public CustomerController(
            IWebHostEnvironment environment
        )
        {
            _customerRepository = new CustomerRepository();
            this.environment = environment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Customer> customers =
                _customerRepository.RetrieveAll();
            return View(customers);
        }

        [HttpPost]
        public IActionResult Create(Customer c)
        {
            _customerRepository.Save(c);

            List<Customer> customers = _customerRepository.RetrieveAll();

            return View("Index", customers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ExportDelimitatedFile()
        {
            string fileContent = string.Empty;
            foreach (Customer c in CustomerData.Customers)
            {
                fileContent += @$"{c.Id};
                                    {c.Name};
                                    {c.HomeAddres!.Id};
                                    {c.HomeAddres.City};
                                    {c.HomeAddres.State};
                                    {c.HomeAddres.Country};
                                    {c.HomeAddres.Street1};
                                    {c.HomeAddres.Street2};
                                    {c.HomeAddres.PostalCode};
                                    {c.HomeAddres.AddressType}
                                    \n
                                ";
            }

            SaveFile(fileContent, "DelimitatedFileContent.txt");

            return View();
        }

        [HttpGet]
        public IActionResult ExportFixedFile()
        {
            string fileContent = string.Empty;
            foreach (Customer c in CustomerData.Customers)
            {
                fileContent +=
                    String.Format("{0:5}", c.Id) +
                    String.Format("{0:64}", c.Name) +
                    String.Format("{0:5}", c.HomeAddres!.Id) +
                    String.Format("{0:32}", c.HomeAddres!.City) +
                    String.Format("{0:2}", c.HomeAddres!.State) +
                    String.Format("{0:32}", c.HomeAddres!.Country) +
                    String.Format("{0:64}", c.HomeAddres!.Street1) +
                    String.Format("{0:64}", c.HomeAddres!.Street2) +
                    String.Format("{0:9}", c.HomeAddres!.PostalCode) +
                    String.Format("{0:16}", c.HomeAddres!.AddressType) +
                    "\n";
            }

            SaveFile(fileContent, "FixedFileCustomer.txt");

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null || id.Value <= 0)
                return NotFound();

            Customer customer = _customerRepository.Retrieve(id.Value);

            if (customer == null)
                return NotFound();

            return View(customer);
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int? id)
        {
            if (id is null || id <= 0)
                return NotFound();

            if (
                !_customerRepository.DeleteById(id.Value)
            )
                return NotFound();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id is null || id.Value <= 0)
                return NotFound();

            Customer customer = _customerRepository.Retrieve(id.Value);

            if (customer == null)
                return NotFound();

            return View(customer);
        }

        [HttpPost]
        public IActionResult PostUpdate(Customer c)
        {
            _customerRepository.Update(c);

            List<Customer> customers = _customerRepository.RetrieveAll();

            return View("Index", customers);
        }

        private bool SaveFile(string content, string fileName)
        {
            bool ret = true;

            if (string.IsNullOrEmpty(content) || string.IsNullOrEmpty(fileName))
                return false;

            var path = Path.Combine(
                environment.WebRootPath,
                "TextFiles"
            );

            try
            {
                if (!System.IO.Directory.Exists(path))
                    System.IO.Directory.CreateDirectory(path);

                var filepath = Path.Combine(
                    path,
                    fileName
                );

                using (StreamWriter sw = System.IO.File.CreateText(filepath))
                {
                    sw.Write(content);
                }
            }
            catch (IOException ioEx)
            {
                string msg = ioEx.Message;
                ret = false;
                //throw ioEx;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = false;
            }
            

            return ret;
        }
    }
}
