namespace RemoveNegativeNums
{
    using System;
    using System.Collections.Generic;

    class RemoveNegativeNums
    {
        static void RemoveAllNegativeNumbers(IList<int> initialList)
        {
            for (int i = 0; i < initialList.Count; i++)
            {
                if (initialList[i] < 0)
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

            RemoveAllNegativeNumbers(listOfInts);

            for (int i = 0; i < listOfInts.Count; i++)
            {
                Console.WriteLine(listOfInts[i]);
            }
        }
    }
}
