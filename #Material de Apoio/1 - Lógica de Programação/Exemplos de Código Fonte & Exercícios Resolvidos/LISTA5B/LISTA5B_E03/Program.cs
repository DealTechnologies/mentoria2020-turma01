using System;

namespace LISTA5B_E03
{
	class Program
	{
		static double MaiorNumero(double n1, double n2, double n3){
			double maior;
			if(n1>n2 && n1>n3){
				maior = n1;
			}
			else{
				if(n2>n1 && n2>n3){
					maior = n2;
				}
				else{
					maior = n3;
				}
			}
			
			return maior;
		}
		
		public static void Main(string[] args)
		{
			double n1, n2, n3, maior;
			
			Console.Write("Digite o primeiro número: ");
			n1 = Convert.ToDouble(Console.ReadLine());
			
			Console.Write("Digite o segundo número : ");
			n2 = Convert.ToDouble(Console.ReadLine());
			
			Console.Write("Digite o terceiro número: ");
			n3 = Convert.ToDouble(Console.ReadLine());
			
			maior = MaiorNumero(n1,n2,n3);
			
			Console.WriteLine("\nO maior número é: {0:N2}",maior);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}