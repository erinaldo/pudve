﻿using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
using PuntoDeVentaV2.ReportesImpresion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoDeVentaV2
{
    public partial class ParaMandarRDLCCorreo : Form
    {
        Consultas cs = new Consultas();
        Conexion cn = new Conexion();
        Moneda oMoneda = new Moneda();
        int IDVenta;
        decimal Total = 0;
        string resultado;
        public static string ruta_archivos_guadados = @"C:\Archivos PUDVE\MisDatos\CSD\";
        string[] usuario;
        string nombreUsuario;
        string DireccionLogo;
        bool SiHayLogo = false;
        string pathLogoImage;
        public static bool fuePorVenta = false;
        string correo = "";
        public ParaMandarRDLCCorreo(int IDDeLaVEnta, string email)
        {
            InitializeComponent();
            this.correo = email;
            this.IDVenta = IDDeLaVEnta;
        }

        private void ParaMandarRDLCCorreo_Load(object sender, EventArgs e)
        {
            CargarNotaDeVenta();
            this.reportViewer1.RefreshReport();
        }

        private void CargarNotaDeVenta()
        {
            string cadenaConn = string.Empty;
            string queryVentas = string.Empty;


            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.Hosting))
            {
                cadenaConn = $"datasource={Properties.Settings.Default.Hosting};port=6666;username=root;password=;database=pudve;";
            }
            else
            {
                cadenaConn = "datasource=127.0.0.1;port=6666;username=root;password=;database=pudve;";
            }

            queryVentas = cs.PDFNotaDeVentas(IDVenta);



            MySqlConnection conn = new MySqlConnection();

            conn.ConnectionString = cadenaConn;

            try
            {
                conn.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

            string pathApplication = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string FullReportPath = $@"{pathApplication}\ReportesImpresion\Ticket\NotasVentas\ReporteVenta.rdlc";

            //imagen

            var servidor = Properties.Settings.Default.Hosting;
            string saveDirectoryImg = @"C:\Archivos PUDVE\MisDatos\Usuarios\";

            using (DataTable ConsultaLogo = cn.CargarDatos(cs.buscarNombreLogoTipo2(FormPrincipal.userID)))
            {
                if (!ConsultaLogo.Rows.Count.Equals(0))
                {
                    string Logo = ConsultaLogo.Rows[0]["Logo"].ToString();
                    if (!Logo.Equals(""))
                    {

                        if (!Directory.Exists(saveDirectoryImg))    // verificamos que si no existe el directorio
                        {
                            Directory.CreateDirectory(saveDirectoryImg);    // lo crea para poder almacenar la imagen
                        }
                        if (!string.IsNullOrWhiteSpace(servidor))
                        {
                            // direccion de la carpeta donde se va poner las imagenes
                            pathLogoImage = new Uri($@"\\{servidor}\Archivos PUDVE\MisDatos\Usuarios\").AbsoluteUri;
                            // ruta donde estan guardados los archivos digitales
                            ruta_archivos_guadados = $@"\\{servidor}\Archivos PUDVE\MisDatos\CSD_{Logo}\";

                            DireccionLogo = pathLogoImage + Logo;
                        }
                        else
                        {
                            // direccion de la carpeta donde se va poner las imagenes
                            pathLogoImage = new Uri($"C:/Archivos PUDVE/MisDatos/Usuarios/").AbsoluteUri;
                            // ruta donde estan guardados los archivos digitales
                            ruta_archivos_guadados = $@"C:\Archivos PUDVE\MisDatos\CSD_{Logo}\";

                            DireccionLogo = pathLogoImage + Logo;

                        }
                        SiHayLogo = true;
                    }
                }
            }
            //imagen

            MySqlDataAdapter retiroDA = new MySqlDataAdapter(queryVentas, conn);
            DataTable DTNotaDeVentas = new DataTable();
            retiroDA.Fill(DTNotaDeVentas);

            Total = Convert.ToDecimal(DTNotaDeVentas.Rows[0]["total"]);
            resultado = oMoneda.Convertir(Total.ToString(), true, "PESOS");

            ReportParameterCollection reportParameters = new ReportParameterCollection();
            decimal descuento = 0;
            if (!string.IsNullOrWhiteSpace(DTNotaDeVentas.Rows[0]["DescuentoDirectoProducto"].ToString()))
            {
                descuento = Convert.ToDecimal(DTNotaDeVentas.Rows[0]["DescuentoDirectoProducto"]);
            }
            DTNotaDeVentas.Rows[0]["DescuentoDirectoProducto"] = descuento.ToString("0.00");
            reportParameters.Add(new ReportParameter("TotalEnTexto", resultado));
            if (SiHayLogo.Equals(true))
            {
                reportParameters.Add(new ReportParameter("Logo", DireccionLogo));
            }
            else
            {
                DireccionLogo = "";
                reportParameters.Add(new ReportParameter("Logo", DireccionLogo));
            }
            string StatusVenta = string.Empty;
            using (DataTable ConsultaEstatus = cn.CargarDatos($"SELECT Efectivo,Tarjeta,Vales,Cheque,Transferencia,Credito FROM detallesventa where IDVenta = {IDVenta}"))
            {

                foreach (var item in ConsultaEstatus.Columns)
                {
                    string TipoVenta = item.ToString();
                    if (!ConsultaEstatus.Rows.Count.Equals(0))
                    {
                        if (Convert.ToDecimal(ConsultaEstatus.Rows[0][TipoVenta]) > 0)
                        {
                            StatusVenta += TipoVenta + ",";
                        }
                    }
                }
                DataTable dato = cn.CargarDatos($"SELECT  FormaPago FROM ventas where ID = {IDVenta}");
                if (dato.Rows[0]["FormaPago"].ToString().Equals("Presupuesto"))
                {
                    StatusVenta = "Presupuesto";
                }
                else if (StatusVenta.Equals(""))
                {
                    StatusVenta = "Anticipo";
                }
                else
                {
                    StatusVenta = StatusVenta.TrimEnd(',');
                }

                //string Status = ConsultaEstatus.Rows[0]["Status"].ToString();
                //if (Status.Equals("1"))
                //{
                //    StatusVenta = "Venta Pagada";
                //}
                //else if (Status.Equals("2"))
                //{
                //    StatusVenta = "Presupuesto";
                //}
                //else if (Status.Equals("3"))
                //{
                //    StatusVenta = "Venta Cancelada";
                //}
                //else if (Status.Equals("5"))
                //{
                //    StatusVenta = "Venta Global";
                //}
                //else
                //{
                //    StatusVenta = "Venta a Crédito";
                //}
                /*string Status = ConsultaEstatus.Rows[0]["Status"].ToString();

                if (Status.Equals("1")) { StatusVenta = "Venta Pagada"; }
                if (Status.Equals("2")) { StatusVenta = "Presupuesto"; }
                if (Status.Equals("3")) { StatusVenta = "Venta Cancelada"; }
                if (Status.Equals("4")) { StatusVenta = "Venta a Crédito"; }
                if (Status.Equals("5")) { StatusVenta = "Venta Global"; }

                if (Status.Equals("6")) { StatusVenta = "Renta Pagada"; }
                if (Status.Equals("7")) { StatusVenta = "Presupuesto"; }
                if (Status.Equals("8")) { StatusVenta = "Renta Cancelada"; }
                if (Status.Equals("9")) { StatusVenta = "Renta a Crédito"; }
                if (Status.Equals("10")) { StatusVenta = "Renta Global"; }*/
            }
            if (DTNotaDeVentas.Rows[0]["Status"].ToString().Equals("6"))
            {
                StatusVenta += " (RENTA)";
            }

            reportParameters.Add(new ReportParameter("StatusVenta", StatusVenta));

            string Anticipo = DTNotaDeVentas.Rows[0]["Anticipo"].ToString();
            reportParameters.Add(new ReportParameter("Anticipo", Anticipo));
            string impuestoTraslado = "";
            string impuestoRetenedio = "";


            string TipoIVA = string.Empty;
            string cantidadIVA = string.Empty;
            using (var dt = cn.CargarDatos($"SELECT mostrarIVA FROM configuracion WHERE IDUsuario = {FormPrincipal.userID}"))
            {
                if (dt.Rows[0][0].Equals(1))
                {
                    if (!Convert.ToDecimal(DTNotaDeVentas.Rows[0]["IVA8"]).Equals(0))
                    {
                        TipoIVA = "IVA 8%";
                        cantidadIVA = DTNotaDeVentas.Rows[0]["IVA8"].ToString();
                    }
                    else if (!Convert.ToDecimal(DTNotaDeVentas.Rows[0]["IVA16"]).Equals(0))
                    {
                        TipoIVA = "IVA 16%";
                        cantidadIVA = DTNotaDeVentas.Rows[0]["IVA16"].ToString();
                    }

                    using (var dt3 = cn.CargarDatos($"SELECT ImpuestosTraslados,ImpuestosRetenidos FROM ventas WHERE ID = {IDVenta}"))
                    {
                        if (!dt3.Rows[0]["ImpuestosTraslados"].ToString().Equals("0.00"))
                        {
                            impuestoTraslado = dt3.Rows[0]["ImpuestosTraslados"].ToString();
                        }

                        if (!dt3.Rows[0]["ImpuestosRetenidos"].ToString().Equals("0.00"))
                        {
                            impuestoRetenedio = dt3.Rows[0]["ImpuestosRetenidos"].ToString();
                        }
                    }
                }
                reportParameters.Add(new ReportParameter("TipoIVA", TipoIVA));
                reportParameters.Add(new ReportParameter("cantidadIVA", cantidadIVA));
            }

            reportParameters.Add(new ReportParameter("ImpuestosTraslados", impuestoTraslado));
            reportParameters.Add(new ReportParameter("ImpuestosRetenidos", impuestoRetenedio));

            LocalReport rdlc = new LocalReport();
            rdlc.EnableExternalImages = true;
            rdlc.ReportPath = FullReportPath;
            rdlc.SetParameters(reportParameters);

            this.reportViewer1.ProcessingMode = ProcessingMode.Local;
            this.reportViewer1.LocalReport.ReportPath = FullReportPath;
            this.reportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource NotasVENTAS = new ReportDataSource("DTNotaVenta", DTNotaDeVentas);

            this.reportViewer1.ZoomMode = ZoomMode.PageWidth;
            this.reportViewer1.LocalReport.DataSources.Add(NotasVENTAS);
            this.reportViewer1.LocalReport.EnableExternalImages = true;
            this.reportViewer1.LocalReport.SetParameters(reportParameters);
            this.reportViewer1.RefreshReport();

            string nombreCarpeta = "Notas de Venta";
            string rutaCarpeta = Path.Combine(@"C:\Archivos PUDVE", nombreCarpeta);

            if (!Directory.Exists(rutaCarpeta))
            {
                Directory.CreateDirectory(rutaCarpeta);
            }

            byte[] pdfBytes = this.reportViewer1.LocalReport.Render(format: "PDF", deviceInfo: @"
            <DeviceInfo><EmbedFonts>None</EmbedFonts></DeviceInfo>
            ");
            string nombreUsuario = Environment.UserName;
            string rutaArchivo = Path.Combine(rutaCarpeta, $"NotaDeVenta_{IDVenta.ToString()}.pdf");

            if (!File.Exists(rutaArchivo))
            {
                File.WriteAllBytes(rutaArchivo, pdfBytes);
            }
           

            // Crear el objeto de correo electrónico
            MailMessage mail = new MailMessage("pudve.contacto@gmail.com", correo);
            mail.Subject = "NOTA DE VENTA PUDVE";
            string razonSocial = ""; ;
            using (var dt = cn.CargarDatos($"SELECT RazonSocial FROM usuarios WHERE ID = {FormPrincipal.userID}"))
            {
                razonSocial = dt.Rows[0][0].ToString();
            }
            mail.Body = $"Se ha enviado la nota de venta con el {DTNotaDeVentas.Rows[0]["Folio"].ToString()}\n De:{razonSocial}";

            // Adjuntar el archivo PDF
            Attachment attachment = new Attachment(rutaArchivo);
            mail.Attachments.Add(attachment);

            // Configurar el cliente SMTP
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new NetworkCredential("pudve.contacto@gmail.com", "grtpoxrdmngbozwm");
            smtpClient.EnableSsl = true;

            // Enviar el correo electrónico
            smtpClient.Send(mail);
            this.Close();
        }

    }
}