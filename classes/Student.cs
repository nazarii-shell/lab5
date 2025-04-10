namespace lab5.classes;

public class Student
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public bool PlaysMusicInstrument { get; set; }
    public int Group { get; set; }
    public double Score { get; set; }

    public Student(string lastName, string firstName, bool playsMusicInstrument, double score, int group)
    {
        LastName = lastName;
        FirstName = firstName;
        PlaysMusicInstrument = playsMusicInstrument;
        Group = group;
        Score = score;
    }

    public override string ToString()
    {
        return FirstName + " " + LastName + "; PlaysMusicInstrument: " + PlaysMusicInstrument + "; Socre:" + Score + "; Group:" + Group; ;
    }
    
}