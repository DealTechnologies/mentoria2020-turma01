using System;

namespace Aula11_E01
{
	class Program
	{
		static int LerTecladoInt(){
			int x;
			x = Convert.ToInt32(Console.ReadLine());
			return x;
		}
		
		static void Divisao(int numero1, int numero2){
			
			Console.WriteLine();
			
			if(numero2!=0){
				Console.WriteLine("O resultado da divisão é: {0:N2}", (double) numero1/numero2);
			}
			else{
				Console.WriteLine("Não é possível realizar a operação");
			}
		}
		
		public static void Main(string[] args)
		{
			int numero1, numero2;
			
			Console.Write("Digite o primeiro número: ");
			numero1 = LerTecladoInt();
			
			Console.Write("Digite o segundo número : ");
			numero2 = LerTecladoInt();
			
			Divisao(numero1, numero2);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}