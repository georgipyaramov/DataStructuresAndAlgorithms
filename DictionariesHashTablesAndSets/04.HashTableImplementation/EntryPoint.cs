using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableImplementation
{
    class EntryPoint
    {
        static void Main()
        {
            var table = new HashTable<int, int>();

            for (int i = 0; i < 60; i++)
            {
                table.Add(i, i + 1);
                Console.WriteLine(i);
            }

            //Console.WriteLine();
        }
    }
}
