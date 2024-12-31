namespace RunningFromTheDayLight
{
    partial class Frm_ExamSchedule
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
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbRoomID = new System.Windows.Forms.ComboBox();
            this.txtTimeExam = new System.Windows.Forms.TextBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.cmbSubjectID = new System.Windows.Forms.ComboBox();
            this.cmbStudentID = new System.Windows.Forms.ComboBox();
            this.dgvListExaam = new System.Windows.Forms.DataGridView();
            this.btnAddExam = new System.Windows.Forms.Button();
            this.btnDeleteExam = new System.Windows.Forms.Button();
            this.btnUpdateExam = new System.Windows.Forms.Button();
            this.ExamScheduleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubjectID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateExam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeExam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.txtExaScheduleID = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListExaam)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtExaScheduleID);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnUpdateExam);
            this.groupBox1.Controls.Add(this.btnDeleteExam);
            this.groupBox1.Controls.Add(this.btnAddExam);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbRoomID);
            this.groupBox1.Controls.Add(this.txtTimeExam);
            this.groupBox1.Controls.Add(this.dtpDate);
            this.groupBox1.Controls.Add(this.cmbSubjectID);
            this.groupBox1.Controls.Add(this.cmbStudentID);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(459, 567);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin lịch thi";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 426);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Phòng thi :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 351);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Thời gian thi :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 276);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ngày thi :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Mã môn học :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "MSSV :";
            // 
            // cmbRoomID
            // 
            this.cmbRoomID.FormattingEnabled = true;
            this.cmbRoomID.Location = new System.Drawing.Point(170, 423);
            this.cmbRoomID.Name = "cmbRoomID";
            this.cmbRoomID.Size = new System.Drawing.Size(276, 28);
            this.cmbRoomID.TabIndex = 4;
            // 
            // txtTimeExam
            // 
            this.txtTimeExam.Location = new System.Drawing.Point(170, 348);
            this.txtTimeExam.Name = "txtTimeExam";
            this.txtTimeExam.Size = new System.Drawing.Size(204, 27);
            this.txtTimeExam.TabIndex = 3;
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(170, 271);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(276, 27);
            this.dtpDate.TabIndex = 2;
            // 
            // cmbSubjectID
            // 
            this.cmbSubjectID.FormattingEnabled = true;
            this.cmbSubjectID.Location = new System.Drawing.Point(170, 197);
            this.cmbSubjectID.Name = "cmbSubjectID";
            this.cmbSubjectID.Size = new System.Drawing.Size(276, 28);
            this.cmbSubjectID.TabIndex = 1;
            // 
            // cmbStudentID
            // 
            this.cmbStudentID.FormattingEnabled = true;
            this.cmbStudentID.Location = new System.Drawing.Point(170, 121);
            this.cmbStudentID.Name = "cmbStudentID";
            this.cmbStudentID.Size = new System.Drawing.Size(276, 28);
            this.cmbStudentID.TabIndex = 0;
            // 
            // dgvListExaam
            // 
            this.dgvListExaam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListExaam.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ExamScheduleID,
            this.StudentID,
            this.SubjectID,
            this.DateExam,
            this.TimeExam,
            this.RoomID});
            this.dgvListExaam.Dock = System.Windows.Forms.DockStyle.Right;
            this.dgvListExaam.Location = new System.Drawing.Point(465, 0);
            this.dgvListExaam.Name = "dgvListExaam";
            this.dgvListExaam.RowHeadersWidth = 51;
            this.dgvListExaam.RowTemplate.Height = 24;
            this.dgvListExaam.Size = new System.Drawing.Size(1083, 567);
            this.dgvListExaam.TabIndex = 1;
            this.dgvListExaam.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListExaam_CellClick);
            // 
            // btnAddExam
            // 
            this.btnAddExam.Location = new System.Drawing.Point(60, 502);
            this.btnAddExam.Name = "btnAddExam";
            this.btnAddExam.Size = new System.Drawing.Size(75, 41);
            this.btnAddExam.TabIndex = 9;
            this.btnAddExam.Text = "Thêm";
            this.btnAddExam.UseVisualStyleBackColor = true;
            this.btnAddExam.Click += new System.EventHandler(this.btnAddExam_Click);
            // 
            // btnDeleteExam
            // 
            this.btnDeleteExam.Location = new System.Drawing.Point(331, 502);
            this.btnDeleteExam.Name = "btnDeleteExam";
            this.btnDeleteExam.Size = new System.Drawing.Size(75, 41);
            this.btnDeleteExam.TabIndex = 10;
            this.btnDeleteExam.Text = "Xóa";
            this.btnDeleteExam.UseVisualStyleBackColor = true;
            this.btnDeleteExam.Click += new System.EventHandler(this.btnDeleteExam_Click);
            // 
            // btnUpdateExam
            // 
            this.btnUpdateExam.Location = new System.Drawing.Point(197, 502);
            this.btnUpdateExam.Name = "btnUpdateExam";
            this.btnUpdateExam.Size = new System.Drawing.Size(75, 41);
            this.btnUpdateExam.TabIndex = 11;
            this.btnUpdateExam.Text = "Sửa";
            this.btnUpdateExam.UseVisualStyleBackColor = true;
            this.btnUpdateExam.Click += new System.EventHandler(this.btnUpdateExam_Click);
            // 
            // ExamScheduleID
            // 
            this.ExamScheduleID.HeaderText = "Mã Lịch Thi";
            this.ExamScheduleID.MinimumWidth = 6;
            this.ExamScheduleID.Name = "ExamScheduleID";
            this.ExamScheduleID.Width = 125;
            // 
            // StudentID
            // 
            this.StudentID.HeaderText = "MSSV";
            this.StudentID.MinimumWidth = 6;
            this.StudentID.Name = "StudentID";
            this.StudentID.Width = 125;
            // 
            // SubjectID
            // 
            this.SubjectID.HeaderText = "Mã Môn";
            this.SubjectID.MinimumWidth = 6;
            this.SubjectID.Name = "SubjectID";
            this.SubjectID.Width = 125;
            // 
            // DateExam
            // 
            this.DateExam.HeaderText = "Thời gian bắt đầu";
            this.DateExam.MinimumWidth = 6;
            this.DateExam.Name = "DateExam";
            this.DateExam.Width = 150;
            // 
            // TimeExam
            // 
            this.TimeExam.HeaderText = "Thời gian thi";
            this.TimeExam.MinimumWidth = 6;
            this.TimeExam.Name = "TimeExam";
            this.TimeExam.Width = 125;
            // 
            // RoomID
            // 
            this.RoomID.HeaderText = "Mã Phòng";
            this.RoomID.MinimumWidth = 6;
            this.RoomID.Name = "RoomID";
            this.RoomID.Width = 125;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Mã lịch thi :";
            // 
            // txtExaScheduleID
            // 
            this.txtExaScheduleID.Enabled = false;
            this.txtExaScheduleID.Location = new System.Drawing.Point(170, 58);
            this.txtExaScheduleID.Name = "txtExaScheduleID";
            this.txtExaScheduleID.Size = new System.Drawing.Size(102, 27);
            this.txtExaScheduleID.TabIndex = 13;
            // 
            // Frm_AddContest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1548, 567);
            this.Controls.Add(this.dgvListExaam);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_AddContest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm Lịch Thi";
            this.Load += new System.EventHandler(this.Frm_AddContest_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListExaam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbStudentID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbRoomID;
        private System.Windows.Forms.TextBox txtTimeExam;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.ComboBox cmbSubjectID;
        private System.Windows.Forms.Button btnDeleteExam;
        private System.Windows.Forms.Button btnAddExam;
        private System.Windows.Forms.DataGridView dgvListExaam;
        private System.Windows.Forms.Button btnUpdateExam;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExamScheduleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateExam;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeExam;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomID;
        private System.Windows.Forms.TextBox txtExaScheduleID;
        private System.Windows.Forms.Label label6;
    }
}