using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper
{
    public partial class BestTimeForm : Form
    {

        private List<Classes.Player> _winnerList;

        public List<Classes.Player> WinnerListBestForm
        {
            get { return _winnerList; }
            set { _winnerList = value; }
        }

        public BestTimeForm()
        {
            InitializeComponent();
            _winnerList = new List<Classes.Player>();
        }

        private int _time;

        public int Time
        {
            get { return _time; }
            set { _time = value; }
        }


        private void BestTimeForm_Shown(object sender, EventArgs e)
        {
            BestTimeDataGridView.DataSource = null;
            BestTimeDataGridView.AutoGenerateColumns = false;
            BestTimeDataGridView.DataSource = _winnerList.ToList();
            
            //BestTimeDataGridView.Sort(BestTimeDataGridView.Columns[2], ListSortDirection.Descending);
        }
    }
}
