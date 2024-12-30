namespace RunningFromTheDayLight
{
    partial class Del_Add_Fix_RandomExams
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
            this.cmbSubject = new System.Windows.Forms.ComboBox();
            this.cmbMonHoc_DAF = new System.Windows.Forms.Label();
            this.dgvRamdomExams = new System.Windows.Forms.DataGridView();
            this.colExamID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreatetionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCountExams = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThoiGianThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddRandomExams = new System.Windows.Forms.Button();
            this.btnDelRandomExams = new System.Windows.Forms.Button();
            this.btnFixRandomExams = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDoiTenDe = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSuaThoiGian = new System.Windows.Forms.TextBox();
            this.entityCommand1 = new System.Data.Entity.Core.EntityClient.EntityCommand();
            this.btnSaveChange = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRamdomExams)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbSubject
            // 
            this.cmbSubject.FormattingEnabled = true;
            this.cmbSubject.Location = new System.Drawing.Point(396, 37);
            this.cmbSubject.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbSubject.Name = "cmbSubject";
            this.cmbSubject.Size = new System.Drawing.Size(336, 24);
            this.cmbSubject.TabIndex = 0;
            // 
            // cmbMonHoc_DAF
            // 
            this.cmbMonHoc_DAF.AutoSize = true;
            this.cmbMonHoc_DAF.Location = new System.Drawing.Point(312, 41);
            this.cmbMonHoc_DAF.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.cmbMonHoc_DAF.Name = "cmbMonHoc_DAF";
            this.cmbMonHoc_DAF.Size = new System.Drawing.Size(61, 16);
            this.cmbMonHoc_DAF.TabIndex = 1;
            this.cmbMonHoc_DAF.Text = "Môn Học";
            // 
            // dgvRamdomExams
            // 
            this.dgvRamdomExams.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRamdomExams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRamdomExams.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colExamID,
            this.colExamName,
            this.colCreatetionDate,
            this.colCountExams,
            this.colThoiGianThi});
            this.dgvRamdomExams.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvRamdomExams.Location = new System.Drawing.Point(16, 128);
            this.dgvRamdomExams.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvRamdomExams.Name = "dgvRamdomExams";
            this.dgvRamdomExams.RowHeadersWidth = 51;
            this.dgvRamdomExams.Size = new System.Drawing.Size(1035, 236);
            this.dgvRamdomExams.TabIndex = 2;
            this.dgvRamdomExams.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRamdomExams_CellClick);
            // 
            // colExamID
            // 
            this.colExamID.FillWeight = 44.24779F;
            this.colExamID.HeaderText = "Mã Đề";
            this.colExamID.MinimumWidth = 6;
            this.colExamID.Name = "colExamID";
            // 
            // colExamName
            // 
            this.colExamName.FillWeight = 102.8827F;
            this.colExamName.HeaderText = "Tên đề";
            this.colExamName.MinimumWidth = 6;
            this.colExamName.Name = "colExamName";
            // 
            // colCreatetionDate
            // 
            this.colCreatetionDate.FillWeight = 152.8695F;
            this.colCreatetionDate.HeaderText = "Ngày Tạo";
            this.colCreatetionDate.MinimumWidth = 6;
            this.colCreatetionDate.Name = "colCreatetionDate";
            // 
            // colCountExams
            // 
            this.colCountExams.HeaderText = "Số câu";
            this.colCountExams.MinimumWidth = 6;
            this.colCountExams.Name = "colCountExams";
            // 
            // colThoiGianThi
            // 
            this.colThoiGianThi.HeaderText = "Thời gian thi";
            this.colThoiGianThi.MinimumWidth = 6;
            this.colThoiGianThi.Name = "colThoiGianThi";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(284, 84);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(556, 22);
            this.txtSearch.TabIndex = 5;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(185, 87);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tìm Kiếm";
            // 
            // btnAddRandomExams
            // 
            this.btnAddRandomExams.Location = new System.Drawing.Point(175, 494);
            this.btnAddRandomExams.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddRandomExams.Name = "btnAddRandomExams";
            this.btnAddRandomExams.Size = new System.Drawing.Size(100, 28);
            this.btnAddRandomExams.TabIndex = 7;
            this.btnAddRandomExams.Text = "Thêm Đề";
            this.btnAddRandomExams.UseVisualStyleBackColor = true;
            this.btnAddRandomExams.Click += new System.EventHandler(this.btnAddRandomExams_Click);
            // 
            // btnDelRandomExams
            // 
            this.btnDelRandomExams.Location = new System.Drawing.Point(741, 494);
            this.btnDelRandomExams.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDelRandomExams.Name = "btnDelRandomExams";
            this.btnDelRandomExams.Size = new System.Drawing.Size(100, 28);
            this.btnDelRandomExams.TabIndex = 8;
            this.btnDelRandomExams.Text = "Xóa";
            this.btnDelRandomExams.UseVisualStyleBackColor = true;
            this.btnDelRandomExams.Click += new System.EventHandler(this.btnDelRandomExams_Click);
            // 
            // btnFixRandomExams
            // 
            this.btnFixRandomExams.Location = new System.Drawing.Point(427, 494);
            this.btnFixRandomExams.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFixRandomExams.Name = "btnFixRandomExams";
            this.btnFixRandomExams.Size = new System.Drawing.Size(199, 28);
            this.btnFixRandomExams.TabIndex = 8;
            this.btnFixRandomExams.Text = "Thêm/Sửa/Xóa câu hỏi";
            this.btnFixRandomExams.UseVisualStyleBackColor = true;
            this.btnFixRandomExams.Click += new System.EventHandler(this.btnFixRandomExams_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 405);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Đổi tên đề";
            // 
            // txtDoiTenDe
            // 
            this.txtDoiTenDe.Location = new System.Drawing.Point(124, 401);
            this.txtDoiTenDe.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDoiTenDe.Name = "txtDoiTenDe";
            this.txtDoiTenDe.Size = new System.Drawing.Size(255, 22);
            this.txtDoiTenDe.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(417, 405);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Sửa thời gian";
            // 
            // txtSuaThoiGian
            // 
            this.txtSuaThoiGian.Location = new System.Drawing.Point(517, 401);
            this.txtSuaThoiGian.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSuaThoiGian.Name = "txtSuaThoiGian";
            this.txtSuaThoiGian.Size = new System.Drawing.Size(271, 22);
            this.txtSuaThoiGian.TabIndex = 11;
            // 
            // entityCommand1
            // 
            this.entityCommand1.CommandTimeout = 0;
            this.entityCommand1.CommandTree = null;
            this.entityCommand1.Connection = null;
            this.entityCommand1.EnablePlanCaching = true;
            this.entityCommand1.Transaction = null;
            // 
            // btnSaveChange
            // 
            this.btnSaveChange.Location = new System.Drawing.Point(828, 399);
            this.btnSaveChange.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSaveChange.Name = "btnSaveChange";
            this.btnSaveChange.Size = new System.Drawing.Size(100, 28);
            this.btnSaveChange.TabIndex = 13;
            this.btnSaveChange.Text = "Lưu";
            this.btnSaveChange.UseVisualStyleBackColor = true;
            this.btnSaveChange.Click += new System.EventHandler(this.btnSaveChange_Click);
            // 
            // Del_Add_Fix_RandomExams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.btnSaveChange);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSuaThoiGian);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDoiTenDe);
            this.Controls.Add(this.btnFixRandomExams);
            this.Controls.Add(this.btnDelRandomExams);
            this.Controls.Add(this.btnAddRandomExams);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvRamdomExams);
            this.Controls.Add(this.cmbMonHoc_DAF);
            this.Controls.Add(this.cmbSubject);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Del_Add_Fix_RandomExams";
            this.Text = "Danh Sách Đề Ngẫu Nhiên";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRamdomExams)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbSubject;
        private System.Windows.Forms.Label cmbMonHoc_DAF;
        private System.Windows.Forms.DataGridView dgvRamdomExams;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddRandomExams;
        private System.Windows.Forms.Button btnDelRandomExams;
        private System.Windows.Forms.Button btnFixRandomExams;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExamID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExamName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreatetionDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCountExams;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThoiGianThi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDoiTenDe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSuaThoiGian;
        private System.Data.Entity.Core.EntityClient.EntityCommand entityCommand1;
        private System.Windows.Forms.Button btnSaveChange;
    }
}