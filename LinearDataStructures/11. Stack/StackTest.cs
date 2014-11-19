namespace Stack
{
    using System;

    public class StackTest
    {
        public static void Main ()
        {
            Stack<int> myStack = new Stack<int>();

            for (int i = 0; i < 20000000; i++)
            {
                myStack.Push(i);
            }

            Console.WriteLine(myStack.Peek());
            Console.WriteLine(myStack.Count);
            Console.WriteLine(myStack.Pop());
            Console.WriteLine(myStack.Count);
            Console.WriteLine(myStack.Length);
            myStack.TrimExcess();
            Console.WriteLine(myStack.Length);
            Console.WriteLine(myStack.Contains(1800000));
            myStack.Clear();
            Console.WriteLine(myStack.Count);
        }
    }
}
