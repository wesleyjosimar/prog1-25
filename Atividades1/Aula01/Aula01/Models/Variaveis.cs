using System;

public class Variaveis	
{
	// Anotacao de Tipos
	public int userCount = 10;

    //Uma Variavel pode ser declarada
    //e nao inicializada
    public int totalCount;

	//CONSTANTES
	//Para declarar uma constante
	//ultilizamos a palavra CONST
	//No entanto a CONST deve ser inicializada
	//quando declarada
	const int interestRate = 10;

	//o metodo contrutor e invocado
	// na iniclização do objeto por meio
	//da palavra reservada new
	//por regra, o construtor sempre tem
	//o mesmo nome da classe
	public Variaveis()
	{
		totalCount = 0;
		//tipo implicito
		//a palavra chave var ver se encarrega
		//de defnir o tipo da variavel
		//na instrução de atribuição
		var signalStrength = 22;
		var companyName = "ACME";


}
}
