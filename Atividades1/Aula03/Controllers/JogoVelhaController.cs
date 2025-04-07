using Microsoft.AspNetCore.Mvc;

namespace Aula03.Controllers
{
    public class JogoVelhaController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(
            string A00, string A01, string A02,
            string A10, string A11, string A12,
            string A20, string A21, string A22
        )
        {
            string[,] matrixJV = new string[3, 3];
            matrixJV[0, 0] = A00;
            matrixJV[0, 1] = A01;
            matrixJV[0, 2] = A02;

            matrixJV[1, 0] = A10;
            matrixJV[1, 1] = A11;
            matrixJV[1, 2] = A12;

            matrixJV[2, 0] = A20;
            matrixJV[2, 1] = A21;
            matrixJV[2, 2] = A22;

            string retorno = String.Empty;
            int xO = 0;
            int yO = 0;
            int xX = 0;
            int yX = 0;
            int xDiag = 0;
            int oDiag = 0;
            int xDiag2 = 0;
            int oDiag2 = 0;
            for (int i = 0; i < 3; i++)
            {
                xO = 0;
                xX = 0;
                yO = 0;
                yX = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (i == j)
                    {
                        if (matrixJV[i, j] == "X")
                        {
                            xDiag++;
                        }
                        else
                        {
                            oDiag++;
                        }
                    }

                    if ((j + i) == 2)
                    {
                        if (matrixJV[i, j] == "X")
                        {
                            xDiag2++;
                        }
                        else
                        {
                            oDiag2++;
                        }
                    }

                    if (matrixJV[i, j] == "X")
                    {
                        xX++;
                    }
                    else
                    {
                        xO++;
                    }
                    if (xX == 3)
                    {
                        retorno = "X é campeão";
                        break;
                    }
                    else if (xO == 3)
                    {
                        retorno = "O é campeão";
                        break;
                    }

                    if (matrixJV[j, i] == "X")
                    {
                        yX++;
                    }
                    else
                    {
                        yO++;
                    }

                    if (yX == 3)
                    {
                        retorno = "X é campeão";
                        break;
                    }
                    else if (yO == 3)
                    {
                        retorno = "O é campeão";
                        break;
                    }
                }
                if (retorno != string.Empty)
                    break;
            }
            if (xDiag == 3)
            {
                retorno = "X é campeão";
            }
            else if (oDiag == 3)
            {
                retorno = "O é campeão";
            }
            else if (xDiag2 == 3)
            {
                retorno = "X é campeão";
            }
            else if (oDiag2 == 3)
            {
                retorno = "O é campeão";
            }
            else if ((retorno == string.Empty))
            {
                retorno = "Empate";
            }

            return View("index", retorno);
        }
    }
}