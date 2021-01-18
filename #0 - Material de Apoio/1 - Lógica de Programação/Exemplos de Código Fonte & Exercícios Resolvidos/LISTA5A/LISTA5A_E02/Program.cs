using System;

namespace LISTA5A_E02
{
	class Program
	{
		
		static void Operacoes(int numero1, int numero2){
			Console.WriteLine();
			Console.WriteLine("A soma é: {0}", numero1+numero2);
			Console.WriteLine("A diferença é: {0} ", numero1-numero2);
			Console.WriteLine("O produto é: {0} ", numero1*numero2);
			Console.WriteLine("O quociente é: {0:N2} ", (double)numero1/numero2);
			Console.WriteLine("O resto é: {0} ", numero1%numero2);
		}
		
		public static void Main(string[] args)
		{			
			int numero1, numero2;
			
			Console.Write("Digite um número inteiro: ");
			numero1 = Convert.ToInt32(Console.ReadLine());
			
			Console.Write("Digite um número inteiro: ");
			numero2 = Convert.ToInt32(Console.ReadLine());
			
			Operacoes(numero1, numero2);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}