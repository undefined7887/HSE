using System;

public partial class Program
{
    static bool ParseArrayFromLine(string line, out int[] arr)
    {
        var stringNumbers = line.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

        arr = new int[stringNumbers.Length];
        for (var i = 0; i < stringNumbers.Length; i++)
        {
            if (!int.TryParse(stringNumbers[i], out var number))
                return false;

            arr[i] = number;
        }

        return true;
    }

    private static void Merge(int[] arr, int left, int right, int mid)
    {
        var result = new int[right - left];

        var leftPointer = left;
        var rightPointer = mid;

        for (var i = 0; i < result.Length; i++)
        {
            if (leftPointer == mid || rightPointer == right)
            {
                if (leftPointer == mid)
                {
                    result[i] = arr[rightPointer];
                    rightPointer++;
                }
                else
                {
                    result[i] = arr[leftPointer];
                    leftPointer++;
                }

                continue;
            }

            if (arr[leftPointer] > arr[rightPointer])
            {
                result[i] = arr[rightPointer];
                rightPointer++;
            }
            else if (arr[leftPointer] < arr[rightPointer])
            {
                result[i] = arr[leftPointer];
                leftPointer++;
            }
            else
            {
                result[i] = arr[leftPointer];
                result[++i] = arr[rightPointer];
                leftPointer++;
                rightPointer++;
            }
        }

        for (var i = 0; i < result.Length; i++)
            arr[left + i] = result[i];
    }
}