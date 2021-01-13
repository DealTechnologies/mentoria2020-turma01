using System;

namespace LISTA5A_E06
{
	class Program
	{
		public static void Main(string[] args)
		{
			double numero, maior, menor;
			
			Console.Write("Digite o 1° número: ");
			numero = Convert.ToDouble(Console.ReadLine());
			
			maior = numero;
			menor = numero;
			
			for(int i=0; i<9; i++){
				
				Console.Write("\nDigite o {0}° número: ",i+2);
				numero = Convert.ToDouble(Console.ReadLine());
				
				if(numero>maior){
					maior = numero;
					Console.Write("O maior atual é: {0:N2}\n", maior);
					Console.Write("O menor atual é: {0:N2}\n\n", menor);
				}
				else{
					if(numero<menor){
						menor = numero;
						Console.Write("O maior atual é: {0:N2}\n", maior);
						Console.Write("O menor atual é: {0:N2}\n", menor);
					}
					else{
						Console.Write("O maior atual é: {0:N2}\n", maior);
						Console.Write("O menor atual é: {0:N2}\n", menor);
					}
				}
			}
			
			Console.Write("\nO maior número é: {0:N2}", maior);
			Console.Write("\nO menor número é: {0:N2}\n", menor);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}