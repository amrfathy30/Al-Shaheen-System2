namespace Al_Shaheen_System
{
    partial class Addnewstockform
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
            this.stock_name_text_box = new System.Windows.Forms.TextBox();
            this.stock_address_text_box = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.stock_address_gps_link = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.save_stock_btn = new System.Windows.Forms.Button();
            this.new_stock_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(161, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "إضافة مخزن جديد";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(65, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "إسم المخزن ";
            // 
            // stock_name_text_box
            // 
            this.stock_name_text_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stock_name_text_box.Location = new System.Drawing.Point(170, 99);
            this.stock_name_text_box.Name = "stock_name_text_box";
            this.stock_name_text_box.Size = new System.Drawing.Size(298, 26);
            this.stock_name_text_box.TabIndex = 2;
            // 
            // stock_address_text_box
            // 
            this.stock_address_text_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stock_address_text_box.Location = new System.Drawing.Point(170, 142);
            this.stock_address_text_box.Name = "stock_address_text_box";
            this.stock_address_text_box.Size = new System.Drawing.Size(298, 26);
            this.stock_address_text_box.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(65, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "عنوان المخزن ";
            // 
            // stock_address_gps_link
            // 
            this.stock_address_gps_link.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stock_address_gps_link.Location = new System.Drawing.Point(170, 184);
            this.stock_address_gps_link.Name = "stock_address_gps_link";
            this.stock_address_gps_link.Size = new System.Drawing.Size(298, 26);
            this.stock_address_gps_link.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(65, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "GPS Link";
            // 
            // save_stock_btn
            // 
            this.save_stock_btn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.save_stock_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save_stock_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save_stock_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.save_stock_btn.Location = new System.Drawing.Point(40, 241);
            this.save_stock_btn.Name = "save_stock_btn";
            this.save_stock_btn.Size = new System.Drawing.Size(114, 36);
            this.save_stock_btn.TabIndex = 7;
            this.save_stock_btn.Text = "حفظ ";
            this.save_stock_btn.UseVisualStyleBackColor = false;
            this.save_stock_btn.Click += new System.EventHandler(this.save_stock_btn_Click);
            // 
            // new_stock_btn
            // 
            this.new_stock_btn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.new_stock_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.new_stock_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.new_stock_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.new_stock_btn.Location = new System.Drawing.Point(213, 241);
            this.new_stock_btn.Name = "new_stock_btn";
            this.new_stock_btn.Size = new System.Drawing.Size(114, 36);
            this.new_stock_btn.TabIndex = 8;
            this.new_stock_btn.Text = "جديد";
            this.new_stock_btn.UseVisualStyleBackColor = false;
            this.new_stock_btn.Click += new System.EventHandler(this.new_stock_btn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.cancel_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cancel_btn.Location = new System.Drawing.Point(379, 241);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(114, 36);
            this.cancel_btn.TabIndex = 9;
            this.cancel_btn.Text = "إلغاء";
            this.cancel_btn.UseVisualStyleBackColor = false;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // Addnewstockform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(536, 311);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.new_stock_btn);
            this.Controls.Add(this.save_stock_btn);
            this.Controls.Add(this.stock_address_gps_link);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.stock_address_text_box);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.stock_name_text_box);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Addnewstockform";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إضافة مخزن جديد";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox stock_name_text_box;
        private System.Windows.Forms.TextBox stock_address_text_box;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox stock_address_gps_link;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button save_stock_btn;
        private System.Windows.Forms.Button new_stock_btn;
        private System.Windows.Forms.Button cancel_btn;
    }
}