using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class DoublyLinkedList<T>
    {
        public DoublyLinkedNode<T> Head { get; internal set; }
        public DoublyLinkedNode<T> Tail { get; internal set; }
        

        public void AddFirst(T value)
        {
            AddFirst(new DoublyLinkedNode<T>(value));
        }

        private void AddFirst(DoublyLinkedNode<T> node)
        {
            DoublyLinkedNode<T> temp = Head;
            Head = node;

            Head.Next = temp;

            if (IsEmpty)
            {
                Tail = Head;
            }

            else
            {
                temp.Previous = Head;
            }

            Count++;
        }

        public void AddLast(T value)
        {
            Addlast(new DoublyLinkedNode<T>(value));
        }

        private void Addlast(DoublyLinkedNode<T> Node)
        {
            if (IsEmpty)
                Head = Node;
            
            else
            {
                Tail.Next = Node;
                Node.Previous = Tail;
            }

            Tail = Node;
            Count++;
        }

        // Work on this method, make unit test for it.
        private void RemoveSpecificNode(DoublyLinkedNode<T> value)
        {
            if (IsEmpty)
                throw new IndexOutOfRangeException();

            value.Next.Previous = value.Previous;
            value.Previous.Next = value.Next;
        }

        private void RemoveFirst()
        {
            if (IsEmpty)
                throw new InvalidOperationException();

            Head = Head.Next;
            Count--;

            if (IsEmpty)
                Tail = null;
            else
                Head.Previous = null;
        }

        public void RemoveLast()
        {
            if (IsEmpty)
                throw new InvalidOperationException();

            if(Count == 1)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Tail.Previous.Next = null;
                Tail = Tail.Previous;
            }

            Count--;
        }

        public bool IsEmpty => Count == 0;
        public int Count { get; private set; }
    }
}
