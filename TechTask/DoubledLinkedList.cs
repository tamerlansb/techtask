using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTask
{
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
                count++;
            }
        }
        public void RemoveByPredicate(Predicate<T> pred)
        {
            
        }
       // Print()
       // ReversePrint()
       // AddByIndex()
       // RemoveByIndex()
       // RemoveAllByLastName
       // SaveToFile()
       // DownloadFromFile()
    }
}
