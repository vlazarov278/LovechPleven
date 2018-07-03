using System;
using System.Text;

namespace Algorithms
{
    class ArrayList
    {

        private class Node
        {
            private object value;
            public object Value
            {
                get { return value; }
                set { this.value = value; }
            }

            private Node next;
            public Node Next
            {
                get { return next; }
                set { this.next = value; }
            }

            private int index;
            public int Index
            {
                get { return index; }
                set { index = value; }
            }


            public Node(object val, int index)
            {
                this.value = val;
                this.previousAddress = null;
                this.index = index;
            }

            public Node(object val)
            {
                this.value = val;
                this.previousAddress = null;
                this.index = -1;
            }

            private Node previousAddress;
            public Node PreviousAddress
            {
                get { return previousAddress; }
                set { previousAddress = value; }
            }
        }

        private int count;

        public int Count
        {
            get { return count; }
        }

        private Node head;

        private int currentIndex = 0;

        public ArrayList()
        {
            this.count = 0;
            this.head = new Node(null, -1);
            this.current = this.head;
            this.previous = head;
        }

        private Node current;

        private Node previous;

        public void Print()
        {
            Node currentNode = this.head.Next;
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(currentNode.Value);
                currentNode = currentNode.Next;
            }
        }

        public void Add(object val)
        {
            Node newNode = new Node(val, currentIndex);
            currentIndex++;
            current.Next = newNode;
            newNode.PreviousAddress = current;
            current = newNode;
            count++;
        }

        public object GetElementByIndex(int index)
        {
            if (index > currentIndex || index < 0)
            {
                throw new Exception("Index was outside of the boundaries.");
            }
            else
            {
                Node currentNode = head.Next;
                for (int i = 0; i < count; i++)
                {
                    if (currentNode.Index == index) return currentNode.Value;
                    currentNode = currentNode.Next;
                }
            }
            return -1;
        }

        public void RemoveElement(object element)
        {
            Node currentNode = head.Next;
            for (int i = 0; i < count; i++)
            {
                if (currentNode.Value.GetHashCode() == element.GetHashCode())
                {
                    Node previous = currentNode.PreviousAddress;
                    Node next = currentNode.Next;
                    if (previous != null)
                    {
                        previous.Next = next;
                    }
                    if (next != null)
                    {
                        next.PreviousAddress = previous;
                    }
                    currentNode = null;
                    count--;
                    break;
                }
                else
                {
                    currentNode = currentNode.Next;
                }
            }
        }

        public void RemoveByIndex(int index)
        {
            if (index > currentIndex || index < 0) throw new Exception("Index was outside of boundaries.");
            else
            {
                Node currentNode = head.Next;
                for (int i = 0; i < count; i++)
                {
                    if (currentNode.Index == index)
                    {
                        Node prevNode = currentNode.PreviousAddress;
                        Node nextNode = currentNode.Next;
                        if (prevNode != null)
                        {
                            prevNode.Next = nextNode;
                        }
                        if (nextNode != null)
                        {
                            nextNode.PreviousAddress = prevNode;
                        }
                        currentNode = null;
                        count--;
                        for (int j = index + 1; j < count; j++)
                        {
                            Node curr = GetNodeByIndex(j);
                            curr.Index--;
                        }
                        currentIndex--;
                        break;
                    }
                    currentNode = currentNode.Next;
                }
            }
        }

        public void AddRange(object collection)
        {
            var element = collection as System.Collections.IEnumerable;
            if (element != null)
            {
                foreach (var el in element)
                {
                    this.Add(el);
                }
            }
            else throw new ArgumentException("Variable is not a collection.");
        }

        public int IndexOf(object element)
        {
            Node currentNode = head.Next;
            for (int i = 0; i < count; i++)
            {
                if (currentNode.Value.GetHashCode() == element.GetHashCode())
                {
                    return currentNode.Index;
                }
                else
                {
                    currentNode = currentNode.Next;
                }
            }
            return -1;
        }

        private Node GetNodeByIndex(int index)
        {
            if (index > currentIndex || index < 0)
            {
                throw new Exception("Index was outside of the boundaries.");
            }
            else
            {
                Node currentNode = head.Next;
                for (int i = 0; i < count; i++)
                {
                    if (currentNode.Index == index) return currentNode;
                    currentNode = currentNode.Next;
                }
            }
            return null;
        }

        public void Insert(object element, int index)
        {
            if (index < 0 || index > count - 1) throw new ArgumentException("Index was outside the boundaries.");
            else
            {
                Node currentNode = GetNodeByIndex(index);
                Node newNode = new Node(element);
                newNode.Next = currentNode;
                newNode.PreviousAddress = currentNode.PreviousAddress;
                currentNode.PreviousAddress.Next = newNode;
                currentNode.PreviousAddress = newNode;
                newNode.Index = index;
                currentIndex++;
                while (currentNode.Next != null)
                {
                    currentNode.Index++;
                    currentNode = currentNode.Next;
                }
                count++;
            }
        }

        public void Clear()
        {
            Node currentIndex = head.Next;
            for (int i = 0; i < count; i++)
            {
                Node temp = currentIndex.Next;
                currentIndex = null;
                currentIndex = temp;
            }
            count = 0;
        }
    }
}