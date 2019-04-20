namespace Al_Shaheen_System
{
    partial class addnewfacecolorform
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
            this.color_name_text_box = new System.Windows.Forms.TextBox();
            this.save_new_color_btn = new System.Windows.Forms.Button();
            this.new_color_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(169, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "إضافة لون جديد ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "إسم اللون ";
            // 
            // color_name_text_box
            // 
            this.color_name_text_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.color_name_text_box.Location = new System.Drawing.Point(130, 84);
            this.color_name_text_box.Name = "color_name_text_box";
            this.color_name_text_box.Size = new System.Drawing.Size(299, 26);
            this.color_name_text_box.TabIndex = 2;
            // 
            // save_new_color_btn
            // 
            this.save_new_color_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save_new_color_btn.Location = new System.Drawing.Point(12, 148);
            this.save_new_color_btn.Name = "save_new_color_btn";
            this.save_new_color_btn.Size = new System.Drawing.Size(114, 41);
            this.save_new_color_btn.TabIndex = 3;
            this.save_new_color_btn.Text = "حفظ ";
            this.save_new_color_btn.UseVisualStyleBackColor = true;
            this.save_new_color_btn.Click += new System.EventHandler(this.save_new_color_btn_Click);
            // 
            // new_color_btn
            // 
            this.new_color_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.new_color_btn.Location = new System.Drawing.Point(177, 148);
            this.new_color_btn.Name = "new_color_btn";
            this.new_color_btn.Size = new System.Drawing.Size(118, 41);
            this.new_color_btn.TabIndex = 4;
            this.new_color_btn.Text = "جديد";
            this.new_color_btn.UseVisualStyleBackColor = true;
            this.new_color_btn.Click += new System.EventHandler(this.new_color_btn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel_btn.Location = new System.Drawing.Point(358, 148);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(120, 41);
            this.cancel_btn.TabIndex = 5;
            this.cancel_btn.Text = "إلغاء";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // addnewfacecolorform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 201);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.new_color_btn);
            this.Controls.Add(this.save_new_color_btn);
            this.Controls.Add(this.color_name_text_box);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "addnewfacecolorform";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إضافة لون وجة جديد";
            this.Load += new System.EventHandler(this.addnewfacecolorform_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox color_name_text_box;
        private System.Windows.Forms.Button save_new_color_btn;
        private System.Windows.Forms.Button new_color_btn;
        private System.Windows.Forms.Button cancel_btn;
    }
}