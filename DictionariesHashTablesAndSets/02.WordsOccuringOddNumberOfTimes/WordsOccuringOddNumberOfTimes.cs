//Write a program that extracts from a given sequence of strings all elements that present in it odd number of times. 
//Example: {C#, SQL, PHP, PHP, SQL, SQL }  {C#, SQL}
namespace WordsOccuringOddNumberOfTimes
{
    using System;
    using System.Collections.Generic;

    public class WordsOccuringOddNumberOfTimes
    {
        static void Main()
        {
            var testStringArray = new string[] { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };
            var dictionary = new Dictionary<string, int>();

            foreach (var testString in testStringArray)
            {
                if (!dictionary.ContainsKey(testString))
                {
                    dictionary[testString] = 0;
                }
                dictionary[testString]++;
            }

            Console.WriteLine("The words that occure odd number of times in the sequence are:");
            foreach (var entry in dictionary)
            {
                if (entry.Value % 2 != 0)
                {
                    Console.WriteLine(entry.Key);
                }
            }            
        }
    }
}