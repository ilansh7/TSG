namespace DailyPlanner
{
    partial class Calendar
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
            this.tctrlPlanner = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lvPlanner = new System.Windows.Forms.ListView();
            this.StartHour = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EndHour = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ConnectionCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UsersList = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tctrlPlanner.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tctrlPlanner
            // 
            this.tctrlPlanner.Controls.Add(this.tabPage2);
            this.tctrlPlanner.Location = new System.Drawing.Point(12, 13);
            this.tctrlPlanner.Name = "tctrlPlanner";
            this.tctrlPlanner.SelectedIndex = 0;
            this.tctrlPlanner.Size = new System.Drawing.Size(1170, 761);
            this.tctrlPlanner.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lvPlanner);
            this.tabPage2.Location = new System.Drawing.Point(10, 47);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1150, 704);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Planner";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lvPlanner
            // 
            this.lvPlanner.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.StartHour,
            this.EndHour,
            this.ConnectionCount,
            this.UsersList});
            this.lvPlanner.Location = new System.Drawing.Point(15, 19);
            this.lvPlanner.Name = "lvPlanner";
            this.lvPlanner.Size = new System.Drawing.Size(1109, 664);
            this.lvPlanner.TabIndex = 0;
            this.lvPlanner.UseCompatibleStateImageBehavior = false;
            this.lvPlanner.View = System.Windows.Forms.View.Details;
            // 
            // StartHour
            // 
            this.StartHour.Text = "Start Hour";
            this.StartHour.Width = 75;
            // 
            // EndHour
            // 
            this.EndHour.Text = "End Hour";
            this.EndHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.EndHour.Width = 75;
            // 
            // ConnectionCount
            // 
            this.ConnectionCount.Text = "Connection Count";
            this.ConnectionCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ConnectionCount.Width = 100;
            // 
            // UsersList
            // 
            this.UsersList.Text = "Names";
            this.UsersList.Width = 600;
            // 
            // Calendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 786);
            this.Controls.Add(this.tctrlPlanner);
            this.Name = "Calendar";
            this.Text = "Calendar";
            this.tctrlPlanner.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tctrlPlanner;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView lvPlanner;
        private System.Windows.Forms.ColumnHeader StartHour;
        private System.Windows.Forms.ColumnHeader EndHour;
        private System.Windows.Forms.ColumnHeader ConnectionCount;
        private System.Windows.Forms.ColumnHeader UsersList;
    }
}