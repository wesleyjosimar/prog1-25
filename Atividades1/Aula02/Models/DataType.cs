namespace Aula02.Models
    {
     public class DataType{
    
        public char myVar = 'a';
        public char myConst = 'b';

        public char myChar1 = 'f';
        public char myChar2 = ':';
        public char myChar3 = 'x';
    //Podemos tambem atribuir referenciade caractecres unicode
        public char myChar4 = '\u2726';
    //Podemos ainda mesclar caracteres especiais como,nova linha , tabulação e etc
    public string textLine =
        "Esta é uma nova linha de texto \n\n\n esta e outra linha";

        /*
            \e caracter de escape
            \n nova linha
            \r retorno
            \t tabulação horizontal
            \

        */

        
        private int count = 10;
        public string message;

        public DataType()
        {
            //interpolação de strings
            //combinando string de difrente maneiras no C#
            message = $"O contador esta em {count}";

            string username = "Wesley";
            int InboxCount = 10;
            int MaxCount = 100;
            message += $"\n O usuario {username} tem {InboxCount} mesnagens";
            message += $"\n espaço restante em sua caixa {MaxCount - InboxCount}";

        }

    }
}
