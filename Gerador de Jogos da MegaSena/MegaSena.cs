using System;

namespace Gerador_de_Jogos_da_MegaSena
{
    class MegaSena
    {
        static void Main(string[] args)
        {
            Gerador MegaSena = new Gerador();

            Console.WriteLine("Seja bem vindo ao Gerador de Jogos da Mega Sena.\r\n Digite os comandos abaixo para elaborar o seu jogo e boa sorte! \r\n");
            do
            {
                Console.WriteLine("\nDigite um comando: (mostrar/novo/sair)");
                string s = Console.ReadLine();
                Console.WriteLine(" ");

                if (s != null)
                    Console.Clear();
                if (s == "mostrar")
                    MegaSena.Mostrar();
                if (s == "novo")
                    if (MegaSena.Reset()) Console.WriteLine("\n Novos numeros foram gerados!\n");
                if (s == "sair")
                    break;
            } while (true);
        }
    }

    public class Gerador
    {
        public int[] Resultado { get; private set; }

        public Gerador()
        {
            Resultado = GerarNumero();
        }

        public int[] GerarNumero()
        {
            Random r = new Random();
            int[] rs = new int[6];

            for (int i = 0; i < 6; i++)
            {
                int v;

                do
                {
                    v = r.Next(1, 60);
                }
                while (Compare(rs, i, v));

                rs[i] = v;
            }

            Array.Sort(rs);

            return rs;
        }

        private bool Compare(int[] rs, int a, int c)
        {
            foreach (int v in rs)
                if (v == c)
                    return true;

            return false;
        }


        public void Mostrar()
        {
            foreach (int n in Resultado)
            {
                Console.WriteLine("Numero = > {0}", n);
            }
        }

        public bool Reset()
        {
            Resultado = GerarNumero();
            return true;
        }

    }
}