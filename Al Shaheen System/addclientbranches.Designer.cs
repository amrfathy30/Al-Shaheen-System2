namespace Al_Shaheen_System
{
    partial class addclientbranches
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.international_radio_btn = new System.Windows.Forms.RadioButton();
            this.national_client_radio_btn = new System.Windows.Forms.RadioButton();
            this.branch_address_link_text_box = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.branch_address_text_box = new System.Windows.Forms.TextBox();
            this.client_branch_name_text_box = new System.Windows.Forms.TextBox();
            this.client_name_text_box = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.save_client_branch_btn = new System.Windows.Forms.Button();
            this.new_client_branch_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.client_branches_grid_view = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.client_branches_grid_view)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(226, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "إضافة فرع جديد ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.branch_address_link_text_box);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.branch_address_text_box);
            this.groupBox1.Controls.Add(this.client_branch_name_text_box);
            this.groupBox1.Controls.Add(this.client_name_text_box);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(31, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(554, 279);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "معلومات فرع العميل ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.international_radio_btn);
            this.groupBox2.Controls.Add(this.national_client_radio_btn);
            this.groupBox2.Location = new System.Drawing.Point(35, 116);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(286, 51);
            this.groupBox2.TabIndex = 10;
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
            // branch_address_link_text_box
            // 
            this.branch_address_link_text_box.Location = new System.Drawing.Point(35, 221);
            this.branch_address_link_text_box.Name = "branch_address_link_text_box";
            this.branch_address_link_text_box.Size = new System.Drawing.Size(286, 30);
            this.branch_address_link_text_box.TabIndex = 9;
            this.branch_address_link_text_box.TextChanged += new System.EventHandler(this.branch_address_link_text_box_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(371, 221);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 25);
            this.label6.TabIndex = 8;
            this.label6.Text = "لينك GPS للفرع";
            // 
            // branch_address_text_box
            // 
            this.branch_address_text_box.Location = new System.Drawing.Point(35, 173);
            this.branch_address_text_box.Name = "branch_address_text_box";
            this.branch_address_text_box.Size = new System.Drawing.Size(286, 30);
            this.branch_address_text_box.TabIndex = 7;
            this.branch_address_text_box.TextChanged += new System.EventHandler(this.branch_address_text_box_TextChanged);
            // 
            // client_branch_name_text_box
            // 
            this.client_branch_name_text_box.Location = new System.Drawing.Point(35, 84);
            this.client_branch_name_text_box.Name = "client_branch_name_text_box";
            this.client_branch_name_text_box.Size = new System.Drawing.Size(286, 30);
            this.client_branch_name_text_box.TabIndex = 5;
            this.client_branch_name_text_box.TextChanged += new System.EventHandler(this.client_branch_name_text_box_TextChanged);
            // 
            // client_name_text_box
            // 
            this.client_name_text_box.Enabled = false;
            this.client_name_text_box.Location = new System.Drawing.Point(35, 42);
            this.client_name_text_box.Name = "client_name_text_box";
            this.client_name_text_box.Size = new System.Drawing.Size(286, 30);
            this.client_name_text_box.TabIndex = 4;
            this.client_name_text_box.TextChanged += new System.EventHandler(this.client_name_text_box_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(373, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 25);
            this.label5.TabIndex = 3;
            this.label5.Text = "نص عنوان الفرع";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(373, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "التواجد";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(373, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "إسم الفرع";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(373, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "إسم العميل";
            // 
            // save_client_branch_btn
            // 
            this.save_client_branch_btn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.save_client_branch_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save_client_branch_btn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.save_client_branch_btn.Location = new System.Drawing.Point(46, 365);
            this.save_client_branch_btn.Name = "save_client_branch_btn";
            this.save_client_branch_btn.Size = new System.Drawing.Size(128, 48);
            this.save_client_branch_btn.TabIndex = 2;
            this.save_client_branch_btn.Text = "حفظ";
            this.save_client_branch_btn.UseVisualStyleBackColor = false;
            this.save_client_branch_btn.Click += new System.EventHandler(this.save_client_branch_btn_Click);
            // 
            // new_client_branch_btn
            // 
            this.new_client_branch_btn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.new_client_branch_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.new_client_branch_btn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.new_client_branch_btn.Location = new System.Drawing.Point(264, 365);
            this.new_client_branch_btn.Name = "new_client_branch_btn";
            this.new_client_branch_btn.Size = new System.Drawing.Size(123, 48);
            this.new_client_branch_btn.TabIndex = 3;
            this.new_client_branch_btn.Text = "جديد";
            this.new_client_branch_btn.UseVisualStyleBackColor = false;
            this.new_client_branch_btn.Click += new System.EventHandler(this.new_client_branch_btn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.cancel_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel_btn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cancel_btn.Location = new System.Drawing.Point(456, 365);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(129, 48);
            this.cancel_btn.TabIndex = 4;
            this.cancel_btn.Text = "إلغاء";
            this.cancel_btn.UseVisualStyleBackColor = false;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // client_branches_grid_view
            // 
            this.client_branches_grid_view.AllowUserToAddRows = false;
            this.client_branches_grid_view.AllowUserToDeleteRows = false;
            this.client_branches_grid_view.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.client_branches_grid_view.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.client_branches_grid_view.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.client_branches_grid_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.client_branches_grid_view.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.client_branches_grid_view.DefaultCellStyle = dataGridViewCellStyle2;
            this.client_branches_grid_view.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.client_branches_grid_view.Location = new System.Drawing.Point(611, 21);
            this.client_branches_grid_view.Name = "client_branches_grid_view";
            this.client_branches_grid_view.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.client_branches_grid_view.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.client_branches_grid_view.Size = new System.Drawing.Size(669, 377);
            this.client_branches_grid_view.TabIndex = 5;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "م";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "إسم الفرع";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "التواجد";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "العنوان بالنص";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "العنوان GPS";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // addclientbranches
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1303, 425);
            this.Controls.Add(this.client_branches_grid_view);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.new_client_branch_btn);
            this.Controls.Add(this.save_client_branch_btn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "addclientbranches";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إضافة فرع جديد للعميل";
            this.Load += new System.EventHandler(this.addclientbranches_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.client_branches_grid_view)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox branch_address_text_box;
        private System.Windows.Forms.TextBox client_branch_name_text_box;
        private System.Windows.Forms.TextBox client_name_text_box;
        private System.Windows.Forms.Button save_client_branch_btn;
        private System.Windows.Forms.Button new_client_branch_btn;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.TextBox branch_address_link_text_box;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton international_radio_btn;
        private System.Windows.Forms.RadioButton national_client_radio_btn;
        private System.Windows.Forms.DataGridView client_branches_grid_view;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}