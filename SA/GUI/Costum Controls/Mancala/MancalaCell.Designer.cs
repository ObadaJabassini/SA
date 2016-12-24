namespace SA.GUI.Costum_Controls.Mancala
{
    partial class MancalaCell
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ContainerCell = new Telerik.WinControls.UI.RadPanel();
            this.CountStones = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ContainerCell)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CountStones)).BeginInit();
            this.SuspendLayout();
            // 
            // ContainerCell
            // 
            this.ContainerCell.Dock = System.Windows.Forms.DockStyle.Top;
            this.ContainerCell.Location = new System.Drawing.Point(0, 0);
            this.ContainerCell.Name = "ContainerCell";
            this.ContainerCell.Size = new System.Drawing.Size(100, 100);
            this.ContainerCell.TabIndex = 0;
            this.ContainerCell.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.ContainerCell.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.ContainerCell_ControlAdded);
            this.ContainerCell.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.ContainerCell_ControlRemoved);
            // 
            // CountStones
            // 
            this.CountStones.AutoSize = false;
            this.CountStones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CountStones.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.CountStones.ForeColor = System.Drawing.Color.Firebrick;
            this.CountStones.Location = new System.Drawing.Point(0, 101);
            this.CountStones.Name = "CountStones";
            this.CountStones.Size = new System.Drawing.Size(100, 18);
            this.CountStones.TabIndex = 0;
            this.CountStones.Text = "0";
            this.CountStones.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MancalaCell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CountStones);
            this.Controls.Add(this.ContainerCell);
            this.Name = "MancalaCell";
            this.Size = new System.Drawing.Size(100, 119);
            this.Load += new System.EventHandler(this.MancalaCell_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ContainerCell)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CountStones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected Telerik.WinControls.UI.RadPanel ContainerCell;
        protected Telerik.WinControls.UI.RadLabel CountStones;

    }
}
