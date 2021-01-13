using System;

namespace LISTA5B_E05
{
	class Program
	{
		static int Soma(int a, int b){
			int soma = 0;
			
			if(a>b)
			{
				while(a>=b)
				{
					if(b%2 != 0)
					{
						soma = soma +b;
						b++;
					}
				}
			}
			else
			{
				if(a<b)
				{
					while(a<=b)
					{
						if(b%2 != 0)
						{
							soma = soma + b;
							b--;
						}
					}
				}
				else
				{
					soma = 0;
				}
			}
			
			return soma;
		}
		
		public static void Main(string[] args)
		{
			int a, b, soma;
			
			Console.Write("Digite o primeiro número: ");
			a = Convert.ToInt32(Console.ReadLine());
			
			Console.Write("Digite o segundo número: ");
			b = Convert.ToInt32(Console.ReadLine());
			
			soma = Soma(a,b);
			
			Console.WriteLine("\nA soma é: {0}",soma);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}