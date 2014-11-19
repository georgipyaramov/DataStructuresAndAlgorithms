//Implement the data structure linked list. Define a class ListItem<T> that has two fields: value (of type T) and NextItem (of type ListItem<T>). Define additionally a class LinkedList<T> with a single field FirstElement (of type ListItem<T>).

namespace LinkedList
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TestLinkedList
    {
        public static void Main ()
        {
            DateTime start = DateTime.Now;
            var myList = new LinkedList<int>();

            myList.AddFirst(5);
            myList.AddLast(3);

            myList.AddFirst(4);
            myList.AddLast(9);

            myList.AddBefore(myList.LastItem, 15);
            myList.AddAfter(myList.FirstItem, 24);
            //As per conventions of quality code, return the removed item.
            Console.WriteLine(myList.RemoveLast());
            Console.WriteLine(myList.RemoveFirst());

            for (int i = 0; i < 2000000; i++)
            {
                myList.AddFirst(i);
                myList.AddLast(i);
            }

            TimeSpan end = DateTime.Now - start;

            Console.WriteLine(myList.Count);
            Console.WriteLine(end);
        }
    }
}
