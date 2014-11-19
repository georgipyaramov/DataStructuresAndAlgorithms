//Write a program that counts in a given array of double values the number of occurrences of each value. 
//Use Dictionary<TKey,TValue>.
//Example: array = {3, 4, 4, -2.5, 3, 3, 4, 3, -2.5}
//-2.5  2 times
//3  4 times
//4  3 times
namespace OccurrencesOfValue
{
    using System;
    using System.Collections.Generic;

    public class OccurrencesOfValue
    {
        static void Main()
        {
            var testArray = new double[] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };

            var dictionary = new Dictionary<double, int>();

            foreach (var number in testArray)
            {
                if (!dictionary.ContainsKey(number))
                {
                    dictionary[number] = 0;
                }
                dictionary[number]++;
            }

            foreach (var entry in dictionary)
            {
                Console.WriteLine("The number {0} occures {1} times in the array", entry.Key, entry.Value);
            }
        }
    }
}