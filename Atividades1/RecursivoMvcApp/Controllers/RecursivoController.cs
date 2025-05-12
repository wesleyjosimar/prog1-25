using Microsoft.AspNetCore.Mvc;

namespace RecursivoMvcApp.Controllers
{
    public class RecursivoController : Controller
    {
        // ---------- 1. IMPRIMIR ----------
        [HttpGet]
        public IActionResult Imprimir()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Imprimir(int n)
        {
            var resultado = ImprimirDecrescente(n);
            ViewBag.Resultado = resultado;
            return View();
        }

        private string ImprimirDecrescente(int n)
        {
            if (n < 1) return "";
            return n + " " + ImprimirDecrescente(n - 1);
        }

        // ---------- 2. SOMAR (IMPRIMIR DE 1 A N) ----------
        [HttpGet]
        public IActionResult Somar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Somar(int n)
        {
            string resultado = ImprimirCrescente(1, n);
            ViewBag.Resultado = resultado;
            return View();
        }

        private string ImprimirCrescente(int atual, int max)
        {
            if (atual > max) return "";
            return atual + " " + ImprimirCrescente(atual + 1, max);
        }

        // ---------- 3. CONTAR CARACTERES ----------
        [HttpGet]
        public IActionResult ContarCaracteres()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ContarCaracteres(string texto)
        {
            int resultado = Contar(texto);
            ViewBag.Resultado = resultado;
            return View();
        }

        private int Contar(string texto)
        {
            if (string.IsNullOrEmpty(texto)) return 0;
            return 1 + Contar(texto.Substring(1));
        }

        // ---------- 4. VERIFICAR PALÍNDROMO ----------
        [HttpGet]
        public IActionResult Palindromo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Palindromo(string palavra)
        {
            bool resultado = EhPalindromo(palavra.ToUpper());
            ViewBag.Resultado = resultado;
            ViewBag.Palavra = palavra;
            return View();
        }

        private bool EhPalindromo(string texto)
        {
            if (texto.Length <= 1) return true;
            if (texto[0] != texto[^1]) return false;
            return EhPalindromo(texto.Substring(1, texto.Length - 2));
        }
    }
}
