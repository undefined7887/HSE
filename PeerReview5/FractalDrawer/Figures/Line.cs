using System;
using System.Drawing;

namespace FractalDrawer.Figures
{
    
    /// <summary>
    /// Describes simple line
    /// </summary>
    public struct Line
    {
        /// <summary>
        /// Line start point
        /// </summary>
        public PointF Start { get; set; }
        
        /// <summary>
        /// Line end point
        /// </summary>
        public PointF End { get; set; }
        
        /// <summary>
        /// Line horizontal angle 
        /// </summary>
        public float Angle { get; set; }

        /// <summary>
        /// Line length
        /// </summary>
        public float Length
            => (float) Math.Sqrt(Math.Pow(End.X - Start.X, 2) + Math.Pow(End.Y - Start.Y, 2));
    }
}