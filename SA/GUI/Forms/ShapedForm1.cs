using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SA.GUI.Forms
{
    public partial class ShapedForm1 : Telerik.WinControls.UI.ShapedForm
    {
        public static Mancala Mancala;
        public static Lights Lights;
        public ShapedForm1()
        {
            InitializeComponent();
        //    myBackgroundWorker = new BackgroundWorker();
        //    myBackgroundWorker.WorkerReportsProgress = true;
        //    myBackgroundWorker.WorkerSupportsCancellation = true;
        //    myBackgroundWorker.DoWork += new DoWorkEventHandler(myBackgroundWorker1_DoWork);
        //    myBackgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(myBackgroundWorker1_RunWorkerCompleted);
            
        }
        //void myBackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    BackgroundWorker worker = sender as BackgroundWorker;
        //    PerformComplexComputations(worker, e);
        //}
        //private void PerformComplexComputations(BackgroundWorker worker, DoWorkEventArgs e)
        //{
        //    M = new Mancala();
        //    if (M.IsLoaded)
        //        M.Show();
        //}

        //private void myBackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{

        //}

        private void ShapedForm1_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void radLabel1_Click(object sender, EventArgs e)
        {
            Mancala = new Mancala(); Mancala.Show();
        }

        private void radPanel2_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void radPanel2_Click(object sender, EventArgs e)
        {
            Lights = new Lights(); Lights.Show();
        }

        private void radLabel2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
