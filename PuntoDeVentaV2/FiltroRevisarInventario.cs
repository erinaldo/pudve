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
    public partial class FiltroRevisarInventario : Form
    {
        // Para el filtro de inventario
        public string tipoFiltro { get; set; }
        public string operadorFiltro { get; set; }
        public int cantidadFiltro { get; set; }

        public FiltroRevisarInventario()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FiltroRevisarInventario_Load(object sender, EventArgs e)
        {
            var operadores = new Dictionary<string, string>();
            operadores.Add("NA", "Seleccionar opción...");
            operadores.Add(">=", "Mayor o igual que");
            operadores.Add("<=", "Menor o igual que");
            operadores.Add("==", "Igual que");
            operadores.Add(">", "Mayor que");
            operadores.Add("<", "Menor que");

            var filtros = new Dictionary<string, string>();
            filtros.Add("Normal", "Revision Normal");
            filtros.Add("Stock", "Stock");
            filtros.Add("StockMinimo", "Stock Mínimo");
            filtros.Add("StockNecesario", "Stock Máximo");
            filtros.Add("NumeroRevision", "Número de Revisión");

            cbFiltro.DataSource = filtros.ToArray();
            cbFiltro.DisplayMember = "Value";
            cbFiltro.ValueMember = "Key";

            cbOperadores.DataSource = operadores.ToArray();
            cbOperadores.DisplayMember = "Value";
            cbOperadores.ValueMember = "Key";

            txtCantidad.KeyPress += new KeyPressEventHandler(SoloDecimales);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            var filtro = cbFiltro.SelectedValue.ToString();
            
            tipoFiltro = filtro;

            if (filtro == "Normal")
            {
                operadorFiltro = "NA";
                cantidadFiltro = 0;
            }
            else
            {
                var operador = cbOperadores.SelectedValue.ToString();
                var cantidad = txtCantidad.Text.Trim();


                if (operador == "NA")
                {
                    MessageBox.Show("Seleccione una opción de las condiciones para el filtro", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbOperadores.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(cantidad))
                {
                    MessageBox.Show("Es necesario ingresar una cantidad", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCantidad.Focus();
                    return;
                }

                operadorFiltro = operador;
                cantidadFiltro = Convert.ToInt32(cantidad);
            }

            //DialogResult = DialogResult.OK;
            Inventario.aceptarFiltro = true;
            Close();
        }

        private void cbFiltro_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var filtro = cbFiltro.SelectedValue.ToString();

            if (filtro == "Normal")
            {
                cbOperadores.Visible = false;
                txtCantidad.Visible = false;
            }
            else
            {
                cbOperadores.Visible = true;
                txtCantidad.Visible = true;
            }
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
