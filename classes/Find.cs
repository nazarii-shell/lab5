namespace lab5.classes;

public class Find
{
    public static Student? FindStudentInArray(Student[] students, double targetScore)
    {
        return find(students, targetScore, 0, students.Length - 1);
    }

    public static Student find(Student[] students, double targetScore, int low, int high)
    {
        // Base case: if the target score is out of range or array is empty
        if (low > high || targetScore < students[low].Score || targetScore > students[high].Score)
            return null; // Not found

        // Avoid division by zero
        if (Math.Abs(students[high].Score - students[low].Score) < 1e-6)
        {
            if (Math.Abs(students[low].Score - targetScore) < 1e-6)
                return students[low]; // Found student
            else
                return null; // Not found
        }

        // Estimate the position
        int pos = low + (int)((targetScore - students[low].Score) * (high - low) /
                              (students[high].Score - students[low].Score));

        // Check if the score matches at the estimated position
        if (Math.Abs(students[pos].Score - targetScore) < 1e-6)
            return students[pos]; // Found student

        // Recur to search either the left or the right part of the array
        if (students[pos].Score < targetScore)
            return find(students, targetScore, pos + 1, high);
        else
            return find(students, targetScore, low, pos - 1);
    }
}