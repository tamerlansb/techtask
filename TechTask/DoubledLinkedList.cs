using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace TechTask
{
    [Serializable]
    public class Node<T> {
        private T data;
        private Node<T> next;
        private Node<T> prev;
        public Node(T Data)
        {
            this.data = Data;
            this.next = null;
            this.prev = null;
        }
        public Node<T> Next
        {
            get { return next; }
            set { next = value;  }
        }
        public Node<T> Prev
        {
            get { return prev; }
            set { prev = value; }
        }
        public T Data
        {
            get { return data; }
            set { data = value; }
        }
        
    }
    [Serializable]
    public class DoubledLinkedList<T>
    {
        private Node<T> First;
        private Node<T> Last;
        private Node<T> Curr;
        private uint count; 
        public DoubledLinkedList()
        {
            this.count = 0;
            this.First = this.Last = this.Curr = null;
        }
        public uint Count 
        {
            get { return count; }
            set { count = value; }
        }
        public void Add(T elem)
        {
            Node<T> NewNode = new Node<T>(elem);
            if (First == null)
            {
                First = Last = NewNode;
            }
            else
            {
                Last.Next = NewNode;
                NewNode.Prev = Last;
                Last = NewNode;
            }
            count++;
        }
        public void AddFront(T elem)
        {
            Node<T> NewNode = new Node<T>(elem);
            if (First == null)
            {
                First = Last = NewNode;
            }
            else
            {
                NewNode.Next = First;
                First.Prev = NewNode;
                First = NewNode;
            }
            count++;
        }
        public bool isempty()
        {
            return count == 0;
        }
        public void Print() 
        {
            if (First == null)
            {
                Console.WriteLine("Doubly Linked List is empty");
                return;
            }
            Curr = First;
            while (Curr != null)
            {
                Console.WriteLine(Curr.Data.ToString());
                Curr = Curr.Next;
            }
        }
        public void ReversePrint()
        {
            if (Last == null)
            {
                Console.WriteLine("Doubly Linked List is empty");
                return;
            }
            Curr = Last;
            while (Curr != null)
            {
                Console.WriteLine(Curr.Data.ToString());
                Curr = Curr.Prev;
            }
        }
        public void AddByIndex(T newElement, uint index) 
        {
            if (index < 1 || index > count+1) 
            {
                throw new IndexOutOfRangeException();
            }
            else if (index == 1) 
            {
                AddFront(newElement);
            }
            else if (index == count+1)
            {
                Add(newElement);
            }
            else
            {
                uint i = 1;
                Curr = First;
                while (Curr != null && i != index)
                {
                    Curr = Curr.Next;
                    i++;
                }
                Node<T> newNode = new Node<T>(newElement);
                count++;
                Curr.Prev.Next = newNode;
                newNode.Prev = Curr.Prev;
                Curr.Prev = newNode;
                newNode.Next = Curr;
            }
        }
        public Node<T> PopFront()
        {
            if (First == null)
            {
                throw new InvalidOperationException("List empty\n");
            }
            else
            {
                Node<T> temp = First;
                if (First.Next != null)
                {
                    First.Next.Prev = null;
                }
                First = First.Next;
                count--;
                temp.Next = null;
                return temp;
            }
        }
        public Node<T> Pop()
        {
            if (Last == null)
            {
                throw new InvalidOperationException("List empty\n");
            }
            else
            {
                Node<T> temp = Last;
                if (Last.Prev != null)
                {
                    Last.Prev.Next = null;
                }
                Last = Last.Prev;
                temp.Prev = null;
                count--;
                return temp;
            }
        }
        public void ClearList() 
        {
            while (count==0)
            {
                Pop();
            }
            First = null;
            Last = null;
        }
        public void RemoveByIndex(uint index)
        { 
            if (index < 1 || index > count)
            {
                throw new IndexOutOfRangeException();
            }
            else if (index == 1)
            {
                PopFront();
            }
            else if (index == count)
            {
                Pop();
            }
            else
            {
                uint i = 1;
                Curr = First;
                while (Curr != null && i != index)
                {
                    Curr = Curr.Next;
                    i++;
                }
                Curr.Prev.Next = Curr.Next;
                Curr.Next.Prev = Curr.Prev;
                --count;
            }
        }
        public void RemoveByPredicate(Predicate<T> condition)
        {
            Curr = First;
            while (Curr!=null)
            {
                if (condition(Curr.Data))
                {
                    if (Curr == First)
                        First = Curr.Next;
                    if (Curr == Last)
                        Last = Curr.Prev;
                    if (Curr.Next != null)
                        Curr.Next.Prev = Curr.Prev;
                    if (Curr.Prev != null)
                        Curr.Prev.Next = Curr.Next;
                    count--;
                }
                Curr = Curr.Next;
            }
        }
        public delegate int Condtion(T obj1, T obj2);
        public void SortByPred(Condtion cond)
        {
            for (int i = 0; i < count;++i)
            {
                Curr = First;
                while (Curr!=null)
                {
                    if (Curr.Next!=null)
                    {
                        if (cond(Curr.Data,Curr.Next.Data)==1)
                        {
                            T temp = Curr.Data;
                            Curr.Data = Curr.Next.Data;
                            Curr.Next.Data = temp;
                        }
                    }
                    Curr = Curr.Next;
                }
            }
        }
        public bool Save(string filename)
        {
            DoubledLinkedList<T> obj = this;
            System.IO.FileStream fileStream = null;
            bool flag = true;
            try
            {
                fileStream = new System.IO.FileStream(filename, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                BinaryFormatter binaryFormatter = new BinaryFormatter();

                binaryFormatter.Serialize(fileStream, obj);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Исключение: " + ex.Message);
                flag = false;
            }
            finally
            {
                if (fileStream != null) fileStream.Close();
            }
            return flag;
        }
        public static bool Load(string filename, ref DoubledLinkedList<T> obj)
        {
            System.IO.FileStream fileStream = null;
            bool flag = true;
            try
            {
                fileStream = new System.IO.FileStream(filename, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                BinaryFormatter binaryFormatter = new BinaryFormatter();

                obj = binaryFormatter.Deserialize(fileStream) as DoubledLinkedList<T>;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Исключение: " + ex.Message);
                flag = false;
            }
            finally
            { if (fileStream != null) fileStream.Close(); }
            return flag;
        }
    }
}