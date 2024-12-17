namespace Proje
{
    partial class Form1
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
            this.dgvTN = new System.Windows.Forms.DataGridView();
            this.colMaCauHoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaNganHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaChuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDapAnA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDapAnB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDapAnC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDapAnD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDapAnDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnUpFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTN)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTN
            // 
            this.dgvTN.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTN.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaCauHoi,
            this.colMaNganHang,
            this.colMaChuong,
            this.colNoiDung,
            this.colDapAnA,
            this.colDapAnB,
            this.colDapAnC,
            this.colDapAnD,
            this.colDapAnDung});
            this.dgvTN.Location = new System.Drawing.Point(24, 143);
            this.dgvTN.Name = "dgvTN";
            this.dgvTN.Size = new System.Drawing.Size(1135, 245);
            this.dgvTN.TabIndex = 0;
            // 
            // colMaCauHoi
            // 
            this.colMaCauHoi.HeaderText = "Mã Câu Hỏi";
            this.colMaCauHoi.Name = "colMaCauHoi";
            // 
            // colMaNganHang
            // 
            this.colMaNganHang.HeaderText = "Mã Ngân Hàng";
            this.colMaNganHang.Name = "colMaNganHang";
            // 
            // colMaChuong
            // 
            this.colMaChuong.HeaderText = "Mã Chương";
            this.colMaChuong.Name = "colMaChuong";
            // 
            // colNoiDung
            // 
            this.colNoiDung.HeaderText = "Nội Dung";
            this.colNoiDung.Name = "colNoiDung";
            // 
            // colDapAnA
            // 
            this.colDapAnA.HeaderText = "Đáp Án A";
            this.colDapAnA.Name = "colDapAnA";
            // 
            // colDapAnB
            // 
            this.colDapAnB.HeaderText = "Đáp Án B";
            this.colDapAnB.Name = "colDapAnB";
            // 
            // colDapAnC
            // 
            this.colDapAnC.HeaderText = "Đáp Án C";
            this.colDapAnC.Name = "colDapAnC";
            // 
            // colDapAnD
            // 
            this.colDapAnD.HeaderText = "Đáp Án D";
            this.colDapAnD.Name = "colDapAnD";
            // 
            // colDapAnDung
            // 
            this.colDapAnDung.HeaderText = "Đáp Án Đúng";
            this.colDapAnDung.Name = "colDapAnDung";
            // 
            // btnUpFile
            // 
            this.btnUpFile.Location = new System.Drawing.Point(463, 82);
            this.btnUpFile.Name = "btnUpFile";
            this.btnUpFile.Size = new System.Drawing.Size(75, 23);
            this.btnUpFile.TabIndex = 1;
            this.btnUpFile.Text = "Úp file";
            this.btnUpFile.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 398);
            this.Controls.Add(this.btnUpFile);
            this.Controls.Add(this.dgvTN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTN)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTN;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaCauHoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaNganHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaChuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNoiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDapAnA;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDapAnB;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDapAnC;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDapAnD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDapAnDung;
        private System.Windows.Forms.Button btnUpFile;
    }
}
