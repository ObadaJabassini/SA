using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SA.GUI.Costum_Controls
{
    public partial class LightsCell : UserControl
    {
        public LightsCell()
        {
            InitializeComponent();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            radButton1.ThemeName = radButton1.ThemeName == this.visualStudio2012LightTheme1.ThemeName
                ? visualStudio2012DarkTheme1.ThemeName
                : visualStudio2012LightTheme1.ThemeName;
        }
    }
}
