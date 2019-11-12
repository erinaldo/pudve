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
        bool filtroStock, filtroPrecio;

        public WinQueryString()
        {
            InitializeComponent();
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
                filtroStock = Convert.ToBoolean(chkBoxStock.Checked);

                Properties.Settings.Default.chkFiltroStock = chkBoxStock.Checked;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();

                txtCantStock.Enabled = true;
                cbTipoFiltroStock.Enabled = true;
                txtCantStock.Text = "";
                //if (Properties.Settings.Default.chkFiltroStock.Equals(true))
                //{
                //    MessageBox.Show("Valor del chkFiltroStock es:\nTrue", "Valor del CheckBox chkFiltroStock", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
                txtCantStock.Focus();
            }
            else if (chkBoxStock.Checked.Equals(false))
            {
                filtroStock = Convert.ToBoolean(chkBoxStock.Checked);

                Properties.Settings.Default.chkFiltroStock = chkBoxStock.Checked;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();

                txtCantStock.Enabled = false;
                cbTipoFiltroStock.Enabled = false;
                txtCantStock.Text = "";
                //if (Properties.Settings.Default.chkFiltroStock.Equals(false))
                //{
                //    MessageBox.Show("Valor del chkFiltroStock es:\nFalse", "Valor del CheckBox chkFiltroStock", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
            }

            cbTipoFiltroPrecio.SelectedIndex = 0;
            if (chkBoxPrecio.Checked.Equals(true))
            {
                filtroPrecio = Convert.ToBoolean(chkBoxPrecio.Checked);

                Properties.Settings.Default.chkFiltroStock = chkBoxPrecio.Checked;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();

                txtCantPrecio.Enabled = true;
                cbTipoFiltroPrecio.Enabled = true;
                txtCantPrecio.Text = "";
                //if (Properties.Settings.Default.chkFiltroPrecio.Equals(true))
                //{
                //    MessageBox.Show("Valor del chkFiltroPrecio es:\nTrue", "Valor del CheckBox chkFiltroPrecio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
                txtCantPrecio.Focus();
            }
            else if (chkBoxPrecio.Checked.Equals(false))
            {
                filtroPrecio = Convert.ToBoolean(chkBoxPrecio.Checked);

                Properties.Settings.Default.chkFiltroStock = chkBoxPrecio.Checked;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();

                txtCantPrecio.Enabled = false;
                cbTipoFiltroPrecio.Enabled = false;
                txtCantPrecio.Text = "";
                //if (Properties.Settings.Default.chkFiltroPrecio.Equals(false))
                //{
                //    MessageBox.Show("Valor del chkFiltroPrecio es:\nFalse", "Valor del CheckBox chkFiltroPrecio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {

        }
    }
}
