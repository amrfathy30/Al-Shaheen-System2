namespace Al_Shaheen_System
{
    partial class raw_tin_all_spcifications
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
            this.sh_main_grid_view = new System.Windows.Forms.DataGridView();
            this.SH_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SH_ITEM_LENGTH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SH_ITEM_WIDTH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SH_ITEM_THICKNESS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SH_ITEM_TYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SH_ITEM_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SH_ITEM_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SH_ITEM_TEMPER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SH_ITEM_COATING = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SH_ITEM_FINISH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SH_ITEM_TOTAL_NUMBER_OF_PACKAGES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SH_ITEM_TOTAL_NUMBER_OF_SHEETS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SH_TOTAL_NET_WEIGHT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SH_TOTAL_GROSS_WEIGHT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sh_sp_quantites_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sh_main_grid_view)).BeginInit();
            this.SuspendLayout();
            // 
            // sh_main_grid_view
            // 
            this.sh_main_grid_view.AllowUserToAddRows = false;
            this.sh_main_grid_view.AllowUserToDeleteRows = false;
            this.sh_main_grid_view.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sh_main_grid_view.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.sh_main_grid_view.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.sh_main_grid_view.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.sh_main_grid_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sh_main_grid_view.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SH_ID,
            this.SH_ITEM_LENGTH,
            this.SH_ITEM_WIDTH,
            this.SH_ITEM_THICKNESS,
            this.SH_ITEM_TYPE,
            this.SH_ITEM_NAME,
            this.SH_ITEM_CODE,
            this.SH_ITEM_TEMPER,
            this.SH_ITEM_COATING,
            this.SH_ITEM_FINISH,
            this.SH_ITEM_TOTAL_NUMBER_OF_PACKAGES,
            this.SH_ITEM_TOTAL_NUMBER_OF_SHEETS,
            this.SH_TOTAL_NET_WEIGHT,
            this.SH_TOTAL_GROSS_WEIGHT});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.sh_main_grid_view.DefaultCellStyle = dataGridViewCellStyle2;
            this.sh_main_grid_view.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.sh_main_grid_view.Location = new System.Drawing.Point(12, 71);
            this.sh_main_grid_view.Name = "sh_main_grid_view";
            this.sh_main_grid_view.ReadOnly = true;
            this.sh_main_grid_view.Size = new System.Drawing.Size(956, 597);
            this.sh_main_grid_view.TabIndex = 0;
            this.sh_main_grid_view.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.sh_main_grid_view_CellContentClick);
            // 
            // SH_ID
            // 
            this.SH_ID.HeaderText = "ID";
            this.SH_ID.Name = "SH_ID";
            this.SH_ID.ReadOnly = true;
            // 
            // SH_ITEM_LENGTH
            // 
            this.SH_ITEM_LENGTH.HeaderText = "الطول ";
            this.SH_ITEM_LENGTH.Name = "SH_ITEM_LENGTH";
            this.SH_ITEM_LENGTH.ReadOnly = true;
            // 
            // SH_ITEM_WIDTH
            // 
            this.SH_ITEM_WIDTH.HeaderText = "العرض";
            this.SH_ITEM_WIDTH.Name = "SH_ITEM_WIDTH";
            this.SH_ITEM_WIDTH.ReadOnly = true;
            // 
            // SH_ITEM_THICKNESS
            // 
            this.SH_ITEM_THICKNESS.HeaderText = "السمك";
            this.SH_ITEM_THICKNESS.Name = "SH_ITEM_THICKNESS";
            this.SH_ITEM_THICKNESS.ReadOnly = true;
            // 
            // SH_ITEM_TYPE
            // 
            this.SH_ITEM_TYPE.HeaderText = "نوع الخام";
            this.SH_ITEM_TYPE.Name = "SH_ITEM_TYPE";
            this.SH_ITEM_TYPE.ReadOnly = true;
            // 
            // SH_ITEM_NAME
            // 
            this.SH_ITEM_NAME.HeaderText = "إسم الخام ";
            this.SH_ITEM_NAME.Name = "SH_ITEM_NAME";
            this.SH_ITEM_NAME.ReadOnly = true;
            // 
            // SH_ITEM_CODE
            // 
            this.SH_ITEM_CODE.HeaderText = "كود الصنف";
            this.SH_ITEM_CODE.Name = "SH_ITEM_CODE";
            this.SH_ITEM_CODE.ReadOnly = true;
            // 
            // SH_ITEM_TEMPER
            // 
            this.SH_ITEM_TEMPER.HeaderText = "TEMPER";
            this.SH_ITEM_TEMPER.Name = "SH_ITEM_TEMPER";
            this.SH_ITEM_TEMPER.ReadOnly = true;
            // 
            // SH_ITEM_COATING
            // 
            this.SH_ITEM_COATING.HeaderText = "COATING";
            this.SH_ITEM_COATING.Name = "SH_ITEM_COATING";
            this.SH_ITEM_COATING.ReadOnly = true;
            // 
            // SH_ITEM_FINISH
            // 
            this.SH_ITEM_FINISH.HeaderText = "FINISH";
            this.SH_ITEM_FINISH.Name = "SH_ITEM_FINISH";
            this.SH_ITEM_FINISH.ReadOnly = true;
            // 
            // SH_ITEM_TOTAL_NUMBER_OF_PACKAGES
            // 
            this.SH_ITEM_TOTAL_NUMBER_OF_PACKAGES.HeaderText = "عدد الطرود";
            this.SH_ITEM_TOTAL_NUMBER_OF_PACKAGES.Name = "SH_ITEM_TOTAL_NUMBER_OF_PACKAGES";
            this.SH_ITEM_TOTAL_NUMBER_OF_PACKAGES.ReadOnly = true;
            // 
            // SH_ITEM_TOTAL_NUMBER_OF_SHEETS
            // 
            this.SH_ITEM_TOTAL_NUMBER_OF_SHEETS.HeaderText = "عدد الشيتات";
            this.SH_ITEM_TOTAL_NUMBER_OF_SHEETS.Name = "SH_ITEM_TOTAL_NUMBER_OF_SHEETS";
            this.SH_ITEM_TOTAL_NUMBER_OF_SHEETS.ReadOnly = true;
            // 
            // SH_TOTAL_NET_WEIGHT
            // 
            this.SH_TOTAL_NET_WEIGHT.HeaderText = "الوزن الصافى ";
            this.SH_TOTAL_NET_WEIGHT.Name = "SH_TOTAL_NET_WEIGHT";
            this.SH_TOTAL_NET_WEIGHT.ReadOnly = true;
            // 
            // SH_TOTAL_GROSS_WEIGHT
            // 
            this.SH_TOTAL_GROSS_WEIGHT.HeaderText = "الوزن القائم";
            this.SH_TOTAL_GROSS_WEIGHT.Name = "SH_TOTAL_GROSS_WEIGHT";
            this.SH_TOTAL_GROSS_WEIGHT.ReadOnly = true;
            // 
            // sh_sp_quantites_btn
            // 
            this.sh_sp_quantites_btn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.sh_sp_quantites_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sh_sp_quantites_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sh_sp_quantites_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.sh_sp_quantites_btn.Location = new System.Drawing.Point(12, 27);
            this.sh_sp_quantites_btn.Name = "sh_sp_quantites_btn";
            this.sh_sp_quantites_btn.Size = new System.Drawing.Size(252, 38);
            this.sh_sp_quantites_btn.TabIndex = 1;
            this.sh_sp_quantites_btn.Text = "عرض كميات الصنف";
            this.sh_sp_quantites_btn.UseVisualStyleBackColor = false;
            this.sh_sp_quantites_btn.Click += new System.EventHandler(this.sh_sp_quantites_btn_Click);
            // 
            // raw_tin_all_spcifications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(980, 734);
            this.Controls.Add(this.sh_sp_quantites_btn);
            this.Controls.Add(this.sh_main_grid_view);
            this.Name = "raw_tin_all_spcifications";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "جميع أصناف الصفيح الخام ";
            this.Load += new System.EventHandler(this.raw_tin_all_spcifications_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sh_main_grid_view)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView sh_main_grid_view;
        private System.Windows.Forms.DataGridViewTextBoxColumn SH_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SH_ITEM_LENGTH;
        private System.Windows.Forms.DataGridViewTextBoxColumn SH_ITEM_WIDTH;
        private System.Windows.Forms.DataGridViewTextBoxColumn SH_ITEM_THICKNESS;
        private System.Windows.Forms.DataGridViewTextBoxColumn SH_ITEM_TYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn SH_ITEM_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn SH_ITEM_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn SH_ITEM_TEMPER;
        private System.Windows.Forms.DataGridViewTextBoxColumn SH_ITEM_COATING;
        private System.Windows.Forms.DataGridViewTextBoxColumn SH_ITEM_FINISH;
        private System.Windows.Forms.DataGridViewTextBoxColumn SH_ITEM_TOTAL_NUMBER_OF_PACKAGES;
        private System.Windows.Forms.DataGridViewTextBoxColumn SH_ITEM_TOTAL_NUMBER_OF_SHEETS;
        private System.Windows.Forms.DataGridViewTextBoxColumn SH_TOTAL_NET_WEIGHT;
        private System.Windows.Forms.DataGridViewTextBoxColumn SH_TOTAL_GROSS_WEIGHT;
        private System.Windows.Forms.Button sh_sp_quantites_btn;
    }
}