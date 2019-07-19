﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace PuntoDeVentaV2
{
    public partial class AgregarCliente : Form
    {
        Conexion cn = new Conexion();
        Consultas cs = new Consultas();
        MetodosBusquedas mb = new MetodosBusquedas();

        //tipo 1 = agregar
        //tipo 2 = editar
        //tipo 3 = confirmar y editar para antes de timbrar
        private int tipo = 0;
        private int idCliente = 0;
        private int idVenta = 0;

        //idVenta como parametro es para cuando se agrega un cliente al momento de querer timbrar
        //una venta, de esta manera se asigna el ID del cliente al terminar el registro de esta manera
        //con la venta la cual se intenta timbrar
        public AgregarCliente(int tipo = 1, int idCliente = 0, int idVenta = 0)
        {
            InitializeComponent();

            this.tipo = tipo;
            this.idCliente = idCliente;
            this.idVenta = idVenta;
        }

        private void AgregarCliente_Load(object sender, EventArgs e)
        {
            //El titulo que se mostrara al abrir el form
            if (tipo == 1)
            {
                this.Text = "PUDVE - Nuevo Cliente";
            }
            else if (tipo == 2)
            {
                this.Text = "PUDVE - Editar Cliente";
            }
            else if (tipo == 3)
            {
                this.Text = "PUDVE - Confirmar Cliente";
            }

            //ComboBox usos de CFDI
            Dictionary<string, string> usosCFDI = new Dictionary<string, string>();
            usosCFDI.Add("G01", "Adquisición de mercancias");
            usosCFDI.Add("G02", "Devoluciones, descuentos o bonificaciones");
            usosCFDI.Add("G03", "Gastos en general");
            usosCFDI.Add("I01", "Construcciones");
            usosCFDI.Add("I02", "Mobilario y equipo de oficina por inversiones");
            usosCFDI.Add("I03", "Equipo de transporte");
            usosCFDI.Add("I04", "Equipo de computo y accesorios");
            usosCFDI.Add("I05", "Dados, troqueles, moldes, matrices y herramental");
            usosCFDI.Add("I06", "Comunicaciones telefónica");
            usosCFDI.Add("I07", "Comunicaciones satelitale");
            usosCFDI.Add("I08", "Otra maquinaria y equipo");
            usosCFDI.Add("P01", "Por definir");

            cbUsoCFDI.DataSource = usosCFDI.ToArray();
            cbUsoCFDI.DisplayMember = "Value";
            cbUsoCFDI.ValueMember = "Key";

            //ComboBox Formas de pago
            /*Dictionary<string, string> pagos = new Dictionary<string, string>();
            pagos.Add("01", "01 - Efectivo");
            pagos.Add("02", "02 - Cheque nominativo");
            pagos.Add("03", "03 - Transferencia electrónica de fondos");
            pagos.Add("04", "04 - Tarjeta de crédito");
            pagos.Add("05", "05 - Monedero electrónico");
            pagos.Add("06", "06 - Dinero electrónico");
            pagos.Add("08", "08 - Vales de despensa");
            pagos.Add("12", "12 - Dación en pago");
            pagos.Add("13", "13 - Pago por subrogación");
            pagos.Add("14", "14 - Pago por consignación");
            pagos.Add("15", "15 - Condonación");
            pagos.Add("17", "17 - Compensación");
            pagos.Add("23", "23 - Novación");
            pagos.Add("24", "24 - Confusión");
            pagos.Add("25", "25 - Remisión de deuda");
            pagos.Add("26", "26 - Prescripción o caducidad");
            pagos.Add("27", "27 - A satisfacción del acreedor");
            pagos.Add("28", "28 - Tarjeta de débito");
            pagos.Add("29", "29 - Tarjeta de servicios");
            pagos.Add("30", "30 - Aplicación de anticipos");
            pagos.Add("99", "99 - Por definir");

            cbFormaPago.DataSource = pagos.ToArray();
            cbFormaPago.DisplayMember = "Value";
            cbFormaPago.ValueMember = "Key";*/

            //Si viene de la opcion editar o confirmar, buscamos los datos actuales del cliente
            if (tipo == 2 || tipo == 3)
            {
                var cliente = mb.ObtenerDatosCliente(idCliente, FormPrincipal.userID);

                CargarDatosCliente(cliente);

                //Deshabilitamos el checkbox para permitir agregar RFC repetido
                cbCliente.Enabled = false;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            var razon = txtRazonSocial.Text;
            var comercial = txtNombreComercial.Text;
            var rfc = txtRFC.Text;
            var usoCFDI = cbUsoCFDI.SelectedValue;
            var pais = txtPais.Text;
            var estado = txtEstado.Text;
            var municipio = txtMunicipio.Text;
            var localidad = txtLocalidad.Text;
            var cp = txtCP.Text;
            var colonia = txtColonia.Text;
            var calle = txtCalle.Text;
            var noExt = txtNumExt.Text;
            var noInt = txtNumInt.Text;
            var regimen = string.Empty; //Esta vacio porque no se utiliza actualmente el campo de regimen
            var email = txtEmail.Text;
            var telefono = txtTelefono.Text;
            var formaPago = "01"; //cbFormaPago.SelectedValue;
            var fechaOperacion = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            int idCliente = Convert.ToInt32(cn.EjecutarSelect($"SELECT ID FROM Clientes WHERE IDUsuario = {FormPrincipal.userID} AND RFC = '{rfc}' ORDER BY FechaOperacion DESC LIMIT 1", 1));

            if (string.IsNullOrWhiteSpace(razon))
            {
                MessageBox.Show("La razón social es obligatoria", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (string.IsNullOrWhiteSpace(rfc))
            {
                MessageBox.Show("El RFC es un campo obligatorio", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            string[] datos = new string[]
            {
                FormPrincipal.userID.ToString(), razon, comercial, rfc, usoCFDI.ToString(), pais, estado, municipio, localidad,
                cp, colonia, calle, noExt, noInt, regimen.ToString(), email, telefono, formaPago, fechaOperacion, idCliente.ToString()
            };

            //Si el checkbox de agregar cliente repetido esta marcado
            if (cbCliente.Checked)
            {
                bool respuesta = (bool)cn.EjecutarSelect($"SELECT * FROM Clientes WHERE IDUsuario = {FormPrincipal.userID} AND RFC = '{rfc}'");

                if (respuesta)
                {
                    var mensaje = MessageBox.Show("Ya existe un cliente registrado con el mismo RFC.\n\n¿Desea actualizarlo con esta información?", "Mensaje del Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (mensaje == DialogResult.Yes)
                    {
                        //Si selecciona SI se hace una actualizacion con la informacion del formulario al usuario que tiene el mismo RFC
                        int resultado = cn.EjecutarConsulta(cs.GuardarCliente(datos, 1));

                        if (resultado > 0)
                        {
                            this.Close();
                        }
                    }
                    else if (mensaje == DialogResult.No)
                    {
                        //Si selecciona NO se hace un nuevo registro

                        //Insertar
                        int resultado = cn.EjecutarConsulta(cs.GuardarCliente(datos));

                        if (resultado > 0)
                        {
                            if (idVenta > 0)
                            {
                                AsignarCliente(idVenta);
                            }

                            this.Close();
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    //Insertar
                    int resultado = cn.EjecutarConsulta(cs.GuardarCliente(datos));

                    if (resultado > 0)
                    {
                        if (idVenta > 0)
                        {
                            AsignarCliente(idVenta);
                        }

                        this.Close();
                    }
                }
            }
            else
            {
                if (tipo == 1)
                {
                    //Insertar
                    int resultado = cn.EjecutarConsulta(cs.GuardarCliente(datos));

                    if (resultado > 0)
                    {
                        if (idVenta > 0)
                        {
                            AsignarCliente(idVenta);
                        }

                        this.Close();
                    }
                }
                else
                {
                    //Actualizar
                    int resultado = cn.EjecutarConsulta(cs.GuardarCliente(datos, 1));

                    if (resultado > 0)
                    {
                        //Verificamos que sea la confirmacion de que los datos del cliente son los correctos
                        //Al aceptar se actualizara la informacion y generara el XML
                        if (tipo == 3)
                        {
                            GenerarXML();
                        }

                        this.Close();
                    }
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void CargarDatosCliente(string[] datos)
        {
            txtRazonSocial.Text = datos[0];
            txtNombreComercial.Text = datos[2];
            txtRFC.Text = datos[1];
            txtPais.Text = datos[4];
            txtEstado.Text = datos[5];
            txtMunicipio.Text = datos[6];
            txtLocalidad.Text = datos[7];
            txtCP.Text = datos[8];
            txtColonia.Text = datos[9];
            txtCalle.Text = datos[10];
            txtNumExt.Text = datos[11];
            txtNumInt.Text = datos[12];
            txtEmail.Text = datos[13];
            txtTelefono.Text = datos[14];
            cbUsoCFDI.SelectedValue = datos[3];
            //cbFormaPago.SelectedValue = datos[15];
        }

        //Este método se utiliza cuando se quiere timbrar una factura pero no se tienen clientes registrados
        //Se abre el form de registrar nuevo cliente, al terminar el registro obtiene el ID de ese cliente
        //Busca sus datos en este caso la razon social y actualiza la tabla de detalles venta de la venta correspondiente
        private void AsignarCliente(int idVenta)
        {
            int idCliente = Convert.ToInt32(cn.EjecutarSelect($"SELECT ID FROM Clientes WHERE IDUsuario = {FormPrincipal.userID} ORDER BY ID DESC LIMIT 1", 1));

            var tmp = mb.ObtenerDatosCliente(idCliente, FormPrincipal.userID);

            //Actualizar a la tabla detalle de venta
            var razonSocial = tmp[0];

            string[] datos = new string[] { idCliente.ToString(), razonSocial, idVenta.ToString(), FormPrincipal.userID.ToString() };

            cn.EjecutarConsulta(cs.GuardarDetallesVenta(datos, 1));
        }

        private void GenerarXML()
        {
            Comprobante comprobante = new Comprobante();
            comprobante.Folio = "666";

            ComprobanteEmisor emisor = new ComprobanteEmisor();
            emisor.Nombre = "Alejandro";
            emisor.Rfc = "NUSN900420SS5";
            emisor.RegimenFiscal = c_RegimenFiscal.Item601;

            ComprobanteReceptor receptor = new ComprobanteReceptor();
            receptor.Nombre = "Carlos Mafufo";
            receptor.Rfc = "NUSN900420SS6";

            comprobante.Emisor = emisor;
            comprobante.Receptor = receptor;

            string rutaXML = @"C:\Users\Jando\Desktop\xmlprueba.xml";

            XmlSerializer xmlSerializador = new XmlSerializer(typeof(Comprobante));

            string xml = string.Empty;

            using (var sw = new StringWriter())
            {
                using (XmlWriter writter = XmlWriter.Create(sw))
                {
                    xmlSerializador.Serialize(writter, comprobante);
                    xml = sw.ToString();
                }
            }

            //Guardamos la string en el archivo XML
            File.WriteAllText(rutaXML, xml);
        }
    }
}
