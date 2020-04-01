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
    public partial class ConceptosCaja : Form
    {
        Conexion cn = new Conexion();

        private string origen;

        public ConceptosCaja(string origen)
        {
            InitializeComponent();

            this.origen = origen;
        }

        private void ConceptosCaja_Load(object sender, EventArgs e)
        {
            CargarDatos();

            if (rbHabilitados.Checked)
            {
                DGVConceptos.Columns["Habilitar"].Visible = false;
            }
        }

        private void CargarDatos(int status = 1)
        {
            var servidor = Properties.Settings.Default.Hosting;

            SQLiteConnection sql_con;
            SQLiteCommand sql_cmd;
            SQLiteDataReader dr;

            if (!string.IsNullOrWhiteSpace(servidor))
            {
                sql_con = new SQLiteConnection("Data source=//" + Properties.Settings.Default.Hosting + @"\BD\pudveDB.db; Version=3; New=False;Compress=True;");
            }
            else
            {
                sql_con = new SQLiteConnection("Data source=" + Properties.Settings.Default.rutaDirectorio + @"\PUDVE\BD\pudveDB.db; Version=3; New=False;Compress=True;");
            }

            sql_con.Open();
            sql_cmd = new SQLiteCommand($"SELECT * FROM ConceptosDinamicos WHERE IDUsuario = {FormPrincipal.userID} AND Origen = '{origen}' AND Status = {status} ORDER BY FechaOperacion ASC", sql_con);
            dr = sql_cmd.ExecuteReader();

            DGVConceptos.Rows.Clear();

            while (dr.Read())
            {
                int rowId = DGVConceptos.Rows.Add();

                DataGridViewRow row = DGVConceptos.Rows[rowId];

                Image imgHabilitar = Image.FromFile(Properties.Settings.Default.rutaDirectorio + @"\PUDVE\icon\black16\level-up.png");
                Image imgDeshabilitar = Image.FromFile(Properties.Settings.Default.rutaDirectorio + @"\PUDVE\icon\black16\level-down.png");

                row.Cells["ID"].Value = dr.GetValue(dr.GetOrdinal("ID"));
                row.Cells["Concepto"].Value = dr.GetValue(dr.GetOrdinal("Concepto"));
                row.Cells["Fecha"].Value = Convert.ToDateTime(dr.GetValue(dr.GetOrdinal("FechaOperacion"))).ToString("yyyy-MM-dd HH:mm:ss");
                row.Cells["Habilitar"].Value = imgHabilitar;
                row.Cells["Deshabilitar"].Value = imgDeshabilitar;
            }

            dr.Close();
            sql_con.Close();

            DGVConceptos.ClearSelection();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var concepto = txtConcepto.Text.Trim();
            var fechaOperacion = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            if (string.IsNullOrWhiteSpace(concepto))
            {
                MessageBox.Show("Ingrese el nombre del concepto", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var consulta = "INSERT INTO ConceptosDinamicos (IDUsuario, Concepto, Origen, FechaOperacion)";
                consulta += $"VALUES ('{FormPrincipal.userID}', '{concepto}', '{origen}', '{fechaOperacion}')";

            var resultado = cn.EjecutarConsulta(consulta);

            if (resultado > 0)
            {
                txtConcepto.Text = string.Empty;
                txtConcepto.Focus();
                CargarDatos();
            }
        }

        private void ConceptosCaja_Shown(object sender, EventArgs e)
        {
            txtConcepto.Focus();
        }

        private void txtConcepto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnAgregar.PerformClick();
            }
        }

        private void DGVConceptos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var fila = DGVConceptos.CurrentCell.RowIndex;
                var id = Convert.ToInt32(DGVConceptos.Rows[fila].Cells["ID"].Value);

                // Habilitar
                if (e.ColumnIndex == 3)
                {
                    var respuesta = MessageBox.Show("¿Estás seguro de habilitar este concepto?", "Mensaje del sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (respuesta == DialogResult.Yes)
                    {
                        cn.EjecutarConsulta($"UPDATE ConceptosDinamicos SET Status = 1 WHERE ID = {id} AND IDUsuario = {FormPrincipal.userID}");
                        CargarDatos(0);
                    }
                }

                // Deshabilitar
                if (e.ColumnIndex == 4)
                {
                    var respuesta = MessageBox.Show("¿Estás seguro de deshabilitar este concepto?", "Mensaje del sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (respuesta == DialogResult.Yes)
                    {
                        cn.EjecutarConsulta($"UPDATE ConceptosDinamicos SET Status = 0 WHERE ID = {id} AND IDUsuario = {FormPrincipal.userID}");
                        CargarDatos();
                    }
                }

                DGVConceptos.ClearSelection();
            }
        }

        private void DGVConceptos_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 3)
            {
                DGVConceptos.Cursor = Cursors.Hand;
            }
            else
            {
                DGVConceptos.Cursor = Cursors.Default;
            }
        }

        private void rbHabilitados_CheckedChanged(object sender, EventArgs e)
        {
            if (rbHabilitados.Checked)
            {
                DGVConceptos.Columns["Habilitar"].Visible = false;
                DGVConceptos.Columns["Deshabilitar"].Visible = true;
                CargarDatos();
            }
        }

        private void rbDeshabilitados_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDeshabilitados.Checked)
            {
                DGVConceptos.Columns["Deshabilitar"].Visible = false;
                DGVConceptos.Columns["Habilitar"].Visible = true;
                CargarDatos(0);
            }
        }
    }
}
