using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace MatrixCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Observe();
            }
        }

        /// <summary>
        /// Working with a user
        /// </summary>
        private static void Observe()
        {
            var matrix = GetMatrixFromUser();

            Console.Clear();
            Console.WriteLine($"Current matrix: {Environment.NewLine}{matrix.String()}");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("\t1) Get matrix track");
            Console.WriteLine("\t2) Get matrix determinant");
            Console.WriteLine("\t3) Transpose matrix");
            Console.WriteLine("\t4) Lead to a stepped view");
            Console.WriteLine("\t5) Multiply matrix by coefficient");
            Console.WriteLine("\t6) Add another matrix");
            Console.WriteLine("\t7) Multiply by another matrix");

            while (true)
            {
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        TrackOption(matrix);
                        return;

                    case "2":
                        DeterminantOption(matrix);
                        return;

                    case "3":
                        TransposeOption(matrix);
                        return;

                    case "4":
                        SteppedViewOption(matrix);
                        return;

                    case "5":
                        MultiplyByCoefficientOption(matrix);
                        return;

                    case "6":
                        SumOption(matrix);
                        return;

                    case "7":
                        MultiplyOption(matrix);
                        return;

                    default:
                        Console.WriteLine("Bad option");
                        break;
                }
            }
        }

        /// <summary>
        /// Handle for 'track' option
        /// </summary>
        /// <param name="matrix">Current matrix</param>
        private static void TrackOption(Matrix matrix)
        {
            Console.Clear();
            try
            {
                Console.WriteLine($"Matrix: {Environment.NewLine}{matrix.String()}");
                Console.WriteLine($"Track: {matrix.GetTrack()}{Environment.NewLine}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to perform calculation: {e.Message}{Environment.NewLine}");
            }

            Final();
        }

        /// <summary>
        /// Handle for 'determinant' option
        /// </summary>
        /// <param name="matrix">Current matrix</param>
        private static void DeterminantOption(Matrix matrix)
        {
            Console.Clear();
            try
            {
                Console.WriteLine($"Matrix: {Environment.NewLine}{matrix.String()}");
                Console.WriteLine($"Determinant: {matrix.GetDeterminant()}{Environment.NewLine}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to perform calculation: {e.Message}{Environment.NewLine}");
            }

            Final();
        }

        /// <summary>
        /// Handle for 'transpose' option
        /// </summary>
        /// <param name="matrix">Current matrix</param>
        private static void TransposeOption(Matrix matrix)
        {
            Console.Clear();
            Console.WriteLine($"Matrix: {Environment.NewLine}{matrix.String()}");
            Console.WriteLine($"Transposed: {Environment.NewLine}{matrix.Transpose().String()}");
            Final();
        }

        /// <summary>
        /// Handle for 'stepped view' option
        /// </summary>
        /// <param name="matrix">Current matrix</param>
        private static void SteppedViewOption(Matrix matrix)
        {
            Console.Clear();
            Console.WriteLine($"Matrix: {Environment.NewLine}{matrix.String()}");
            Console.WriteLine($"Stepped view: {Environment.NewLine}{matrix.SteppedView().String()}");
            Final();
        }

        /// <summary>
        /// Handle for 'multiply by coefficient' option
        /// </summary>
        /// <param name="matrix">Current matrix</param>
        private static void MultiplyByCoefficientOption(Matrix matrix)
        {
            Console.Clear();
            var k = GetDoubleFromUser("Enter coefficient (double): ");

            Console.WriteLine($"Matrix: {Environment.NewLine}{matrix.String()}");
            Console.WriteLine($"Matrix * ({k}): {Environment.NewLine}{matrix.SelfMultiply(k).String()}");
            Final();
        }

        /// <summary>
        /// Handle for 'sum' option
        /// </summary>
        /// <param name="matrix">Current matrix</param>
        private static void SumOption(Matrix matrix)
        {
            Console.Clear();
            var k = GetDoubleFromUser("Enter sum coefficient (double): ");
            var matrix2 = GetMatrixFromUser();

            Console.Clear();
            try
            {
                Console.WriteLine($"Matrix1:{Environment.NewLine}{matrix.String()}");
                Console.WriteLine($"Matrix2:{Environment.NewLine}{matrix2.String()}");
                Console.WriteLine($"Matrix1 + ({k}) * Matrix2: {Environment.NewLine}{matrix.Sum(matrix2, k).String()}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to perform calculation: {e.Message}{Environment.NewLine}");
            }

            Final();
        }

        /// <summary>
        /// Handle for 'multiply' option
        /// </summary>
        /// <param name="matrix">Current matrix</param>
        private static void MultiplyOption(Matrix matrix)
        {
            var matrix2 = GetMatrixFromUser();

            Console.Clear();
            try
            {
                Console.WriteLine($"Matrix1:{Environment.NewLine}{matrix.String()}");
                Console.WriteLine($"Matrix2:{Environment.NewLine}{matrix2.String()}");
                Console.WriteLine($"Matrix1 * Matrix2: {Environment.NewLine}{matrix.Multiply(matrix2).String()}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to perform calculation: {e.Message}{Environment.NewLine}");
            }

            Final();
        }

        /// <summary>
        /// Asks the user if he wants to exit the program
        /// </summary>
        private static void Final()
        {
            Console.WriteLine("Press ENTER to continue or ESC to exit");
            if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                Environment.Exit(0);

            Console.Clear();
        }

        /// <summary>
        /// Gets matrix from user
        /// </summary>
        /// <returns>Matrix passed by the user</returns>
        private static Matrix GetMatrixFromUser()
        {
            Console.Clear();
            Console.WriteLine("You need to enter matrix, choose option:");
            Console.WriteLine("\t1) Get matrix from command line");
            Console.WriteLine("\t2) Get matrix from file");
            Console.WriteLine("\t3) Generate random matrix");

            while (true)
            {
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        return GetMatrixFromCommandLine();

                    case "2":
                        return GetMatrixFromFile();

                    case "3":
                        return GetRandomMatrix();

                    default:
                        Console.WriteLine("Bad option");
                        break;
                }
            }
        }

        /// <summary>
        /// Reads matrix from command line
        /// </summary>
        /// <returns>Read matrix</returns>
        private static Matrix GetMatrixFromCommandLine()
        {
            Console.Clear();
            Console.WriteLine("Enter a matrix separating the numbers with a space");
            Console.WriteLine("Write 'stop' when you want to finish");

            while (true)
            {
                var lines = new List<string>();

                while (true)
                {
                    var line = Console.ReadLine();
                    if (line == null)
                        continue;

                    if (line.ToLower().Equals("stop"))
                        break;

                    lines.Add(line);
                }

                var matrix = Matrix.Parse(lines);
                if (matrix != null)
                    return matrix;

                Console.Clear();
                Console.WriteLine("Bad matrix, try again");
            }
        }

        /// <summary>
        /// Reads matrix from file
        /// </summary>
        /// <returns>Read matrix</returns>
        private static Matrix GetMatrixFromFile()
        {
            Console.Clear();
            Console.WriteLine("Enter full path to the file");

            while (true)
            {
                var path = Console.ReadLine();

                try
                {
                    var lines = File
                        .ReadAllLines(path)
                        .ToList();

                    var matrix = Matrix.Parse(lines);
                    if (matrix != null)
                        return matrix;

                    Console.Clear();
                    Console.WriteLine("Bad matrix, try again");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error opening file, try again: {e.Message}");
                }
            }
        }

        /// <summary>
        /// Generates random matrix
        /// </summary>
        /// <returns>Generated matrix</returns>
        private static Matrix GetRandomMatrix()
        {
            Console.Clear();

            while (true)
            {
                var height = GetIntFromUser("Enter number of rows: ", true);
                var width = GetIntFromUser("Enter number of columns: ", true);

                var min = GetIntFromUser("Enter minimum (integer): ", false);
                var max = GetIntFromUser("Enter maximum (integer): ", false);

                return Matrix.Random(height, width, min, max);
            }
        }

        /// <summary>
        /// Gets integer from user
        /// </summary>
        /// <param name="prefix">Prefix to print before</param>
        /// <param name="positive">Should the number be positive</param>
        /// <returns>Entered number</returns>
        private static int GetIntFromUser(string prefix, bool positive)
        {
            while (true)
            {
                Console.Write(prefix);

                var input = Console.ReadLine();
                if (int.TryParse(input, out var number) && (!positive || number > 0))
                    return number;

                Console.WriteLine($"Bad number {(positive ? "(number must be positive)" : "")}");
            }
        }

        /// <summary>
        /// Gets double from user
        /// </summary>
        /// <param name="prefix">Prefix to print before</param>
        /// <returns>Entered double</returns>
        private static double GetDoubleFromUser(string prefix)
        {
            while (true)
            {
                Console.Write(prefix);

                var input = Console.ReadLine();
                if (double.TryParse(input, out var number))
                    return number;

                Console.WriteLine("Bad double");
            }
        }
    }
}