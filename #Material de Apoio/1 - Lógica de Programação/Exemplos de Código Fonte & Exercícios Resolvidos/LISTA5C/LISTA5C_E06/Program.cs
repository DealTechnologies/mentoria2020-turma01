using System;

namespace LISTA5C_E06
{
	class Program
	{
		static void CaracterA(){
			char c;
			int quantidade = 0, cont = 0;
			
			Console.Write("Informe um caracter: ");
			c = Convert.ToChar(Console.ReadLine());
			
			while(c=='a' || c=='A' || c=='e' || c=='E' || c=='i' || c=='I' || c=='o' || c=='O' || c=='u' || c=='U')
			{
				Console.Write("Informe um caracter: ");
				c = Convert.ToChar(Console.ReadLine());
				
				if(c=='A')
				{
					quantidade++;
				}
				cont++;
			}
			
			Console.Write("\nA quantidade de 'A' é: {0}", quantidade);
			Console.Write("\nO percentual é: {0:N2}", (double)(quantidade*100)/cont);
		}
		
		public static void Main(string[] args)
		{
			CaracterA();			
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}