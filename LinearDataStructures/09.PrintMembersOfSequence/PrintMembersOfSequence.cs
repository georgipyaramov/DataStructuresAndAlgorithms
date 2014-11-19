namespace PrintMembersOfSequence
{
    using System;
    using System.Collections.Generic;

    class PrintMembersOfSequence
    {
        static void Main()
        {
            int numN = int.Parse(Console.ReadLine());
            int numN2 = 0;
            int numN3 = 0;
            int numN4 = 0;
            var listOfInts = new Queue<int>();
            listOfInts.Enqueue(numN);

            for (int i = 1; i < 50; i++)
            {
                numN2 = numN + 1;
                numN3 = (2 * numN) + 1;
                numN4 = numN + 2;
                listOfInts.Enqueue(numN2);
                listOfInts.Enqueue(numN3);
                listOfInts.Enqueue(numN4);

                numN = numN2;
            }

            Console.WriteLine();

            for (int i = 0; i < 50; i++)
            {
                Console.Write(listOfInts.Dequeue() + ", ");
            }
        }
    }
}
