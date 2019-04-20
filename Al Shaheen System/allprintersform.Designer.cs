namespace Al_Shaheen_System
{
    partial class allprintersform
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
            this.printers_grid_view = new System.Windows.Forms.DataGridView();
            this.printer_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printer_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printer_address_text = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printer_address_gps_link = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.printers_grid_view)).BeginInit();
            this.SuspendLayout();
            // 
            // printers_grid_view
            // 
            this.printers_grid_view.AllowUserToAddRows = false;
            this.printers_grid_view.AllowUserToDeleteRows = false;
            this.printers_grid_view.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.printers_grid_view.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.printers_grid_view.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.printers_grid_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.printers_grid_view.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.printer_id,
            this.printer_name,
            this.printer_address_text,
            this.printer_address_gps_link});
            this.printers_grid_view.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.printers_grid_view.Location = new System.Drawing.Point(12, 100);
            this.printers_grid_view.Name = "printers_grid_view";
            this.printers_grid_view.ReadOnly = true;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printers_grid_view.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.printers_grid_view.Size = new System.Drawing.Size(673, 436);
            this.printers_grid_view.TabIndex = 0;
            // 
            // printer_id
            // 
            this.printer_id.HeaderText = "رقم المطبعة ";
            this.printer_id.Name = "printer_id";
            this.printer_id.ReadOnly = true;
            // 
            // printer_name
            // 
            this.printer_name.HeaderText = "إسم المطبعة";
            this.printer_name.Name = "printer_name";
            this.printer_name.ReadOnly = true;
            // 
            // printer_address_text
            // 
            this.printer_address_text.HeaderText = "نص عنوان المطبعة ";
            this.printer_address_text.Name = "printer_address_text";
            this.printer_address_text.ReadOnly = true;
            // 
            // printer_address_gps_link
            // 
            this.printer_address_gps_link.HeaderText = "لينك عنوان المطبعة ";
            this.printer_address_gps_link.Name = "printer_address_gps_link";
            this.printer_address_gps_link.ReadOnly = true;
            // 
            // allprintersform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 563);
            this.Controls.Add(this.printers_grid_view);
            this.Name = "allprintersform";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "جميع المطابع ";
            this.Load += new System.EventHandler(this.allprintersform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.printers_grid_view)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView printers_grid_view;
        private System.Windows.Forms.DataGridViewTextBoxColumn printer_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn printer_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn printer_address_text;
        private System.Windows.Forms.DataGridViewTextBoxColumn printer_address_gps_link;
    }
}