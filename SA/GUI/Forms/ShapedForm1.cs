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
        private Mancala M;
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

            M = new Mancala();

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (M.IsLoaded)
            {
                M.Show();
                this.Hide();
            }
        }
    }
}
