using System;

namespace ASCIIDecoder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число от 32 до 127: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out var number) || number > 127 || number < 32)
            {
                Console.WriteLine("Введены неправильные данные");
                return;
            }

            Console.WriteLine($"Этому номеру соответствует символ: {(char) number}");
        }
    }
}