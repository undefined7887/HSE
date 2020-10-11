partial class Program
{
    private static void GetLetterDigitCount(string line, out int digitCount, out int letterCount)
    {
        line = line.ToLower();
        
        digitCount = 0;
        letterCount = 0;
        
        foreach (var symbol in line)
        {
            if ('0' <= symbol && symbol <= '9')
                digitCount++;
            
            if ('a' <= symbol && symbol <= 'z')
                letterCount++;
        }
    }
}