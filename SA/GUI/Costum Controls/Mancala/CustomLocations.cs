using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telerik.WinControls.UI;

namespace SA.GUI.Costum_Controls.Mancala
{
    static class CustomLocations
    {
        private static List<Point> Points = new List<Point>()
        {
            new Point(37, 3),
            new Point(5, 19),
            new Point(62, 19),
            new Point(30, 35),
            new Point(5, 51),
            new Point(57, 47),
            new Point(30, 61),
        };
        public static Point GetRandomPoint()
        {
            Thread.Sleep(500);
            Random random = new Random((int)DateTime.Now.Ticks);
            return Points[random.Next(Points.Count)];
        }

    }
}
