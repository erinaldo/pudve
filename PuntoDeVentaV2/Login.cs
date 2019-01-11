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
    public partial class Login : Form
    {

        Conexion cn = new Conexion();

        public Login()
        {
            InitializeComponent();
        }

        private void btnCerrarLogin_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string password = txtPassword.Text;

            if (usuario != "" && password != "")
            {
                bool resultado = cn.EjecutarSelect("SELECT * FROM Usuarios WHERE Usuario = '" + usuario + "' AND Password = '" + password + "'");

                if (resultado == true)
                {
                    FormPrincipal fp = new FormPrincipal();

                    this.Hide();

                    fp.nickUsuario = usuario;
                    fp.ShowDialog();

                    this.Close();
                }
                else
                {

                    txtMensaje.Text = "El usuario y/o contraseña son incorrectos";
                    txtPassword.Text = "";
                    txtPassword.Focus();
                }
            }
            else
            {
                txtMensaje.Text = "Ingrese sus datos de inicio de sesión";
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEntrar_Click(this, new EventArgs());
            }
        }

        private void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            Registro ventanaRegistro = new Registro();

            this.Hide();

            ventanaRegistro.ShowDialog();

            this.Close();
        }
    }
}
