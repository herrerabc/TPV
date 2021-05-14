using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dulceria.Entidades;
using Dulceria.Logica;

namespace Dulceria
{
    public partial class Reporte : Form
    {
        IReportes _servicioReportes = new LReportes();
        public Reporte()
        {
            InitializeComponent();
        }

        private void Reporte_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnGenrar_Click(object sender, EventArgs e)
        {
            if(dtpFin.Value < dtpInicio.Value)
            {
                MessageBox.Show("No puede ser la fecha de inicio mayor a la de fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            getreporte();
        }
        private void getreporte()
        {
            reportViewer1.LocalReport.DataSources.Clear();
            List<EReporteVenta> Reporte = new List<EReporteVenta>();

            DateTime fini = Convert.ToDateTime(dtpInicio.Value.ToString("dd/MM/yyyy"));
            DateTime ffin = Convert.ToDateTime(dtpFin.Value.ToString("dd/MM/yyyy"));

            string fecini = "'"+dtpInicio.Value.ToString("yyyyMMdd")+"'";
            string fecfin = "'"+dtpFin.Value.ToString("yyyyMMdd")+"'";

            ETransactionResult result = null;

            Reporte =_servicioReportes.getReporteVenta(fecini, fecfin,chkCancelaciones.Checked,  ref result);
            
            List<ReportParameter> parametros = new List<ReportParameter>();
            ReportDataSource dt = new ReportDataSource();

            parametros.Add(new ReportParameter("FechaIni", fini.ToString()));
            parametros.Add(new ReportParameter("FechaFin", ffin.ToString()));
            parametros.Add(new ReportParameter("Tipo_Reporte", chkCancelaciones.Checked ? "Reporte de Devoluciones": "Reporte de Ventas"));

            reportViewer1.Refresh();
            reportViewer1.LocalReport.SetParameters(parametros);

            dt = new ReportDataSource("ReporteVenta", Reporte);
            reportViewer1.LocalReport.DataSources.Add(dt);

            reportViewer1.RefreshReport();
        }
    }
}
