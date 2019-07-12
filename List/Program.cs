using System;
using System.Collections;
using System.Collections.Generic;

namespace Linked_List
{
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public Node(T data)
        {
            this.Data = data;
        }
    }

    public class LinkedList<T> : IEnumerable<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public int Count { get; private set; }

        #region Method Add (add an item to the end of the list) 

        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);

            if (head == null)
            {
                head = node;
                tail = node;
            }

            else
            {
                tail.Next = node;
                tail = node;
            }

            Count++;
        }

        #endregion
        #region Method Remove (remove the item from the list and return "true" if item was deleted)

        public bool Remove(T item)
        {
            Node<T> current = head;
            Node<T> previous = null;
            

            while (current!=null)
            {
                if (current.Data.Equals(item))
                {
                    break; 
                }
                previous = current;
                current = current.Next;
            }

            if (current!=null)
            {
                if (previous != null)
                {
                    previous.Next = current.Next;

                    if (current.Next == null)//?End list?
                    {
                        tail = previous;
                    }
                }
                else // if item is first
                {
                    head = head.Next;

                    if (head == null) // if item is first and list size equals 1
                    {
                        tail = null;
                    }
                }
                Count--;
                return true;
            }

            return false;
        }

        #endregion
        #region Method Contains (return "true" if the list contains an item)

        public bool Contains(T item)
        {
            Node<T> data = head;

            while (data != null)
            {
                if (data.Data.Equals(item))
                {
                    return true;
                }
                data = data.Next;
            }
            return false;
        }


        #endregion
        #region Method GetEnumerator (method get a numerator for the collection and return an instance of the class IEnumerator<T>)

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        #endregion
        #region Method Clear (clear the list)

        public void Clear()
        {
            head = null;
            tail = null;
            Count = 0;
        }

        #endregion
        #region  Method CopyTo (method copies the contents of the list into an array)

        public void CopyTo(T[] array,int arrayIndex)
        {
            Node<T> current = head;

            while (current!=null)
            {
                array[arrayIndex] = current.Data;
                
                current = current.Next;
                arrayIndex++;

            }
        }

        #endregion
        #region Method isEmpty (return "true" if list size equals 0)

        public bool isEmpty()
        {
            if (Count==0)
            {
                return true;
            }

            return false;
        }

        #endregion

    }


    class Program
    {
        
        public static void Display(string nameMethod,LinkedList<int> linkedList)
        {
            Console.WriteLine(nameMethod);
            if (!linkedList.isEmpty())
            {
                foreach (int item in linkedList)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("List is empty!");
                Console.WriteLine();
                Console.WriteLine();
            }

        }
        public static void Display(string nameMethod, int[] mas)
        {
            Console.WriteLine(nameMethod);
            foreach (int item in mas)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            LinkedList<int> linkedList = new LinkedList<int>();

            #region add item

            linkedList.Add(2);
            linkedList.Add(5);
            linkedList.Add(47);
            linkedList.Add(54);


            Display("Add",linkedList);

            #endregion

            #region remove item and use method contains

            int item1 = 47;
            int item2 = 8;
            string nameMethod = "Remove";

            if (linkedList.Contains(item1))
            {
                linkedList.Remove(item1);
                nameMethod += " "+item1;
            }

            if (linkedList.Contains(item2))
            {
                linkedList.Remove(item2);
                nameMethod += " " + item2;
            }

            

            Display(nameMethod,linkedList);


            #endregion

            #region CopyTo

            int[] mas = new int[5];

            linkedList.CopyTo(mas, 2);

            Display("CopyTo",mas);

            #endregion

            #region Clear list

            linkedList.Clear();

            Display("Clear", linkedList);

            #endregion

            Console.ReadKey();
        }
    }
}
