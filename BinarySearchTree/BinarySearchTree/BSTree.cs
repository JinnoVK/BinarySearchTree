using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    class BSTree<T> : BinaryTree<T> where T : IComparable
    {  
        public BSTree()
        {
            root = null;
        }

        public void height()
        {
            Console.WriteLine(Height(ref root));
        }

        private int Height(ref Node<T> tree)
        {

            if (tree == null)
            {
                return -1;
            }
            int leftHeight = Height(ref tree.Left);
            int rightHeight = Height(ref tree.Right);

            if (leftHeight > rightHeight)
            {
                return leftHeight + 1;
            }
            else
            {
                return rightHeight + 1;
            }
        }




        public void Count(ref string buffer)
        //Return the number of nodes in the tree
        {
            Console.WriteLine(countF(ref root, ref buffer));
        }

        public int count;
        private int countF(ref Node<T> tree, ref string buffer)
        {
            inOrder(tree, ref buffer);
            return count;
        }



        private void inOrder(Node<T> tree, ref string buffer)
        {
            if (tree != null)
            {

                inOrder(tree.Left, ref buffer);
                buffer += tree.Data.ToString() + ",";
                count++;
                inOrder(tree.Right, ref buffer);
            }
        }

        public Boolean Contains(T item)
        {
            Node<T> node = root;
            return contains(root, item);
        }



        private Boolean contains(Node<T> node, T item)
        {
            if (item.CompareTo(root.Data) == 0)
            {
                return true;
            }
            else
            {
                if (item.CompareTo(root.Data) > 0)
                {

                    Node<T> left = root.Left;
                    return (contains(root, item));
                }
                else
                {
                    if (item.CompareTo(root.Data) < 0)
                    {

                        Node<T> right = root.Right;
                        return (contains(root, item));
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }


        private void insertItem(T item, ref Node<T> tree)
        {
            if (tree == null)
                tree = new Node<T>(item);

            else if (item.CompareTo(tree.Data) < 0)
                insertItem(item, ref tree.Left);

            else if (item.CompareTo(tree.Data) > 0)
                insertItem(item, ref tree.Right);
        }


        public void InsertItem(T item)
        {
            insertItem(item, ref root);
        }

        public void RemoveItem(T item)
        {
            removeItem(ref root, item);
        }

        private bool removeItem(ref Node<T> tree, T item)
        {
            if (tree == null) { return false; }
            if (tree.Data.CompareTo(item) == 0)
            {
                if (tree.Right == null && tree.Left == null)
                {
                    tree = null;
                }
                else if (tree.Right == null)
                {
                    tree = tree.Left;
                }
                else if (tree.Left == null)
                {

                    tree = tree.Right;
                }
                else
                {
                    tree.Data = returnRemoveLastLeft(ref tree.Right);
                }
                return true;
            }
            else
            {
                if (removeItem(ref tree.Left, item))
                {
                    return true;
                }
                else if (removeItem(ref tree.Right, item))
                {
                    return true;
                }

            }

            return false;
        }

        private T returnRemoveLastLeft(ref Node<T> tree)
        {
            while (tree.Left != null)
            {
                tree = tree.Left;
            }
            T returnItem = tree.Data;
            tree = null;
            return returnItem;
        }

    }
}
