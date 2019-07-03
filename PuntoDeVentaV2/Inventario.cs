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
    public partial class Inventario : Form
    {
        RevisarInventario checkInventory = new RevisarInventario();
        ReporteFinalRevisarInventario FinalReportReviewInventory = new ReporteFinalRevisarInventario();

        public Inventario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkInventory.FormClosed += delegate
            {
                FinalReportReviewInventory.FormClosed += delegate
                {
                    FormCollection fOpen = Application.OpenForms;

                    List<string> tempFormOpen = new List<string>();

                    foreach (Form formToClose in fOpen)
                    {
                        if (formToClose.Name != "FormPrincipal" && formToClose.Name != "Login")
                        {
                            tempFormOpen.Add(formToClose.Name);
                        }
                    }

                    foreach (var toClose in tempFormOpen)
                    {
                        Form ventanaAbierta = Application.OpenForms[toClose];
                        ventanaAbierta.Close();
                    }
                };
                if (!FinalReportReviewInventory.Visible)
                {
                    FinalReportReviewInventory.ShowDialog();
                }
                else
                {
                    FinalReportReviewInventory.ShowDialog();
                }
            };
            if (!checkInventory.Visible)
            {
                checkInventory.ShowDialog();
            }
            else
            {
                checkInventory.ShowDialog();
            }
        }
    }
}
