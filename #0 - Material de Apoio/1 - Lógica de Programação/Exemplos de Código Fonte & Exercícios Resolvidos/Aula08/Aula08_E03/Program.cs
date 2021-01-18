using System;

namespace Aula08_E03
{
	class Program
	{	
		static void operacoes(int n1, int n2){
			int soma, diferenca, produto, quociente, resto;
			soma = n1 + n2;
			diferenca = n1 - n2;
			produto = n1 * n2;
			quociente = n1 /n2;
			resto = n1 % n2;
			
			Console.WriteLine("\nA soma é: {0}", soma);
			Console.WriteLine("A diferenca é: {0}",diferenca);
			Console.WriteLine("O produto é: {0}",produto);
			Console.WriteLine("O quociente é: {0}",quociente);
			Console.WriteLine("O resto é: {0}",resto);			
		}
		
		
		public static void Main(string[] args)
		{
			int n1, n2;
			
			Console.Write("Digite o primeiro número:"); n1 = Convert.ToInt32(Console.ReadLine());
			Console.Write("Digite o segundo número :"); n2 = Convert.ToInt32(Console.ReadLine());

			operacoes(n1, n2);
		
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}