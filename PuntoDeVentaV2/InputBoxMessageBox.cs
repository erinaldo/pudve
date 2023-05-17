﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoDeVentaV2
{
    public partial class InputBoxMessageBox : Form
    {
        string promptMsg = string.Empty,
                titleWindow = string.Empty,
                strDefaultResponse = string.Empty;
        Conexion cn = new Conexion();
        Consultas cs = new Consultas();

        public string retornoNombreConcepto = string.Empty;
        public string ventaFacil = string.Empty;

        private void cargarValores()
        {
            lblPrompt.Text = promptMsg;
            this.Text = titleWindow;
            txtDefaultResponse.Text = strDefaultResponse;
            txtDefaultResponse.Focus();
            txtDefaultResponse.SelectAll();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            txtDefaultResponse.Text = txtDefaultResponse.Text.Trim();
            if (string.IsNullOrWhiteSpace(txtDefaultResponse.Text) || txtDefaultResponse.Text == "Concepto para Agregar al producto.")
            {
                MessageBox.Show("Ingreses un nombre para el Detalle","Aviso del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            string  textoDefaultResponse = string.Empty, 
                    auxComparacionAgregar = string.Empty;

            textoDefaultResponse = txtDefaultResponse.Text;
            auxComparacionAgregar = strDefaultResponse;

            if (txtDefaultResponse.Text.Equals(string.Empty))
            {
                retornoNombreConcepto = string.Empty;
            }
            else if(!textoDefaultResponse.Contains(auxComparacionAgregar))
            {
                retornoNombreConcepto = txtDefaultResponse.Text;
                retornoNombreConcepto.Trim();
                retornoNombreConcepto = retornoNombreConcepto.Replace("\r\n", " ");
            }

            if (chbVentaFacil.Checked)
            {
                ventaFacil = "";
            }

            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDefaultResponse_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAceptar.PerformClick();
            }
        }

        private void InputBoxMessageBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
            {
                this.Close();
            }
        }

        private void chbVentaFacil_CheckedChanged(object sender, EventArgs e)
        {
            if (chbVentaFacil.Checked)
            {
                txtDefaultResponse.Text = "Venta fácil";
                txtDefaultResponse.Enabled = false;
            }
            else
            {
                txtDefaultResponse.Text = "";
                txtDefaultResponse.Enabled = true;
            }
        }

        private void txtDefaultResponse_TextChanged(object sender, EventArgs e)
        {
            ValidarEntradaDeTexto(sender, e);
            if (txtDefaultResponse.Text.Equals("Venta facil"))
            {
                chbVentaFacil.Checked = true;
            }
        }

        private void ValidarEntradaDeTexto(object sender, EventArgs e)
        {
            var resultado = string.Empty;
            var txtValidarTexto = (TextBox)sender;
            resultado = txtValidarTexto.Text;

            if (!string.IsNullOrWhiteSpace(resultado))
            {
                Regex patronCorerecto = new Regex(@"^[a-zA-Z0-9ÑñÁáÉéÍíÓóÚú]");

                if (patronCorerecto.IsMatch(resultado))
                {
                    resultado = Regex.Replace(resultado, @"[Ñ]", "N");
                    resultado = Regex.Replace(resultado, @"[ñ]", "n");
                    resultado = Regex.Replace(resultado, @"[Á]", "A");
                    resultado = Regex.Replace(resultado, @"[á]", "a");
                    resultado = Regex.Replace(resultado, @"[É]", "E");
                    resultado = Regex.Replace(resultado, @"[é]", "e");
                    resultado = Regex.Replace(resultado, @"[Í]", "I");
                    resultado = Regex.Replace(resultado, @"[í]", "i");
                    resultado = Regex.Replace(resultado, @"[Ó]", "O");
                    resultado = Regex.Replace(resultado, @"[ó]", "o");
                    resultado = Regex.Replace(resultado, @"[Ú]", "U");
                    resultado = Regex.Replace(resultado, @"[ú]", "u");
                    txtValidarTexto.Text = resultado;
                    txtValidarTexto.Select(txtValidarTexto.Text.Length, 0);
                }
                else
                {
                    var resultadoAuxialiar = Regex.Replace(resultado, @"[^a-zA-Z0-9]", string.Empty).Trim();
                    resultado = resultadoAuxialiar;
                    txtValidarTexto.Text = resultado;
                    txtValidarTexto.Focus();
                    txtValidarTexto.Select(txtValidarTexto.Text.Length, 0);
                }
            }
            else
            {
                txtValidarTexto.Focus();
                txtValidarTexto.Select(txtValidarTexto.Text.Length, 0);
            }
        }

        private void InputBoxMessageBox_Load(object sender, EventArgs e)
        {
            cargarValores();
            using (DataTable dt = cn.CargarDatos($"SELECT ventaFacil FROM configuracion WHERE IDUsuario = {FormPrincipal.userID}"))
            {
                if (dt.Rows[0][0].ToString().Equals("1"))
                {
                    chbVentaFacil.Visible = true;
                }
            }
        }

        public InputBoxMessageBox(string _Prompt, string _Title, string _DefaultResponse)
        {
            InitializeComponent();
            this.promptMsg = _Prompt;
            this.titleWindow = _Title;
            this.strDefaultResponse = _DefaultResponse;
        }
    }
} 
