using System;

namespace SubRotinas
{
    class Program
    {
        static int Media (int n1, int n2, int n3)
        {
            int media;
            media = (n1 + n2 + n3) / 3; 
            return media;
        }
        static void Main(string[] args)
        {
            int n1, n2, n3, media;
            Console.WriteLine("Digite 3 valores: ");
            n1 = Convert.ToInt32(Console.ReadLine());
            n2 = Convert.ToInt32(Console.ReadLine());
            n3 = Convert.ToInt32(Console.ReadLine());

            media = Media(n1, n2, n3);
            Console.WriteLine("Media é {0}", media);
        }
    }
}
