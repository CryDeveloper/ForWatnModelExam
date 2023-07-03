using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForWatnModelExam
{
    internal class NorthwestCorner
    {
        public static int[] NVector { get; set; }
        public static int[] MVector { get; set; }
        public static int[,] InputMatrix { get; set; }
        public static int[,] ExitMatrix { get; set; }
        public static int ValueFunction { get; set; }

        public static void ReadFile(string path)
        {
            Debug.WriteLine("Начало чтение файла.");
            string[] input = File.ReadAllLines(path);
            NVector = input[0].Trim().Split(' ').Select(n => int.Parse(n)).ToArray();
            MVector = input[1].Trim().Split(' ').Select(n => int.Parse(n)).ToArray();
            InputMatrix = new int[MVector.Length, NVector.Length];
            ExitMatrix = new int[MVector.Length, NVector.Length];
            for (int i = 0; i < InputMatrix.GetLength(0); i++)
            {
                int[] row = input[i+2].Trim().Split(' ').Select(n => int.Parse(n)).ToArray();
                for (int j = 0; j < InputMatrix.GetLength(1); j++)
                {
                    InputMatrix[i, j] = row[j];
                }
            }
            Debug.WriteLine("Файл прочитан.");
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
            Debug.WriteLine("Вывод матрицы на консоль.");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i,j]} ");
                }
                Console.WriteLine();
            }
        }

        public static bool HaveAnswer()
        {
            Debug.WriteLine("Проверка решаемости задачи.");
            if (MVector != null && NVector != null && MVector.Sum() == NVector.Sum())
            {
                return true;
            }
            return false;
        }

        public static void FindExitMatrix()
        {
            Debug.WriteLine("Поиск выходной матрицы.");

            for (int i = 0; i < InputMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < InputMatrix.GetLength(1); j++)
                {
                    if (NVector[j] > MVector[i])
                    {
                        NVector[j] -= MVector[i];
                        ExitMatrix[i, j] = MVector[i];
                        MVector[i] = 0;
                    }
                    else if (NVector[j] < MVector[i])
                    {
                        MVector[i] -= NVector[j];
                        ExitMatrix[i, j] = NVector[j];
                        NVector[j] = 0;
                    }
                    else
                    {
                        ExitMatrix[i, j] = MVector[i];
                        MVector[i] = 0;
                    }
                }
            }
        }

        public static void FindValueFunction()
        {
            Debug.WriteLine("Нахождение ЦФ.");
            for (int i = 0; i < InputMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < InputMatrix.GetLength(1); j++)
                {
                    ValueFunction += InputMatrix[i, j] * ExitMatrix[i, j];
                }
            }
        }

        public static void DoTask()
        {
            Debug.WriteLine("Начало решения задачи СЗ.");
            if (!HaveAnswer())
            {
                Debug.WriteLine("Задача не имеет решения.");
                Console.WriteLine("Суммы векторов не равны. Решения нет.");
                return;
            }
            FindExitMatrix();
            PrintMatrix(ExitMatrix);
            FindValueFunction();
            Console.WriteLine($"Значение ЦФ = {ValueFunction} у.е.");
        }
    }
}
