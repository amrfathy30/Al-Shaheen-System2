namespace Al_Shaheen_System
{
    partial class maintenanceworkorders
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.workshop_orders_grid_view = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_name_text_box = new System.Windows.Forms.TextBox();
            this.quantity_text_box = new System.Windows.Forms.TextBox();
            this.requested_man_name_text_box = new System.Windows.Forms.TextBox();
            this.notes_text_box = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.job_Completed_button = new System.Windows.Forms.Button();
            this.save_btn = new System.Windows.Forms.Button();
            this.new_btn = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.requesting_date_time_picker = new System.Windows.Forms.DateTimePicker();
            this.machinenametextbox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.print_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.workshop_orders_grid_view)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(534, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "أوامر شغل الورشة";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(69, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "إسم الصنف";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(69, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "الكمية";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(69, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "تاريخ الطلب";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(69, 307);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "إسم الطالب";
            // 
            // workshop_orders_grid_view
            // 
            this.workshop_orders_grid_view.AllowUserToAddRows = false;
            this.workshop_orders_grid_view.AllowUserToDeleteRows = false;
            this.workshop_orders_grid_view.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.workshop_orders_grid_view.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.workshop_orders_grid_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.workshop_orders_grid_view.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column5,
            this.Column3,
            this.Column4,
            this.Column7,
            this.Column6,
            this.Column8});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.workshop_orders_grid_view.DefaultCellStyle = dataGridViewCellStyle4;
            this.workshop_orders_grid_view.Location = new System.Drawing.Point(444, 80);
            this.workshop_orders_grid_view.Name = "workshop_orders_grid_view";
            this.workshop_orders_grid_view.ReadOnly = true;
            this.workshop_orders_grid_view.Size = new System.Drawing.Size(822, 598);
            this.workshop_orders_grid_view.TabIndex = 6;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "م";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "إسم الصنف";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "الكمية";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "تاريخ البدء";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "المكاينة المصنعة";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "عدد ساعات العمل";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "ملاحظات";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "الحالة";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // item_name_text_box
            // 
            this.item_name_text_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item_name_text_box.Location = new System.Drawing.Point(171, 129);
            this.item_name_text_box.Name = "item_name_text_box";
            this.item_name_text_box.Size = new System.Drawing.Size(213, 30);
            this.item_name_text_box.TabIndex = 7;
            // 
            // quantity_text_box
            // 
            this.quantity_text_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantity_text_box.Location = new System.Drawing.Point(171, 175);
            this.quantity_text_box.Name = "quantity_text_box";
            this.quantity_text_box.Size = new System.Drawing.Size(213, 30);
            this.quantity_text_box.TabIndex = 8;
            // 
            // requested_man_name_text_box
            // 
            this.requested_man_name_text_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.requested_man_name_text_box.Location = new System.Drawing.Point(171, 302);
            this.requested_man_name_text_box.Name = "requested_man_name_text_box";
            this.requested_man_name_text_box.Size = new System.Drawing.Size(213, 30);
            this.requested_man_name_text_box.TabIndex = 10;
            // 
            // notes_text_box
            // 
            this.notes_text_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notes_text_box.Location = new System.Drawing.Point(171, 361);
            this.notes_text_box.Multiline = true;
            this.notes_text_box.Name = "notes_text_box";
            this.notes_text_box.Size = new System.Drawing.Size(213, 203);
            this.notes_text_box.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(69, 368);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 25);
            this.label7.TabIndex = 12;
            this.label7.Text = "ملاحظات";
            // 
            // job_Completed_button
            // 
            this.job_Completed_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.job_Completed_button.Location = new System.Drawing.Point(1123, 34);
            this.job_Completed_button.Name = "job_Completed_button";
            this.job_Completed_button.Size = new System.Drawing.Size(143, 40);
            this.job_Completed_button.TabIndex = 15;
            this.job_Completed_button.Text = "تم العمل";
            this.job_Completed_button.UseVisualStyleBackColor = true;
            this.job_Completed_button.Click += new System.EventHandler(this.job_Completed_button_Click);
            // 
            // save_btn
            // 
            this.save_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save_btn.Location = new System.Drawing.Point(13, 638);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(116, 40);
            this.save_btn.TabIndex = 16;
            this.save_btn.Text = "حفظ";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // new_btn
            // 
            this.new_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.new_btn.Location = new System.Drawing.Point(172, 638);
            this.new_btn.Name = "new_btn";
            this.new_btn.Size = new System.Drawing.Size(99, 40);
            this.new_btn.TabIndex = 17;
            this.new_btn.Text = "جديد";
            this.new_btn.UseVisualStyleBackColor = true;
            // 
            // cancel
            // 
            this.cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel.Location = new System.Drawing.Point(309, 638);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(97, 40);
            this.cancel.TabIndex = 18;
            this.cancel.Text = "إلغاء";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // requesting_date_time_picker
            // 
            this.requesting_date_time_picker.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.requesting_date_time_picker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.requesting_date_time_picker.Location = new System.Drawing.Point(172, 232);
            this.requesting_date_time_picker.Name = "requesting_date_time_picker";
            this.requesting_date_time_picker.Size = new System.Drawing.Size(212, 34);
            this.requesting_date_time_picker.TabIndex = 19;
            // 
            // machinenametextbox
            // 
            this.machinenametextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.machinenametextbox.Location = new System.Drawing.Point(172, 80);
            this.machinenametextbox.Name = "machinenametextbox";
            this.machinenametextbox.Size = new System.Drawing.Size(213, 30);
            this.machinenametextbox.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(70, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 25);
            this.label6.TabIndex = 20;
            this.label6.Text = "إسم الماكينة";
            // 
            // print_btn
            // 
            this.print_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.print_btn.Location = new System.Drawing.Point(1123, 700);
            this.print_btn.Name = "print_btn";
            this.print_btn.Size = new System.Drawing.Size(143, 38);
            this.print_btn.TabIndex = 22;
            this.print_btn.Text = "طباعة";
            this.print_btn.UseVisualStyleBackColor = true;
            this.print_btn.Click += new System.EventHandler(this.print_btn_Click);
            // 
            // maintenanceworkorders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1297, 763);
            this.Controls.Add(this.print_btn);
            this.Controls.Add(this.machinenametextbox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.requesting_date_time_picker);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.new_btn);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.job_Completed_button);
            this.Controls.Add(this.notes_text_box);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.requested_man_name_text_box);
            this.Controls.Add(this.quantity_text_box);
            this.Controls.Add(this.item_name_text_box);
            this.Controls.Add(this.workshop_orders_grid_view);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "maintenanceworkorders";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "أوامر شغل الورشة";
            this.Load += new System.EventHandler(this.maintenanceworkorders_Load);
            ((System.ComponentModel.ISupportInitialize)(this.workshop_orders_grid_view)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView workshop_orders_grid_view;
        private System.Windows.Forms.TextBox item_name_text_box;
        private System.Windows.Forms.TextBox quantity_text_box;
        private System.Windows.Forms.TextBox requested_man_name_text_box;
        private System.Windows.Forms.TextBox notes_text_box;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.Button job_Completed_button;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.Button new_btn;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.DateTimePicker requesting_date_time_picker;
        private System.Windows.Forms.TextBox machinenametextbox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button print_btn;
    }
}