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
			
			if(idade>=5 && idade<=7){
				Console.WriteLine("Infantil A");
			}
			else{
				if(idade>=8 && idade<=10){
					Console.WriteLine("Infantil B");
				}
				else{
					if(idade>=11 && idade<=13){
						Console.WriteLine("Juvenil A");
					}
					else{
						if(idade>=14 && idade<=17){
							Console.WriteLine("Juvenil B");
						}
						else{
							if(idade>=18 && idade<=30){
								Console.WriteLine("Adulto");
							}
							else{
								if(idade>30){
									Console.WriteLine("Sênior");
								}
								else{
									Console.WriteLine("Sem categoria");
								}
							}
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