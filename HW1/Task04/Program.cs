using System;

namespace Task04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите напряжение (U): ");
            var input = Console.ReadLine();

            if (!float.TryParse(input, out var voltage))
            {
                Console.WriteLine("Введены данные неправильного формата");
                return;
            }

            Console.Write("Введите сопротивление (R): ");
            input = Console.ReadLine();

            if (!float.TryParse(input, out var resistance))
            {
                Console.WriteLine("Введены данные неправильного формата");
                return;
            }

            Console.WriteLine(
                "Сила тока (I = U/R): {0:F3}",
                voltage / resistance
            );

            Console.WriteLine(
                "Потребляемая мощность (P = U*U/R): {0:F3}",
                voltage * voltage / resistance
            );
        }
    }
}