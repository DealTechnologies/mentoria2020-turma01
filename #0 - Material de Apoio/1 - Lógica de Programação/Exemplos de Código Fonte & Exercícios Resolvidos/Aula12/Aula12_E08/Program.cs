using System;

namespace LISTA5A_08
{
	class Program
	{
		public static void Main(string[] args)
		{
			int matricula;
			double nota1, nota2, nota3, media;
			
			Console.Write("Informe a matrícula: ");
			matricula = Convert.ToInt32(Console.ReadLine());			
			
			while(matricula>=0){
				Console.Write("Informe a primera nota : ");
				nota1 = Convert.ToDouble(Console.ReadLine());
				
				Console.Write("Informe a segunda nota : ");
				nota2 = Convert.ToDouble(Console.ReadLine());
			
				Console.Write("Informe a terceira nota: ");
				nota3 = Convert.ToDouble(Console.ReadLine());
				
				media = (4*nota1 + 3*nota2 + 3*nota3) / (4+3+3);
				Console.Write("Sua média é: {0:N2}\n", media);
				
				if(media>=5){
					Console.Write("APROVADO");
				}
				else{
					Console.Write("REPROVADO");
				}
				
				Console.Write("\n\n\nInforme a matrícula: ");
				matricula = Convert.ToInt32(Console.ReadLine());
			}
		}
	}
}