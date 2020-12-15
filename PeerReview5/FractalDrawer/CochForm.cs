using System;
using System.Windows.Forms;
using FractalDrawer.Fractals;

namespace FractalDrawer
{
    /// <summary>
    /// Form with coch set
    /// </summary>
    public partial class CochForm : Form
    {
        private readonly CochCurve _fractal = new CochCurve();

        public CochForm()
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

            e.Graphics.DrawImage(_fractal.Draw(), 0, 0);
        }
        
        private void depth_Scroll(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }
    }
}