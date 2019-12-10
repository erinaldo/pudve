﻿using System;
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
    public partial class AsignarPropiedad : Form
    {
        Conexion cn = new Conexion();
        Consultas cs = new Consultas();
        MetodosBusquedas mb = new MetodosBusquedas();

        string propiedad = string.Empty;

        Dictionary<int, string> productos;

        public AsignarPropiedad(object propiedad)
        {
            InitializeComponent();

            this.propiedad = propiedad.ToString();

            productos = Productos.productosSeleccionados;
        }

        private void AsignarPropiedad_Load(object sender, EventArgs e)
        {
            lbNombrePropiedad.Text = $"ASIGNAR {propiedad.ToUpper()}";

            CargarPropiedad();
        }

        private void CargarPropiedad()
        {
            Font fuente = new Font("Century Gothic", 10.0f);
            
            if (propiedad == "Mensaje")
            {
                TextBox tbMensaje = new TextBox();
                tbMensaje.Name = "tb" + propiedad;
                tbMensaje.Width = 200;
                tbMensaje.Height = 20;
                tbMensaje.TextAlign = HorizontalAlignment.Center;
                tbMensaje.Font = fuente;
                tbMensaje.Location = new Point(65, 70);

                panelContenedor.Controls.Add(tbMensaje);
                panelContenedor.Controls.Add(GenerarBoton(0, "cancelarMensaje"));
                panelContenedor.Controls.Add(GenerarBoton(1, "aceptarMensaje"));
            }
            else if (propiedad == "Stock")
            {
                TextBox tbStock = new TextBox();
                tbStock.Name = "tb" + propiedad;
                tbStock.Width = 200;
                tbStock.Height = 20;
                tbStock.TextAlign = HorizontalAlignment.Center;
                tbStock.Font = fuente;
                tbStock.KeyPress += new KeyPressEventHandler(SoloDecimales);
                tbStock.Location = new Point(65, 70);

                panelContenedor.Controls.Add(tbStock);
                panelContenedor.Controls.Add(GenerarBoton(0, "cancelarStock"));
                panelContenedor.Controls.Add(GenerarBoton(1, "aceptarStock"));
            }
            else if (propiedad == "Precio")
            {
                TextBox tbPrecio = new TextBox();
                tbPrecio.Name = "tb" + propiedad;
                tbPrecio.Width = 200;
                tbPrecio.Height = 20;
                tbPrecio.TextAlign = HorizontalAlignment.Center;
                tbPrecio.Font = fuente;
                tbPrecio.KeyPress += new KeyPressEventHandler(SoloDecimales);
                tbPrecio.Location = new Point(65, 70);

                panelContenedor.Controls.Add(tbPrecio);
                panelContenedor.Controls.Add(GenerarBoton(0, "cancelarPrecio"));
                panelContenedor.Controls.Add(GenerarBoton(1, "aceptarPrecio"));
            }
            else if (propiedad == "Proveedor")
            {
                var listaProveedores = cn.ObtenerProveedores(FormPrincipal.userID);

                // Comprobamos que tenga proveedores
                if (listaProveedores.Length > 0)
                {
                    Dictionary<int, string> lista = new Dictionary<int, string>();

                    lista.Add(0, "Seleccionar proveedor...");

                    foreach (string proveedor in listaProveedores)
                    {
                        var info = proveedor.Split('-');

                        lista.Add(Convert.ToInt32(info[0].Trim()), info[1].Trim());
                    }

                    ComboBox cbProveedores = new ComboBox();
                    cbProveedores.Name = "cb" + propiedad;
                    cbProveedores.Width = 300;
                    cbProveedores.Height = 20;
                    cbProveedores.Font = fuente;
                    cbProveedores.DropDownStyle = ComboBoxStyle.DropDownList;
                    cbProveedores.DataSource = lista.ToArray();
                    cbProveedores.DisplayMember = "Value";
                    cbProveedores.ValueMember = "Key";
                    cbProveedores.Location = new Point(15, 70);

                    panelContenedor.Controls.Add(cbProveedores);
                    panelContenedor.Controls.Add(GenerarBoton(0, "cancelarProveedor"));
                    panelContenedor.Controls.Add(GenerarBoton(1, "aceptarProveedor"));

                    // Verificamos si fue solo un producto el que se selecciono para buscar si ya tiene
                    // proveedor registrado, si tiene uno registrado ese producto lo selecciona por defecto
                    // en el combobox
                    if (productos.Count == 1)
                    {
                        var idProducto = productos.Keys.First();
                        var detalleProducto = mb.DetallesProducto(idProducto, FormPrincipal.userID);

                        if (detalleProducto.Length > 0)
                        {
                            var idProveedor = Convert.ToInt32(detalleProducto[1]);

                            var datosProveedor = mb.ObtenerDatosProveedor(idProveedor, FormPrincipal.userID);

                            if (datosProveedor.Length > 0)
                            {
                                cbProveedores.SelectedValue = idProveedor;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No hay proveedores registrados", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Dispose();
                }
            }
            else
            {
                // Consulta para obtener todas las opciones registradas para esa propiedad
                var opciones = mb.ObtenerOpcionesPropiedad(FormPrincipal.userID, propiedad);

                if (opciones.Count > 0)
                {
                    // Aqui van todos los que son dinamicos agregados en detalle de producto
                    ComboBox cbPropiedad = new ComboBox();
                    cbPropiedad.Name = "cb" + propiedad;
                    cbPropiedad.Width = 300;
                    cbPropiedad.Height = 20;
                    cbPropiedad.Font = fuente;
                    cbPropiedad.DropDownStyle = ComboBoxStyle.DropDownList;
                    cbPropiedad.DataSource = opciones.ToArray();
                    cbPropiedad.DisplayMember = "Value";
                    cbPropiedad.ValueMember = "Key";
                    cbPropiedad.Location = new Point(15, 70);

                    panelContenedor.Controls.Add(cbPropiedad);
                    panelContenedor.Controls.Add(GenerarBoton(0, "cancelar" + propiedad));
                    panelContenedor.Controls.Add(GenerarBoton(1, "aceptar" + propiedad));
                }
                else
                {
                    MessageBox.Show("No hay opciones registradas para la propiedad " + propiedad, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Dispose();
                }
            }
        }

        private Button GenerarBoton(int tipo, string nombre)
        {
            Button boton = new Button();
            Font fuenteBoton = new Font("Century Gothic", 9.5f);     

            if (tipo == 0)
            {
                Button btnCancelar = new Button();
                btnCancelar.Text = "Cancelar";
                btnCancelar.Name = nombre;
                btnCancelar.BackColor = Color.FromArgb(192, 0, 0);
                btnCancelar.ForeColor = Color.White;
                btnCancelar.FlatStyle = FlatStyle.Flat;
                btnCancelar.Cursor = Cursors.Hand;
                btnCancelar.Font = fuenteBoton;
                btnCancelar.Width = 95;
                btnCancelar.Height = 25;
                btnCancelar.Click += new EventHandler(botonCancelar_Click);
                btnCancelar.Location = new Point(65, 125);

                boton = btnCancelar;
            }
            
            if (tipo == 1)
            {
                Button btnAceptar = new Button();
                btnAceptar.Text = "Aceptar";
                btnAceptar.Name = nombre;
                btnAceptar.BackColor = Color.Green;
                btnAceptar.ForeColor = Color.White;
                btnAceptar.FlatStyle = FlatStyle.Flat;
                btnAceptar.Cursor = Cursors.Hand;
                btnAceptar.Font = fuenteBoton;
                btnAceptar.Width = 95;
                btnAceptar.Height = 25;
                btnAceptar.Click += new EventHandler(botonAceptar_Click);
                btnAceptar.Location = new Point(170, 125);

                boton = btnAceptar;
            }

            return boton;
        }

        private void botonAceptar_Click(object sender, EventArgs e)
        {
            Button boton = sender as Button;

            string[] datos;

            if (propiedad == "Mensaje")
            {
                TextBox txtMensaje = (TextBox)this.Controls.Find("tbMensaje", true)[0];

                var mensaje = txtMensaje.Text;

                if (string.IsNullOrWhiteSpace(mensaje))
                {
                    MessageBox.Show("Ingrese el mensaje para asignar", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                foreach (var producto in productos)
                {
                    // Comprobar si existe ya un mensaje para este producto
                    var comprobar = Convert.ToInt32(cn.EjecutarSelect($"SELECT * FROM ProductMessage WHERE IDProducto = {producto.Key}"));

                    if (comprobar > 0)
                    {
                        // UPDATE
                        cn.EjecutarConsulta($"UPDATE ProductMessage SET ProductOfMessage = '{mensaje}' WHERE IDProducto = {producto.Key}");
                    }
                    else
                    {
                        // INSERT
                        cn.EjecutarConsulta($"INSERT INTO ProductMessage (IDProducto, ProductOfMessage, ProductMessageActivated) VALUES ('{producto.Key}', '{mensaje}', '1')");
                    }
                }
            }
            else if (propiedad == "Stock")
            {
                TextBox txtStock = (TextBox)this.Controls.Find("tbStock", true)[0];

                var stock = txtStock.Text;

                if (!string.IsNullOrWhiteSpace(stock))
                {
                    foreach (var producto in productos)
                    {
                        if (producto.Value == "P")
                        {
                            datos = new string[] { producto.Key.ToString(), stock, FormPrincipal.userID.ToString() };

                            cn.EjecutarConsulta(cs.ActualizarStockProductos(datos));
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese una cantidad para stock", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }    
            }
            else if (propiedad == "Precio")
            {
                TextBox txtPrecio = (TextBox)this.Controls.Find("tbPrecio", true)[0];

                var precioTmp = txtPrecio.Text;

                if (!string.IsNullOrWhiteSpace(precioTmp))
                {
                    var precio = float.Parse(precioTmp);

                    foreach (var producto in productos)
                    {
                        cn.EjecutarConsulta(cs.SetUpPrecioProductos(producto.Key, precio, FormPrincipal.userID));
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese el precio para asignar", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            else if (propiedad == "Proveedor")
            {
                // Acceder al combobox de proveedores
                ComboBox combo = (ComboBox)this.Controls.Find("cbProveedor", true)[0];

                var idProveedor = Convert.ToInt32(combo.SelectedValue.ToString());
                var proveedor = combo.Text;
                
                if (idProveedor > 0)
                {
                    foreach (var producto in productos)
                    {
                        // Comprobar si existe registro en la tabla DetallesProducto
                        var existe = mb.DetallesProducto(producto.Key, FormPrincipal.userID);

                        datos = new string[] {
                            producto.Key.ToString(), FormPrincipal.userID.ToString(),
                            proveedor, idProveedor.ToString()
                        };

                        if (existe.Length > 0)
                        {
                            // Hacemos un UPDATE
                            cn.EjecutarConsulta(cs.GuardarProveedorProducto(datos, 1));
                        }
                        else
                        {
                            // Hacemos un INSERT
                            cn.EjecutarConsulta(cs.GuardarProveedorProducto(datos));
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Es necesario seleccionar un proveedor", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }  
            }
            else
            {
                ComboBox combo = (ComboBox)this.Controls.Find("cb" + propiedad, true)[0];

                var idPropiedad = combo.SelectedValue.ToString();
                var nombreOpcion = combo.Text;
                var nombrePanel = "panelContenido" + propiedad;

                foreach (var producto in productos)
                {
                    var existe = (bool)cn.EjecutarSelect($"SELECT * FROM DetallesProductoGenerales WHERE IDProducto = {producto.Key} AND IDUsuario = {FormPrincipal.userID} AND panelContenido = '{nombrePanel}'");

                    if (existe)
                    {
                        // UPDATE tabla DetallesProductoGenerales
                        cn.EjecutarConsulta($"UPDATE DetallesProductoGenerales SET IDDetalleGral = {idPropiedad} WHERE IDProducto = {producto.Key} AND IDUsuario = {FormPrincipal.userID}");
                    }
                    else
                    {
                        // INSERT tabla DetallesProductoGenerales
                        datos = new string[] {
                            producto.Key.ToString(), FormPrincipal.userID.ToString(),
                            idPropiedad, "1", nombrePanel
                        };

                        cn.EjecutarConsulta(cs.GuardarDetallesProductoGenerales(datos));
                    }
                }
            }

            Dispose();
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void SoloDecimales(object sender, KeyPressEventArgs e)
        {
            //permite 0-9, eliminar y decimal
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }

            //verifica que solo un decimal este permitido
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                {
                    e.Handled = true;
                }
            }
        }
    }
}
