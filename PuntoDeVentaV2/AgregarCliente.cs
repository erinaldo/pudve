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
    public partial class AgregarCliente : Form
    {
        public AgregarCliente()
        {
            InitializeComponent();
        }

        private void AgregarCliente_Load(object sender, EventArgs e)
        {
            //ComboBox usos de CFDI
            Dictionary<string, string> usosCFDI = new Dictionary<string, string>();
            usosCFDI.Add("G01", "Adquisición de mercancias");
            usosCFDI.Add("G02", "Devoluciones, descuentos o bonificaciones");
            usosCFDI.Add("G03", "Gastos en general");
            usosCFDI.Add("I01", "Construcciones");
            usosCFDI.Add("I02", "Mobilario y equipo de oficina por inversiones");
            usosCFDI.Add("I03", "Equipo de transporte");
            usosCFDI.Add("I04", "Equipo de computo y accesorios");
            usosCFDI.Add("I05", "Dados, troqueles, moldes, matrices y herramental");
            usosCFDI.Add("I06", "Comunicaciones telefónica");
            usosCFDI.Add("I07", "Comunicaciones satelitale");
            usosCFDI.Add("I08", "Otra maquinaria y equipo");
            usosCFDI.Add("P01", "Por definir");

            cbUsoCFDI.DataSource = usosCFDI.ToArray();
            cbUsoCFDI.DisplayMember = "Value";
            cbUsoCFDI.ValueMember = "Key";

            //ComboBox Regimen Fiscal
            Dictionary<string, string> regimenes = new Dictionary<string, string>();
            regimenes.Add("Asalariados", "Asalariados");
            regimenes.Add("Honorarios(Servicios Profesionales)", "Honorarios(Servicios Profesionales)");
            regimenes.Add("Arrendamiento de inmuebles", "Arrendamiento de inmuebles");
            regimenes.Add("Regimen de las actividades empresariales y profesionales", "Régimen de las actividades empresariales y profesionales");
            regimenes.Add("Regimen de actividades agricolas, ganaderas, silvicolas y pesqueras pf y pm", "Régimen de actividades agrícolas, ganaderas, silvícolas y pesqueras pf y pm.");
            regimenes.Add("Incorporacion Fiscal", "Incorporación Fiscal");
            regimenes.Add("Personas morales del regimen general", "Personas morales del régimen general");
            regimenes.Add("Personas morales con fines no lucrativos", "Personas morales con fines no lucrativos");
            regimenes.Add("No contribuyente", "No contribuyente");
            regimenes.Add("Regimen de las personas fisicas con actividad empresarial y profesionales", "Régimen de las personas físicas con actividad empresarial y profesionales");

            cbRegimen.DataSource = regimenes.ToArray();
            cbRegimen.DisplayMember = "Value";
            cbRegimen.ValueMember = "Key";

            //ComboBox Formas de pago
            Dictionary<string, string> pagos = new Dictionary<string, string>();
            pagos.Add("01", "01 - Efectivo");
            pagos.Add("02", "02 - Cheque nominativo");
            pagos.Add("03", "03 - Transferencia electrónica de fondos");
            pagos.Add("04", "04 - Tarjeta de crédito");
            pagos.Add("05", "05 - Monedero electrónico");
            pagos.Add("06", "06 - Dinero electrónico");
            pagos.Add("08", "08 - Vales de despensa");
            pagos.Add("12", "12 - Dación en pago");
            pagos.Add("13", "13 - Pago por subrogación");
            pagos.Add("14", "14 - Pago por consignación");
            pagos.Add("15", "15 - Condonación");
            pagos.Add("17", "17 - Compensación");
            pagos.Add("23", "23 - Novación");
            pagos.Add("24", "24 - Confusión");
            pagos.Add("25", "25 - Remisión de deuda");
            pagos.Add("26", "26 - Prescripción o caducidad");
            pagos.Add("27", "27 - A satisfacción del acreedor");
            pagos.Add("28", "28 - Tarjeta de débito");
            pagos.Add("29", "29 - Tarjeta de servicios");
            pagos.Add("30", "30 - Aplicación de anticipos");
            pagos.Add("99", "99 - Por definir");

            cbFormaPago.DataSource = pagos.ToArray();
            cbFormaPago.DisplayMember = "Value";
            cbFormaPago.ValueMember = "Key";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }
    }
}
