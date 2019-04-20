namespace Al_Shaheen_System
{
    partial class Bottomaddingform
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.supplier_branches_combo_box = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.suppliers_combo_box = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.sizes_combo_box = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.usage_combo_box = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.material_type_combo_box = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.f2_combo_box = new System.Windows.Forms.ComboBox();
            this.f2_label = new System.Windows.Forms.Label();
            this.F1_combo_box = new System.Windows.Forms.ComboBox();
            this.f1_label = new System.Windows.Forms.Label();
            this.f1_printing_stat = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.no_of_items_per_container = new System.Windows.Forms.TextBox();
            this.total_no_of_products_text_box = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.no_of_container_text_box = new System.Windows.Forms.TextBox();
            this.p_container_no_label = new System.Windows.Forms.Label();
            this.p_no_per_comtainer_label = new System.Windows.Forms.Label();
            this.container_types_combo_box = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.save_easy_open_btn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.addition_permission_number_text_box = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.stock_men_combo_box = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.stocks_combo_box = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(304, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "إضافة قاع";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.supplier_branches_combo_box);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.suppliers_combo_box);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(28, 153);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(743, 59);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "معلومات المورد";
            // 
            // supplier_branches_combo_box
            // 
            this.supplier_branches_combo_box.FormattingEnabled = true;
            this.supplier_branches_combo_box.Location = new System.Drawing.Point(24, 23);
            this.supplier_branches_combo_box.Name = "supplier_branches_combo_box";
            this.supplier_branches_combo_box.Size = new System.Drawing.Size(222, 28);
            this.supplier_branches_combo_box.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(284, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "إسم الفرع";
            // 
            // suppliers_combo_box
            // 
            this.suppliers_combo_box.FormattingEnabled = true;
            this.suppliers_combo_box.Location = new System.Drawing.Point(397, 23);
            this.suppliers_combo_box.Name = "suppliers_combo_box";
            this.suppliers_combo_box.Size = new System.Drawing.Size(222, 28);
            this.suppliers_combo_box.TabIndex = 1;
            this.suppliers_combo_box.SelectedIndexChanged += new System.EventHandler(this.suppliers_combo_box_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(638, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "إسم المورد";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.sizes_combo_box);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.usage_combo_box);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.material_type_combo_box);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(28, 312);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(743, 138);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "معلومات المنتج ";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // sizes_combo_box
            // 
            this.sizes_combo_box.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.sizes_combo_box.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.sizes_combo_box.FormattingEnabled = true;
            this.sizes_combo_box.Location = new System.Drawing.Point(397, 83);
            this.sizes_combo_box.Name = "sizes_combo_box";
            this.sizes_combo_box.Size = new System.Drawing.Size(223, 28);
            this.sizes_combo_box.TabIndex = 44;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(640, 86);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 20);
            this.label11.TabIndex = 43;
            this.label11.Text = "المقاس";
            // 
            // usage_combo_box
            // 
            this.usage_combo_box.FormattingEnabled = true;
            this.usage_combo_box.Items.AddRange(new object[] {
            "غذائي",
            "بودر"});
            this.usage_combo_box.Location = new System.Drawing.Point(24, 37);
            this.usage_combo_box.Name = "usage_combo_box";
            this.usage_combo_box.Size = new System.Drawing.Size(222, 28);
            this.usage_combo_box.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(284, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "الإستخدام";
            // 
            // material_type_combo_box
            // 
            this.material_type_combo_box.FormattingEnabled = true;
            this.material_type_combo_box.Items.AddRange(new object[] {
            "ETP",
            "TFS",
            "ALU"});
            this.material_type_combo_box.Location = new System.Drawing.Point(397, 37);
            this.material_type_combo_box.Name = "material_type_combo_box";
            this.material_type_combo_box.Size = new System.Drawing.Size(222, 28);
            this.material_type_combo_box.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(638, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "نوع الخام ";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(28, 467);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(743, 179);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "معلومات الطباعة";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.f2_combo_box);
            this.groupBox5.Controls.Add(this.f2_label);
            this.groupBox5.Controls.Add(this.F1_combo_box);
            this.groupBox5.Controls.Add(this.f1_label);
            this.groupBox5.Controls.Add(this.f1_printing_stat);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Location = new System.Drawing.Point(24, 37);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(700, 121);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "الطلاء";
            // 
            // f2_combo_box
            // 
            this.f2_combo_box.FormattingEnabled = true;
            this.f2_combo_box.Location = new System.Drawing.Point(6, 67);
            this.f2_combo_box.Name = "f2_combo_box";
            this.f2_combo_box.Size = new System.Drawing.Size(216, 28);
            this.f2_combo_box.TabIndex = 5;
            // 
            // f2_label
            // 
            this.f2_label.AutoSize = true;
            this.f2_label.Location = new System.Drawing.Point(281, 67);
            this.f2_label.Name = "f2_label";
            this.f2_label.Size = new System.Drawing.Size(28, 20);
            this.f2_label.TabIndex = 4;
            this.f2_label.Text = "F1";
            // 
            // F1_combo_box
            // 
            this.F1_combo_box.FormattingEnabled = true;
            this.F1_combo_box.Location = new System.Drawing.Point(374, 67);
            this.F1_combo_box.Name = "F1_combo_box";
            this.F1_combo_box.Size = new System.Drawing.Size(221, 28);
            this.F1_combo_box.TabIndex = 3;
            this.F1_combo_box.SelectedIndexChanged += new System.EventHandler(this.F1_combo_box_SelectedIndexChanged);
            // 
            // f1_label
            // 
            this.f1_label.AutoSize = true;
            this.f1_label.Location = new System.Drawing.Point(649, 75);
            this.f1_label.Name = "f1_label";
            this.f1_label.Size = new System.Drawing.Size(28, 20);
            this.f1_label.TabIndex = 2;
            this.f1_label.Text = "F1";
            // 
            // f1_printing_stat
            // 
            this.f1_printing_stat.FormattingEnabled = true;
            this.f1_printing_stat.Items.AddRange(new object[] {
            "مطبوع",
            "مورنش"});
            this.f1_printing_stat.Location = new System.Drawing.Point(374, 25);
            this.f1_printing_stat.Name = "f1_printing_stat";
            this.f1_printing_stat.Size = new System.Drawing.Size(221, 28);
            this.f1_printing_stat.Sorted = true;
            this.f1_printing_stat.TabIndex = 1;
            this.f1_printing_stat.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(599, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "حالة الطباعة ";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.no_of_items_per_container);
            this.groupBox7.Controls.Add(this.total_no_of_products_text_box);
            this.groupBox7.Controls.Add(this.label10);
            this.groupBox7.Controls.Add(this.no_of_container_text_box);
            this.groupBox7.Controls.Add(this.p_container_no_label);
            this.groupBox7.Controls.Add(this.p_no_per_comtainer_label);
            this.groupBox7.Controls.Add(this.container_types_combo_box);
            this.groupBox7.Controls.Add(this.label8);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(28, 652);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(742, 145);
            this.groupBox7.TabIndex = 4;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "التعبئة";
            // 
            // no_of_items_per_container
            // 
            this.no_of_items_per_container.Location = new System.Drawing.Point(23, 28);
            this.no_of_items_per_container.Name = "no_of_items_per_container";
            this.no_of_items_per_container.Size = new System.Drawing.Size(222, 26);
            this.no_of_items_per_container.TabIndex = 8;
            this.no_of_items_per_container.TextChanged += new System.EventHandler(this.no_of_items_per_container_TextChanged);
            // 
            // total_no_of_products_text_box
            // 
            this.total_no_of_products_text_box.Enabled = false;
            this.total_no_of_products_text_box.Location = new System.Drawing.Point(23, 78);
            this.total_no_of_products_text_box.Name = "total_no_of_products_text_box";
            this.total_no_of_products_text_box.Size = new System.Drawing.Size(222, 26);
            this.total_no_of_products_text_box.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(284, 81);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 20);
            this.label10.TabIndex = 6;
            this.label10.Text = "إجمالى العدد";
            // 
            // no_of_container_text_box
            // 
            this.no_of_container_text_box.Location = new System.Drawing.Point(397, 83);
            this.no_of_container_text_box.Name = "no_of_container_text_box";
            this.no_of_container_text_box.Size = new System.Drawing.Size(221, 26);
            this.no_of_container_text_box.TabIndex = 5;
            this.no_of_container_text_box.TextChanged += new System.EventHandler(this.no_of_container_text_box_TextChanged);
            // 
            // p_container_no_label
            // 
            this.p_container_no_label.AutoSize = true;
            this.p_container_no_label.Location = new System.Drawing.Point(620, 86);
            this.p_container_no_label.Name = "p_container_no_label";
            this.p_container_no_label.Size = new System.Drawing.Size(80, 20);
            this.p_container_no_label.TabIndex = 4;
            this.p_container_no_label.Text = "عدد الحاويات ";
            // 
            // p_no_per_comtainer_label
            // 
            this.p_no_per_comtainer_label.AutoSize = true;
            this.p_no_per_comtainer_label.Location = new System.Drawing.Point(284, 31);
            this.p_no_per_comtainer_label.Name = "p_no_per_comtainer_label";
            this.p_no_per_comtainer_label.Size = new System.Drawing.Size(48, 20);
            this.p_no_per_comtainer_label.TabIndex = 2;
            this.p_no_per_comtainer_label.Text = "العدد /  ";
            // 
            // container_types_combo_box
            // 
            this.container_types_combo_box.FormattingEnabled = true;
            this.container_types_combo_box.Items.AddRange(new object[] {
            "كرتونة ",
            "بالتة"});
            this.container_types_combo_box.Location = new System.Drawing.Point(397, 36);
            this.container_types_combo_box.Name = "container_types_combo_box";
            this.container_types_combo_box.Size = new System.Drawing.Size(221, 28);
            this.container_types_combo_box.TabIndex = 1;
            this.container_types_combo_box.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(630, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "نوع الحاوية";
            // 
            // save_easy_open_btn
            // 
            this.save_easy_open_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save_easy_open_btn.Location = new System.Drawing.Point(28, 834);
            this.save_easy_open_btn.Name = "save_easy_open_btn";
            this.save_easy_open_btn.Size = new System.Drawing.Size(132, 40);
            this.save_easy_open_btn.TabIndex = 5;
            this.save_easy_open_btn.Text = "حفظ";
            this.save_easy_open_btn.UseVisualStyleBackColor = true;
            this.save_easy_open_btn.Click += new System.EventHandler(this.save_BOTTOM_btn_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(357, 834);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 40);
            this.button1.TabIndex = 6;
            this.button1.Text = "جديد";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(639, 834);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(132, 40);
            this.button2.TabIndex = 7;
            this.button2.Text = "إلغاء";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(29, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "رقم إذن الإضافة";
            // 
            // addition_permission_number_text_box
            // 
            this.addition_permission_number_text_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addition_permission_number_text_box.Location = new System.Drawing.Point(151, 111);
            this.addition_permission_number_text_box.Name = "addition_permission_number_text_box";
            this.addition_permission_number_text_box.Size = new System.Drawing.Size(223, 26);
            this.addition_permission_number_text_box.TabIndex = 9;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.stock_men_combo_box);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.stocks_combo_box);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(28, 218);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(743, 88);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "معلومات المخازن";
            // 
            // stock_men_combo_box
            // 
            this.stock_men_combo_box.FormattingEnabled = true;
            this.stock_men_combo_box.Location = new System.Drawing.Point(24, 37);
            this.stock_men_combo_box.Name = "stock_men_combo_box";
            this.stock_men_combo_box.Size = new System.Drawing.Size(222, 28);
            this.stock_men_combo_box.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(284, 45);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 20);
            this.label12.TabIndex = 2;
            this.label12.Text = "إمين المخزن ";
            // 
            // stocks_combo_box
            // 
            this.stocks_combo_box.FormattingEnabled = true;
            this.stocks_combo_box.Location = new System.Drawing.Point(398, 37);
            this.stocks_combo_box.Name = "stocks_combo_box";
            this.stocks_combo_box.Size = new System.Drawing.Size(222, 28);
            this.stocks_combo_box.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(650, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "المخزن ";
            // 
            // Bottomaddingform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 896);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.addition_permission_number_text_box);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.save_easy_open_btn);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "Bottomaddingform";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إضافة المنتج التام Easy Open";
            this.Load += new System.EventHandler(this.Easyopenaddingform_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox suppliers_combo_box;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox supplier_branches_combo_box;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox material_type_combo_box;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label f1_label;
        private System.Windows.Forms.ComboBox F1_combo_box;
        private System.Windows.Forms.ComboBox f2_combo_box;
        private System.Windows.Forms.Label f2_label;
        private System.Windows.Forms.ComboBox usage_combo_box;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.ComboBox container_types_combo_box;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label p_no_per_comtainer_label;
        private System.Windows.Forms.Label p_container_no_label;
        private System.Windows.Forms.TextBox no_of_container_text_box;
        private System.Windows.Forms.TextBox total_no_of_products_text_box;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button save_easy_open_btn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox no_of_items_per_container;
        private System.Windows.Forms.ComboBox sizes_combo_box;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox addition_permission_number_text_box;
        private System.Windows.Forms.ComboBox f1_printing_stat;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox stock_men_combo_box;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox stocks_combo_box;
        private System.Windows.Forms.Label label9;
    }
}