namespace Al_Shaheen_System
{
    partial class add_new_supply_company_form
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.international_radio_btn = new System.Windows.Forms.RadioButton();
            this.national_client_radio_btn = new System.Windows.Forms.RadioButton();
            this.company_mobile_text_box = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.company_telephone_text_box = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.company_name_text_box = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.save_company_btn = new System.Windows.Forms.Button();
            this.add_new_company_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(117, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(418, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "إضافة شركة توريد جديدة ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.company_mobile_text_box);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.company_telephone_text_box);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.company_name_text_box);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(42, 106);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(541, 268);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "إضافة معلومات شركة التوريد ";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.international_radio_btn);
            this.groupBox2.Controls.Add(this.national_client_radio_btn);
            this.groupBox2.Location = new System.Drawing.Point(13, 90);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(292, 51);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // international_radio_btn
            // 
            this.international_radio_btn.AutoSize = true;
            this.international_radio_btn.Location = new System.Drawing.Point(33, 15);
            this.international_radio_btn.Name = "international_radio_btn";
            this.international_radio_btn.Size = new System.Drawing.Size(61, 29);
            this.international_radio_btn.TabIndex = 1;
            this.international_radio_btn.TabStop = true;
            this.international_radio_btn.Text = "دولى";
            this.international_radio_btn.UseVisualStyleBackColor = true;
            // 
            // national_client_radio_btn
            // 
            this.national_client_radio_btn.AutoSize = true;
            this.national_client_radio_btn.Location = new System.Drawing.Point(220, 17);
            this.national_client_radio_btn.Name = "national_client_radio_btn";
            this.national_client_radio_btn.Size = new System.Drawing.Size(65, 29);
            this.national_client_radio_btn.TabIndex = 0;
            this.national_client_radio_btn.TabStop = true;
            this.national_client_radio_btn.Text = "محلى";
            this.national_client_radio_btn.UseVisualStyleBackColor = true;
            // 
            // company_mobile_text_box
            // 
            this.company_mobile_text_box.Location = new System.Drawing.Point(13, 196);
            this.company_mobile_text_box.Name = "company_mobile_text_box";
            this.company_mobile_text_box.Size = new System.Drawing.Size(292, 30);
            this.company_mobile_text_box.TabIndex = 7;
            this.company_mobile_text_box.TextChanged += new System.EventHandler(this.company_mobile_text_box_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(344, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 25);
            this.label5.TabIndex = 6;
            this.label5.Text = "التليفون المحمول";
            // 
            // company_telephone_text_box
            // 
            this.company_telephone_text_box.Location = new System.Drawing.Point(13, 150);
            this.company_telephone_text_box.Name = "company_telephone_text_box";
            this.company_telephone_text_box.Size = new System.Drawing.Size(292, 30);
            this.company_telephone_text_box.TabIndex = 5;
            this.company_telephone_text_box.TextChanged += new System.EventHandler(this.company_telephone_text_box_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(344, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "التليفون الأرضي";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(344, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "نوع الشركة ";
            // 
            // company_name_text_box
            // 
            this.company_name_text_box.Location = new System.Drawing.Point(13, 58);
            this.company_name_text_box.Name = "company_name_text_box";
            this.company_name_text_box.Size = new System.Drawing.Size(292, 30);
            this.company_name_text_box.TabIndex = 1;
            this.company_name_text_box.TextChanged += new System.EventHandler(this.company_name_text_box_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(344, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "إسم الشركة ";
            // 
            // save_company_btn
            // 
            this.save_company_btn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.save_company_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save_company_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save_company_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.save_company_btn.Location = new System.Drawing.Point(43, 380);
            this.save_company_btn.Name = "save_company_btn";
            this.save_company_btn.Size = new System.Drawing.Size(132, 37);
            this.save_company_btn.TabIndex = 2;
            this.save_company_btn.Text = "حفظ ";
            this.save_company_btn.UseVisualStyleBackColor = false;
            this.save_company_btn.Click += new System.EventHandler(this.save_company_btn_Click);
            // 
            // add_new_company_btn
            // 
            this.add_new_company_btn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.add_new_company_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add_new_company_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add_new_company_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.add_new_company_btn.Location = new System.Drawing.Point(260, 380);
            this.add_new_company_btn.Name = "add_new_company_btn";
            this.add_new_company_btn.Size = new System.Drawing.Size(132, 37);
            this.add_new_company_btn.TabIndex = 3;
            this.add_new_company_btn.Text = "جديد";
            this.add_new_company_btn.UseVisualStyleBackColor = false;
            this.add_new_company_btn.Click += new System.EventHandler(this.add_new_company_btn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.cancel_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cancel_btn.Location = new System.Drawing.Point(451, 380);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(132, 37);
            this.cancel_btn.TabIndex = 4;
            this.cancel_btn.Text = "إلغاء";
            this.cancel_btn.UseVisualStyleBackColor = false;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.RightToLeft = true;
            // 
            // add_new_supply_company_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(640, 439);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.add_new_company_btn);
            this.Controls.Add(this.save_company_btn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "add_new_supply_company_form";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إضافة شركة توريد ";
            this.Load += new System.EventHandler(this.add_new_supply_company_form_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox company_mobile_text_box;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox company_telephone_text_box;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox company_name_text_box;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button save_company_btn;
        private System.Windows.Forms.Button add_new_company_btn;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton international_radio_btn;
        private System.Windows.Forms.RadioButton national_client_radio_btn;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}