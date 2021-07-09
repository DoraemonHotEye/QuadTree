using System;

namespace QuadTree
{
    class Program
    {
        static int[,] Quad_Array = new int[8, 8]
        {
            { 0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0 },
            { 0,0,0,0,1,1,1,1 },
            { 0,0,0,0,1,1,1,1 },
            { 0,0,0,1,1,1,1,1 },
            { 0,0,1,1,1,1,1,1 },
            { 0,0,1,1,1,1,1,1 },
            { 0,0,1,1,1,1,1,1 }
        };
        static void Main(string[] args)
        {
            PrintArrayQuade(Quad_Array);

            //쿼드트리
            QuadeTree(0, 0, 8);
        }

        public static void PrintArrayQuade(int[,] Quad_Array)
        {

            //쿼드트리 출력
            for (int i = 0; i < Quad_Array.GetLength(0); ++i)
            {
                for (int j = 0; j < Quad_Array.GetLength(1); ++j)
                {
                    Console.Write(Quad_Array[i, j]);
                }
                Console.WriteLine("");
            }
        }

        public static void QuadeTree(int a, int b, int n)
        {
            int i, j = 0;
            int p = Quad_Array[a, b];
            bool flag = false;

            for(i = 0; i < n; ++i)
            {
                for(j = 0; j < n; ++j)
                {
                    if(p != Quad_Array[a + i, b + j])
                    {
                        flag = true;
                        break;
                    }
                }

                if(j != n)
                {
                    flag = true;
                    break;
                }
            }
            if(flag == false)
            {
                Console.Write($"{p}");
            }
            else
            {
                Console.Write("(");
                n = n / 2;
                QuadeTree(a, b, n);
                QuadeTree(a, b + n, n);
                QuadeTree(a + n, b, n);
                QuadeTree(a + n, b + n, n);
                Console.Write(")");
            }
        }
    }
}
