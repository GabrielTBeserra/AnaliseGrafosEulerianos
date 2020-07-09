using ExameTeoria.data;
using ExameTeoria.entity;
using ExameTeoria.processing;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;

namespace ExameTeoria
{
    class Menu
    {
        private Data data;

        public Menu(Data data)
        {
            this.data = data;
            OpenMenu();
        }

        public void OpenMenu()
        {
            Console.Clear();
            Console.WriteLine("Menu");
            Console.WriteLine("");
            Console.WriteLine("1. Inserir matriz");
            Console.WriteLine("2. Gerar matriz aleatoria");
            Console.WriteLine("3. Ver matriz gerada/inserida");
            Console.WriteLine("4. Calcular grafo");
            Console.WriteLine("5. Ajuda");
            Console.WriteLine("9. SAIR");
            Console.WriteLine("");

            int Opcao = 0;

            // Verifica se a entrada de dados e um numero, caso nao retorna para o menu
            try
            {
                Opcao = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                OpenMenu();
            }


            switch (Opcao)
            {
                case 1:
                    InsertMatriz();
                    break;
                case 2:
                    GenerateMatriz();
                    break;
                case 3:
                    SeeMatriz();
                    break;
                case 4:
                    new Eulerian(data).Run();
                    Console.ReadKey();
                    OpenMenu();
                    break;
                case 5:
                    Help();
                    break;
                case 9:
                    Environment.Exit(0);
                    break;
                default:
                    OpenMenu();
                    break;
            }
        }

        private void InsertMatriz()
        {
            Console.Clear();
            Console.WriteLine("Insertir matriz");
            Console.WriteLine("Para inserir use numeros para representar a existencia de aresta");
            Console.WriteLine("E letras para representar que nao ha uma aresta");
            Console.WriteLine("");
            Console.WriteLine();
            Console.Write("Informe a quantidade de nos: ");

            String matrizSize = Console.ReadLine();
            Console.WriteLine();
            int size = 0;

            // Verifica que o que foi informado e um numero
            if (Information.IsNumeric(matrizSize))
            {
                size = int.Parse(matrizSize);
                data.StartMatriz(size);
            }
            else
            {
                Console.WriteLine("Tente novamente!");
                Console.ReadKey();
                OpenMenu();
            }
            
            // Cria uma lista de nos
            List<Noh> nohs = new List<Noh>();

            for (int i = 0; i < size; i++)
            {
                nohs.Add(new Noh());

                for (int y = 0; y < size; y++)
                {
                    if (i != y)
                    {
                        Console.Write($"Informe se possui aresta entra os pontos [{i},{y}]: ");
                        int value = int.Parse(Console.ReadLine());
                        // Marca o noh atual com o valor desejado e a outra ponta da aresta tambem com ligacao
                        data.MatrizNoh[i, y] = value;
                        data.MatrizNoh[y, i] = value;
                    }
                    else
                    {
                        data.MatrizNoh[i, y] = -1;
                    }

                }
            }

            data.StartNohList(nohs);

            OpenMenu();
        }

        private void GenerateMatriz()
        {
            Console.WriteLine();
            Console.Write("Informe a quantidade de nos: ");

            String matrizSize = Console.ReadLine();
            Console.WriteLine();
            int size = 0;

            // Verifica se o que foi informado e um nume
            if (Information.IsNumeric(matrizSize))
            {
                size = int.Parse(matrizSize);
                data.StartMatriz(size);
            }
            else
            {
                Console.WriteLine("Tente novamente!");
                Console.ReadKey();
                OpenMenu();
            }



            List<Noh> nohs = new List<Noh>();



            for (int i = 0; i < size; i++)
            {
                nohs.Add(new Noh());
                for (int y = 0; y < size; y++)
                {
                    // Sorteia um numero entre 0 e 10
                    Random rnd = new Random();
                    int rand = rnd.Next(0, 10);
                    
                    // Para evitar de marcar o proprio no como aresta, e ignorado e marcado como sem aresta
                    if (y != i)
                    {
                        // Caso o numero sorteado seja menor que 5 nao possui aresta
                        // Caso nao, ele marca como aresta
                        if (rand < 5)
                        {
                            data.MatrizNoh[i, y] = -1;
                            data.MatrizNoh[y, i] = -1;
                        }
                        else
                        {
                            data.MatrizNoh[i, y] = 1;
                            data.MatrizNoh[y, i] = 1;
                        }
                    }
                    else
                    {
                        data.MatrizNoh[i, y] = -1;
                    }

                }
            }

            data.StartNohList(nohs);

            OpenMenu();
        }

        private void SeeMatriz()
        {
            // Opcao para vizualizar a matriz inserida ou gerada
            if (data.MatrizNoh == null || data.NohList == null)
            {
                Console.WriteLine("Voce deve primeiro informar a matriz para calcular!");
                return;
            }
            int size = (int)Math.Sqrt(data.MatrizNoh.Length);

            for (int i = 0; i < size; i++)
            {
                for (int y = 0; y < size; y++)
                {
                    Console.Write(String.Format("{0,12:0}", data.MatrizNoh[i, y]));
                }
                Console.WriteLine("");
            }

            Console.ReadKey();
            OpenMenu();
        }

        private void Help()
        {
            Console.Clear();
            Console.WriteLine("*********************");
            Console.WriteLine("--      AJUDA      --\n\n");
            Console.WriteLine("1. A opcao de inserir matriz, use numeros positivos para informar a existencia de aresta");
            Console.WriteLine("e qualquer numero negativo para informar a nao existencia de aresta\n");
            Console.WriteLine("2. A opcao gera um grafo totalmente aleatorio para que possa ser feito o teste\n");
            Console.WriteLine("3. O opcao onde voce pode3 vizualizar a matriz inserida ou gerada\n");
            Console.WriteLine("4. Opcao onde e feito o calculo do grafo ou inserido ou gerado aleatoriamente\n");
            Console.WriteLine("Para evitar que as insercoes seja inseridas de forma incorreta, caso estiver");
            Console.WriteLine("inserindo na posicao [1,2] a posicao [2,1] tambem sera alterada para que");
            Console.WriteLine("uma aresta nao seja ligada em um no e ao contrario nao");
            Console.ReadKey();
            OpenMenu();
        }
    }
}