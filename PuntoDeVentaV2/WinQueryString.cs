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
        bool    filtroStock, 
                filtroPrecio;

        string  strFiltroStock = string.Empty, 
                strFiltroPrecio = string.Empty,
                strOpcionCBStock = string.Empty,
                strOpcionCBPrecio = string.Empty,
                strTxtStock = string.Empty,
                strTxtPrecio = string.Empty;

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
            //MessageBox.Show("Valor de checkBox: " + Properties.Settings.Default.chkFiltroStock);
            if (Properties.Settings.Default.chkFiltroStock.Equals(true))
            {
                string strOperadorAndCant;
                string[] strList;
                char[] separator = { ' ' };
                chkBoxStock.Checked = Properties.Settings.Default.chkFiltroStock;
                strOperadorAndCant = Properties.Settings.Default.strFiltroStock;
                if (!strOperadorAndCant.Equals(""))
                {
                    strList = strOperadorAndCant.Split(separator);
                    txtCantStock.Text = strList[2].ToString();
                    if (strList[1].ToString().Equals(">="))
                    {
                        cbTipoFiltroStock.SelectedIndex = 1;
                    }
                    else if (strList[1].ToString().Equals("<="))
                    {
                        cbTipoFiltroStock.SelectedIndex = 2;
                    }
                    else if (strList[1].ToString().Equals("="))
                    {
                        cbTipoFiltroStock.SelectedIndex = 3;
                    }
                    else if (strList[1].ToString().Equals(">"))
                    {
                        cbTipoFiltroStock.SelectedIndex = 4;
                    }
                    else if (strList[1].ToString().Equals("<"))
                    {
                        cbTipoFiltroStock.SelectedIndex = 5;
                    }
                }
            }
            else if (Properties.Settings.Default.chkFiltroStock.Equals(false))
            {
                chkBoxStock.Checked = false;
                cbTipoFiltroStock.SelectedIndex = 0;
                cbTipoFiltroStock_SelectedIndexChanged(sender, e);
                validarChkBoxStock();
            }
            if (Properties.Settings.Default.chkFiltroPrecio.Equals(true))
            {
                string strOperadorAndCant;
                string[] strList;
                char[] separator = { ' ' };
                chkBoxPrecio.Checked = Properties.Settings.Default.chkFiltroPrecio;
                strOperadorAndCant = Properties.Settings.Default.strFiltroPrecio;
                if (!strOperadorAndCant.Equals(""))
                {
                    strList = strOperadorAndCant.Split(separator);
                    if (strList.Length > 1)
                    {
                        txtCantPrecio.Text = strList[2].ToString();

                        if (strList[1].ToString().Equals(">="))
                        {
                            cbTipoFiltroPrecio.SelectedIndex = 1;
                        }
                        else if (strList[1].ToString().Equals("<="))
                        {
                            cbTipoFiltroPrecio.SelectedIndex = 2;
                        }
                        else if (strList[1].ToString().Equals("="))
                        {
                            cbTipoFiltroPrecio.SelectedIndex = 3;
                        }
                        else if (strList[1].ToString().Equals(">"))
                        {
                            cbTipoFiltroPrecio.SelectedIndex = 4;
                        }
                        else if (strList[1].ToString().Equals("<"))
                        {
                            cbTipoFiltroPrecio.SelectedIndex = 5;
                        }
                    }
                }
            }
            else if (Properties.Settings.Default.chkFiltroPrecio.Equals(false))
            {
                chkBoxPrecio.Checked = false;
                cbTipoFiltroPrecio.SelectedIndex = 0;
                cbTipoFiltroPrecio_SelectedIndexChanged(sender, e);
                validarChkBoxPrecio();
            }
        }

        private void validarChkBoxStock()
        {
            cbTipoFiltroStock.SelectedIndex = 0;
            if (chkBoxStock.Checked.Equals(true))
            {
                filtroStock = Convert.ToBoolean(chkBoxStock.Checked);

                Properties.Settings.Default.chkFiltroStock = filtroStock;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();

                txtCantStock.Enabled = true;
                cbTipoFiltroStock.Enabled = true;
                txtCantStock.Text = "";
                txtCantStock.Focus();
            }
            else if (chkBoxStock.Checked.Equals(false))
            {
                filtroStock = Convert.ToBoolean(chkBoxStock.Checked);

                Properties.Settings.Default.chkFiltroStock = filtroStock;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();

                txtCantStock.Enabled = false;
                cbTipoFiltroStock.Enabled = false;
                txtCantStock.Text = "";
            }
        }

        private void validarChkBoxPrecio()
        {
            cbTipoFiltroPrecio.SelectedIndex = 0;
            if (chkBoxPrecio.Checked.Equals(true))
            {
                filtroPrecio = Convert.ToBoolean(chkBoxPrecio.Checked);

                Properties.Settings.Default.chkFiltroPrecio = filtroPrecio;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();

                txtCantPrecio.Enabled = true;
                cbTipoFiltroPrecio.Enabled = true;
                txtCantPrecio.Text = "";
                txtCantPrecio.Focus();
            }
            else if (chkBoxPrecio.Checked.Equals(false))
            {
                filtroPrecio = Convert.ToBoolean(chkBoxPrecio.Checked);

                Properties.Settings.Default.chkFiltroPrecio = filtroPrecio;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();

                txtCantPrecio.Enabled = false;
                cbTipoFiltroPrecio.Enabled = false;
                txtCantPrecio.Text = "";
            }
        }

        private void chkBoxStock_CheckedChanged(object sender, EventArgs e)
        {
            validarChkBoxStock();
        }

        private void cbTipoFiltroStock_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtroStock = Properties.Settings.Default.chkFiltroStock;

            if (filtroStock.Equals(true))
            {
                strOpcionCBStock = Convert.ToString(cbTipoFiltroStock.SelectedItem);

                strTxtStock = txtCantStock.Text;

                strFiltroStock = "Stock ";

                if (!strTxtStock.Equals(""))
                {
                    if (strOpcionCBStock.Equals("No Aplica"))
                    {
                        strFiltroStock = "";
                    }
                    else if (strOpcionCBStock.Equals("Mayor o Igual Que"))
                    {
                        strFiltroStock += ">= ";
                    }
                    else if (strOpcionCBStock.Equals("Menor o Igual Que"))
                    {
                        strFiltroStock += "<= ";
                    }
                    else if (strOpcionCBStock.Equals("Igual Que"))
                    {
                        strFiltroStock += "= ";
                    }
                    else if (strOpcionCBStock.Equals("Mayor Que"))
                    {
                        strFiltroStock += "> ";
                    }
                    else if (strOpcionCBStock.Equals("Menor Que"))
                    {
                        strFiltroStock += "< ";
                    }
                }
                else if (strTxtStock.Equals(""))
                {
                    strFiltroStock = "";
                }
            }
        }

        private void WinQueryString_FormClosed(object sender, FormClosedEventArgs e)
        {
            Productos producto = Application.OpenForms.OfType<Productos>().FirstOrDefault();

            if (producto != null)
            {
                producto.actualizarBtnFiltro();
                producto.CargarDatos();
            }
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            Productos producto = Application.OpenForms.OfType<Productos>().FirstOrDefault();

            if (producto != null)
            {
                producto.inicializarVariablesFiltro();
            }

            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbTipoFiltroPrecio_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtroPrecio = Properties.Settings.Default.chkFiltroPrecio;

            if (filtroPrecio.Equals(true))
            {
                strOpcionCBPrecio = Convert.ToString(cbTipoFiltroPrecio.SelectedItem);

                strTxtPrecio = txtCantPrecio.Text;

                strFiltroPrecio = "Precio ";

                if (!strTxtPrecio.Equals(""))
                {
                    if (strOpcionCBPrecio.Equals("No Aplica"))
                    {
                        strFiltroPrecio = "";
                    }
                    else if (strOpcionCBPrecio.Equals("Mayor o Igual Que"))
                    {
                        strFiltroPrecio += ">= ";
                    }
                    else if (strOpcionCBPrecio.Equals("Menor o Igual Que"))
                    {
                        strFiltroPrecio += "<= ";
                    }
                    else if (strOpcionCBPrecio.Equals("Igual Que"))
                    {
                        strFiltroPrecio += "= ";
                    }
                    else if (strOpcionCBPrecio.Equals("Mayor Que"))
                    {
                        strFiltroPrecio += "> ";
                    }
                    else if (strOpcionCBPrecio.Equals("Menor Que"))
                    {
                        strFiltroPrecio += "< ";
                    }
                }
                else if (strTxtPrecio.Equals(""))
                {
                    strFiltroPrecio = "";
                }
            }
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
            validarChkBoxPrecio();
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            cbTipoFiltroStock_SelectedIndexChanged(sender, e);
            filtroStock = Properties.Settings.Default.chkFiltroStock;
            cbTipoFiltroPrecio_SelectedIndexChanged(sender, e);
            filtroPrecio = Properties.Settings.Default.chkFiltroPrecio;

            DialogResult result = MessageBox.Show("Desea Guardar el Filtro\no editar su elección", 
                                                  "Guardado del Filtro", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (filtroStock.Equals(true))
                {
                    strTxtStock = txtCantStock.Text;

                    if (!strTxtStock.Equals(""))
                    {
                        if (!strOpcionCBStock.Equals("No Aplica"))
                        {
                            strFiltroStock += strTxtStock;

                            Properties.Settings.Default.strFiltroStock = strFiltroStock;
                            Properties.Settings.Default.Save();
                            Properties.Settings.Default.Reload();
                            //MessageBox.Show("Query Construido es: " + Properties.Settings.Default.strFiltroStock,
                            //            "Filtro Construido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            Properties.Settings.Default.strFiltroStock = string.Empty;
                            //MessageBox.Show("Query Construido es: " + Properties.Settings.Default.strFiltroStock,
                            //            "Filtro Construido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else if (strTxtStock.Equals(""))
                    {
                        strFiltroStock = "";
                        MessageBox.Show("Favor de Introducir una\nCantidad en el Campo de Stock",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtCantStock.Focus();
                    }
                }
                else if (filtroStock.Equals(false))
                {
                    //MessageBox.Show("Que Paso...\nFalta Seleccionar Stock.");
                }
                if (filtroPrecio.Equals(true))
                {
                    strTxtPrecio = txtCantPrecio.Text;

                    if (!strTxtPrecio.Equals(""))
                    {
                        if (!strOpcionCBPrecio.Equals("No Aplica"))
                        {
                            strFiltroPrecio += strTxtPrecio;

                            Properties.Settings.Default.strFiltroPrecio = strFiltroPrecio;
                            Properties.Settings.Default.Save();
                            Properties.Settings.Default.Reload();
                            //MessageBox.Show("Query Construido es: " + Properties.Settings.Default.strFiltroStock,
                            //            "Filtro Construido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            Properties.Settings.Default.strFiltroPrecio = string.Empty;
                            //MessageBox.Show("Query Construido es: " + Properties.Settings.Default.strFiltroStock,
                            //            "Filtro Construido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else if (strTxtPrecio.Equals(""))
                    {
                        strFiltroPrecio = "";
                        MessageBox.Show("Favor de Introducir una\nCantidad en el Campo de Precio",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtCantPrecio.Focus();
                    }
                }
                else if (filtroPrecio.Equals(false))
                {
                    //MessageBox.Show("Que Paso...\nFalta Seleccionar Precio.");
                }
                this.Close();
            }
            else if (result == DialogResult.No)
            {
                this.Close();
            }
            else if (result == DialogResult.Cancel)
            {
                txtCantStock.Focus();
            }
        }
    }
}
