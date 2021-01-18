using System;

namespace Aula11_E05
{
	class Program
	{
		static char LerTecladoChar(){
			char x;
			x = Convert.ToChar(Console.ReadLine());
			return x;
		}
		
		static void ImprimirCaracteres(char caracter){
			Console.WriteLine();
			
			switch(caracter){
				case '<':
					Console.WriteLine("Sinal de menor");
			    	break;
			    case '>':
					Console.WriteLine("Sinal de maior");
			    	break;
			    case '=':
					Console.WriteLine("Sinal de igual");
			    	break;
			    default:
					Console.WriteLine("Outro caracter");
			    	break;
			}                 
		}
		
		
		public static void Main(string[] args)
		{
			char caracter;
			
			Console.WriteLine("Informe um dos caracteres a seguir: < ou > ou = \n");
			
			Console.Write("Digite o caracter: ");
			caracter = LerTecladoChar();
			
			ImprimirCaracteres(caracter);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}