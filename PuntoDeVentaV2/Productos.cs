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

namespace PuntoDeVentaV2
{
    public partial class Productos : Form
    {
        public AgregarEditarProducto FormAgregar = new AgregarEditarProducto("Agregar Producto");
        public AgregarStockXML FormXML = new AgregarStockXML();
        public RecordViewProduct ProductoRecord = new RecordViewProduct();
        public CodeBarMake MakeBarCode = new CodeBarMake();
        public photoShow VentanaMostrarFoto = new photoShow();
        //public string rutaDirectorio = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));

        Conexion cn = new Conexion();
        Consultas cs = new Consultas();

        int numfila, index, number_of_rows, i, seleccionadoDato, origenDeLosDatos=0, editarEstado = 0, numerofila = 0;
        string Id_Prod_select, buscar, id, Nombre, Precio, Stock, ClaveInterna, CodigoBarras, status, filtro;

        DataTable dt, dtConsulta;
        DataGridViewButtonColumn setup, record, barcode, foto;
        DataGridViewImageCell cell;

        Icon image;

        OpenFileDialog f;       // declaramos el objeto de OpenFileDialog

        // objeto para el manejo de las imagenes
        FileStream File, File1;
        FileInfo info;

        // direccion de la carpeta donde se va poner las imagenes
        string saveDirectoryImg = Properties.Settings.Default.rutaDirectorio + @"\Productos\";
        // nombre de archivo
        string fileName;
        // directorio origen de la imagen
        string oldDirectory;
        // directorio para guardar el archivo
        string fileSavePath;
        // Nuevo nombre del archivo
        string NvoFileName;

        string logoTipo = "";

        string ProductoNombre, ProductoStock, ProductoPrecio, ProductoCategoria, ProductoClaveInterna, ProductoCodigoBarras;

