namespace Al_Shaheen_System
{
    partial class Display_allUsers
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridViewAllUsers = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.setuserpermissionsform = new System.Windows.Forms.Button();
            this.bttnDisplayAllUserData = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAllUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // gridViewAllUsers
            // 
            this.gridViewAllUsers.AllowUserToAddRows = false;
            this.gridViewAllUsers.AllowUserToDeleteRows = false;
            this.gridViewAllUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridViewAllUsers.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridViewAllUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridViewAllUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewAllUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridViewAllUsers.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridViewAllUsers.Location = new System.Drawing.Point(12, 76);
            this.gridViewAllUsers.Name = "gridViewAllUsers";
            this.gridViewAllUsers.ReadOnly = true;
            this.gridViewAllUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridViewAllUsers.Size = new System.Drawing.Size(912, 506);
            this.gridViewAllUsers.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "م";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "اسم الموظف";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "اسم المستخدم";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "كلمة السر";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "تاريخ عمل الحساب";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(215, 31);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(178, 33);
            this.button2.TabIndex = 3;
            this.button2.Text = "تغير كلمه السر";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // setuserpermissionsform
            // 
            this.setuserpermissionsform.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.setuserpermissionsform.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setuserpermissionsform.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setuserpermissionsform.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.setuserpermissionsform.Location = new System.Drawing.Point(741, 31);
            this.setuserpermissionsform.Name = "setuserpermissionsform";
            this.setuserpermissionsform.Size = new System.Drawing.Size(183, 33);
            this.setuserpermissionsform.TabIndex = 4;
            this.setuserpermissionsform.Text = "صلاحيات المستخدم";
            this.setuserpermissionsform.UseVisualStyleBackColor = false;
            this.setuserpermissionsform.Click += new System.EventHandler(this.setuserpermissionsform_Click);
            // 
            // bttnDisplayAllUserData
            // 
            this.bttnDisplayAllUserData.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.bttnDisplayAllUserData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttnDisplayAllUserData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnDisplayAllUserData.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bttnDisplayAllUserData.Location = new System.Drawing.Point(12, 31);
            this.bttnDisplayAllUserData.Name = "bttnDisplayAllUserData";
            this.bttnDisplayAllUserData.Size = new System.Drawing.Size(158, 34);
            this.bttnDisplayAllUserData.TabIndex = 1;
            this.bttnDisplayAllUserData.Text = "عرض تفاصيل المستخدم";
            this.bttnDisplayAllUserData.UseVisualStyleBackColor = false;
            this.bttnDisplayAllUserData.Click += new System.EventHandler(this.bttnDisplayAllUserData_Click);
            // 
            // Display_allUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 594);
            this.Controls.Add(this.setuserpermissionsform);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.bttnDisplayAllUserData);
            this.Controls.Add(this.gridViewAllUsers);
            this.Name = "Display_allUsers";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "عرض جميع المستخدمين";
            this.Load += new System.EventHandler(this.Display_allUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAllUsers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.DataGridView gridViewAllUsers;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button setuserpermissionsform;
        private System.Windows.Forms.Button bttnDisplayAllUserData;
    }
}