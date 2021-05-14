using Dulceria.Entidades;
using Dulceria.Logica;
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

namespace Dulceria
{
    public partial class ReporteExistencia : Form
    {
        IReportes _servicioReportes = new LReportes();
        public ReporteExistencia()
        {
            InitializeComponent();
        }

        private void ReporteExistencia_Load(object sender, EventArgs e)
        {
            getReporte();
        }
        private void getReporte()
        {
            RPTExistencias.LocalReport.DataSources.Clear();
            List<EExistencias> Reporte = new List<EExistencias>();
            ETransactionResult result = null;

            Reporte = _servicioReportes.getExistencias(ref result);

            
            ReportDataSource dt = new ReportDataSource();

            RPTExistencias.Refresh();            

            dt = new ReportDataSource("Existencia", Reporte);
            RPTExistencias.LocalReport.DataSources.Add(dt);

            RPTExistencias.RefreshReport();
        }
    }
}
