using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ForWatnModelExam
{
    internal class Prufer
    {
        public static List<List<int>> Wood { get; set; } = new List<List<int>>();

        public static List<int> Code { get; set; } = new List<int>();

        public static void ReadWoodFile(string path)
        {
            string[] input = File.ReadAllLines(path);
            foreach (var item in input)
            {
                Wood.Add(item.Trim().Split().Select(n => int.Parse(n)).ToList());
            }
        }
        public static void ReadCodeFile(string path)
        {
            string[] input = File.ReadAllLines(path);
            Code = (input[0].Trim().Split().Select(n => int.Parse(n)).ToList());

        }

        public static void WriteCodeInFile(string path) 
        { 
            using (StreamWriter w = new StreamWriter(path))
            {
                foreach (var item in Code)
                {
                    w.Write($"{item} ");
                }
            }
        }
        public static void WriteWoodInFile(string path) 
        { 
            using (StreamWriter w = new StreamWriter(path))
            {
                foreach (var item in Wood)
                {
                    item.ForEach(x => w.Write($"{x} "));
                    w.WriteLine();
                }
            }
        }

        public static void PrintWood()
        {
            Console.WriteLine("Дерево:");
            foreach (var item in Wood)
            {
                item.ForEach(Console.Write);
                Console.WriteLine();
            }
        }

        public static void PrintCode()
        {
            Console.WriteLine("Код прюфера:");
            Code.ForEach(Console.Write);
            Console.WriteLine();
        }

        public static void CodeTask()
        {
            PrintWood();
            do
            {
                int placeMinLeaf = Wood[1].IndexOf(Wood[1].Except(Wood[0]).Min());
                Code.Add(Wood[0][placeMinLeaf]);
                Wood[0].RemoveAt(placeMinLeaf);
                Wood[1].RemoveAt(placeMinLeaf);
            } while (Wood[0].Count > 1);
            PrintCode();
        }

        public static void DeCodeTask()
        {
            PrintCode();
            //создание свободных листьев
            List<int> freeLeaf = new List<int>();
            for (int i = 0; i < Code.Count + 2; i++)
            {
                freeLeaf.Add(i + 1);
            }
            Wood.Add(new List<int>());
            Wood.Add(new List<int>());
            while (Code.Count > 0)
            {
                Wood[0].Add(Code[0]);
                Wood[1].Add(freeLeaf.Except(Code).Min());
                freeLeaf.Remove(freeLeaf.Except(Code).Min());
                Code.RemoveAt(0);
            } 
            PrintWood();

        }
    }
}
