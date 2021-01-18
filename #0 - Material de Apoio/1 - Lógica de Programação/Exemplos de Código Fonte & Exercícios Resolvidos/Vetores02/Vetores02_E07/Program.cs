using System;

namespace Vetores02_E07
{
	class Program
	{
		const int TAMANHO = 4;
		
		static void LerVetor(double[] vetor)
		{
			for(int i=0; i < TAMANHO; i++)
			{
				Console.Write("Informe o {0}° valor: ", i+1);
				vetor[i] = Convert.ToDouble(Console.ReadLine());
			}			
		}
		
		static void ImprimirVetor(double[] vetor)
		{
			for(int i=0; i < TAMANHO; i++)
			{
				Console.Write("{0}; ", vetor[i]);
			}
		}
		
		static void ParesImpares(double[] vetor, double[] pares, double[] impares)
		{
			int indiceP=0, indiceI=0;
			
			for(int i=0; i < TAMANHO; i++)
			{
				if(vetor[i] % 2 == 0)
				{
					pares[indiceP] = vetor[i];
					indiceP++;
				}
				else
				{
					impares[indiceI] = vetor[i];
					indiceI++;
				}
			}
		}
		
		public static void Main(string[] args)
		{			
			double[] vetor = new double[TAMANHO];
			double[] pares = new double[TAMANHO];
			double[] impares = new double[TAMANHO];
			
			LerVetor(vetor);
			
			ParesImpares(vetor, pares, impares);
			
			Console.Write("\nVetor  : "); 
			ImprimirVetor(vetor);
			
			Console.Write("\nPares  : ");
			ImprimirVetor(pares);
			
			Console.Write("\nImpares: ");
			ImprimirVetor(impares);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}