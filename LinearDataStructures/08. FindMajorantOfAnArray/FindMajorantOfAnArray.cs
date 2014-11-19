namespace FindMajorantOfAnArray
{
    using System;
    using System.Collections.Generic;

    class FindMajorantOfAnArray
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

            var dict = new Dictionary<int, int>();

            for (int i = 0; i < listOfInts.Count; i++)
            {
                if (!dict.ContainsKey(listOfInts[i]))
                {
                    dict[listOfInts[i]] = 0;
                }
                dict[listOfInts[i]]++;
            }

            foreach (var item in dict)
            {
                if (item.Value >= (listOfInts.Count / 2) + 1)
                {
                    Console.WriteLine("The majorant of the array is: {0}", item.Key);
                }
                
            }
        }
    }
}
