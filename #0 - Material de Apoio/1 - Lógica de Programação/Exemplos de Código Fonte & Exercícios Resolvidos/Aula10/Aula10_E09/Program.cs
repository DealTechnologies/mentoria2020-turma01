using System;

namespace Aula10_E09
{
	class Program
	{
		static int LerTecladoInt(){
			int x;
			x = Convert.ToInt32(Console.ReadLine());
			return x;
		}
		
		static void FormasPagamento(){
			Console.WriteLine("Forma de pagamento:");
			Console.WriteLine("1 - À vista.");
			Console.WriteLine("2 - Cheque para trinta dias.");
			Console.WriteLine("3 - Em duas vezes.");
			Console.WriteLine("4 - Em três vezes.");
			Console.WriteLine("5 - Em quatro vezes.");
			Console.WriteLine("6 - A partir de 5 vezes.");
			Console.WriteLine("");			
		}
		
		static void EscolhaFormaPagamento(){
			
			Console.Write("Entre com sua opção: ");
			int opcao = LerTecladoInt();
			Console.WriteLine("");
			
			switch(opcao){
				case 1:
					Console.WriteLine("Desconto de 20%.");
					break;
				case 2:
				case 3:
				case 4:
					Console.WriteLine("Mesmo preço a vista.");
					break;
				case 5:
					Console.WriteLine("Juros de 3% ao mês.");
					break;
				case 6:
					Console.WriteLine("Juros de 5% ao mês.");
					break;
				default:
					Console.WriteLine("Opção inválida.");
					break;
			}
		}
		
		public static void Main(string[] args)
		{
			FormasPagamento();
			EscolhaFormaPagamento();
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}