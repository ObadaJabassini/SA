﻿using SA.LightsOut;
using SA.LightsOut.LineraAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SA.Mancala;

namespace SA
{
    static class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            //var b = new Node.State[,] { { Node.State.ON, Node.State.ON, Node.State.ON}, { Node.State.ON, Node.State.OFF, Node.State.ON }, { Node.State.OFF, Node.State.OFF, Node.State.OFF } };
            ////var b = new Node.State[,] { { Node.State.OFF, Node.State.ON, Node.State.ON}, { Node.State.OFF, Node.State.OFF, Node.State.ON }, { Node.State.OFF, Node.State.OFF, Node.State.OFF } };
            //var sol = new BFS() { Initial = b }.Solve(BFS.SolveMethod.ASYNC).ToList();
            //if(sol.Count == 0)
            //    Console.WriteLine("No Solutions have been found");
            //else
            //    sol.ForEach(Console.WriteLine);
            //Console.ReadKey();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GUI.Forms.Lights());
            Application.Run(new GUI.Forms.Mancala());

            //int[,] tt = new int[5, 5];
            //for (int i = 0; i < 5; i++)
            //{
            //    for (int j = 0; j < 5; j++)
            //    {
            //        tt[i, j] = 0;
            //    }
            //}
            //tt[0, 0] = 1;
            //var t = new Board() { Game = tt};
            //var b = new Board() { Game = new int[,] { { 1, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } } };
            //var bb = new Board() { Game = new int[,] { { 1, 1, 1 }, { 1, 0, 1 }, { 0, 0, 0 } } };
            //SolutionMethod method = new BFS() { Initial = t};
            //var sol = method.Solve().ToList();
            //if (sol.Count == 0)
            //    Console.WriteLine("No Solutions have been found");
            //else
            //    sol.ForEach(Console.WriteLine);
            ////Game g = new Game();
            ////g.Play();
            //Console.ReadKey();
        }
    }
}
