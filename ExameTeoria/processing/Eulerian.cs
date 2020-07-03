using ExameTeoria.data;
using Microsoft.VisualBasic;
using System;

namespace ExameTeoria.processing
{
    class Eulerian
    {
        private Data data;

        public Eulerian(Data data)
        {
            this.data = data;
        }

        public void Run()
        {

            if (data.MatrizNoh == null || data.NohList == null)
            {
                Console.WriteLine("Voce deve primeiro informar a matriz para calcular!");
                return;
            }

            Console.WriteLine("Calculando....");

            int numeroDeNohs = (int)Math.Sqrt(data.MatrizNoh.Length);
            int numeroDePossibilidades = numeroDeNohs - 1;

            for (int i = 0; i < numeroDeNohs; i++)
            {
                int quantidadeDeNumerosPar = 0;
                for (int y = 0; y < numeroDeNohs; y++)
                {
                    if (i != y)
                    {
                        if (data.MatrizNoh[i, y] == 1)
                        {
                            quantidadeDeNumerosPar++;
                        }
                    }
                }

                if (quantidadeDeNumerosPar % 2 == 0)
                {
                    data.NohList[i].isEulerian = true;
                }

            }

            int numeroDePars = 0;

            for (int i = 0; i < numeroDeNohs; i++)
            {
                if (data.NohList[i].isEulerian)
                {
                    numeroDePars++;
                }
            }

            numeroDePars--;

            if (numeroDePars == numeroDePossibilidades)
            {
                Console.WriteLine("O grafo e euleriano");
            }
            else if (numeroDePars == (numeroDePossibilidades - 1) || numeroDePars == (numeroDePossibilidades - 2))
            {
                Console.WriteLine("O grafo e semi-euleriano");
            }
            else
            {
                Console.WriteLine("O grafo nao e euleriano");
            }

        }
    }
}
