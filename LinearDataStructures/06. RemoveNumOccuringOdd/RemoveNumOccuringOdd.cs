namespace RemoveNumOccuringOdd
{
    using System;
    using System.Collections.Generic;

    class RemoveNumOccuringOdd
    {
        static void RemoveAllNumbersOccuringOddNumberOfTimes(IList<int> initialList)
        {
            var dict = new Dictionary<int, int>();
            
            for (int i = 0; i < initialList.Count; i++)
            {
                if (!dict.ContainsKey(initialList[i]))
                {
                    dict[initialList[i]] = 0;
                }
                dict[initialList[i]]++;
            }

            for (int i = 0; i < initialList.Count; i++)
            {
                if (dict[initialList[i]] % 2 != 0)
                {
                    initialList.RemoveAt(i);
                    i--;
                }
            }
        }

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

            RemoveAllNumbersOccuringOddNumberOfTimes(listOfInts);

            for (int i = 0; i < listOfInts.Count; i++)
            {
                Console.WriteLine(listOfInts[i]);
            }
        }
    }
}
