namespace ProjetoPcm.Relatorio
{
    partial class FrmRelOrdem
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
            this.controleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sistemapcmDataSet = new ProjetoPcm.sistemapcmDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.controleTableAdapter = new ProjetoPcm.sistemapcmDataSetTableAdapters.controleTableAdapter();
            this.controleporidBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.controleporidBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.controleporidTableAdapter = new ProjetoPcm.sistemapcmDataSetTableAdapters.controleporidTableAdapter();
            this.controleporidBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.controleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sistemapcmDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controleporidBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controleporidBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controleporidBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // controleBindingSource
            // 
            this.controleBindingSource.DataMember = "controle";
            this.controleBindingSource.DataSource = this.sistemapcmDataSet;
            // 
            // sistemapcmDataSet
            // 
            this.sistemapcmDataSet.DataSetName = "sistemapcmDataSet";
            this.sistemapcmDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetRegistro";
            reportDataSource1.Value = this.controleporidBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ProjetoPcm.Relatorio.Relregistro.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // controleTableAdapter
            // 
            this.controleTableAdapter.ClearBeforeFill = true;
            // 
            // controleporidBindingSource
            // 
            this.controleporidBindingSource.DataMember = "controleporid";
            this.controleporidBindingSource.DataSource = this.sistemapcmDataSet;
            // 
            // controleporidBindingSource1
            // 
            this.controleporidBindingSource1.DataMember = "controleporid";
            this.controleporidBindingSource1.DataSource = this.sistemapcmDataSet;
            // 
            // controleporidTableAdapter
            // 
            this.controleporidTableAdapter.ClearBeforeFill = true;
            // 
            // controleporidBindingSource2
            // 
            this.controleporidBindingSource2.DataMember = "controleporid";
            this.controleporidBindingSource2.DataSource = this.sistemapcmDataSet;
            // 
            // FrmRelOrdem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmRelOrdem";
            this.Text = "FrmRegistro";
            this.Load += new System.EventHandler(this.FrmRegistro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.controleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sistemapcmDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.controleporidBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.controleporidBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.controleporidBindingSource2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private sistemapcmDataSet sistemapcmDataSet;
        private System.Windows.Forms.BindingSource controleBindingSource;
        private sistemapcmDataSetTableAdapters.controleTableAdapter controleTableAdapter;
        private System.Windows.Forms.BindingSource controleporidBindingSource;
        private System.Windows.Forms.BindingSource controleporidBindingSource1;
        private sistemapcmDataSetTableAdapters.controleporidTableAdapter controleporidTableAdapter;
        private System.Windows.Forms.BindingSource controleporidBindingSource2;
    }
}