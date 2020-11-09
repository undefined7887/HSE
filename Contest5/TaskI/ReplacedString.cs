using System;

public class ReplacedString
{
    private string replacedString;

    public ReplacedString(string s, string initialSubstring, string finalSubstring)
    {
        var s1 = s;
        while (true)
        {
            var s2 = s1.Replace(initialSubstring, finalSubstring);
            if (s1 == s2)
                break;

            s1 = s2;
        }

        replacedString = s1;
    }

    public override string ToString()
    {
        return replacedString;
    }
}