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
            this.roundRectShapeForm = new Telerik.WinControls.RoundRectShape(this.components);
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = global::SA.Properties.Resources.AnimatedCustomWaintingFinalofFinalofFinal1;
            this.pictureBox9.Location = new System.Drawing.Point(3, 3);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(220, 64);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox9.TabIndex = 8;
            this.pictureBox9.TabStop = false;
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
            // radPanel1
            // 
            this.radPanel1.BackColor = System.Drawing.Color.Transparent;
            this.radPanel1.Controls.Add(this.pictureBox9);
            this.radPanel1.Location = new System.Drawing.Point(0, 1);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(224, 100);
            this.radPanel1.TabIndex = 9;
            this.radPanel1.Text = "radPanel1";
            // 
            // ShapedForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(224, 70);
            this.Controls.Add(this.radPanel1);
            this.Name = "ShapedForm1";
            this.Opacity = 0.9D;
            this.Shape = this.roundRectShapeForm;
            this.ShowInTaskbar = false;
            this.Text = "ShapedForm1";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ShapedForm1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.RoundRectShape roundRectShapeForm;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Telerik.WinControls.UI.RadPanel radPanel1;
    }
}
