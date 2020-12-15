using System;
using System.Windows.Forms;

namespace FractalDrawer
{
    /// <summary>
    /// Manager form (contains 5 navigation buttons)
    /// </summary>
    public partial class ManagerForm : Form
    {
        public ManagerForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var pythagorasForm = new PythagorasForm();
            pythagorasForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var cochForm = new CochForm();
            cochForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var sierpinskiCarpetForm = new SierpinskiCarpetForm();
            sierpinskiCarpetForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var sierpinskiTriangleForm = new SierpinskiTriangleForm();
            sierpinskiTriangleForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var cantorSetForm = new CantorSetForm();
            cantorSetForm.Show();
        }
    }
}