using System;

namespace dotnet
{
    class Program
    {
        static void Main(string[] args)
        {
            Pessoa x, y;

            x = new Pessoa();
            y = new Pessoa();

            Console.WriteLine("Digite a primeira pessoa:");
            Console.Write("Nome: ");
            x.Nome = Console.ReadLine();
            Console.Write("Idade: ");
            x.Idade = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a segunda pessoa:");
            Console.Write("Nome: ");
            y.Nome = Console.ReadLine();
            Console.Write("Idade: ");
            y.Idade = int.Parse(Console.ReadLine());

            if(x.Idade > y.Idade){
                Console.WriteLine("Pessao mas velha {0}",x.Nome);
            }else{
                Console.WriteLine("Pessao mas velha {0}",y.Nome);

            }


        }
    }
}
