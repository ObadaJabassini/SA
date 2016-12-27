namespace SA.GUI.Costum_Controls.Mancala
{
    partial class Stone
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
            this._stone = new Telerik.WinControls.UI.RadButton();
            this.aquaTheme1 = new Telerik.WinControls.Themes.AquaTheme();
            this.ellipseShape1 = new Telerik.WinControls.EllipseShape();
            ((System.ComponentModel.ISupportInitialize)(this._stone)).BeginInit();
            this.SuspendLayout();
            // 
            // _stone
            // 
            this._stone.BackColor = System.Drawing.Color.Transparent;
            this._stone.Location = new System.Drawing.Point(0, 0);
            this._stone.Name = "_stone";
            // 
            // 
            // 
            this._stone.RootElement.Shape = this.ellipseShape1;
            this._stone.Size = new System.Drawing.Size(26, 25);
            this._stone.TabIndex = 0;
            this._stone.ThemeName = "Aqua";
            ((Telerik.WinControls.UI.RadButtonElement)(this._stone.GetChildAt(0))).Text = "";
            ((Telerik.WinControls.UI.RadButtonElement)(this._stone.GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            ((Telerik.WinControls.UI.RadButtonElement)(this._stone.GetChildAt(0))).Shape = this.ellipseShape1;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this._stone.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this._stone.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this._stone.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this._stone.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this._stone.GetChildAt(0).GetChildAt(0))).ClipDrawing = true;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this._stone.GetChildAt(0).GetChildAt(0))).Shape = this.ellipseShape1;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this._stone.GetChildAt(0).GetChildAt(1).GetChildAt(1))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this._stone.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this._stone.GetChildAt(0).GetChildAt(2))).Opacity = 0D;
            // 
            // Stone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this._stone);
            this.Name = "Stone";
            this.Size = new System.Drawing.Size(26, 26);
            ((System.ComponentModel.ISupportInitialize)(this._stone)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadButton _stone;
        private Telerik.WinControls.Themes.AquaTheme aquaTheme1;
        private Telerik.WinControls.EllipseShape ellipseShape1;
    }
}
