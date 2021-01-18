using System;

namespace LISTA5A_E04
{
	class Program
	{		
		public static void Main(string[] args)
		{
			char sexo;
			double altura;
			
			Console.WriteLine("Digite 'm' para masculino e 'f' para feminino:\n");
			
			Console.Write("Digite o seu sexo: ");
			sexo = Convert.ToChar(Console.ReadLine());
			
			Console.Write("Digite sua altura: ");
			altura = Convert.ToDouble(Console.ReadLine());
			
			if(sexo=='m'){
				Console.WriteLine("\nO peso ideal para você é: {0:N2}", (72.7*altura)-58);
			}
			else{
				if(sexo=='f'){
					Console.WriteLine("\nO peso ideal para você é: {0:N2}", (62.1*altura)-44.7);			
				}
				else{
					Console.WriteLine("\nSexo inválido");
				}
			}
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}