namespace RunningFromTheDayLight
{
    partial class DoExams
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
            this.components = new System.ComponentModel.Container();
            this.pnlStudentInfo = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblSubjectName = new System.Windows.Forms.Label();
            this.lbStudentName = new System.Windows.Forms.Label();
            this.lblRoom = new System.Windows.Forms.Label();
            this.lbStudentCode = new System.Windows.Forms.Label();
            this.lblStudentInfo = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.flpQuestions = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblTimer = new System.Windows.Forms.Label();
            this.examTimer = new System.Windows.Forms.Timer(this.components);
            this.pnlStudentInfo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlStudentInfo
            // 
            this.pnlStudentInfo.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pnlStudentInfo.Controls.Add(this.groupBox1);
            this.pnlStudentInfo.Controls.Add(this.lblStudentInfo);
            this.pnlStudentInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStudentInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlStudentInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlStudentInfo.Name = "pnlStudentInfo";
            this.pnlStudentInfo.Size = new System.Drawing.Size(1067, 98);
            this.pnlStudentInfo.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblSubjectName);
            this.groupBox1.Controls.Add(this.lbStudentName);
            this.groupBox1.Controls.Add(this.lblRoom);
            this.groupBox1.Controls.Add(this.lbStudentCode);
            this.groupBox1.Location = new System.Drawing.Point(229, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(643, 87);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // lblSubjectName
            // 
            this.lblSubjectName.AutoSize = true;
            this.lblSubjectName.Location = new System.Drawing.Point(345, 62);
            this.lblSubjectName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubjectName.Name = "lblSubjectName";
            this.lblSubjectName.Size = new System.Drawing.Size(118, 16);
            this.lblSubjectName.TabIndex = 4;
            this.lblSubjectName.Text = "This.SubjectName";
            // 
            // lbStudentName
            // 
            this.lbStudentName.AutoSize = true;
            this.lbStudentName.Location = new System.Drawing.Point(59, 11);
            this.lbStudentName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbStudentName.Name = "lbStudentName";
            this.lbStudentName.Size = new System.Drawing.Size(73, 16);
            this.lbStudentName.TabIndex = 1;
            this.lbStudentName.Text = "This.Name";
            // 
            // lblRoom
            // 
            this.lblRoom.AutoSize = true;
            this.lblRoom.Location = new System.Drawing.Point(345, 11);
            this.lblRoom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Size = new System.Drawing.Size(73, 16);
            this.lblRoom.TabIndex = 3;
            this.lblRoom.Text = "This.Room";
            // 
            // lbStudentCode
            // 
            this.lbStudentCode.AutoSize = true;
            this.lbStudentCode.Location = new System.Drawing.Point(59, 62);
            this.lbStudentCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbStudentCode.Name = "lbStudentCode";
            this.lbStudentCode.Size = new System.Drawing.Size(69, 16);
            this.lbStudentCode.TabIndex = 2;
            this.lbStudentCode.Text = "This.Code";
            // 
            // lblStudentInfo
            // 
            this.lblStudentInfo.AutoSize = true;
            this.lblStudentInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblStudentInfo.Location = new System.Drawing.Point(16, 33);
            this.lblStudentInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStudentInfo.Name = "lblStudentInfo";
            this.lblStudentInfo.Size = new System.Drawing.Size(161, 20);
            this.lblStudentInfo.TabIndex = 0;
            this.lblStudentInfo.Text = "Thông tin thí sinh:";
            // 
            // pnlMain
            // 
            this.pnlMain.AutoScroll = true;
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Controls.Add(this.flpQuestions);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 98);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1067, 640);
            this.pnlMain.TabIndex = 1;
            // 
            // flpQuestions
            // 
            this.flpQuestions.AutoScroll = true;
            this.flpQuestions.AutoSize = true;
            this.flpQuestions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpQuestions.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpQuestions.Location = new System.Drawing.Point(0, 0);
            this.flpQuestions.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flpQuestions.Name = "flpQuestions";
            this.flpQuestions.Size = new System.Drawing.Size(1067, 640);
            this.flpQuestions.TabIndex = 0;
            this.flpQuestions.WrapContents = false;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pnlBottom.Controls.Add(this.btnSave);
            this.pnlBottom.Controls.Add(this.btnSubmit);
            this.pnlBottom.Controls.Add(this.lblTimer);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 664);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1067, 74);
            this.pnlBottom.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(760, 15);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(133, 43);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Lưu bài";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(907, 15);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(133, 43);
            this.btnSubmit.TabIndex = 0;
            this.btnSubmit.Text = "Nộp bài";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click_1);
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblTimer.Location = new System.Drawing.Point(27, 25);
            this.lblTimer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(170, 20);
            this.lblTimer.TabIndex = 1;
            this.lblTimer.Text = "Thời gian: 00:00:00";
            // 
            // examTimer
            // 
            this.examTimer.Interval = 1000;
            // 
            // DoExams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 738);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlStudentInfo);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DoExams";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Làm bài thi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DoExams_FormClosing);
            this.Load += new System.EventHandler(this.DoExams_Load);
            this.pnlStudentInfo.ResumeLayout(false);
            this.pnlStudentInfo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlStudentInfo;
        private System.Windows.Forms.Label lblStudentInfo;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.FlowLayoutPanel flpQuestions;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnSave;  // Thêm nút Lưu bài
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Timer examTimer;
        private System.Windows.Forms.Label lbStudentName;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.Label lblSubjectName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbStudentCode;
    }
}
