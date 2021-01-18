using System;

namespace LISTA5A_E05
{
	class Program
	{		
		public static void Main(string[] args)
		{
			int idade;
			
			Console.Write("Informe a idade: ");
			idade = Convert.ToInt32(Console.ReadLine());
			
			// Zero SE APLICA A CRIANÇAS QUE AINDA NÃO FIZERAM ANIVERSÁRIO, SENSO ASSIM SÓ POSSUEM MESES DE IDADE		
			if(idade>=0 && idade<13){
				Console.WriteLine("\nCriança");
			}
			else{
				if(idade>=0 && idade<20){
					Console.WriteLine("\nAdolecente");
				}
				else{
					if(idade>=0 && idade<60){
						Console.WriteLine("\nAdulto");
					}
					else{
						if(idade>=0 && idade>=60){
							Console.WriteLine("\nIdoso");
						}
						else{
							Console.WriteLine("\nIdade inválida");
						}
					}
				}
			}
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}