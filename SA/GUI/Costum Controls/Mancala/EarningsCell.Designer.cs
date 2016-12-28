namespace SA.GUI.Costum_Controls.Mancala
{
    partial class EarningsCell
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
            this.CountStones = new Telerik.WinControls.UI.RadLabel();
            this.ContainerCell = new Telerik.WinControls.UI.RadPanel();
            ((System.ComponentModel.ISupportInitialize)(this.CountStones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContainerCell)).BeginInit();
            this.SuspendLayout();
            // 
            // CountStones
            // 
            this.CountStones.AutoSize = false;
            this.CountStones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CountStones.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CountStones.ForeColor = System.Drawing.Color.DarkRed;
            this.CountStones.Location = new System.Drawing.Point(0, 282);
            this.CountStones.Name = "CountStones";
            this.CountStones.Size = new System.Drawing.Size(100, 18);
            this.CountStones.TabIndex = 3;
            this.CountStones.Text = "0";
            this.CountStones.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.CountStones.TextChanged += new System.EventHandler(this.CountStones_TextChanged);
            // 
            // ContainerCell
            // 
            this.ContainerCell.Dock = System.Windows.Forms.DockStyle.Top;
            this.ContainerCell.Location = new System.Drawing.Point(0, 0);
            this.ContainerCell.Name = "ContainerCell";
            this.ContainerCell.Size = new System.Drawing.Size(100, 276);
            this.ContainerCell.TabIndex = 4;
            this.ContainerCell.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.ContainerCell.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.ContainerCell_ControlAdded);
            this.ContainerCell.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.ContainerCell_ControlRemoved);
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.ContainerCell.GetChildAt(0).GetChildAt(1))).Opacity = 0D;
            // 
            // EarningsCell
            // 
            this.Controls.Add(this.CountStones);
            this.Controls.Add(this.ContainerCell);
            this.Name = "EarningsCell";
            this.Size = new System.Drawing.Size(100, 300);
            ((System.ComponentModel.ISupportInitialize)(this.CountStones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContainerCell)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected Telerik.WinControls.UI.RadLabel CountStones;
        public Telerik.WinControls.UI.RadPanel ContainerCell;
    }
}
