namespace Al_Shaheen_System
{
    partial class printfinishedcanstotalbalanceform
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
            this.finishedcanstotalbalancedataset = new Al_Shaheen_System.finishedcanstotalbalancedataset();
            this.finishedcanstotalbalancetabelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.finishedcanstotalbalancedataset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.finishedcanstotalbalancetabelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // finishedcanstotalbalancedataset
            // 
            this.finishedcanstotalbalancedataset.DataSetName = "finishedcanstotalbalancedataset";
            this.finishedcanstotalbalancedataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // finishedcanstotalbalancetabelBindingSource
            // 
            this.finishedcanstotalbalancetabelBindingSource.DataMember = "finishedcanstotalbalancetabel";
            this.finishedcanstotalbalancetabelBindingSource.DataSource = this.finishedcanstotalbalancedataset;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "mydataset";
            reportDataSource1.Value = this.finishedcanstotalbalancetabelBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Al_Shaheen_System.finishedcanstotalbalance_report.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(815, 788);
            this.reportViewer1.TabIndex = 0;
            // 
            // printfinishedcanstotalbalanceform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 788);
            this.Controls.Add(this.reportViewer1);
            this.Name = "printfinishedcanstotalbalanceform";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "نافذة طباعة أرصدة علب الصفيح ";
            this.Load += new System.EventHandler(this.printfinishedcanstotalbalanceform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.finishedcanstotalbalancedataset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.finishedcanstotalbalancetabelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource finishedcanstotalbalancetabelBindingSource;
        private finishedcanstotalbalancedataset finishedcanstotalbalancedataset;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}