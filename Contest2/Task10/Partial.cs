using System;

internal partial class Program
{
    private static bool ValidateData(int day, int month, int year)
    {
        try
        {
            var dt = new DateTime(year, month, day);

            if (dt.Year < 1701 || dt.Year > 1800)
                return false;
        }
        catch (Exception e)
        {
            return false;
        }

        return true;
    }

    private static int GetDayOfWeek(int day, int month, int year)
    {
        var dt = new DateTime(year, month, day);
        return dt.DayOfWeek.GetHashCode();
    }

    private static string GetDateOfFriday(int dateOfWeek, int day, int month, int year)
    {
        var dt = new DateTime(year, month, day);
        if (dateOfWeek == 6)
            dt = dt.AddDays(5);
        else
            dt = dt.AddDays(DayOfWeek.Friday.GetHashCode() - dateOfWeek);

        return GetFormatMessage(dt.Day, dt.Month, dt.Year);
    }
}