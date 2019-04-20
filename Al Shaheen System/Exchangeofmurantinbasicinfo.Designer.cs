namespace Al_Shaheen_System
{
    partial class Exchangeofmurantinbasicinfo
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
            this.p_text_box = new System.Windows.Forms.TextBox();
            this.p_label = new System.Windows.Forms.Label();
            this.stock_combo_box = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.receival_man_text_box = new System.Windows.Forms.TextBox();
            this.stock_man_text_box = new System.Windows.Forms.TextBox();
            this.confidential_man_text_box = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.exchange_permission_number = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.work_number_text_box = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.muran_parcels_grid_view = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.save_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.muran_parcels_grid_view)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(333, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(336, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "صرف الصفيح المورنش";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.p_text_box);
            this.groupBox1.Controls.Add(this.p_label);
            this.groupBox1.Controls.Add(this.stock_combo_box);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.receival_man_text_box);
            this.groupBox1.Controls.Add(this.stock_man_text_box);
            this.groupBox1.Controls.Add(this.confidential_man_text_box);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.exchange_permission_number);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.work_number_text_box);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(31, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(959, 202);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "طلب الصرف";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.production_radio_btn);
            this.groupBox3.Controls.Add(this.muraning_radio_btn);
            this.groupBox3.Controls.Add(this.printering_radio_btn);
            this.groupBox3.Location = new System.Drawing.Point(483, 139);
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
            this.muraning_radio_btn.Location = new System.Drawing.Point(157, 19);
            this.muraning_radio_btn.Name = "muraning_radio_btn";
            this.muraning_radio_btn.Size = new System.Drawing.Size(69, 24);
            this.muraning_radio_btn.TabIndex = 1;
            this.muraning_radio_btn.TabStop = true;
            this.muraning_radio_btn.Text = "الورنشة";
            this.muraning_radio_btn.UseVisualStyleBackColor = true;
            // 
            // printering_radio_btn
            // 
            this.printering_radio_btn.AutoSize = true;
            this.printering_radio_btn.Location = new System.Drawing.Point(288, 18);
            this.printering_radio_btn.Name = "printering_radio_btn";
            this.printering_radio_btn.Size = new System.Drawing.Size(70, 24);
            this.printering_radio_btn.TabIndex = 0;
            this.printering_radio_btn.TabStop = true;
            this.printering_radio_btn.Text = "الطباعة ";
            this.printering_radio_btn.UseVisualStyleBackColor = true;
            this.printering_radio_btn.CheckedChanged += new System.EventHandler(this.printering_radio_btn_CheckedChanged);
            // 
            // p_text_box
            // 
            this.p_text_box.Location = new System.Drawing.Point(117, 155);
            this.p_text_box.Name = "p_text_box";
            this.p_text_box.Size = new System.Drawing.Size(237, 26);
            this.p_text_box.TabIndex = 40;
            // 
            // p_label
            // 
            this.p_label.AutoSize = true;
            this.p_label.Location = new System.Drawing.Point(377, 157);
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
            this.stock_combo_box.Location = new System.Drawing.Point(117, 36);
            this.stock_combo_box.Name = "stock_combo_box";
            this.stock_combo_box.Size = new System.Drawing.Size(237, 28);
            this.stock_combo_box.TabIndex = 38;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(395, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 20);
            this.label8.TabIndex = 37;
            this.label8.Text = "المخزن ";
            // 
            // receival_man_text_box
            // 
            this.receival_man_text_box.Location = new System.Drawing.Point(604, 109);
            this.receival_man_text_box.Name = "receival_man_text_box";
            this.receival_man_text_box.Size = new System.Drawing.Size(177, 26);
            this.receival_man_text_box.TabIndex = 36;
            // 
            // stock_man_text_box
            // 
            this.stock_man_text_box.Location = new System.Drawing.Point(117, 75);
            this.stock_man_text_box.Name = "stock_man_text_box";
            this.stock_man_text_box.Size = new System.Drawing.Size(237, 26);
            this.stock_man_text_box.TabIndex = 35;
            // 
            // confidential_man_text_box
            // 
            this.confidential_man_text_box.Location = new System.Drawing.Point(117, 116);
            this.confidential_man_text_box.Name = "confidential_man_text_box";
            this.confidential_man_text_box.Size = new System.Drawing.Size(237, 26);
            this.confidential_man_text_box.TabIndex = 34;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(403, 122);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 20);
            this.label11.TabIndex = 30;
            this.label11.Text = "المعتمد";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(841, 114);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 20);
            this.label12.TabIndex = 28;
            this.label12.Text = "المستلم";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(370, 81);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 20);
            this.label13.TabIndex = 21;
            this.label13.Text = "امين المخزن ";
            // 
            // exchange_permission_number
            // 
            this.exchange_permission_number.Location = new System.Drawing.Point(604, 75);
            this.exchange_permission_number.Name = "exchange_permission_number";
            this.exchange_permission_number.Size = new System.Drawing.Size(177, 26);
            this.exchange_permission_number.TabIndex = 20;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(790, 78);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(93, 20);
            this.label14.TabIndex = 19;
            this.label14.Text = "رقم إذن الصرف";
            // 
            // work_number_text_box
            // 
            this.work_number_text_box.Location = new System.Drawing.Point(604, 38);
            this.work_number_text_box.Name = "work_number_text_box";
            this.work_number_text_box.Size = new System.Drawing.Size(177, 26);
            this.work_number_text_box.TabIndex = 18;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(794, 39);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(89, 20);
            this.label15.TabIndex = 17;
            this.label15.Text = "رقم أمر التشغيل";
            // 
            // muran_parcels_grid_view
            // 
            this.muran_parcels_grid_view.AllowUserToAddRows = false;
            this.muran_parcels_grid_view.AllowUserToDeleteRows = false;
            this.muran_parcels_grid_view.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.muran_parcels_grid_view.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.muran_parcels_grid_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.muran_parcels_grid_view.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.muran_parcels_grid_view.DefaultCellStyle = dataGridViewCellStyle2;
            this.muran_parcels_grid_view.Location = new System.Drawing.Point(31, 296);
            this.muran_parcels_grid_view.Name = "muran_parcels_grid_view";
            this.muran_parcels_grid_view.ReadOnly = true;
            this.muran_parcels_grid_view.Size = new System.Drawing.Size(959, 445);
            this.muran_parcels_grid_view.TabIndex = 43;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "م";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "رقم الطرد ";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "كود الطرد";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "العميل";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "الوجة الأول";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "الوجة الثانى ";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "المقاس";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "نوع الورنشة";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "عدد الشيتات";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "الوزن القائم";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // save_btn
            // 
            this.save_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save_btn.Location = new System.Drawing.Point(31, 764);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(145, 40);
            this.save_btn.TabIndex = 44;
            this.save_btn.Text = "حفظ";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel_btn.Location = new System.Drawing.Point(829, 764);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(161, 40);
            this.cancel_btn.TabIndex = 46;
            this.cancel_btn.Text = "إلغاء";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Exchangeofmurantinbasicinfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 816);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.muran_parcels_grid_view);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "Exchangeofmurantinbasicinfo";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "صرف الصفيح الخام ";
            this.Load += new System.EventHandler(this.Exchangerawtinbasicinfo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.muran_parcels_grid_view)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton production_radio_btn;
        private System.Windows.Forms.RadioButton muraning_radio_btn;
        private System.Windows.Forms.RadioButton printering_radio_btn;
        private System.Windows.Forms.TextBox p_text_box;
        private System.Windows.Forms.Label p_label;
        private System.Windows.Forms.ComboBox stock_combo_box;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox receival_man_text_box;
        private System.Windows.Forms.TextBox stock_man_text_box;
        private System.Windows.Forms.TextBox confidential_man_text_box;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox exchange_permission_number;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox work_number_text_box;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridView muran_parcels_grid_view;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
    }
}