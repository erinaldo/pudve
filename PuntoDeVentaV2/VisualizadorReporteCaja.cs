﻿using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoDeVentaV2
{
    public partial class VisualizadorReporteCaja : Form
    {
        Consultas cs = new Consultas();

        public string PrimeraFecha { get; set; }
        public string SegundaFecha { get; set; }
        public string Conceptos { get; set; }
        public string Operacion { get; set; }

        public VisualizadorReporteCaja()
        {
            InitializeComponent();
        }

        private void VisualizadorReporteCaja_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {

            string cadenaConn = string.Empty;

            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.Hosting))
            {
                cadenaConn = $"datasource={Properties.Settings.Default.Hosting};port=6666;username=root;password=;database=pudve;";
            }
            else
            {
                cadenaConn = "datasource=127.0.0.1;port=6666;username=root;password=;database=pudve;";
            }

            //pasar array como parametro, fechas, conceptos, etc
            string[] datos = new[] { PrimeraFecha, SegundaFecha, Conceptos, Operacion };

            string queryReporteCaja = cs.ImprimirReporteCaja(datos);

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
            string FullReportPath = $@"{pathApplication}\ReportesImpresion\Ticket\ImpimirReporteCaja\ReporteCaja.rdlc";

            //========================================================================
            // DATOS PARA EL TITULO DEL REPORTE
            var usuarioActivo = cs.validarEmpleado(FormPrincipal.userNickName, true);
            var obtenerUsuarioPrincipal = cs.validarEmpleadoPorID();


            var usuarioActual = $"USUARIO: ADMIN ({obtenerUsuarioPrincipal})";

            if (!string.IsNullOrEmpty(usuarioActivo))
            {
                usuarioActual = $"EMPLEADO: {usuarioActivo}";
            }

            var datosEncabezado = new List<DatosEncabezadoReportes>();

            datosEncabezado.Add(new DatosEncabezadoReportes { 
                TituloReporte = "REPORTE DE CAJA",
                Usuario = usuarioActual,
                Subtitulo = Operacion.ToUpper(),
                TextoExtra = $"CONSULTA REALIZADA\nDEL {PrimeraFecha} AL {SegundaFecha}",
                FechaCreacion = $"Fecha de creación: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}"
            });

            //========================================================================

            MySqlDataAdapter reporteCajaDA = new MySqlDataAdapter(queryReporteCaja, conn);
            DataTable reporteCajaDT = new DataTable();

            reporteCajaDA.Fill(reporteCajaDT);

            this.reportViewer1.ProcessingMode = ProcessingMode.Local;
            this.reportViewer1.LocalReport.ReportPath = FullReportPath;
            this.reportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource rp1 = new ReportDataSource("DTReporteCaja", reporteCajaDT);
            ReportDataSource rp2 = new ReportDataSource("DTEncabezado", datosEncabezado);

            this.reportViewer1.LocalReport.DataSources.Add(rp1);
            this.reportViewer1.LocalReport.DataSources.Add(rp2);
            this.reportViewer1.RefreshReport();
        }
    }
}
