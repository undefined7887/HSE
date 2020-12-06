using System;
using System.Drawing;
using System.Windows.Forms;
using FractalDrawer.Fractals;

namespace FractalDrawer
{
    /// <summary>
    /// Form with cantor set
    /// </summary>
    public partial class CantorSetForm : Form
    {
        private CantorSet _fractal = new CantorSet();
        
        public CantorSetForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            _fractal.SurfaceSize = pictureBox1.Size;
            _fractal.Depth = depth.Value;
            _fractal.LineHeight = lineHeight.Value;
            _fractal.WhitespaceHeight = whitespaceHeight.Value;
            
            e.Graphics.DrawImage(_fractal.Draw(), new Point(0, 0));
        }

        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }

        private void on_Scroll(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }
    }
}