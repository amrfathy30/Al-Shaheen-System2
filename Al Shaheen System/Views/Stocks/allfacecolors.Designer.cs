namespace Al_Shaheen_System
{
    partial class allfacecolors
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
            this.colors_grid_view = new System.Windows.Forms.DataGridView();
            this.color_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.color_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.colors_grid_view)).BeginInit();
            this.SuspendLayout();
            // 
            // colors_grid_view
            // 
            this.colors_grid_view.AllowUserToAddRows = false;
            this.colors_grid_view.AllowUserToDeleteRows = false;
            this.colors_grid_view.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.colors_grid_view.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colors_grid_view.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.colors_grid_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.colors_grid_view.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.color_id,
            this.color_name});
            this.colors_grid_view.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.colors_grid_view.Location = new System.Drawing.Point(12, 58);
            this.colors_grid_view.Name = "colors_grid_view";
            this.colors_grid_view.ReadOnly = true;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colors_grid_view.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.colors_grid_view.Size = new System.Drawing.Size(538, 367);
            this.colors_grid_view.TabIndex = 0;
            // 
            // color_id
            // 
            this.color_id.HeaderText = "رقم اللون";
            this.color_id.Name = "color_id";
            this.color_id.ReadOnly = true;
            // 
            // color_name
            // 
            this.color_name.HeaderText = "إسم اللون";
            this.color_name.Name = "color_name";
            this.color_name.ReadOnly = true;
            // 
            // allfacecolors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(562, 437);
            this.Controls.Add(this.colors_grid_view);
            this.Name = "allfacecolors";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "جميع الألوان ";
            this.Load += new System.EventHandler(this.allfacecolors_Load);
            ((System.ComponentModel.ISupportInitialize)(this.colors_grid_view)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView colors_grid_view;
        private System.Windows.Forms.DataGridViewTextBoxColumn color_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn color_name;
    }
}