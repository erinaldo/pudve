﻿namespace PuntoDeVentaV2
{
    partial class Productos
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
            this.DGVProductos = new System.Windows.Forms.DataGridView();
            this.chk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnAgregarProducto = new System.Windows.Forms.Button();
            this.tituloSeccion = new System.Windows.Forms.Label();
            this.tituloBusqueda = new System.Windows.Forms.Label();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.cbOrden = new System.Windows.Forms.ComboBox();
            this.cbMostrar = new System.Windows.Forms.ComboBox();
            this.btnAgregarXML = new System.Windows.Forms.Button();
            this.btnModificarEstado = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGVProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVProductos
            // 
            this.DGVProductos.AllowUserToAddRows = false;
            this.DGVProductos.AllowUserToDeleteRows = false;
            this.DGVProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chk});
            this.DGVProductos.Location = new System.Drawing.Point(16, 266);
            this.DGVProductos.Margin = new System.Windows.Forms.Padding(4);
            this.DGVProductos.MultiSelect = false;
            this.DGVProductos.Name = "DGVProductos";
            this.DGVProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVProductos.Size = new System.Drawing.Size(1183, 324);
            this.DGVProductos.TabIndex = 1;
            this.DGVProductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVProductos_CellClick);
            this.DGVProductos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVProductos_CellContentClick_1);
            this.DGVProductos.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVProductos_CellMouseEnter);
            this.DGVProductos.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DGVProductos_CellPainting);
            // 
            // chk
            // 
            this.chk.HeaderText = "Seleccionar";
            this.chk.MinimumWidth = 50;
            this.chk.Name = "chk";
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(53)))), ((int)(((byte)(20)))));
            this.btnAgregarProducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarProducto.FlatAppearance.BorderSize = 0;
            this.btnAgregarProducto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(83)))), ((int)(((byte)(79)))));
            this.btnAgregarProducto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(83)))), ((int)(((byte)(79)))));
            this.btnAgregarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarProducto.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarProducto.ForeColor = System.Drawing.Color.White;
            this.btnAgregarProducto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarProducto.Location = new System.Drawing.Point(964, 203);
            this.btnAgregarProducto.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(233, 33);
            this.btnAgregarProducto.TabIndex = 1;
            this.btnAgregarProducto.Text = "Agregar  producto +";
            this.btnAgregarProducto.UseVisualStyleBackColor = false;
            this.btnAgregarProducto.Click += new System.EventHandler(this.btnAgregarProducto_Click);
            // 
            // tituloSeccion
            // 
            this.tituloSeccion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tituloSeccion.AutoSize = true;
            this.tituloSeccion.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tituloSeccion.Location = new System.Drawing.Point(547, 34);
            this.tituloSeccion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tituloSeccion.Name = "tituloSeccion";
            this.tituloSeccion.Size = new System.Drawing.Size(175, 32);
            this.tituloSeccion.TabIndex = 3;
            this.tituloSeccion.Text = "PRODUCTOS";
            this.tituloSeccion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tituloBusqueda
            // 
            this.tituloBusqueda.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tituloBusqueda.AutoSize = true;
            this.tituloBusqueda.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tituloBusqueda.Location = new System.Drawing.Point(443, 86);
            this.tituloBusqueda.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tituloBusqueda.Name = "tituloBusqueda";
            this.tituloBusqueda.Size = new System.Drawing.Size(335, 22);
            this.tituloBusqueda.TabIndex = 4;
            this.tituloBusqueda.Text = "Búsqueda avanzada de productos";
            this.tituloBusqueda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtBusqueda.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusqueda.Location = new System.Drawing.Point(163, 126);
            this.txtBusqueda.Margin = new System.Windows.Forms.Padding(4);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(887, 27);
            this.txtBusqueda.TabIndex = 5;
            this.txtBusqueda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBusqueda.TextChanged += new System.EventHandler(this.txtBusqueda_TextChanged);
            // 
            // cbOrden
            // 
            this.cbOrden.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbOrden.DisplayMember = "Prueba";
            this.cbOrden.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbOrden.FormattingEnabled = true;
            this.cbOrden.Items.AddRange(new object[] {
            "Ordenar por:",
            "A - Z",
            "Z - A",
            "Mayor precio",
            "Menor precio"});
            this.cbOrden.Location = new System.Drawing.Point(517, 206);
            this.cbOrden.Margin = new System.Windows.Forms.Padding(4);
            this.cbOrden.Name = "cbOrden";
            this.cbOrden.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbOrden.Size = new System.Drawing.Size(199, 29);
            this.cbOrden.TabIndex = 6;
            // 
            // cbMostrar
            // 
            this.cbMostrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMostrar.DisplayMember = "Prueba";
            this.cbMostrar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMostrar.FormattingEnabled = true;
            this.cbMostrar.Items.AddRange(new object[] {
            "Habilitados",
            "Deshabilitados",
            "Todos"});
            this.cbMostrar.Location = new System.Drawing.Point(741, 206);
            this.cbMostrar.Margin = new System.Windows.Forms.Padding(4);
            this.cbMostrar.Name = "cbMostrar";
            this.cbMostrar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbMostrar.Size = new System.Drawing.Size(199, 29);
            this.cbMostrar.TabIndex = 7;
            this.cbMostrar.SelectedIndexChanged += new System.EventHandler(this.cbMostrar_SelectedIndexChanged);
            // 
            // btnAgregarXML
            // 
            this.btnAgregarXML.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnAgregarXML.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarXML.Font = new System.Drawing.Font("Century Gothic", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarXML.Image = global::PuntoDeVentaV2.Properties.Resources.cart_plus;
            this.btnAgregarXML.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarXML.Location = new System.Drawing.Point(16, 201);
            this.btnAgregarXML.Name = "btnAgregarXML";
            this.btnAgregarXML.Size = new System.Drawing.Size(163, 35);
            this.btnAgregarXML.TabIndex = 8;
            this.btnAgregarXML.Text = "Agregar XML";
            this.btnAgregarXML.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarXML.UseVisualStyleBackColor = false;
            this.btnAgregarXML.Click += new System.EventHandler(this.btnAgregarXML_Click);
            // 
            // btnModificarEstado
            // 
            this.btnModificarEstado.Font = new System.Drawing.Font("Century Gothic", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnModificarEstado.Image = global::PuntoDeVentaV2.Properties.Resources.cogs;
            this.btnModificarEstado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificarEstado.Location = new System.Drawing.Point(185, 201);
            this.btnModificarEstado.Name = "btnModificarEstado";
            this.btnModificarEstado.Size = new System.Drawing.Size(201, 35);
            this.btnModificarEstado.TabIndex = 10;
            this.btnModificarEstado.Text = "Modificar Estado";
            this.btnModificarEstado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModificarEstado.UseVisualStyleBackColor = true;
            this.btnModificarEstado.Click += new System.EventHandler(this.btnModificarEstado_Click);
            // 
            // Productos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1215, 690);
            this.Controls.Add(this.btnModificarEstado);
            this.Controls.Add(this.btnAgregarXML);
            this.Controls.Add(this.cbMostrar);
            this.Controls.Add(this.btnAgregarProducto);
            this.Controls.Add(this.cbOrden);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.tituloBusqueda);
            this.Controls.Add(this.tituloSeccion);
            this.Controls.Add(this.DGVProductos);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Productos";
            this.Text = "Productos";
            this.Load += new System.EventHandler(this.Productos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView DGVProductos;
        private System.Windows.Forms.Button btnAgregarProducto;
        private System.Windows.Forms.Label tituloSeccion;
        private System.Windows.Forms.Label tituloBusqueda;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.ComboBox cbOrden;
        private System.Windows.Forms.ComboBox cbMostrar;
        private System.Windows.Forms.Button btnAgregarXML;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chk;
        private System.Windows.Forms.Button btnModificarEstado;
    }
}