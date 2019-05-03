namespace Al_Shaheen_System
{
    partial class getAllEmployeesFrm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bttnNewUser = new System.Windows.Forms.Button();
            this.employees_grid_view = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.employees_grid_view)).BeginInit();
            this.SuspendLayout();
            // 
            // bttnNewUser
            // 
            this.bttnNewUser.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.bttnNewUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttnNewUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnNewUser.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bttnNewUser.Location = new System.Drawing.Point(754, 36);
            this.bttnNewUser.Name = "bttnNewUser";
            this.bttnNewUser.Size = new System.Drawing.Size(172, 35);
            this.bttnNewUser.TabIndex = 1;
            this.bttnNewUser.Text = "تعين اسم مستخدم";
            this.bttnNewUser.UseVisualStyleBackColor = false;
            this.bttnNewUser.Click += new System.EventHandler(this.button1_Click);
            // 
            // employees_grid_view
            // 
            this.employees_grid_view.AllowUserToAddRows = false;
            this.employees_grid_view.AllowUserToDeleteRows = false;
            this.employees_grid_view.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.employees_grid_view.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.employees_grid_view.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.employees_grid_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.employees_grid_view.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column6,
            this.Column5});
            this.employees_grid_view.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.employees_grid_view.Location = new System.Drawing.Point(12, 77);
            this.employees_grid_view.Name = "employees_grid_view";
            this.employees_grid_view.ReadOnly = true;
            this.employees_grid_view.Size = new System.Drawing.Size(914, 536);
            this.employees_grid_view.TabIndex = 0;
            this.employees_grid_view.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.employees_grid_view_CellContentClick);
            this.employees_grid_view.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.employees_grid_view_CellContentDoubleClick);
            // 
            // Column1
            // 
            this.Column1.FillWeight = 49.46275F;
            this.Column1.HeaderText = "م";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 87.54908F;
            this.Column2.HeaderText = "رقم ";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.FillWeight = 87.54908F;
            this.Column3.HeaderText = "اسم الموظف كاملا";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.FillWeight = 87.54908F;
            this.Column4.HeaderText = "الرقم القومي";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.FillWeight = 87.54908F;
            this.Column6.HeaderText = "العنوان";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "تم الإضافة بواسطة";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // getAllEmployeesFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(938, 638);
            this.Controls.Add(this.bttnNewUser);
            this.Controls.Add(this.employees_grid_view);
            this.Name = "getAllEmployeesFrm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "عرض جميع الموظفين";
            this.Load += new System.EventHandler(this.getAllEmployeesFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.employees_grid_view)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bttnNewUser;
        public System.Windows.Forms.DataGridView employees_grid_view;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}