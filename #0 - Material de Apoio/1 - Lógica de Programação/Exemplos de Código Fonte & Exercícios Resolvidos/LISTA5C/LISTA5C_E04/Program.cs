using System;

namespace LISTA5C_E04
{
	class Program
	{
		static void OperacaoBancaria(double saldo, double chequeEspecial, double saque){
			char resposta;
			
			if(saldo >= saque)
			{
				Console.WriteLine("\nSaque autorizado");
			}
			else
			{
				if(saldo+chequeEspecial >= saque)
				{
					Console.WriteLine("\nVocê utilizará {0:N2} do limite de seu cheque especial.", (double)saque-saldo);
					Console.Write("\nDeseja continuar (s/n)?");
					resposta = Convert.ToChar(Console.ReadLine());
					
					if(resposta=='s' || resposta=='S')
					{
						Console.WriteLine("\nSaque autorizado");
					}
					else
					{
						if(resposta=='n' || resposta=='N')
						{
							Console.WriteLine("\nUsuário abortou a operação");
						}
					}
				}
				else
				{
					Console.WriteLine("\nSaldo insuficiente");
				}
			}
		}
		
		public static void Main(string[] args)
		{
			double saldo, chequeEspecial, saque;			
			
			Console.Write("Informe o valor do saldo: ");
			saldo = Convert.ToDouble(Console.ReadLine());
			
			Console.Write("Informe o limite do cheque especial: ");
			chequeEspecial = Convert.ToDouble(Console.ReadLine());
			
			Console.Write("Informe o valor do saque: ");
			saque = Convert.ToDouble(Console.ReadLine());
			
			OperacaoBancaria(saldo, chequeEspecial, saque);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}