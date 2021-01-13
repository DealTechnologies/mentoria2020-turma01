using System;

namespace Classes01_E01
{
	class Program
	{
		public static void Main(string[] args)
		{
			
			Aluno a = new Aluno();
			Aluno b = new Aluno();
			
			a.Matricula = 10223;
			a.Nome = "Ana";
			
			b.Matricula = 31083;
			b.Nome = "Lucas";
			
			Console.WriteLine("Aluno: {0} - {1}", a.Matricula, a.Nome);
			Console.WriteLine("Aluno: {0} - {1}", b.Matricula, b.Nome);						
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}