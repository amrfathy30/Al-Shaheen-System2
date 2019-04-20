namespace Al_Shaheen_System
{
    partial class allstocksform
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
            this.stocks_data_grid_view = new System.Windows.Forms.DataGridView();
            this.stock_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stock_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.address_text = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.address_link = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.stocks_data_grid_view)).BeginInit();
            this.SuspendLayout();
            // 
            // stocks_data_grid_view
            // 
            this.stocks_data_grid_view.AllowUserToAddRows = false;
            this.stocks_data_grid_view.AllowUserToDeleteRows = false;
            this.stocks_data_grid_view.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.stocks_data_grid_view.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.stocks_data_grid_view.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.stocks_data_grid_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stocks_data_grid_view.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stock_id,
            this.stock_name,
            this.address_text,
            this.address_link});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.stocks_data_grid_view.DefaultCellStyle = dataGridViewCellStyle2;
            this.stocks_data_grid_view.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.stocks_data_grid_view.Location = new System.Drawing.Point(12, 97);
            this.stocks_data_grid_view.Name = "stocks_data_grid_view";
            this.stocks_data_grid_view.ReadOnly = true;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stocks_data_grid_view.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.stocks_data_grid_view.Size = new System.Drawing.Size(765, 423);
            this.stocks_data_grid_view.TabIndex = 0;
            // 
            // stock_id
            // 
            this.stock_id.HeaderText = "رقم المخزن ";
            this.stock_id.Name = "stock_id";
            this.stock_id.ReadOnly = true;
            // 
            // stock_name
            // 
            this.stock_name.HeaderText = "الإسم ";
            this.stock_name.Name = "stock_name";
            this.stock_name.ReadOnly = true;
            // 
            // address_text
            // 
            this.address_text.HeaderText = "نص العنوان ";
            this.address_text.Name = "address_text";
            this.address_text.ReadOnly = true;
            // 
            // address_link
            // 
            this.address_link.HeaderText = "رابط العنوان";
            this.address_link.Name = "address_link";
            this.address_link.ReadOnly = true;
            // 
            // allstocksform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 532);
            this.Controls.Add(this.stocks_data_grid_view);
            this.Name = "allstocksform";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "جميغ مخازن أل شاهين للتجارة والصناعة ";
            this.Load += new System.EventHandler(this.allstocksform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stocks_data_grid_view)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView stocks_data_grid_view;
        private System.Windows.Forms.DataGridViewTextBoxColumn stock_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn stock_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn address_text;
        private System.Windows.Forms.DataGridViewTextBoxColumn address_link;
    }
}