        private void DGVProductos_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                foreach (DataGridViewRow row in DGVProductos.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[e.ColumnIndex].Value))
                    {
                        row.Cells[e.ColumnIndex].Value = false;
                    }
                }
            }
        }

        private void btnModificarEstado_Click(object sender, EventArgs e)
        {
            if (editarEstado == 4 && Convert.ToBoolean(DGVProductos.Rows[numerofila].Cells[0].Value) == true)
            {
                //MessageBox.Show("Proceso de Cambiar el estado del\nProducto: " + ProductoNombre, "Proceso de Actividades", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                string status;
                DialogResult result = MessageBox.Show("Desdea Realmente Modificar el Estatus del\nProducto: " + Nombre + "\nde su Stock Existente", "Advertencia", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    status = DGVProductos.Rows[numerofila].Cells[12].Value.ToString();
                    ModificarStatusProductoChkBox();
                    if (status == "1")
                    {
                        cbMostrar.Text = "Deshabilitados";
                    }
                    else if (status == "0")
                    {
                        cbMostrar.Text = "Habilitados";
                    }
                    DGVProductos.Refresh();
                }
                else if (result == DialogResult.No)
                {
                    status = cbMostrar.Text;
                    DGVProductos.Rows[numerofila].Cells[0].Value = false;
                    if (status == "Habilitados")
                    {
                        DGVProductos.Refresh();
                    }
                    else if (status == "Deshabilitados")
                    {
                        DGVProductos.Refresh();
                    }
                }
                else if (result == DialogResult.Cancel)
                {
                    DGVProductos.Rows[numerofila].Cells[0].Value = false;
                    DGVProductos.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Favor de seleccionar (Marcar un)\nalgun CheckBox (Casilla de Verificación)", "Verificar Selección", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DGVProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                numerofila = e.RowIndex;
                Nombre = DGVProductos.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                Stock = DGVProductos.Rows[e.RowIndex].Cells["Stock"].Value.ToString();
                Precio = DGVProductos.Rows[e.RowIndex].Cells["Precio"].Value.ToString();
                ProductoCategoria = DGVProductos.Rows[e.RowIndex].Cells["Categoria"].Value.ToString();
                ClaveInterna = DGVProductos.Rows[e.RowIndex].Cells["Clave Interna"].Value.ToString();
                CodigoBarras = DGVProductos.Rows[e.RowIndex].Cells["Código de Barras"].Value.ToString();
                id = FormPrincipal.userID.ToString();
                editarEstado = 4;
            }
        }

        private void cbMostrar_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtro = Convert.ToString(cbMostrar.SelectedItem);      // tomamos el valor que se elige en el TextBox
            if (filtro == "Habilitados")                            // comparamos si el valor a filtrar es Habilitados
            {
                // almacenamos el resultado de la consulta en dtConsulta
                dtConsulta = cn.CargarDatos(cs.StatusProductos(FormPrincipal.userID.ToString(), "1"));
                DGVProductos.DataSource = dtConsulta;               // llenamos el DataGridView con el resultado de la consulta
            }
            else if (filtro == "Deshabilitados")                    // comparamos si el valor a filtrar es Deshabilitados
            {
                // almacenamos el resultado de la consulta en dtConsulta
                dtConsulta = cn.CargarDatos(cs.StatusProductos(FormPrincipal.userID.ToString(), "0"));
                DGVProductos.DataSource = dtConsulta;               // llenamos el DataGridView con el resultado de la consulta
            }
            else if (filtro == "Todos")                             // comparamos si el valor a filtrar es Todos
            {
                CargarDatos();                                      // cargamos todos los registros
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            dtConsulta.DefaultView.RowFilter = $"Nombre LIKE '{txtBusqueda.Text}%'";
        }

        public Productos()
        {
            InitializeComponent();
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            CargarDatos();
            cbOrden.SelectedIndex = 0;
            cbOrden.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMostrar.SelectedIndex = 0;
            cbMostrar.DropDownStyle = ComboBoxStyle.DropDownList;

            DataGridViewImageColumn editar = new DataGridViewImageColumn();
            editar.Image = Image.FromFile(Properties.Settings.Default.rutaDirectorio + @"\icon\black16\pencil.png");
            editar.Width = 50;
            editar.HeaderText = "Editar";
            DGVProductos.Columns.Add(editar);

            setup = new DataGridViewButtonColumn();
            setup.Width = 40;
            setup.Name = "status";
            setup.HeaderText = "Estado";
            DGVProductos.Columns.Add(setup);

            record = new DataGridViewButtonColumn();
            record.Width = 40;
            record.Name = "historial";
            record.HeaderText = "Historial";
            DGVProductos.Columns.Add(record);

            barcode = new DataGridViewButtonColumn();
            barcode.Width = 40;
            barcode.Name = "CodigoBarras";
            barcode.HeaderText = "Generar";
            DGVProductos.Columns.Add(barcode);

            foto = new DataGridViewButtonColumn();
            foto.Width = 40;
            foto.Name = "Fotos";
            foto.HeaderText = "Imagen";
            DGVProductos.Columns.Add(foto);

            DGVProductos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DGVProductos.CellClick += new DataGridViewCellEventHandler(EditarProducto);
            DGVProductos.CellClick += new DataGridViewCellEventHandler(EditarStatus);
            DGVProductos.CellClick += new DataGridViewCellEventHandler(RecordView);
            DGVProductos.CellClick += new DataGridViewCellEventHandler(BarCodeMake);
            DGVProductos.CellClick += new DataGridViewCellEventHandler(PhotoStatus);

            DGVProductos.Columns["Path"].Visible = false;
            DGVProductos.Columns["Activo"].Visible = false;
        }

        private void CargarDatos()
        {
            cn.CargarInformacion(cs.Productos(FormPrincipal.userID), DGVProductos);
            number_of_rows = DGVProductos.RowCount;
        }

        private void DGVProductos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.DGVProductos.Columns[e.ColumnIndex].Name == "status" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                string valor = DGVProductos.Rows[e.RowIndex].Cells["Activo"].Value.ToString();

                DataGridViewButtonCell statusBoton = this.DGVProductos.Rows[e.RowIndex].Cells["status"] as DataGridViewButtonCell;
                //statusBoton.FlatStyle = FlatStyle.Flat;
                //statusBoton.Style.BackColor = Color.GhostWhite;

                if (valor == "1")
                {
                    image = new Icon(Properties.Settings.Default.rutaDirectorio + @"\icon\black16\check.ico");
                    e.Graphics.DrawIcon(image, e.CellBounds.Left + 18, e.CellBounds.Top + 3);
                    this.DGVProductos.Rows[e.RowIndex].Height = image.Height + 8;
                    this.DGVProductos.Columns[e.ColumnIndex].Width = image.Width + 36;
                }
                if (valor == "0")
                {
                    image = new Icon(Properties.Settings.Default.rutaDirectorio + @"\icon\black16\close.ico");
                    e.Graphics.DrawIcon(image, e.CellBounds.Left + 18, e.CellBounds.Top + 3);
                    this.DGVProductos.Rows[e.RowIndex].Height = image.Height + 8;
                    this.DGVProductos.Columns[e.ColumnIndex].Width = image.Width + 36;
                }
                e.Handled = true;
            }
            if (e.ColumnIndex >= 0 && this.DGVProductos.Columns[e.ColumnIndex].Name == "historial" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell historialBoton = this.DGVProductos.Rows[e.RowIndex].Cells["historial"] as DataGridViewButtonCell;
                //historialBoton.FlatStyle = FlatStyle.Flat;
                //historialBoton.Style.BackColor = Color.GhostWhite;

                image = new Icon(Properties.Settings.Default.rutaDirectorio + @"\icon\black16\line-chart.ico");
                e.Graphics.DrawIcon(image, e.CellBounds.Left + 18, e.CellBounds.Top + 3);
                this.DGVProductos.Rows[e.RowIndex].Height = image.Height + 8;
                this.DGVProductos.Columns[e.ColumnIndex].Width = image.Width + 36;
                
                e.Handled = true;
            }
            if (e.ColumnIndex >= 0 && this.DGVProductos.Columns[e.ColumnIndex].Name == "CodigoBarras" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell codigoBarrasBoton = this.DGVProductos.Rows[e.RowIndex].Cells["CodigoBarras"] as DataGridViewButtonCell;
                //codigoBarrasBoton.FlatStyle = FlatStyle.Flat;
                //codigoBarrasBoton.Style.BackColor = Color.GhostWhite;

                image = new Icon(Properties.Settings.Default.rutaDirectorio + @"\icon\black16\barcode.ico");
                e.Graphics.DrawIcon(image, e.CellBounds.Left + 18, e.CellBounds.Top + 3);
                this.DGVProductos.Rows[e.RowIndex].Height = image.Height + 8;
                this.DGVProductos.Columns[e.ColumnIndex].Width = image.Width + 36;

                e.Handled = true;
            }
            if (e.ColumnIndex >= 0 && this.DGVProductos.Columns[e.ColumnIndex].Name == "Fotos" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                string valor = DGVProductos.Rows[e.RowIndex].Cells["Path"].Value.ToString();

                DataGridViewButtonCell photoBoton = this.DGVProductos.Rows[e.RowIndex].Cells["Fotos"] as DataGridViewButtonCell;
                //photoBoton.FlatStyle = FlatStyle.Flat;
                //photoBoton.Style.BackColor = Color.GhostWhite;

                if (valor == "")
                {
                    image = new Icon(Properties.Settings.Default.rutaDirectorio + @"\icon\black16\file-o.ico");
                    e.Graphics.DrawIcon(image, e.CellBounds.Left + 18, e.CellBounds.Top+3);
                    this.DGVProductos.Rows[e.RowIndex].Height = image.Height + 8;
                    this.DGVProductos.Columns[e.ColumnIndex].Width = image.Width + 36;
                }
                if (valor != "")
                {
                    image = new Icon(Properties.Settings.Default.rutaDirectorio + @"\icon\black16\file-picture-o.ico");
                    e.Graphics.DrawIcon(image, e.CellBounds.Left + 18, e.CellBounds.Top + 3);
                    this.DGVProductos.Rows[e.RowIndex].Height = image.Height + 8;
                    this.DGVProductos.Columns[e.ColumnIndex].Width = image.Width + 36;
                }
                e.Handled = true;
            }
        }

        // metodo para cargar los productos Activos
        public void cargarProductosActivos()
        {
            string consulta = $"SELECT P.Nombre, P.Stock, P.Precio, P.Categoria, P.ClaveInterna AS 'Clave Interna', P.CodigoBarras AS 'Código de Barras', P.Status AS 'Activo', P.ProdImage AS 'Path' FROM Productos P INNER JOIN Usuarios U ON P.IDUsuario = U.ID WHERE U.ID = '{FormPrincipal.userID}' AND P.Status = '1'";
            dtConsulta = cn.CargarDatos(buscar);                    // acutualizamos los datos
            DGVProductos.DataSource = dtConsulta;
        }

        // metodo para cargar los productos No Activos
        public void cargarProductosNoActivos()
        {
            string consulta = $"SELECT P.Nombre, P.Stock, P.Precio, P.Categoria, P.ClaveInterna AS 'Clave Interna', P.CodigoBarras AS 'Código de Barras', P.Status AS 'Activo', P.ProdImage AS 'Path' FROM Productos P INNER JOIN Usuarios U ON P.IDUsuario = U.ID WHERE U.ID = '{FormPrincipal.userID}' AND P.Status = '0'";
            dtConsulta = cn.CargarDatos(buscar);                    // acutualizamos los datos
            DGVProductos.DataSource = dtConsulta;
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (origenDeLosDatos == 0)
            {
                FormAgregar.DatosSource = 1;
            }
            if (origenDeLosDatos == 2)
            {
                FormAgregar.DatosSource = 2;
            }

            FormAgregar.FormClosed += delegate
            {
                CargarDatos();
            };

            if (FormAgregar.Text == "")
            {
                FormAgregar = new AgregarEditarProducto("Agregar Producto");
            }

            if (!FormAgregar.Visible)
            {
                
                if (seleccionadoDato == 0)
                {
                    FormAgregar.ProdNombre = "";
                    FormAgregar.ShowDialog();
                }
                else if (seleccionadoDato == 1)
                {
                    seleccionadoDato = 0;
                    FormAgregar.ProdNombre = Nombre;
                    FormAgregar.ProdStock = Stock;
                    FormAgregar.ProdPrecio = Precio;
                    FormAgregar.ProdCategoria = ProductoCategoria;
                    FormAgregar.ProdClaveInterna = ClaveInterna;
                    FormAgregar.ProdCodBarras = CodigoBarras;
                    FormAgregar.ShowDialog();
                }
            }
            else
            {
                if (seleccionadoDato == 0)
                {
                    FormAgregar.ProdNombre = "";
                    FormAgregar.ShowDialog();
                }
                else if (seleccionadoDato == 1)
                {
                    seleccionadoDato = 0;
                    FormAgregar.ProdNombre = Nombre;
                    FormAgregar.ProdStock = Stock;
                    FormAgregar.ProdPrecio = Precio;
                    FormAgregar.ProdCategoria = ProductoCategoria;
                    FormAgregar.ProdClaveInterna = ClaveInterna;
                    FormAgregar.ProdCodBarras = CodigoBarras;
                    FormAgregar.ShowDialog();
                }
            }
            origenDeLosDatos = 0;
        }

        private void EditarProducto(object sender, DataGridViewCellEventArgs e)
        {
            //Editar producto
            if (e.ColumnIndex == 1)
            {
                if (seleccionadoDato==0)
                {
                    seleccionadoDato = 1;
                    Nombre = DGVProductos.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                    Stock = DGVProductos.Rows[e.RowIndex].Cells["Stock"].Value.ToString();
                    Precio = DGVProductos.Rows[e.RowIndex].Cells["Precio"].Value.ToString();
                    ProductoCategoria = DGVProductos.Rows[e.RowIndex].Cells["Categoria"].Value.ToString();
                    ClaveInterna = DGVProductos.Rows[e.RowIndex].Cells["Clave Interna"].Value.ToString();
                    CodigoBarras = DGVProductos.Rows[e.RowIndex].Cells["Código de Barras"].Value.ToString();
                    origenDeLosDatos = 2;
                }
                btnAgregarProducto.PerformClick();
            }
        }

        private void ModificarStatusProducto()
        {
            DataRow row;
            // Preparamos el Query que haremos segun la fila seleccionada
            buscar = $"SELECT * FROM Productos WHERE Nombre = '{Nombre}' AND Precio = '{Precio}' AND Stock = '{Stock}' AND ClaveInterna = '{ClaveInterna}' AND CodigoBarras = '{CodigoBarras}' AND IDUsuario = '{id}'";
            dt = cn.CargarDatos(buscar);    // almacenamos el resultado de la Funcion CargarDatos que esta en la calse Consultas
            row = dt.Rows[0];
            Id_Prod_select = Convert.ToString(row["ID"]);       // almacenamos el Id del producto
            status = Convert.ToString(row["Status"]);           // almacenamos el status
            if (status == "0")                              // si el status es 0
            {
                // preparamos el Query 
                buscar = $"UPDATE Productos SET Status = '1' WHERE ID = '{Id_Prod_select}' AND IDUsuario = '{id}'";
                dtConsulta = cn.CargarDatos(buscar);                    // acutualizamos los datos
            }
            else if (status == "1")                         // si el status es 1
            {
                // preparamos el Query 
                buscar = $"UPDATE Productos SET Status = '0' WHERE ID = '{Id_Prod_select}' AND IDUsuario = '{id}'";
                dtConsulta = cn.CargarDatos(buscar);                    // acutualizamos los datos
            }
        }

        private void ModificarStatusProductoChkBox()
        {
            DataRow row;
            // Preparamos el Query que haremos segun la fila seleccionada
            buscar = $"SELECT * FROM Productos WHERE Nombre = '{Nombre}' AND Precio = '{Precio}' AND Stock = '{Stock}' AND ClaveInterna = '{ClaveInterna}' AND CodigoBarras = '{CodigoBarras}' AND IDUsuario = '{id}'";
            dt = cn.CargarDatos(buscar);    // almacenamos el resultado de la Funcion CargarDatos que esta en la calse Consultas
            row = dt.Rows[0];
            Id_Prod_select = Convert.ToString(row["ID"]);       // almacenamos el Id del producto
            status = Convert.ToString(row["Status"]);           // almacenamos el status
            if (status == "0")                              // si el status es 0
            {
                // preparamos el Query 
                buscar = $"UPDATE Productos SET Status = '1' WHERE ID = '{Id_Prod_select}' AND IDUsuario = '{id}'";
                dtConsulta = cn.CargarDatos(buscar);                    // acutualizamos los datos
                //cn.EjecutarConsulta(buscar);                              // acutualizamos los datos
            }
            else if (status == "1")                         // si el status es 1
            {
                // preparamos el Query 
                buscar = $"UPDATE Productos SET Status = '0' WHERE ID = '{Id_Prod_select}' AND IDUsuario = '{id}'";
                dtConsulta = cn.CargarDatos(buscar);                    // acutualizamos los datos
                //cn.EjecutarConsulta(buscar);                              // acutualizamos los datos
            }
        }

        private void ViewRecordProducto()
        {
            ProductoRecord.FormClosed += delegate
            {
                
            };
            if (!FormXML.Visible)
            {
                ProductoRecord.nombreProd = Nombre;
                ProductoRecord.stockProd = Stock;
                ProductoRecord.precioProd = Precio;
                ProductoRecord.claveInternaProd = ClaveInterna;
                ProductoRecord.codigoBarrasProd = CodigoBarras;
                ProductoRecord.idUsuarioProd = id;
                ProductoRecord.lblFolioCompra.Text = "";
                ProductoRecord.lblRFCProveedor.Text = "";
                ProductoRecord.lblNombreProveedor.Text = "";
                ProductoRecord.lblClaveProducto.Text = "";
                ProductoRecord.lblFechaCompletaCompra.Text = "";
                ProductoRecord.lblCantidadCompra.Text = "";
                ProductoRecord.lblValorUnitarioProducto.Text = "";
                ProductoRecord.lblDescuentoProducto.Text = "";
                ProductoRecord.lblPrecioCompra.Text = "";
                ProductoRecord.ShowDialog();
            }
            else
            {
                ProductoRecord.lblFolioCompra.Text = "";
                ProductoRecord.lblRFCProveedor.Text = "";
                ProductoRecord.lblNombreProveedor.Text = "";
                ProductoRecord.lblClaveProducto.Text = "";
                ProductoRecord.lblFechaCompletaCompra.Text = "";
                ProductoRecord.lblCantidadCompra.Text = "";
                ProductoRecord.lblValorUnitarioProducto.Text = "";
                ProductoRecord.lblDescuentoProducto.Text = "";
                ProductoRecord.lblPrecioCompra.Text = "";
                ProductoRecord.SeleccionarFila();
                ProductoRecord.BringToFront();
            }
            
        }

        private void EditarStatus(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                index = 0;
                
                DialogResult result = MessageBox.Show("Realmente desdea Modificar el estado?", "Advertencia", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    numfila = DGVProductos.CurrentRow.Index;
                    Nombre = DGVProductos[6, numfila].Value.ToString();             // Nombre Producto
                    Stock = DGVProductos[7, numfila].Value.ToString();              // Stock Producto
                    Precio = DGVProductos[8, numfila].Value.ToString();             // Precio Producto
                    ClaveInterna = DGVProductos[10, numfila].Value.ToString();       // ClaveInterna Producto
                    CodigoBarras = DGVProductos[11, numfila].Value.ToString();       // Codigo de Barras Producto
                    id = FormPrincipal.userID.ToString();
                    ModificarStatusProducto();
                }
                else if (result == DialogResult.No)
                {
                    dtConsulta = cn.CargarDatos(cs.StatusProductos(FormPrincipal.userID.ToString(), "1"));
                    DGVProductos.DataSource = dtConsulta;
                }
                else if (result == DialogResult.Cancel)
                {
                    //code for Cancel
                    cbMostrar.Text = "Todos";
                }
            }
        }

        private void RecordView(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                //MessageBox.Show("Proceso de construccion de Historial de compra","En Proceso de Construccion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                numfila = DGVProductos.CurrentRow.Index;
                Nombre = DGVProductos[6, numfila].Value.ToString();             // Nombre Producto
                Stock = DGVProductos[7, numfila].Value.ToString();              // Stock Producto
                Precio = DGVProductos[8, numfila].Value.ToString();             // Precio Producto
                ClaveInterna = DGVProductos[10, numfila].Value.ToString();       // ClaveInterna Producto
                CodigoBarras = DGVProductos[11, numfila].Value.ToString();       // Codigo de Barras Producto
                id = FormPrincipal.userID.ToString();
                ViewRecordProducto();
            }
        }

        private void BarCodeMake(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                string codiBarProd="";
                numfila = DGVProductos.CurrentRow.Index;
                //MessageBox.Show("Proceso de construccion de Codigo de Barras", "En Proceso de Construccion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                MakeBarCode.FormClosed += delegate
                {
                    
                };
                if (!MakeBarCode.Visible)
                {
                    MakeBarCode.NombreProd = DGVProductos[6, numfila].Value.ToString();
                    MakeBarCode.PrecioProd = DGVProductos[8, numfila].Value.ToString();
                    codiBarProd = DGVProductos[11, numfila].Value.ToString();
                    if (codiBarProd != "")
                    {
                        MakeBarCode.CodigoBarProd = codiBarProd;
                        MakeBarCode.ShowDialog();
                    }
                    else if (codiBarProd == "")
                    {
                        MessageBox.Show("No se puede generar el codigo de barras\nPuesto que no tiene codigo de barras asignado","Error de Generar Codigo de Barras", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MakeBarCode.NombreProd = DGVProductos[6, numfila].Value.ToString();
                    MakeBarCode.PrecioProd = DGVProductos[8, numfila].Value.ToString();
                    codiBarProd = DGVProductos[11, numfila].Value.ToString();
                    if (codiBarProd != "")
                    {
                        MakeBarCode.CodigoBarProd = codiBarProd;
                        MakeBarCode.BringToFront();
                    }
                    else if (codiBarProd == "")
                    {
                        MessageBox.Show("No se puede generar el codigo de barras\nPuesto que no tiene codigo de barras asignado", "Error de Generar Codigo de Barras", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void agregarFoto()
        {
            try
            {
                using (f = new OpenFileDialog())    // Abrirmos el OpenFileDialog para buscar y seleccionar la Imagen
                {
                    // le aplicamos un filtro para solo ver 
                    // imagenes de tipo *.jpg y *.png 
                    f.Filter = "Imagenes JPG (*.jpg)|*.jpg| Imagenes PNG (*.png)|*.png";
                    if (f.ShowDialog() == DialogResult.OK)      // si se selecciono correctamente un archivo en el OpenFileDialog
                    {
                        /************************************************
                        *   usamos el objeto File para almacenar las    *
                        *   propiedades de la imagen                    * 
                        ************************************************/
                        using (File = new FileStream(f.FileName, FileMode.Open, FileAccess.Read))
                        {
                            info = new FileInfo(f.FileName);                        // Obtenemos toda la Informacion de la Imagen
                            fileName = Path.GetFileName(f.FileName);                // Obtenemos el nombre de la imagen
                            oldDirectory = info.DirectoryName;                      // Obtenemos el directorio origen de la Imagen
                            File.Dispose();                                         // Liberamos el objeto File
                        }
                    }
                }
                if (!Directory.Exists(saveDirectoryImg))        // verificamos que si no existe el directorio
                {
                    Directory.CreateDirectory(saveDirectoryImg);        // lo crea para poder almacenar la imagen
                }
                if (f.CheckFileExists && f.FileName != "")      // si el archivo existe
                {
                    try     // Intentamos la actualizacion de la imagen en la base de datos
                    {
                        // Obtenemos el Nuevo nombre de la imagen
                        // con la que se va hacer la copia de la imagen
                        NvoFileName = fileName;
                        // hacemos la nueva cadena de consulta para hacer el UpDate
                        string insertarImagen = $"UPDATE Productos SET ProdImage = '{saveDirectoryImg + NvoFileName}' WHERE Nombre = '{Nombre}' AND Stock = '{Stock}' AND Precio = '{Precio}' AND ClaveInterna = '{ClaveInterna}' AND CodigoBarras = '{CodigoBarras}'";
                        cn.EjecutarConsulta(insertarImagen);    // hacemos que se ejecute la consulta
                        // realizamos la copia de la imagen origen hacia el nuevo destino
                        System.IO.File.Copy(oldDirectory + @"\" + fileName, saveDirectoryImg + NvoFileName, true);
                        CargarDatos();
                    }
                    catch (Exception ex)	// si no se puede hacer el proceso
                    {
                        // si no se borra el archivo muestra este mensaje
                        MessageBox.Show("Error al hacer el borrado No: " + ex);
                    }
                }
            }
            catch (Exception ex)	// si el nombre del archivo esta en blanco
            {
                // si no selecciona un archivo valido o ningun archivo muestra este mensaje
                MessageBox.Show("selecciona una Imagen", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void mostrarFoto()
        {
            VentanaMostrarFoto.FormClosed += delegate
            {
                CargarDatos();
            };
            if (!VentanaMostrarFoto.Visible)
            {
                VentanaMostrarFoto.NombreProd = Nombre;
                VentanaMostrarFoto.StockProd = Stock;
                VentanaMostrarFoto.PrecioProd = Precio;
                VentanaMostrarFoto.ClaveInterna = ClaveInterna;
                VentanaMostrarFoto.CodigoBarras = CodigoBarras;
                VentanaMostrarFoto.ShowDialog();
            }
            else
            {
                VentanaMostrarFoto.NombreProd = Nombre;
                VentanaMostrarFoto.StockProd = Stock;
                VentanaMostrarFoto.PrecioProd = Precio;
                VentanaMostrarFoto.ClaveInterna = ClaveInterna;
                VentanaMostrarFoto.CodigoBarras = CodigoBarras;
                VentanaMostrarFoto.BringToFront();
            }
        }

        public void PhotoStatus(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                numfila = DGVProductos.CurrentRow.Index;

                Nombre = DGVProductos[6, numfila].Value.ToString();             // Nombre Producto
                Stock = DGVProductos[7, numfila].Value.ToString();              // Stock Producto
                Precio = DGVProductos[8, numfila].Value.ToString();             // Precio Producto
                ClaveInterna = DGVProductos[10, numfila].Value.ToString();       // ClaveInterna Producto
                CodigoBarras = DGVProductos[11, numfila].Value.ToString();       // Codigo de Barras Producto

                string pathString;

                pathString = DGVProductos[13, numfila].Value.ToString();

                if (pathString != "")
                {
                    mostrarFoto(); 
                }
                else if (pathString == "")
                {
                    agregarFoto();
                }
            }
        }

        private void DGVProductos_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            //Boton editar producto
            if (e.ColumnIndex == 1 || e.ColumnIndex == 2 || e.ColumnIndex == 3 || e.ColumnIndex == 4 || e.ColumnIndex == 5)
            {
                DGVProductos.Cursor = Cursors.Hand;
            }
            else
            {
                DGVProductos.Cursor = Cursors.Default;
            }
        }

        private void btnAgregarXML_Click(object sender, EventArgs e)
        {
            FormXML.FormClosed += delegate 
            {
                CargarDatos();
            };
            if (!FormXML.Visible)
            {
                FormXML.OcultarPanelRegistro();
                FormXML.ShowDialog();
            }
            else
            {
                FormXML.BringToFront();
            }
        }
    }
}
