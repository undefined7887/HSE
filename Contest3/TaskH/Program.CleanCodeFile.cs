using System;
using System.IO;

partial class Program
{
    private static string[] ReadCodeLines(string codePath)
    {
        return File.ReadAllLines(codePath);
    }

    private static string[] CleanCode(string[] codeWithComments)
    {
        var multilineCodeComment = false;
        for (var i = 0; i < codeWithComments.Length; i++)
        {
            var line = codeWithComments[i].TrimStart();
            
            if (line.StartsWith("//"))
            {
                codeWithComments[i] = string.Empty;
                continue;
            }

            if (line.StartsWith("/*"))
            {
                codeWithComments[i] = string.Empty;
                
                if (!line.Contains("*/"))
                    multilineCodeComment = true;
                
                continue;
            }

            if (multilineCodeComment)
            {
                codeWithComments[i] = string.Empty;

                if (line.Contains("*/"))
                    multilineCodeComment = false;
            }
                
        }

        return codeWithComments;
    }

    private static void WriteCode(string codeFilePath, string[] codeLines)
    {
        
        var code = string.Empty;
        foreach (var line in codeLines)
        {
            if (line == string.Empty)
                continue;

            code += line + Environment.NewLine;
        }
        
        File.WriteAllText(codeFilePath, code);
    }
}