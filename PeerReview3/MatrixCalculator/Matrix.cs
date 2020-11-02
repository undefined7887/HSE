using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace MatrixCalculator
{
    public class Matrix
    {
        /// <summary>
        /// Number of rows
        /// </summary>
        public int Height { get; }
        
        /// <summary>
        /// Number of columns
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// Matrix
        /// </summary>
        private readonly double[,] _array;

        /// <summary>
        /// Constructor for Matrix class
        /// </summary>
        /// <param name="matrixArray">Matrix</param>
        public Matrix(double[,] matrixArray)
        {
            Height = matrixArray.GetLength(0);
            Width = matrixArray.GetLength(1);

            _array = new double[Height, Width];

            for (var i = 0; i < Height; i++)
            for (var j = 0; j < Width; j++)
                _array[i, j] = matrixArray[i, j];
        }

        /// <summary>
        /// Constructor for Matrix class (creates empty matrix)
        /// </summary>
        /// <param name="height">Number of rows</param>
        /// <param name="width">Number of columns</param>
        private Matrix(int height, int width)
        {
            Height = height;
            Width = width;
            _array = new double[Height, Width];
        }

        /// <summary>
        /// Calculates track of the matrix
        /// </summary>
        /// <returns>Matrix track</returns>
        /// <exception cref="Exception">Matrix is not square</exception>
        public double GetTrack()
        {
            if (Width != Height)
                throw new Exception("Matrix must be square");

            double result = 0;
            for (var i = 0; i < Height; i++)
                result += _array[i, i];

            return result;
        }

        /// <summary>
        /// Calculates determinant of the matrix
        /// </summary>
        /// <returns>Matrix determinant</returns>
        /// <exception cref="Exception">Matrix is not square</exception>
        public double GetDeterminant()
        {
            if (Height != Width)
                throw new Exception("Matrix must be square");

            var steppedMatrix = SteppedView();

            double result = 1;
            for (var i = 0; i < Height; i++)
                result *= steppedMatrix._array[i, i];

            return Math.Abs(result);
        }

        /// <summary>
        /// Transposes matrix
        /// </summary>
        /// <returns>New transposed matrix</returns>
        public Matrix Transpose()
        {
            var result = new Matrix(Width, Height);
            for (var i = 0; i < Height; i++)
            for (var j = 0; j < Width; j++)
                result._array[j, i] = _array[i, j];

            return result;
        }

        /// <summary>
        /// Adds another matrix to the current matrix
        /// </summary>
        /// <param name="anotherMatrix">Matrix to add</param>
        /// <param name="k">Sum coefficient (matrix1 + k * matrix2)</param>
        /// <returns>New matrix that is the sum of 2 matrices</returns>
        /// <exception cref="Exception">Matrices are not the same size</exception>
        public Matrix Sum(Matrix anotherMatrix, double k)
        {
            if (Height != anotherMatrix.Height || Width != anotherMatrix.Width)
                throw new Exception("Matrices must be the same size");

            var result = new Matrix(Height, Width);

            for (var i = 0; i < Height; i++)
            for (var j = 0; j < Width; j++)
                result._array[i, j] = _array[i, j] + k * anotherMatrix._array[i, j];

            return result;
        }

        /// <summary>
        /// Multiplies current matrix
        /// </summary>
        /// <param name="anotherMatrix">Matrix to multiply by</param>
        /// <returns>New matrix that is the product of 2 matrices</returns>
        /// <exception cref="Exception">Matrices have wrong size</exception>
        public Matrix Multiply(Matrix anotherMatrix)
        {
            if (Width != anotherMatrix.Height)
                throw new Exception("The number of columns in the first matrix " +
                                    "must be equal to the number of rows in the second");

            var result = new Matrix(Height, anotherMatrix.Width);

            for (var i = 0; i < Height; i++)
            for (var j = 0; j < anotherMatrix.Width; j++)
            {
                for (var g = 0; g < Width; g++)
                    result._array[i, j] += _array[i, g] * anotherMatrix._array[g, j];
            }

            return result;
        }

        /// <summary>
        /// Multiplies current matrix by a coefficient
        /// </summary>
        /// <param name="k">Coefficient to multiply by</param>
        /// <returns>New matrix that is the product of k and current matrix</returns>
        public Matrix SelfMultiply(double k)
        {
            var result = new Matrix(Height, Width);

            for (var i = 0; i < Height; i++)
            for (var j = 0; j < Width; j++)
                result._array[i, j] = k * _array[i, j];

            return result;
        }

        /// <summary>
        /// Leads matrix to a stepped view
        /// </summary>
        /// <returns>New matrix that is stepped view of current matrix</returns>
        public Matrix SteppedView()
        {
            var result = new Matrix(_array);

            var i = 0;
            for (var j = 0; j < Width; j++)
            {
                if (result._array[i, j] == 0)
                {
                    var flag = false;
                    for (var k = i + 1; k < Height; k++)
                    {
                        if (result._array[k, j] == 0)
                            continue;

                        flag = true;
                        result.SwapRows(i, k);
                    }

                    if (!flag)
                        continue;
                }
                else
                    for (var k = i + 1; k < Height; k++)
                        result.SumRows(k, i,
                            -(result._array[k, j] / result._array[i, j]));

                if (i == Height - 1)
                    break;

                i++;
            }

            return result;
        }

        /// <summary>
        /// Swaps two rows
        /// </summary>
        /// <param name="m">row1</param>
        /// <param name="n">row2</param>
        private void SwapRows(int m, int n)
        {
            for (var g = 0; g < Width; g++)
            {
                var temp = _array[m, g];
                _array[m, g] = _array[n, g];
                _array[n, g] = temp;
            }
        }

        /// <summary>
        /// Multiplies row
        /// </summary>
        /// <param name="m">Row to multiply</param>
        /// <param name="k">Coefficient to multiply by</param>
        private void MultiplyRow(int m, double k)
        {
            for (var g = 0; g < Width; g++)
                _array[m, g] *= k;
        }

        /// <summary>
        /// Calculates sum of 2 rows
        /// </summary>
        /// <param name="m">row1</param>
        /// <param name="n">row2</param>
        /// <param name="k">Sum coefficient ((m) + k * (n) -> (m))</param>
        private void SumRows(int m, int n, double k)
        {
            for (var g = 0; g < Width; g++)
                _array[m, g] += k * _array[n, g];
        }

        /// <summary>
        /// Renders matrix into a string
        /// </summary>
        /// <returns>String with matrix</returns>
        public string String()
        {
            var result = "";

            for (var i = 0; i < Height; i++)
            {
                for (var j = 0; j < Width; j++)
                    result += _array[i, j] + " ";

                result += Environment.NewLine;
            }

            return result;
        }

        /// <summary>
        /// Parses array of lines into matrix
        /// </summary>
        /// <param name="lines">Lines to parse</param>
        /// <returns>Parsed matrix or null if parsing failed</returns>
        public static Matrix Parse(List<string> lines)
        {
            var splitLines = lines
                .Select(x => x.Split(" ", StringSplitOptions.RemoveEmptyEntries))
                .ToArray();

            if (splitLines.Length == 0)
                return null;

            var height = lines.Count;
            var width = splitLines[0].Length;

            var numbers = new double[height, width];

            for (var i = 0; i < splitLines.Length; i++)
            {
                if (splitLines[i].Length != width)
                    return null;

                for (var j = 0; j < splitLines[i].Length; j++)
                {
                    if (!double.TryParse(splitLines[i][j], out var number))
                        return null;

                    numbers[i, j] = number;
                }
            }

            return new Matrix(numbers);
        }

        /// <summary>
        /// Creates new random matrix
        /// </summary>
        /// <param name="height">Number of rows</param>
        /// <param name="width">Number of columns</param>
        /// <param name="min">Minimum</param>
        /// <param name="max">Maximum</param>
        /// <returns>Generated matrix</returns>
        public static Matrix Random(int height, int width, int min, int max)
        {
            var matrix = new Matrix(height, width);

            var random = new Random();
            for (var i = 0; i < height; i++)
            for (var j = 0; j < width; j++)
                matrix._array[i, j] = random.Next(min, max);

            return matrix;
        }
    }
}