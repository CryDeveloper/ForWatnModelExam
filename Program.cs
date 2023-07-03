using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForWatnModelExam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
            //Debug.Listeners.Add(new TextWriterTraceListener("DebugText.txt"));
            Debug.AutoFlush = true;
            Debug.Indent();

            Debug.WriteLine("Вход в main.");
            //NorthwestCorner.ReadFile("Source/СЗ-вход.txt");
            //NorthwestCorner.PrintMatrix(NorthwestCorner.InputMatrix);
            //NorthwestCorner.DoTask();
            //NorthwestCorner.WriteAnswerInFile("Source/СЗ-выход.txt");

            //MinimalElementArr.ReadFile("Source/Мин-вход.txt");
            //MinimalElementArr.PrintMatrix(MinimalElementArr.InputMatrix);
            //MinimalElementArr.DoTask();
            //MinimalElementArr.WriteAnswerInFile("Source/Мин-выход.txt");

            //Prufer.ReadWoodFile("Source/Прюфера-вход.txt");
            //Prufer.CodeTask();
            //Prufer.WriteCodeInFile("Source/Прюфера-выход.txt");

            //Prufer.ReadCodeFile("Source/Прюфера-выход.txt");
            //Prufer.DeCodeTask();
            //Prufer.WriteWoodInFile("Source/Прюфера-вход.txt");

            Djonson.ReadFile("Source/Джносона-вход.txt");
            Djonson.DoTask();
            //Djonson.WriteFile("Source/Джносона-выход.txt");

            Debug.WriteLine("Конец.");
            Console.ReadKey();
        }
    }
}
