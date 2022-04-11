using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> ll = new LinkedList<int>();
            ll.AddLast(1);
            ll.AddLast(2);
            ll.AddLast(3);
            ll.AddLast(4);
            ll.AddLast(5);
            ll.AddLast(6);
            ll.AddLast(7);
            ll.AddLast(8);

            foreach (var item in ll)
            {
                Console.Write(item + "->");
            }
            Console.WriteLine();
            ll.Remove(8);
            foreach (var item in ll)
            {
                Console.Write(item + "->");
            }
            Console.ReadKey();
        }
    }
}


