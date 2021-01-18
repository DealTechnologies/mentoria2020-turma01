using System;

namespace Classes02_Ex01
{
	class Program
	{
		public static void Main(string[] args)
		{
			Cartao cartao1 = new Cartao();
			Cartao cartao2 = new Cartao();
			
			cartao1.numero_cartao = 1234567891234567;
			cartao1.codigo_verificacao = 123;
			cartao1.mes = 12;
			cartao1.ano = 2005;
			
			cartao2.numero_cartao = 9876543219876543;
			cartao2.codigo_verificacao = 321;
			cartao2.mes = 05;
			cartao2.ano = 2012;
			
			Console.WriteLine("Número: {0}",cartao2.numero_cartao);
			Console.WriteLine("Código de verificação: {0}",cartao2.codigo_verificacao);	
			Console.WriteLine("Validade: {0}/{1}",cartao2.mes, cartao2.ano);	
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}