namespace Al_Shaheen_System
{
    partial class all_clients_data
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.clients_grid_view = new System.Windows.Forms.DataGridView();
            this.client_company_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.client_company_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.client_company_telephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.client_company_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.add_client_branches = new System.Windows.Forms.Button();
            this.add_client_product = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.بحث = new System.Windows.Forms.Button();
            this.addnewclientcontacts = new System.Windows.Forms.Button();
            this.edite_client_company_btn = new System.Windows.Forms.Button();
            this.Message_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.clients_grid_view)).BeginInit();
            this.SuspendLayout();
            // 
            // clients_grid_view
            // 
            this.clients_grid_view.AllowUserToAddRows = false;
            this.clients_grid_view.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.clients_grid_view.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.clients_grid_view.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.clients_grid_view.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.clients_grid_view.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.clients_grid_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clients_grid_view.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.client_company_id,
            this.client_company_name,
            this.client_company_telephone,
            this.Column1,
            this.client_company_type});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.clients_grid_view.DefaultCellStyle = dataGridViewCellStyle3;
            this.clients_grid_view.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.clients_grid_view.Location = new System.Drawing.Point(12, 55);
            this.clients_grid_view.Name = "clients_grid_view";
            this.clients_grid_view.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.clients_grid_view.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.clients_grid_view.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.clients_grid_view.Size = new System.Drawing.Size(1141, 593);
            this.clients_grid_view.TabIndex = 0;
            this.clients_grid_view.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.clients_grid_view_CellContentDoubleClick);
            this.clients_grid_view.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.clients_grid_view_CellDoubleClick);
            // 
            // client_company_id
            // 
            this.client_company_id.HeaderText = "رقم العميل";
            this.client_company_id.Name = "client_company_id";
            this.client_company_id.ReadOnly = true;
            // 
            // client_company_name
            // 
            this.client_company_name.HeaderText = "إسم شركة العميل";
            this.client_company_name.Name = "client_company_name";
            this.client_company_name.ReadOnly = true;
            // 
            // client_company_telephone
            // 
            this.client_company_telephone.HeaderText = "التليفون الأرضي";
            this.client_company_telephone.Name = "client_company_telephone";
            this.client_company_telephone.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "رقم الفاكس";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // client_company_type
            // 
            this.client_company_type.HeaderText = "نوع العميل";
            this.client_company_type.Name = "client_company_type";
            this.client_company_type.ReadOnly = true;
            // 
            // add_client_branches
            // 
            this.add_client_branches.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.add_client_branches.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add_client_branches.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add_client_branches.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.add_client_branches.Location = new System.Drawing.Point(1018, 664);
            this.add_client_branches.Name = "add_client_branches";
            this.add_client_branches.Size = new System.Drawing.Size(135, 37);
            this.add_client_branches.TabIndex = 1;
            this.add_client_branches.Text = "إضافة فروع العميل";
            this.add_client_branches.UseVisualStyleBackColor = false;
            this.add_client_branches.Click += new System.EventHandler(this.add_client_branches_Click);
            // 
            // add_client_product
            // 
            this.add_client_product.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.add_client_product.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add_client_product.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add_client_product.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.add_client_product.Location = new System.Drawing.Point(869, 666);
            this.add_client_product.Name = "add_client_product";
            this.add_client_product.Size = new System.Drawing.Size(125, 36);
            this.add_client_product.TabIndex = 2;
            this.add_client_product.Text = "إضافة أصناف";
            this.add_client_product.UseVisualStyleBackColor = false;
            this.add_client_product.Click += new System.EventHandler(this.add_client_product_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(76, 18);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(262, 30);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "بحث";
            // 
            // بحث
            // 
            this.بحث.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.بحث.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.بحث.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.بحث.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.بحث.Location = new System.Drawing.Point(344, 12);
            this.بحث.Name = "بحث";
            this.بحث.Size = new System.Drawing.Size(85, 37);
            this.بحث.TabIndex = 5;
            this.بحث.Text = "بحث";
            this.بحث.UseVisualStyleBackColor = false;
            this.بحث.Click += new System.EventHandler(this.بحث_Click);
            // 
            // addnewclientcontacts
            // 
            this.addnewclientcontacts.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.addnewclientcontacts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addnewclientcontacts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addnewclientcontacts.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.addnewclientcontacts.Location = new System.Drawing.Point(675, 666);
            this.addnewclientcontacts.Name = "addnewclientcontacts";
            this.addnewclientcontacts.Size = new System.Drawing.Size(179, 36);
            this.addnewclientcontacts.TabIndex = 6;
            this.addnewclientcontacts.Text = "إضافة موظفين ";
            this.addnewclientcontacts.UseVisualStyleBackColor = false;
            this.addnewclientcontacts.Click += new System.EventHandler(this.addnewclientcontacts_Click);
            // 
            // edite_client_company_btn
            // 
            this.edite_client_company_btn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.edite_client_company_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.edite_client_company_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edite_client_company_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.edite_client_company_btn.Location = new System.Drawing.Point(1068, 14);
            this.edite_client_company_btn.Name = "edite_client_company_btn";
            this.edite_client_company_btn.Size = new System.Drawing.Size(85, 37);
            this.edite_client_company_btn.TabIndex = 7;
            this.edite_client_company_btn.Text = "تعديل";
            this.edite_client_company_btn.UseVisualStyleBackColor = false;
            this.edite_client_company_btn.Click += new System.EventHandler(this.edite_client_company_btn_Click);
            // 
            // Message_label
            // 
            this.Message_label.AutoSize = true;
            this.Message_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Message_label.Location = new System.Drawing.Point(747, 12);
            this.Message_label.Name = "Message_label";
            this.Message_label.Size = new System.Drawing.Size(64, 25);
            this.Message_label.TabIndex = 8;
            this.Message_label.Text = "label2";
            // 
            // all_clients_data
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1165, 713);
            this.Controls.Add(this.Message_label);
            this.Controls.Add(this.edite_client_company_btn);
            this.Controls.Add(this.addnewclientcontacts);
            this.Controls.Add(this.بحث);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.add_client_product);
            this.Controls.Add(this.add_client_branches);
            this.Controls.Add(this.clients_grid_view);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Name = "all_clients_data";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "جميع بيانات العملاء";
            this.Activated += new System.EventHandler(this.all_clients_data_Activated);
            this.Deactivate += new System.EventHandler(this.all_clients_data_Deactivate);
            this.Load += new System.EventHandler(this.all_clients_data_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clients_grid_view)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView clients_grid_view;
        private System.Windows.Forms.Button add_client_branches;
        private System.Windows.Forms.Button add_client_product;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button بحث;
        private System.Windows.Forms.Button addnewclientcontacts;
        private System.Windows.Forms.Button edite_client_company_btn;
        private System.Windows.Forms.Label Message_label;
        private System.Windows.Forms.DataGridViewTextBoxColumn client_company_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn client_company_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn client_company_telephone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn client_company_type;
    }
}