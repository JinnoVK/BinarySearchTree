using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BSTree<int> searchTree = new BSTree<int>();
            string buffer = "";
            searchTree.InsertItem(6);
            searchTree.InsertItem(7);
            searchTree.InsertItem(3);
            searchTree.InsertItem(9);
            searchTree.InOrder(ref buffer);
            Console.Write("The values: ");
            Console.WriteLine(buffer);
            Console.Write("The height of the tree: ");
            searchTree.height();
            searchTree.Count(ref buffer);
            Console.WriteLine(searchTree.Contains(6));
            searchTree.RemoveItem(7);
            buffer = "";
            searchTree.InOrder(ref buffer);
            Console.WriteLine(buffer);
            Console.ReadKey();
        }
    }
}
