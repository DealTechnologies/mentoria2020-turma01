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
		
		static void StatusIdade(int codigo){
			Console.WriteLine();
			
			if(codigo>=1 && codigo<=20){
				Console.WriteLine("Europa");
			}
			else{
				if(codigo>=21 && codigo<=40){
					Console.WriteLine("Ásia");
				}
				else{
					if(codigo>=41 && codigo<=60){
						Console.WriteLine("América");
					}
					else{
						if(codigo>=61 && codigo<=80){
							Console.WriteLine("África");
						}
						else{
							if(codigo>80){
								Console.WriteLine("Paraguai");
							}
						}
					}
				}
			}
		}
		
		public static void Main(string[] args)
		{
			int codigo;
			
			Console.Write("Informe o código do produto: ");
			codigo = LerTecladoInt();
			
			StatusIdade(codigo);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}