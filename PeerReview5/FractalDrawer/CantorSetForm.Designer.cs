using System.ComponentModel;

namespace FractalDrawer
{
    partial class CantorSetForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.depth = new System.Windows.Forms.TrackBar();
            this.lineHeight = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.whitespaceHeight = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.depth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.lineHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.whitespaceHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(776, 372);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.Resize += new System.EventHandler(this.pictureBox1_Resize);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Location = new System.Drawing.Point(12, 399);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 44);
            this.label1.TabIndex = 1;
            this.label1.Text = "Recursion Depth [1; 8]:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // depth
            // 
            this.depth.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.depth.Location = new System.Drawing.Point(224, 398);
            this.depth.Maximum = 8;
            this.depth.Minimum = 1;
            this.depth.Name = "depth";
            this.depth.Size = new System.Drawing.Size(563, 45);
            this.depth.TabIndex = 2;
            this.depth.Value = 1;
            this.depth.Scroll += new System.EventHandler(this.on_Scroll);
            // 
            // lineHeight
            // 
            this.lineHeight.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lineHeight.Location = new System.Drawing.Point(224, 449);
            this.lineHeight.Maximum = 60;
            this.lineHeight.Minimum = 10;
            this.lineHeight.Name = "lineHeight";
            this.lineHeight.Size = new System.Drawing.Size(563, 45);
            this.lineHeight.TabIndex = 4;
            this.lineHeight.Value = 10;
            this.lineHeight.Scroll += new System.EventHandler(this.on_Scroll);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Location = new System.Drawing.Point(12, 450);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 44);
            this.label2.TabIndex = 3;
            this.label2.Text = "Line height [10; 60]";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // whitespaceHeight
            // 
            this.whitespaceHeight.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.whitespaceHeight.Location = new System.Drawing.Point(224, 500);
            this.whitespaceHeight.Maximum = 60;
            this.whitespaceHeight.Minimum = 10;
            this.whitespaceHeight.Name = "whitespaceHeight";
            this.whitespaceHeight.Size = new System.Drawing.Size(561, 45);
            this.whitespaceHeight.TabIndex = 6;
            this.whitespaceHeight.Value = 10;
            this.whitespaceHeight.Scroll += new System.EventHandler(this.on_Scroll);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Location = new System.Drawing.Point(12, 500);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(206, 44);
            this.label3.TabIndex = 5;
            this.label3.Text = "Whitespace height [10; 60]:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CantorSetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 590);
            this.Controls.Add(this.whitespaceHeight);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lineHeight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.depth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "CantorSetForm";
            this.Text = "CantorSet";
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.depth)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.lineHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.whitespaceHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar lineHeight;
        private System.Windows.Forms.TrackBar whitespaceHeight;

        private System.Windows.Forms.TrackBar depth;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.PictureBox pictureBox1;

        #endregion
    }
}