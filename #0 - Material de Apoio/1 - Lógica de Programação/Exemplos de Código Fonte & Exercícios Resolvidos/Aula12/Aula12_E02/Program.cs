using System;

namespace Aula12_E01
{
	class Program
	{
		public static void Main(string[] args)
		{
			for(int i=100; i>0; i--){
				Console.WriteLine("{0}",i);
			}			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}