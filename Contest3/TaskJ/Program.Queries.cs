using System.Collections.Generic;
using System.IO;

partial class Program
{
    private static bool ValidateQuery(string query, out string[] queryParameters)
    {
        queryParameters = new string[3];
        var parameters = query.Split(' ');

        if (parameters.Length != 3)
            return false;

        parameters[0] = parameters[0].ToLower();
        switch (parameters[0])
        {
            case "first_name":
                if (parameters[1] != "==" && parameters[1] != "<>")
                    return false;
                break;

            case "last_name":
                if (parameters[1] != "==" && parameters[1] != "<>")
                    return false;
                break;

            case "group":
                if (parameters[1] != "==" && parameters[1] != "<>")
                    return false;
                break;

            case "rating":
                if (parameters[1] != ">=" && parameters[1] != "<=")
                    return false;

                if (!int.TryParse(parameters[2], out _))
                    return false;

                break;

            case "gpa":
                if (parameters[1] != ">=" && parameters[1] != "<=")
                    return false;

                if (!double.TryParse(parameters[2], out _))
                    return false;

                break;

            default:
                return false;
        }

        queryParameters = parameters;
        return true;
    }

    private static List<string> ProcessQuery(string[] queryParameters, string pathToDatabase)
    {
        var data = File.ReadAllLines(pathToDatabase);

        var column = queryParameters[0].ToLower();
        var operation = queryParameters[1];
        var value = queryParameters[2];
        
        var result = new List<string>();
        
        for (var i = 1; i < data.Length; i++)
        {
            var dataValues = data[i].Split(';');

            switch (column)
            {
                case "first_name":
                    if (operation == "==" && SafeEqual(value, dataValues[0]) || 
                        operation == "<>" && !SafeEqual(value, dataValues[0]))
                        result.Add(data[i]);
                    break;    

                case "last_name":
                    if (operation == "==" && SafeEqual(value, dataValues[1]) || 
                        operation == "<>" && !SafeEqual(value, dataValues[1]))
                        result.Add(data[i]);
                    break;   

                case "group":
                    if (operation == "==" && SafeEqual(value, dataValues[2]) || 
                        operation == "<>" && !SafeEqual(value, dataValues[2]))
                        result.Add(data[i]);
                    break; 

                case "rating":
                    int.TryParse(value, out var ratingValue);
                    int.TryParse(dataValues[3], out var rating);
                    
                    if (operation == ">=" && ratingValue <= rating ||
                        operation == "<=" && ratingValue >= rating)
                        result.Add(data[i]);
                    
                    break;

                case "gpa":
                    double.TryParse(value, out var gpaValue);
                    double.TryParse(dataValues[4], out var gpa);
                    
                    if (operation == ">=" && gpaValue <= gpa ||
                        operation == "<=" && gpaValue >= gpa)
                        result.Add(data[i]);
                    
                    break;
            }
        }

        return result;
    }

    private static bool SafeEqual(string str1, string str2)
    {
        return str1.ToLower().Equals(str2.ToLower());
    }
}