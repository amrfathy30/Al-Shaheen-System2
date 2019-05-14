namespace Al_Shaheen_System
{
    partial class addnewacccounttreeitem
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
            this.account_code = new System.Windows.Forms.TextBox();
            this.account_name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.account_level = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.mother_branch_tree_account = new System.Windows.Forms.ComboBox();
            this.account_type_combo_box = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.revenu_and_cost_center_combo_box = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.save_btn = new System.Windows.Forms.Button();
            this.new_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.active_check_box = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.last_child_or_not = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(63, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(426, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "إضافة فرع جديد فى شجرة المحاسبة ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "الكود";
            // 
            // account_code
            // 
            this.account_code.Enabled = false;
            this.account_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.account_code.Location = new System.Drawing.Point(182, 216);
            this.account_code.Name = "account_code";
            this.account_code.Size = new System.Drawing.Size(327, 30);
            this.account_code.TabIndex = 2;
            // 
            // account_name
            // 
            this.account_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.account_name.Location = new System.Drawing.Point(182, 267);
            this.account_name.Name = "account_name";
            this.account_name.Size = new System.Drawing.Size(327, 30);
            this.account_name.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 267);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "الإسم";
            // 
            // account_level
            // 
            this.account_level.Enabled = false;
            this.account_level.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.account_level.Location = new System.Drawing.Point(182, 319);
            this.account_level.Name = "account_level";
            this.account_level.Size = new System.Drawing.Size(327, 30);
            this.account_level.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 319);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "المستوى";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(22, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 25);
            this.label5.TabIndex = 7;
            this.label5.Text = "رقم حساب الأم";
            // 
            // mother_branch_tree_account
            // 
            this.mother_branch_tree_account.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mother_branch_tree_account.FormattingEnabled = true;
            this.mother_branch_tree_account.Location = new System.Drawing.Point(183, 158);
            this.mother_branch_tree_account.Name = "mother_branch_tree_account";
            this.mother_branch_tree_account.Size = new System.Drawing.Size(326, 33);
            this.mother_branch_tree_account.TabIndex = 8;
            this.mother_branch_tree_account.SelectedIndexChanged += new System.EventHandler(this.mother_branch_tree_account_SelectedIndexChanged);
            // 
            // account_type_combo_box
            // 
            this.account_type_combo_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.account_type_combo_box.FormattingEnabled = true;
            this.account_type_combo_box.Items.AddRange(new object[] {
            "الميزانية"});
            this.account_type_combo_box.Location = new System.Drawing.Point(182, 480);
            this.account_type_combo_box.Name = "account_type_combo_box";
            this.account_type_combo_box.Size = new System.Drawing.Size(326, 33);
            this.account_type_combo_box.TabIndex = 10;
            this.account_type_combo_box.SelectedIndexChanged += new System.EventHandler(this.account_type_combo_box_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(22, 483);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 25);
            this.label6.TabIndex = 9;
            this.label6.Text = "نوع الحساب";
            // 
            // revenu_and_cost_center_combo_box
            // 
            this.revenu_and_cost_center_combo_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.revenu_and_cost_center_combo_box.FormattingEnabled = true;
            this.revenu_and_cost_center_combo_box.Items.AddRange(new object[] {
            "اى مركز"});
            this.revenu_and_cost_center_combo_box.Location = new System.Drawing.Point(182, 536);
            this.revenu_and_cost_center_combo_box.Name = "revenu_and_cost_center_combo_box";
            this.revenu_and_cost_center_combo_box.Size = new System.Drawing.Size(326, 33);
            this.revenu_and_cost_center_combo_box.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(22, 539);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 25);
            this.label7.TabIndex = 11;
            this.label7.Text = "مركز الربح والتكلفة";
            // 
            // save_btn
            // 
            this.save_btn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.save_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.save_btn.Location = new System.Drawing.Point(27, 608);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(107, 37);
            this.save_btn.TabIndex = 13;
            this.save_btn.Text = "حفظ";
            this.save_btn.UseVisualStyleBackColor = false;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // new_btn
            // 
            this.new_btn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.new_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.new_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.new_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.new_btn.Location = new System.Drawing.Point(206, 608);
            this.new_btn.Name = "new_btn";
            this.new_btn.Size = new System.Drawing.Size(122, 37);
            this.new_btn.TabIndex = 14;
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
            this.cancel_btn.Location = new System.Drawing.Point(396, 608);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(112, 37);
            this.cancel_btn.TabIndex = 15;
            this.cancel_btn.Text = "إلغاء";
            this.cancel_btn.UseVisualStyleBackColor = false;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // active_check_box
            // 
            this.active_check_box.AutoSize = true;
            this.active_check_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.active_check_box.Location = new System.Drawing.Point(183, 385);
            this.active_check_box.Name = "active_check_box";
            this.active_check_box.Size = new System.Drawing.Size(15, 14);
            this.active_check_box.TabIndex = 17;
            this.active_check_box.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(22, 379);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 25);
            this.label8.TabIndex = 16;
            this.label8.Text = "نشط";
            // 
            // last_child_or_not
            // 
            this.last_child_or_not.AutoSize = true;
            this.last_child_or_not.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.last_child_or_not.Location = new System.Drawing.Point(183, 436);
            this.last_child_or_not.Name = "last_child_or_not";
            this.last_child_or_not.Size = new System.Drawing.Size(15, 14);
            this.last_child_or_not.TabIndex = 19;
            this.last_child_or_not.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(22, 430);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 25);
            this.label9.TabIndex = 18;
            this.label9.Text = "المستوى الأخير";
            // 
            // addnewacccounttreeitem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(543, 668);
            this.Controls.Add(this.last_child_or_not);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.active_check_box);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.new_btn);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.revenu_and_cost_center_combo_box);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.account_type_combo_box);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.mother_branch_tree_account);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.account_level);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.account_name);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.account_code);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "addnewacccounttreeitem";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "إضافة فرع جديد فى شجرة المحاسبة";
            this.Activated += new System.EventHandler(this.addnewacccounttreeitem_Activated);
            this.Load += new System.EventHandler(this.addnewacccounttreeitem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox account_code;
        private System.Windows.Forms.TextBox account_name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox account_level;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox mother_branch_tree_account;
        private System.Windows.Forms.ComboBox account_type_combo_box;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox revenu_and_cost_center_combo_box;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.Button new_btn;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.CheckBox active_check_box;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox last_child_or_not;
        private System.Windows.Forms.Label label9;
    }
}