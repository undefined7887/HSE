using System.Drawing;

namespace FractalDrawer.Fractals
{
    /// <summary>
    /// Implementation of sierpinski carpet 
    /// </summary>
    public class SierpinskiCarpet : Fractal
    {
        /// <summary>
        /// Background brush
        /// </summary>
        private readonly Brush _backgroundBrush = Brushes.Blue;
        
        /// <summary>
        /// Mini rectangles brush
        /// </summary>
        private readonly Brush _drawBrush = Brushes.White;

        /// <summary>
        /// Draws sierpinski carpet 
        /// </summary>
        /// <returns>Image with drawn sierpinski carpet</returns>
        public override Bitmap Draw()
        {
            RecursionDraw(DrawMainRectangle(), Depth);
            return Bitmap;
        }

        /// <summary>
        /// Draws main rectangle (with resize logic)
        /// </summary>
        /// <returns>Drawn rectangle</returns>
        private RectangleF DrawMainRectangle()
        {
            float x, y, side;

            if (SurfaceSize.Width > SurfaceSize.Height)
            {
                side = SurfaceSize.Height;
                x = (SurfaceSize.Width - side) / 2;
                y = 0;
            }
            else
            {
                side = SurfaceSize.Width;
                x = 0;
                y = (SurfaceSize.Height - side) / 2;
            }

            var rectangle = new RectangleF(
                new PointF(x, y),
                new SizeF(side, side)
            );
            

            Graphics.FillRectangle(_backgroundBrush, rectangle);
            return rectangle;
        }

        /// <summary>
        /// Recursion draw
        /// </summary>
        /// <param name="rectangle">Previous rectangle</param>
        /// <param name="count">Recursion depth</param>
        private void RecursionDraw(RectangleF rectangle, int count)
        {
            if (count == 0)
                return;
            
            var newRectangles = new RectangleF[9];
            var newSide = rectangle.Height / 3;

            var tempLocation = rectangle.Location;
            for (var i = 0; i < newRectangles.Length; i++)
            {
                newRectangles[i] = new RectangleF(
                    tempLocation,
                    new SizeF(newSide, newSide)
                );

                tempLocation = i % 3 == 2 
                    ? new PointF(rectangle.X, tempLocation.Y + newSide) 
                    : PointF.Add(tempLocation, new SizeF(newSide, 0));
            }
            
            Graphics.FillRectangle(_drawBrush, newRectangles[4]);
            for (var i = 0; i < newRectangles.Length; i++)
            {
                if (i != 4)
                    RecursionDraw(newRectangles[i], count - 1);
            }
        }
    }
}