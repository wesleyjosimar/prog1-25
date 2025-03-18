using System;
using System.Globalization;

namespace numtowords.Models
{
    public static class NumberConverter
    {
        public static string NumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            return new CultureInfo("pt-BR").TextInfo.ToTitleCase(NumberToText(number));
        }

        private static string NumberToText(int number)
        {
            if (number < 0)
                return "menos " + NumberToText(Math.Abs(number));

            string[] unidades = { "", "um", "dois", "três", "quatro", "cinco", "seis", "sete", "oito", "nove" };
            string[] dezenas = { "", "dez", "vinte", "trinta", "quarenta", "cinquenta", "sessenta", "setenta", "oitenta", "noventa" };
            string[] especiais = { "dez", "onze", "doze", "treze", "quatorze", "quinze", "dezesseis", "dezessete", "dezoito", "dezenove" };
            string[] centenas = { "", "cem", "duzentos", "trezentos", "quatrocentos", "quinhentos", "seiscentos", "setecentos", "oitocentos", "novecentos" };

            if (number < 10)
                return unidades[number];
            if (number < 20)
                return especiais[number - 10];
            if (number < 100)
                return dezenas[number / 10] + (number % 10 != 0 ? " e " + unidades[number % 10] : "");
            if (number < 1000)
                return centenas[number / 100] + (number % 100 != 0 ? " e " + NumberToText(number % 100) : "");
            if (number < 10000)
                return unidades[number / 1000] + " mil" + (number % 1000 != 0 ? " " + NumberToText(number % 1000) : "");

            return "Número fora do escopo";
        }

        public static string GetCategory(int number)
        {
            if (number < 10)
                return "Unidade";
            if (number < 100)
                return "Dezena";
            if (number < 1000)
                return "Centena";
            if (number < 10000)
                return "Milhar";
            return "Fora do escopo";
        }
    }
}
