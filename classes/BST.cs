namespace lab5.classes;

public class BST
{
    class Node
    {
        public Student student;

        public Node left;

        public Node right;

        public Node(Student student)
        {
            this.student = student;
        }
    }

    private Node root;

    public void insert(Student newElem)
    {
        root = insertNode(root, newElem);
    }

    private Node insertNode(Node current, Student newElem)
    {
        if (current == null)
        {
            return new Node(newElem);
        }

        if (newElem.LastName.CompareTo(current.student.LastName) < 0)
        {
            current.left = insertNode(current.left, newElem);

            current = rotationR(current);
        }

        else
        {
            current.right = insertNode(current.right, newElem);

            current = rotationL(current);
        }

        return current;
    }

    private Node rotationR(Node current)
    {
        Node temp = current.left;

        current.left = temp.right;

        temp.right = current;

        current = temp;

        return current;
    }

    private Node rotationL(Node current)
    {
        Node temp = current.right;

        current.right = temp.left;

        temp.left = current;

        current = temp;

        return current;
    }

    public void find(String key)
    {
        Console.WriteLine("Element with key " + key);

        Node findN = findNode(root, key);

        if (findN == null)
        {
            Console.WriteLine("No elements with such key!");
        }

        else
        {
            Console.WriteLine(findN.student);
        }
    }

    private Node findNode(Node current, String key)
    {
        if (current == null)
        {
            return null;
        }

        if (current.student.LastName.CompareTo(key) > 0)
        {
            current = findNode(current.left, key);
        }
        else if (current.student.LastName.CompareTo(key) < 0)
        {
            current = findNode(current.right, key);
        }

        else return current;

        return current;
    }
}