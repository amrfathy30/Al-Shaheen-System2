﻿namespace Al_Shaheen_System
{
    partial class addnewclientproduct
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.product_name_text_box = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.sizes_combo_box = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.height_text_box = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.capacity_tect_box = new System.Windows.Forms.TextBox();
            this.save_new_client_product_btn = new System.Windows.Forms.Button();
            this.new_client_product_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.client_name_text_box = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.products_grid_view = new System.Windows.Forms.DataGridView();
            this.product_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shape_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printing_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.first_dimention_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product_first_diameter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.second_dimention_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seconddimention = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.surrounding = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_height = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.second_face = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.add_new_face_btn = new System.Windows.Forms.Button();
            this.faces_combo_box = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.head_radio_btn = new System.Windows.Forms.RadioButton();
            this.bottom_radio_btn = new System.Windows.Forms.RadioButton();
            this.body_radio_btn = new System.Windows.Forms.RadioButton();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.products_grid_view)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(54, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(369, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "إضافة صنف جديد للعميل";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(326, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "إسم الصنف";
            // 
            // product_name_text_box
            // 
            this.product_name_text_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.product_name_text_box.Location = new System.Drawing.Point(45, 44);
            this.product_name_text_box.Name = "product_name_text_box";
            this.product_name_text_box.Size = new System.Drawing.Size(257, 30);
            this.product_name_text_box.TabIndex = 2;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.sizes_combo_box);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.height_text_box);
            this.groupBox5.Controls.Add(this.label34);
            this.groupBox5.Controls.Add(this.label30);
            this.groupBox5.Controls.Add(this.capacity_tect_box);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(12, 394);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(427, 190);
            this.groupBox5.TabIndex = 44;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "معلومات المقاس";
            // 
            // sizes_combo_box
            // 
            this.sizes_combo_box.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.sizes_combo_box.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.sizes_combo_box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sizes_combo_box.FormattingEnabled = true;
            this.sizes_combo_box.Location = new System.Drawing.Point(31, 44);
            this.sizes_combo_box.Name = "sizes_combo_box";
            this.sizes_combo_box.Size = new System.Drawing.Size(254, 28);
            this.sizes_combo_box.TabIndex = 42;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(357, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 20);
            this.label6.TabIndex = 41;
            this.label6.Text = "المقاس";
            // 
            // height_text_box
            // 
            this.height_text_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.height_text_box.Location = new System.Drawing.Point(31, 122);
            this.height_text_box.Name = "height_text_box";
            this.height_text_box.Size = new System.Drawing.Size(254, 30);
            this.height_text_box.TabIndex = 38;
            this.height_text_box.TextChanged += new System.EventHandler(this.height_text_box_TextChanged);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(295, 126);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(105, 25);
            this.label34.TabIndex = 37;
            this.label34.Text = "إرتفاع الشرحة";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(353, 89);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(47, 25);
            this.label30.TabIndex = 25;
            this.label30.Text = "السعة";
            // 
            // capacity_tect_box
            // 
            this.capacity_tect_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.capacity_tect_box.Location = new System.Drawing.Point(31, 84);
            this.capacity_tect_box.Name = "capacity_tect_box";
            this.capacity_tect_box.Size = new System.Drawing.Size(254, 30);
            this.capacity_tect_box.TabIndex = 26;
            this.capacity_tect_box.TextChanged += new System.EventHandler(this.capacity_tect_box_TextChanged);
            // 
            // save_new_client_product_btn
            // 
            this.save_new_client_product_btn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.save_new_client_product_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save_new_client_product_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save_new_client_product_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.save_new_client_product_btn.Location = new System.Drawing.Point(4, 610);
            this.save_new_client_product_btn.Name = "save_new_client_product_btn";
            this.save_new_client_product_btn.Size = new System.Drawing.Size(117, 40);
            this.save_new_client_product_btn.TabIndex = 46;
            this.save_new_client_product_btn.Text = "حفظ ";
            this.save_new_client_product_btn.UseVisualStyleBackColor = false;
            this.save_new_client_product_btn.Click += new System.EventHandler(this.save_new_client_product_btn_Click);
            // 
            // new_client_product_btn
            // 
            this.new_client_product_btn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.new_client_product_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.new_client_product_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.new_client_product_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.new_client_product_btn.Location = new System.Drawing.Point(160, 610);
            this.new_client_product_btn.Name = "new_client_product_btn";
            this.new_client_product_btn.Size = new System.Drawing.Size(125, 40);
            this.new_client_product_btn.TabIndex = 47;
            this.new_client_product_btn.Text = "جديد";
            this.new_client_product_btn.UseVisualStyleBackColor = false;
            // 
            // cancel_btn
            // 
            this.cancel_btn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.cancel_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cancel_btn.Location = new System.Drawing.Point(319, 610);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(110, 40);
            this.cancel_btn.TabIndex = 48;
            this.cancel_btn.Text = "إلغاء";
            this.cancel_btn.UseVisualStyleBackColor = false;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // client_name_text_box
            // 
            this.client_name_text_box.Enabled = false;
            this.client_name_text_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.client_name_text_box.Location = new System.Drawing.Point(118, 113);
            this.client_name_text_box.Name = "client_name_text_box";
            this.client_name_text_box.Size = new System.Drawing.Size(321, 30);
            this.client_name_text_box.TabIndex = 50;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(38, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 25);
            this.label3.TabIndex = 49;
            this.label3.Text = "إسم العميل";
            // 
            // products_grid_view
            // 
            this.products_grid_view.AllowUserToAddRows = false;
            this.products_grid_view.AllowUserToDeleteRows = false;
            this.products_grid_view.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.products_grid_view.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.products_grid_view.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.products_grid_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.products_grid_view.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.product_id,
            this.product_name,
            this.shape_type,
            this.printing_type,
            this.first_dimention_name,
            this.product_first_diameter,
            this.second_dimention_name,
            this.seconddimention,
            this.surrounding,
            this.item_height,
            this.second_face});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.products_grid_view.DefaultCellStyle = dataGridViewCellStyle2;
            this.products_grid_view.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.products_grid_view.Location = new System.Drawing.Point(459, 35);
            this.products_grid_view.Name = "products_grid_view";
            this.products_grid_view.ReadOnly = true;
            this.products_grid_view.Size = new System.Drawing.Size(811, 615);
            this.products_grid_view.TabIndex = 51;
            // 
            // product_id
            // 
            this.product_id.HeaderText = "رقم المنتج";
            this.product_id.Name = "product_id";
            this.product_id.ReadOnly = true;
            // 
            // product_name
            // 
            this.product_name.HeaderText = "إسم الصنف";
            this.product_name.Name = "product_name";
            this.product_name.ReadOnly = true;
            // 
            // shape_type
            // 
            this.shape_type.HeaderText = "إسم الشكل";
            this.shape_type.Name = "shape_type";
            this.shape_type.ReadOnly = true;
            // 
            // printing_type
            // 
            this.printing_type.HeaderText = "نوع الطباعة";
            this.printing_type.Name = "printing_type";
            this.printing_type.ReadOnly = true;
            // 
            // first_dimention_name
            // 
            this.first_dimention_name.HeaderText = "إسم البعد الاول";
            this.first_dimention_name.Name = "first_dimention_name";
            this.first_dimention_name.ReadOnly = true;
            // 
            // product_first_diameter
            // 
            this.product_first_diameter.HeaderText = "البعد الأول";
            this.product_first_diameter.Name = "product_first_diameter";
            this.product_first_diameter.ReadOnly = true;
            // 
            // second_dimention_name
            // 
            this.second_dimention_name.HeaderText = "إسم البعد الثانى ";
            this.second_dimention_name.Name = "second_dimention_name";
            this.second_dimention_name.ReadOnly = true;
            // 
            // seconddimention
            // 
            this.seconddimention.HeaderText = "البعد الثانى ";
            this.seconddimention.Name = "seconddimention";
            this.seconddimention.ReadOnly = true;
            // 
            // surrounding
            // 
            this.surrounding.HeaderText = "المحيط";
            this.surrounding.Name = "surrounding";
            this.surrounding.ReadOnly = true;
            // 
            // item_height
            // 
            this.item_height.HeaderText = "الارتفاع";
            this.item_height.Name = "item_height";
            this.item_height.ReadOnly = true;
            // 
            // second_face
            // 
            this.second_face.HeaderText = "الوجة الثانى ";
            this.second_face.Name = "second_face";
            this.second_face.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.add_new_face_btn);
            this.groupBox1.Controls.Add(this.faces_combo_box);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.product_name_text_box);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(23, 216);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(430, 165);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "معلومات الطباعة";
            // 
            // add_new_face_btn
            // 
            this.add_new_face_btn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.add_new_face_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add_new_face_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add_new_face_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.add_new_face_btn.Location = new System.Drawing.Point(172, 119);
            this.add_new_face_btn.Name = "add_new_face_btn";
            this.add_new_face_btn.Size = new System.Drawing.Size(127, 35);
            this.add_new_face_btn.TabIndex = 53;
            this.add_new_face_btn.Text = "إضافة وجة جديد";
            this.add_new_face_btn.UseVisualStyleBackColor = false;
            // 
            // faces_combo_box
            // 
            this.faces_combo_box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.faces_combo_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.faces_combo_box.FormattingEnabled = true;
            this.faces_combo_box.Location = new System.Drawing.Point(45, 80);
            this.faces_combo_box.Name = "faces_combo_box";
            this.faces_combo_box.Size = new System.Drawing.Size(254, 33);
            this.faces_combo_box.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(312, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "الوجة الداخلى ";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.head_radio_btn);
            this.groupBox4.Controls.Add(this.bottom_radio_btn);
            this.groupBox4.Controls.Add(this.body_radio_btn);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(36, 153);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(403, 57);
            this.groupBox4.TabIndex = 46;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "نوع الطباعة";
            // 
            // head_radio_btn
            // 
            this.head_radio_btn.AutoSize = true;
            this.head_radio_btn.Location = new System.Drawing.Point(31, 25);
            this.head_radio_btn.Name = "head_radio_btn";
            this.head_radio_btn.Size = new System.Drawing.Size(55, 24);
            this.head_radio_btn.TabIndex = 2;
            this.head_radio_btn.TabStop = true;
            this.head_radio_btn.Text = "غطاء";
            this.head_radio_btn.UseVisualStyleBackColor = true;
            // 
            // bottom_radio_btn
            // 
            this.bottom_radio_btn.AutoSize = true;
            this.bottom_radio_btn.Location = new System.Drawing.Point(167, 25);
            this.bottom_radio_btn.Name = "bottom_radio_btn";
            this.bottom_radio_btn.Size = new System.Drawing.Size(44, 24);
            this.bottom_radio_btn.TabIndex = 1;
            this.bottom_radio_btn.TabStop = true;
            this.bottom_radio_btn.Text = "قاع";
            this.bottom_radio_btn.UseVisualStyleBackColor = true;
            // 
            // body_radio_btn
            // 
            this.body_radio_btn.AutoSize = true;
            this.body_radio_btn.Location = new System.Drawing.Point(277, 25);
            this.body_radio_btn.Name = "body_radio_btn";
            this.body_radio_btn.Size = new System.Drawing.Size(44, 24);
            this.body_radio_btn.TabIndex = 0;
            this.body_radio_btn.TabStop = true;
            this.body_radio_btn.Text = "بدن";
            this.body_radio_btn.UseVisualStyleBackColor = true;
            this.body_radio_btn.CheckedChanged += new System.EventHandler(this.body_radio_btn_CheckedChanged);
            // 
            // addnewclientproduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1282, 674);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.products_grid_view);
            this.Controls.Add(this.client_name_text_box);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.new_client_product_btn);
            this.Controls.Add(this.save_new_client_product_btn);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.label1);
            this.Name = "addnewclientproduct";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إضافة صنف جديد للعميل";
            this.Load += new System.EventHandler(this.addnewclientproduct_Load);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.products_grid_view)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox product_name_text_box;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox height_text_box;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox capacity_tect_box;
        private System.Windows.Forms.Button save_new_client_product_btn;
        private System.Windows.Forms.Button new_client_product_btn;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.TextBox client_name_text_box;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView products_grid_view;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton head_radio_btn;
        private System.Windows.Forms.RadioButton bottom_radio_btn;
        private System.Windows.Forms.RadioButton body_radio_btn;
        private System.Windows.Forms.ComboBox faces_combo_box;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button add_new_face_btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn shape_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn printing_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn first_dimention_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_first_diameter;
        private System.Windows.Forms.DataGridViewTextBoxColumn second_dimention_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn seconddimention;
        private System.Windows.Forms.DataGridViewTextBoxColumn surrounding;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_height;
        private System.Windows.Forms.DataGridViewTextBoxColumn second_face;
        private System.Windows.Forms.ComboBox sizes_combo_box;
        private System.Windows.Forms.Label label6;
    }
}