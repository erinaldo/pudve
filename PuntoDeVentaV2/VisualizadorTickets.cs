﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoDeVentaV2
{
    public partial class VisualizadorTickets : Form
    {
        private string ticketGenerado = string.Empty;
        private string rutaTicketGenerado = string.Empty;

        public VisualizadorTickets(string nombreTicket, string rutaTicket)
        {
            InitializeComponent();

            this.ticketGenerado = nombreTicket;
            this.rutaTicketGenerado = rutaTicket;
        }

        private void VisualizadorTickets_Load(object sender, EventArgs e)
        {
            this.Text = "PUDVE - " + ticketGenerado;
            axAcroPDF.src = rutaTicketGenerado;
            axAcroPDF.setZoom(75);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo info = new ProcessStartInfo();
                info.Verb = "print";
                info.FileName = rutaTicketGenerado;
                info.CreateNoWindow = true;
                info.WindowStyle = ProcessWindowStyle.Hidden;

                Process p = new Process();
                p.StartInfo = info;
                p.Start();

                p.WaitForInputIdle();
                System.Threading.Thread.Sleep(1000);

                if (false == p.CloseMainWindow())
                {
                    p.Kill();
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Imprimir No: "+ex, "Error al Imprimir", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
