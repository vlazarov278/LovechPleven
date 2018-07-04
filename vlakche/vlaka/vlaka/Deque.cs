using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vlaka
{
    public class Deque<T>
    {
        class Node<P>
        {

            public T Value
            {
                get; set;
            }
            private Node<P> next;

            public Node<P> Next
            {
                get { return next; }
                set { next = value; }
            }
            private Node<P> previous;

            public Node<P> Previous
            {
                get { return previous; }
                set { previous = value; }
            }

        }
        private Node<T> head;
        private Node<T> tail;
        public T train;
        public int capacity;
        public int count;
        public Deque (int capacity)
        {
            this.capacity = capacity;
        }
        public Deque (T [] trains)
        {

        }
        public Deque ()
        {
            this.capacity = 16;
            head = null;
        }
        public void AddFront(T item)
        {
            var node = new Node<T> { Value = item };

            if (this.count == 0)
            {
                this.tail = this.head = node;
            }
            else if (this.count == 1)
            {
                this.head = node;
                this.head.Next = this.tail;
                this.tail.Previous = this.head;
            }
            else
            {
                node.Next = this.head;
                this.head.Previous = node;
                this.head = node;
            }

            this.count++;
        }
        public void AddBack(T item)
        {
            var node = new Node<T> { Value = item };

            if (this.count == 0)
            {
                this.head = this.tail = node;
            }
            else if (this.count == 1)
            {
                this.tail = node;
                this.tail.Previous = this.head;
                this.head.Next = node;
            }
            else
            {
                node.Previous = this.tail;
                this.tail.Next = node;
                this.tail = node;
            }

            count++;
        }
        public T RemoveFront()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException();
            }

            var removedItem = this.head.Value;

            if (this.count == 1)
            {
                this.head = this.tail = null;
            }
            else
            {
                this.head = this.head.Next;
                this.head.Previous = null;
            }

            this.count--;

            return removedItem;
        }

        public T RemoveBack()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException();
            }

            var removedItem = this.tail.Value;

            if (this.count == 1)
            {
                this.head = this.tail = null;
            }
            else
            {
                this.tail = this.tail.Previous;
                this.tail.Next = null;
            }

            this.count--;

            return removedItem;
        }

        public T GetFront()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException();
            }
            var removedItem = this.head.Value;
            return removedItem;
        }

        public T GetBack()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException();
            }
            var removedItem = this.tail.Value;
            return removedItem;
        }
    }
}
