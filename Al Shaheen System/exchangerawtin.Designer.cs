namespace Al_Shaheen_System
{
    partial class exchangerawtin
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.production_radio_btn = new System.Windows.Forms.RadioButton();
            this.muraning_radio_btn = new System.Windows.Forms.RadioButton();
            this.printering_radio_btn = new System.Windows.Forms.RadioButton();
            this.p_label = new System.Windows.Forms.Label();
            this.stock_combo_box = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.receival_man_text_box = new System.Windows.Forms.TextBox();
            this.confidential_man_text_box = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.exchange_permission_number = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.work_number_text_box = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.add_new_parcel_btn = new System.Windows.Forms.Button();
            this.parcels_grid_view = new System.Windows.Forms.DataGridView();
            this.item_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.no_sheets = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplier_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.material_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.net_weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.temper = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Finish = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.save_and_print_ = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.item_id_text_box = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.remove_parcel_btn = new System.Windows.Forms.Button();
            this.stock_man_text_box = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.item_total_no_sheets_text_box = new System.Windows.Forms.TextBox();
            this.total_net_weight_text_box = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.p_text_box = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.parcels_grid_view)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(368, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 39);
            this.label1.TabIndex = 11;
            this.label1.Text = "صرف الصفيح الخام ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.p_text_box);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.p_label);
            this.groupBox1.Controls.Add(this.stock_combo_box);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.receival_man_text_box);
            this.groupBox1.Controls.Add(this.stock_man_text_box);
            this.groupBox1.Controls.Add(this.confidential_man_text_box);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.exchange_permission_number);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.work_number_text_box);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(21, 159);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(839, 202);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "طلب الصرف";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.production_radio_btn);
            this.groupBox3.Controls.Add(this.muraning_radio_btn);
            this.groupBox3.Controls.Add(this.printering_radio_btn);
            this.groupBox3.Location = new System.Drawing.Point(381, 135);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(436, 50);
            this.groupBox3.TabIndex = 42;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "سبب الصرف";
            // 
            // production_radio_btn
            // 
            this.production_radio_btn.AutoSize = true;
            this.production_radio_btn.Location = new System.Drawing.Point(35, 18);
            this.production_radio_btn.Name = "production_radio_btn";
            this.production_radio_btn.Size = new System.Drawing.Size(60, 24);
            this.production_radio_btn.TabIndex = 43;
            this.production_radio_btn.TabStop = true;
            this.production_radio_btn.Text = "الانتاج";
            this.production_radio_btn.UseVisualStyleBackColor = true;
            this.production_radio_btn.CheckedChanged += new System.EventHandler(this.production_radio_btn_CheckedChanged);
            // 
            // muraning_radio_btn
            // 
            this.muraning_radio_btn.AutoSize = true;
            this.muraning_radio_btn.Location = new System.Drawing.Point(169, 19);
            this.muraning_radio_btn.Name = "muraning_radio_btn";
            this.muraning_radio_btn.Size = new System.Drawing.Size(69, 24);
            this.muraning_radio_btn.TabIndex = 1;
            this.muraning_radio_btn.TabStop = true;
            this.muraning_radio_btn.Text = "الورنشة";
            this.muraning_radio_btn.UseVisualStyleBackColor = true;
            this.muraning_radio_btn.CheckedChanged += new System.EventHandler(this.muraning_radio_btn_CheckedChanged);
            // 
            // printering_radio_btn
            // 
            this.printering_radio_btn.AutoSize = true;
            this.printering_radio_btn.Location = new System.Drawing.Point(289, 18);
            this.printering_radio_btn.Name = "printering_radio_btn";
            this.printering_radio_btn.Size = new System.Drawing.Size(70, 24);
            this.printering_radio_btn.TabIndex = 0;
            this.printering_radio_btn.TabStop = true;
            this.printering_radio_btn.Text = "الطباعة ";
            this.printering_radio_btn.UseVisualStyleBackColor = true;
            this.printering_radio_btn.CheckedChanged += new System.EventHandler(this.printering_radio_btn_CheckedChanged);
            // 
            // p_label
            // 
            this.p_label.AutoSize = true;
            this.p_label.Location = new System.Drawing.Point(248, 155);
            this.p_label.Name = "p_label";
            this.p_label.Size = new System.Drawing.Size(67, 20);
            this.p_label.TabIndex = 39;
            this.p_label.Text = "p_name";
            // 
            // stock_combo_box
            // 
            this.stock_combo_box.FormattingEnabled = true;
            this.stock_combo_box.Items.AddRange(new object[] {
            "المخزن الرئيسي ( مصنع العاشر من  رمضان)"});
            this.stock_combo_box.Location = new System.Drawing.Point(45, 33);
            this.stock_combo_box.Name = "stock_combo_box";
            this.stock_combo_box.Size = new System.Drawing.Size(180, 28);
            this.stock_combo_box.TabIndex = 38;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(266, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 37;
            this.label2.Text = "المخزن ";
            // 
            // receival_man_text_box
            // 
            this.receival_man_text_box.Location = new System.Drawing.Point(442, 109);
            this.receival_man_text_box.Name = "receival_man_text_box";
            this.receival_man_text_box.Size = new System.Drawing.Size(177, 26);
            this.receival_man_text_box.TabIndex = 36;
            this.receival_man_text_box.TextChanged += new System.EventHandler(this.receival_man_text_box_TextChanged);
            // 
            // confidential_man_text_box
            // 
            this.confidential_man_text_box.Location = new System.Drawing.Point(45, 111);
            this.confidential_man_text_box.Name = "confidential_man_text_box";
            this.confidential_man_text_box.Size = new System.Drawing.Size(180, 26);
            this.confidential_man_text_box.TabIndex = 34;
            this.confidential_man_text_box.TextChanged += new System.EventHandler(this.confidential_man_text_box_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(274, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 20);
            this.label6.TabIndex = 30;
            this.label6.Text = "المعتمد";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(641, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 20);
            this.label5.TabIndex = 28;
            this.label5.Text = "المستلم";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(241, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 20);
            this.label8.TabIndex = 21;
            this.label8.Text = "امين المخزن ";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // exchange_permission_number
            // 
            this.exchange_permission_number.Location = new System.Drawing.Point(442, 75);
            this.exchange_permission_number.Name = "exchange_permission_number";
            this.exchange_permission_number.Size = new System.Drawing.Size(177, 26);
            this.exchange_permission_number.TabIndex = 20;
            this.exchange_permission_number.TextChanged += new System.EventHandler(this.exchange_permission_number_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(641, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "رقم إذن الصرف";
            // 
            // work_number_text_box
            // 
            this.work_number_text_box.Location = new System.Drawing.Point(442, 38);
            this.work_number_text_box.Name = "work_number_text_box";
            this.work_number_text_box.Size = new System.Drawing.Size(177, 26);
            this.work_number_text_box.TabIndex = 18;
            this.work_number_text_box.TextChanged += new System.EventHandler(this.work_number_text_box_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(641, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 17;
            this.label4.Text = "رقم أمر التشغيل";
            // 
            // add_new_parcel_btn
            // 
            this.add_new_parcel_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add_new_parcel_btn.Location = new System.Drawing.Point(21, 428);
            this.add_new_parcel_btn.Name = "add_new_parcel_btn";
            this.add_new_parcel_btn.Size = new System.Drawing.Size(184, 36);
            this.add_new_parcel_btn.TabIndex = 13;
            this.add_new_parcel_btn.Text = "إضافة رقم الطرد";
            this.add_new_parcel_btn.UseVisualStyleBackColor = true;
            this.add_new_parcel_btn.Click += new System.EventHandler(this.add_new_parcel_btn_Click);
            // 
            // parcels_grid_view
            // 
            this.parcels_grid_view.AllowUserToAddRows = false;
            this.parcels_grid_view.AllowUserToDeleteRows = false;
            this.parcels_grid_view.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.parcels_grid_view.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.parcels_grid_view.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.parcels_grid_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.parcels_grid_view.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.item_id,
            this.itemcode,
            this.no_sheets,
            this.supplier_name,
            this.material_type,
            this.net_weight,
            this.temper,
            this.Finish});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.parcels_grid_view.DefaultCellStyle = dataGridViewCellStyle2;
            this.parcels_grid_view.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.parcels_grid_view.Location = new System.Drawing.Point(21, 470);
            this.parcels_grid_view.MultiSelect = false;
            this.parcels_grid_view.Name = "parcels_grid_view";
            this.parcels_grid_view.ReadOnly = true;
            this.parcels_grid_view.Size = new System.Drawing.Size(839, 195);
            this.parcels_grid_view.TabIndex = 14;
            // 
            // item_id
            // 
            this.item_id.HeaderText = "رقم الطرد";
            this.item_id.Name = "item_id";
            this.item_id.ReadOnly = true;
            // 
            // itemcode
            // 
            this.itemcode.HeaderText = "كود الصنف";
            this.itemcode.Name = "itemcode";
            this.itemcode.ReadOnly = true;
            // 
            // no_sheets
            // 
            this.no_sheets.HeaderText = "عدد الشيتات ";
            this.no_sheets.Name = "no_sheets";
            this.no_sheets.ReadOnly = true;
            // 
            // supplier_name
            // 
            this.supplier_name.HeaderText = "إسم المورد ";
            this.supplier_name.Name = "supplier_name";
            this.supplier_name.ReadOnly = true;
            // 
            // material_type
            // 
            this.material_type.HeaderText = "نوع الخام";
            this.material_type.Name = "material_type";
            this.material_type.ReadOnly = true;
            // 
            // net_weight
            // 
            this.net_weight.HeaderText = "الوزن الصافى ";
            this.net_weight.Name = "net_weight";
            this.net_weight.ReadOnly = true;
            // 
            // temper
            // 
            this.temper.HeaderText = "Temper";
            this.temper.Name = "temper";
            this.temper.ReadOnly = true;
            // 
            // Finish
            // 
            this.Finish.HeaderText = "Finish";
            this.Finish.Name = "Finish";
            this.Finish.ReadOnly = true;
            // 
            // save_and_print_
            // 
            this.save_and_print_.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save_and_print_.Location = new System.Drawing.Point(21, 682);
            this.save_and_print_.Name = "save_and_print_";
            this.save_and_print_.Size = new System.Drawing.Size(160, 38);
            this.save_and_print_.TabIndex = 15;
            this.save_and_print_.Text = "حفظ وطباعة";
            this.save_and_print_.UseVisualStyleBackColor = true;
            this.save_and_print_.Click += new System.EventHandler(this.save_and_print__Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(375, 682);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(150, 38);
            this.button3.TabIndex = 16;
            this.button3.Text = "طلب صرف جديد";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(738, 682);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(122, 38);
            this.button4.TabIndex = 17;
            this.button4.Text = "إلغاء";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.item_id_text_box);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(21, 367);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(839, 55);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "الكمية ";
            // 
            // item_id_text_box
            // 
            this.item_id_text_box.Location = new System.Drawing.Point(323, 19);
            this.item_id_text_box.Name = "item_id_text_box";
            this.item_id_text_box.Size = new System.Drawing.Size(180, 26);
            this.item_id_text_box.TabIndex = 35;
            this.item_id_text_box.TextChanged += new System.EventHandler(this.item_id_text_box_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(537, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 20);
            this.label9.TabIndex = 34;
            this.label9.Text = "رقم الطرد ";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.RightToLeft = true;
            // 
            // remove_parcel_btn
            // 
            this.remove_parcel_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remove_parcel_btn.Location = new System.Drawing.Point(664, 428);
            this.remove_parcel_btn.Name = "remove_parcel_btn";
            this.remove_parcel_btn.Size = new System.Drawing.Size(196, 36);
            this.remove_parcel_btn.TabIndex = 19;
            this.remove_parcel_btn.Text = "مسح طرد ";
            this.remove_parcel_btn.UseVisualStyleBackColor = true;
            this.remove_parcel_btn.Click += new System.EventHandler(this.remove_parcel_btn_Click);
            // 
            // stock_man_text_box
            // 
            this.stock_man_text_box.Location = new System.Drawing.Point(45, 73);
            this.stock_man_text_box.Name = "stock_man_text_box";
            this.stock_man_text_box.Size = new System.Drawing.Size(180, 26);
            this.stock_man_text_box.TabIndex = 35;
            this.stock_man_text_box.TextChanged += new System.EventHandler(this.stock_man_text_box_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(93, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 20);
            this.label7.TabIndex = 20;
            this.label7.Text = "عدد الشيتات المصروفه";
            // 
            // item_total_no_sheets_text_box
            // 
            this.item_total_no_sheets_text_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item_total_no_sheets_text_box.Location = new System.Drawing.Point(241, 107);
            this.item_total_no_sheets_text_box.Name = "item_total_no_sheets_text_box";
            this.item_total_no_sheets_text_box.Size = new System.Drawing.Size(177, 26);
            this.item_total_no_sheets_text_box.TabIndex = 21;
            // 
            // total_net_weight_text_box
            // 
            this.total_net_weight_text_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total_net_weight_text_box.Location = new System.Drawing.Point(635, 107);
            this.total_net_weight_text_box.Name = "total_net_weight_text_box";
            this.total_net_weight_text_box.Size = new System.Drawing.Size(177, 26);
            this.total_net_weight_text_box.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(487, 113);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(118, 20);
            this.label10.TabIndex = 22;
            this.label10.Text = "إجمالى الوزن الصافى";
            // 
            // p_text_box
            // 
            this.p_text_box.FormattingEnabled = true;
            this.p_text_box.Location = new System.Drawing.Point(45, 149);
            this.p_text_box.Name = "p_text_box";
            this.p_text_box.Size = new System.Drawing.Size(180, 28);
            this.p_text_box.TabIndex = 43;
            // 
            // exchangerawtin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 738);
            this.Controls.Add(this.total_net_weight_text_box);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.item_total_no_sheets_text_box);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.remove_parcel_btn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.save_and_print_);
            this.Controls.Add(this.parcels_grid_view);
            this.Controls.Add(this.add_new_parcel_btn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "exchangerawtin";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "صرف الصفيح الخام ";
            this.Load += new System.EventHandler(this.exchangerawtin_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.parcels_grid_view)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox exchange_permission_number;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox work_number_text_box;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button add_new_parcel_btn;
        private System.Windows.Forms.DataGridView parcels_grid_view;
        private System.Windows.Forms.Button save_and_print_;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox confidential_man_text_box;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox item_id_text_box;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn no_sheets;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplier_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn material_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn net_weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn temper;
        private System.Windows.Forms.DataGridViewTextBoxColumn Finish;
        private System.Windows.Forms.TextBox receival_man_text_box;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox stock_combo_box;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button remove_parcel_btn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton production_radio_btn;
        private System.Windows.Forms.RadioButton muraning_radio_btn;
        private System.Windows.Forms.RadioButton printering_radio_btn;
        private System.Windows.Forms.Label p_label;
        private System.Windows.Forms.TextBox stock_man_text_box;
        private System.Windows.Forms.TextBox total_net_weight_text_box;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox item_total_no_sheets_text_box;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox p_text_box;
    }
}