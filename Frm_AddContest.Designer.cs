namespace RunningFromTheDayLight
{
    partial class Frm_AddContest
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDeleteContest = new System.Windows.Forms.Button();
            this.btnUpdateContest = new System.Windows.Forms.Button();
            this.btnAddContest = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbState = new System.Windows.Forms.ComboBox();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.cmbSubjectID = new System.Windows.Forms.ComboBox();
            this.txtContestID = new System.Windows.Forms.TextBox();
            this.dgv_ListContest = new System.Windows.Forms.DataGridView();
            this.ContestID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubjectID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateContest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeContest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ListContest)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDeleteContest);
            this.groupBox1.Controls.Add(this.btnUpdateContest);
            this.groupBox1.Controls.Add(this.btnAddContest);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbState);
            this.groupBox1.Controls.Add(this.dtpTime);
            this.groupBox1.Controls.Add(this.dtpDate);
            this.groupBox1.Controls.Add(this.cmbSubjectID);
            this.groupBox1.Controls.Add(this.txtContestID);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(630, 544);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin cuôc thi";
            // 
            // btnDeleteContest
            // 
            this.btnDeleteContest.Location = new System.Drawing.Point(368, 465);
            this.btnDeleteContest.Name = "btnDeleteContest";
            this.btnDeleteContest.Size = new System.Drawing.Size(95, 40);
            this.btnDeleteContest.TabIndex = 11;
            this.btnDeleteContest.Text = "Xóa";
            this.btnDeleteContest.UseVisualStyleBackColor = true;
            this.btnDeleteContest.Click += new System.EventHandler(this.btnDeleteContest_Click);
            // 
            // btnUpdateContest
            // 
            this.btnUpdateContest.Location = new System.Drawing.Point(208, 465);
            this.btnUpdateContest.Name = "btnUpdateContest";
            this.btnUpdateContest.Size = new System.Drawing.Size(95, 40);
            this.btnUpdateContest.TabIndex = 10;
            this.btnUpdateContest.Text = "Sửa";
            this.btnUpdateContest.UseVisualStyleBackColor = true;
            this.btnUpdateContest.Click += new System.EventHandler(this.btnUpdateContest_Click);
            // 
            // btnAddContest
            // 
            this.btnAddContest.Location = new System.Drawing.Point(46, 465);
            this.btnAddContest.Name = "btnAddContest";
            this.btnAddContest.Size = new System.Drawing.Size(95, 40);
            this.btnAddContest.TabIndex = 9;
            this.btnAddContest.Text = "Thêm";
            this.btnAddContest.UseVisualStyleBackColor = true;
            this.btnAddContest.Click += new System.EventHandler(this.btnAddContest_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(149, 381);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Trạng thái :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(62, 303);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(193, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Thời gian bắt đầu thi :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(165, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ngày thi :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(163, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Môn học :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(136, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã cuộc thi :";
            // 
            // cmbState
            // 
            this.cmbState.FormattingEnabled = true;
            this.cmbState.Items.AddRange(new object[] {
            "Đang diễn ra",
            "Chưa diễn ra",
            "Kết thúc"});
            this.cmbState.Location = new System.Drawing.Point(292, 378);
            this.cmbState.Name = "cmbState";
            this.cmbState.Size = new System.Drawing.Size(270, 28);
            this.cmbState.TabIndex = 4;
            // 
            // dtpTime
            // 
            this.dtpTime.Location = new System.Drawing.Point(292, 298);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.Size = new System.Drawing.Size(270, 27);
            this.dtpTime.TabIndex = 3;
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(292, 218);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(270, 27);
            this.dtpDate.TabIndex = 2;
            // 
            // cmbSubjectID
            // 
            this.cmbSubjectID.FormattingEnabled = true;
            this.cmbSubjectID.Location = new System.Drawing.Point(292, 135);
            this.cmbSubjectID.Name = "cmbSubjectID";
            this.cmbSubjectID.Size = new System.Drawing.Size(270, 28);
            this.cmbSubjectID.TabIndex = 1;
            // 
            // txtContestID
            // 
            this.txtContestID.Enabled = false;
            this.txtContestID.Location = new System.Drawing.Point(292, 60);
            this.txtContestID.Name = "txtContestID";
            this.txtContestID.Size = new System.Drawing.Size(100, 27);
            this.txtContestID.TabIndex = 0;
            // 
            // dgv_ListContest
            // 
            this.dgv_ListContest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ListContest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ContestID,
            this.SubjectID,
            this.DateContest,
            this.TimeContest,
            this.State});
            this.dgv_ListContest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_ListContest.Location = new System.Drawing.Point(630, 0);
            this.dgv_ListContest.Name = "dgv_ListContest";
            this.dgv_ListContest.RowHeadersWidth = 51;
            this.dgv_ListContest.RowTemplate.Height = 24;
            this.dgv_ListContest.Size = new System.Drawing.Size(1079, 544);
            this.dgv_ListContest.TabIndex = 1;
            this.dgv_ListContest.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ListContest_CellClick);
            // 
            // ContestID
            // 
            this.ContestID.HeaderText = "Mã Cuộc Thi";
            this.ContestID.MinimumWidth = 6;
            this.ContestID.Name = "ContestID";
            this.ContestID.Width = 125;
            // 
            // SubjectID
            // 
            this.SubjectID.HeaderText = "Mã Cuộc Thi";
            this.SubjectID.MinimumWidth = 6;
            this.SubjectID.Name = "SubjectID";
            this.SubjectID.Width = 125;
            // 
            // DateContest
            // 
            this.DateContest.HeaderText = "Ngày Thi";
            this.DateContest.MinimumWidth = 6;
            this.DateContest.Name = "DateContest";
            this.DateContest.Width = 125;
            // 
            // TimeContest
            // 
            this.TimeContest.HeaderText = "Thời gian thi";
            this.TimeContest.MinimumWidth = 6;
            this.TimeContest.Name = "TimeContest";
            this.TimeContest.Width = 125;
            // 
            // State
            // 
            this.State.HeaderText = "Trạng thái";
            this.State.MinimumWidth = 6;
            this.State.Name = "State";
            this.State.Width = 125;
            // 
            // Frm_AddContest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1709, 544);
            this.Controls.Add(this.dgv_ListContest);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_AddContest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm cuộc thi";
            this.Load += new System.EventHandler(this.Frm_AddContest_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ListContest)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.ComboBox cmbSubjectID;
        private System.Windows.Forms.TextBox txtContestID;
        private System.Windows.Forms.ComboBox cmbState;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDeleteContest;
        private System.Windows.Forms.Button btnUpdateContest;
        private System.Windows.Forms.Button btnAddContest;
        private System.Windows.Forms.DataGridView dgv_ListContest;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContestID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateContest;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeContest;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
    }
}