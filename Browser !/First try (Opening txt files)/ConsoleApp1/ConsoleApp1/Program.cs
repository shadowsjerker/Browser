﻿using System;
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
            }

            Console.WriteLine("Welcome to my app");
            Thread.Sleep(600);
            Console.WriteLine("ENJOY!!!!");
            Thread.Sleep(500);

            

            while(true)
            {
                Console.WriteLine("Choose website: \n1. GeeksForGeeks");
                Console.WriteLine("2. Other websites are in developing procces\n");
                string userInput = Console.ReadLine();
                
                if(userInput.Length > 1)
                {
                    continue;
                }

                switch (userInput)
                {
                    case "1":
                        SearchUtilities.GeeksForGeeks();
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Think again :|");
                        break;
                }
            }


            
        }
    }
}
