using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class SearchUtilities
    {
        static public void w3Schools() 
        {
            // Load subfolders directories
            StreamReader firstLoad = new StreamReader("enter_Address_Here.txt");
            string loadAdd = firstLoad.ReadToEnd();
            var allFolders = Directory.GetDirectories(loadAdd);

            while (true)
            {

                List<string> keyWords = new List<string>() { };
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
                break;

                //Console.Write("\n\nLeave empty to continue, type '1' to end: ");
                //string loop = Console.ReadLine();

                //if (loop == "")
                //{
                //    continue;
                //}
                //else if (loop == "1")
                //{
                //    break;
                //}
                //else
                //{
                //    Thread.Sleep(1000);
                //    Console.WriteLine("\nReally !");
                //    Thread.Sleep(1000);
                //    Console.Write("Am I a joke to you");
                //    Thread.Sleep(800);
                //    Console.Write(" :|");
                //    for (int i = 0; i < 99; i++)
                //    {
                //        Thread.Sleep(100);
                //        Console.Write(" :|");
                //    }
                //    Thread.Sleep(5000);
                //    continue;
                //}
            }
        }

        static public void userInput(List<string> keyWords)
        {
            while (true)
            {
                Console.Write("Enter keyword (Leave empty to finnish): ");
                string var = Console.ReadLine();

                if (var == "")
                {
                    break;
                }
                keyWords.Add(var);
            }
        }

        static public void loadFileAndSearch(IEnumerable<string> b, List<string> keyWords, List<string> result)
        {
            foreach (var item2 in b)
            {
                List<bool> check = new List<bool>();
                bool checker = false;
                StreamReader temp = new StreamReader(item2);

                // Cutting the html code
                string a1 = temp.ReadToEnd();
                string a2 = a1;
                if (a1 == null || a1 == "")
                {
                    break;
                }
                else if (a1.Length < 40000)
                {
                    break;
                }
                int index1 = a2.IndexOf("post type-post status-publish format-standard hentry");
                int index2 = a2.IndexOf("saveUserPersonalNote()");
                if (index1 == -1 || index2 == -1)
                {
                    break;
                }

                string helper = a2.Substring(index1, index2 - index1).ToLower();


                foreach (var str in keyWords)
                {
                    if (item2.Contains(str))
                    {
                        checker = true;
                        break;
                    }
                    else if (helper.Contains(str))
                    {
                        //check.Add(true);
                        checker = true;
                    }
                    else
                    {
                        //check.Add(false);
                        checker = false;
                        break;
                    }
                }
                if (checker)
                {
                    result.Add(item2);
                }
            }

        }
    }
 }

