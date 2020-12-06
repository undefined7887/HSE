using System.Drawing;

namespace FractalDrawer.Fractals
{
    /// <summary>
    /// Implementation of cantor set fractal
    /// </summary>
    public class CantorSet : Fractal
    {
        /// <summary>
        /// Brush to draw
        /// </summary>
        private readonly Brush _brush = Brushes.Black;

        /// <summary>
        /// Line height
        /// </summary>
        public float LineHeight { get; set; }
        
        /// <summary>
        /// Whitespace height
        /// </summary>
        public float WhitespaceHeight { get; set; }

        /// <summary>
        /// Draws cantor set
        /// </summary>
        /// <returns>Image with drawn cantor set</returns>
        public override Bitmap Draw()
        {
            DrawRectangle(
                new RectangleF(
                    new PointF(0, 0),
                    new SizeF(SurfaceSize.Width, LineHeight)
                ),
                Depth
            );
            return Bitmap;
        }

        /// <summary>
        /// Draws rectangle
        /// </summary>
        /// <param name="rectangle">Previous rectangle</param>
        /// <param name="count">Recursion depth</param>
        private void DrawRectangle(RectangleF rectangle, int count)
        {
            if (count == 0)
                return;

            Graphics.FillRectangle(_brush, rectangle);

            DrawRectangle(
                new RectangleF(
                    PointF.Add(
                        rectangle.Location,
                        new SizeF(0, LineHeight + WhitespaceHeight)
                    ),
                    SizeF.Subtract(rectangle.Size, new SizeF(2 * rectangle.Width / 3f, 0))
                ),
                count - 1
            );

            DrawRectangle(
                new RectangleF(
                    PointF.Add(
                        rectangle.Location,
                        new SizeF(2 * rectangle.Width / 3f, LineHeight + WhitespaceHeight)
                    ),
                    SizeF.Subtract(rectangle.Size, new SizeF(2 * rectangle.Width / 3f, 0))
                ),
                count - 1
            );
        }
    }
}