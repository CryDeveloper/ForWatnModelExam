using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForWatnModelExam
{
    internal class MinimalElement
    {
        public static List<int> NVector { get; set; }
        public static List<int> MVector { get; set; }
        public static List<List<int>> InputMatrix { get; set; }
        public static List<List<int>> ExitMatrix { get; set; }
        public static int ValueFunction { get; set; }

        public static void ReadFile(string path)
        {
            string[] input = File.ReadAllLines(path);
            NVector = input[0].Trim().Split().Select(n => int.Parse(n)).ToList();
            MVector = input[1].Trim().Split().Select(n => int.Parse(n)).ToList();
            for (int i = 2; i < input.Length; i++)
            {
                InputMatrix.Add(input[i].Trim().Split().Select(n => int.Parse(n)).ToList());
                ExitMatrix.Add(new List<int>());
            }
        }

        public static void PrintMatrix(List<List<int>> matrix)
        {
            foreach (var row in matrix)
            {
                foreach (var item in row)
                {
                    Console.Write($"{item} ");
                }
                Console.WriteLine();
            }
        }

        public static void DoTask()
        {
            if (!HaveAnswer())
            {
                Console.WriteLine("Суммы векторов не равны. Решения нет.");
                return;
            }
            FindExitMatix();
            PrintMatrix(ExitMatrix);
        }

        public static bool HaveAnswer()
        {
            if (NVector != null && MVector != null && NVector.Sum() == MVector.Sum())
            {
                return true;
            }
            return false;
        }

        public static void FindExitMatix()
        {
            while (NVector.Sum() != 0 && MVector.Sum() != 0)
            {
                var a = InputMatrix.Select(x => x.Min()).Min();
            }
        }

        public static void FindValueFunction()
        {
            for (int i = 0; i < InputMatrix.Count; i++)
            {
                for (int j = 0; j < InputMatrix[i].Count; j++)
                {
                    ValueFunction += InputMatrix[i][j] * ExitMatrix[i][j];
                }
            }
        }

    }
}
