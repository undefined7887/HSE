using System;
using System.Windows.Forms;

namespace FractalDrawer
{
    partial class PythagorasForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.depth = new System.Windows.Forms.TrackBar();
            this.rightAngle = new System.Windows.Forms.TrackBar();
            this.leftAngle = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.depth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.rightAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.leftAngle)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Location = new System.Drawing.Point(12, 346);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 45);
            this.label1.TabIndex = 2;
            this.label1.Text = "Recursion depth [1; 15]:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Location = new System.Drawing.Point(12, 445);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 45);
            this.label3.TabIndex = 6;
            this.label3.Text = "Left angle [15; 45]:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Location = new System.Drawing.Point(12, 397);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 45);
            this.label2.TabIndex = 7;
            this.label2.Text = "Right angle [15; 45]:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(718, 328);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.Resize += new System.EventHandler(this.pictureBox1_Resize);
            // 
            // depth
            // 
            this.depth.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.depth.Location = new System.Drawing.Point(146, 346);
            this.depth.Maximum = 15;
            this.depth.Minimum = 1;
            this.depth.Name = "depth";
            this.depth.Size = new System.Drawing.Size(584, 45);
            this.depth.TabIndex = 9;
            this.depth.Value = 1;
            this.depth.Scroll += new System.EventHandler(this.on_Scroll);
            // 
            // rightAngle
            // 
            this.rightAngle.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.rightAngle.Location = new System.Drawing.Point(146, 397);
            this.rightAngle.Maximum = 45;
            this.rightAngle.Minimum = 15;
            this.rightAngle.Name = "rightAngle";
            this.rightAngle.Size = new System.Drawing.Size(584, 45);
            this.rightAngle.TabIndex = 12;
            this.rightAngle.Value = 15;
            this.rightAngle.Scroll += new System.EventHandler(this.on_Scroll);
            // 
            // leftAngle
            // 
            this.leftAngle.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.leftAngle.Location = new System.Drawing.Point(146, 445);
            this.leftAngle.Maximum = 45;
            this.leftAngle.Minimum = 15;
            this.leftAngle.Name = "leftAngle";
            this.leftAngle.Size = new System.Drawing.Size(584, 45);
            this.leftAngle.TabIndex = 13;
            this.leftAngle.Value = 15;
            this.leftAngle.Scroll += new System.EventHandler(this.on_Scroll);
            // 
            // PythagorasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 503);
            this.Controls.Add(this.leftAngle);
            this.Controls.Add(this.rightAngle);
            this.Controls.Add(this.depth);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "PythagorasForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.depth)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.rightAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.leftAngle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TrackBar depth;
        private System.Windows.Forms.TrackBar leftAngle;
        private System.Windows.Forms.TrackBar rightAngle;

        private System.Windows.Forms.PictureBox pictureBox1;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

        #endregion
    }
}