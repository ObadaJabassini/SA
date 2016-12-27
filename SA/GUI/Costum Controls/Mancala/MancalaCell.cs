using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SA.GUI.Costum_Controls.Mancala
{
    public partial class MancalaCell : UserControl
    {

        public MancalaCell()
        {
            InitializeComponent();
        }

        private void ContainerCell_ControlAdded(object sender, ControlEventArgs e)
        {
            this.CountStones.Text = ContainerCell.Controls.Count.ToString();
        }

        private void ContainerCell_ControlRemoved(object sender, ControlEventArgs e)
        {
            this.CountStones.Text = ContainerCell.Controls.Count.ToString();
        }

        private void MancalaCell_Load(object sender, EventArgs e)
        {
            int count = 4;

            for (int i = 0; i < count; i++)
                this.ContainerCell.Controls.Add(new Stone());
            //this.ContainerCell.Controls.Add(new FlatStone());

            this.CountStones.Text = ContainerCell.Controls.Count.ToString();
        }

        //public IEnumerator<Stone> GetEnumerator()
        //{
        //    throw new NotImplementedException();
        //}

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return GetEnumerator();
        //}

        //public void Add(Stone item)
        //{
        //    ContainerCell.Controls.Add(item);
        //    this.CountStones.Text = this.Count.ToString();
        //}

        //public void Clear()
        //{
        //    this.ContainerCell.Controls.Clear();
        //}

        //public bool Contains(Stone item)
        //{
        //    this.CountStones.Text = "0";
        //    return ContainerCell.Controls.Contains(item);
        //}

        //public void CopyTo(Stone[] array, int arrayIndex)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool Remove(Stone item)
        //{
        //    if (this.Contains(item))
        //    {
        //        this.ContainerCell.Controls.Remove(item);
        //        return true;
        //    }
        //    return false;
        //}

        //public int Count { get; private set; }
        //public bool IsReadOnly { get; private set; }
        //public int IndexOf(Stone item)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Insert(int index, Stone item)
        //{
        //    throw new NotImplementedException();
        //}

        //public void RemoveAt(int index)
        //{
        //    throw new NotImplementedException();
        //}

        //public Stone this[int index]
        //{
        //    get { throw new NotImplementedException(); }
        //    set { throw new NotImplementedException(); }
        //}
    }
}
