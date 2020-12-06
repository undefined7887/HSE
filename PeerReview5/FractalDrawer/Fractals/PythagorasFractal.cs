using System;
using System.Drawing;

namespace FractalDrawer.Fractals
{
    /// <summary>
    /// Describes pythagoras tree fractal
    /// </summary>
    public class PythagorasFractal : Fractal
    {
        /// <summary>
        /// Pen for drawing
        /// </summary>
        private readonly Pen _pen = new Pen(Color.Black, 2);

        /// <summary>
        /// Angle of left tree branch
        /// </summary>
        public double LeftAngle { get; set; }
        
        /// <summary>
        /// Angle of right tree branch
        /// </summary>
        public double RightAngle { get; set; }

        /// <summary>
        /// Draws pythagoras tree fractal
        /// </summary>
        /// <returns>Image with pythagoras tree</returns>
        public override Bitmap Draw()
        {
            DrawLine(
                new PointF(SurfaceSize.Width / 2f, SurfaceSize.Height),
                Math.PI / 2,
                // ReSharper disable once PossibleLossOfFraction
                SurfaceSize.Height / 4,
                Depth
            );

            return Bitmap;
        }

        /// <summary>
        /// Draws branch of pythagoras tree
        /// </summary>
        /// <param name="start">Point to start from</param>
        /// <param name="angle">Angle of branch</param>
        /// <param name="length">Branch length</param>
        /// <param name="count">Recursion depth</param>
        private void DrawLine(PointF start, double angle, double length, int count)
        {
            if (count == 0)
                return;

            var end = new PointF(
                (float) (start.X + length * Math.Cos(angle)),
                (float) (start.Y - length * Math.Sin(angle))
            );

            Graphics.DrawLine(_pen, start, end);

            DrawLine(end, angle + LeftAngle, length / 1.4, count - 1);
            DrawLine(end, angle - RightAngle, length / 1.4, count - 1);
            
        }
    }
}