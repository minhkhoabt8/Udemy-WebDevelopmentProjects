namespace LinkedList
{
    public class LinkedList
    {
        private Node Head;


        public void Add(object data)
        {
            Node newNode = new Node(data);
            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                Node current = Head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
                newNode.Previous = current;
            }
        }

        public void AddFirst(object data)
        {
            Node newNode = new Node(data);
            newNode.Next = Head;
            if (Head != null)
            {
                Head.Previous = newNode;
            }
            Head = newNode;
        }

        public void AddLast(object data)
        {
            Add(data);
        }

        public void Remove(object data)
        {
            if (Head == null)
                return;

            if (Head.Data.Equals(data))
            {
                Head = Head.Next;
                if (Head != null)
                {
                    Head.Previous = null;
                }
                return;
            }

            Node current = Head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (current.Previous != null)
                    {
                        current.Previous.Next = current.Next;
                    }
                    if (current.Next != null)
                    {
                        current.Next.Previous = current.Previous;
                    }
                    return;
                }
                current = current.Next;
            }
        }

        public void RemoveFirst()
        {
            if (Head != null)
            {
                Head = Head.Next;
                if (Head != null)
                {
                    Head.Previous = null;
                }
            }
        }

        public void RemoveLast()
        {
            if (Head == null || Head.Next == null)
            {
                Head = null;
                return;
            }

            Node current = Head;
            while (current.Next.Next != null)
            {
                current = current.Next;
            }
            current.Next = null;
        }

        public void Clear()
        {
            Head = null;
        }

        public int Count()
        {
            int count = 0;
            Node current = Head;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }


        public void Print()
        {
            Node current = Head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }

    }
    
}
