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
        //->쿼드트리 재귀함수 2021-07-09
        {
            int i, j = 0;
            int p = Quad_Array[a, b];
            bool flag = false;

            //->각각 영역을 n*n만큼 검사합니다.
            for (i = 0; i < n; ++i)
            {
                for (j = 0; j < n; ++j)
                {
                    if (p != Quad_Array[a + i, b + j])
                    //만약에 검사한 영역에 다른것이 있을경우
                    //게임에는 장애물 오브젝트가 해당 사각형 공간 내에서 컬링이 되었다고
                    //비유할 수 있다.
                    {
                        flag = true;
                        break;
                        //->플래그를 true로 바꾸고 break
                    }
                }

                if (j != n)
                //->만일 j가 n과 다르다고 판명이 날경우를 대비해
                //한번도 체크하여 flag를 true로 하고 break를 한다.
                {
                    flag = true;
                    break;
                }
            }
            if (flag == false)
            {
                Console.Write($"{p}");
                //만일 컬링된 Obj가 없을경우 해당 트리에 대해서 값만 출력
            }
            else
            {//아닐경우
                Console.Write("(");
                n = n / 2; //반으로 나누고
                           //->공간 분활
                QuadeTree(a, b, n);//1번 영역
                QuadeTree(a, b + n, n); //2번 영역
                QuadeTree(a + n, b, n); //3번 영역
                QuadeTree(a + n, b + n, n); //4번영역
                Console.Write(")");
            }
        }
    }
}
