using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class SearchUtilities
    {
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

