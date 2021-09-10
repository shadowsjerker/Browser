using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Process firstProc = new Process();
            //firstProc.StartInfo.FileName = "enter_Address_Here.txt";
            //firstProc.EnableRaisingEvents = true;

            //firstProc.Start();

            //firstProc.WaitForExit();
            //Console.WriteLine(firstProc.ExitCode);

            /*var arraY = Directory.EnumerateFiles("E:/Programming/C#/Visual Studio/Projs/Browser !/First try (Opening txt files)/ConsoleApp1/ConsoleApp1/files/", "*.html");
            var ARRAY = Directory.EnumerateFiles("E:/others/Website Downloads Main/GeeksForGeeks/geeks for geeks/www.geeksforgeeks.org", "*.html");
            */

            // Load subfolders directories
            StreamReader firstLoad = new StreamReader("enter_Address_Here.txt");
            string loadAdd = firstLoad.ReadToEnd();
            var allFolders = Directory.GetDirectories(loadAdd);

            while(true)
            {
                Console.Clear();

                List<string> keyWords = new List<string>() {  };
                List<string> result = new List<string>() { };

                // Getting key words from user
                SearchUtilities.userInput(keyWords);


                for (int j = 0; j < allFolders.Length; j++)
                {
                    var b = Directory.EnumerateFiles(allFolders[j], "*.html", SearchOption.AllDirectories);

                    double ass = allFolders.Length;
                    double mean = (j / ass) * 100;
                    int importantCast = Convert.ToInt32(mean);
                    Console.WriteLine(String.Format("{0:0.##}", mean) + " %");
                    Console.SetCursorPosition(0, Console.CursorTop - 1);

                    // Loading each file and doing the search
                    SearchUtilities.loadFileAndSearch(b, keyWords, result);
                }
                

                using (StreamWriter temp = new StreamWriter("result.txt"))
                {
                    foreach (var item in result)
                    {
                        temp.WriteLine(item);
                    }

                }

                Process firstProc = new Process();
                firstProc.StartInfo.FileName = "result.txt";
                firstProc.EnableRaisingEvents = true;

                firstProc.Start();

                firstProc.WaitForExit();
                Console.WriteLine(firstProc.ExitCode);

                Console.Write("\n\nLeave empty to continue, type '1' to end: ");
                string loop = Console.ReadLine();

                if(loop == "")
                {
                    continue;
                }
                else if(loop == "1")
                {
                    break;
                }
                else
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("\nReally !");
                    Thread.Sleep(1000);
                    Console.Write("Am I a joke to you");
                    Thread.Sleep(800);
                    Console.Write(" :|");
                    for (int i = 0; i < 99; i++)
                    {
                        Thread.Sleep(100);
                        Console.Write(" :|");
                    }
                    Thread.Sleep(5000);
                    continue;
                }
            }
        }
    }
}
