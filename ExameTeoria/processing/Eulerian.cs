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
            // Verifica se ja foi inserida uma matriz
            if (data.MatrizNoh == null || data.NohList == null)
            {
                Console.WriteLine("Voce deve primeiro informar a matriz para calcular!");
                return;
            }

            Console.WriteLine("Calculando....");

            // Salva o numero de nohs
            int numeroDeNohs = data.NohList.Count;
            int numeroDePossibilidades = numeroDeNohs - 1;

            // A partida de um noh da lista, passa soma todas arestas conectadas a ele (Valor => 0)
            for (int i = 0; i < numeroDeNohs; i++)
            {
                int quantidadeDeNumerosPar = 0;
                // Conta as aresta conectadas naquele noh especifico
                for (int y = 0; y < numeroDeNohs; y++)
                {
                    // Desconsidera o proprio noh
                    if (i != y)
                    {
                        if (data.MatrizNoh[i, y] >= 0)
                        {
                            quantidadeDeNumerosPar++;
                        }
                    }
                }

                // Caso o numero de arestas conectadas aquele noh seja par, ele marca aquele noh como par
                if (quantidadeDeNumerosPar % 2 == 0)
                {
                    data.NohList[i].isEulerian = true;
                }

            }

            // Conta a quantidade de nohs par que grafo possui
            int numeroDePars = 0;

            for (int i = 0; i < numeroDeNohs; i++)
            {
                if (data.NohList[i].isEulerian)
                {
                    numeroDePars++;
                }
            }

            //numeroDePars--;

            if (numeroDePars == numeroDeNohs)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("O grafo é Euleriano");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (numeroDePars == (numeroDeNohs - 1) || numeroDePars == (numeroDeNohs - 2))
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("O grafo é Semi-Euleriano");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("O grafo é não Euleriano");
                Console.ForegroundColor = ConsoleColor.White;
            }

        }
    }
}
