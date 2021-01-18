using System;

namespace Classes_Exemplo2
{
	class Program
	{
		static void LerAlunos(Aluno[] alunos)
		{
			Aluno atual;
			
			for(int i=0; i < alunos.Length; i++)
			{
				atual = new Aluno();
				Console.WriteLine(" - Alunos:");
				
				Console.Write("Nome: ");
				atual.setNome(Console.ReadLine());
				
				Console.Write("Nota 1: ");
				atual.setNota1(Convert.ToDouble(Console.ReadLine()));
				
				Console.Write("Nota 2: ");
				atual.setNota2(Convert.ToDouble(Console.ReadLine()));
				
				Console.Write("Nota 3: ");
				atual.setNota3(Convert.ToDouble(Console.ReadLine()));

				alunos[i] = atual;
			}
		}
		
		static void ImprimirAlunos(Aluno[] alunos)
		{
			for(int i=0; i < alunos.Length; i++)
			{
				Console.WriteLine("{0}",alunos[i].getNome());
				Console.WriteLine("{0}",alunos[i].getNota1());
				Console.WriteLine("{0}",alunos[i].getNota2());
				Console.WriteLine("{0}",alunos[i].getNota3());
			}
		}
		
		static double MediaTurma(Aluno[] alunos)
		{
			double soma = 0;
			
			for(int i=0; i < alunos.Length; i++)
			{
				soma = soma + alunos[i].getMedia();
			}
			
			return soma / alunos.Length;
		}
		
		static void ImprimirAlunosAcimaMedia(Aluno[] alunos, double mediaTurma)
		{
			Console.Write("\nAlunos com notas acima da média:");
			
			for(int i=0; i < alunos.Length; i++)
			{
				if(alunos[i].getMedia() > mediaTurma)
				{
					Console.WriteLine(" - {0}", alunos[i].getNome());
				}
			}
		}
		
		
		public static void Main(string[] args)
		{
			Aluno[] alunos = new Aluno[5];
			
			LerAlunos(alunos);
			
			double media = MediaTurma(alunos);
			
			ImprimirAlunosAcimaMedia(alunos, media);			
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}