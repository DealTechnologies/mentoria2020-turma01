using System;

namespace Classes_Exemplo2
{
	public class Aluno
	{
		private string nome;
		private double nota1;
		private double nota2;
		private double nota3;
		
		public string setNome(string novoNome)
		{
			nome = novoNome;
		}
		
		public string getNome()
		{
			return nome;
		}
		
		public double setNota1(double novoNota1)
		{
			nota1 = novoNota1;
		}
		
		public double getNota1()
		{
			return nota1;
		}
		
		public double setNota2(double novoNota2)
		{
			nota2 = novoNota2;
		}
		
		public double getNota2()
		{
			return nota2;
		}
		
		public double setNota3(double novoNota3)
		{
			nota3 = novoNota3;
		}
		
		public double getNota3()
		{
			return nota3;
		}
		
		public double getMedia()
		{
			return (nota1 + nota2 + nota3) /3;
		}
	}
}
