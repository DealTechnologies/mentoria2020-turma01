using System;

namespace Aula09_E01
{
	class Program
	{
		static void ConverterSegundos(int tempo){
			int segundos, minutos, horas;
			
			horas = tempo / 3600;
			tempo = tempo % 3600;
			minutos = tempo / 60;
			segundos = tempo % 60;
			
			Console.WriteLine("\nSão {0} hora(s) {1} minuto(s) e {2} segundo(s)", horas, minutos, segundos);
		}
		
		public static void Main(string[] args)
		{
			int segundos;
			
			Console.Write("Informe a quantidade de segundos:");
			segundos = Convert.ToInt32(Console.ReadLine());
			
			ConverterSegundos(segundos);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}