namespace lab5.classes;

public class BSTRandomize
{
// вузол дерева повинен містити кількість елементів в піддереві

    public class NodeRandom
    {
        public Student student;

        public NodeRandom left;

        public NodeRandom right;

        public int countNodes;

        public NodeRandom(Student student)
        {
            this.student = student;
        }
    }

    public NodeRandom root;

    public void insert(Student newElem)
    {
        root = insertTree(root, newElem);
    }

    private NodeRandom insertTree(NodeRandom current, Student newElem)
    {
// вставка нового вузла в порожнє дерево

        if (current == null)
        {
            NodeRandom newNodeRandom = new NodeRandom(newElem);

            newNodeRandom.countNodes = 1;

            return newNodeRandom;
        }

        Random random = new Random();

        if (random.NextDouble() * current.countNodes < 1.0)
        {
            current = insR(current, newElem);
        }

        else if (newElem.LastName.CompareTo(current.student.LastName) < 0)
        {
            current.left = insertTree(current.left, newElem);
        }

        else
        {
            current.right = insertTree(current.right, newElem);
        }

        current.countNodes++;

        return current;
    }

    private NodeRandom insR(NodeRandom current, Student newElem)
    {
        current = insertRoot(current, newElem);

        current.countNodes = current.countNodes - 1;

        return current;
    }

    private NodeRandom insertRoot(NodeRandom current, Student newElem)
    {
        if (current == null)
        {
            NodeRandom nodeRandom = new NodeRandom(newElem);
            nodeRandom.countNodes = 1;
            return nodeRandom;
        }

        if (newElem.LastName.CompareTo(current.student.LastName) < 0)
        {
            current.left = insertRoot(current.left, newElem);
            current.countNodes = current.countNodes - current.left.countNodes;
            current = rotationR(current);
            current.right.countNodes = count(current.right);
        }
        else
        {
            current.right = insertRoot(current.right, newElem);
            current.countNodes = current.countNodes - current.right.countNodes;
            current = rotationL(current);
            current.left.countNodes = count(current.left);
        }

        current.countNodes = count(current);
        return current;
    }

    private int count(NodeRandom current)
    {
        if (current.left != null)
        {
            if (current.right != null)

                current.countNodes = current.left.countNodes + current.right.countNodes;
            else
                current.countNodes = current.left.countNodes;
        }

        else if (current.right != null)

            current.countNodes = current.right.countNodes;

        return ++current.countNodes;
    }

    private NodeRandom rotationR(NodeRandom current)
    {
        NodeRandom temp = current.left;

        current.left = temp.right;

        temp.right = current;

        current = temp;

        return current;
    }

    private NodeRandom rotationL(NodeRandom current)
    {
        NodeRandom temp = current.right;

        current.right = temp.left;

        temp.left = current;

        current = temp;

        return current;
    }

    public void find(String key)
    {
        Console.WriteLine("Element with key " + key);

        NodeRandom findN = findNode(root, key);

        if (findN == null)
        {
            Console.WriteLine("No elements with such key!");
        }

        else
        {
            Console.WriteLine(findN.student);
        }
    }

    private NodeRandom findNode(NodeRandom current, String key)
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

    public void printTree(NodeRandom current)
    {
        if (current == null)
        {
            return;
        }
        
        Console.WriteLine(current.student);
        
        printTree(current.left);
        printTree(current.right);
    }
}