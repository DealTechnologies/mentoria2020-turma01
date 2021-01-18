using System;

namespace Aula09_05
{
	class Program
	{	
		static double Posicao(double instante, double aceleracao, double posicaoInicial, double velocidadeInicial){
			double posicao;
			posicao = posicaoInicial + velocidadeInicial + instante + (aceleracao * instante * instante) / 2;
			return posicao;
		}
		
		static double Velocidade(double instante, double aceleracao, double velocidadeInicial){
			double velociade;
			velociade = velocidadeInicial + aceleracao * instante;
			return velociade;
		}
		
		public static void Main(string[] args)
		{
			double instante, aceleracao, posicaoInicial, velocidadeInicial, posicao, velocidade;
			
			Console.Write("Informe o instante: ");
			instante = Convert.ToDouble(Console.ReadLine());
			
			Console.Write("Informe a aceleração: ");
			aceleracao = Convert.ToDouble(Console.ReadLine());
			
			Console.Write("Informe a posião inicial: ");
			posicaoInicial = Convert.ToDouble(Console.ReadLine());
			
			Console.Write("Informe a velociade inicial: ");
			velocidadeInicial = Convert.ToDouble(Console.ReadLine());
			
			posicao = Posicao(instante, aceleracao, posicaoInicial, velocidadeInicial);
			velocidade = Velocidade(instante, aceleracao, velocidadeInicial);
			
			Console.WriteLine("\nA posição é   : {0}",posicao);
			Console.WriteLine("A velocidade é: {0}", velocidade);			
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}