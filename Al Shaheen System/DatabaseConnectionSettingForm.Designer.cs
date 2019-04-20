namespace Al_Shaheen_System
{
    partial class DatabaseConnectionSettingForm
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
            this.passwordtxtbox = new System.Windows.Forms.TextBox();
            this.usernametxtbox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.save_server_info_btn = new System.Windows.Forms.Button();
            this.dbtxtbox = new System.Windows.Forms.TextBox();
            this.servertxtbox = new System.Windows.Forms.TextBox();
            this.SqlServerradiobtn = new System.Windows.Forms.RadioButton();
            this.windowsradiobtn = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.passwordtxtbox);
            this.groupBox1.Controls.Add(this.usernametxtbox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox1.Location = new System.Drawing.Point(17, 247);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(370, 100);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Login";
            // 
            // passwordtxtbox
            // 
            this.passwordtxtbox.Location = new System.Drawing.Point(10, 61);
            this.passwordtxtbox.Name = "passwordtxtbox";
            this.passwordtxtbox.PasswordChar = '*';
            this.passwordtxtbox.Size = new System.Drawing.Size(213, 20);
            this.passwordtxtbox.TabIndex = 15;
            // 
            // usernametxtbox
            // 
            this.usernametxtbox.Location = new System.Drawing.Point(10, 20);
            this.usernametxtbox.Name = "usernametxtbox";
            this.usernametxtbox.Size = new System.Drawing.Size(213, 20);
            this.usernametxtbox.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(277, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 19);
            this.label6.TabIndex = 13;
            this.label6.Text = "كلمة المرور";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(254, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 19);
            this.label5.TabIndex = 12;
            this.label5.Text = "إسم المستخدم ";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.Location = new System.Drawing.Point(144, 375);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(106, 32);
            this.button3.TabIndex = 26;
            this.button3.Text = "إختبار الاتصال";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(298, 375);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(89, 32);
            this.button2.TabIndex = 25;
            this.button2.Text = "إغلاق النافذة ";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // save_server_info_btn
            // 
            this.save_server_info_btn.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.save_server_info_btn.FlatAppearance.BorderSize = 0;
            this.save_server_info_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save_server_info_btn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.save_server_info_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.save_server_info_btn.Location = new System.Drawing.Point(17, 375);
            this.save_server_info_btn.Name = "save_server_info_btn";
            this.save_server_info_btn.Size = new System.Drawing.Size(98, 32);
            this.save_server_info_btn.TabIndex = 24;
            this.save_server_info_btn.Text = "حفظ الاعدادات";
            this.save_server_info_btn.UseVisualStyleBackColor = false;
            this.save_server_info_btn.Click += new System.EventHandler(this.save_server_info_btn_Click);
            // 
            // dbtxtbox
            // 
            this.dbtxtbox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dbtxtbox.Location = new System.Drawing.Point(140, 126);
            this.dbtxtbox.Name = "dbtxtbox";
            this.dbtxtbox.Size = new System.Drawing.Size(213, 20);
            this.dbtxtbox.TabIndex = 23;
            // 
            // servertxtbox
            // 
            this.servertxtbox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.servertxtbox.Location = new System.Drawing.Point(140, 91);
            this.servertxtbox.Name = "servertxtbox";
            this.servertxtbox.Size = new System.Drawing.Size(213, 20);
            this.servertxtbox.TabIndex = 22;
            // 
            // SqlServerradiobtn
            // 
            this.SqlServerradiobtn.AutoSize = true;
            this.SqlServerradiobtn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.SqlServerradiobtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.SqlServerradiobtn.Location = new System.Drawing.Point(186, 216);
            this.SqlServerradiobtn.Name = "SqlServerradiobtn";
            this.SqlServerradiobtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SqlServerradiobtn.Size = new System.Drawing.Size(193, 23);
            this.SqlServerradiobtn.TabIndex = 21;
            this.SqlServerradiobtn.TabStop = true;
            this.SqlServerradiobtn.Text = "SQL Server Autthentication";
            this.SqlServerradiobtn.UseVisualStyleBackColor = true;
            this.SqlServerradiobtn.CheckedChanged += new System.EventHandler(this.SqlServerradiobtn_CheckedChanged);
            // 
            // windowsradiobtn
            // 
            this.windowsradiobtn.AutoSize = true;
            this.windowsradiobtn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.windowsradiobtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.windowsradiobtn.Location = new System.Drawing.Point(202, 187);
            this.windowsradiobtn.Name = "windowsradiobtn";
            this.windowsradiobtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.windowsradiobtn.Size = new System.Drawing.Size(177, 23);
            this.windowsradiobtn.TabIndex = 20;
            this.windowsradiobtn.TabStop = true;
            this.windowsradiobtn.Text = "Windows Authentication";
            this.windowsradiobtn.UseVisualStyleBackColor = true;
            this.windowsradiobtn.CheckedChanged += new System.EventHandler(this.windowsradiobtn_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(15, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 19);
            this.label4.TabIndex = 19;
            this.label4.Text = "Authentication Mode";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(13, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 19);
            this.label3.TabIndex = 18;
            this.label3.Text = "إسم قاعدة البيانات ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(13, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 19);
            this.label2.TabIndex = 17;
            this.label2.Text = "إسم السيرفر";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(135, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 25);
            this.label1.TabIndex = 16;
            this.label1.Text = "إعدادات السيرفر ";
            // 
            // DatabaseConnectionSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 426);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.save_server_info_btn);
            this.Controls.Add(this.dbtxtbox);
            this.Controls.Add(this.servertxtbox);
            this.Controls.Add(this.SqlServerradiobtn);
            this.Controls.Add(this.windowsradiobtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DatabaseConnectionSettingForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إعداد الاتصال بقواعد البيانات ";
            this.Load += new System.EventHandler(this.DatabaseConnectionSettingForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox passwordtxtbox;
        private System.Windows.Forms.TextBox usernametxtbox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button save_server_info_btn;
        private System.Windows.Forms.TextBox dbtxtbox;
        private System.Windows.Forms.TextBox servertxtbox;
        private System.Windows.Forms.RadioButton SqlServerradiobtn;
        private System.Windows.Forms.RadioButton windowsradiobtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}