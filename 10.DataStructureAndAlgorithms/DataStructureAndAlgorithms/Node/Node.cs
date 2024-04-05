
namespace LinkedList
{
    public class Node
    {
        public object Data { get; set; }

        public Node Next { get; set; }

        public Node Previous { get; set; }

        public Node(object data)
        {
            Data = data;
        }

    }

}
