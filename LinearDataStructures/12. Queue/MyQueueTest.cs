namespace Queue
{
    using System;

    public class MyQueueTest
    {
        public static void Main ()
        {
            LinkedQueue<int> myQueue = new LinkedQueue<int>();

            myQueue.Enqueue(5);
            Console.WriteLine(myQueue.Dequeue());
            for (int i = 0; i < 2000000; i++)
            {
                myQueue.Enqueue(i);
            }

            Console.WriteLine(myQueue.Count);
            Console.WriteLine(myQueue.Peek());
            Console.WriteLine(myQueue.Count);
            Console.WriteLine(myQueue.Contains(1000000));
            myQueue.Clear();
            Console.WriteLine(myQueue.Count);
        }
    }
}
