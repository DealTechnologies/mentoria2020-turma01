using System;

namespace Aula12_E01
{
	class Program
	{
		public static void Main(string[] args)
		{
			for(int i=1; i<=100; i++){
				if(i%2==0){
					Console.WriteLine("{0}",i);
				}
			}
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}