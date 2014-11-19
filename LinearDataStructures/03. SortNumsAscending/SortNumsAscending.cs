namespace SortNumsAscending
{
    using System;
    using System.Collections.Generic;

    class SortNumsAscending
    {
        static void Main()
        {
            string input = Console.ReadLine();
            int inputNumber;
            var listOfInts = new List<int>();
            while (!(string.IsNullOrEmpty(input)))
            {
                inputNumber = int.Parse(input);
                listOfInts.Add(inputNumber);
                input = Console.ReadLine();
            }
            listOfInts.Sort();

            for (int i = 0; i < listOfInts.Count; i++)
            {
                Console.WriteLine(listOfInts[i]);
            }
        }
    }
}
