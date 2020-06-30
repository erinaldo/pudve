﻿using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoDeVentaV2
{
    public partial class Reportes : Form
    {
        Conexion cn = new Conexion();
        MetodosBusquedas mb = new MetodosBusquedas();

        private string concepto = string.Empty;
        private string fechaInicial = string.Empty;
        private string fechaFinal = string.Empty;

        public static bool botonAceptar = false;

        // Permisos botones
        int opcion1 = 1; // Historial precios
        int opcion2 = 1; // Historial dinero agregado

        public Reportes()
        {
            InitializeComponent();
        }

        private void Reportes_Load(object sender, EventArgs e)
        {
            if (FormPrincipal.id_empleado > 0)
            {
                var permisos = mb.ObtenerPermisosEmpleado(FormPrincipal.id_empleado, "Reportes");

                opcion1 = permisos[0];
                opcion2 = permisos[1];
            }
        }

        private void btnHistorialPrecios_Click(object sender, EventArgs e)
        {
            if (opcion1 == 0)
            {
                Utilidades.MensajePermiso();
                return;
            }

            if (Application.OpenForms.OfType<FechasReportes>().Count() == 1)
            {
                Application.OpenForms.OfType<FechasReportes>().First().BringToFront();
            }
            else
            {
                var fechas = new FechasReportes();

                fechas.FormClosed += delegate
                {
                    if (botonAceptar)
                    {
                        botonAceptar = false;

                        fechaInicial = fechas.fechaInicial;
                        fechaFinal = fechas.fechaFinal;

                        if (!string.IsNullOrWhiteSpace(fechaInicial))
                        {
                            if (!string.IsNullOrWhiteSpace(fechaFinal))
                            {
                                if (Utilidades.AdobeReaderInstalado())
                                {
                                    GenerarReportePrecios();
                                }
                                else
                                {
                                    Utilidades.MensajeAdobeReader();
                                }
                            }
                        }
                    }
                };

                fechas.Show();
            }
        }

        private void GenerarReportePrecios()
        {
            var datos = FormPrincipal.datosUsuario;

            var colorFuenteNegrita = new BaseColor(Color.Black);

            var fuenteNormal = FontFactory.GetFont(FontFactory.HELVETICA, 8);
            var fuenteNegrita = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8, 1, colorFuenteNegrita);
            var fuenteGrande = FontFactory.GetFont(FontFactory.HELVETICA, 10);
            var fuenteMensaje = FontFactory.GetFont(FontFactory.HELVETICA, 10);

            int anchoLogo = 110;
            int altoLogo = 60;

            var fechaActual = DateTime.Now;
            var servidor = Properties.Settings.Default.Hosting;
            var rutaArchivo = $@"C:\Archivos PUDVE\Reportes\Historial\reporte_historial_precios_{fechaActual.ToString("yyyyMMddHHmmss")}.pdf";

            Document reporte = new Document(PageSize.A3);
            PdfWriter writer = PdfWriter.GetInstance(reporte, new FileStream(rutaArchivo, FileMode.Create));

            string logotipo = datos[11];
            //string encabezado = $"\n{datos[1]} {datos[2]} {datos[3]}, {datos[4]}, {datos[5]}\nCol. {datos[6]} C.P. {datos[7]}\nRFC: {datos[8]}\n{datos[9]}\nTel. {datos[10]}\n\n";

            reporte.Open();

            //Validación para verificar si existe logotipo
            if (logotipo != "")
            {
                logotipo = @"C:\Archivos PUDVE\MisDatos\Usuarios\" + logotipo;

                if (File.Exists(logotipo))
                {
                    iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(logotipo);
                    logo.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
                    logo.ScaleAbsolute(anchoLogo, altoLogo);
                    reporte.Add(logo);
                }
            }

            

            Paragraph titulo = new Paragraph(datos[0], fuenteGrande);
            Paragraph subTitulo = new Paragraph("REPORTE HISTORIAL PRECIOS\nFecha: " + fechaActual.ToString("yyyy-MM-dd HH:mm:ss") + "\n\n\n", fuenteNormal);
            //Paragraph domicilio = new Paragraph(encabezado, fuenteNormal);

            titulo.Alignment = Element.ALIGN_CENTER;
            subTitulo.Alignment = Element.ALIGN_CENTER;
            //domicilio.Alignment = Element.ALIGN_CENTER;
            //domicilio.SetLeading(10, 0);

            /***************************************
             ** Tabla con los productos ajustados **
             ***************************************/
            float[] anchoColumnas = new float[] { 300f, 80f, 80f, 100f, 80f };

            PdfPTable tabla = new PdfPTable(5);
            tabla.WidthPercentage = 100;
            tabla.SetWidths(anchoColumnas);

            PdfPCell colProducto = new PdfPCell(new Phrase("Producto / Servicio / Combo", fuenteNegrita));
            colProducto.BorderWidth = 1;
            colProducto.HorizontalAlignment = Element.ALIGN_CENTER;

            PdfPCell colPrecioAnterior = new PdfPCell(new Phrase("Precio Anterior", fuenteNegrita));
            colPrecioAnterior.BorderWidth = 1;
            colPrecioAnterior.HorizontalAlignment = Element.ALIGN_CENTER;

            PdfPCell colPrecioNuevo = new PdfPCell(new Phrase("Precio Nuevo", fuenteNegrita));
            colPrecioNuevo.BorderWidth = 1;
            colPrecioNuevo.HorizontalAlignment = Element.ALIGN_CENTER;

            PdfPCell colOrigen = new PdfPCell(new Phrase("Origen", fuenteNegrita));
            colOrigen.BorderWidth = 1;
            colOrigen.HorizontalAlignment = Element.ALIGN_CENTER;

            PdfPCell colFechaOperacion = new PdfPCell(new Phrase("Fecha de Operación", fuenteNegrita));
            colFechaOperacion.BorderWidth = 1;
            colFechaOperacion.HorizontalAlignment = Element.ALIGN_CENTER;

            tabla.AddCell(colProducto);
            tabla.AddCell(colPrecioAnterior);
            tabla.AddCell(colPrecioNuevo);
            tabla.AddCell(colOrigen);
            tabla.AddCell(colFechaOperacion);


            //Consulta para obtener los registros del Historial de compras
            SQLiteConnection sql_con;
            SQLiteCommand sql_cmd;
            SQLiteDataReader dr;

            if (!string.IsNullOrWhiteSpace(servidor))
            {
                sql_con = new SQLiteConnection("Data source=//" + servidor + @"\BD\pudveDB.db; Version=3; New=False;Compress=True;");
            }
            else
            {
                sql_con = new SQLiteConnection("Data source=" + Properties.Settings.Default.rutaDirectorio + @"\PUDVE\BD\pudveDB.db; Version=3; New=False;Compress=True;");
            }

            sql_con.Open();
            sql_cmd = new SQLiteCommand($"SELECT * FROM HistorialPrecios WHERE IDUsuario = {FormPrincipal.userID} AND DATE(FechaOperacion) BETWEEN '{fechaInicial}' AND '{fechaFinal}' ORDER BY FechaOperacion DESC", sql_con);
            dr = sql_cmd.ExecuteReader();

            while (dr.Read())
            {
                var idProducto = Convert.ToInt32(dr.GetValue(dr.GetOrdinal("IDProducto")));
                var datosProducto = cn.BuscarProducto(idProducto, FormPrincipal.userID);
                var nombreProducto = datosProducto[1];

                var precioAnterior = float.Parse(dr.GetValue(dr.GetOrdinal("PrecioAnterior")).ToString());
                var precioNuevo = float.Parse(dr.GetValue(dr.GetOrdinal("PrecioNuevo")).ToString());
                var origen = dr.GetValue(dr.GetOrdinal("Origen")).ToString();

                DateTime fechaOp = (DateTime)dr.GetValue(dr.GetOrdinal("FechaOperacion"));
                var fechaOperacion = fechaOp.ToString("yyyy-MM-dd HH:mm tt");

                PdfPCell colProductoTmp = new PdfPCell(new Phrase(nombreProducto, fuenteNormal));
                colProductoTmp.BorderWidth = 1;
                colProductoTmp.HorizontalAlignment = Element.ALIGN_CENTER;

                PdfPCell colPrecioAnteriorTmp = new PdfPCell(new Phrase("$" + precioAnterior.ToString("N2"), fuenteNormal));
                colPrecioAnteriorTmp.BorderWidth = 1;
                colPrecioAnteriorTmp.HorizontalAlignment = Element.ALIGN_CENTER;

                PdfPCell colPrecioNuevoTmp = new PdfPCell(new Phrase("$" + precioNuevo.ToString("N2"), fuenteNormal));
                colPrecioNuevoTmp.BorderWidth = 1;
                colPrecioNuevoTmp.HorizontalAlignment = Element.ALIGN_CENTER;

                PdfPCell colOrigenTmp = new PdfPCell(new Phrase(origen, fuenteNormal));
                colOrigenTmp.BorderWidth = 1;
                colOrigenTmp.HorizontalAlignment = Element.ALIGN_CENTER;

                PdfPCell colFechaOperacionTmp = new PdfPCell(new Phrase(fechaOperacion, fuenteNormal));
                colFechaOperacionTmp.BorderWidth = 1;
                colFechaOperacionTmp.HorizontalAlignment = Element.ALIGN_CENTER;

                tabla.AddCell(colProductoTmp);
                tabla.AddCell(colPrecioAnteriorTmp);
                tabla.AddCell(colPrecioNuevoTmp);
                tabla.AddCell(colOrigenTmp);
                tabla.AddCell(colFechaOperacionTmp);
            }

            /******************************************
             ** Fin de la tabla                      **
             ******************************************/

            reporte.Add(titulo);
            reporte.Add(subTitulo);
            //reporte.Add(domicilio);
            reporte.Add(tabla);

            reporte.AddTitle("Reporte Historial Precios");
            reporte.AddAuthor("PUDVE");
            reporte.Close();
            writer.Close();

            VisualizadorReportes vr = new VisualizadorReportes(rutaArchivo);
            vr.ShowDialog();
        }

        private void btnHistorialDineroAgregado_Click(object sender, EventArgs e)
        {
            if (opcion2 == 0)
            {
                Utilidades.MensajePermiso();
                return;
            }

            if (Application.OpenForms.OfType<FechasReportes>().Count() == 1)
            {
                Application.OpenForms.OfType<FechasReportes>().First().BringToFront();
            }
            else
            {
                var fechas = new FechasReportes("CAJA");

                fechas.FormClosed += delegate
                {
                    if (botonAceptar)
                    {
                        botonAceptar = false;

                        concepto = fechas.concepto;
                        fechaInicial = fechas.fechaInicial;
                        fechaFinal = fechas.fechaFinal;

                        if (!string.IsNullOrWhiteSpace(fechaInicial))
                        {
                            if (!string.IsNullOrWhiteSpace(fechaFinal))
                            {
                                if (Utilidades.AdobeReaderInstalado())
                                {
                                    GenerarReporteDineroAgregado();
                                }
                                else
                                {
                                    Utilidades.MensajeAdobeReader();
                                }
                            }
                        }
                    }
                };

                fechas.Show();
            }
        }

        private void GenerarReporteDineroAgregado()
        {
            var consultaGeneral = string.Empty;

            if (concepto.Equals("Seleccionar concepto..."))
            {
                concepto = string.Empty;
            }

            if (string.IsNullOrWhiteSpace(concepto))
            {
                consultaGeneral = $"SELECT * FROM Caja WHERE IDUsuario = {FormPrincipal.userID} AND Operacion = 'deposito' AND DATE(FechaOperacion) BETWEEN '{fechaInicial}' AND '{fechaFinal}' ORDER BY FechaOperacion ASC";
            }
            else
            {
                consultaGeneral = $"SELECT * FROM Caja WHERE IDUsuario = {FormPrincipal.userID} AND Operacion = 'deposito' AND Concepto = '{concepto}' AND DATE(FechaOperacion) BETWEEN '{fechaInicial}' AND '{fechaFinal}' ORDER BY FechaOperacion ASC";
            }

            //==================================================================================================

            using (DataTable dtDineroAgregadoResultado = cn.CargarDatos(consultaGeneral))
            {
                if (dtDineroAgregadoResultado.Rows.Count > 0)
                {
                    // Datos del usuario
                    var datos = FormPrincipal.datosUsuario;

                    // Fuentes y Colores
                    var colorFuenteNegrita = new BaseColor(Color.Black);
                    var colorFuenteBlanca = new BaseColor(Color.White);

                    var fuenteNormal = FontFactory.GetFont(FontFactory.HELVETICA, 8);
                    var fuenteNegrita = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8, 1, colorFuenteNegrita);
                    var fuenteGrande = FontFactory.GetFont(FontFactory.HELVETICA, 10);
                    var fuenteMensaje = FontFactory.GetFont(FontFactory.HELVETICA, 10);
                    var fuenteTotales = FontFactory.GetFont(FontFactory.HELVETICA, 10, 1, colorFuenteBlanca);

                    // Ruta donde se creara el archivo PDF
                    var rutaArchivo = @"C:\Archivos PUDVE\Reportes\Caja\reporte_Dinero_Agregado_Por_Fechas_" + fechaInicial + "_Al_" + fechaFinal + ".pdf";

                    Document reporte = new Document(PageSize.A3);
                    PdfWriter writer = PdfWriter.GetInstance(reporte, new FileStream(rutaArchivo, FileMode.Create));

                    reporte.Open();

                    Paragraph titulo = new Paragraph(datos[0], fuenteGrande);
                    Paragraph subTitulo = new Paragraph("DINERO AGREGADO\nFechas: " + fechaInicial + " al " + fechaFinal + "\n\n", fuenteNormal);

                    titulo.Alignment = Element.ALIGN_CENTER;
                    subTitulo.Alignment = Element.ALIGN_CENTER;

                    reporte.Add(titulo);
                    reporte.Add(subTitulo);

                    //=====================================
                    //===    TABLA DE DINERO AGREGADO   ===
                    //=====================================
                    #region Tabla de Dinero Agregado
                    float[] anchoColumnas = new float[] { 100f, 100f, 100f, 100f, 100f, 100f, 100f };

                    Paragraph tituloDineroAgregado = new Paragraph("HISTORIAL DE DINERO AGREGADO", fuenteGrande);
                    tituloDineroAgregado.Alignment = Element.ALIGN_CENTER;

                    reporte.Add(tituloDineroAgregado);

                    // Linea serapadora
                    Paragraph linea = new Paragraph(new Chunk(new LineSeparator(0.0F, 100.0F, new BaseColor(Color.Black), Element.ALIGN_LEFT, 1)));

                    reporte.Add(linea);

                    PdfPTable tablaDineroAgregado = new PdfPTable(7);
                    tablaDineroAgregado.WidthPercentage = 100;
                    tablaDineroAgregado.SetWidths(anchoColumnas);

                    PdfPCell colEmpleado = new PdfPCell(new Phrase("EMPLEADO", fuenteNegrita));
                    colEmpleado.BorderWidth = 0;
                    colEmpleado.HorizontalAlignment = Element.ALIGN_CENTER;
                    colEmpleado.Padding = 3;

                    PdfPCell colDepositoEfectivo = new PdfPCell(new Phrase("EFECTIVO", fuenteNegrita));
                    colDepositoEfectivo.BorderWidth = 0;
                    colDepositoEfectivo.HorizontalAlignment = Element.ALIGN_CENTER;
                    colDepositoEfectivo.Padding = 3;

                    PdfPCell colDepositoTarjeta = new PdfPCell(new Phrase("TARJETA", fuenteNegrita));
                    colDepositoTarjeta.BorderWidth = 0;
                    colDepositoTarjeta.HorizontalAlignment = Element.ALIGN_CENTER;
                    colDepositoTarjeta.Padding = 3;

                    PdfPCell colDepositoVales = new PdfPCell(new Phrase("VALES", fuenteNegrita));
                    colDepositoVales.BorderWidth = 0;
                    colDepositoVales.HorizontalAlignment = Element.ALIGN_CENTER;
                    colDepositoVales.Padding = 3;

                    PdfPCell colDepositoCheque = new PdfPCell(new Phrase("CHEQUE", fuenteNegrita));
                    colDepositoCheque.BorderWidth = 0;
                    colDepositoCheque.HorizontalAlignment = Element.ALIGN_CENTER;
                    colDepositoCheque.Padding = 3;

                    PdfPCell colDepositoTrans = new PdfPCell(new Phrase("TRANSFERENCIA", fuenteNegrita));
                    colDepositoTrans.BorderWidth = 0;
                    colDepositoTrans.HorizontalAlignment = Element.ALIGN_CENTER;
                    colDepositoTrans.Padding = 3;

                    PdfPCell colDepositoFecha = new PdfPCell(new Phrase("FECHA", fuenteNegrita));
                    colDepositoFecha.BorderWidth = 0;
                    colDepositoFecha.HorizontalAlignment = Element.ALIGN_CENTER;
                    colDepositoFecha.Padding = 3;

                    tablaDineroAgregado.AddCell(colEmpleado);
                    tablaDineroAgregado.AddCell(colDepositoEfectivo);
                    tablaDineroAgregado.AddCell(colDepositoTarjeta);
                    tablaDineroAgregado.AddCell(colDepositoVales);
                    tablaDineroAgregado.AddCell(colDepositoCheque);
                    tablaDineroAgregado.AddCell(colDepositoTrans);
                    tablaDineroAgregado.AddCell(colDepositoFecha);

                    //Varaibles para los Totales
                    float totalEfectivo = 0,
                          totalTarjeta = 0,
                          totalVales = 0,
                          totalCheque = 0,
                          totalTransferencia = 0;

                    float subEfectivo = 0,
                          subTarjeta = 0,
                          subVales = 0,
                          subCheque = 0,
                          subTransferencia = 0;


                    var fechaAuxiliar = "0000-00-00";
                    var longitud = dtDineroAgregadoResultado.Rows.Count - 1;
                    var contador = 0;

                    foreach (DataRow row in dtDineroAgregadoResultado.Rows)
                    {

                        string Empleado = string.Empty,
                                Efectivo = string.Empty,
                                Tarjeta = string.Empty,
                                Vales = string.Empty,
                                Cheque = string.Empty,
                                Transferencia = string.Empty,
                                Fecha = string.Empty;

                        var fechaAux = Convert.ToDateTime(row["FechaOperacion"].ToString());
                        var fecha = fechaAux.ToString("yyyy-MM-dd");

                        if (fechaAuxiliar != "0000-00-00")
                        {
                            if (fecha != fechaAuxiliar)
                            {
                                fechaAuxiliar = fecha;

                                var cantidades = new float[] { subEfectivo, subTarjeta, subVales, subCheque, subTransferencia };

                                ColumnaSubtotal(cantidades, fuenteTotales, tablaDineroAgregado);

                                subEfectivo = 0;
                                subTarjeta = 0;
                                subVales = 0;
                                subCheque = 0;
                                subTransferencia = 0;
                                
                                tablaDineroAgregado.AddCell(colEmpleado);
                                tablaDineroAgregado.AddCell(colDepositoEfectivo);
                                tablaDineroAgregado.AddCell(colDepositoTarjeta);
                                tablaDineroAgregado.AddCell(colDepositoVales);
                                tablaDineroAgregado.AddCell(colDepositoCheque);
                                tablaDineroAgregado.AddCell(colDepositoTrans);
                                tablaDineroAgregado.AddCell(colDepositoFecha);
                            }
                        }
                        else
                        {
                            fechaAuxiliar = fecha;
                        }


                        Empleado = "ADMIN";

                        Efectivo = row["Efectivo"].ToString();
                        totalEfectivo += float.Parse(Efectivo);
                        subEfectivo += float.Parse(Efectivo);

                        Tarjeta = row["Tarjeta"].ToString();
                        totalTarjeta += float.Parse(Tarjeta);
                        subTarjeta += float.Parse(Tarjeta);
                        
                        Vales = row["Vales"].ToString();
                        totalVales += float.Parse(Vales);
                        subVales += float.Parse(Vales);

                        Cheque = row["Cheque"].ToString();
                        totalCheque += float.Parse(Cheque);
                        subCheque += float.Parse(Cheque);

                        Transferencia = row["Transferencia"].ToString();
                        totalTransferencia += float.Parse(Transferencia);
                        subTransferencia += float.Parse(Transferencia);

                        Fecha = row["FechaOperacion"].ToString();

                        PdfPCell colEmpleadoTmp = new PdfPCell(new Phrase(Empleado, fuenteNormal));
                        colEmpleadoTmp.BorderWidth = 0;
                        colEmpleadoTmp.HorizontalAlignment = Element.ALIGN_CENTER;

                        PdfPCell colDepositoEfectivoTmp = new PdfPCell(new Phrase("$ " + Efectivo, fuenteNormal));
                        colDepositoEfectivoTmp.BorderWidth = 0;
                        colDepositoEfectivoTmp.HorizontalAlignment = Element.ALIGN_CENTER;

                        PdfPCell colDepositoTarjetaTmp = new PdfPCell(new Phrase("$ " + Tarjeta, fuenteNormal));
                        colDepositoTarjetaTmp.BorderWidth = 0;
                        colDepositoTarjetaTmp.HorizontalAlignment = Element.ALIGN_CENTER;

                        PdfPCell colDepositoValesTmp = new PdfPCell(new Phrase("$ " + Vales, fuenteNormal));
                        colDepositoValesTmp.BorderWidth = 0;
                        colDepositoValesTmp.HorizontalAlignment = Element.ALIGN_CENTER;

                        PdfPCell colDepositoChequeTmp = new PdfPCell(new Phrase("$ " + Cheque, fuenteNormal));
                        colDepositoChequeTmp.BorderWidth = 0;
                        colDepositoChequeTmp.HorizontalAlignment = Element.ALIGN_CENTER;

                        PdfPCell colDepositoTransTmp = new PdfPCell(new Phrase("$ " + Transferencia, fuenteNormal));
                        colDepositoTransTmp.BorderWidth = 0;
                        colDepositoTransTmp.HorizontalAlignment = Element.ALIGN_CENTER;

                        PdfPCell colDepositoFechaTmp = new PdfPCell(new Phrase(Fecha, fuenteNormal));
                        colDepositoFechaTmp.BorderWidth = 0;
                        colDepositoFechaTmp.HorizontalAlignment = Element.ALIGN_CENTER;

                        tablaDineroAgregado.AddCell(colEmpleadoTmp);
                        tablaDineroAgregado.AddCell(colDepositoEfectivoTmp);
                        tablaDineroAgregado.AddCell(colDepositoTarjetaTmp);
                        tablaDineroAgregado.AddCell(colDepositoValesTmp);
                        tablaDineroAgregado.AddCell(colDepositoChequeTmp);
                        tablaDineroAgregado.AddCell(colDepositoTransTmp);
                        tablaDineroAgregado.AddCell(colDepositoFechaTmp);


                        if (contador == longitud)
                        {
                            var cantidades = new float[] { subEfectivo, subTarjeta, subVales, subCheque, subTransferencia };

                            ColumnaSubtotal(cantidades, fuenteTotales, tablaDineroAgregado);
                        }

                        contador++;
                    }

                    reporte.Add(tablaDineroAgregado);
                    reporte.Add(linea);

                    PdfPTable tablaTotalesDineroAgregado = new PdfPTable(7);
                    tablaTotalesDineroAgregado.WidthPercentage = 100;
                    tablaTotalesDineroAgregado.SpacingBefore = 10;
                    tablaTotalesDineroAgregado.SetWidths(anchoColumnas);

                    // Linea de TOTALES
                    PdfPCell colEmpleadoTotal = new PdfPCell(new Phrase($"TOTAL", fuenteTotales));
                    colEmpleadoTotal.BorderWidth = 0;
                    colEmpleadoTotal.HorizontalAlignment = Element.ALIGN_CENTER;
                    colEmpleadoTotal.Padding = 3;
                    colEmpleadoTotal.BackgroundColor = new BaseColor(Color.Red);

                    PdfPCell colEfectivoTotal = new PdfPCell(new Phrase("$ " + totalEfectivo.ToString("N2"), fuenteTotales));
                    colEfectivoTotal.BorderWidth = 0;
                    colEfectivoTotal.HorizontalAlignment = Element.ALIGN_CENTER;
                    colEfectivoTotal.Padding = 3;
                    colEfectivoTotal.BackgroundColor = new BaseColor(Color.Red);

                    PdfPCell colTarjetaTotal = new PdfPCell(new Phrase("$ " + totalTarjeta.ToString("N2"), fuenteTotales));
                    colTarjetaTotal.BorderWidth = 0;
                    colTarjetaTotal.HorizontalAlignment = Element.ALIGN_CENTER;
                    colTarjetaTotal.Padding = 3;
                    colTarjetaTotal.BackgroundColor = new BaseColor(Color.Red);

                    PdfPCell colValesTotal = new PdfPCell(new Phrase("$ " + totalVales.ToString("N2"), fuenteTotales));
                    colValesTotal.BorderWidth = 0;
                    colValesTotal.HorizontalAlignment = Element.ALIGN_CENTER;
                    colValesTotal.Padding = 3;
                    colValesTotal.BackgroundColor = new BaseColor(Color.Red);

                    PdfPCell colChequeTotal = new PdfPCell(new Phrase("$ " + totalCheque.ToString("N2"), fuenteTotales));
                    colChequeTotal.BorderWidth = 0;
                    colChequeTotal.HorizontalAlignment = Element.ALIGN_CENTER;
                    colChequeTotal.Padding = 3;
                    colChequeTotal.BackgroundColor = new BaseColor(Color.Red);

                    PdfPCell colTransaccionTotal = new PdfPCell(new Phrase("$ " + totalTransferencia.ToString("N2"), fuenteTotales));
                    colTransaccionTotal.BorderWidth = 0;
                    colTransaccionTotal.HorizontalAlignment = Element.ALIGN_CENTER;
                    colTransaccionTotal.Padding = 3;
                    colTransaccionTotal.BackgroundColor = new BaseColor(Color.Red);

                    PdfPCell colFechaTotal = new PdfPCell(new Phrase("", fuenteTotales));
                    colFechaTotal.BorderWidth = 0;
                    colFechaTotal.HorizontalAlignment = Element.ALIGN_CENTER;
                    colFechaTotal.Padding = 3;
                    colFechaTotal.BackgroundColor = new BaseColor(Color.Red);

                    tablaTotalesDineroAgregado.AddCell(colEmpleadoTotal);
                    tablaTotalesDineroAgregado.AddCell(colEfectivoTotal);
                    tablaTotalesDineroAgregado.AddCell(colTarjetaTotal);
                    tablaTotalesDineroAgregado.AddCell(colValesTotal);
                    tablaTotalesDineroAgregado.AddCell(colChequeTotal);
                    tablaTotalesDineroAgregado.AddCell(colTransaccionTotal);
                    tablaTotalesDineroAgregado.AddCell(colFechaTotal);

                    reporte.Add(tablaTotalesDineroAgregado);
                    #endregion Tabla de Dinero Agregado
                    //=====================================
                    //=== FIN TABLA DE DINERO AGREGADO  ===
                    //=====================================
                    reporte.AddTitle("Reporte Dinero Agregado Por Fechas");
                    reporte.AddAuthor("PUDVE");
                    reporte.Close();
                    writer.Close();

                    VisualizadorReportes vr = new VisualizadorReportes(rutaArchivo);
                    vr.ShowDialog();
                }
                else if (dtDineroAgregadoResultado.Rows.Count <= 0)
                {
                    MessageBox.Show("El rango de fechas que usted ha seleccionado\nNo contiene información para generar el reporte", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void ColumnaSubtotal(float[] datos, iTextSharp.text.Font fuenteTotales, PdfPTable tabla)
        {
            PdfPCell colSubTotal = new PdfPCell(new Phrase($"SUBTOTAL", fuenteTotales));
            colSubTotal.BorderWidth = 0;
            colSubTotal.HorizontalAlignment = Element.ALIGN_CENTER;
            colSubTotal.Padding = 3;
            colSubTotal.BackgroundColor = new BaseColor(Color.Red);

            PdfPCell colSubEfectivo = new PdfPCell(new Phrase("$ " + datos[0].ToString("N2"), fuenteTotales));
            colSubEfectivo.BorderWidth = 0;
            colSubEfectivo.HorizontalAlignment = Element.ALIGN_CENTER;
            colSubEfectivo.Padding = 3;
            colSubEfectivo.BackgroundColor = new BaseColor(Color.Red);

            PdfPCell colSubTarjeta = new PdfPCell(new Phrase("$ " + datos[1].ToString("N2"), fuenteTotales));
            colSubTarjeta.BorderWidth = 0;
            colSubTarjeta.HorizontalAlignment = Element.ALIGN_CENTER;
            colSubTarjeta.Padding = 3;
            colSubTarjeta.BackgroundColor = new BaseColor(Color.Red);

            PdfPCell colSubVales = new PdfPCell(new Phrase("$ " + datos[2].ToString("N2"), fuenteTotales));
            colSubVales.BorderWidth = 0;
            colSubVales.HorizontalAlignment = Element.ALIGN_CENTER;
            colSubVales.Padding = 3;
            colSubVales.BackgroundColor = new BaseColor(Color.Red);

            PdfPCell colSubCheque = new PdfPCell(new Phrase("$ " + datos[3].ToString("N2"), fuenteTotales));
            colSubCheque.BorderWidth = 0;
            colSubCheque.HorizontalAlignment = Element.ALIGN_CENTER;
            colSubCheque.Padding = 3;
            colSubCheque.BackgroundColor = new BaseColor(Color.Red);

            PdfPCell colSubTrans = new PdfPCell(new Phrase("$ " + datos[4].ToString("N2"), fuenteTotales));
            colSubTrans.BorderWidth = 0;
            colSubTrans.HorizontalAlignment = Element.ALIGN_CENTER;
            colSubTrans.Padding = 3;
            colSubTrans.BackgroundColor = new BaseColor(Color.Red);

            PdfPCell colAuxiliar = new PdfPCell(new Phrase("", fuenteTotales));
            colAuxiliar.BorderWidth = 0;
            colAuxiliar.HorizontalAlignment = Element.ALIGN_CENTER;
            colAuxiliar.Padding = 3;
            colAuxiliar.BackgroundColor = new BaseColor(Color.Red);

            tabla.AddCell(colSubTotal);
            tabla.AddCell(colSubEfectivo);
            tabla.AddCell(colSubTarjeta);
            tabla.AddCell(colSubVales);
            tabla.AddCell(colSubCheque);
            tabla.AddCell(colSubTrans);
            tabla.AddCell(colAuxiliar);
        }
    }
}
