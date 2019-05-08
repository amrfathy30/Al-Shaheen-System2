namespace Al_Shaheen_System
{
    partial class all_suppliers_data
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
            this.suppliers_grid_view = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supply_company_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supply_company_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supply_company_telephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supply_company_mobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.company_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.search_text_box = new System.Windows.Forms.TextBox();
            this.search_btn = new System.Windows.Forms.Button();
            this.add_new_supplier_branch_btn = new System.Windows.Forms.Button();
            this.add_new_supplier_item = new System.Windows.Forms.Button();
            this.add_new_supplier_contact = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.suppliers_grid_view)).BeginInit();
            this.SuspendLayout();
            // 
            // suppliers_grid_view
            // 
            this.suppliers_grid_view.AllowUserToAddRows = false;
            this.suppliers_grid_view.AllowUserToDeleteRows = false;
            this.suppliers_grid_view.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.suppliers_grid_view.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.suppliers_grid_view.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.suppliers_grid_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.suppliers_grid_view.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.supply_company_number,
            this.supply_company_name,
            this.supply_company_telephone,
            this.supply_company_mobile,
            this.company_type});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.suppliers_grid_view.DefaultCellStyle = dataGridViewCellStyle2;
            this.suppliers_grid_view.GridColor = System.Drawing.SystemColors.Desktop;
            this.suppliers_grid_view.Location = new System.Drawing.Point(3, 145);
            this.suppliers_grid_view.Name = "suppliers_grid_view";
            this.suppliers_grid_view.ReadOnly = true;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suppliers_grid_view.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.suppliers_grid_view.Size = new System.Drawing.Size(986, 464);
            this.suppliers_grid_view.TabIndex = 0;
            this.suppliers_grid_view.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.suppliers_grid_view_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "م";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // supply_company_number
            // 
            this.supply_company_number.HeaderText = "رقم شركة التوريد ";
            this.supply_company_number.Name = "supply_company_number";
            this.supply_company_number.ReadOnly = true;
            // 
            // supply_company_name
            // 
            this.supply_company_name.HeaderText = "إسم شركة  ";
            this.supply_company_name.Name = "supply_company_name";
            this.supply_company_name.ReadOnly = true;
            // 
            // supply_company_telephone
            // 
            this.supply_company_telephone.HeaderText = "التليفون ";
            this.supply_company_telephone.Name = "supply_company_telephone";
            this.supply_company_telephone.ReadOnly = true;
            // 
            // supply_company_mobile
            // 
            this.supply_company_mobile.HeaderText = "المحمول";
            this.supply_company_mobile.Name = "supply_company_mobile";
            this.supply_company_mobile.ReadOnly = true;
            // 
            // company_type
            // 
            this.company_type.HeaderText = "نوع التوريد ";
            this.company_type.Name = "company_type";
            this.company_type.ReadOnly = true;
            // 
            // search_text_box
            // 
            this.search_text_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_text_box.Location = new System.Drawing.Point(12, 83);
            this.search_text_box.Name = "search_text_box";
            this.search_text_box.Size = new System.Drawing.Size(298, 30);
            this.search_text_box.TabIndex = 1;
            // 
            // search_btn
            // 
            this.search_btn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.search_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.search_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_btn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.search_btn.Location = new System.Drawing.Point(333, 79);
            this.search_btn.Name = "search_btn";
            this.search_btn.Size = new System.Drawing.Size(104, 34);
            this.search_btn.TabIndex = 2;
            this.search_btn.Text = "بحث";
            this.search_btn.UseVisualStyleBackColor = false;
            this.search_btn.Click += new System.EventHandler(this.search_btn_Click);
            // 
            // add_new_supplier_branch_btn
            // 
            this.add_new_supplier_branch_btn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.add_new_supplier_branch_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add_new_supplier_branch_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add_new_supplier_branch_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.add_new_supplier_branch_btn.Location = new System.Drawing.Point(633, 616);
            this.add_new_supplier_branch_btn.Name = "add_new_supplier_branch_btn";
            this.add_new_supplier_branch_btn.Size = new System.Drawing.Size(158, 34);
            this.add_new_supplier_branch_btn.TabIndex = 3;
            this.add_new_supplier_branch_btn.Text = "إضافة فرع";
            this.add_new_supplier_branch_btn.UseVisualStyleBackColor = false;
            this.add_new_supplier_branch_btn.Click += new System.EventHandler(this.add_new_supplier_branch_btn_Click);
            // 
            // add_new_supplier_item
            // 
            this.add_new_supplier_item.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.add_new_supplier_item.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add_new_supplier_item.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add_new_supplier_item.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.add_new_supplier_item.Location = new System.Drawing.Point(472, 616);
            this.add_new_supplier_item.Name = "add_new_supplier_item";
            this.add_new_supplier_item.Size = new System.Drawing.Size(113, 34);
            this.add_new_supplier_item.TabIndex = 4;
            this.add_new_supplier_item.Text = "إضافة صنف";
            this.add_new_supplier_item.UseVisualStyleBackColor = false;
            this.add_new_supplier_item.Click += new System.EventHandler(this.add_new_supplier_item_Click);
            // 
            // add_new_supplier_contact
            // 
            this.add_new_supplier_contact.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.add_new_supplier_contact.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add_new_supplier_contact.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add_new_supplier_contact.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.add_new_supplier_contact.Location = new System.Drawing.Point(833, 615);
            this.add_new_supplier_contact.Name = "add_new_supplier_contact";
            this.add_new_supplier_contact.Size = new System.Drawing.Size(156, 35);
            this.add_new_supplier_contact.TabIndex = 5;
            this.add_new_supplier_contact.Text = "إضافة موظف";
            this.add_new_supplier_contact.UseVisualStyleBackColor = false;
            this.add_new_supplier_contact.Click += new System.EventHandler(this.add_new_supplier_contact_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(316, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 39);
            this.label1.TabIndex = 6;
            this.label1.Text = "جميع بيانات الموردين";
            // 
            // all_suppliers_data
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1001, 673);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.add_new_supplier_contact);
            this.Controls.Add(this.add_new_supplier_item);
            this.Controls.Add(this.add_new_supplier_branch_btn);
            this.Controls.Add(this.search_btn);
            this.Controls.Add(this.search_text_box);
            this.Controls.Add(this.suppliers_grid_view);
            this.Name = "all_suppliers_data";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "جميع بيانات الموردين ";
            this.Activated += new System.EventHandler(this.all_suppliers_data_Activated);
            this.Load += new System.EventHandler(this.all_suppliers_data_Load);
            ((System.ComponentModel.ISupportInitialize)(this.suppliers_grid_view)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView suppliers_grid_view;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn supply_company_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn supply_company_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn supply_company_telephone;
        private System.Windows.Forms.DataGridViewTextBoxColumn supply_company_mobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn company_type;
        private System.Windows.Forms.TextBox search_text_box;
        private System.Windows.Forms.Button search_btn;
        private System.Windows.Forms.Button add_new_supplier_branch_btn;
        private System.Windows.Forms.Button add_new_supplier_item;
        private System.Windows.Forms.Button add_new_supplier_contact;
        private System.Windows.Forms.Label label1;
    }
}