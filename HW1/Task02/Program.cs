using System;

namespace Task02
{
    class Program
    {
        const int LetterHeight = 5;

        static void Main(string[] args)
        {
            string[] letterE = {
                "*****",
                "*    ",
                "*****",
                "*    ",
                "*****"
            };

            string[] letterB = {
                "**** ",
                "*  * ",
                "*****",
                "*   *",
                "*****"
            };

            string[] letterC = {
                "*****",
                "*    ",
                "*    ",
                "*    ",
                "*****"
            };

            string[] letterT = {
                "*****",
                "  *  ",
                "  *  ",
                "  *  ",
                "  *  "
            };

            string[] letterA = {
                "*****",
                "*   *",
                "*****",
                "*   *",
                "*   *"
            };

            string[] letterF = {
                "*****",
                "* * *",
                "*****",
                "  *  ",
                "  *  "
            };

            string[] letterb = {
                "*    ",
                "*    ",
                "*****",
                "*   *",
                "*****"
            };

            string[][] name =
            {
                letterE,
                letterB,
                letterC,
                letterT,
                letterA,
                letterF,
                letterb,
                letterE,
                letterB
            };

            
            for (var i = 0; i < LetterHeight; i++)
            {
                foreach (var t in name)
                {
                    Console.Write(t[i] + "  ");
                }

                Console.WriteLine();
            }
        }
    }
}
