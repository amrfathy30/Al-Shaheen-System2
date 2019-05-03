namespace Al_Shaheen_System
{
    partial class addnewscrewusage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.usages_grid_view = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usage_text_box = new System.Windows.Forms.TextBox();
            this.saev_btn = new System.Windows.Forms.Button();
            this.new_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.usages_grid_view)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(157, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(341, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "إضافة إستخدام جديد للقلاووظ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "الإستخدام";
            // 
            // usages_grid_view
            // 
            this.usages_grid_view.AllowUserToAddRows = false;
            this.usages_grid_view.AllowUserToDeleteRows = false;
            this.usages_grid_view.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.usages_grid_view.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.usages_grid_view.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.usages_grid_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usages_grid_view.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.usages_grid_view.DefaultCellStyle = dataGridViewCellStyle12;
            this.usages_grid_view.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.usages_grid_view.Location = new System.Drawing.Point(314, 83);
            this.usages_grid_view.Name = "usages_grid_view";
            this.usages_grid_view.ReadOnly = true;
            this.usages_grid_view.Size = new System.Drawing.Size(388, 310);
            this.usages_grid_view.TabIndex = 2;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "م";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "الإستخدام";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // usage_text_box
            // 
            this.usage_text_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usage_text_box.Location = new System.Drawing.Point(34, 179);
            this.usage_text_box.Name = "usage_text_box";
            this.usage_text_box.Size = new System.Drawing.Size(218, 29);
            this.usage_text_box.TabIndex = 3;
            // 
            // saev_btn
            // 
            this.saev_btn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.saev_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saev_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saev_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.saev_btn.Location = new System.Drawing.Point(34, 412);
            this.saev_btn.Name = "saev_btn";
            this.saev_btn.Size = new System.Drawing.Size(125, 31);
            this.saev_btn.TabIndex = 4;
            this.saev_btn.Text = "حفظ";
            this.saev_btn.UseVisualStyleBackColor = false;
            this.saev_btn.Click += new System.EventHandler(this.saev_btn_Click);
            // 
            // new_btn
            // 
            this.new_btn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.new_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.new_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.new_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.new_btn.Location = new System.Drawing.Point(314, 412);
            this.new_btn.Name = "new_btn";
            this.new_btn.Size = new System.Drawing.Size(120, 31);
            this.new_btn.TabIndex = 5;
            this.new_btn.Text = "جديد";
            this.new_btn.UseVisualStyleBackColor = false;
            this.new_btn.Click += new System.EventHandler(this.new_btn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.cancel_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cancel_btn.Location = new System.Drawing.Point(583, 412);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(119, 31);
            this.cancel_btn.TabIndex = 6;
            this.cancel_btn.Text = "إلغاء";
            this.cancel_btn.UseVisualStyleBackColor = false;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // addnewscrewusage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(714, 455);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.new_btn);
            this.Controls.Add(this.saev_btn);
            this.Controls.Add(this.usage_text_box);
            this.Controls.Add(this.usages_grid_view);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "addnewscrewusage";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "إضافة إستخدام جديد للقلاووظ";
            this.Load += new System.EventHandler(this.addnewscrewusage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.usages_grid_view)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView usages_grid_view;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.TextBox usage_text_box;
        private System.Windows.Forms.Button saev_btn;
        private System.Windows.Forms.Button new_btn;
        private System.Windows.Forms.Button cancel_btn;
    }
}