namespace lab5.classes;

public class Tasks
{
    public static void Task1()
    {
        Student[] students =
        [
            new Student("Ivanov", "Ivan", false, 3.5, 101),
            new Student("Petrova", "Anna", true, 3.7, 102),
            new Student("Smith", "John", false, 3.9, 103),
            new Student("Brown", "Lisa", true, 4.2, 104),
            new Student("Clark", "Tom", false, 4.5, 105)
        ];
        
        Array.Sort(students, (a, b) => a.Score.CompareTo(b.Score));

        var targetScore = 4.2;
        var foundStudent = Find.FindStudentInArray(students, targetScore);

        Console.WriteLine(foundStudent != null ? $"Found: {foundStudent}" : "Student not found.");
        PrintArr(students);
    }

    public static void Task2()
    {
        Student[] students =
        [
            new Student("Ivanov", "Ivan", false, 3.5, 101),
            new Student("Petrova", "Anna", true, 3.7, 102),
            new Student("Smith", "John", false, 3.9, 103),
            new Student("Brown", "Lisa", true, 4.2, 104),
            new Student("Clark", "Tom", false, 4.5, 105)
        ];

        BST bst = new BST();
        
        foreach (var student in students)
        {
            bst.insert(student);
        }
        
        bst.find("Ivanov");
        
    }

    public static void Task3()
    {
        Student[] students =
        [
            new Student("Ivanov", "Ivan", false, 3.5, 101),
            new Student("Petrova", "Anna", true, 3.7, 102),
            new Student("Smith", "John", false, 3.9, 103),
            new Student("Brown", "Lisa", true, 4.2, 104),
            new Student("Clark", "Tom", false, 4.5, 105)
        ];

        BSTRandomize bst = new BSTRandomize();
        
        foreach (var student in students)
        {
            bst.insert(student);
        }
        
        bst.find("Ivanov");
    }
    
    static void PrintArr<T>(T[] arr)
    {
        foreach (T element in arr)
        {
            Console.Write($"{element} \n");
        }
    }
    
}