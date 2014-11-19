namespace CalcSumAndAverage
{
    using System;
    using System.Collections.Generic;

    class CalcSumAndAverage
    {
        static void Main()
        {
            string input = Console.ReadLine();
            int inputNumber;
            int sum = 0;
            int average = 0;
            var listOfInts = new List<int>();
            while (!(string.IsNullOrEmpty(input)))
            {                
                inputNumber = int.Parse(input);
                sum += inputNumber;
                listOfInts.Add(inputNumber);
                input = Console.ReadLine();
            }

            average = sum / listOfInts.Count;

            Console.WriteLine("The sum of the numbers is: " + sum);
            Console.WriteLine("The average of the numbers is: " + average);
        }
    }
}
