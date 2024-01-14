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
            Console.CursorVisible = false;
            RandomNewElements();
            RandomNewElements();
            while (EndGame == false)
            {
                Console.Clear();
                OutputGameField();
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                HandleInput(pressedKey);
            }
            Console.SetCursorPosition(0,5);
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("Game over!");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ReadKey();
        }
        public static void OutputGameField()
        {
            for (int i = 0; i < Field.GetLength(0); i++)
            {
                for (int j = 0; j < Field.GetLength(1); j++)
                {
                    if (Field[i, j] > 999)
                    {
                        Console.BackgroundColor = ConsoleColor.Red; Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(Field[i, j] + " ");
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else if (Field[i, j] > 540)
                    {
                        Console.BackgroundColor = ConsoleColor.Red; Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(Field[i, j] + "  ");
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else if (Field[i, j] > 99)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkYellow; Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(Field[i, j] + "  ");
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else if (Field[i, j] == 64)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkYellow; Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" " + Field[i, j] + "  ");
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else if (Field[i, j] > 9)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkMagenta; Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" " + Field[i, j] + "  ");
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else if (Field[i, j] == 8)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkMagenta; Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("  " + Field[i, j] + "  ");
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else if (Field[i, j] == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("  " + Field[i, j] + "  ");
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Gray; Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("  " + Field[i, j] + "  ");
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                }
                Console.WriteLine();
            }
            ShowScore();
        }
        static void ShowScore()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(24, 0);
            Console.BackgroundColor = ConsoleColor.Cyan; Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Score: " + Score);
            Console.BackgroundColor = ConsoleColor.Black;
        }
        static void HandleInput(ConsoleKeyInfo presedKey)
        {
            int[,] before = new int[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    before[i, j] = Field[i, j];
                }
            }
            int[,] after;
            if (presedKey.Key == ConsoleKey.UpArrow)
            {
                UpSwap();
            }
            else if (presedKey.Key == ConsoleKey.DownArrow)
            {
                DownSwap();
            }
            else if (presedKey.Key == ConsoleKey.LeftArrow)
            {
                LeftSwap();
            }
            else if (presedKey.Key == ConsoleKey.RightArrow)
            {
                RightSwap();
            }
            after = Field;
            if (IsSmthChanged(before, after))
            {
                RandomNewElements();
            }
            else
            {
                CheckStatus();
            }
        }
        static bool IsSmthChanged(int[,] matrixA, int[,] matrixB)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (matrixA[i, j] != matrixB[i, j])
                        return true;
                }
            }
            return false;
        }
        static void CheckStatus()
        {
            int check = 0;
            for (int i = 0; i < Field.GetLength(0); i++)
            {
                for (int j = 0; j < Field.GetLength(1); j++)
                {
                    if (j != 0 && Field[i, j - 1] == Field[i, j])
                    {
                        check++;
                        break;
                    }
                    //right
                    if (j != Field.GetLength(1) - 1 && Field[i, j + 1] == Field[i, j])
                    {
                        check++;
                        break;
                    }
                    //up
                    if (i != 0 && Field[i - 1, j] == Field[i, j])
                    {
                        check++;
                        break;
                    }
                    //down
                    if (i != Field.GetLength(0) - 1 && Field[i + 1, j] == Field[i, j])
                    {
                        check++;
                        break;
                    }

                }
            }
            if (check == 0) EndGame = true;
            else EndGame = false;
        }
        static void RandomNewElements()
        {
            Random rand = new Random();
            int counterOfEmpty = 0;
            int randomCell;
            int newCounterOfEmpty = 0;
            for (int i = 0; i < Field.GetLength(0); i++)
            {
                for (int j = 0; j < Field.GetLength(1); j++)
                {
                    if (Field[i, j] == 0)
                    {
                        counterOfEmpty++;
                    }
                }
            }
            if (counterOfEmpty == 0) CheckStatus();
            else
            {
                randomCell = rand.Next(0, counterOfEmpty + 1);
                for (int g = 0; g < Field.GetLength(0); g++)
                {
                    for (int h = 0; h < Field.GetLength(1); h++)
                    {
                        if (Field[g, h] == 0)
                        {
                            newCounterOfEmpty++;
                            if (newCounterOfEmpty == randomCell)
                            {
                                if (rand.Next(0, 10) == 9)
                                {
                                    Field[g, h] = 4;
                                }
                                else
                                {
                                    Field[g, h] = 2;
                                }
                            }
                        }
                    }
                }
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
                        Score += row[j];
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
                        Score += row[j];
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
                        Score += column[j];
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
                        Score += column[j];
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