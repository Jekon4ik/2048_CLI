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
            Field[0,2] = 2;
            Field[0,1] = 0;
            Field[0,0] = 0;
            Field[1, 3] = 2;
            Field[1, 2] = 2;
            Field[1, 1] = 2;
            Field[1, 0] = 2;
            OutputGameField();
            Console.ReadLine();
            LeftSwap();   
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
           for(int k =0; k < 3; k++)
           {
                for (int i = Field.GetLength(0) - 1; i >= 0; i--)
                {
                    for (int j = Field.GetLength(1) - 1; j > 0; j--)
                    {
                        if (Field[i, j] == Field[i, j - 1])
                        {
                            Field[i, j] = Field[i, j] + Field[i, j - 1];
                            Field[i, j - 1] = 0;
                        }

                    }
                }
           }
           for(int i = 0; i< Field.GetLength(0); i++)
            {
                for (int j =1; j < Field.GetLength(1); j++)
                {
                    if (Field[i,j-1] != 0)
                    {
                        if (Field[i, j] == 0)
                        {
                            Field[i, j] = Field[i, j - 1];
                            Field[i, j - 1] = 0;
                        }
                    }
                }
            }
          
        }
        public static void LeftSwap()
        {
            for (int k = 0; k < 3; k++)
            {
                for (int i = 0; i < Field.GetLength(0); i++)
                {
                    for (int j = 0; j <Field.GetLength(1)-1; j++)
                    {
                        //Console.WriteLine($"i = {i} j = {j}");
                        if (Field[i, j] == Field[i, j + 1])
                        {
                            Field[i, j] = Field[i, j] + Field[i, j + 1];
                            Field[i, j + 1] = 0;
                        }

                    }
                }
                //Console.WriteLine("gey");
            }
            for (int i = Field.GetLength(0)-1; i >= 0; i--)
            {
                for (int j = Field.GetLength(1)-2; j >=0; j--)
                {
                    Console.WriteLine($"i = {i} j = {j}");
                    if (Field[i, j + 1] != 0)
                    {
                        if (Field[i, j] == 0)
                        {
                            Field[i, j] = Field[i, j + 1];
                            Field[i, j + 1] = 0;
                        }
                    }
                }
            }
        }
        public void UpSwap()
        {

        }
        public void DownSwap()
        {

        }

    }
}