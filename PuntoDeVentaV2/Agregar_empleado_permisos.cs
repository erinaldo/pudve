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
    public partial class Agregar_empleado_permisos : Form
    {

        Conexion cn = new Conexion();
        Consultas cs = new Consultas();
        MetodosBusquedas mb = new MetodosBusquedas();
        public static List<int> Anticipos = new List<int>();
        public static List<int> Configuracion = new List<int>();
        public static List<int> Facturas = new List<int>();
        public static List<int> Productos = new List<int>();
        public static List<int> Ventas = new List<int>();
        public static List<int> Caja = new List<int>();
        public static List<int> Empleados = new List<int>();
        public static List<int> Inventario = new List<int>();
        public static List<int> Proveedores = new List<int>();
        public static List<int> Clientes = new List<int>();
        public static List<int> Bascula = new List<int>();
        public static List<int> MisDatos = new List<int>();
        public static List<int> Reportes = new List<int>();
        private string[] datosUpdate;
        private string[] secciones;
        private string[] ListaSeccion;
        List<int> opciones = new List<int>();
        static public int IDPlantilla = 0;
        static public bool SeGuardo = false;
        private int id_empleado = 0;

        public string[] datos;
        static public int MiIDEmpleado;

        public Agregar_empleado_permisos(int id_emp)
        {
            InitializeComponent();

            id_empleado = id_emp;
            MiIDEmpleado = id_empleado;
        }

        private void cargar_datos(object sender, EventArgs e)
        {
            if (id_empleado > 0)
            {
                var datos_e = mb.obtener_permisos_empleado(id_empleado, FormPrincipal.userID);
                cargar_checkbox_permisos(datos_e);
            }
            else
            {
                if (!IDPlantilla.Equals(0))
                {
                    CargarPermisosPlantilla();
                }
                else
                {
                    cargarCheckboxNvoEmpleado();
                }

            }
            CargarPlantillas();
        }

        private void CargarPlantillas()
        {
            ComboHabilittados.SelectedIndex = 0;
            DGVPlantillas.Rows.Clear();
            DataTable DTPlanttillas = cn.CargarDatos($"SELECT ID,Nombre FROM plantillapermisos WHERE IDUsuario = {FormPrincipal.userID} AND Estatus = 1");
            var path = Properties.Settings.Default.rutaDirectorio + @"\PUDVE\icon\black16\reply.png";
            System.Drawing.Image deshabilitar = System.Drawing.Image.FromFile(Properties.Settings.Default.rutaDirectorio + @"\PUDVE\icon\black16\trash.png");
            Image agregar = Image.FromFile(path);
            foreach (DataRow item in DTPlanttillas.Rows)
            {
                var numeroDeRows = DGVPlantillas.Rows.Add();
                DataGridViewRow row = DGVPlantillas.Rows[numeroDeRows];

                // Columna IdProducto 
                string Nombre = item["Nombre"].ToString();
                string idProducto = item["ID"].ToString();
                row.Cells["ID"].Value = idProducto;
                row.Cells["Nombre"].Value = Nombre;
                row.Cells["Seleccionar"].Value = agregar;
                row.Cells["Eliminar"].Value = deshabilitar;
            }
        }

        private void CargarPermisosPlantilla()
        {
            var DTPlantillaPermisos = cn.CargarDatos($"SELECT Anticipo,Caja,clientes,configuracion,empleado,factura,inventario,misdatos,productos,proveedor,reportes,precio,ventas, bascula,ConsultaPrecio FROM plantillapermisos WHERE IDUsuario = {FormPrincipal.userID} AND ID = {IDPlantilla} AND Estatus = 1");
            if (!DTPlantillaPermisos.Rows.Count.Equals(0))
            {
                string PermisosJusntos = string.Empty;
                int contador = 0;
                foreach (var item in DTPlantillaPermisos.Rows)
                {
                    foreach (var itemxd in DTPlantillaPermisos.Columns)
                    {
                        PermisosJusntos += DTPlantillaPermisos.Rows[0][contador].ToString() + ",";
                        contador++;
                    }
                }
                string[] listapermisos = PermisosJusntos.Split(',');

                cbox_anticipos.Checked = Convert.ToBoolean(Convert.ToInt32(listapermisos[0]));
                cbox_caja.Checked = Convert.ToBoolean(Convert.ToInt32(listapermisos[1]));
                cbox_clientes.Checked = Convert.ToBoolean(Convert.ToInt32(listapermisos[2]));
                cbox_configuracion.Checked = Convert.ToBoolean(Convert.ToInt32(listapermisos[3]));
                cbox_empleados.Checked = Convert.ToBoolean(Convert.ToInt32(listapermisos[4]));
                cbox_facturas.Checked = Convert.ToBoolean(Convert.ToInt32(listapermisos[5]));
                cbox_inventario.Checked = Convert.ToBoolean(Convert.ToInt32(listapermisos[6]));
                cbox_misdatos.Checked = Convert.ToBoolean(Convert.ToInt32(listapermisos[7]));
                cbox_productos.Checked = Convert.ToBoolean(Convert.ToInt32(listapermisos[8]));
                cbox_proveedores.Checked = Convert.ToBoolean(Convert.ToInt32(listapermisos[9]));
                cbox_reportes.Checked = Convert.ToBoolean(Convert.ToInt32(listapermisos[10]));
                chkPrecio.Checked = Convert.ToBoolean(Convert.ToInt32(listapermisos[11]));
                cbox_ventas.Checked = Convert.ToBoolean(Convert.ToInt32(listapermisos[12]));
                cboBascula.Checked = Convert.ToBoolean(Convert.ToInt32(listapermisos[13]));
                cboxConsultaP.Checked = Convert.ToBoolean(Convert.ToInt32(listapermisos[14]));
            }
            CargarPlantillas();
        }

        private void cargarCheckboxNvoEmpleado()
        {
            cbox_anticipos.Checked = false;
            cbox_caja.Checked = false;
            cbox_clientes.Checked = false;
            cbox_configuracion.Checked = false;
            cbox_empleados.Checked = false;
            cbox_empresas.Checked = false;
            cbox_facturas.Checked = false;
            cbox_inventario.Checked = false;
            cbox_misdatos.Checked = false;
            cbox_productos.Checked = false;
            cbox_proveedores.Checked = false;
            cbox_reportes.Checked = false;
            cbox_ventas.Checked = false;
            cboBascula.Checked = false;
            chkPrecio.Checked = false;
            cboxConsultaP.Checked = false;
        }

        private void cargar_checkbox_permisos(string[] datos_e)
        {
            cbox_anticipos.Checked = Convert.ToBoolean(Convert.ToInt32(datos_e[0]));
            cbox_caja.Checked = Convert.ToBoolean(Convert.ToInt32(datos_e[1]));
            cbox_clientes.Checked = Convert.ToBoolean(Convert.ToInt32(datos_e[2]));
            cbox_configuracion.Checked = Convert.ToBoolean(Convert.ToInt32(datos_e[3]));
            cbox_empleados.Checked = Convert.ToBoolean(Convert.ToInt32(datos_e[4]));
            cbox_empresas.Checked = Convert.ToBoolean(Convert.ToInt32(datos_e[5]));
            cbox_facturas.Checked = Convert.ToBoolean(Convert.ToInt32(datos_e[6]));
            cbox_inventario.Checked = Convert.ToBoolean(Convert.ToInt32(datos_e[7]));
            cbox_misdatos.Checked = Convert.ToBoolean(Convert.ToInt32(datos_e[8]));
            cbox_productos.Checked = Convert.ToBoolean(Convert.ToInt32(datos_e[9]));
            cbox_proveedores.Checked = Convert.ToBoolean(Convert.ToInt32(datos_e[10]));
            cbox_reportes.Checked = Convert.ToBoolean(Convert.ToInt32(datos_e[11]));
            cbox_ventas.Checked = Convert.ToBoolean(Convert.ToInt32(datos_e[13]));
            cboBascula.Checked = Convert.ToBoolean(Convert.ToInt32(datos_e[14]));
            cboxConsultaP.Checked = Convert.ToBoolean(Convert.ToInt32(datos_e[18]));

            var permisoPrecio = cn.CargarDatos($"SELECT COUNT(Precio) AS Estado FROM empleadospermisos WHERE IDEmpleado = '{id_empleado}' AND IDUsuario = '{FormPrincipal.userID}' AND Precio = 1");
            var DRPermisoPrecio = permisoPrecio.Rows[0]["Estado"].ToString();
            if (!DRPermisoPrecio.Equals("0"))
            {
                chkPrecio.Checked = true;
            }
            else
            {
                chkPrecio.Checked = false;
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            string chkPermisoPrecio = Convert.ToString(Convert.ToInt32(chkPrecio.Checked));
            string anticipo = Convert.ToString(Convert.ToInt32(cbox_anticipos.Checked));
            string caja = Convert.ToString(Convert.ToInt32(cbox_caja.Checked));
            string client = Convert.ToString(Convert.ToInt32(cbox_clientes.Checked));
            string config = Convert.ToString(Convert.ToInt32(cbox_configuracion.Checked));
            string empleado = Convert.ToString(Convert.ToInt32(cbox_empleados.Checked));
            string empresa = Convert.ToString(Convert.ToInt32(cbox_empresas.Checked));
            string factura = Convert.ToString(Convert.ToInt32(cbox_facturas.Checked));
            string inventario = Convert.ToString(Convert.ToInt32(cbox_inventario.Checked));
            string mdatos = Convert.ToString(Convert.ToInt32(cbox_misdatos.Checked));
            string producto = Convert.ToString(Convert.ToInt32(cbox_productos.Checked));
            string proveedor = Convert.ToString(Convert.ToInt32(cbox_proveedores.Checked));
            string reporte = Convert.ToString(Convert.ToInt32(cbox_reportes.Checked));
            string venta = Convert.ToString(Convert.ToInt32(cbox_ventas.Checked));
            string bascula = Convert.ToString(Convert.ToInt32(cboBascula.Checked));
            string ConsultaPrecio = Convert.ToString(Convert.ToInt32(cboxConsultaP.Checked));

            datos = new string[]
            {
                FormPrincipal.userID.ToString(), id_empleado.ToString(), anticipo, caja, client, config, empleado, empresa, factura, inventario, mdatos, producto, proveedor, reporte, venta, bascula, ConsultaPrecio
            };

            Agregar_empleado.datosPermisosSeleccionados = datos;

            if (id_empleado > 0)
            {
                cn.EjecutarConsulta($"UPDATE empleadospermisos SET Precio = '{chkPermisoPrecio}' WHERE IDEmpleado = '{datos[1]}' AND IDUsuario = '{datos[0]}'");

                int r = cn.EjecutarConsulta(cs.guardar_editar_empleado(datos, 2));
                ActualizarSubPermisos();
                if (r > 0)
                {
                    IDPlantilla = 0;
                    this.Close();
                }
            }
            else
            {
                IDPlantilla = 0;
                this.Close();
            }
        }

        private void ActualizarSubPermisos()
        {
            datosUpdate = new string[] { "editarTicket", "EnvioCorreo", "confiGeneral", "porcentajeGanancia", "tipoMoneda", "RespaldarInfo", "MensajeVentas", "MensajeInventario" };
            secciones = new string[] {
                "Caja", "Ventas", "Inventario", "Anticipos",
                "MisDatos", "Facturas", "Configuracion", "Reportes",
                "Clientes", "Proveedores", "Empleados", "Productos", "Bascula" ,"Permisos"
            };
            ListaSeccion = new string[] {
                "Anticipos", "Configuracion","Facturas","Productos","Ventas","Caja","Empleados","Inventario","Proveedores","Clientes","Bascula","MisDatos","Reportes"
            };
            if (!IDPlantilla.Equals(0))
            {
                if (Anticipos.Count.Equals(0))
                {
                    var DTColumnas = cn.CargarDatos($"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'subpermisos' AND COLUMN_NAME LIKE 'ANT_%'");

                    var rows = DTColumnas.AsEnumerable()
                                 .Select(r => string.Format("{0}", string.Join(",", r.ItemArray)));

                    var columnas = string.Format("{0}", string.Join(",", rows.ToArray()));

                    var DTPermisos = cn.CargarDatos($"SELECT {columnas} FROM subpermisos WHERE IDPlantilla = {Agregar_empleado_permisos.IDPlantilla}");

                    var rows2 = DTPermisos.AsEnumerable()
                                .Select(r => string.Format("{0}", string.Join(",", r.ItemArray)));

                    var permisos = string.Format("{0}", string.Join(",", rows2.ToArray()));

                    var datos = permisos.Split(',');
                    foreach (var item in datos)
                    {
                        Anticipos.Add(Convert.ToInt32(item));
                    }
                }

                if (Caja.Count.Equals(0))
                {
                    var DTColumnas = cn.CargarDatos($"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'subpermisos' AND COLUMN_NAME LIKE 'Caja_%'");
                    var rows = DTColumnas.AsEnumerable()
                                 .Select(r => string.Format("{0}", string.Join(",", r.ItemArray)));

                    var columnas = string.Format("{0}", string.Join(",", rows.ToArray()));

                    var DTPermisos = cn.CargarDatos($"SELECT {columnas} FROM subpermisos WHERE IDPlantilla = {Agregar_empleado_permisos.IDPlantilla}");

                    var rows2 = DTPermisos.AsEnumerable()
                                .Select(r => string.Format("{0}", string.Join(",", r.ItemArray)));

                    var permisos = string.Format("{0}", string.Join(",", rows2.ToArray()));

                    var datos = permisos.Split(',');
                    foreach (var item in datos)
                    {
                        Caja.Add(Convert.ToInt32(item));
                    }

                }
                if (Ventas.Count.Equals(0))
                {
                    var DTColumnas = cn.CargarDatos($"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'subpermisos' AND COLUMN_NAME LIKE 'VEN_%'");
                    var rows = DTColumnas.AsEnumerable()
                                 .Select(r => string.Format("{0}", string.Join(",", r.ItemArray)));

                    var columnas = string.Format("{0}", string.Join(",", rows.ToArray()));

                    var DTPermisos = cn.CargarDatos($"SELECT {columnas} FROM subpermisos WHERE IDPlantilla = {Agregar_empleado_permisos.IDPlantilla}");

                    var rows2 = DTPermisos.AsEnumerable()
                                .Select(r => string.Format("{0}", string.Join(",", r.ItemArray)));

                    var permisos = string.Format("{0}", string.Join(",", rows2.ToArray()));

                    var datos = permisos.Split(',');
                    foreach (var item in datos)
                    {
                        Ventas.Add(Convert.ToInt32(item));
                    }
                }
                if (Inventario.Count.Equals(0))
                {
                    var DTColumnas = cn.CargarDatos($"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'subpermisos' AND COLUMN_NAME LIKE 'INV_%'");
                    var rows = DTColumnas.AsEnumerable()
                                 .Select(r => string.Format("{0}", string.Join(",", r.ItemArray)));

                    var columnas = string.Format("{0}", string.Join(",", rows.ToArray()));

                    var DTPermisos = cn.CargarDatos($"SELECT {columnas} FROM subpermisos WHERE IDPlantilla = {Agregar_empleado_permisos.IDPlantilla}");

                    var rows2 = DTPermisos.AsEnumerable()
                                .Select(r => string.Format("{0}", string.Join(",", r.ItemArray)));

                    var permisos = string.Format("{0}", string.Join(",", rows2.ToArray()));

                    var datos = permisos.Split(',');
                    foreach (var item in datos)
                    {
                        Inventario.Add(Convert.ToInt32(item));
                    }
                }
                if (MisDatos.Count.Equals(0))
                {
                    var DTColumnas = cn.CargarDatos($"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'subpermisos' AND COLUMN_NAME LIKE 'MISD_%'");
                    var rows = DTColumnas.AsEnumerable()
                                 .Select(r => string.Format("{0}", string.Join(",", r.ItemArray)));

                    var columnas = string.Format("{0}", string.Join(",", rows.ToArray()));

                    var DTPermisos = cn.CargarDatos($"SELECT {columnas} FROM subpermisos WHERE IDPlantilla = {Agregar_empleado_permisos.IDPlantilla}");

                    var rows2 = DTPermisos.AsEnumerable()
                                .Select(r => string.Format("{0}", string.Join(",", r.ItemArray)));

                    var permisos = string.Format("{0}", string.Join(",", rows2.ToArray()));

                    var datos = permisos.Split(',');
                    foreach (var item in datos)
                    {
                        MisDatos.Add(Convert.ToInt32(item));
                    }
                }

                if (Facturas.Count.Equals(0))
                {
                    var DTColumnas = cn.CargarDatos($"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'subpermisos' AND COLUMN_NAME LIKE 'FAC_%'");
                    var rows = DTColumnas.AsEnumerable()
                                 .Select(r => string.Format("{0}", string.Join(",", r.ItemArray)));

                    var columnas = string.Format("{0}", string.Join(",", rows.ToArray()));

                    var DTPermisos = cn.CargarDatos($"SELECT {columnas} FROM subpermisos WHERE IDPlantilla = {Agregar_empleado_permisos.IDPlantilla}");

                    var rows2 = DTPermisos.AsEnumerable()
                                .Select(r => string.Format("{0}", string.Join(",", r.ItemArray)));

                    var permisos = string.Format("{0}", string.Join(",", rows2.ToArray()));
                    var datos = permisos.Split(',');
                    foreach (var item in datos)
                    {
                        Facturas.Add(Convert.ToInt32(item));
                    }
                }

                if (Configuracion.Count.Equals(0))
                {
                    var DTColumnas = cn.CargarDatos($"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'subpermisos' AND COLUMN_NAME LIKE 'CONF_%'");
                    var rows = DTColumnas.AsEnumerable()
                                 .Select(r => string.Format("{0}", string.Join(",", r.ItemArray)));

                    var columnas = string.Format("{0}", string.Join(",", rows.ToArray()));

                    var DTPermisos = cn.CargarDatos($"SELECT {columnas} FROM subpermisos WHERE IDPlantilla = {Agregar_empleado_permisos.IDPlantilla}");

                    var rows2 = DTPermisos.AsEnumerable()
                                .Select(r => string.Format("{0}", string.Join(",", r.ItemArray)));

                    var permisos = string.Format("{0}", string.Join(",", rows2.ToArray()));

                    var datos = permisos.Split(',');
                    foreach (var item in datos)
                    {
                        Configuracion.Add(Convert.ToInt32(item));
                    }
                }

                if (Reportes.Count.Equals(0))
                {

                    var DTColumnas = cn.CargarDatos($"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'subpermisos' AND COLUMN_NAME LIKE 'REP_%'");
                    var rows = DTColumnas.AsEnumerable()
                                 .Select(r => string.Format("{0}", string.Join(",", r.ItemArray)));

                    var columnas = string.Format("{0}", string.Join(",", rows.ToArray()));

                    var DTPermisos = cn.CargarDatos($"SELECT {columnas} FROM subpermisos WHERE IDPlantilla = {Agregar_empleado_permisos.IDPlantilla}");

                    var rows2 = DTPermisos.AsEnumerable()
                                .Select(r => string.Format("{0}", string.Join(",", r.ItemArray)));

                    var permisos = string.Format("{0}", string.Join(",", rows2.ToArray()));

                    var datos = permisos.Split(',');
                    foreach (var item in datos)
                    {
                        Reportes.Add(Convert.ToInt32(item));
                    }
                }

                if (Clientes.Count.Equals(0))
                {
                    var DTColumnas = cn.CargarDatos($"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'subpermisos' AND COLUMN_NAME LIKE 'CLI_%'");
                    var rows = DTColumnas.AsEnumerable()
                                 .Select(r => string.Format("{0}", string.Join(",", r.ItemArray)));

                    var columnas = string.Format("{0}", string.Join(",", rows.ToArray()));

                    var DTPermisos = cn.CargarDatos($"SELECT {columnas} FROM subpermisos WHERE IDPlantilla = {Agregar_empleado_permisos.IDPlantilla}");

                    var rows2 = DTPermisos.AsEnumerable()
                                .Select(r => string.Format("{0}", string.Join(",", r.ItemArray)));

                    var permisos = string.Format("{0}", string.Join(",", rows2.ToArray()));

                    var datos = permisos.Split(',');
                    foreach (var item in datos)
                    {
                        Clientes.Add(Convert.ToInt32(item));
                    }
                }

                if (Proveedores.Count.Equals(0))
                {
                    var DTColumnas = cn.CargarDatos($"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'subpermisos' AND COLUMN_NAME LIKE 'PROV_%'");
                    var rows = DTColumnas.AsEnumerable()
                                 .Select(r => string.Format("{0}", string.Join(",", r.ItemArray)));

                    var columnas = string.Format("{0}", string.Join(",", rows.ToArray()));

                    var DTPermisos = cn.CargarDatos($"SELECT {columnas} FROM subpermisos WHERE IDPlantilla = {Agregar_empleado_permisos.IDPlantilla}");

                    var rows2 = DTPermisos.AsEnumerable()
                                .Select(r => string.Format("{0}", string.Join(",", r.ItemArray)));

                    var permisos = string.Format("{0}", string.Join(",", rows2.ToArray()));

                    var datos = permisos.Split(',');
                    foreach (var item in datos)
                    {
                        Proveedores.Add(Convert.ToInt32(item));
                    }
                }

                if (Empleados.Count.Equals(0))
                {
                    var DTColumnas = cn.CargarDatos($"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'subpermisos' AND COLUMN_NAME LIKE 'EMP_%'");
                    var rows = DTColumnas.AsEnumerable()
                                 .Select(r => string.Format("{0}", string.Join(",", r.ItemArray)));

                    var columnas = string.Format("{0}", string.Join(",", rows.ToArray()));

                    var DTPermisos = cn.CargarDatos($"SELECT {columnas} FROM subpermisos WHERE IDPlantilla = {Agregar_empleado_permisos.IDPlantilla}");

                    var rows2 = DTPermisos.AsEnumerable()
                                .Select(r => string.Format("{0}", string.Join(",", r.ItemArray)));

                    var permisos = string.Format("{0}", string.Join(",", rows2.ToArray()));

                    var datos = permisos.Split(',');

                    foreach (var item in datos)
                    {
                        Empleados.Add(Convert.ToInt32(item));
                    }
                }

                if (Productos.Count.Equals(0))
                {
                    var DTColumnas = cn.CargarDatos($"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'subpermisos' AND COLUMN_NAME LIKE 'PROD_%'");
                    var rows = DTColumnas.AsEnumerable()
                                 .Select(r => string.Format("{0}", string.Join(",", r.ItemArray)));

                    var columnas = string.Format("{0}", string.Join(",", rows.ToArray()));

                    var DTPermisos = cn.CargarDatos($"SELECT {columnas} FROM subpermisos WHERE IDPlantilla = {Agregar_empleado_permisos.IDPlantilla}");

                    var rows2 = DTPermisos.AsEnumerable()
                                .Select(r => string.Format("{0}", string.Join(",", r.ItemArray)));

                    var permisos = string.Format("{0}", string.Join(",", rows2.ToArray()));

                    var datos = permisos.Split(',');
                    foreach (var item in datos)
                    {
                        Productos.Add(Convert.ToInt32(item));
                    }
                }

                if (Bascula.Count.Equals(0))
                {
                    var DTColumnas = cn.CargarDatos($"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'subpermisos' AND COLUMN_NAME LIKE 'BAS_%'");
                    var rows = DTColumnas.AsEnumerable()
                                 .Select(r => string.Format("{0}", string.Join(",", r.ItemArray)));

                    var columnas = string.Format("{0}", string.Join(",", rows.ToArray()));

                    var DTPermisos = cn.CargarDatos($"SELECT {columnas} FROM subpermisos WHERE IDPlantilla = {Agregar_empleado_permisos.IDPlantilla}");

                    var rows2 = DTPermisos.AsEnumerable()
                                .Select(r => string.Format("{0}", string.Join(",", r.ItemArray)));

                    var permisos = string.Format("{0}", string.Join(",", rows2.ToArray()));

                    var datos = permisos.Split(',');
                    foreach (var item in datos)
                    {
                        Bascula.Add(Convert.ToInt32(item));
                    }
                }
                int contador = 0;
                foreach (var seccion in ListaSeccion)
                {
                    foreach (var apartado in secciones)
                    {
                        if (seccion.Equals("Configuracion"))
                        {
                            TomarValoresLista(seccion);

                            foreach (var opcion in opciones)
                            {
                                string dato = datosUpdate[contador].ToString();
                                cn.EjecutarConsulta($"UPDATE EmpleadosPermisos SET {dato} = {opcion} WHERE IDEmpleado = {id_empleado} AND IDUsuario = {FormPrincipal.userID} ");
                                contador++;
                            }
                            contador = 0;
                        }
                        if (seccion.Equals(apartado) && !seccion.Equals("Configuracion"))
                        {
                            int numero = 1;
                            TomarValoresLista(seccion);
                            foreach (var opcion in opciones)
                            {
                                cn.EjecutarConsulta($"UPDATE EmpleadosPermisos SET Opcion{numero} = {opcion} WHERE IDEmpleado = {id_empleado} AND IDUsuario = {FormPrincipal.userID} AND Seccion = '{apartado}'");

                                numero++;
                            }
                        }
                        if (seccion.Equals("Ventas"))
                        {
                            TomarValoresLista(seccion);
                            cn.EjecutarConsulta($"UPDATE empleadospermisos SET PermisoVentaClienteDescuento = {opciones[20]} WHERE IDEmpleado = {id_empleado} AND IDUsuario = {FormPrincipal.userID} AND Seccion = '{apartado}'");
                        }
                    }
                }
            }
        }

        private object TomarValoresLista(string seccion)
        {
            if (seccion.Equals("Anticipos"))
            {
                opciones = Anticipos;
            }
            if (seccion.Equals("Configuracion"))
            {
                opciones = Configuracion;
            }
            if (seccion.Equals("Facturas"))
            {
                opciones = Facturas;
            }
            if (seccion.Equals("Productos"))
            {
                opciones = Productos;
            }
            if (seccion.Equals("Ventas"))
            {
                opciones = Ventas;
            }
            if (seccion.Equals("Caja"))
            {
                opciones = Caja;
            }
            if (seccion.Equals("Empleados"))
            {
                opciones = Empleados;
            }
            if (seccion.Equals("Inventario"))
            {
                opciones = Inventario;
            }
            if (seccion.Equals("Proveedores"))
            {
                opciones = Proveedores;
            }
            if (seccion.Equals("Clientes"))
            {
                opciones = Clientes;
            }
            if (seccion.Equals("Bascula"))
            {
                opciones = Bascula;
            }
            if (seccion.Equals("MisDatos"))
            {
                opciones = MisDatos;
            }
            if (seccion.Equals("Reportes"))
            {
                opciones = Reportes;
            }
            return opciones.ToList<int>();
        }

        private void btnCaja_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<SeccionPermisos>().Count() == 1)
            {
                Application.OpenForms.OfType<SeccionPermisos>().First().BringToFront();
            }
            else
            {
                var permisos = new SeccionPermisos("Caja", id_empleado);

                permisos.Show();
            }
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<SeccionPermisos>().Count() == 1)
            {
                Application.OpenForms.OfType<SeccionPermisos>().First().BringToFront();
            }
            else
            {
                var permisos = new SeccionPermisos("Ventas", id_empleado);

                permisos.Show();
            }
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<SeccionPermisos>().Count() == 1)
            {
                Application.OpenForms.OfType<SeccionPermisos>().First().BringToFront();
            }
            else
            {
                var permisos = new SeccionPermisos("Inventario", id_empleado);

                permisos.Show();
            }
        }

        private void btnAnticipos_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<SeccionPermisos>().Count() == 1)
            {
                Application.OpenForms.OfType<SeccionPermisos>().First().BringToFront();
            }
            else
            {
                var permisos = new SeccionPermisos("Anticipos", id_empleado);

                permisos.Show();
            }
        }

        private void btnMisDatos_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<SeccionPermisos>().Count() == 1)
            {
                Application.OpenForms.OfType<SeccionPermisos>().First().BringToFront();
            }
            else
            {
                var permisos = new SeccionPermisos("MisDatos", id_empleado);

                permisos.Show();
            }
        }

        private void btnFacturas_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<SeccionPermisos>().Count() == 1)
            {
                Application.OpenForms.OfType<SeccionPermisos>().First().BringToFront();
            }
            else
            {
                var permisos = new SeccionPermisos("Facturas", id_empleado);

                permisos.Show();
            }
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<SeccionPermisos>().Count() == 1)
            {
                Application.OpenForms.OfType<SeccionPermisos>().First().BringToFront();
            }
            else
            {
                var permisos = new SeccionPermisos("Configuracion", id_empleado);

                permisos.Show();
            }
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<SeccionPermisos>().Count() == 1)
            {
                Application.OpenForms.OfType<SeccionPermisos>().First().BringToFront();
            }
            else
            {
                var permisos = new SeccionPermisos("Reportes", id_empleado);

                permisos.Show();
            }
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<SeccionPermisos>().Count() == 1)
            {
                Application.OpenForms.OfType<SeccionPermisos>().First().BringToFront();
            }
            else
            {
                var permisos = new SeccionPermisos("Clientes", id_empleado);

                permisos.Show();
            }
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<SeccionPermisos>().Count() == 1)
            {
                Application.OpenForms.OfType<SeccionPermisos>().First().BringToFront();
            }
            else
            {
                var permisos = new SeccionPermisos("Proveedores", id_empleado);

                permisos.Show();
            }
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<SeccionPermisos>().Count() == 1)
            {
                Application.OpenForms.OfType<SeccionPermisos>().First().BringToFront();
            }
            else
            {
                var permisos = new SeccionPermisos("Empleados", id_empleado);

                permisos.Show();
            }
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<SeccionPermisos>().Count() == 1)
            {
                Application.OpenForms.OfType<SeccionPermisos>().First().BringToFront();
            }
            else
            {
                var permisos = new SeccionPermisos("Productos", id_empleado);

                permisos.Show();
            }
        }

        private void chkMarcarDesmarcar_CheckedChanged(object sender, EventArgs e)
        {
            var CheckBoxList = this.Controls.OfType<CheckBox>().ToList();

            foreach (CheckBox objetos in CheckBoxList)
            {
                if (objetos is CheckBox)
                {
                    CheckBox chkObjetos = (CheckBox)objetos;
                    if ("Marcar todo" != chkObjetos.Text)
                    {
                        bool estado = chkObjetos.Checked;

                        if (chkMarcarDesmarcar.Checked == false)
                        {
                            chkObjetos.Checked = false;
                        }
                        else if (chkMarcarDesmarcar.Checked == true)
                        {
                            chkObjetos.Checked = true;
                        }
                    }
                }
                if (chkMarcarDesmarcar.Checked == true)
                {
                    chkMarcarDesmarcar.Text = "Desmarcar todo";
                }
                else if (chkMarcarDesmarcar.Checked == false)
                {
                    chkMarcarDesmarcar.Text = "Marcar todo";
                }
            }
        }

        private void btnBascula_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<SeccionPermisos>().Count() == 1)
            {
                Application.OpenForms.OfType<SeccionPermisos>().First().BringToFront();
            }
            else
            {
                var permisos = new SeccionPermisos("Bascula", id_empleado);

                permisos.Show();
            }
        }

        private void Agregar_empleado_permisos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void chkPrecio_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string anticipo = Convert.ToString(Convert.ToInt32(cbox_anticipos.Checked));
            string caja = Convert.ToString(Convert.ToInt32(cbox_caja.Checked));
            string client = Convert.ToString(Convert.ToInt32(cbox_clientes.Checked));
            string config = Convert.ToString(Convert.ToInt32(cbox_configuracion.Checked));
            string empleado = Convert.ToString(Convert.ToInt32(cbox_empleados.Checked));
            string factura = Convert.ToString(Convert.ToInt32(cbox_facturas.Checked));
            string inventario = Convert.ToString(Convert.ToInt32(cbox_inventario.Checked));
            string mdatos = Convert.ToString(Convert.ToInt32(cbox_misdatos.Checked));
            string producto = Convert.ToString(Convert.ToInt32(cbox_productos.Checked));
            string proveedor = Convert.ToString(Convert.ToInt32(cbox_proveedores.Checked));
            string reporte = Convert.ToString(Convert.ToInt32(cbox_reportes.Checked));
            string chkPermisoPrecio = Convert.ToString(Convert.ToInt32(chkPrecio.Checked));
            string venta = Convert.ToString(Convert.ToInt32(cbox_ventas.Checked));
            string bascula = Convert.ToString(Convert.ToInt32(cboBascula.Checked));
            string ConsultaPrecio = Convert.ToString(Convert.ToInt32(cboxConsultaP.Checked));

            datos = new string[]
            {
                FormPrincipal.userID.ToString(),anticipo, caja, client, config, empleado,factura, inventario, mdatos, producto, proveedor, reporte,chkPermisoPrecio, venta, bascula, ConsultaPrecio
            };
            string[] Seleccionados;
            Seleccionados = new string[]
            {
                anticipo, caja, client, config, empleado, factura, inventario, mdatos, producto, proveedor, reporte, chkPermisoPrecio, venta, bascula, ConsultaPrecio
            };
            bool HaySeleccionados = false;
            foreach (var item in Seleccionados)
            {
                if (item.Equals("1"))
                {
                    HaySeleccionados = true;
                }
            }
            if (HaySeleccionados.Equals(true))
            {
                IngresarrNombrePlantilla plantilla = new IngresarrNombrePlantilla(datos);
                plantilla.ShowDialog();
                if (SeGuardo)
                {
                    using (var DTIDPlantilla = cn.CargarDatos("SELECT ID from plantillapermisos ORDER BY ID DESC LIMIT 1"))
                    {
                        Agregar_empleado.IDPlantilla = Convert.ToInt32(DTIDPlantilla.Rows[0]["ID"]);
                    }
                }
                CargarPermisosPlantilla();
                DGVPlantillas.Rows.Clear();
                CargarPlantillas();
            }
            else
            {
                MessageBox.Show("Seleecione almenos un permiso", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            IDPlantilla = 0;
        }

        private void DGVPlantillas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 2)
                {
                    IDPlantilla = Convert.ToInt32(DGVPlantillas.Rows[e.RowIndex].Cells[0].Value.ToString());
                    Agregar_empleado.IDPlantilla = IDPlantilla;
                    CargarPermisosPlantilla();
                }
                if (e.ColumnIndex == 3)
                {
                    IDPlantilla = Convert.ToInt32(DGVPlantillas.Rows[e.RowIndex].Cells[0].Value.ToString());
                    cn.EjecutarConsulta($"UPDATE  plantillapermisos SET Estatus = 0 WHERE ID = {IDPlantilla} AND IDUsuario = {FormPrincipal.userID}");
                    DGVPlantillas.Rows.Clear();
                    CargarPermisosPlantilla();
                }
            }
            
        }

        private void Agregar_empleado_permisos_FormClosing(object sender, FormClosingEventArgs e)
        {
            IDPlantilla = 0;
        }

        private void ComboHabilittados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboHabilittados.SelectedIndex.Equals(0))
            {
                DGVPlantillas.Rows.Clear();
                DGVPlantillas.Visible = true;
                dDGVDeshabilitados.Visible = false;
                CargarPermisosPlantilla();
            }
            else
            {
                dDGVDeshabilitados.Rows.Clear();
                DGVPlantillas.Visible = false;
                dDGVDeshabilitados.Visible = true;
                DataTable DTPlanttillas = cn.CargarDatos($"SELECT ID,Nombre FROM plantillapermisos WHERE IDUsuario = {FormPrincipal.userID} AND Estatus = 0");
                var path = Properties.Settings.Default.rutaDirectorio + @"\PUDVE\icon\black16\reply.png";
                System.Drawing.Image deshabilitar = System.Drawing.Image.FromFile(Properties.Settings.Default.rutaDirectorio + @"\PUDVE\icon\black16\trash.png");
                Image agregar = Image.FromFile(path);
                foreach (DataRow item in DTPlanttillas.Rows)
                {
                    var numeroDeRows = dDGVDeshabilitados.Rows.Add();
                    DataGridViewRow row = dDGVDeshabilitados.Rows[numeroDeRows];

                    // Columna IdProducto 
                    string Nombre = item["Nombre"].ToString();
                    string idProducto = item["ID"].ToString();
                    row.Cells["IDDeshabilitado"].Value = idProducto;
                    row.Cells["NombreDesha"].Value = Nombre;
                    row.Cells["ImagenDesha"].Value = agregar;
                }
            }
        }

        private void dDGVDeshabilitados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                IDPlantilla = Convert.ToInt32(dDGVDeshabilitados.Rows[e.RowIndex].Cells[0].Value.ToString());
                cn.EjecutarConsulta($"UPDATE  plantillapermisos SET Estatus = 1 WHERE ID = {IDPlantilla} AND IDUsuario = {FormPrincipal.userID}");
                dDGVDeshabilitados.Rows.Clear();
                CargarPermisosPlantilla();
            }
        }

        private void dDGVDeshabilitados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
