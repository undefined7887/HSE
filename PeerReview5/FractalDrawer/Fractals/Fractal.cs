using System.Drawing;

namespace FractalDrawer.Fractals
{
    /// <summary>
    /// Base class for fractals
    /// </summary>
    public abstract class Fractal
    {
        /// <summary>
        /// Drawing surface
        /// </summary>
        protected Bitmap Bitmap;
        
        /// <summary>
        /// Drawing tool
        /// </summary>
        protected Graphics Graphics { get; private set; }
        
        /// <summary>
        /// Field for SurfaceSize property
        /// </summary>
        private Size _size;
        
        /// <summary>
        /// Surface size
        /// </summary>
        public Size SurfaceSize
        {
            get => _size;
            set
            {
                _size = value;
                Bitmap = new Bitmap(_size.Width, _size.Height);
                Graphics = Graphics.FromImage(Bitmap);
            }
        }

        /// <summary>
        /// Recursion depth
        /// </summary>
        public int Depth { get; set; }

        /// <summary>
        /// Draws fractal on surface
        /// </summary>
        /// <returns>Image with drawn fractal</returns>
        public abstract Bitmap Draw();
    }
}