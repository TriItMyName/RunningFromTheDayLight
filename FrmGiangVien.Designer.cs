namespace RunningFromTheDayLight
{
    partial class FrmGiangVien
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvListSubject = new System.Windows.Forms.DataGridView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStrip_btnHome = new System.Windows.Forms.ToolStripButton();
            this.toolStrip_btnAddsubjects = new System.Windows.Forms.ToolStripButton();
            this.toolStrip_btnAddQuestion = new System.Windows.Forms.ToolStripButton();
            this.toolStrip_UpFile = new System.Windows.Forms.ToolStripButton();
            this.toolStrip_btnReadList = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCreateExam = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmbsubjects = new System.Windows.Forms.ComboBox();
            this.txtCount = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListSubject)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(212, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chọn môn học";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(212, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tìm câu hỏi ";
            // 
            // dgvListSubject
            // 
            this.dgvListSubject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListSubject.Location = new System.Drawing.Point(188, 99);
            this.dgvListSubject.Name = "dgvListSubject";
            this.dgvListSubject.RowHeadersWidth = 51;
            this.dgvListSubject.RowTemplate.Height = 24;
            this.dgvListSubject.Size = new System.Drawing.Size(1167, 572);
            this.dgvListSubject.TabIndex = 2;
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.BackColor = System.Drawing.Color.DimGray;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_btnHome,
            this.toolStrip_btnAddsubjects,
            this.toolStrip_btnAddQuestion,
            this.toolStrip_UpFile,
            this.toolStrip_btnReadList});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(180, 758);
            this.toolStrip2.TabIndex = 4;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStrip_btnHome
            // 
            this.toolStrip_btnHome.AutoSize = false;
            this.toolStrip_btnHome.AutoToolTip = false;
            this.toolStrip_btnHome.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStrip_btnHome.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStrip_btnHome.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStrip_btnHome.Name = "toolStrip_btnHome";
            this.toolStrip_btnHome.Size = new System.Drawing.Size(175, 50);
            this.toolStrip_btnHome.Text = "Home";
            this.toolStrip_btnHome.Click += new System.EventHandler(this.toolStrip_btnHome_Click);
            // 
            // toolStrip_btnAddsubjects
            // 
            this.toolStrip_btnAddsubjects.AutoSize = false;
            this.toolStrip_btnAddsubjects.AutoToolTip = false;
            this.toolStrip_btnAddsubjects.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStrip_btnAddsubjects.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStrip_btnAddsubjects.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStrip_btnAddsubjects.Name = "toolStrip_btnAddsubjects";
            this.toolStrip_btnAddsubjects.Size = new System.Drawing.Size(175, 50);
            this.toolStrip_btnAddsubjects.Text = "Thêm Môn Học";
            this.toolStrip_btnAddsubjects.Click += new System.EventHandler(this.toolStrip_btnAddMon_Click);
            // 
            // toolStrip_btnAddQuestion
            // 
            this.toolStrip_btnAddQuestion.AutoSize = false;
            this.toolStrip_btnAddQuestion.AutoToolTip = false;
            this.toolStrip_btnAddQuestion.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStrip_btnAddQuestion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStrip_btnAddQuestion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStrip_btnAddQuestion.Name = "toolStrip_btnAddQuestion";
            this.toolStrip_btnAddQuestion.Size = new System.Drawing.Size(175, 50);
            this.toolStrip_btnAddQuestion.Text = "Thêm Câu Hỏi ";
            this.toolStrip_btnAddQuestion.Click += new System.EventHandler(this.toolStrip_btnAddQuestion_Click);
            // 
            // toolStrip_UpFile
            // 
            this.toolStrip_UpFile.AutoSize = false;
            this.toolStrip_UpFile.AutoToolTip = false;
            this.toolStrip_UpFile.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStrip_UpFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStrip_UpFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStrip_UpFile.Name = "toolStrip_UpFile";
            this.toolStrip_UpFile.Size = new System.Drawing.Size(175, 50);
            this.toolStrip_UpFile.Text = "Tải File Câu Hỏi";
            this.toolStrip_UpFile.Click += new System.EventHandler(this.toolStrip_UpFile_Click);
            // 
            // toolStrip_btnReadList
            // 
            this.toolStrip_btnReadList.AutoSize = false;
            this.toolStrip_btnReadList.AutoToolTip = false;
            this.toolStrip_btnReadList.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStrip_btnReadList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStrip_btnReadList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStrip_btnReadList.Name = "toolStrip_btnReadList";
            this.toolStrip_btnReadList.Size = new System.Drawing.Size(175, 50);
            this.toolStrip_btnReadList.Text = "Xem Lại Danh Sách";
            this.toolStrip_btnReadList.Click += new System.EventHandler(this.toolStrip_btnReadList_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(703, 32);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 33);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(859, 35);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(98, 33);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnCreateExam
            // 
            this.btnCreateExam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateExam.Location = new System.Drawing.Point(675, 684);
            this.btnCreateExam.Name = "btnCreateExam";
            this.btnCreateExam.Size = new System.Drawing.Size(239, 49);
            this.btnCreateExam.TabIndex = 7;
            this.btnCreateExam.Text = "Tạo Câu Hỏi Ngẫu Nhiên";
            this.btnCreateExam.UseVisualStyleBackColor = true;
            this.btnCreateExam.Click += new System.EventHandler(this.btnCreateExam_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1192, 698);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tổng số câu";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(325, 70);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(311, 22);
            this.txtSearch.TabIndex = 9;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // cmbsubjects
            // 
            this.cmbsubjects.FormattingEnabled = true;
            this.cmbsubjects.Location = new System.Drawing.Point(325, 31);
            this.cmbsubjects.Name = "cmbsubjects";
            this.cmbsubjects.Size = new System.Drawing.Size(311, 24);
            this.cmbsubjects.TabIndex = 10;
            // 
            // txtCount
            // 
            this.txtCount.Enabled = false;
            this.txtCount.Location = new System.Drawing.Point(1299, 698);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(56, 22);
            this.txtCount.TabIndex = 11;
            // 
            // FrmGiangVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1363, 758);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.cmbsubjects);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCreateExam);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.dgvListSubject);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmGiangVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giang Viên";
            this.Load += new System.EventHandler(this.FrmGiangVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListSubject)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvListSubject;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStrip_btnHome;
        private System.Windows.Forms.ToolStripButton toolStrip_btnAddsubjects;
        private System.Windows.Forms.ToolStripButton toolStrip_btnAddQuestion;
        private System.Windows.Forms.ToolStripButton toolStrip_UpFile;
        private System.Windows.Forms.ToolStripButton toolStrip_btnReadList;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCreateExam;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cmbsubjects;
        private System.Windows.Forms.TextBox txtCount;
    }
}