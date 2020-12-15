using System;
using System.Windows.Forms;
using FractalDrawer.Fractals;

namespace FractalDrawer
{
    public partial class SierpinskiTriangleForm : Form
    {
        private readonly SierpinskiTriangle _fractal = new SierpinskiTriangle();
        public SierpinskiTriangleForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            _fractal.SurfaceSize = pictureBox1.Size;
            _fractal.Depth = depth.Value;
            
            e.Graphics.DrawImage(_fractal.Draw(), 0, 0);
        }

        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }

        private void depth_Scroll(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }
    }
}