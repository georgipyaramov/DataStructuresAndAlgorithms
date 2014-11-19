namespace LongestSubsequence
{
    using System;
    using System.Collections.Generic;

    class LongestSubsequence
    {
        static IList<int> FindTheLongestSubsquence(IList<int> initialList)
        {
            var result = new List<int>();
            var currentCount = 1;
            var lastBiggestCount = 0;
            for (int i = 1; i < initialList.Count; i++)
            {
                if (initialList[i] == initialList[i - 1])
                {
                    currentCount++;
                    if (currentCount > lastBiggestCount)
                    {
                        result.Clear();
                        for (int j = 0; j < currentCount; j++)
                        {
                            result.Add(initialList[i - 1]);
                        }

                        lastBiggestCount = currentCount;
                        currentCount = 1;
                    }
                }
            }

            return result;
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

            var result = FindTheLongestSubsquence(listOfInts);
            for (int i = 0; i < result.Count; i++)
            {
                Console.WriteLine(result[i]);
            }
        }
    }
}