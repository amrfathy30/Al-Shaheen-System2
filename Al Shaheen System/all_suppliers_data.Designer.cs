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
            this.supply_company_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supply_company_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supply_company_telephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supply_company_mobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.company_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.suppliers_grid_view.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.suppliers_grid_view.Location = new System.Drawing.Point(12, 73);
            this.suppliers_grid_view.Name = "suppliers_grid_view";
            this.suppliers_grid_view.ReadOnly = true;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suppliers_grid_view.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.suppliers_grid_view.Size = new System.Drawing.Size(681, 464);
            this.suppliers_grid_view.TabIndex = 0;
            this.suppliers_grid_view.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.suppliers_grid_view_CellDoubleClick);
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
            // all_suppliers_data
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 549);
            this.Controls.Add(this.suppliers_grid_view);
            this.Name = "all_suppliers_data";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "جميع بيانات الموردين ";
            this.Load += new System.EventHandler(this.all_suppliers_data_Load);
            ((System.ComponentModel.ISupportInitialize)(this.suppliers_grid_view)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView suppliers_grid_view;
        private System.Windows.Forms.DataGridViewTextBoxColumn supply_company_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn supply_company_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn supply_company_telephone;
        private System.Windows.Forms.DataGridViewTextBoxColumn supply_company_mobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn company_type;
    }
}