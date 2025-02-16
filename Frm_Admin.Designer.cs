﻿namespace RunningFromTheDayLight
{
    partial class Frm_Admin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Admin));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStrip_btnHome = new System.Windows.Forms.ToolStripButton();
            this.toolStrip_btnListStudent = new System.Windows.Forms.ToolStripButton();
            this.toolStrip_btnTeacher = new System.Windows.Forms.ToolStripButton();
            this.toolStrip_btnAddMajor = new System.Windows.Forms.ToolStripButton();
            this.toolStrip_btnSuject = new System.Windows.Forms.ToolStripButton();
            this.toolStrip_btnExam = new System.Windows.Forms.ToolStripButton();
            this.toolStrip_btnAddExaSchedule = new System.Windows.Forms.ToolStripButton();
            this.toolStrip_btnScore = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgv_ListUser = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnUpFile = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbFaculty = new System.Windows.Forms.ComboBox();
            this.cmbDecntralization = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNameID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnNoSave = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ListUser)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.DimGray;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_btnHome,
            this.toolStrip_btnListStudent,
            this.toolStrip_btnTeacher,
            this.toolStrip_btnAddMajor,
            this.toolStrip_btnSuject,
            this.toolStrip_btnExam,
            this.toolStrip_btnAddExaSchedule,
            this.toolStrip_btnScore});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(171, 757);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStrip_btnHome
            // 
            this.toolStrip_btnHome.AutoSize = false;
            this.toolStrip_btnHome.AutoToolTip = false;
            this.toolStrip_btnHome.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStrip_btnHome.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStrip_btnHome.Image = ((System.Drawing.Image)(resources.GetObject("toolStrip_btnHome.Image")));
            this.toolStrip_btnHome.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStrip_btnHome.Name = "toolStrip_btnHome";
            this.toolStrip_btnHome.Size = new System.Drawing.Size(175, 50);
            this.toolStrip_btnHome.Text = "Home";
            this.toolStrip_btnHome.Click += new System.EventHandler(this.toolStrip_btnHome_Click);
            // 
            // toolStrip_btnListStudent
            // 
            this.toolStrip_btnListStudent.AutoSize = false;
            this.toolStrip_btnListStudent.AutoToolTip = false;
            this.toolStrip_btnListStudent.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStrip_btnListStudent.Image = ((System.Drawing.Image)(resources.GetObject("toolStrip_btnListStudent.Image")));
            this.toolStrip_btnListStudent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStrip_btnListStudent.Name = "toolStrip_btnListStudent";
            this.toolStrip_btnListStudent.Size = new System.Drawing.Size(175, 50);
            this.toolStrip_btnListStudent.Text = "DS Sinh Viên";
            this.toolStrip_btnListStudent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStrip_btnListStudent.Click += new System.EventHandler(this.toolStrip_btnListStudent_Click);
            // 
            // toolStrip_btnTeacher
            // 
            this.toolStrip_btnTeacher.AutoSize = false;
            this.toolStrip_btnTeacher.AutoToolTip = false;
            this.toolStrip_btnTeacher.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStrip_btnTeacher.Image = ((System.Drawing.Image)(resources.GetObject("toolStrip_btnTeacher.Image")));
            this.toolStrip_btnTeacher.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStrip_btnTeacher.Name = "toolStrip_btnTeacher";
            this.toolStrip_btnTeacher.Size = new System.Drawing.Size(175, 50);
            this.toolStrip_btnTeacher.Text = "DS Giảng Viên";
            this.toolStrip_btnTeacher.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStrip_btnTeacher.Click += new System.EventHandler(this.toolStrip_btnTeacher_Click);
            // 
            // toolStrip_btnAddMajor
            // 
            this.toolStrip_btnAddMajor.AutoSize = false;
            this.toolStrip_btnAddMajor.AutoToolTip = false;
            this.toolStrip_btnAddMajor.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStrip_btnAddMajor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStrip_btnAddMajor.Image = ((System.Drawing.Image)(resources.GetObject("toolStrip_btnAddMajor.Image")));
            this.toolStrip_btnAddMajor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStrip_btnAddMajor.Name = "toolStrip_btnAddMajor";
            this.toolStrip_btnAddMajor.Size = new System.Drawing.Size(175, 50);
            this.toolStrip_btnAddMajor.Text = "Thêm ngành học";
            this.toolStrip_btnAddMajor.Click += new System.EventHandler(this.toolStrip_btnAddMajor_Click);
            // 
            // toolStrip_btnSuject
            // 
            this.toolStrip_btnSuject.AutoSize = false;
            this.toolStrip_btnSuject.AutoToolTip = false;
            this.toolStrip_btnSuject.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStrip_btnSuject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStrip_btnSuject.Image = ((System.Drawing.Image)(resources.GetObject("toolStrip_btnSuject.Image")));
            this.toolStrip_btnSuject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStrip_btnSuject.Name = "toolStrip_btnSuject";
            this.toolStrip_btnSuject.Size = new System.Drawing.Size(175, 50);
            this.toolStrip_btnSuject.Text = "Thêm môn học";
            this.toolStrip_btnSuject.Click += new System.EventHandler(this.toolStrip_btnSuject_Click);
            // 
            // toolStrip_btnExam
            // 
            this.toolStrip_btnExam.AutoSize = false;
            this.toolStrip_btnExam.AutoToolTip = false;
            this.toolStrip_btnExam.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStrip_btnExam.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStrip_btnExam.Image = ((System.Drawing.Image)(resources.GetObject("toolStrip_btnExam.Image")));
            this.toolStrip_btnExam.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStrip_btnExam.Name = "toolStrip_btnExam";
            this.toolStrip_btnExam.Size = new System.Drawing.Size(175, 50);
            this.toolStrip_btnExam.Text = "Thêm cuộc thi";
            this.toolStrip_btnExam.Click += new System.EventHandler(this.toolStrip_btnAddExam_Click);
            // 
            // toolStrip_btnAddExaSchedule
            // 
            this.toolStrip_btnAddExaSchedule.AutoSize = false;
            this.toolStrip_btnAddExaSchedule.AutoToolTip = false;
            this.toolStrip_btnAddExaSchedule.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStrip_btnAddExaSchedule.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStrip_btnAddExaSchedule.Image = ((System.Drawing.Image)(resources.GetObject("toolStrip_btnAddExaSchedule.Image")));
            this.toolStrip_btnAddExaSchedule.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStrip_btnAddExaSchedule.Name = "toolStrip_btnAddExaSchedule";
            this.toolStrip_btnAddExaSchedule.Size = new System.Drawing.Size(175, 50);
            this.toolStrip_btnAddExaSchedule.Text = "Thêm lịch thi";
            this.toolStrip_btnAddExaSchedule.Click += new System.EventHandler(this.toolStrip_btnAddExaSchedule_Click);
            // 
            // toolStrip_btnScore
            // 
            this.toolStrip_btnScore.AutoSize = false;
            this.toolStrip_btnScore.AutoToolTip = false;
            this.toolStrip_btnScore.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStrip_btnScore.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStrip_btnScore.Image = ((System.Drawing.Image)(resources.GetObject("toolStrip_btnScore.Image")));
            this.toolStrip_btnScore.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStrip_btnScore.Name = "toolStrip_btnScore";
            this.toolStrip_btnScore.Size = new System.Drawing.Size(175, 50);
            this.toolStrip_btnScore.Text = "Thống kê điểm";
            this.toolStrip_btnScore.Click += new System.EventHandler(this.toolStrip_btnScore_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(349, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tìm kiếm :";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.Gray;
            this.txtSearch.Location = new System.Drawing.Point(452, 27);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(360, 27);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.Text = "Tìm kiếm theo Tên/Username/UserID";
            this.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // dgv_ListUser
            // 
            this.dgv_ListUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ListUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            this.dgv_ListUser.Location = new System.Drawing.Point(187, 66);
            this.dgv_ListUser.Name = "dgv_ListUser";
            this.dgv_ListUser.RowHeadersWidth = 51;
            this.dgv_ListUser.RowTemplate.Height = 24;
            this.dgv_ListUser.Size = new System.Drawing.Size(1381, 355);
            this.dgv_ListUser.TabIndex = 4;
            this.dgv_ListUser.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_List_CellClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "UserID";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Username";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Password";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Họ tên";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 125;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Ngày sinh";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 125;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Giới tính";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 125;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Khoa";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 125;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Phân quyền";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 120;
            // 
            // btnUpFile
            // 
            this.btnUpFile.Location = new System.Drawing.Point(870, 22);
            this.btnUpFile.Name = "btnUpFile";
            this.btnUpFile.Size = new System.Drawing.Size(88, 38);
            this.btnUpFile.TabIndex = 6;
            this.btnUpFile.Text = "Up File";
            this.btnUpFile.UseVisualStyleBackColor = true;
            this.btnUpFile.Click += new System.EventHandler(this.btnUpFile_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(1011, 22);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(88, 38);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.cmbFaculty);
            this.groupBox1.Controls.Add(this.cmbDecntralization);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.dtpDate);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.rbFemale);
            this.groupBox1.Controls.Add(this.rbMale);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtPass);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtNameID);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(187, 444);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(771, 301);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // cmbFaculty
            // 
            this.cmbFaculty.FormattingEnabled = true;
            this.cmbFaculty.Location = new System.Drawing.Point(473, 168);
            this.cmbFaculty.Name = "cmbFaculty";
            this.cmbFaculty.Size = new System.Drawing.Size(240, 24);
            this.cmbFaculty.TabIndex = 17;
            // 
            // cmbDecntralization
            // 
            this.cmbDecntralization.FormattingEnabled = true;
            this.cmbDecntralization.Items.AddRange(new object[] {
            "SinhVien",
            "GiangVien"});
            this.cmbDecntralization.Location = new System.Drawing.Point(473, 232);
            this.cmbDecntralization.Name = "cmbDecntralization";
            this.cmbDecntralization.Size = new System.Drawing.Size(240, 24);
            this.cmbDecntralization.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(364, 233);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 18);
            this.label9.TabIndex = 15;
            this.label9.Text = "Phân quyền";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(364, 172);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 18);
            this.label8.TabIndex = 13;
            this.label8.Text = "Khoa";
            // 
            // dtpDate
            // 
            this.dtpDate.Checked = false;
            this.dtpDate.Location = new System.Drawing.Point(473, 101);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(240, 22);
            this.dtpDate.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(364, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 18);
            this.label7.TabIndex = 11;
            this.label7.Text = "Ngày Sinh";
            // 
            // rbFemale
            // 
            this.rbFemale.AutoSize = true;
            this.rbFemale.Location = new System.Drawing.Point(580, 41);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(45, 20);
            this.rbFemale.TabIndex = 10;
            this.rbFemale.TabStop = true;
            this.rbFemale.Text = "Nữ";
            this.rbFemale.UseVisualStyleBackColor = true;
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.Location = new System.Drawing.Point(473, 41);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(57, 20);
            this.rbMale.TabIndex = 9;
            this.rbMale.TabStop = true;
            this.rbMale.Text = "Nam";
            this.rbMale.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(364, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 18);
            this.label6.TabIndex = 8;
            this.label6.Text = "GIới tính";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(123, 229);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(183, 22);
            this.txtName.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(25, 233);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 18);
            this.label5.TabIndex = 6;
            this.label5.Text = "Họ tên";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(123, 168);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(183, 22);
            this.txtPass.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "Password";
            // 
            // txtNameID
            // 
            this.txtNameID.Location = new System.Drawing.Point(123, 100);
            this.txtNameID.Name = "txtNameID";
            this.txtNameID.Size = new System.Drawing.Size(183, 22);
            this.txtNameID.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Usename";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(123, 37);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(183, 22);
            this.txtID.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "UserID";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(1011, 517);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(133, 50);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(1213, 516);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(133, 50);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Text = "Sửa ";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(1011, 612);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(133, 50);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(1213, 612);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(133, 50);
            this.btnReset.TabIndex = 13;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnNoSave
            // 
            this.btnNoSave.Enabled = false;
            this.btnNoSave.Location = new System.Drawing.Point(1148, 22);
            this.btnNoSave.Name = "btnNoSave";
            this.btnNoSave.Size = new System.Drawing.Size(88, 38);
            this.btnNoSave.TabIndex = 14;
            this.btnNoSave.Text = "K.Lưu";
            this.btnNoSave.UseVisualStyleBackColor = true;
            this.btnNoSave.Click += new System.EventHandler(this.btnNoSave_Click);
            // 
            // Frm_Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1580, 757);
            this.Controls.Add(this.btnNoSave);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnUpFile);
            this.Controls.Add(this.dgv_ListUser);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Frm_Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin";
            this.Load += new System.EventHandler(this.Frm_Admin_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ListUser)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStrip_btnHome;
        private System.Windows.Forms.ToolStripButton toolStrip_btnListStudent;
        private System.Windows.Forms.ToolStripButton toolStrip_btnTeacher;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgv_ListUser;
        private System.Windows.Forms.Button btnUpFile;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNameID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rbFemale;
        private System.Windows.Forms.RadioButton rbMale;
        private System.Windows.Forms.ComboBox cmbDecntralization;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ToolStripButton toolStrip_btnScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.ComboBox cmbFaculty;
        private System.Windows.Forms.Button btnNoSave;
        private System.Windows.Forms.ToolStripButton toolStrip_btnAddExaSchedule;
        private System.Windows.Forms.ToolStripButton toolStrip_btnExam;
        private System.Windows.Forms.ToolStripButton toolStrip_btnAddMajor;
        private System.Windows.Forms.ToolStripButton toolStrip_btnSuject;
    }       
}