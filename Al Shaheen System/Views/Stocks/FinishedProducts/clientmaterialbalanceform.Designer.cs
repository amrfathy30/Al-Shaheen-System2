namespace Al_Shaheen_System
{
    partial class clientmaterialbalanceform
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
            this.client_name_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.client_name_combo_box = new System.Windows.Forms.ComboBox();
            this.client_products_combo_box = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.client_material_grid_view = new System.Windows.Forms.DataGridView();
            this.search_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.client_material_grid_view)).BeginInit();
            this.SuspendLayout();
            // 
            // client_name_label
            // 
            this.client_name_label.AutoSize = true;
            this.client_name_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.client_name_label.Location = new System.Drawing.Point(294, 9);
            this.client_name_label.Name = "client_name_label";
            this.client_name_label.Size = new System.Drawing.Size(285, 39);
            this.client_name_label.TabIndex = 0;
            this.client_name_label.Text = "رصيد العميل فى المخزن";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "إسم العميل";
            // 
            // client_name_combo_box
            // 
            this.client_name_combo_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.client_name_combo_box.FormattingEnabled = true;
            this.client_name_combo_box.Location = new System.Drawing.Point(103, 72);
            this.client_name_combo_box.Name = "client_name_combo_box";
            this.client_name_combo_box.Size = new System.Drawing.Size(265, 33);
            this.client_name_combo_box.TabIndex = 2;
            this.client_name_combo_box.SelectedIndexChanged += new System.EventHandler(this.client_name_combo_box_SelectedIndexChanged);
            // 
            // client_products_combo_box
            // 
            this.client_products_combo_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.client_products_combo_box.FormattingEnabled = true;
            this.client_products_combo_box.Location = new System.Drawing.Point(528, 69);
            this.client_products_combo_box.Name = "client_products_combo_box";
            this.client_products_combo_box.Size = new System.Drawing.Size(327, 33);
            this.client_products_combo_box.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(425, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "إسم الصنف";
            // 
            // client_material_grid_view
            // 
            this.client_material_grid_view.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.client_material_grid_view.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.client_material_grid_view.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.client_material_grid_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.client_material_grid_view.DefaultCellStyle = dataGridViewCellStyle2;
            this.client_material_grid_view.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.client_material_grid_view.Location = new System.Drawing.Point(12, 178);
            this.client_material_grid_view.Name = "client_material_grid_view";
            this.client_material_grid_view.Size = new System.Drawing.Size(843, 532);
            this.client_material_grid_view.TabIndex = 5;
            // 
            // search_btn
            // 
            this.search_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_btn.Location = new System.Drawing.Point(12, 132);
            this.search_btn.Name = "search_btn";
            this.search_btn.Size = new System.Drawing.Size(158, 40);
            this.search_btn.TabIndex = 6;
            this.search_btn.Text = "search";
            this.search_btn.UseVisualStyleBackColor = true;
            this.search_btn.Click += new System.EventHandler(this.search_btn_Click);
            // 
            // clientmaterialbalanceform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 756);
            this.Controls.Add(this.search_btn);
            this.Controls.Add(this.client_material_grid_view);
            this.Controls.Add(this.client_products_combo_box);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.client_name_combo_box);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.client_name_label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "clientmaterialbalanceform";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "رصيد العميل فى المخزن";
            this.Load += new System.EventHandler(this.clientmaterialbalanceform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.client_material_grid_view)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label client_name_label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox client_name_combo_box;
        private System.Windows.Forms.ComboBox client_products_combo_box;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView client_material_grid_view;
        private System.Windows.Forms.Button search_btn;
    }
}