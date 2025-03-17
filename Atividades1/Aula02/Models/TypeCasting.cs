namespace Aula02.Models
{
    public class TypeCasting
    {
        //Declando variaveis na Classe
        public int myInterger =20;
        public long myLong;

        public string myType1;
        public string myType2;
       
        public TypeCasting()
        {
            //conversao implicita de tipos
            myLong = myInterger;
            //myInterger = myLong;
            //Nesse caso o nome e muito grande para  o int e a conversao implicita
            //nao e permitida

            //Conversao explicita 
            long myLong2 = 138129210;
            int myInterger2;
            myInterger2 = (int)myLong2;

            myType1 = myLong2.GetType().ToString();
            myType2 = myInterger2.GetType().ToString();


            //e possivel identificar qual e o tipo de uma variavel em tempo de execução

        }
    }
}
