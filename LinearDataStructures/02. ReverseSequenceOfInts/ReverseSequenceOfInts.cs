namespace ReverseSequenceOfInts
{
    using System;
    using System.Collections.Generic;

    class ReverseSequenceOfInts
    {
        static void Main()
        {
            string input = Console.ReadLine();
            int inputNumber;
            var listOfInts = new Stack<int>();
            while (!(string.IsNullOrEmpty(input)))
            {
                inputNumber = int.Parse(input);
                listOfInts.Push(inputNumber);
                input = Console.ReadLine();
            }

            Console.WriteLine();

            while (listOfInts.Count > 0)
            {
                Console.WriteLine(listOfInts.Pop());
            }
        }
    }
}
