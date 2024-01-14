using System;
namespace ConsoleGame
{
    class Program
    {
        public static int[,] Field = new int[4,4];
        public static int Score = 0;
        public static bool EndGame = false;
        static void Main(string[] args)
        {
            Field[0,3] = 2;
            Field[0,2] = 0;
            Field[0,1] = 2;
            Field[0,0] = 2;
            Field[1, 3] = 0;
            Field[1, 2] = 2;
            Field[1, 1] = 2;
            Field[1, 0] = 2;
            Field[2, 0] = 0;
            Field[3, 2] = 2;
            Field[3, 0] = 2;
            OutputGameField();
            Console.ReadLine();
            UpSwap();   
            OutputGameField();
            

        }
        public static void OutputGameField()
        {
            for (int i = 0; i < Field.GetLength(0); i++)
            {
                for (int j = 0; j < Field.GetLength(1); j++)
                {
                    Console.Write(Field[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        public static void RightSwap()
        {
            for (int i = 0; i < 4; i++)
            {
                int[] row = new int[4];
                int index = 3;
                for (int j = 3; j >= 0; j--)
                {
                    if (Field[i, j] != 0)
                    {
                        row[index] = Field[i, j];
                        index--;
                    }
                }
                for (int j = 3; j > 0; j--)
                {
                    if (row[j] == row[j - 1])
                    {
                        row[j] *= 2;
                        for (int k = j - 1; k > 0; k--)
                        {
                            row[k] = row[k - 1];
                        }
                        row[0] = 0;
                    }
                }
                for (int j = 0; j < 4; j++)
                {
                    Field[i, j] = row[j];
                }
            }

        }
        public static void LeftSwap()
        {
            for (int i = 0; i < 4; i++)
            {
                int[] row = new int[4];
                int index = 0;
                for (int j = 0; j < 4; j++)
                {
                    if (Field[i, j] != 0)
                    {
                        row[index] = Field[i, j];
                        index++;
                    }
                }

                for (int j = 0; j < 3; j++)
                {
                    if (row[j] == row[j + 1])
                    {
                        row[j] *= 2;
                        for (int k = j + 1; k < 3; k++)
                        {
                            row[k] = row[k + 1];
                        }
                        row[3] = 0;
                    }
                }
                for (int j = 0; j < 4; j++)
                {
                    Field[i, j] = row[j];
                }
            }
        }
        public static void UpSwap()
        {
            for (int i = 0; i < 4; i++)
            {
                int[] column = new int[4];
                int index = 0;

                for (int j = 0; j < 4; j++)
                {
                    if (Field[j, i] != 0)
                    {
                        column[index] = Field[j, i];
                        index++;
                    }
                }

                for (int j = 0; j < 3; j++)
                {
                    if (column[j] == column[j + 1])
                    {
                        column[j] *= 2;
                        for (int k = j + 1; k < 3; k++)
                        {
                            column[k] = column[k + 1];
                        }
                        column[3] = 0;
                    }
                }

                for (int j = 0; j < 4; j++)
                {
                    Field[j, i] = column[j];
                }
            }
        }
        public static void DownSwap()
        {
            for (int i = 0; i < 4; i++)
            {
                int[] column = new int[4];
                int index = 3;

                for (int j = 3; j >= 0; j--)
                {
                    if (Field[j, i] != 0)
                    {
                        column[index] = Field[j, i];
                        index--;
                    }
                }

                for (int j = 3; j > 0; j--)
                {
                    if (column[j] == column[j - 1])
                    {
                        column[j] *= 2;
                        for (int k = j - 1; k > 0; k--)
                        {
                            column[k] = column[k - 1];
                        }
                        column[0] = 0;
                    }
                }

                for (int j = 0; j < 4; j++)
                {
                    Field[j, i] = column[j];
                }
            }
        }

    }
}