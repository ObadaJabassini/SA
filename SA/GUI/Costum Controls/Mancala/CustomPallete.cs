using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SA.GUI.Costum_Controls.Mancala
{
    static class CustomPallete
    {
        private static List<Color> Colors = new List<Color>()
        {
            Color.CornflowerBlue,
            Color.SandyBrown,
            Color.MediumSeaGreen,
            Color.Crimson,
            Color.MediumPurple,
            Color.Orange,
            Color.FromArgb(227, 71, 97),
            Color.FromArgb(115, 138, 176),
            Color.FromArgb(92, 159, 86),
            Color.FromArgb(255, 190, 64)
        };

        public static Color GetRandomColor()
        {
            Thread.Sleep(500);
            Random random = new Random((int)DateTime.Now.Ticks);
            return Colors[random.Next(Colors.Count)];
        }
    }
}
