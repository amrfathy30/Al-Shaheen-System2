namespace Al_Shaheen_System
{
    partial class searchincutprintedmaterial
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.client_products_combo_box = new System.Windows.Forms.ComboBox();
            this.clients_combo_box = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.search_btn = new System.Windows.Forms.Button();
            this.exchange_btn = new System.Windows.Forms.Button();
            this.parcels_cut_printed_parcels_grid_view = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.parcels_cut_printed_parcels_grid_view)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(203, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(435, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "البحث فى الصفيح المقصوص المطبوع";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.client_products_combo_box);
            this.groupBox1.Controls.Add(this.clients_combo_box);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(20, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(819, 79);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "معلومات أصناف الطباعة ";
            // 
            // client_products_combo_box
            // 
            this.client_products_combo_box.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.client_products_combo_box.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.client_products_combo_box.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.client_products_combo_box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.client_products_combo_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.client_products_combo_box.FormattingEnabled = true;
            this.client_products_combo_box.Location = new System.Drawing.Point(49, 25);
            this.client_products_combo_box.Name = "client_products_combo_box";
            this.client_products_combo_box.Size = new System.Drawing.Size(242, 28);
            this.client_products_combo_box.TabIndex = 60;
            // 
            // clients_combo_box
            // 
            this.clients_combo_box.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.clients_combo_box.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.clients_combo_box.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.clients_combo_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clients_combo_box.Location = new System.Drawing.Point(411, 28);
            this.clients_combo_box.Name = "clients_combo_box";
            this.clients_combo_box.Size = new System.Drawing.Size(239, 28);
            this.clients_combo_box.TabIndex = 59;
            this.clients_combo_box.SelectedIndexChanged += new System.EventHandler(this.clients_combo_box_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(312, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 25);
            this.label2.TabIndex = 58;
            this.label2.Text = "إسم الصنف";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(678, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 25);
            this.label3.TabIndex = 57;
            this.label3.Text = "إسم العميل";
            // 
            // search_btn
            // 
            this.search_btn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.search_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.search_btn.Location = new System.Drawing.Point(20, 161);
            this.search_btn.Name = "search_btn";
            this.search_btn.Size = new System.Drawing.Size(170, 34);
            this.search_btn.TabIndex = 2;
            this.search_btn.Text = "بحث";
            this.search_btn.UseVisualStyleBackColor = false;
            this.search_btn.Click += new System.EventHandler(this.search_btn_Click);
            // 
            // exchange_btn
            // 
            this.exchange_btn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.exchange_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exchange_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.exchange_btn.Location = new System.Drawing.Point(677, 161);
            this.exchange_btn.Name = "exchange_btn";
            this.exchange_btn.Size = new System.Drawing.Size(162, 34);
            this.exchange_btn.TabIndex = 3;
            this.exchange_btn.Text = "صرف";
            this.exchange_btn.UseVisualStyleBackColor = false;
            this.exchange_btn.Click += new System.EventHandler(this.exchange_btn_Click);
            // 
            // parcels_cut_printed_parcels_grid_view
            // 
            this.parcels_cut_printed_parcels_grid_view.AllowUserToAddRows = false;
            this.parcels_cut_printed_parcels_grid_view.AllowUserToDeleteRows = false;
            this.parcels_cut_printed_parcels_grid_view.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.parcels_cut_printed_parcels_grid_view.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.parcels_cut_printed_parcels_grid_view.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.parcels_cut_printed_parcels_grid_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.parcels_cut_printed_parcels_grid_view.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.parcels_cut_printed_parcels_grid_view.DefaultCellStyle = dataGridViewCellStyle4;
            this.parcels_cut_printed_parcels_grid_view.Location = new System.Drawing.Point(20, 201);
            this.parcels_cut_printed_parcels_grid_view.Name = "parcels_cut_printed_parcels_grid_view";
            this.parcels_cut_printed_parcels_grid_view.ReadOnly = true;
            this.parcels_cut_printed_parcels_grid_view.Size = new System.Drawing.Size(819, 498);
            this.parcels_cut_printed_parcels_grid_view.TabIndex = 4;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "م";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "إسم العميل";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "إسم الصنف";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "عدد العلب";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "عدد الرصات ";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // searchincutprintedmaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(854, 737);
            this.Controls.Add(this.parcels_cut_printed_parcels_grid_view);
            this.Controls.Add(this.exchange_btn);
            this.Controls.Add(this.search_btn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "searchincutprintedmaterial";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "البحث فى الصفيح المقصوص المطبوع";
            this.Load += new System.EventHandler(this.searchincutprintedmaterial_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.parcels_cut_printed_parcels_grid_view)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox client_products_combo_box;
        private System.Windows.Forms.ComboBox clients_combo_box;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button search_btn;
        private System.Windows.Forms.Button exchange_btn;
        private System.Windows.Forms.DataGridView parcels_cut_printed_parcels_grid_view;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}