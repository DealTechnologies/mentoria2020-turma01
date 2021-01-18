using System;

namespace Classes_Exemplo
{
	public class Pessoa
	{
		private string nome;
		private double altura;
		
		public void setNome(string novoNome)
		{
			nome = novoNome;
		}
		
		public string getNome()
		{
			return nome;
		}
		
		public void setAltura(double novoAltura)
		{
			altura = novoAltura;
		}
		
		public double getAltura()
		{
			return altura;
		}
	}
}
