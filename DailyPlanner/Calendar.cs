using BusinessLogic;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace DailyPlanner
{
    public partial class Calendar : Form
    {
        #region Properties

        public UsersLogic userLogic = new UsersLogic();

        #endregion

        #region c'tor

        public Calendar()
        {
            InitializeComponent();
            getPlannerData(0, string.Empty, string.Empty);

            TimeSelector timeSelector = new TimeSelector();
            //timeSelector.ShowDialog();

            if (timeSelector.DialogResult == DialogResult.OK)
            {
                Trace.WriteLine("timeSelector btnOK");
            }

            if (timeSelector.DialogResult == DialogResult.Cancel)
            {
                Trace.WriteLine("timeSelector btnCancel");
                //timeSelector.ShowDialog();
            }

            if (timeSelector.DialogResult == DialogResult.No)
            {
                Trace.WriteLine("timeSelector btnNo");
                //timeSelector.ShowDialog();
                //return;
            }
        }

        public Calendar(bool Flag)
        {
            InitializeComponent();
            getPlannerData(0, string.Empty, string.Empty);
        }

        #endregion

        #region Actions

        public void getPlannerData(int Id, string sTime, string eTime)
        {
            DataTable dt = userLogic.GetPlannerData(Id, sTime, eTime);
            //int fc = dt.Columns.Count;

            lvPlanner.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["StartHour"].ToString());
                item.SubItems.Add(row["EndHour"].ToString());
                item.SubItems.Add(row["ConnectionCount"].ToString());
                item.SubItems.Add(row["UsersList"].ToString());

                lvPlanner.Items.Add(item);
            }
        }

        #endregion

        #region Form Methods

        //private void ServerForm_Load(object sender, EventArgs e)
        //{

        //}

        #endregion

        #region Controls

        #endregion

        #region d'tor

        //private void DropCalendar()
        //{
        //        this.Dispose();
        //}

        #endregion
    }
    }
