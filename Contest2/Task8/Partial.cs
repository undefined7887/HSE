using System;

internal partial class Program
{
    private static int MorningWorkout(string dayOfWeek, int firstNumber, int secondNumber)
    {
        switch (dayOfWeek)
        {
            case "Monday":
            case "Wednesday":
            case "Friday":
                return GetSumOfOddOrEvenDigits(firstNumber, 1);

            case "Tuesday":
            case "Thursday":
                return GetSumOfOddOrEvenDigits(secondNumber, 0);

            case "Saturday":
                return Maximum(firstNumber, secondNumber);

            case "Sunday":
                return Multiply(firstNumber, secondNumber);

            default:
                return int.MinValue;
        }
    }

    private static int GetSumOfOddOrEvenDigits(int value, int remainder)
    {
        // 0 - even; 1 - odd

        var sum = 0;
        while (Math.Abs(value) > 0)
        {
            if (remainder == 0 && value % 2 == 0 || remainder == 1 && value % 2 != 0)
                sum += value % 10;
            
            value /= 10;
        }

        return Math.Abs(sum);
    }

    private static int Multiply(int firstValue, int secondValue)
    {
        return firstValue * secondValue;
    }

    private static int Maximum(int firstValue, int secondValue)
    {
        return firstValue > secondValue ? firstValue : secondValue;
    }
}