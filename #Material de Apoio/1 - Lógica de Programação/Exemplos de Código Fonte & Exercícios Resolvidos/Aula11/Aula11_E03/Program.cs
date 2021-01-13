using System;

namespace Aula11_E01
{
	class Program
	{
		static double LerTecladoDouble(){
			double x;
			x = Convert.ToDouble(Console.ReadLine());
			return x;
		}
		
		static char LerTecladoChar(){
			char x;
			x = Convert.ToChar(Console.ReadLine());
			return x;
		}
		
		static void Valores(char sexo, double altura){
			
			Console.WriteLine();
			
			if(sexo=='m'){
				Console.WriteLine("O peso ideal para você é: {0:N2}", (72.7*altura)-58);
			}
			else{
				if(sexo=='f'){
					Console.WriteLine("O peso ideal para você é: {0:N2}", (62.1*altura)-44.7);			
				}
				else{
					Console.WriteLine("Sexo inválido");
				}
			}
		}
		
		public static void Main(string[] args)
		{
			char sexo;
			double altura;
			
			Console.WriteLine("Digite 'm' para masculino e 'f' para feminino:\n");
			
			Console.Write("Digite o seu sexo: ");
			sexo = LerTecladoChar();
			
			Console.Write("Digite sua altura: ");
			altura = LerTecladoDouble();
			
			Valores(sexo, altura);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}