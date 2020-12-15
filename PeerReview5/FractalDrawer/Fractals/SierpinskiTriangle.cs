using System;
using System.Drawing;
using FractalDrawer.Figures;

namespace FractalDrawer.Fractals
{
    /// <summary>
    /// Implementation of sierpinski triangle 
    /// </summary>
    public class SierpinskiTriangle : Fractal
    {
        /// <summary>
        /// Pen to draw
        /// </summary>
        private readonly Pen _pen = new Pen(Brushes.Black, 2);
        
        /// <summary>
        /// The ratio of the sides of the rectangle in which the regular triangle is inscribed
        /// </summary>
        private readonly float _coefficient = (float) Math.Sqrt(3) / 2f;

        /// <summary>
        /// Draws sierpinski triangle
        /// </summary>
        /// <returns>Image with sierpinski triangle</returns>
        public override Bitmap Draw()
        {
            RecursionDraw(DrawMainTriangle(), Depth);
            return Bitmap;
        }

        /// <summary>
        /// Draws main triangle (with resize logic)
        /// </summary>
        /// <returns>Main triangle</returns>
        private Triangle DrawMainTriangle()
        {
            float x, y, bigSide, smallSide;

            if (SurfaceSize.Height / (float) SurfaceSize.Width >= _coefficient)
            {
                bigSide = SurfaceSize.Width;
                smallSide = bigSide * _coefficient;

                x = 0;
                y = (SurfaceSize.Height - smallSide) / 2f;
            }
            else
            {
                smallSide = SurfaceSize.Height;
                bigSide = smallSide / _coefficient;

                x = (SurfaceSize.Width - bigSide) / 2f;
                y = 0;
            }

            var rectangle = new RectangleF(
                new PointF(x, y),
                new SizeF(bigSide, smallSide)
            );

            var triangle = new Triangle {Rectangle = rectangle};
            Graphics.DrawPolygon(_pen, new[]
            {
                triangle.Top,
                triangle.Left,
                triangle.Right
            });

            return triangle;
        }

        /// <summary>
        /// Recursively draws triangle
        /// </summary>
        /// <param name="triangle">Previous triangle</param>
        /// <param name="count">Recursion depth</param>
        private void RecursionDraw(Triangle triangle, int count)
        {
            if (count == 0)
                return;

            var newBigSide = triangle.Rectangle.Width / 2;
            var newSmallSide = triangle.Rectangle.Height / 2;

            DrawTriangle(new Triangle
            {
                Rectangle = new RectangleF(
                    PointF.Add(
                        triangle.Rectangle.Location,
                        new SizeF(triangle.Rectangle.Width / 4f, 0)
                    ),
                    new SizeF(
                        newBigSide,
                        newSmallSide
                    )
                )
            }, count);

            DrawTriangle(new Triangle
            {
                Rectangle = new RectangleF(
                    PointF.Add(
                        triangle.Rectangle.Location,
                        new SizeF(0, newSmallSide)
                    ),
                    new SizeF(
                        newBigSide,
                        newSmallSide
                    )
                )
            }, count);

            DrawTriangle(new Triangle
            {
                Rectangle = new RectangleF(
                    PointF.Add(
                        triangle.Rectangle.Location,
                        new SizeF(newBigSide, newSmallSide)
                    ),
                    new SizeF(
                        newBigSide,
                        newSmallSide
                    )
                )
            }, count);
        }

        /// <summary>
        /// Draws simple triangle on screen
        /// </summary>
        /// <param name="triangle">Triangle on draw</param>
        /// <param name="count">Recursion depth</param>
        private void DrawTriangle(Triangle triangle, int count)
        {
            Graphics.DrawPolygon(_pen, new[]
            {
                triangle.Top,
                triangle.Left,
                triangle.Right
            });
            RecursionDraw(triangle, count - 1);
        }
    }
}