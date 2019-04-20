namespace Al_Shaheen_System
{
    partial class addnewcutterform
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
            this.cutters_grid_view = new System.Windows.Forms.DataGridView();
            this.no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cutter_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cutter_location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cutter_name_text_box = new System.Windows.Forms.TextBox();
            this.cutter_location_text_box = new System.Windows.Forms.TextBox();
            this.save_cutter_btn = new System.Windows.Forms.Button();
            this.new_cutter_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cutters_grid_view)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(359, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "المقصات";
            // 
            // cutters_grid_view
            // 
            this.cutters_grid_view.AllowUserToAddRows = false;
            this.cutters_grid_view.AllowUserToDeleteRows = false;
            this.cutters_grid_view.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.cutters_grid_view.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cutters_grid_view.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.cutters_grid_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cutters_grid_view.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.no,
            this.cutter_name,
            this.cutter_location});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.cutters_grid_view.DefaultCellStyle = dataGridViewCellStyle2;
            this.cutters_grid_view.Location = new System.Drawing.Point(485, 86);
            this.cutters_grid_view.Name = "cutters_grid_view";
            this.cutters_grid_view.ReadOnly = true;
            this.cutters_grid_view.Size = new System.Drawing.Size(514, 399);
            this.cutters_grid_view.TabIndex = 1;
            // 
            // no
            // 
            this.no.FillWeight = 20F;
            this.no.HeaderText = "م";
            this.no.Name = "no";
            this.no.ReadOnly = true;
            // 
            // cutter_name
            // 
            this.cutter_name.HeaderText = "إسم المقص";
            this.cutter_name.Name = "cutter_name";
            this.cutter_name.ReadOnly = true;
            // 
            // cutter_location
            // 
            this.cutter_location.HeaderText = "مكان المقص";
            this.cutter_location.Name = "cutter_location";
            this.cutter_location.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "إسم المقص";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "مكان المقص";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cutter_name_text_box
            // 
            this.cutter_name_text_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cutter_name_text_box.Location = new System.Drawing.Point(146, 148);
            this.cutter_name_text_box.Name = "cutter_name_text_box";
            this.cutter_name_text_box.Size = new System.Drawing.Size(239, 30);
            this.cutter_name_text_box.TabIndex = 4;
            // 
            // cutter_location_text_box
            // 
            this.cutter_location_text_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cutter_location_text_box.Location = new System.Drawing.Point(146, 203);
            this.cutter_location_text_box.Name = "cutter_location_text_box";
            this.cutter_location_text_box.Size = new System.Drawing.Size(239, 30);
            this.cutter_location_text_box.TabIndex = 5;
            // 
            // save_cutter_btn
            // 
            this.save_cutter_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save_cutter_btn.Location = new System.Drawing.Point(16, 441);
            this.save_cutter_btn.Name = "save_cutter_btn";
            this.save_cutter_btn.Size = new System.Drawing.Size(108, 44);
            this.save_cutter_btn.TabIndex = 6;
            this.save_cutter_btn.Text = "حفظ";
            this.save_cutter_btn.UseVisualStyleBackColor = true;
            this.save_cutter_btn.Click += new System.EventHandler(this.save_cutter_btn_Click);
            // 
            // new_cutter_btn
            // 
            this.new_cutter_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.new_cutter_btn.Location = new System.Drawing.Point(180, 441);
            this.new_cutter_btn.Name = "new_cutter_btn";
            this.new_cutter_btn.Size = new System.Drawing.Size(95, 44);
            this.new_cutter_btn.TabIndex = 7;
            this.new_cutter_btn.Text = "جديد";
            this.new_cutter_btn.UseVisualStyleBackColor = true;
            this.new_cutter_btn.Click += new System.EventHandler(this.new_cutter_btn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel_btn.Location = new System.Drawing.Point(332, 441);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(110, 44);
            this.cancel_btn.TabIndex = 8;
            this.cancel_btn.Text = "إلغاء";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // addnewcutterform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 523);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.new_cutter_btn);
            this.Controls.Add(this.save_cutter_btn);
            this.Controls.Add(this.cutter_location_text_box);
            this.Controls.Add(this.cutter_name_text_box);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cutters_grid_view);
            this.Controls.Add(this.label1);
            this.Name = "addnewcutterform";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إضافة مقص جديد";
            this.Load += new System.EventHandler(this.addnewcutterform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cutters_grid_view)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView cutters_grid_view;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox cutter_name_text_box;
        private System.Windows.Forms.TextBox cutter_location_text_box;
        private System.Windows.Forms.Button save_cutter_btn;
        private System.Windows.Forms.Button new_cutter_btn;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn no;
        private System.Windows.Forms.DataGridViewTextBoxColumn cutter_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn cutter_location;
    }
}