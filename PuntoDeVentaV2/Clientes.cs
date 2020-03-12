﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoDeVentaV2
{
    public partial class Clientes : Form
    {
        Conexion cn = new Conexion();
        Consultas cs = new Consultas();

        public Clientes()
        {
            InitializeComponent();
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            SQLiteConnection sql_con;
            SQLiteCommand sql_cmd;
            SQLiteDataReader dr;

            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.Hosting))
            {
                sql_con = new SQLiteConnection("Data source=//" + Properties.Settings.Default.Hosting + @"\BD\pudveDB.db; Version=3; New=False;Compress=True;");
            }
            else
            {
                sql_con = new SQLiteConnection("Data source=" + Properties.Settings.Default.rutaDirectorio + @"\PUDVE\BD\pudveDB.db; Version=3; New=False;Compress=True;");
            }
            
            sql_con.Open();
            sql_cmd = new SQLiteCommand($"SELECT * FROM Clientes WHERE IDUsuario = {FormPrincipal.userID} AND Status = 1", sql_con);
            dr = sql_cmd.ExecuteReader();

            DGVClientes.Rows.Clear();

            while (dr.Read())
            {
                int rowId = DGVClientes.Rows.Add();

                DataGridViewRow row = DGVClientes.Rows[rowId];

                var tipoClienteAux = Convert.ToInt16(dr.GetValue(dr.GetOrdinal("TipoCliente")).ToString());
                var tipoCliente = string.Empty;

                if (tipoClienteAux == 0) { tipoCliente = "N/A"; }
                if (tipoClienteAux == 1) { tipoCliente = "MAYORISTA"; }
                if (tipoClienteAux == 2) { tipoCliente = "DISTRIBUIDOR"; }
                if (tipoClienteAux == 3) { tipoCliente = "SOCIO MAYORITARIO"; }

                row.Cells["ID"].Value = dr.GetValue(dr.GetOrdinal("ID"));
                row.Cells["RFC"].Value = dr.GetValue(dr.GetOrdinal("RFC"));
                row.Cells["Cliente"].Value = dr.GetValue(dr.GetOrdinal("RazonSocial"));
                row.Cells["NombreComercial"].Value = dr.GetValue(dr.GetOrdinal("NombreComercial"));
                row.Cells["Tipo"].Value = tipoCliente;
                row.Cells["NoCliente"].Value = dr.GetValue(dr.GetOrdinal("NumeroCliente")).ToString();
                row.Cells["Fecha"].Value = Convert.ToDateTime(dr.GetValue(dr.GetOrdinal("FechaOperacion"))).ToString("yyyy-MM-dd HH:mm:ss");

                Image editar = Image.FromFile(Properties.Settings.Default.rutaDirectorio + @"\PUDVE\icon\black16\edit.png");
                Image eliminar = Image.FromFile(Properties.Settings.Default.rutaDirectorio + @"\PUDVE\icon\black16\remove.png");

                row.Cells["Editar"].Value = editar;
                row.Cells["Eliminar"].Value = eliminar;
            }

            DGVClientes.ClearSelection();

            dr.Close();
            sql_con.Close();
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            AgregarCliente cliente = new AgregarCliente();

            cliente.FormClosed += delegate
            {
                CargarDatos();
            };

            cliente.ShowDialog();
        }

        private void DGVClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int idCliente = Convert.ToInt32(DGVClientes.Rows[e.RowIndex].Cells["ID"].Value);

                //Editar cliente
                if (e.ColumnIndex == 7)
                {
                    AgregarCliente editar = new AgregarCliente(2, idCliente);

                    editar.FormClosed += delegate
                    {
                        CargarDatos();
                    };

                    editar.ShowDialog();
                }

                //Eliminar cliente
                if (e.ColumnIndex == 8)
                {
                    var respuesta = MessageBox.Show("¿Estás seguro de deshabilitar este cliente?", "Mensaje del sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (respuesta == DialogResult.Yes)
                    {
                        string[] datos = new string[] { idCliente.ToString(), FormPrincipal.userID.ToString() };

                        int resultado = cn.EjecutarConsulta(cs.GuardarCliente(datos, 2));

                        if (resultado > 0)
                        {
                            CargarDatos();
                        }
                    }
                }

                DGVClientes.ClearSelection();
            }
        }

        private void DGVClientes_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex >= 7)
                {
                    DGVClientes.Cursor = Cursors.Hand;
                }
            }
        }

        private void DGVClientes_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex >= 7)
                {
                    DGVClientes.Cursor = Cursors.Default;
                }
            }
        }

        private void btnTipoCliente_Click(object sender, EventArgs e)
        {
            using (var tipoCliente = new AgregarTipoCliente())
            {
                tipoCliente.ShowDialog();
            }
        }

        private void btnListaDescuentos_Click(object sender, EventArgs e)
        {
            using (var listado = new ListadoTipoClientes())
            {
                var respuesta = listado.ShowDialog();
            }
        }
    }
}
