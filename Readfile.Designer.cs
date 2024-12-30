namespace WinFormApp
{
    partial class Readfile
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.btnUpFile = new System.Windows.Forms.Button();
            this.dgvCauHoi = new System.Windows.Forms.DataGridView();
            this.colBai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoaiCauHoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCauHoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDapAnA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDapAnB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDapAnC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDapAnD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDapAnDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbTenMonHoc = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuThemMonHoc = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnDeleteALLQS = new System.Windows.Forms.Button();
            this.btnTaoCauHoi = new System.Windows.Forms.Button();
            this.btnaddquestion = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCauHoi)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUpFile
            // 
            this.btnUpFile.Location = new System.Drawing.Point(46, 49);
            this.btnUpFile.Name = "btnUpFile";
            this.btnUpFile.Size = new System.Drawing.Size(100, 30);
            this.btnUpFile.TabIndex = 0;
            this.btnUpFile.Text = "Up File";
            this.btnUpFile.UseVisualStyleBackColor = true;
            this.btnUpFile.Click += new System.EventHandler(this.btnUpFile_Click);
            // 
            // dgvCauHoi
            // 
            this.dgvCauHoi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCauHoi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCauHoi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBai,
            this.colLoaiCauHoi,
            this.colCauHoi,
            this.colDapAnA,
            this.colDapAnB,
            this.colDapAnC,
            this.colDapAnD,
            this.colDapAnDung});
            this.dgvCauHoi.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvCauHoi.Location = new System.Drawing.Point(34, 109);
            this.dgvCauHoi.Name = "dgvCauHoi";
            this.dgvCauHoi.RowHeadersWidth = 51;
            this.dgvCauHoi.Size = new System.Drawing.Size(975, 308);
            this.dgvCauHoi.TabIndex = 1;
            this.dgvCauHoi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCauHoi_CellClick);
            // 
            // colBai
            // 
            this.colBai.HeaderText = "Bài";
            this.colBai.MinimumWidth = 6;
            this.colBai.Name = "colBai";
            // 
            // colLoaiCauHoi
            // 
            this.colLoaiCauHoi.HeaderText = "Loại Câu Hỏi";
            this.colLoaiCauHoi.MinimumWidth = 6;
            this.colLoaiCauHoi.Name = "colLoaiCauHoi";
            // 
            // colCauHoi
            // 
            this.colCauHoi.HeaderText = "Câu Hỏi";
            this.colCauHoi.MinimumWidth = 6;
            this.colCauHoi.Name = "colCauHoi";
            // 
            // colDapAnA
            // 
            this.colDapAnA.HeaderText = "Đáp Án A";
            this.colDapAnA.MinimumWidth = 6;
            this.colDapAnA.Name = "colDapAnA";
            // 
            // colDapAnB
            // 
            this.colDapAnB.HeaderText = "Đáp Án B";
            this.colDapAnB.MinimumWidth = 6;
            this.colDapAnB.Name = "colDapAnB";
            // 
            // colDapAnC
            // 
            this.colDapAnC.HeaderText = "Đáp Án C";
            this.colDapAnC.MinimumWidth = 6;
            this.colDapAnC.Name = "colDapAnC";
            // 
            // colDapAnD
            // 
            this.colDapAnD.HeaderText = "Đáp Án D";
            this.colDapAnD.MinimumWidth = 6;
            this.colDapAnD.Name = "colDapAnD";
            // 
            // colDapAnDung
            // 
            this.colDapAnDung.HeaderText = "Đáp Án Đúng";
            this.colDapAnDung.MinimumWidth = 6;
            this.colDapAnDung.Name = "colDapAnDung";
            // 
            // cmbTenMonHoc
            // 
            this.cmbTenMonHoc.FormattingEnabled = true;
            this.cmbTenMonHoc.Location = new System.Drawing.Point(365, 31);
            this.cmbTenMonHoc.Name = "cmbTenMonHoc";
            this.cmbTenMonHoc.Size = new System.Drawing.Size(343, 24);
            this.cmbTenMonHoc.TabIndex = 2;
            this.cmbTenMonHoc.SelectedIndexChanged += new System.EventHandler(this.cmbTenMonHoc_SelectedIndexChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(289, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tên môn học";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Enabled = false;
            this.txtSoLuong.Location = new System.Drawing.Point(813, 441);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.ReadOnly = true;
            this.txtSoLuong.Size = new System.Drawing.Size(195, 22);
            this.txtSoLuong.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(729, 444);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tổng số câu";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 28);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Menu
            // 
            this.Menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuThemMonHoc});
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(60, 24);
            this.Menu.Text = "Menu";
            // 
            // menuThemMonHoc
            // 
            this.menuThemMonHoc.Name = "menuThemMonHoc";
            this.menuThemMonHoc.Size = new System.Drawing.Size(194, 26);
            this.menuThemMonHoc.Text = "Thêm Môn Học";
            this.menuThemMonHoc.Click += new System.EventHandler(this.menuThemMonHoc_Click_1);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(741, 64);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(100, 30);
            this.btnLuu.TabIndex = 19;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnDeleteALLQS
            // 
            this.btnDeleteALLQS.Location = new System.Drawing.Point(856, 64);
            this.btnDeleteALLQS.Name = "btnDeleteALLQS";
            this.btnDeleteALLQS.Size = new System.Drawing.Size(100, 30);
            this.btnDeleteALLQS.TabIndex = 20;
            this.btnDeleteALLQS.Text = "Xóa";
            this.btnDeleteALLQS.UseVisualStyleBackColor = true;
            this.btnDeleteALLQS.Click += new System.EventHandler(this.btnDeleteALLQS_Click);
            // 
            // btnTaoCauHoi
            // 
            this.btnTaoCauHoi.Location = new System.Drawing.Point(408, 437);
            this.btnTaoCauHoi.Name = "btnTaoCauHoi";
            this.btnTaoCauHoi.Size = new System.Drawing.Size(217, 30);
            this.btnTaoCauHoi.TabIndex = 21;
            this.btnTaoCauHoi.Text = "Tạo câu hỏi ngẫu nhiên";
            this.btnTaoCauHoi.UseVisualStyleBackColor = true;
            this.btnTaoCauHoi.Click += new System.EventHandler(this.btnTaoCauHoi_Click);
            // 
            // btnaddquestion
            // 
            this.btnaddquestion.Location = new System.Drawing.Point(129, 435);
            this.btnaddquestion.Name = "btnaddquestion";
            this.btnaddquestion.Size = new System.Drawing.Size(109, 26);
            this.btnaddquestion.TabIndex = 22;
            this.btnaddquestion.Text = "Thêm câu hỏi";
            this.btnaddquestion.UseVisualStyleBackColor = true;
            this.btnaddquestion.Click += new System.EventHandler(this.btnaddquestion_Click_1);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(338, 74);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(370, 22);
            this.txtSearch.TabIndex = 23;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(228, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 16);
            this.label3.TabIndex = 24;
            this.label3.Text = "Tìm câu hỏi theo tên";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(264, 435);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(95, 26);
            this.btnDelete.TabIndex = 25;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click_1);
            // 
            // Readfile
            // 
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1008, 490);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnaddquestion);
            this.Controls.Add(this.btnTaoCauHoi);
            this.Controls.Add(this.btnDeleteALLQS);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbTenMonHoc);
            this.Controls.Add(this.dgvCauHoi);
            this.Controls.Add(this.btnUpFile);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Readfile";
            this.Text = "Tạo câu hỏi";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCauHoi)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpFile;
        private System.Windows.Forms.DataGridView dgvCauHoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBai; 
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoaiCauHoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCauHoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDapAnA;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDapAnB;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDapAnC;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDapAnD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDapAnDung;
        private System.Windows.Forms.ComboBox cmbTenMonHoc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Menu;
        private System.Windows.Forms.ToolStripMenuItem menuThemMonHoc;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnDeleteALLQS;
        private System.Windows.Forms.Button btnTaoCauHoi;
        private System.Windows.Forms.Button btnaddquestion;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDelete;
    }
}
