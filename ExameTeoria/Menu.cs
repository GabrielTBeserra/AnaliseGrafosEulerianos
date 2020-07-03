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
            Console.WriteLine("Informe o tamanho da matriz");

            String matrizSize = Console.ReadLine();
            int size = 0;

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
            char[] alfabeto = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("Informe o nome do ponto");

                nohs.Add(new Noh($"{alfabeto[i]}"));

                for (int y = 0; y < size; y++)
                {
                    if (i != y)
                    {
                        Console.Write($"Informe o vertice do ponto [{i},{y}]: ");
                        int value = int.Parse(Console.ReadLine());
                        data.MatrizNoh[i, y] = value;
                        data.MatrizNoh[y, i] = value;
                    } else
                    {
                        data.MatrizNoh[i, y] = 0;
                    }
                    
                }
            }

            data.StartNohList(nohs);



            OpenMenu();
        }

        private void GenerateMatriz()
        {
            Console.WriteLine("Informe o tamanho da matriz");



            String matrizSize = Console.ReadLine();
            int size = 0;

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
            char[] alfabeto = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();


            for (int i = 0; i < size; i++)
            {
                nohs.Add(new Noh($"{alfabeto[i]}"));
                for (int y = 0; y < size; y++)
                {
                    Random rnd = new Random();
                    int rand = rnd.Next(0, 10);

                    if (y != i)
                    {
                        if (rand < 5)
                        {
                            data.MatrizNoh[i, y] = 0;
                            data.MatrizNoh[y, i] = 0;
                        }
                        else
                        {
                            Random random = new Random();
                            int randIn = rnd.Next(0, int.MaxValue);
                            data.MatrizNoh[i, y] = 1;
                            data.MatrizNoh[y, i] = 1;
                        }
                    } else
                    {
                        data.MatrizNoh[i, y] = 0;
                    }

                }
            }

            data.StartNohList(nohs);

            OpenMenu();
        }

        private void SeeMatriz()
        {
            int size = (int)Math.Sqrt(data.MatrizNoh.Length);

            for (int i = 0; i < size; i++)
            {
                for (int y = 0; y < size; y++)
                {
                    Console.Write(String.Format("{0,12:0,000.00}", data.MatrizNoh[i, y]));
                }
                Console.WriteLine("");
            }

            OpenMenu();
        }

        private void Help()
        {
            Console.WriteLine("*********************");
            Console.WriteLine("--      AJUDA      --");
            Console.WriteLine("1. A opacao de inserir matriz, use 1 Para informar a existencia de vertice");
            Console.WriteLine("e 0 para informar a nao existencia de vertice");
        }
    }
}
