using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForWatnModelExam
{
    internal class Djonson
    {
        public static List<List<int>> InputJonson { get; set; } = new List<List<int>>();
        public static int[,] ExitJonson { get; set; }

        public static void ReadFile(string path)
        {
            string[] input = File.ReadAllLines(path);
            foreach (var item in input)
            {
                InputJonson.Add(item.Trim().Split().Select(n => int.Parse(n)).ToList());
                ExitJonson = new int[2, InputJonson[0].Count];
            }
        }
        public static void WriteFile(string path)
        {
            using (StreamWriter w = new StreamWriter(path))
            {
                for (int i = 0; i < ExitJonson.GetLength(0); i++)
                {
                    for (int j = 0; j < ExitJonson.GetLength(1); j++)
                    {
                        w.Write($"{ExitJonson[i, j]} ");
                    }
                    w.WriteLine();
                }
            }
        }
        public static void PrintStanok(List<List<int>> stanok)
        {
            foreach (var item in InputJonson)
            {
                item.ForEach(x => Console.Write($"{x} "));
                Console.WriteLine();
            }
        }

        public static void DoTask()
        {
            PrintStanok(InputJonson);
            int top = 0;
            int bot = InputJonson[0].Count - 1;
            while (InputJonson[0].Count > 0)
            {
                int min = InputJonson.Select(x => x.Min()).Min();
                int idMin; 
                if (InputJonson[0].Contains(min))
                {
                    idMin = InputJonson[0].IndexOf(min);
                    ExitJonson[0, top] = InputJonson[0][idMin];
                    ExitJonson[1, top] = InputJonson[1][idMin];
                    InputJonson[0].RemoveAt(idMin);
                    InputJonson[1].RemoveAt(idMin);
                    top++;
                }
                else
                {
                    idMin = InputJonson[1].IndexOf(min);
                    ExitJonson[0, bot] = InputJonson[0][idMin];
                    ExitJonson[1, bot] = InputJonson[1][idMin];
                    InputJonson[0].RemoveAt(idMin);
                    InputJonson[1].RemoveAt(idMin);
                    bot--;
                }
                
            }
            for (int i = 0; i < ExitJonson.GetLength(0); i++)
            {
                for (int j = 0; j < ExitJonson.GetLength(1); j++)
                {
                    Console.Write($"{ExitJonson[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
