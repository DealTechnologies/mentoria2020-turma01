using System;

namespace LISTA5B_E07
{
	class Program
	{
		static int Calculo(){
			
			int cont = 0;
			double numero;
			int positivo = 0;
			int negativo = 0;
			double mediaA = 0;			
			double positivoPerc;
			double negativoPerc;
			
			Console.Write("Informe um número: ");
			numero = Convert.ToDouble(Console.ReadLine());
			
			while(numero!=0 && cont<=50){
				if(numero>0)
				{
					positivo++;
				}
				else
				{
					negativo++;
				}
				mediaA = mediaA + numero;
				cont++;
				
				Console.Write("Informe um número: ");
				numero = Convert.ToDouble(Console.ReadLine());
			}
			
			positivoPerc = (100*positivo)/cont;
			negativoPerc = (100*negativo)/cont;
			mediaA = mediaA/cont;
			
			Console.Write("\nA quantidade de números positivos é: {0}", positivo);
			Console.Write("\nA quantidade de números negativos é: {0}", negativo);
			Console.Write("\nO percentual de números positivos é: {0:N2}%", positivoPerc);
			Console.Write("\nO percentual de números negativos é: {0:N2}%", negativoPerc);
			Console.Write("\nA média aritmética é: {0:N3}", mediaA);
			return cont;
		}
		
		public static void Main(string[] args)
		{
			int cont;
			cont = Calculo();
			
			Console.WriteLine("\n\nA quantidade de números é: {0}",cont);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}