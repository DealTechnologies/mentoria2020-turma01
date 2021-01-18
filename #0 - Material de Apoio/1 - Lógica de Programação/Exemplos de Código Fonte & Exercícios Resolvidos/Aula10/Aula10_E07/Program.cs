using System;

namespace Aula10_E06
{
	class Program
	{
		static int LerTecladoInt(){
			int x;
			x = Convert.ToInt32(Console.ReadLine());
			return x;
		}
		
		static void StatusIdade(int idade){
			Console.WriteLine();
			
			if(idade>=0 && idade<13){
				Console.WriteLine("Criança");
			}
			else{
				if(idade>=0 && idade<20){
					Console.WriteLine("Adolecente");
				}
				else{
					if(idade>=0 && idade<60){
						Console.WriteLine("Adulto");
					}
					else{
						if(idade>=0 && idade>=60){
							Console.WriteLine("Idoso");
						}
						else{
							Console.WriteLine("Idade inválida");
						}
					}
				}
			}
		}
		
		public static void Main(string[] args)
		{
			int idade;
			
			Console.Write("Informe a idade: ");
			idade = LerTecladoInt();
			
			StatusIdade(idade);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}