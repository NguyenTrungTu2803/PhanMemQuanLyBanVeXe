namespace DANGNHAP
{
    partial class RePortDSNV
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
            this.ACCOUNTDAILYBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.AcountDataSet = new DANGNHAP.AcountDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ACCOUNTDAILYTableAdapter = new DANGNHAP.AcountDataSetTableAdapters.ACCOUNTDAILYTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ACCOUNTDAILYBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcountDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // ACCOUNTDAILYBindingSource
            // 
            this.ACCOUNTDAILYBindingSource.DataMember = "ACCOUNTDAILY";
            this.ACCOUNTDAILYBindingSource.DataSource = this.AcountDataSet;
            // 
            // AcountDataSet
            // 
            this.AcountDataSet.DataSetName = "AcountDataSet";
            this.AcountDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.ACCOUNTDAILYBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "DANGNHAP.ReportACCOUNTDAILY.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1192, 627);
            this.reportViewer1.TabIndex = 0;
            // 
            // ACCOUNTDAILYTableAdapter
            // 
            this.ACCOUNTDAILYTableAdapter.ClearBeforeFill = true;
            // 
            // RePortDSNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 627);
            this.Controls.Add(this.reportViewer1);
            this.Name = "RePortDSNV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách nhân viên";
            this.Load += new System.EventHandler(this.RePortDSNV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ACCOUNTDAILYBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcountDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ACCOUNTDAILYBindingSource;
        private AcountDataSet AcountDataSet;
        private AcountDataSetTableAdapters.ACCOUNTDAILYTableAdapter ACCOUNTDAILYTableAdapter;

    }
}