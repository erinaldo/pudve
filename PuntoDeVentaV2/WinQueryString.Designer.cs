﻿namespace PuntoDeVentaV2
{
    partial class WinQueryString
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkBoxImagen = new System.Windows.Forms.CheckBox();
            this.chkBoxRevision = new System.Windows.Forms.CheckBox();
            this.chkBoxTipo = new System.Windows.Forms.CheckBox();
            this.fLPDetalleProducto = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbTipoFiltroImagen = new System.Windows.Forms.ComboBox();
            this.txtNoRevision = new System.Windows.Forms.TextBox();
            this.cbTipoFiltroRevision = new System.Windows.Forms.ComboBox();
            this.cbTipoFiltroCombProdServ = new System.Windows.Forms.ComboBox();
            this.cbTipoFiltroStock = new System.Windows.Forms.ComboBox();
            this.txtCantStock = new System.Windows.Forms.TextBox();
            this.txtCantPrecio = new System.Windows.Forms.TextBox();
            this.cbTipoFiltroPrecio = new System.Windows.Forms.ComboBox();
            this.chkBoxPrecio = new System.Windows.Forms.CheckBox();
            this.chkBoxStock = new System.Windows.Forms.CheckBox();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.btnClean = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkBoxImagen);
            this.groupBox1.Controls.Add(this.chkBoxRevision);
            this.groupBox1.Controls.Add(this.chkBoxTipo);
            this.groupBox1.Controls.Add(this.fLPDetalleProducto);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.chkBoxPrecio);
            this.groupBox1.Controls.Add(this.chkBoxStock);
            this.groupBox1.Location = new System.Drawing.Point(27, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(524, 347);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuració de Filtrado: ";
            // 
            // chkBoxImagen
            // 
            this.chkBoxImagen.AutoSize = true;
            this.chkBoxImagen.Location = new System.Drawing.Point(19, 165);
            this.chkBoxImagen.Name = "chkBoxImagen";
            this.chkBoxImagen.Size = new System.Drawing.Size(61, 17);
            this.chkBoxImagen.TabIndex = 14;
            this.chkBoxImagen.Text = "Imagen";
            this.chkBoxImagen.UseVisualStyleBackColor = true;
            this.chkBoxImagen.CheckedChanged += new System.EventHandler(this.chkBoxImagen_CheckedChanged);
            // 
            // chkBoxRevision
            // 
            this.chkBoxRevision.AutoSize = true;
            this.chkBoxRevision.Location = new System.Drawing.Point(19, 99);
            this.chkBoxRevision.Name = "chkBoxRevision";
            this.chkBoxRevision.Size = new System.Drawing.Size(65, 17);
            this.chkBoxRevision.TabIndex = 13;
            this.chkBoxRevision.Text = "Revisón";
            this.chkBoxRevision.UseVisualStyleBackColor = true;
            this.chkBoxRevision.CheckedChanged += new System.EventHandler(this.chkBoxRevision_CheckedChanged);
            // 
            // chkBoxTipo
            // 
            this.chkBoxTipo.AutoSize = true;
            this.chkBoxTipo.Location = new System.Drawing.Point(19, 131);
            this.chkBoxTipo.Name = "chkBoxTipo";
            this.chkBoxTipo.Size = new System.Drawing.Size(47, 17);
            this.chkBoxTipo.TabIndex = 12;
            this.chkBoxTipo.Text = "Tipo";
            this.chkBoxTipo.UseVisualStyleBackColor = true;
            this.chkBoxTipo.CheckedChanged += new System.EventHandler(this.chkBoxTipo_CheckedChanged);
            // 
            // fLPDetalleProducto
            // 
            this.fLPDetalleProducto.AutoScroll = true;
            this.fLPDetalleProducto.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.fLPDetalleProducto.Location = new System.Drawing.Point(6, 191);
            this.fLPDetalleProducto.Name = "fLPDetalleProducto";
            this.fLPDetalleProducto.Size = new System.Drawing.Size(512, 150);
            this.fLPDetalleProducto.TabIndex = 11;
            this.fLPDetalleProducto.WrapContents = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbTipoFiltroImagen);
            this.panel1.Controls.Add(this.txtNoRevision);
            this.panel1.Controls.Add(this.cbTipoFiltroRevision);
            this.panel1.Controls.Add(this.cbTipoFiltroCombProdServ);
            this.panel1.Controls.Add(this.cbTipoFiltroStock);
            this.panel1.Controls.Add(this.txtCantStock);
            this.panel1.Controls.Add(this.txtCantPrecio);
            this.panel1.Controls.Add(this.cbTipoFiltroPrecio);
            this.panel1.Location = new System.Drawing.Point(90, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(428, 172);
            this.panel1.TabIndex = 8;
            // 
            // cbTipoFiltroImagen
            // 
            this.cbTipoFiltroImagen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoFiltroImagen.FormattingEnabled = true;
            this.cbTipoFiltroImagen.Items.AddRange(new object[] {
            "No Aplica",
            "Con Imagen",
            "Sin Imagen"});
            this.cbTipoFiltroImagen.Location = new System.Drawing.Point(38, 144);
            this.cbTipoFiltroImagen.Name = "cbTipoFiltroImagen";
            this.cbTipoFiltroImagen.Size = new System.Drawing.Size(369, 21);
            this.cbTipoFiltroImagen.TabIndex = 9;
            this.cbTipoFiltroImagen.SelectedIndexChanged += new System.EventHandler(this.cbTipoFiltroImagen_SelectedIndexChanged);
            // 
            // txtNoRevision
            // 
            this.txtNoRevision.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtNoRevision.Location = new System.Drawing.Point(342, 77);
            this.txtNoRevision.Name = "txtNoRevision";
            this.txtNoRevision.Size = new System.Drawing.Size(65, 23);
            this.txtNoRevision.TabIndex = 7;
            this.txtNoRevision.Text = "0";
            this.txtNoRevision.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNoRevision.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoRevision_KeyPress);
            // 
            // cbTipoFiltroRevision
            // 
            this.cbTipoFiltroRevision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoFiltroRevision.FormattingEnabled = true;
            this.cbTipoFiltroRevision.Items.AddRange(new object[] {
            "No Aplica",
            "Mayor o Igual Que",
            "Menor o Igual Que",
            "Igual Que",
            "Mayor Que",
            "Menor Que"});
            this.cbTipoFiltroRevision.Location = new System.Drawing.Point(38, 77);
            this.cbTipoFiltroRevision.Name = "cbTipoFiltroRevision";
            this.cbTipoFiltroRevision.Size = new System.Drawing.Size(284, 21);
            this.cbTipoFiltroRevision.TabIndex = 6;
            this.cbTipoFiltroRevision.SelectedIndexChanged += new System.EventHandler(this.cbTipoFiltroRevision_SelectedIndexChanged);
            // 
            // cbTipoFiltroCombProdServ
            // 
            this.cbTipoFiltroCombProdServ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoFiltroCombProdServ.FormattingEnabled = true;
            this.cbTipoFiltroCombProdServ.Items.AddRange(new object[] {
            "No Aplica",
            "Combo",
            "Producto",
            "Servicio"});
            this.cbTipoFiltroCombProdServ.Location = new System.Drawing.Point(38, 110);
            this.cbTipoFiltroCombProdServ.Name = "cbTipoFiltroCombProdServ";
            this.cbTipoFiltroCombProdServ.Size = new System.Drawing.Size(369, 21);
            this.cbTipoFiltroCombProdServ.TabIndex = 8;
            this.cbTipoFiltroCombProdServ.SelectedIndexChanged += new System.EventHandler(this.cbTipoFiltroCombProdServ_SelectedIndexChanged);
            this.cbTipoFiltroCombProdServ.Click += new System.EventHandler(this.cbTipoFiltroCombProdServ_Click);
            // 
            // cbTipoFiltroStock
            // 
            this.cbTipoFiltroStock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbTipoFiltroStock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoFiltroStock.FormattingEnabled = true;
            this.cbTipoFiltroStock.Items.AddRange(new object[] {
            "No Aplica",
            "Mayor o Igual Que",
            "Menor o Igual Que",
            "Igual Que",
            "Mayor Que",
            "Menor Que"});
            this.cbTipoFiltroStock.Location = new System.Drawing.Point(38, 8);
            this.cbTipoFiltroStock.Name = "cbTipoFiltroStock";
            this.cbTipoFiltroStock.Size = new System.Drawing.Size(284, 21);
            this.cbTipoFiltroStock.TabIndex = 1;
            this.cbTipoFiltroStock.SelectedIndexChanged += new System.EventHandler(this.cbTipoFiltroStock_SelectedIndexChanged);
            this.cbTipoFiltroStock.Click += new System.EventHandler(this.cbTipoFiltroStock_Click);
            // 
            // txtCantStock
            // 
            this.txtCantStock.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtCantStock.Location = new System.Drawing.Point(342, 6);
            this.txtCantStock.Name = "txtCantStock";
            this.txtCantStock.Size = new System.Drawing.Size(65, 23);
            this.txtCantStock.TabIndex = 2;
            this.txtCantStock.Text = "0.0";
            this.txtCantStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCantStock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantStock_KeyPress);
            // 
            // txtCantPrecio
            // 
            this.txtCantPrecio.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtCantPrecio.Location = new System.Drawing.Point(342, 42);
            this.txtCantPrecio.Name = "txtCantPrecio";
            this.txtCantPrecio.Size = new System.Drawing.Size(65, 23);
            this.txtCantPrecio.TabIndex = 5;
            this.txtCantPrecio.Text = "0.0";
            this.txtCantPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCantPrecio.Click += new System.EventHandler(this.txtCantPrecio_Click);
            this.txtCantPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantPrecio_KeyPress);
            // 
            // cbTipoFiltroPrecio
            // 
            this.cbTipoFiltroPrecio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoFiltroPrecio.FormattingEnabled = true;
            this.cbTipoFiltroPrecio.Items.AddRange(new object[] {
            "No Aplica",
            "Mayor o Igual Que",
            "Menor o Igual Que",
            "Igual Que",
            "Mayor Que",
            "Menor Que"});
            this.cbTipoFiltroPrecio.Location = new System.Drawing.Point(38, 44);
            this.cbTipoFiltroPrecio.Name = "cbTipoFiltroPrecio";
            this.cbTipoFiltroPrecio.Size = new System.Drawing.Size(284, 21);
            this.cbTipoFiltroPrecio.TabIndex = 4;
            this.cbTipoFiltroPrecio.SelectedIndexChanged += new System.EventHandler(this.cbTipoFiltroPrecio_SelectedIndexChanged);
            this.cbTipoFiltroPrecio.Click += new System.EventHandler(this.cbTipoFiltroPrecio_Click);
            // 
            // chkBoxPrecio
            // 
            this.chkBoxPrecio.AutoSize = true;
            this.chkBoxPrecio.Location = new System.Drawing.Point(19, 65);
            this.chkBoxPrecio.Name = "chkBoxPrecio";
            this.chkBoxPrecio.Size = new System.Drawing.Size(56, 17);
            this.chkBoxPrecio.TabIndex = 3;
            this.chkBoxPrecio.Text = "Precio";
            this.chkBoxPrecio.UseVisualStyleBackColor = true;
            this.chkBoxPrecio.CheckedChanged += new System.EventHandler(this.chkBoxPrecio_CheckedChanged);
            // 
            // chkBoxStock
            // 
            this.chkBoxStock.AutoSize = true;
            this.chkBoxStock.Location = new System.Drawing.Point(19, 29);
            this.chkBoxStock.Name = "chkBoxStock";
            this.chkBoxStock.Size = new System.Drawing.Size(54, 17);
            this.chkBoxStock.TabIndex = 0;
            this.chkBoxStock.Text = "Stock";
            this.chkBoxStock.UseVisualStyleBackColor = true;
            this.chkBoxStock.CheckedChanged += new System.EventHandler(this.chkBoxStock_CheckedChanged);
            // 
            // btnAplicar
            // 
            this.btnAplicar.BackColor = System.Drawing.Color.ForestGreen;
            this.btnAplicar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAplicar.FlatAppearance.BorderSize = 0;
            this.btnAplicar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAplicar.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicar.ForeColor = System.Drawing.Color.White;
            this.btnAplicar.Location = new System.Drawing.Point(335, 385);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(95, 43);
            this.btnAplicar.TabIndex = 6;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = false;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // btnClean
            // 
            this.btnClean.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.btnClean.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnClean.FlatAppearance.BorderSize = 0;
            this.btnClean.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClean.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClean.ForeColor = System.Drawing.Color.White;
            this.btnClean.Location = new System.Drawing.Point(122, 385);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(95, 43);
            this.btnClean.TabIndex = 7;
            this.btnClean.Text = "Limpiar";
            this.btnClean.UseVisualStyleBackColor = false;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // WinQueryString
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 442);
            this.Controls.Add(this.btnClean);
            this.Controls.Add(this.btnAplicar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WinQueryString";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filtro Avanzado de Productos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WinQueryString_FormClosed);
            this.Load += new System.EventHandler(this.WinQueryString_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCantStock;
        private System.Windows.Forms.CheckBox chkBoxStock;
        private System.Windows.Forms.ComboBox cbTipoFiltroStock;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.CheckBox chkBoxPrecio;
        private System.Windows.Forms.TextBox txtCantPrecio;
        private System.Windows.Forms.ComboBox cbTipoFiltroPrecio;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel fLPDetalleProducto;
        private System.Windows.Forms.CheckBox chkBoxTipo;
        private System.Windows.Forms.ComboBox cbTipoFiltroCombProdServ;
        private System.Windows.Forms.CheckBox chkBoxRevision;
        private System.Windows.Forms.ComboBox cbTipoFiltroRevision;
        private System.Windows.Forms.TextBox txtNoRevision;
        private System.Windows.Forms.ComboBox cbTipoFiltroImagen;
        private System.Windows.Forms.CheckBox chkBoxImagen;
    }
}