﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoDeVentaV2
{
    public partial class ImprimirEtiqueta : Form
    {
        private string[] nombrePlantillas;
        public ImprimirEtiqueta()
        {
            InitializeComponent();
        }

        private void ImprimirEtiqueta_Load(object sender, EventArgs e)
        {
            ListaPlantillas();
        }

        private void ListaPlantillas()
        {
            // Obtener los nombres de los archivos de la carpeta plantillas
            var ruta = Properties.Settings.Default.rutaDirectorio + @"\PUDVE\Plantillas";

            nombrePlantillas = Directory.GetFiles(ruta, "*.txt").Select(Path.GetFileName).ToArray();

            cbPlantillas.Items.Add("Seleccionar una plantilla...");

            if (nombrePlantillas.Length > 0)
            {
                foreach (var nombre in nombrePlantillas)
                {
                    var plantilla = nombre.Replace(".txt", "");

                    cbPlantillas.Items.Add(plantilla);
                }
            }

            cbPlantillas.SelectedIndex = 0;
            cbPlantillas.Focus();
        }

        private void cbPlantillas_SelectedIndexChanged(object sender, EventArgs e)
        {
            var indice = cbPlantillas.SelectedIndex;
            var nombre = cbPlantillas.SelectedItem.ToString();

            if (indice > 0)
            {
                panelEtiqueta.BorderStyle = BorderStyle.None;

                var plantilla = nombre + ".bmp";
                var rutaPlantilla = Properties.Settings.Default.rutaDirectorio + @"\PUDVE\Plantillas\" + plantilla;

                panelEtiqueta.BackgroundImage = Image.FromFile(rutaPlantilla);
            }
            else
            {
                panelEtiqueta.BackgroundImage = null;
                panelEtiqueta.BorderStyle = BorderStyle.FixedSingle;
            }
        }
    }
}
