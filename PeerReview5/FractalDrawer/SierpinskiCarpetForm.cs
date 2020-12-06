using System;
using System.Drawing;
using System.Windows.Forms;
using FractalDrawer.Fractals;

namespace FractalDrawer
{
    public partial class SierpinskiCarpetForm : Form
    {
        private readonly SierpinskiCarpet _fractal = new SierpinskiCarpet();

        public SierpinskiCarpetForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Draw(e);
        }

        private void Draw(PaintEventArgs e)
        {
            _fractal.SurfaceSize = pictureBox1.Size;
            _fractal.Depth = depth.Value;

            e.Graphics.DrawImage(_fractal.Draw(), new Point(0, 0));
        }

        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }
    }
}