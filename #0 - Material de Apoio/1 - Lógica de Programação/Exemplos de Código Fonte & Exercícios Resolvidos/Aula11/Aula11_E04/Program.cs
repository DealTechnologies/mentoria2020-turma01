using System;

namespace Aula11_E04
{
	class Program
	{
		static int LerTecladoInt(){
			int x;
			x = Convert.ToInt32(Console.ReadLine());
			return x;
		}
		
		static void VerificarTriangulo(int x, int y, int z){
			Console.WriteLine();
			
			if(x<y+z && y<x+z && z<x+y){
				Console.Write("Forma um triângulo");
			}
			else{
				Console.Write("Não forma um triângulo");
			}
		}
		
		public static void Main(string[] args)
		{
			int comprimento1, comprimento2, comprimento3;
			
			Console.Write("Digite o primeiro comprimento: ");
			comprimento1 = LerTecladoInt();
			
			Console.Write("Digite o segundo comprimento : ");
			comprimento2 = LerTecladoInt();
			
			Console.Write("Digite o terceiro comprimento: ");
			comprimento3 = LerTecladoInt();
			
			VerificarTriangulo(comprimento1, comprimento2, comprimento3);			
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}