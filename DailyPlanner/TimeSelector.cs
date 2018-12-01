using BusinessLogic;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DailyPlanner
{
    public partial class TimeSelector : Form
    {
        #region Properties

        public UsersLogic userLogic = new UsersLogic();
        public string strMessage = string.Empty;

        #endregion Properties

        #region c'tor

        public TimeSelector()
        {
            InitializeComponent();

            lblStatus.Text = "";

            cbUsers.DataSource = userLogic.GetUsersList(true);
            cbUsers.DisplayMember = "LoginName";
            cbUsers.ValueMember = "UserId";
        }

        #endregion c'tor

        #region Form Methods

        #endregion Form Methods

        #region Controls Actions

        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "";
                lblUsers.BackColor = Control.DefaultBackColor;
                lblStartTime.BackColor = Control.DefaultBackColor;
                lblEndTime.BackColor = Control.DefaultBackColor;
                // Mandatory fields validation
                if (string.IsNullOrEmpty(cbStartTime.Text) || string.IsNullOrEmpty(cbEndTime.Text) || string.IsNullOrEmpty(cbUsers.Text))
                {
                    if (string.IsNullOrEmpty(cbUsers.Text))
                    {
                        strMessage = "User is Mandatory";
                        lblUsers.BackColor = Color.Red;
                    }
                    else if (string.IsNullOrEmpty(cbStartTime.Text))
                    {
                        strMessage = "Start Time is Mandatory";
                        lblStartTime.BackColor = Color.Red;
                    }
                    else if (string.IsNullOrEmpty(cbEndTime.Text))
                    {
                        strMessage = "End Time is Mandatory";
                        lblEndTime.BackColor = Color.Red;
                    }
                    lblStatus.ForeColor = Color.Red;
                    lblStatus.Text = strMessage;
                }
                else
                {
                    DateTime st = DateTime.Parse(cbStartTime.Text);
                    DateTime et = DateTime.Parse(cbEndTime.Text);
                    if (st.TimeOfDay >= et.TimeOfDay)
                    {
                        lblStatus.ForeColor = Color.Red;
                        //lblStatus.BackColor = Color.White;
                        strMessage = "End time cannot be greater than Start time";
                        lblStatus.Text = strMessage;
                        //DialogResult = DialogResult.No;
                    }
                    else if (int.Parse(cbEndTime.Text.Substring(0, 2)) - int.Parse(cbStartTime.Text.Substring(0, 2)) != 1)
                    {
                        lblStatus.ForeColor = Color.Red;
                        //lblStatus.BackColor = Color.White;
                        strMessage = "Invalid Time Range";
                        lblStatus.Text = strMessage;
                        //DialogResult = DialogResult.No;
                    }
                    else
                    {
                        string ret = (userLogic.MarkTimeFrame(int.Parse(cbUsers.SelectedValue.ToString()), cbStartTime.Text, cbEndTime.Text).ToString());
                        lblStatus.ForeColor = Color.Green;
                        //lblStatus.BackColor = Color.White;
                        strMessage = cbUsers.Text + "'s Request added successfully";
                        lblStatus.Text = strMessage;
                        //DialogResult = DialogResult.No;
                        //MessageBox.Show(ret, "Message", MessageBoxButtons.OK);
                        DialogResult = DialogResult.OK;

                        lnkTimeTable_LinkClicked(this, new LinkLabelLinkClickedEventArgs(new LinkLabel.Link()));
                    }
                }
            }
            catch
            {
                CloseLoginForm();
                throw;
            }
        }

        private void TimeSelector_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.No)
            {
                e.Cancel = true;
            }
            //e.Cancel = true;
            CloseLoginForm();
        }

        private void lnkTimeTable_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //lblStatus.Text = "";
            Calendar calendar = new Calendar(true);
            calendar.ShowDialog();
        }

        private void lnkReset_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lblStatus.Text = "";
            DialogResult dlgReset = MessageBox.Show("This action will flush the Planner. Continue ?", "Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dlgReset == DialogResult.Yes)
            { 
                userLogic.ResetConnection();
            }
        }

        #endregion Controls Actions

        #region d'tor

        public void CloseLoginForm()
        {
            // release recorces
        }
        #endregion d'tor

    }
}
