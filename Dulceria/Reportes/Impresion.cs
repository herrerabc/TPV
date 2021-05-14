using System;
using System.IO;
using System.Data;
using System.Text;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Drawing;
using Dulceria.Entidades;
using System.Configuration;
using QRCoder;
using log4net;

namespace Dulceria
{
    public class Impresion : IDisposable
    {
        private int m_currentPageIndex;
        private IList<Stream> m_streams;
        ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private DataTable LoadSalesData()
        {
            // Create a new DataSet and read sales data file 
            //    data.xml into the first DataTable.
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(@"..\..\data.xml");
            return dataSet.Tables[0];
        }
        // Routine to provide to the report renderer, in order to
        //    save an image for each page of the report.
        private Stream CreateStream(string name,
          string fileNameExtension, Encoding encoding,
          string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }
        // Export the given report as an EMF (Enhanced Metafile) file.
        private void Export(LocalReport report)
        {
            string deviceInfo =
              @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>

            </DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream,
               out warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0;
        }
        // Handler for PrintPageEvents
        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new
               Metafile(m_streams[m_currentPageIndex]);

            // Adjust rectangular area with printer margins.
            Rectangle adjustedRect = new Rectangle(
                ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                ev.PageBounds.Width,
                ev.PageBounds.Height);

            // Draw a white background for the report
            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

            // Draw the report content
            ev.Graphics.DrawImage(pageImage, adjustedRect);

            // Prepare for the next page. Make sure we haven't hit the end.
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

        private void Print()
        {
            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("Error: no stream to print.");
            PrintDocument printDoc = new PrintDocument();
            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: cannot find the default printer.");
            }
            else
            {
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                m_currentPageIndex = 0;
                printDoc.Print();
            }
        }
        // Create a local report for Report.rdlc, load the data,
        //    export the report to an .emf file, and print it.
        //public void Run(List<Model.VentaTicket> ticket, string usr, string reporte, List<ReportParameter> parametros)
        public void Run(EImpresion ticket, bool reimpresion)
        {
            LocalReport report = new LocalReport();
            string Telefono = ConfigurationManager.AppSettings["Telefono"];
            string Domicilio = ConfigurationManager.AppSettings["Domicilio"];
            string Razon = ConfigurationManager.AppSettings["Razon"];

            report.ReportPath =  @"..\..\Reportes\TicketCompra.rdlc";

            EEncabezado enc = new EEncabezado();
            List<EEncabezado> encs = new List<EEncabezado>();

            encs.Add(enc);

            enc.fecha = ticket.fecha;
            enc.usuario = ticket.usuario;
            enc.idTicket = ticket.idTicket;

            report.DataSources.Add(new ReportDataSource("VentaDetalle", ticket.detalle));
            report.DataSources.Add(new ReportDataSource("Venta",encs));
            report.EnableExternalImages = true;
            
            List<ReportParameter> paramList = new List<ReportParameter>();

            string item = ticket.idTicket.ToString();
            string strTicket =  item.PadLeft(12, '0');

            string file = "";

            string dir = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\QRS";
            file = dir + "\\" + strTicket.Trim() + ".jpg";


            if(!File.Exists(file))
                GetQR(strTicket);

            paramList.Add(new ReportParameter("Telefono", Telefono));
            paramList.Add(new ReportParameter("Domicilio", Domicilio));
            paramList.Add(new ReportParameter("TPV", Razon));
            paramList.Add(new ReportParameter("NumeroTicket", strTicket));
            paramList.Add(new ReportParameter("UrlImg", @"file:\"+ new Uri(file).AbsolutePath));
                        
            report.SetParameters(paramList);
            Export(report);
            Print();
        }

        public void Dispose()
        {
            if (m_streams != null)
            {
                foreach (Stream stream in m_streams)
                    stream.Close();
                m_streams = null;
            }
        }
        private void GetQR(string cadena)
        {
            string file = "";
            try
            {
                QRCodeGenerator qr = new QRCodeGenerator();
                QRCodeData data = qr.CreateQrCode(cadena, QRCodeGenerator.ECCLevel.Q);
                QRCode code = new QRCode(data);

                Bitmap img = code.GetGraphic(5);

                string dir = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\QRS";
                file = dir + "\\" + cadena.Trim() + ".jpg";
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                img.Save(file, ImageFormat.Jpeg);                

            }
            catch(Exception e)
            {
                //MessageBox.Show(e.Message);
                Log.Error("Error al generar QR " + e.Message, e);
            }            
        }

        public void ImpQrProd(Eproductos item)
        {
            List<Eproductos> prods = new List<Eproductos>() { item };
            LocalReport report = new LocalReport();
            string Telefono = ConfigurationManager.AppSettings["Telefono"];
            string Domicilio = ConfigurationManager.AppSettings["Domicilio"];
            string Razon = ConfigurationManager.AppSettings["Razon"];

            report.ReportPath = @"..\..\Reportes\Codigos.rdlc";
            
            report.DataSources.Add(new ReportDataSource("Productos",prods));
            report.EnableExternalImages = true;

            List<ReportParameter> paramList = new List<ReportParameter>();
            string file = "";

            string dir = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\QRS";
            file = dir + "\\" + item.codigoBarras.Trim() + ".jpg";


            if (!File.Exists(file))
                GetQR(item.codigoBarras);

            paramList.Add(new ReportParameter("UrlImg", @"file:\" + new Uri(file).AbsolutePath));

            report.SetParameters(paramList);
            Export(report);
            Print();
        }
    }
}