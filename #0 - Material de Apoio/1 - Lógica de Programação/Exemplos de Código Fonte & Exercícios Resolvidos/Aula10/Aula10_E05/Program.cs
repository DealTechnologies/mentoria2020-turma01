using System;

namespace Aula10_E05
{
	class Program
	{
		static int LerTecladoInt(){
			int x;
			x = Convert.ToInt32(Console.ReadLine());
			return x;
		}
		
		static void DiaSemana(int numero){
			Console.WriteLine();
			switch (numero)
			{
				case 1:
					Console.WriteLine("Domingo");
					break;
				case 2:
					Console.WriteLine("Segunda-Feira");
					break;
				case 3:
					Console.WriteLine("Terça-Feira");
					break;
				case 4:
					Console.WriteLine("Quarta-Feira");
					break;
				case 5:
					Console.WriteLine("Quinta-Feira");
					break;
				case 6:
					Console.WriteLine("Sexta-Feira");
					break;
				case 7:
					Console.WriteLine("Sábado");
					break;
				default:
					Console.WriteLine("Número inválido");
					break;
			}
		}
		
		public static void Main(string[] args)
		{
			int numero;
			
			Console.WriteLine("Informe um número de 1 a 7, para ser informado o dia da semana correspondente!\n");
			Console.Write("Digite o número desejado: ");
			
			numero = LerTecladoInt();
			
			DiaSemana(numero);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}