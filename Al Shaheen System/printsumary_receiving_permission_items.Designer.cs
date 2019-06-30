namespace Al_Shaheen_System
{
    partial class printsumary_receiving_permission_items
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
            this.summarysoldquantitiesinformation = new Al_Shaheen_System.summarysoldquantitiesinformation();
            this.summary_dataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.summarysoldquantitiesinformation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.summary_dataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.summary_dataBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Al_Shaheen_System.summary_sold_quanititiesbydatereport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(711, 761);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // summarysoldquantitiesinformation
            // 
            this.summarysoldquantitiesinformation.DataSetName = "summarysoldquantitiesinformation";
            this.summarysoldquantitiesinformation.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // summary_dataBindingSource
            // 
            this.summary_dataBindingSource.DataMember = "summary_data";
            this.summary_dataBindingSource.DataSource = this.summarysoldquantitiesinformation;
            // 
            // printsumary_receiving_permission_items
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 761);
            this.Controls.Add(this.reportViewer1);
            this.Name = "printsumary_receiving_permission_items";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "طباعة ملخص الكميات المباعة بالأصناف ";
            this.Load += new System.EventHandler(this.printsumary_receiving_permission_items_Load);
            ((System.ComponentModel.ISupportInitialize)(this.summarysoldquantitiesinformation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.summary_dataBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource summary_dataBindingSource;
        private summarysoldquantitiesinformation summarysoldquantitiesinformation;
    }
}