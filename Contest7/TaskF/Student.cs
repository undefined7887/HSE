using System;

public class Student
{
    public string Name { get; }
    public int Grade { get; }

    private Student(string name, int grade)
    {
        Name = name;
        Grade = grade;
    }

    public static Student Parse(string line)
    {
        var splitLine = line.Split(" ");

        if (!int.TryParse(splitLine[1], out var mark))
            throw new ArgumentException("Incorrect input mark");
        
        if (CheckName(splitLine[0]))
            throw new ArgumentException("Incorrect name");
        
        if (mark < 0 || mark > 10)
            throw new ArgumentException("Incorrect mark");
        
        return new Student(splitLine[0], mark);
    }

    private static bool CheckName(string name)
    {
        return name.Length < 3 || 'a' <= name[0] && name[0] <= 'z';
    }

    public override string ToString()
    {
        return $"{Name} got a grade of {Grade}.";
    }
}