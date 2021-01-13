using System;

namespace Lista2BIM_Ex03
{
	class Program
	{
		static void LerAtletas(Atleta[] atletas)
		{
			Atleta atual;
			
			for(int i=0; i < atletas.Length; i++)
			{
				atual = new Atleta();
				Console.WriteLine("\n - Atleta:");
				
				Console.Write("Nome: ");
				atual.setNome(Console.ReadLine());
				
				Console.Write("Idade: ");
				atual.setIdade(Convert.ToInt32(Console.ReadLine()));
				
				Console.Write("Peso: ");
				atual.setPeso(Convert.ToDouble(Console.ReadLine()));
				
				Console.Write("Altura: ");
				atual.setAltura(Convert.ToDouble(Console.ReadLine()));

				atletas[i] = atual;
			}
		}
		
		static string MaiorIdade(Atleta[] atletas)
		{
			string nome="a";
			double idade;
			
			for(int i=0; i < atletas.Length; i++)
			{	
				nome = atletas[i].getNome();
				idade = atletas[i].getIdade();
				
				if(idade <= atletas[i].getIdade())
				{
					nome = atletas[i].getNome();
					idade = atletas[i].getIdade();
				}
			}
			
			return nome;
		}
		
		static string MaiorIMC(Atleta[] atletas)
		{
			string nome="a";
			double imc;
			
			for(int i=0; i < atletas.Length; i++)
			{	
				nome = atletas[i].getNome();
				imc = atletas[i].getIMC();
				
				if(imc <= atletas[i].getIMC())
				{
					nome = atletas[i].getNome();
					imc = atletas[i].getIMC();
				}
			}
			
			return nome;
		}
		
		
		public static void Main(string[] args)
		{
			Atleta[] atletas = new Atleta[2];
			
			LerAtletas(atletas);
			
			Console.WriteLine("\nMaior Idade: {0}", MaiorIdade(atletas));
			Console.WriteLine("Maior IMC: {0}", MaiorIMC(atletas));
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}