using System.Drawing;

namespace FractalDrawer.Figures
{
    /// <summary>
    /// Describes simple regular triangle
    /// </summary>
    public struct Triangle
    {
        /// <summary>
        /// Rectangle in which the given triangle is inscribed
        /// </summary>
        public RectangleF Rectangle { get; set; }

        /// <summary>
        /// Rectangle's top point
        /// </summary>
        public PointF Top
            => PointF.Add(Rectangle.Location, new SizeF(Rectangle.Width / 2f, 0));

        /// <summary>
        /// Rectangle's left point
        /// </summary>
        public PointF Left
            => PointF.Add(Rectangle.Location, new SizeF(0, Rectangle.Height));

        /// <summary>
        /// Rectangle's right point
        /// </summary>
        public PointF Right
            => PointF.Add(Rectangle.Location, new SizeF(Rectangle.Width, Rectangle.Height));
    }
}