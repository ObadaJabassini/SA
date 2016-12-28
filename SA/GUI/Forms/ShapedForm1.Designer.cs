namespace SA.GUI.Forms
{
    partial class ShapedForm1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radTitleBar1 = new Telerik.WinControls.UI.RadTitleBar();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // radPanel2
            // 
            this.radPanel2.BackColor = System.Drawing.Color.Transparent;
            this.radPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.radPanel2.Controls.Add(this.pictureBox1);
            this.radPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radPanel2.Font = new System.Drawing.Font("Nightclub BTN Cn", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radPanel2.ForeColor = System.Drawing.Color.Silver;
            this.radPanel2.Location = new System.Drawing.Point(0, 149);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(399, 259);
            this.radPanel2.TabIndex = 8;
            this.radPanel2.Text = "Lights Out";
            this.radPanel2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radPanel2.Click += new System.EventHandler(this.radPanel2_Click);
            this.radPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.radPanel2_Paint);
            ((Telerik.WinControls.UI.RadPanelElement)(this.radPanel2.GetChildAt(0))).Text = "Lights Out";
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radPanel2.GetChildAt(0).GetChildAt(1))).Opacity = 0D;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SA.Properties.Resources.idea;
            this.pictureBox1.Location = new System.Drawing.Point(100, 84);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 57);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Sneakerhead BTN Condensed", 50.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.ForeColor = System.Drawing.Color.DarkGray;
            this.radLabel1.Image = global::SA.Properties.Resources.Mask;
            this.radLabel1.Location = new System.Drawing.Point(77, 76);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(242, 87);
            this.radLabel1.TabIndex = 7;
            this.radLabel1.Text = "Mancala";
            this.radLabel1.Click += new System.EventHandler(this.radLabel1_Click);
            ((Telerik.WinControls.UI.RadLabelElement)(this.radLabel1.GetChildAt(0))).Image = global::SA.Properties.Resources.Mask;
            ((Telerik.WinControls.UI.RadLabelElement)(this.radLabel1.GetChildAt(0))).Text = "Mancala";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radLabel1.GetChildAt(0).GetChildAt(2).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.None;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radLabel1.GetChildAt(0).GetChildAt(2).GetChildAt(0))).Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // radTitleBar1
            // 
            this.radTitleBar1.Location = new System.Drawing.Point(0, 0);
            this.radTitleBar1.Name = "radTitleBar1";
            this.radTitleBar1.Size = new System.Drawing.Size(399, 23);
            this.radTitleBar1.TabIndex = 11;
            this.radTitleBar1.TabStop = false;
            this.radTitleBar1.Text = "Mancala & LightsOut";
            this.radTitleBar1.ThemeName = "VisualStudio2012Dark";
            // 
            // ShapedForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InfoText;
            this.ClientSize = new System.Drawing.Size(399, 408);
            this.Controls.Add(this.radTitleBar1);
            this.Controls.Add(this.radPanel2);
            this.Controls.Add(this.radLabel1);
            this.Name = "ShapedForm1";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShapedForm1";
            this.ThemeName = "VisualStudio2012Dark";
            this.Load += new System.EventHandler(this.ShapedForm1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Telerik.WinControls.UI.RadTitleBar radTitleBar1;
    }
}
