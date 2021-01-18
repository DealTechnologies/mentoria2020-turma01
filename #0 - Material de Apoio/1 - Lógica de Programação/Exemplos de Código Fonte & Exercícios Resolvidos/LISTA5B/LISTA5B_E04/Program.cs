using System;

namespace LISTA5B_E04
{
	class Program
	{
		static void Idade(int anoAtual, int anoNasc){
			int idade = anoAtual - anoNasc;
			Console.Write("\nA sua idade é: {0} \n",idade);
			
			if(idade>=0 && idade<3){
				Console.Write("\nBebê");
			}
			else{
				if(idade>=0 && idade<10){
					Console.Write("\nCriança");
				}
				else{
					if(idade>=0 && idade<18){
						Console.Write("\nAdolecente");
					}
					else{
						if(idade>=0 && idade<60){
							Console.Write("\nAdulto");
						}
						else{
							if(idade>=0 && idade>=60){
								Console.Write("\nIdoso");
							}
						}
					}
				}
			}
			
		}
		
		public static void Main(string[] args)
		{
			int anoAtual, anoNasc;
			
			Console.Write("Digite o ano atual: ");
			anoAtual = Convert.ToInt32(Console.ReadLine());
						
			Console.Write("Digite o ano de nascimento: ");
			anoNasc = Convert.ToInt32(Console.ReadLine());
			
			Idade(anoAtual, anoNasc);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}