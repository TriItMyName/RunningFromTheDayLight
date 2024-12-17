using System;

namespace RunningFromTheDayLight
{
    partial class Add_Fix_Del_Qestions
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
            this.flpQuestions = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlEdit = new System.Windows.Forms.Panel();
            this.lblQuestionTitle = new System.Windows.Forms.Label();
            this.txtQuestion = new System.Windows.Forms.TextBox();
            this.lblOptionA = new System.Windows.Forms.Label();
            this.txtOptionA = new System.Windows.Forms.TextBox();
            this.lblOptionB = new System.Windows.Forms.Label();
            this.txtOptionB = new System.Windows.Forms.TextBox();
            this.lblOptionC = new System.Windows.Forms.Label();
            this.txtOptionC = new System.Windows.Forms.TextBox();
            this.lblOptionD = new System.Windows.Forms.Label();
            this.txtOptionD = new System.Windows.Forms.TextBox();
            this.lblCorrectAnswer = new System.Windows.Forms.Label();
            this.cboCorrectAnswer = new System.Windows.Forms.ComboBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.pnlEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpQuestions
            // 
            this.flpQuestions.AutoScroll = true;
            this.flpQuestions.BackColor = System.Drawing.Color.White;
            this.flpQuestions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpQuestions.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpQuestions.Location = new System.Drawing.Point(0, 0);
            this.flpQuestions.Name = "flpQuestions";
            this.flpQuestions.Padding = new System.Windows.Forms.Padding(10);
            this.flpQuestions.Size = new System.Drawing.Size(800, 450);
            this.flpQuestions.TabIndex = 0;
            this.flpQuestions.WrapContents = false;
            // 
            // pnlEdit
            // 
            this.pnlEdit.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pnlEdit.Controls.Add(this.btnClear);
            this.pnlEdit.Controls.Add(this.btnAdd);
            this.pnlEdit.Controls.Add(this.lblQuestionTitle);
            this.pnlEdit.Controls.Add(this.txtQuestion);
            this.pnlEdit.Controls.Add(this.lblOptionA);
            this.pnlEdit.Controls.Add(this.txtOptionA);
            this.pnlEdit.Controls.Add(this.lblOptionB);
            this.pnlEdit.Controls.Add(this.txtOptionB);
            this.pnlEdit.Controls.Add(this.lblOptionC);
            this.pnlEdit.Controls.Add(this.txtOptionC);
            this.pnlEdit.Controls.Add(this.lblOptionD);
            this.pnlEdit.Controls.Add(this.txtOptionD);
            this.pnlEdit.Controls.Add(this.lblCorrectAnswer);
            this.pnlEdit.Controls.Add(this.cboCorrectAnswer);
            this.pnlEdit.Controls.Add(this.btnDelete);
            this.pnlEdit.Controls.Add(this.btnEdit);
            this.pnlEdit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlEdit.Location = new System.Drawing.Point(0, 450);
            this.pnlEdit.Name = "pnlEdit";
            this.pnlEdit.Size = new System.Drawing.Size(800, 200);
            this.pnlEdit.TabIndex = 1;
            // 
            // lblQuestionTitle
            // 
            this.lblQuestionTitle.AutoSize = true;
            this.lblQuestionTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblQuestionTitle.Location = new System.Drawing.Point(12, 15);
            this.lblQuestionTitle.Name = "lblQuestionTitle";
            this.lblQuestionTitle.Size = new System.Drawing.Size(60, 15);
            this.lblQuestionTitle.TabIndex = 0;
            this.lblQuestionTitle.Text = "Câu hỏi:";
            // 
            // txtQuestion
            // 
            this.txtQuestion.Location = new System.Drawing.Point(79, 12);
            this.txtQuestion.Multiline = true;
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.Size = new System.Drawing.Size(709, 50);
            this.txtQuestion.TabIndex = 1;
            // 
            // lblOptionA
            // 
            this.lblOptionA.AutoSize = true;
            this.lblOptionA.Location = new System.Drawing.Point(12, 73);
            this.lblOptionA.Name = "lblOptionA";
            this.lblOptionA.Size = new System.Drawing.Size(55, 13);
            this.lblOptionA.TabIndex = 2;
            this.lblOptionA.Text = "Đáp án A:";
            // 
            // txtOptionA
            // 
            this.txtOptionA.Location = new System.Drawing.Point(79, 70);
            this.txtOptionA.Name = "txtOptionA";
            this.txtOptionA.Size = new System.Drawing.Size(300, 20);
            this.txtOptionA.TabIndex = 3;
            // 
            // lblOptionB
            // 
            this.lblOptionB.AutoSize = true;
            this.lblOptionB.Location = new System.Drawing.Point(388, 73);
            this.lblOptionB.Name = "lblOptionB";
            this.lblOptionB.Size = new System.Drawing.Size(55, 13);
            this.lblOptionB.TabIndex = 4;
            this.lblOptionB.Text = "Đáp án B:";
            // 
            // txtOptionB
            // 
            this.txtOptionB.Location = new System.Drawing.Point(455, 70);
            this.txtOptionB.Name = "txtOptionB";
            this.txtOptionB.Size = new System.Drawing.Size(300, 20);
            this.txtOptionB.TabIndex = 5;
            // 
            // lblOptionC
            // 
            this.lblOptionC.AutoSize = true;
            this.lblOptionC.Location = new System.Drawing.Point(12, 103);
            this.lblOptionC.Name = "lblOptionC";
            this.lblOptionC.Size = new System.Drawing.Size(55, 13);
            this.lblOptionC.TabIndex = 6;
            this.lblOptionC.Text = "Đáp án C:";
            // 
            // txtOptionC
            // 
            this.txtOptionC.Location = new System.Drawing.Point(79, 100);
            this.txtOptionC.Name = "txtOptionC";
            this.txtOptionC.Size = new System.Drawing.Size(300, 20);
            this.txtOptionC.TabIndex = 7;
            // 
            // lblOptionD
            // 
            this.lblOptionD.AutoSize = true;
            this.lblOptionD.Location = new System.Drawing.Point(388, 103);
            this.lblOptionD.Name = "lblOptionD";
            this.lblOptionD.Size = new System.Drawing.Size(56, 13);
            this.lblOptionD.TabIndex = 8;
            this.lblOptionD.Text = "Đáp án D:";
            // 
            // txtOptionD
            // 
            this.txtOptionD.Location = new System.Drawing.Point(455, 100);
            this.txtOptionD.Name = "txtOptionD";
            this.txtOptionD.Size = new System.Drawing.Size(300, 20);
            this.txtOptionD.TabIndex = 9;
            // 
            // lblCorrectAnswer
            // 
            this.lblCorrectAnswer.AutoSize = true;
            this.lblCorrectAnswer.Location = new System.Drawing.Point(12, 133);
            this.lblCorrectAnswer.Name = "lblCorrectAnswer";
            this.lblCorrectAnswer.Size = new System.Drawing.Size(73, 13);
            this.lblCorrectAnswer.TabIndex = 10;
            this.lblCorrectAnswer.Text = "Đáp án đúng:";
            // 
            // cboCorrectAnswer
            // 
            this.cboCorrectAnswer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCorrectAnswer.FormattingEnabled = true;
            this.cboCorrectAnswer.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D"});
            this.cboCorrectAnswer.Location = new System.Drawing.Point(104, 130);
            this.cboCorrectAnswer.Name = "cboCorrectAnswer";
            this.cboCorrectAnswer.Size = new System.Drawing.Size(100, 21);
            this.cboCorrectAnswer.TabIndex = 11;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(680, 150);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.LimeGreen;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(588, 150);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 30);
            this.btnEdit.TabIndex = 12;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(490, 150);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 30);
            this.btnAdd.TabIndex = 15;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Blue;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(391, 150);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 16;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Add_Fix_Del_Qestions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 650);
            this.Controls.Add(this.flpQuestions);
            this.Controls.Add(this.pnlEdit);
            this.Name = "Add_Fix_Del_Qestions";
            this.Text = "Quản lý câu hỏi";
            this.pnlEdit.ResumeLayout(false);
            this.pnlEdit.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpQuestions;
        private System.Windows.Forms.Panel pnlEdit;
        private System.Windows.Forms.Label lblQuestionTitle;
        private System.Windows.Forms.TextBox txtQuestion;
        private System.Windows.Forms.Label lblOptionA;
        private System.Windows.Forms.TextBox txtOptionA;
        private System.Windows.Forms.Label lblOptionB;
        private System.Windows.Forms.TextBox txtOptionB;
        private System.Windows.Forms.Label lblOptionC;
        private System.Windows.Forms.TextBox txtOptionC;
        private System.Windows.Forms.Label lblOptionD;
        private System.Windows.Forms.TextBox txtOptionD;
        private System.Windows.Forms.Label lblCorrectAnswer;
        private System.Windows.Forms.ComboBox cboCorrectAnswer;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClear;
    }
}
