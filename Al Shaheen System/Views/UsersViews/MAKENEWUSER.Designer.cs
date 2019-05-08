namespace Al_Shaheen_System
{
    partial class makenewuser
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmpName = new System.Windows.Forms.TextBox();
            this.txtEmpUserName = new System.Windows.Forms.TextBox();
            this.txtEmpPassword = new System.Windows.Forms.TextBox();
            this.txtEmpPasswordConfirm = new System.Windows.Forms.TextBox();
            this.bttnSave = new System.Windows.Forms.Button();
            this.bttnNewUser = new System.Windows.Forms.Button();
            this.bttnCancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 67);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "اسم الموظف";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 113);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "اسم المستخدم";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 152);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "كلمه المرور";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 195);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "تأكيد كلمه المرور";
            // 
            // txtEmpName
            // 
            this.txtEmpName.Enabled = false;
            this.txtEmpName.Location = new System.Drawing.Point(150, 67);
            this.txtEmpName.Margin = new System.Windows.Forms.Padding(6);
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.Size = new System.Drawing.Size(322, 29);
            this.txtEmpName.TabIndex = 4;
            // 
            // txtEmpUserName
            // 
            this.txtEmpUserName.Location = new System.Drawing.Point(150, 108);
            this.txtEmpUserName.Margin = new System.Windows.Forms.Padding(6);
            this.txtEmpUserName.Name = "txtEmpUserName";
            this.txtEmpUserName.Size = new System.Drawing.Size(322, 29);
            this.txtEmpUserName.TabIndex = 5;
            // 
            // txtEmpPassword
            // 
            this.txtEmpPassword.Location = new System.Drawing.Point(150, 149);
            this.txtEmpPassword.Margin = new System.Windows.Forms.Padding(6);
            this.txtEmpPassword.Name = "txtEmpPassword";
            this.txtEmpPassword.PasswordChar = '*';
            this.txtEmpPassword.Size = new System.Drawing.Size(322, 29);
            this.txtEmpPassword.TabIndex = 6;
            // 
            // txtEmpPasswordConfirm
            // 
            this.txtEmpPasswordConfirm.Location = new System.Drawing.Point(150, 190);
            this.txtEmpPasswordConfirm.Margin = new System.Windows.Forms.Padding(6);
            this.txtEmpPasswordConfirm.Name = "txtEmpPasswordConfirm";
            this.txtEmpPasswordConfirm.PasswordChar = '*';
            this.txtEmpPasswordConfirm.Size = new System.Drawing.Size(322, 29);
            this.txtEmpPasswordConfirm.TabIndex = 7;
            // 
            // bttnSave
            // 
            this.bttnSave.Location = new System.Drawing.Point(31, 252);
            this.bttnSave.Margin = new System.Windows.Forms.Padding(6);
            this.bttnSave.Name = "bttnSave";
            this.bttnSave.Size = new System.Drawing.Size(91, 42);
            this.bttnSave.TabIndex = 8;
            this.bttnSave.Text = "حفظ";
            this.bttnSave.UseVisualStyleBackColor = true;
            this.bttnSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // bttnNewUser
            // 
            this.bttnNewUser.Location = new System.Drawing.Point(196, 252);
            this.bttnNewUser.Margin = new System.Windows.Forms.Padding(6);
            this.bttnNewUser.Name = "bttnNewUser";
            this.bttnNewUser.Size = new System.Drawing.Size(96, 42);
            this.bttnNewUser.TabIndex = 9;
            this.bttnNewUser.Text = "جديد";
            this.bttnNewUser.UseVisualStyleBackColor = true;
            this.bttnNewUser.Click += new System.EventHandler(this.bttnNewUser_Click);
            // 
            // bttnCancel
            // 
            this.bttnCancel.Location = new System.Drawing.Point(379, 252);
            this.bttnCancel.Margin = new System.Windows.Forms.Padding(6);
            this.bttnCancel.Name = "bttnCancel";
            this.bttnCancel.Size = new System.Drawing.Size(93, 42);
            this.bttnCancel.TabIndex = 10;
            this.bttnCancel.Text = "الغاء";
            this.bttnCancel.UseVisualStyleBackColor = true;
            this.bttnCancel.Click += new System.EventHandler(this.button3_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(130, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(233, 39);
            this.label5.TabIndex = 11;
            this.label5.Text = "إضافة حساب جديد ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // makenewuser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 309);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.bttnCancel);
            this.Controls.Add(this.bttnNewUser);
            this.Controls.Add(this.bttnSave);
            this.Controls.Add(this.txtEmpPasswordConfirm);
            this.Controls.Add(this.txtEmpPassword);
            this.Controls.Add(this.txtEmpUserName);
            this.Controls.Add(this.txtEmpName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "makenewuser";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تعين اسم مستخدم";
            this.Load += new System.EventHandler(this.MAKENEWUSER_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEmpUserName;
        private System.Windows.Forms.TextBox txtEmpPassword;
        private System.Windows.Forms.TextBox txtEmpPasswordConfirm;
        private System.Windows.Forms.Button bttnSave;
        private System.Windows.Forms.Button bttnNewUser;
        private System.Windows.Forms.Button bttnCancel;
        public System.Windows.Forms.TextBox txtEmpName;
        private System.Windows.Forms.Label label5;
    }
}