namespace Al_Shaheen_System
{
    partial class addnewclientproductfilm
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
            this.label2 = new System.Windows.Forms.Label();
            this.film_code_text_box = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.film_length_text_box = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.client_combo_box = new System.Windows.Forms.ComboBox();
            this.client_product_combo_box = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.removefromlistbtn = new System.Windows.Forms.Button();
            this.addnewclientproductbtn = new System.Windows.Forms.Button();
            this.browse_btn = new System.Windows.Forms.Button();
            this.savebtn = new System.Windows.Forms.Button();
            this.newbtn = new System.Windows.Forms.Button();
            this.cancelbtn = new System.Windows.Forms.Button();
            this.film_width_text_box = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.no_of_products_per_sheet_text_box = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.film_picture_box = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.film_picture_box)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(512, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "إضافة فيلم صنف جديد";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "كود الفيلم";
            // 
            // film_code_text_box
            // 
            this.film_code_text_box.Enabled = false;
            this.film_code_text_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.film_code_text_box.Location = new System.Drawing.Point(88, 93);
            this.film_code_text_box.Name = "film_code_text_box";
            this.film_code_text_box.Size = new System.Drawing.Size(462, 29);
            this.film_code_text_box.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.no_of_products_per_sheet_text_box);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.addnewclientproductbtn);
            this.groupBox1.Controls.Add(this.removefromlistbtn);
            this.groupBox1.Controls.Add(this.client_product_combo_box);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.client_combo_box);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 128);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(538, 465);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "إضافة أصناف الفيلم الواحد";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.film_width_text_box);
            this.groupBox2.Controls.Add(this.film_length_text_box);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 601);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(538, 100);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "مقاس الفيلم";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(470, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "الطول";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(209, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 21);
            this.label4.TabIndex = 1;
            this.label4.Text = "العرض";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // film_length_text_box
            // 
            this.film_length_text_box.Location = new System.Drawing.Point(336, 43);
            this.film_length_text_box.Name = "film_length_text_box";
            this.film_length_text_box.Size = new System.Drawing.Size(128, 28);
            this.film_length_text_box.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(435, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "العميل";
            // 
            // client_combo_box
            // 
            this.client_combo_box.FormattingEnabled = true;
            this.client_combo_box.Location = new System.Drawing.Point(251, 36);
            this.client_combo_box.Name = "client_combo_box";
            this.client_combo_box.Size = new System.Drawing.Size(178, 28);
            this.client_combo_box.TabIndex = 1;
            this.client_combo_box.SelectedIndexChanged += new System.EventHandler(this.client_combo_box_SelectedIndexChanged);
            this.client_combo_box.TextChanged += new System.EventHandler(this.client_combo_box_TextChanged);
            // 
            // client_product_combo_box
            // 
            this.client_product_combo_box.FormattingEnabled = true;
            this.client_product_combo_box.Location = new System.Drawing.Point(21, 41);
            this.client_product_combo_box.Name = "client_product_combo_box";
            this.client_product_combo_box.Size = new System.Drawing.Size(167, 28);
            this.client_product_combo_box.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(201, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "الصنف";
            // 
            // removefromlistbtn
            // 
            this.removefromlistbtn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.removefromlistbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removefromlistbtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.removefromlistbtn.Location = new System.Drawing.Point(20, 399);
            this.removefromlistbtn.Name = "removefromlistbtn";
            this.removefromlistbtn.Size = new System.Drawing.Size(142, 38);
            this.removefromlistbtn.TabIndex = 5;
            this.removefromlistbtn.Text = "مسح من القائمة";
            this.removefromlistbtn.UseVisualStyleBackColor = false;
            this.removefromlistbtn.Click += new System.EventHandler(this.removefromlistbtn_Click);
            // 
            // addnewclientproductbtn
            // 
            this.addnewclientproductbtn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.addnewclientproductbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addnewclientproductbtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.addnewclientproductbtn.Location = new System.Drawing.Point(21, 115);
            this.addnewclientproductbtn.Name = "addnewclientproductbtn";
            this.addnewclientproductbtn.Size = new System.Drawing.Size(142, 32);
            this.addnewclientproductbtn.TabIndex = 6;
            this.addnewclientproductbtn.Text = "إضافة صنف جديد";
            this.addnewclientproductbtn.UseVisualStyleBackColor = false;
            this.addnewclientproductbtn.Click += new System.EventHandler(this.addnewclientproductbtn_Click);
            // 
            // browse_btn
            // 
            this.browse_btn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.browse_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browse_btn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.browse_btn.Location = new System.Drawing.Point(1303, 714);
            this.browse_btn.Name = "browse_btn";
            this.browse_btn.Size = new System.Drawing.Size(104, 41);
            this.browse_btn.TabIndex = 6;
            this.browse_btn.Text = "تصفح";
            this.browse_btn.UseVisualStyleBackColor = false;
            this.browse_btn.Click += new System.EventHandler(this.browse_btn_Click);
            // 
            // savebtn
            // 
            this.savebtn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.savebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.savebtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savebtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.savebtn.Location = new System.Drawing.Point(12, 707);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(112, 41);
            this.savebtn.TabIndex = 7;
            this.savebtn.Text = "حفظ";
            this.savebtn.UseVisualStyleBackColor = false;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // newbtn
            // 
            this.newbtn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.newbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newbtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newbtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.newbtn.Location = new System.Drawing.Point(244, 707);
            this.newbtn.Name = "newbtn";
            this.newbtn.Size = new System.Drawing.Size(112, 41);
            this.newbtn.TabIndex = 8;
            this.newbtn.Text = "جديد";
            this.newbtn.UseVisualStyleBackColor = false;
            this.newbtn.Click += new System.EventHandler(this.newbtn_Click);
            // 
            // cancelbtn
            // 
            this.cancelbtn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.cancelbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelbtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelbtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cancelbtn.Location = new System.Drawing.Point(448, 707);
            this.cancelbtn.Name = "cancelbtn";
            this.cancelbtn.Size = new System.Drawing.Size(102, 41);
            this.cancelbtn.TabIndex = 9;
            this.cancelbtn.Text = "إلغاء";
            this.cancelbtn.UseVisualStyleBackColor = false;
            this.cancelbtn.Click += new System.EventHandler(this.cancelbtn_Click);
            // 
            // film_width_text_box
            // 
            this.film_width_text_box.Location = new System.Drawing.Point(75, 43);
            this.film_width_text_box.Name = "film_width_text_box";
            this.film_width_text_box.Size = new System.Drawing.Size(128, 28);
            this.film_width_text_box.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(307, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 21);
            this.label7.TabIndex = 4;
            this.label7.Text = "مم";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(46, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 21);
            this.label8.TabIndex = 5;
            this.label8.Text = "مم";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(424, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 20);
            this.label9.TabIndex = 7;
            this.label9.Text = "العدد بالفرخ";
            // 
            // no_of_products_per_sheet_text_box
            // 
            this.no_of_products_per_sheet_text_box.Location = new System.Drawing.Point(251, 106);
            this.no_of_products_per_sheet_text_box.Name = "no_of_products_per_sheet_text_box";
            this.no_of_products_per_sheet_text_box.Size = new System.Drawing.Size(178, 26);
            this.no_of_products_per_sheet_text_box.TabIndex = 8;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ButtonShadow;
            this.dataGridView1.Location = new System.Drawing.Point(21, 153);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(484, 240);
            this.dataGridView1.TabIndex = 9;
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
            this.Column4.HeaderText = "العدد / الفرخ";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.film_picture_box);
            this.panel1.Location = new System.Drawing.Point(564, 96);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(843, 612);
            this.panel1.TabIndex = 10;
            // 
            // film_picture_box
            // 
            this.film_picture_box.Dock = System.Windows.Forms.DockStyle.Fill;
            this.film_picture_box.Image = global::Al_Shaheen_System.Properties.Resources.download;
            this.film_picture_box.InitialImage = null;
            this.film_picture_box.Location = new System.Drawing.Point(0, 0);
            this.film_picture_box.Name = "film_picture_box";
            this.film_picture_box.Size = new System.Drawing.Size(843, 612);
            this.film_picture_box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.film_picture_box.TabIndex = 6;
            this.film_picture_box.TabStop = false;
            // 
            // addnewclientproductfilm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1412, 774);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cancelbtn);
            this.Controls.Add(this.newbtn);
            this.Controls.Add(this.savebtn);
            this.Controls.Add(this.browse_btn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.film_code_text_box);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "addnewclientproductfilm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إضافة أفلام منتجات العملاء";
            this.Load += new System.EventHandler(this.addnewclientproductfilm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.film_picture_box)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox film_code_text_box;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox film_length_text_box;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox client_combo_box;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button addnewclientproductbtn;
        private System.Windows.Forms.Button removefromlistbtn;
        private System.Windows.Forms.ComboBox client_product_combo_box;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button browse_btn;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Button newbtn;
        private System.Windows.Forms.Button cancelbtn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox film_width_text_box;
        private System.Windows.Forms.TextBox no_of_products_per_sheet_text_box;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox film_picture_box;
    }
}