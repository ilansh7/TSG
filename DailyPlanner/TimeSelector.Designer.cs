namespace DailyPlanner
{
    partial class TimeSelector
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblUser = new System.Windows.Forms.Label();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.btnAddRecord = new System.Windows.Forms.Button();
            this.lblUsers = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lnkTimeTable = new System.Windows.Forms.LinkLabel();
            this.cbUsers = new System.Windows.Forms.ComboBox();
            this.cbStartTime = new System.Windows.Forms.ComboBox();
            this.cbEndTime = new System.Windows.Forms.ComboBox();
            this.lnkReset = new System.Windows.Forms.LinkLabel();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(166, 58);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(76, 29);
            this.lblUser.TabIndex = 3;
            this.lblUser.Text = "User :";
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(166, 189);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(130, 29);
            this.lblEndTime.TabIndex = 5;
            this.lblEndTime.Text = "End Time :";
            // 
            // btnAddRecord
            // 
            this.btnAddRecord.Location = new System.Drawing.Point(209, 266);
            this.btnAddRecord.Name = "btnAddRecord";
            this.btnAddRecord.Size = new System.Drawing.Size(184, 59);
            this.btnAddRecord.TabIndex = 6;
            this.btnAddRecord.Text = "Add Record";
            this.btnAddRecord.UseVisualStyleBackColor = true;
            this.btnAddRecord.Click += new System.EventHandler(this.btnAddRecord_Click);
            // 
            // lblUsers
            // 
            this.lblUsers.AutoSize = true;
            this.lblUsers.Location = new System.Drawing.Point(166, 61);
            this.lblUsers.Name = "lblUsers";
            this.lblUsers.Size = new System.Drawing.Size(76, 29);
            this.lblUsers.TabIndex = 3;
            this.lblUsers.Text = "User :";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(40, 403);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(79, 29);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Status";
            // 
            // lnkTimeTable
            // 
            this.lnkTimeTable.AutoSize = true;
            this.lnkTimeTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lnkTimeTable.Location = new System.Drawing.Point(203, 345);
            this.lnkTimeTable.Name = "lnkTimeTable";
            this.lnkTimeTable.Size = new System.Drawing.Size(212, 31);
            this.lnkTimeTable.TabIndex = 8;
            this.lnkTimeTable.TabStop = true;
            this.lnkTimeTable.Text = "Show Calendar";
            this.lnkTimeTable.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkTimeTable_LinkClicked);
            // 
            // cbUsers
            // 
            this.cbUsers.FormattingEnabled = true;
            this.cbUsers.Location = new System.Drawing.Point(280, 57);
            this.cbUsers.Name = "cbUsers";
            this.cbUsers.Size = new System.Drawing.Size(256, 37);
            this.cbUsers.TabIndex = 9;
            // 
            // cbStartTime
            // 
            this.cbStartTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStartTime.FormattingEnabled = true;
            this.cbStartTime.Items.AddRange(new object[] {
            "07:00",
            "08:00",
            "09:00",
            "10:00",
            "11:00",
            "12:00",
            "13:00",
            "14:00",
            "15:00",
            "16:00",
            "17:00",
            "18:00",
            "19:00"});
            this.cbStartTime.Location = new System.Drawing.Point(336, 121);
            this.cbStartTime.Name = "cbStartTime";
            this.cbStartTime.Size = new System.Drawing.Size(200, 37);
            this.cbStartTime.TabIndex = 10;
            // 
            // cbEndTime
            // 
            this.cbEndTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEndTime.FormattingEnabled = true;
            this.cbEndTime.Items.AddRange(new object[] {
            "07:00",
            "08:00",
            "09:00",
            "10:00",
            "11:00",
            "12:00",
            "13:00",
            "14:00",
            "15:00",
            "16:00",
            "17:00",
            "18:00",
            "19:00"});
            this.cbEndTime.Location = new System.Drawing.Point(336, 185);
            this.cbEndTime.Name = "cbEndTime";
            this.cbEndTime.Size = new System.Drawing.Size(200, 37);
            this.cbEndTime.TabIndex = 11;
            // 
            // lnkReset
            // 
            this.lnkReset.AutoSize = true;
            this.lnkReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkReset.ForeColor = System.Drawing.Color.Black;
            this.lnkReset.LinkColor = System.Drawing.Color.Red;
            this.lnkReset.Location = new System.Drawing.Point(540, 348);
            this.lnkReset.Name = "lnkReset";
            this.lnkReset.Size = new System.Drawing.Size(81, 29);
            this.lnkReset.TabIndex = 12;
            this.lnkReset.TabStop = true;
            this.lnkReset.Text = "Reset";
            this.lnkReset.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnkReset.VisitedLinkColor = System.Drawing.Color.Red;
            this.lnkReset.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkReset_LinkClicked);
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(166, 125);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(136, 29);
            this.lblStartTime.TabIndex = 13;
            this.lblStartTime.Text = "Start Time :";
            // 
            // TimeSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 450);
            this.Controls.Add(this.lblStartTime);
            this.Controls.Add(this.lnkReset);
            this.Controls.Add(this.cbEndTime);
            this.Controls.Add(this.cbStartTime);
            this.Controls.Add(this.cbUsers);
            this.Controls.Add(this.lnkTimeTable);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnAddRecord);
            this.Controls.Add(this.lblEndTime);
            this.Controls.Add(this.lblUsers);
            this.Controls.Add(this.lblUser);
            this.Name = "TimeSelector";
            this.Text = "Time Planner";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TimeSelector_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblUser;
        //private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.Button btnAddRecord;
        private System.Windows.Forms.Label lblUsers;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.LinkLabel lnkTimeTable;
        private System.Windows.Forms.ComboBox cbUsers;
        private System.Windows.Forms.ComboBox cbStartTime;
        private System.Windows.Forms.ComboBox cbEndTime;
        private System.Windows.Forms.LinkLabel lnkReset;
        private System.Windows.Forms.Label lblStartTime;
    }
}

