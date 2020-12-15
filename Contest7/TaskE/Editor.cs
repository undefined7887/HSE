using System;

abstract class Editor
{
    protected string Name;
    protected int Salary;

    protected Editor(string name, int salary)
    {
        Name = name;
        Salary = salary;
    }

    protected string EditHeader(string header)
        => $"{header} {Name}";

    public int CountSalary(string oldStr, string newStr)
    {
        return Math.Abs(oldStr.Length - newStr.Length) * Salary;
    }
}