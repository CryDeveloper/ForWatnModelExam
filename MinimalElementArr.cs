using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForWatnModelExam
{
    internal class MinimalElementArr
    {
        //for (int i = 0; i<InputMatrix.GetLength(0); i++)
        //    {
        //        for (int j = 0; j<InputMatrix.GetLength(1); j++)
        //        {

        //        }
        //    }

        public static int[] NVector { get; set; }
        public static int[] MVector { get; set; }
        public static int[,] InputMatrix { get; set; }
        public static int[,] ExitMatrix { get; set; }
        public static int ValueFunction { get; set; }

        public static void ReadFile(string path)
        {
            string[] input = File.ReadAllLines(path);
            NVector = input[0].Trim().Split().Select(n => int.Parse(n)).ToArray();
            MVector = input[1].Trim().Split().Select(n => int.Parse(n)).ToArray();
            InputMatrix = new int[MVector.Length, NVector.Length];
            ExitMatrix = new int[MVector.Length, NVector.Length];
            for (int i = 0; i < InputMatrix.GetLength(0); i++)
            {
                int[] row = input[i+2].Trim().Split().Select(n => int.Parse(n)).ToArray();
                for (int j = 0; j < InputMatrix.GetLength(1); j++)
                {
                    InputMatrix[i, j] = row[j];
                }
            }
        }

        public static void WriteAnswerInFile(string path)
        {
            using (StreamWriter w = new StreamWriter(path))
            {
                w.WriteLine(ValueFunction);
                for (int i = 0; i < ExitMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < ExitMatrix.GetLength(1); j++)
                    {
                        w.Write($"{ExitMatrix[i, j]} ");
                    }
                    w.WriteLine();
                }
            }
        }

        public static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        public static void DoTask()
        {
            if(!HaveAnswer())
            {
                Console.WriteLine("Суммы векторов не равны. Решения нет.");
                return;
            }
            FindExitMatix();
            PrintMatrix(ExitMatrix);
            FindValueFunction();
            Console.WriteLine(ValueFunction);
        }

        public static bool HaveAnswer()
        {
            if(NVector != null && MVector != null && NVector.Sum() == MVector.Sum())
            {
                return true;
            }
            return false;

        }

        public static int FindMaximum(int[,] matrix)
        {
            int max = 0;
            foreach (int item in matrix)
            {
                if (max < item)
                {
                    max = item;
                }
            }
            return max;
        }

        public static void FindExitMatix()
        {
            int max = 0;
            int maxRow = 0;
            int maxColumn = 0;
            for (int i = 0; i < InputMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < InputMatrix.GetLength(1); j++)
                {
                    max = InputMatrix[i, j];
                    maxRow = i;
                    maxColumn = j;
                }
            }
            //штука выше нужна чтобы избежать проблемы с зависанием цикла
            while (NVector.Sum() != 0 && MVector.Sum() != 0)
            {
                int min = max;
                int minRow = maxRow;
                int minColumn = maxColumn;
                //определение минимума
                for (int i = 0; i < InputMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < InputMatrix.GetLength(1); j++)
                    {
                        //условие для минимума
                        if (min > InputMatrix[i,j] && NVector[j] != 0 && MVector[i] != 0)
                        {
                            min = InputMatrix[i, j];
                            minRow = i;
                            minColumn = j;
                        }
                    }
                }
                //Debug.WriteLine("Найден минимум. {0} {1} {2}", min, minRow, minColumn);
                if (MVector[minRow] < NVector[minColumn])
                {
                    NVector[minColumn] -= MVector[minRow];
                    ExitMatrix[minRow, minColumn] = MVector[minRow];
                    MVector[minRow] = 0;
                }
                else if(MVector[minRow] > NVector[minColumn])
                {
                    MVector[minRow] -= NVector[minColumn];
                    ExitMatrix[minRow, minColumn] = NVector[minColumn];
                    NVector[minColumn] = 0;
                }
                else
                {
                    ExitMatrix[minRow, minColumn] = NVector[minColumn];
                    MVector[minRow] = 0;
                    NVector[minColumn] = 0;
                }
                //PrintMatrix(ExitMatrix);
            }
        }

        public static void FindValueFunction()
        {
            for (int i = 0; i < InputMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < InputMatrix.GetLength(1); j++)
                {
                    ValueFunction += InputMatrix[i, j] * ExitMatrix[i, j];
                }
            }
        }
    }
}
