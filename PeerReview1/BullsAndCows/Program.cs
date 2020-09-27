using System;
using System.Collections.Generic;

namespace PeerReview1
{
    internal static class Program
    {
        private const int DigitCount = 4;

        /// <summary>
        /// Game "Bulls and cows"
        /// </summary>
        private static void Main()
        {
            var generatedNumber = GenerateNumber();

            while (true)
            {
                var userNumber = GetUserSuggestion();

                var bulls = 0;
                var cows = 0;

                var digitCounter = 0;
                while (userNumber > 0)
                {
                    var digit = userNumber % 10;

                    var generatedNumberPosition = GetDigitPosition(generatedNumber, digit);
                    var userNumberPosition = DigitCount - digitCounter;

                    if (generatedNumberPosition != -1)
                    {
                        if (generatedNumberPosition == userNumberPosition)
                            bulls++;
                        else
                            cows++;
                    }

                    digitCounter++;
                    userNumber /= 10;
                }

                if (bulls == DigitCount)
                {
                    if (!Finish(generatedNumber))
                        break;

                    generatedNumber = GenerateNumber();
                }
                else
                {
                    ShowBullsAndCows(bulls, cows);
                }
            }
        }

        /// <summary>
        /// Generates a number and notifies the user about it
        /// </summary>
        /// <returns>Generated number</returns>
        private static int GenerateNumber()
        {
            var random = new Random();
            var result = random.Next(1, 10);

            var hashSet = new HashSet<int>();
            for (var i = 1; i < DigitCount; i++)
            {
                var number = random.Next(0, 10);
                while (hashSet.Contains(number))
                    number = random.Next(0, 10);

                hashSet.Add(number);
                result = result * 10 + number;
            }

            Console.Clear();
            Console.WriteLine("Okay, I have generated the number, try to guess it");

            return result;
        }

        /// <summary>
        /// Gets and checks the number suggested by the user
        /// </summary>
        /// <returns>Number suggested by the user</returns>
        private static int GetUserSuggestion()
        {
            Console.Write("Your suggestion: ");
            var lowerLimit = Math.Pow(10, DigitCount - 1);
            var upperLimit = Math.Pow(10, DigitCount);

            int number;
            while (!int.TryParse(Console.ReadLine(), out number) || number < lowerLimit || number >= upperLimit)
            {
                Console.WriteLine($"Please, provide number in range [{lowerLimit}, {upperLimit - 1}]");
                Console.Write("Your suggestion: ");
            }

            return number;
        }

        private static void ShowBullsAndCows(int bulls, int cows)
        {
            Console.WriteLine($"\nBulls: {bulls}\nCows: {cows}\n");
        }

        /// <summary>
        /// Finishes the game and asks user if they want to continue
        /// </summary>
        /// <param name="number">Guessed number</param>
        /// <returns>True if the user want to continue or False if the user want to exit</returns>
        private static bool Finish(int number)
        {
            Console.Clear();
            Console.WriteLine($"You have guessed the number {number}");
            Console.WriteLine("Press ENTER if you want to continue and ESC to exit...");

            var key = Console.ReadKey();
            return key.Key != ConsoleKey.Escape;
        }

        /// <summary>
        /// Finds digit position in the number
        /// </summary>
        /// <param name="number">Number to get position for</param>
        /// <param name="digit">Digit to get position of</param>
        /// <returns>-1 if digit was not found or latest digit occurence in specified number</returns>
        private static int GetDigitPosition(int number, int digit)
        {
            var digitCounter = 0;
            while (number > 0)
            {
                if (number % 10 == digit)
                    return DigitCount - digitCounter;

                number /= 10;
                digitCounter++;
            }

            return -1;
        }
    }
}