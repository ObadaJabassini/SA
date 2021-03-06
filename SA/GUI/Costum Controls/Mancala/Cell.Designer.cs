﻿namespace SA.GUI.Costum_Controls.Mancala
{
    partial class Cell
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
            this.CountStones.Location = new System.Drawing.Point(0, 102);
            this.CountStones.Name = "CountStones";
            this.CountStones.Size = new System.Drawing.Size(100, 18);
            this.CountStones.TabIndex = 1;
            this.CountStones.Text = "0";
            this.CountStones.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.CountStones.TextChanged += new System.EventHandler(this.CountStones_TextChanged);
            this.CountStones.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.ContainerCell_ControlAdded);
            this.CountStones.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.ContainerCell_ControlRemoved);
            // 
            // ContainerCell
            // 
            this.ContainerCell.Dock = System.Windows.Forms.DockStyle.Top;
            this.ContainerCell.Location = new System.Drawing.Point(0, 0);
            this.ContainerCell.Name = "ContainerCell";
            this.ContainerCell.Size = new System.Drawing.Size(100, 100);
            this.ContainerCell.TabIndex = 2;
            this.ContainerCell.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.ContainerCell.Click += new System.EventHandler(this.ContainerCell_Click);
            this.ContainerCell.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.ContainerCell_ControlAdded_1);
            this.ContainerCell.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.ContainerCell_ControlRemoved);
            this.ContainerCell.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ContainerCell_MouseUp);
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.ContainerCell.GetChildAt(0).GetChildAt(1))).Opacity = 0D;
            // 
            // Cell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CountStones);
            this.Controls.Add(this.ContainerCell);
            this.Name = "Cell";
            this.Size = new System.Drawing.Size(100, 120);
            this.Load += new System.EventHandler(this.Cell_Load);
            this.Click += new System.EventHandler(this.Cell_Click);
            ((System.ComponentModel.ISupportInitialize)(this.CountStones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContainerCell)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected Telerik.WinControls.UI.RadLabel CountStones;
        internal Telerik.WinControls.UI.RadPanel ContainerCell;

    }
}
