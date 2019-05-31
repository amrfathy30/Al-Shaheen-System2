namespace Al_Shaheen_System
{
    partial class getallclientproductfilms
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(getallclientproductfilms));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("محمد", 0);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("اى منتج", 1);
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.clients_combo_box = new System.Windows.Forms.ComboBox();
            this.client_products_combo_box = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.code_text_box = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.film_code_label = new System.Windows.Forms.Label();
            this.film_length_label = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.film_width_label = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.film_image_picture_box = new System.Windows.Forms.PictureBox();
            this.result_count_label = new System.Windows.Forms.Label();
            this.current_counter_label = new System.Windows.Forms.Label();
            this.search_btn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.film_image_picture_box)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(435, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "أفلام منتجات العملاء";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.search_btn);
            this.panel1.Controls.Add(this.result_count_label);
            this.panel1.Controls.Add(this.listView1);
            this.panel1.Controls.Add(this.film_width_label);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.film_length_label);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.film_code_label);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.film_image_picture_box);
            this.panel1.Controls.Add(this.code_text_box);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.client_products_combo_box);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.clients_combo_box);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 82);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1400, 727);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1322, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "إسم العميل";
            // 
            // clients_combo_box
            // 
            this.clients_combo_box.FormattingEnabled = true;
            this.clients_combo_box.Location = new System.Drawing.Point(1079, 36);
            this.clients_combo_box.Name = "clients_combo_box";
            this.clients_combo_box.Size = new System.Drawing.Size(237, 29);
            this.clients_combo_box.TabIndex = 1;
            this.clients_combo_box.SelectedIndexChanged += new System.EventHandler(this.clients_combo_box_SelectedIndexChanged);
            // 
            // client_products_combo_box
            // 
            this.client_products_combo_box.FormattingEnabled = true;
            this.client_products_combo_box.Location = new System.Drawing.Point(767, 36);
            this.client_products_combo_box.Name = "client_products_combo_box";
            this.client_products_combo_box.Size = new System.Drawing.Size(203, 29);
            this.client_products_combo_box.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(988, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "إسم الصنف";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(681, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 21);
            this.label4.TabIndex = 4;
            this.label4.Text = "كود الفيلم";
            // 
            // code_text_box
            // 
            this.code_text_box.Location = new System.Drawing.Point(419, 36);
            this.code_text_box.Name = "code_text_box";
            this.code_text_box.Size = new System.Drawing.Size(234, 28);
            this.code_text_box.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1322, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 21);
            this.label5.TabIndex = 7;
            this.label5.Text = "كود الفيلم ";
            // 
            // film_code_label
            // 
            this.film_code_label.AutoSize = true;
            this.film_code_label.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.film_code_label.ForeColor = System.Drawing.Color.Maroon;
            this.film_code_label.Location = new System.Drawing.Point(942, 90);
            this.film_code_label.Name = "film_code_label";
            this.film_code_label.Size = new System.Drawing.Size(57, 21);
            this.film_code_label.TabIndex = 8;
            this.film_code_label.Text = "label6";
            // 
            // film_length_label
            // 
            this.film_length_label.AutoSize = true;
            this.film_length_label.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.film_length_label.ForeColor = System.Drawing.Color.Maroon;
            this.film_length_label.Location = new System.Drawing.Point(942, 120);
            this.film_length_label.Name = "film_length_label";
            this.film_length_label.Size = new System.Drawing.Size(57, 21);
            this.film_length_label.TabIndex = 10;
            this.film_length_label.Text = "label6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1320, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 21);
            this.label7.TabIndex = 9;
            this.label7.Text = "طول الفيلم";
            // 
            // film_width_label
            // 
            this.film_width_label.AutoSize = true;
            this.film_width_label.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.film_width_label.ForeColor = System.Drawing.Color.Maroon;
            this.film_width_label.Location = new System.Drawing.Point(942, 150);
            this.film_width_label.Name = "film_width_label";
            this.film_width_label.Size = new System.Drawing.Size(57, 21);
            this.film_width_label.TabIndex = 12;
            this.film_width_label.Text = "label8";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1311, 150);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 21);
            this.label9.TabIndex = 11;
            this.label9.Text = "عرض الفيلم";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "user (1).png");
            this.imageList1.Images.SetKeyName(1, "production.png");
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView1.GridLines = true;
            listViewItem2.IndentCount = 1;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.listView1.Location = new System.Drawing.Point(942, 183);
            this.listView1.Name = "listView1";
            this.listView1.RightToLeftLayout = true;
            this.listView1.Size = new System.Drawing.Size(439, 255);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.TabIndex = 13;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "العميل";
            this.columnHeader1.Width = 366;
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Image = global::Al_Shaheen_System.Properties.Resources.back;
            this.button4.Location = new System.Drawing.Point(1162, 825);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(62, 41);
            this.button4.TabIndex = 5;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Image = global::Al_Shaheen_System.Properties.Resources.backward_arrows_couple_pointing_to_left;
            this.button3.Location = new System.Drawing.Point(955, 825);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(92, 40);
            this.button3.TabIndex = 4;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = global::Al_Shaheen_System.Properties.Resources.forward_button;
            this.button2.Location = new System.Drawing.Point(543, 825);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(60, 40);
            this.button2.TabIndex = 3;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::Al_Shaheen_System.Properties.Resources.step_forward;
            this.button1.Location = new System.Drawing.Point(412, 825);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(47, 40);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // film_image_picture_box
            // 
            this.film_image_picture_box.Location = new System.Drawing.Point(56, 90);
            this.film_image_picture_box.Name = "film_image_picture_box";
            this.film_image_picture_box.Size = new System.Drawing.Size(843, 612);
            this.film_image_picture_box.TabIndex = 6;
            this.film_image_picture_box.TabStop = false;
            // 
            // result_count_label
            // 
            this.result_count_label.AutoSize = true;
            this.result_count_label.Location = new System.Drawing.Point(28, 15);
            this.result_count_label.Name = "result_count_label";
            this.result_count_label.Size = new System.Drawing.Size(52, 21);
            this.result_count_label.TabIndex = 14;
            this.result_count_label.Text = "label6";
            // 
            // current_counter_label
            // 
            this.current_counter_label.AutoSize = true;
            this.current_counter_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.current_counter_label.Location = new System.Drawing.Point(756, 835);
            this.current_counter_label.Name = "current_counter_label";
            this.current_counter_label.Size = new System.Drawing.Size(51, 20);
            this.current_counter_label.TabIndex = 6;
            this.current_counter_label.Text = "label6";
            // 
            // search_btn
            // 
            this.search_btn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.search_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.search_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.search_btn.Location = new System.Drawing.Point(269, 36);
            this.search_btn.Name = "search_btn";
            this.search_btn.Size = new System.Drawing.Size(109, 29);
            this.search_btn.TabIndex = 15;
            this.search_btn.Text = "بحث";
            this.search_btn.UseVisualStyleBackColor = false;
            this.search_btn.Click += new System.EventHandler(this.search_btn_Click);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(942, 444);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(439, 258);
            this.panel2.TabIndex = 16;
            // 
            // getallclientproductfilms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1412, 875);
            this.Controls.Add(this.current_counter_label);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "getallclientproductfilms";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "عرض جميع أفلام منتجات العملاء";
            this.Load += new System.EventHandler(this.getallclientproductfilms_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.film_image_picture_box)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox client_products_combo_box;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox clients_combo_box;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox code_text_box;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox film_image_picture_box;
        private System.Windows.Forms.Label film_code_label;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label film_width_label;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label film_length_label;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label result_count_label;
        private System.Windows.Forms.Label current_counter_label;
        private System.Windows.Forms.Button search_btn;
        private System.Windows.Forms.Panel panel2;
    }
}