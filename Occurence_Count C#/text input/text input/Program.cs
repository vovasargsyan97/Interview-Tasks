using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using System.Linq;

namespace CountOccurrence
{
    class Program
    {
        static void Main(string[] args)
        {
            //setlocale(LC_ALL, "Russian");
            string text = System.IO.File.ReadAllText(@"C:\\Story.txt");                 
            string textToLower = text.ToLower();                                        
            Regex reg_exp = new Regex("[^а-я0-9]");                                     
            textToLower = reg_exp.Replace(textToLower, " ");                            
            string[] Value = textToLower.Split(new char[] { ' ' },
            StringSplitOptions.RemoveEmptyEntries);                                     // Split the string and remove the empty entries

            Dictionary<string, int> CountTheOccurrences = new Dictionary<string, int>(); // Create a dictionary to keep track of each occurrence of the words in the string
            for (int i = 0; i < Value.Length; i++)                                       // Loop the splited string  
            {
                if (CountTheOccurrences.ContainsKey(Value[i]))                           // Check if word is already in dictionary update the count  
                {
                    int value = CountTheOccurrences[Value[i]];
                    CountTheOccurrences[Value[i]] = value + 1;
                }
                else                                                  
                // If we found the same word we just increase the count in the dictionary 
                {
                    CountTheOccurrences.Add(Value[i], 1);
                }
            }
            CountTheOccurrences = CountTheOccurrences.OrderByDescending(x => x.Value).ToDictionary(x => x.Key,x => x.Value);
            //Console.WriteLine("The number of counts for each words are:");
            foreach (KeyValuePair<string, int> kvp in CountTheOccurrences)
            {  
                //Open the File
                StreamWriter sw = new StreamWriter("C:\\gago\\Occurence.txt", true, Encoding.UTF8);

           
                sw.Write(kvp.Key + "--" + kvp.Value + System.Environment.NewLine);

                //close the file
                sw.Close();
            }
            Console.ReadKey();
        }
    }
}