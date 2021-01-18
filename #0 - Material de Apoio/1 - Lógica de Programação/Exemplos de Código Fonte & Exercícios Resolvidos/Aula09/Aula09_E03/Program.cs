using System;

namespace Aula09_E03
{
	class Program
	{
		static int CalcularIdade(int anos, int meses, int dias){
			int tempo;
			tempo = anos * 365;
			tempo = tempo + (meses * 30);
			tempo = tempo + dias;
			
			return tempo;
		}
				
		public static void Main(string[] args)
		{
			int anos, meses, dias, tempo;
			
			Console.Write("Informe o(s) ano(s): ");
			anos = Convert.ToInt32(Console.ReadLine());
			
			Console.Write("Informe o(s) mese(s): ");
			meses = Convert.ToInt32(Console.ReadLine());
			
			Console.Write("Informe o(s) dia(s): ");
			dias = Convert.ToInt32(Console.ReadLine());
			
			tempo = CalcularIdade(anos, meses, dias);
			
			Console.WriteLine("\nO número de dias é: {0}", tempo);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}