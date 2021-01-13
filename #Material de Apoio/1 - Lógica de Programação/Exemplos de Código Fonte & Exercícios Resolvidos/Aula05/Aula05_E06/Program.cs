using System;

namespace Aula05_E06
{
	class Program
	{
		public static void Main(string[] args)
		{
			int segundos, minutos, horas, tempo;
			
			Console.Write("Informe o tempo em segundos: "); tempo = Convert.ToInt32(Console.ReadLine());
			
			horas = tempo / 3600;
			tempo = tempo % 3600;
			minutos = tempo / 60;
			segundos = tempo % 60;
			
			Console.WriteLine("\nSão {0} hora(s) {1} minuto(s) e {2} segundo(s): ", horas, minutos, segundos);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}