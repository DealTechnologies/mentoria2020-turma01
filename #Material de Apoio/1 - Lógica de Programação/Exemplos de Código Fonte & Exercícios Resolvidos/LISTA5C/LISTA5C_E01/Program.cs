using System;

namespace LISTA5C_E01
{
	class Program
	{
		public static void Main(string[] args)
		{ 
			double n1, n2, n3;
				
			Console.Write("Informe o primeiro número: ");
			n1 = Convert.ToDouble(Console.ReadLine());
			
			Console.Write("Informe o segundo número : ");
			n2 = Convert.ToDouble(Console.ReadLine());
			
			Console.Write("Informe o terceiro número: ");
			n3 = Convert.ToDouble(Console.ReadLine());
			
			if(n1>=n2 && n1>=n3)
			{
				Console.Write("\nO quadrado é: {0}", Math.Pow(n1,2));
			}
			else
			{
				if(n2>=n1 && n2>=n3)
				{
					Console.Write("\nO quadrado é: {0}", Math.Pow(n2,2));
				}
				else
				{
					if(n3>=n1 && n3>=n2)
					{
						Console.Write("\nO quadrado é: {0}", Math.Pow(n3,2));
					}
				}
			}
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}