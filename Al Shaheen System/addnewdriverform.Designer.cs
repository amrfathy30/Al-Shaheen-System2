namespace Al_Shaheen_System
{
    partial class addnewdriverform
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.driver_name_text_box = new System.Windows.Forms.TextBox();
            this.driver_car_number_text_box = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.driving_lisence_number_text_box = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.driver_telephone_number_text_box = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.save_btn = new System.Windows.Forms.Button();
            this.new_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.drivers_data_grid_view = new System.Windows.Forms.DataGridView();
            this.search_driver_name_text_box = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.search_btn = new System.Windows.Forms.Button();
            this.cancel_search_btn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drivers_data_grid_view)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.cancel_search_btn);
            this.panel1.Controls.Add(this.search_btn);
            this.panel1.Controls.Add(this.search_driver_name_text_box);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.drivers_data_grid_view);
            this.panel1.Controls.Add(this.cancel_btn);
            this.panel1.Controls.Add(this.new_btn);
            this.panel1.Controls.Add(this.save_btn);
            this.panel1.Controls.Add(this.driver_telephone_number_text_box);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.driving_lisence_number_text_box);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.driver_car_number_text_box);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.driver_name_text_box);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(932, 511);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(589, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "إضافة سائق جديد";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(812, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "إسم السائق";
            // 
            // driver_name_text_box
            // 
            this.driver_name_text_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.driver_name_text_box.Location = new System.Drawing.Point(581, 172);
            this.driver_name_text_box.Name = "driver_name_text_box";
            this.driver_name_text_box.Size = new System.Drawing.Size(175, 30);
            this.driver_name_text_box.TabIndex = 2;
            // 
            // driver_car_number_text_box
            // 
            this.driver_car_number_text_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.driver_car_number_text_box.Location = new System.Drawing.Point(581, 208);
            this.driver_car_number_text_box.Name = "driver_car_number_text_box";
            this.driver_car_number_text_box.Size = new System.Drawing.Size(175, 30);
            this.driver_car_number_text_box.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(808, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "رقم السيارة";
            // 
            // driving_lisence_number_text_box
            // 
            this.driving_lisence_number_text_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.driving_lisence_number_text_box.Location = new System.Drawing.Point(581, 244);
            this.driving_lisence_number_text_box.Name = "driving_lisence_number_text_box";
            this.driving_lisence_number_text_box.Size = new System.Drawing.Size(175, 30);
            this.driving_lisence_number_text_box.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(766, 249);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "رقم رخصة القيادة";
            // 
            // driver_telephone_number_text_box
            // 
            this.driver_telephone_number_text_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.driver_telephone_number_text_box.Location = new System.Drawing.Point(581, 280);
            this.driver_telephone_number_text_box.Name = "driver_telephone_number_text_box";
            this.driver_telephone_number_text_box.Size = new System.Drawing.Size(175, 30);
            this.driver_telephone_number_text_box.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(807, 285);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 25);
            this.label5.TabIndex = 7;
            this.label5.Text = "رقم التليفون";
            // 
            // save_btn
            // 
            this.save_btn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.save_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save_btn.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save_btn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.save_btn.Location = new System.Drawing.Point(798, 426);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(98, 40);
            this.save_btn.TabIndex = 9;
            this.save_btn.Text = "حفظ";
            this.save_btn.UseVisualStyleBackColor = false;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // new_btn
            // 
            this.new_btn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.new_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.new_btn.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.new_btn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.new_btn.Location = new System.Drawing.Point(662, 426);
            this.new_btn.Name = "new_btn";
            this.new_btn.Size = new System.Drawing.Size(118, 40);
            this.new_btn.TabIndex = 10;
            this.new_btn.Text = "جديد";
            this.new_btn.UseVisualStyleBackColor = false;
            // 
            // cancel_btn
            // 
            this.cancel_btn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.cancel_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel_btn.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel_btn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cancel_btn.Location = new System.Drawing.Point(542, 426);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(114, 40);
            this.cancel_btn.TabIndex = 11;
            this.cancel_btn.Text = "إلغاء";
            this.cancel_btn.UseVisualStyleBackColor = false;
            // 
            // drivers_data_grid_view
            // 
            this.drivers_data_grid_view.AllowUserToAddRows = false;
            this.drivers_data_grid_view.AllowUserToDeleteRows = false;
            this.drivers_data_grid_view.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.drivers_data_grid_view.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.drivers_data_grid_view.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.drivers_data_grid_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.drivers_data_grid_view.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.drivers_data_grid_view.DefaultCellStyle = dataGridViewCellStyle6;
            this.drivers_data_grid_view.Location = new System.Drawing.Point(12, 142);
            this.drivers_data_grid_view.Name = "drivers_data_grid_view";
            this.drivers_data_grid_view.ReadOnly = true;
            this.drivers_data_grid_view.Size = new System.Drawing.Size(524, 324);
            this.drivers_data_grid_view.TabIndex = 12;
            // 
            // search_driver_name_text_box
            // 
            this.search_driver_name_text_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_driver_name_text_box.Location = new System.Drawing.Point(127, 44);
            this.search_driver_name_text_box.Name = "search_driver_name_text_box";
            this.search_driver_name_text_box.Size = new System.Drawing.Size(216, 30);
            this.search_driver_name_text_box.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(365, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 25);
            this.label6.TabIndex = 13;
            this.label6.Text = "إسم السائق";
            // 
            // Column1
            // 
            this.Column1.FillWeight = 50.76142F;
            this.Column1.HeaderText = "م";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 112.3096F;
            this.Column2.HeaderText = "إسم السائق";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.FillWeight = 112.3096F;
            this.Column3.HeaderText = "رقم السيارة";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.FillWeight = 112.3096F;
            this.Column4.HeaderText = "رقم الرخصة";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.FillWeight = 112.3096F;
            this.Column5.HeaderText = "رقم التليفون";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // search_btn
            // 
            this.search_btn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.search_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.search_btn.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_btn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.search_btn.Location = new System.Drawing.Point(12, 40);
            this.search_btn.Name = "search_btn";
            this.search_btn.Size = new System.Drawing.Size(87, 40);
            this.search_btn.TabIndex = 15;
            this.search_btn.Text = "بحث";
            this.search_btn.UseVisualStyleBackColor = false;
            this.search_btn.Click += new System.EventHandler(this.search_btn_Click);
            // 
            // cancel_search_btn
            // 
            this.cancel_search_btn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.cancel_search_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel_search_btn.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel_search_btn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cancel_search_btn.Location = new System.Drawing.Point(320, 80);
            this.cancel_search_btn.Name = "cancel_search_btn";
            this.cancel_search_btn.Size = new System.Drawing.Size(120, 40);
            this.cancel_search_btn.TabIndex = 16;
            this.cancel_search_btn.Text = "إلغاء البحث";
            this.cancel_search_btn.UseVisualStyleBackColor = false;
            this.cancel_search_btn.Click += new System.EventHandler(this.cancel_search_btn_Click);
            // 
            // addnewdriverform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 511);
            this.Controls.Add(this.panel1);
            this.Name = "addnewdriverform";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "إضافة سائق جديد";
            this.Load += new System.EventHandler(this.addnewdriverform_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drivers_data_grid_view)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox driver_telephone_number_text_box;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox driving_lisence_number_text_box;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox driver_car_number_text_box;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox driver_name_text_box;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button search_btn;
        private System.Windows.Forms.TextBox search_driver_name_text_box;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView drivers_data_grid_view;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.Button new_btn;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.Button cancel_search_btn;
    }
}