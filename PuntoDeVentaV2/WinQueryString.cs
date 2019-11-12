﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoDeVentaV2
{
    public partial class WinQueryString : Form
    {
        public WinQueryString()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCantStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            CultureInfo cc = System.Threading.Thread.CurrentThread.CurrentCulture;

            if (char.IsNumber(e.KeyChar) || e.KeyChar.ToString() == cc.NumberFormat.NumberDecimalSeparator)
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Soló son permitidos numeros\nen este campo de Stock",
                                "Error de captura del Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void WinQueryString_Load(object sender, EventArgs e)
        {
            validarChkBox();
        }

        private void validarChkBox()
        {
            cbTipoFiltroStock.SelectedIndex = 0;
            if (chkBoxStock.Checked.Equals(true))
            {
                txtCantStock.Enabled = true;
                cbTipoFiltroStock.Enabled = true;
                txtCantStock.Text = "";
                txtCantStock.Focus();
            }
            else if (chkBoxStock.Checked.Equals(false))
            {
                txtCantStock.Enabled = false;
                cbTipoFiltroStock.Enabled = false;
                txtCantStock.Text = "";
            }

            cbTipoFiltroPrecio.SelectedIndex = 0;
            if (chkBoxPrecio.Checked.Equals(true))
            {
                txtCantPrecio.Enabled = true;
                cbTipoFiltroPrecio.Enabled = true;
                txtCantPrecio.Text = "";
                txtCantPrecio.Focus();
            }
            else if (chkBoxPrecio.Checked.Equals(false))
            {
                txtCantPrecio.Enabled = false;
                cbTipoFiltroPrecio.Enabled = false;
                txtCantPrecio.Text = "";
            }
        }

        private void chkBoxStock_CheckedChanged(object sender, EventArgs e)
        {
            validarChkBox();
        }

        private void cbTipoFiltroStock_Click(object sender, EventArgs e)
        {
            cbTipoFiltroStock.DroppedDown = true;
        }

        private void txtCantPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            CultureInfo cc = System.Threading.Thread.CurrentThread.CurrentCulture;

            if (char.IsNumber(e.KeyChar) || e.KeyChar.ToString() == cc.NumberFormat.NumberDecimalSeparator)
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Soló son permitidos numeros\nen este campo de Precio",
                                "Error de captura del Precio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbTipoFiltroPrecio_Click(object sender, EventArgs e)
        {
            cbTipoFiltroPrecio.DroppedDown = true;
        }

        private void chkBoxPrecio_CheckedChanged(object sender, EventArgs e)
        {
            validarChkBox();
        }
    }
}
