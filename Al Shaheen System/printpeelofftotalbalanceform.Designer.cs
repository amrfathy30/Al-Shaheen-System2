namespace Al_Shaheen_System
{
    partial class printpeelofftotalbalanceform
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.bottomtotalbalancedataset = new Al_Shaheen_System.bottomtotalbalancedataset();
            this.item_dataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bottomtotalbalancedataset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item_dataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.item_dataBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Al_Shaheen_System.bottomtotalbalancereport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(734, 762);
            this.reportViewer1.TabIndex = 0;
            // 
            // bottomtotalbalancedataset
            // 
            this.bottomtotalbalancedataset.DataSetName = "bottomtotalbalancedataset";
            this.bottomtotalbalancedataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // item_dataBindingSource
            // 
            this.item_dataBindingSource.DataMember = "item_data";
            this.item_dataBindingSource.DataSource = this.bottomtotalbalancedataset;
            // 
            // printpeelofftotalbalanceform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 762);
            this.Controls.Add(this.reportViewer1);
            this.Name = "printpeelofftotalbalanceform";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "طباعة أرصدة المخزن من بيل أوف";
            this.Load += new System.EventHandler(this.printpeelofftotalbalanceform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bottomtotalbalancedataset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item_dataBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource item_dataBindingSource;
        private bottomtotalbalancedataset bottomtotalbalancedataset;
    }
}