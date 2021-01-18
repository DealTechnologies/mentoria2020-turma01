using System;

namespace Aula10_E06
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
		
		static void OperacaoSimbolos(double numero1, double numero2, char simbolo){
			Console.WriteLine();
			
			double resultado;
			
			switch (simbolo)
			{
				case '+':
					resultado = numero1 + numero2;
					Console.WriteLine("O resultado é: {0}", resultado);
					break;
				case '-':
					resultado = numero1 - numero2;					
					Console.WriteLine("O resultado é: {0}", resultado);
					break;
				case '*':
					resultado = numero1 * numero2;
					Console.WriteLine("O resultado é: {0}", resultado);
					break;
				case '/':
					resultado = numero1 / numero2;
					Console.WriteLine("O resultado é: {0}", resultado);
					break;				
				default:
					Console.WriteLine("Símbolo inválido");
					break;
			}
		}
		
		public static void Main(string[] args)
		{
			double numero1, numero2;
			char simbolo;
			
			Console.Write("Informe o primeiro número: ");
			numero1 = LerTecladoDouble();			
			
			Console.Write("Informe o segundo número : ");
			numero2 = LerTecladoDouble();			
			
			Console.Write("Informe o símbolo da operação: ");
			simbolo = LerTecladoChar();
			
			OperacaoSimbolos(numero1, numero2, simbolo);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}