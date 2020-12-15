using System;

public class Group
{
    private readonly Student[] _studentsArray;

    public Group(Student[] studentsArray)
    {
        if (studentsArray.Length < 5)
            throw new ArgumentException("Incorrect group");

        _studentsArray = studentsArray;
    }

    public int IndexOfMaxGrade()
    {
        var maxGrade = _studentsArray[0].Grade;
        var idx = 0;
        
        for (var i = 0; i < _studentsArray.Length; i++)
        {
            if (_studentsArray[i].Grade > maxGrade)
            {
                maxGrade = _studentsArray[i].Grade;
                idx = i;
            }
        }

        return idx;
    }

    public int IndexOfMinGrade()
    {
        var minGrade = _studentsArray[0].Grade;
        var idx = 0;
        
        for (var i = 0; i < _studentsArray.Length; i++)
        {
            if (_studentsArray[i].Grade < minGrade)
            {
                minGrade = _studentsArray[i].Grade;
                idx = i;
            }
        }

        return idx;
    }

    public Student this[int index] => _studentsArray[index];
}