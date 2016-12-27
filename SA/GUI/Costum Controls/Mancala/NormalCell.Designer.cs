namespace SA.GUI.Costum_Controls.Mancala
{
    partial class NormalCell
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
            ((System.ComponentModel.ISupportInitialize)(this.ContainerCell)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CountStones)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.CountStones.Location = new System.Drawing.Point(0, 232);
            // 
            // radPanel1
            // 
            this.ContainerCell.Size = new System.Drawing.Size(100, 100);
            // 
            // NormalCell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "NormalCell";
            ((System.ComponentModel.ISupportInitialize)(this.ContainerCell)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CountStones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
