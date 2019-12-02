using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class NodeStack<T> : IEnumerable<T>
    {
        public Node<T> Head { get; private set; }
        private readonly SinglyLinkedList<T> _list = new SinglyLinkedList<T>();

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            return _list.Head.Value;
        }

        public void Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            _list.RemoveFirst();
        }

        public void Push(T item)
        {
            _list.AddFirst(item);
        }

        public bool IsEmpty => Count == 0;
        public int Count => _list.Count;

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
}
