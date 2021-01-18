using System;

namespace Lista2BIM_Ex03
{
	public class Atleta
	{
		private string nome;
		private int idade;
		private double peso;
		private double altura;
		
		//Atributo Nome
		public void setNome(string novoNome)
		{
			nome = novoNome;
		}
		
		public string getNome()
		{
			return nome;
		}
		
		//Atributo Idade
		public void setIdade(int novaIdade)
		{
			idade = novaIdade;
		}
		
		public int getIdade()
		{
			return idade;
		}
		
		//Atributo Peso
		public void setPeso(double novoPeso)
		{
			peso = novoPeso;
		}
		
		public double getPeso()
		{
			return peso;
		} 
		
		//Atributo Altura
		public void setAltura(double novaAltura)
		{
			altura = novaAltura;
		}
		
		public double getAltura()
		{
			return altura;
		}
		
		//Calculo IMC
		public double getIMC()
		{
			return peso / (altura * altura);
		}
	}
}