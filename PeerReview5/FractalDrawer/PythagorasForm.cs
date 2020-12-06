using System;
using System.Drawing;
using System.Windows.Forms;
using FractalDrawer.Fractals;

namespace FractalDrawer
{
    /// <summary>
    /// Form with pythagoras tree fractal
    /// </summary>
    public partial class PythagorasForm : Form
    {
        private readonly PythagorasFractal _fractal  = new PythagorasFractal();

        public PythagorasForm()
        {
            InitializeComponent();
        }
        
        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }

        private void on_Scroll(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Draw(e);
        }

        private void Draw(PaintEventArgs e)
        {
            _fractal.SurfaceSize = pictureBox1.Size;

            _fractal.Depth = depth.Value;
            _fractal.RightAngle = rightAngle.Value * Math.PI / 180;
            _fractal.LeftAngle = leftAngle.Value * Math.PI / 180;

            e.Graphics.DrawImage(_fractal.Draw(), 0, 0);
        }
    }
}