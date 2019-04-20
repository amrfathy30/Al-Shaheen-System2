namespace Al_Shaheen_System
{
    partial class printedcaredsforrawmaterial
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.SH_RAW_MATERIAL_PARCELBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.SH_RAW_MATERIAL_PARCELBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // SH_RAW_MATERIAL_PARCELBindingSource
            // 
            this.SH_RAW_MATERIAL_PARCELBindingSource.DataSource = typeof(Al_Shaheen_System.SH_RAW_MATERIAL_PARCEL);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.SH_RAW_MATERIAL_PARCELBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Al_Shaheen_System.new_raw_material_parcels_cards.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.reportViewer1.Size = new System.Drawing.Size(698, 773);
            this.reportViewer1.TabIndex = 0;
            // 
            // printedcaredsforrawmaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 773);
            this.Controls.Add(this.reportViewer1);
            this.Name = "printedcaredsforrawmaterial";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "طباعة كروت الطرود للمخزن ";
            this.Load += new System.EventHandler(this.printedcaredsforrawmaterial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SH_RAW_MATERIAL_PARCELBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource SH_RAW_MATERIAL_PARCELBindingSource;
    }
}