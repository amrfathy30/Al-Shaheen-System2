namespace Al_Shaheen_System
{
    partial class print_exchange_request
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
            this.reportViewer1.DocumentMapCollapsed = true;
            reportDataSource1.Name = "Exchanged_Raw_Material_Parcels_Report";
            reportDataSource1.Value = this.SH_RAW_MATERIAL_PARCELBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Al_Shaheen_System.Exchanged_raw_materail_db.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(727, 729);
            this.reportViewer1.TabIndex = 0;
            // 
            // print_exchange_request
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 729);
            this.Controls.Add(this.reportViewer1);
            this.Name = "print_exchange_request";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "طباعة طلب الصرف";
            this.Load += new System.EventHandler(this.print_exchange_request_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SH_RAW_MATERIAL_PARCELBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource SH_RAW_MATERIAL_PARCELBindingSource;
    }
}