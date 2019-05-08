namespace Al_Shaheen_System
{
    partial class addnewprinterform
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.printer_name_text_box = new System.Windows.Forms.TextBox();
            this.printer_address_text_box = new System.Windows.Forms.TextBox();
            this.printer_address_gps_text_box = new System.Windows.Forms.TextBox();
            this.save_printer_btn = new System.Windows.Forms.Button();
            this.new_printer_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(212, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(284, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "إضافة مطبعة جديدة ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(63, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "إسم المطبعة";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(63, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "عنوان المطبعة ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(63, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "لينك المطبعة ";
            // 
            // printer_name_text_box
            // 
            this.printer_name_text_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printer_name_text_box.Location = new System.Drawing.Point(183, 112);
            this.printer_name_text_box.Name = "printer_name_text_box";
            this.printer_name_text_box.Size = new System.Drawing.Size(327, 30);
            this.printer_name_text_box.TabIndex = 4;
            // 
            // printer_address_text_box
            // 
            this.printer_address_text_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printer_address_text_box.Location = new System.Drawing.Point(183, 162);
            this.printer_address_text_box.Name = "printer_address_text_box";
            this.printer_address_text_box.Size = new System.Drawing.Size(327, 30);
            this.printer_address_text_box.TabIndex = 5;
            // 
            // printer_address_gps_text_box
            // 
            this.printer_address_gps_text_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printer_address_gps_text_box.Location = new System.Drawing.Point(183, 212);
            this.printer_address_gps_text_box.Name = "printer_address_gps_text_box";
            this.printer_address_gps_text_box.Size = new System.Drawing.Size(327, 30);
            this.printer_address_gps_text_box.TabIndex = 6;
            // 
            // save_printer_btn
            // 
            this.save_printer_btn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.save_printer_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save_printer_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save_printer_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.save_printer_btn.Location = new System.Drawing.Point(32, 301);
            this.save_printer_btn.Name = "save_printer_btn";
            this.save_printer_btn.Size = new System.Drawing.Size(130, 41);
            this.save_printer_btn.TabIndex = 7;
            this.save_printer_btn.Text = "حفظ ";
            this.save_printer_btn.UseVisualStyleBackColor = false;
            this.save_printer_btn.Click += new System.EventHandler(this.save_printer_btn_Click);
            // 
            // new_printer_btn
            // 
            this.new_printer_btn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.new_printer_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.new_printer_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.new_printer_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.new_printer_btn.Location = new System.Drawing.Point(252, 301);
            this.new_printer_btn.Name = "new_printer_btn";
            this.new_printer_btn.Size = new System.Drawing.Size(133, 41);
            this.new_printer_btn.TabIndex = 8;
            this.new_printer_btn.Text = "جديد";
            this.new_printer_btn.UseVisualStyleBackColor = false;
            this.new_printer_btn.Click += new System.EventHandler(this.new_printer_btn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.cancel_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cancel_btn.Location = new System.Drawing.Point(452, 301);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(125, 41);
            this.cancel_btn.TabIndex = 9;
            this.cancel_btn.Text = "إلغاء";
            this.cancel_btn.UseVisualStyleBackColor = false;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // addnewprinterform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(615, 354);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.new_printer_btn);
            this.Controls.Add(this.save_printer_btn);
            this.Controls.Add(this.printer_address_gps_text_box);
            this.Controls.Add(this.printer_address_text_box);
            this.Controls.Add(this.printer_name_text_box);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "addnewprinterform";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إضافة مطبعة جديدة ";
            this.Load += new System.EventHandler(this.addnewprinterform_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox printer_name_text_box;
        private System.Windows.Forms.TextBox printer_address_text_box;
        private System.Windows.Forms.TextBox printer_address_gps_text_box;
        private System.Windows.Forms.Button save_printer_btn;
        private System.Windows.Forms.Button new_printer_btn;
        private System.Windows.Forms.Button cancel_btn;
    }
}