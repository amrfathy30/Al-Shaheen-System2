namespace Al_Shaheen_System
{
    partial class quantities_of_selected_sp_raw_tin
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
            this.quantites_data_grid_view = new System.Windows.Forms.DataGridView();
            this.quantity_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sp_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.specification_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.No_packages = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_number_of_sheets = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_net_weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_gross_weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantities_of_data_grid_view = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.quantites_data_grid_view)).BeginInit();
            this.SuspendLayout();
            // 
            // quantites_data_grid_view
            // 
            this.quantites_data_grid_view.AllowUserToAddRows = false;
            this.quantites_data_grid_view.AllowUserToDeleteRows = false;
            this.quantites_data_grid_view.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.quantites_data_grid_view.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.quantites_data_grid_view.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.quantites_data_grid_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.quantites_data_grid_view.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.quantity_id,
            this.sp_id,
            this.specification_code,
            this.No_packages,
            this.total_number_of_sheets,
            this.total_net_weight,
            this.total_gross_weight});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.quantites_data_grid_view.DefaultCellStyle = dataGridViewCellStyle2;
            this.quantites_data_grid_view.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.quantites_data_grid_view.Location = new System.Drawing.Point(12, 58);
            this.quantites_data_grid_view.Name = "quantites_data_grid_view";
            this.quantites_data_grid_view.ReadOnly = true;
            this.quantites_data_grid_view.Size = new System.Drawing.Size(843, 689);
            this.quantites_data_grid_view.TabIndex = 0;
            // 
            // quantity_id
            // 
            this.quantity_id.HeaderText = "رقم الكمية ";
            this.quantity_id.Name = "quantity_id";
            this.quantity_id.ReadOnly = true;
            // 
            // sp_id
            // 
            this.sp_id.HeaderText = "رقم الصنف";
            this.sp_id.Name = "sp_id";
            this.sp_id.ReadOnly = true;
            // 
            // specification_code
            // 
            this.specification_code.HeaderText = "كود الصنف";
            this.specification_code.Name = "specification_code";
            this.specification_code.ReadOnly = true;
            // 
            // No_packages
            // 
            this.No_packages.HeaderText = "عدد الطرود";
            this.No_packages.Name = "No_packages";
            this.No_packages.ReadOnly = true;
            // 
            // total_number_of_sheets
            // 
            this.total_number_of_sheets.HeaderText = "عدد الافرخ";
            this.total_number_of_sheets.Name = "total_number_of_sheets";
            this.total_number_of_sheets.ReadOnly = true;
            // 
            // total_net_weight
            // 
            this.total_net_weight.HeaderText = "اجمالى الوزن الصافى للكمية ";
            this.total_net_weight.Name = "total_net_weight";
            this.total_net_weight.ReadOnly = true;
            // 
            // total_gross_weight
            // 
            this.total_gross_weight.HeaderText = "اجمالى الوزن القائم";
            this.total_gross_weight.Name = "total_gross_weight";
            this.total_gross_weight.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(302, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 46);
            this.label1.TabIndex = 1;
            this.label1.Text = "الكميات للصنف ";
            // 
            // quantities_of_selected_sp_raw_tin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 759);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.quantites_data_grid_view);
            this.Name = "quantities_of_selected_sp_raw_tin";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "كميات مواصفات الصفيح الخام ";
            this.Load += new System.EventHandler(this.quantities_of_selected_sp_raw_tin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.quantites_data_grid_view)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView quantites_data_grid_view;
        private System.ComponentModel.BackgroundWorker quantities_of_data_grid_view;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn sp_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn specification_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn No_packages;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_number_of_sheets;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_net_weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_gross_weight;
    }
}