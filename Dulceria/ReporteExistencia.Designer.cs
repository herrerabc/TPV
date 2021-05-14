namespace Dulceria
{
    partial class ReporteExistencia
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.RPTExistencias = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.RPTExistencias, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(885, 608);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // RPTExistencias
            // 
            this.RPTExistencias.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "datos";
            reportDataSource1.Value = null;
            this.RPTExistencias.LocalReport.DataSources.Add(reportDataSource1);
            this.RPTExistencias.LocalReport.ReportEmbeddedResource = "Dulceria.Reportes.ReporteExistencias.rdlc";
            this.RPTExistencias.Location = new System.Drawing.Point(4, 4);
            this.RPTExistencias.Margin = new System.Windows.Forms.Padding(4);
            this.RPTExistencias.Name = "RPTExistencias";
            this.RPTExistencias.ShowBackButton = false;
            this.RPTExistencias.ShowFindControls = false;
            this.RPTExistencias.ShowPrintButton = false;
            this.RPTExistencias.ShowStopButton = false;
            this.RPTExistencias.Size = new System.Drawing.Size(877, 600);
            this.RPTExistencias.TabIndex = 1;
            // 
            // ReporteExistencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 608);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ReporteExistencia";
            this.Text = "ReporteExistencia";
            this.Load += new System.EventHandler(this.ReporteExistencia_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Microsoft.Reporting.WinForms.ReportViewer RPTExistencias;
    }
}