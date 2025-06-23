using Microsoft.AspNetCore.Mvc;
using Modelo;
using Repository;
using System.Text;

namespace Aula05Projeto.Controllers
{
    public class ProductController : Controller
    {
        private readonly IWebHostEnvironment environment;

        private ProductRepository _productRepository;

        public ProductController(IWebHostEnvironment environment)
        {
            _productRepository = new ProductRepository();
            this.environment = environment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Product> product =
                _productRepository.RetrieveAll();
            return View(product);
        }

        [HttpPost]
        public IActionResult Create(Product p)
        {
            _productRepository.Save(p);

            List<Product> products = _productRepository.RetrieveAll();

            return View("Index", products);
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

            foreach (Product p in CustomerData.Products)
            {
                fileContent += @$"{p.Id};
                                    {p.ProductName};
                                    {p.Description};
                                    R$ {p.CurrentPrice}
                                ";
            }

            SaveFile(fileContent, "DelimitatedFileProduct.txt");

            return View();
        }

        public IActionResult ExportFixedFile()
        {
            string fileContent = string.Empty;
            foreach (Product p in CustomerData.Products)
            {
                fileContent +=
                    String.Format("{0:5}", p.Id) +
                    String.Format("{0:32}", p.ProductName) +
                    String.Format("{0:128}", p.Description) +
                    String.Format("{0:10}", p.CurrentPrice) +
                    "\n";
            }

            SaveFile(fileContent, "FixedFileProduct.txt");

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null || id.Value <= 0)
                return NotFound();

            Product product = _productRepository.Retrieve(id.Value);

            if (product == null)
                return NotFound();

            return View(product);
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int? id)
        {
            if (id is null || id <= 0)
                return NotFound();

            if (
                !_productRepository.DeleteById(id.Value)
            )
                return NotFound();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id is null || id.Value <= 0)
                return NotFound();

            Product product = _productRepository.Retrieve(id.Value);

            if (product == null)
                return NotFound();

            return View(product);
        }

        [HttpPost]
        public IActionResult PostUpdate(Product p)
        {
            _productRepository.Update(p);

            List<Product> product = _productRepository.RetrieveAll();

            return View("Index", product);
        }

        [HttpGet]
        public IActionResult Import()
        {
            return View();
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

        [HttpPost]
        public async Task<IActionResult> ImportDelimitedFile(IFormFile file)
        {
            if (file == null)
            {
                return NotFound();
            }

            try
            {
                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);
                    stream.Seek(0, SeekOrigin.Begin);

                    int lineCount = 0;
                    using (var reader = new StreamReader(stream))
                    {
                        string line;
                        while ((line = await reader.ReadLineAsync()) != null) // Usar ReadLineAsync para async
                        {
                            lineCount++;
                        }
                    }

                    for (int i = 0; i < lineCount; i++)
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao ler o arquivo: {ex.Message}");
            }

            List<Product> products = _productRepository.RetrieveAll();

            return View("Index", products);
        }
    }
}
