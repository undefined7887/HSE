using System;

namespace Task05
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите 1 катет: ");
            var input = Console.ReadLine();

            if (!float.TryParse(input, out var firstLeg))
            {
                Console.WriteLine("Введены данные неправильного формата");
            }

            Console.Write("Введите 2 катет: ");
            input = Console.ReadLine();

            if (!float.TryParse(input, out var secondLeg))
            {
                Console.WriteLine("Введены данные неправильного формата");
            }

            Console.WriteLine(
                "Гипотенуза: {0:F3}",
                Math.Sqrt(firstLeg * firstLeg + secondLeg * secondLeg)
            );
        }
    }
}