﻿namespace PuntoDeVentaV2
{
    partial class Ventas
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
            this.components = new System.ComponentModel.Container();
            this.tituloSeccion = new System.Windows.Forms.Label();
            this.txtBuscadorProducto = new System.Windows.Forms.TextBox();
            this.DGVentas = new System.Windows.Forms.DataGridView();
            this.btnEliminarUltimo = new System.Windows.Forms.Button();
            this.btnEliminarTodos = new System.Windows.Forms.Button();
            this.tituloBoton = new System.Windows.Forms.ToolTip(this.components);
            this.btnServicioRapido = new System.Windows.Forms.Button();
            this.btnProductoRapido = new System.Windows.Forms.Button();
            this.btnUltimoTicket = new System.Windows.Forms.Button();
            this.btnPresupuesto = new System.Windows.Forms.Button();
            this.listaProductos = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.IDProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescuentoTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AgregarMultiple = new System.Windows.Forms.DataGridViewImageColumn();
            this.AgregarIndividual = new System.Windows.Forms.DataGridViewImageColumn();
            this.RestarIndividual = new System.Windows.Forms.DataGridViewImageColumn();
            this.EliminarIndividual = new System.Windows.Forms.DataGridViewImageColumn();
            this.lbNumeroArticulos = new System.Windows.Forms.Label();
            this.lbSubtotal = new System.Windows.Forms.Label();
            this.lbIVA = new System.Windows.Forms.Label();
            this.lbAnticipo = new System.Windows.Forms.Label();
            this.lbDescuento = new System.Windows.Forms.Label();
            this.lbTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGVentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tituloSeccion
            // 
            this.tituloSeccion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tituloSeccion.AutoSize = true;
            this.tituloSeccion.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tituloSeccion.Location = new System.Drawing.Point(470, 22);
            this.tituloSeccion.Name = "tituloSeccion";
            this.tituloSeccion.Size = new System.Drawing.Size(157, 25);
            this.tituloSeccion.TabIndex = 4;
            this.tituloSeccion.Text = "NUEVA VENTA";
            this.tituloSeccion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtBuscadorProducto
            // 
            this.txtBuscadorProducto.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscadorProducto.Location = new System.Drawing.Point(24, 91);
            this.txtBuscadorProducto.Name = "txtBuscadorProducto";
            this.txtBuscadorProducto.Size = new System.Drawing.Size(534, 23);
            this.txtBuscadorProducto.TabIndex = 5;
            this.txtBuscadorProducto.Text = "Buscar producto...";
            this.txtBuscadorProducto.TextChanged += new System.EventHandler(this.txtBuscadorProducto_TextChanged);
            this.txtBuscadorProducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscadorProducto_KeyDown);
            // 
            // DGVentas
            // 
            this.DGVentas.AllowUserToAddRows = false;
            this.DGVentas.AllowUserToDeleteRows = false;
            this.DGVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDProducto,
            this.DescuentoTipo,
            this.Cantidad,
            this.Precio,
            this.Descripcion,
            this.Descuento,
            this.Importe,
            this.AgregarMultiple,
            this.AgregarIndividual,
            this.RestarIndividual,
            this.EliminarIndividual});
            this.DGVentas.Location = new System.Drawing.Point(24, 174);
            this.DGVentas.Name = "DGVentas";
            this.DGVentas.Size = new System.Drawing.Size(534, 177);
            this.DGVentas.TabIndex = 6;
            this.DGVentas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVentas_CellClick);
            this.DGVentas.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVentas_CellMouseEnter);
            // 
            // btnEliminarUltimo
            // 
            this.btnEliminarUltimo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarUltimo.Location = new System.Drawing.Point(475, 140);
            this.btnEliminarUltimo.Name = "btnEliminarUltimo";
            this.btnEliminarUltimo.Size = new System.Drawing.Size(40, 28);
            this.btnEliminarUltimo.TabIndex = 7;
            this.tituloBoton.SetToolTip(this.btnEliminarUltimo, "Eliminar último agregado");
            this.btnEliminarUltimo.UseVisualStyleBackColor = true;
            // 
            // btnEliminarTodos
            // 
            this.btnEliminarTodos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarTodos.Location = new System.Drawing.Point(518, 140);
            this.btnEliminarTodos.Name = "btnEliminarTodos";
            this.btnEliminarTodos.Size = new System.Drawing.Size(40, 28);
            this.btnEliminarTodos.TabIndex = 8;
            this.tituloBoton.SetToolTip(this.btnEliminarTodos, "Eliminar todos los agregados");
            this.btnEliminarTodos.UseVisualStyleBackColor = true;
            // 
            // btnServicioRapido
            // 
            this.btnServicioRapido.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnServicioRapido.Location = new System.Drawing.Point(69, 140);
            this.btnServicioRapido.Name = "btnServicioRapido";
            this.btnServicioRapido.Size = new System.Drawing.Size(40, 28);
            this.btnServicioRapido.TabIndex = 11;
            this.tituloBoton.SetToolTip(this.btnServicioRapido, "Agregar servicio rápido");
            this.btnServicioRapido.UseVisualStyleBackColor = true;
            // 
            // btnProductoRapido
            // 
            this.btnProductoRapido.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProductoRapido.Location = new System.Drawing.Point(24, 140);
            this.btnProductoRapido.Name = "btnProductoRapido";
            this.btnProductoRapido.Size = new System.Drawing.Size(40, 28);
            this.btnProductoRapido.TabIndex = 10;
            this.tituloBoton.SetToolTip(this.btnProductoRapido, "Agregar producto rápido");
            this.btnProductoRapido.UseVisualStyleBackColor = true;
            // 
            // btnUltimoTicket
            // 
            this.btnUltimoTicket.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUltimoTicket.Location = new System.Drawing.Point(999, 91);
            this.btnUltimoTicket.Name = "btnUltimoTicket";
            this.btnUltimoTicket.Size = new System.Drawing.Size(37, 23);
            this.btnUltimoTicket.TabIndex = 18;
            this.tituloBoton.SetToolTip(this.btnUltimoTicket, "Imprimir último ticket");
            this.btnUltimoTicket.UseVisualStyleBackColor = true;
            // 
            // btnPresupuesto
            // 
            this.btnPresupuesto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPresupuesto.Location = new System.Drawing.Point(1037, 91);
            this.btnPresupuesto.Name = "btnPresupuesto";
            this.btnPresupuesto.Size = new System.Drawing.Size(37, 23);
            this.btnPresupuesto.TabIndex = 19;
            this.tituloBoton.SetToolTip(this.btnPresupuesto, "Guardar como presupuesto");
            this.btnPresupuesto.UseVisualStyleBackColor = true;
            // 
            // listaProductos
            // 
            this.listaProductos.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listaProductos.FormattingEnabled = true;
            this.listaProductos.ItemHeight = 17;
            this.listaProductos.Location = new System.Drawing.Point(24, 113);
            this.listaProductos.Name = "listaProductos";
            this.listaProductos.Size = new System.Drawing.Size(534, 55);
            this.listaProductos.TabIndex = 9;
            this.listaProductos.Visible = false;
            this.listaProductos.SelectedIndexChanged += new System.EventHandler(this.listaProductos_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(575, 91);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(85, 85);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(675, 91);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(756, 91);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Guardar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(837, 91);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 15;
            this.button3.Text = "Anticipos";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(918, 91);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 16;
            this.button4.Text = "Abrir Caja";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(917, 120);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(157, 23);
            this.button5.TabIndex = 17;
            this.button5.Text = "Ventas guardadas";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // IDProducto
            // 
            this.IDProducto.HeaderText = "ID";
            this.IDProducto.Name = "IDProducto";
            this.IDProducto.Visible = false;
            // 
            // DescuentoTipo
            // 
            this.DescuentoTipo.HeaderText = "Tipo Descuento";
            this.DescuentoTipo.Name = "DescuentoTipo";
            this.DescuentoTipo.Visible = false;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.Width = 65;
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            this.Precio.Width = 65;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.Width = 130;
            // 
            // Descuento
            // 
            this.Descuento.HeaderText = "Descuento";
            this.Descuento.Name = "Descuento";
            this.Descuento.Width = 65;
            // 
            // Importe
            // 
            this.Importe.HeaderText = "Importe";
            this.Importe.Name = "Importe";
            this.Importe.Width = 65;
            // 
            // AgregarMultiple
            // 
            this.AgregarMultiple.HeaderText = "";
            this.AgregarMultiple.Name = "AgregarMultiple";
            this.AgregarMultiple.ReadOnly = true;
            this.AgregarMultiple.Width = 25;
            // 
            // AgregarIndividual
            // 
            this.AgregarIndividual.HeaderText = "";
            this.AgregarIndividual.Name = "AgregarIndividual";
            this.AgregarIndividual.ReadOnly = true;
            this.AgregarIndividual.Width = 25;
            // 
            // RestarIndividual
            // 
            this.RestarIndividual.HeaderText = "";
            this.RestarIndividual.Name = "RestarIndividual";
            this.RestarIndividual.ReadOnly = true;
            this.RestarIndividual.Width = 25;
            // 
            // EliminarIndividual
            // 
            this.EliminarIndividual.HeaderText = "";
            this.EliminarIndividual.Name = "EliminarIndividual";
            this.EliminarIndividual.ReadOnly = true;
            this.EliminarIndividual.Width = 25;
            // 
            // lbNumeroArticulos
            // 
            this.lbNumeroArticulos.AutoSize = true;
            this.lbNumeroArticulos.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNumeroArticulos.Location = new System.Drawing.Point(672, 199);
            this.lbNumeroArticulos.Name = "lbNumeroArticulos";
            this.lbNumeroArticulos.Size = new System.Drawing.Size(143, 17);
            this.lbNumeroArticulos.TabIndex = 20;
            this.lbNumeroArticulos.Text = "Número de artículos:";
            // 
            // lbSubtotal
            // 
            this.lbSubtotal.AutoSize = true;
            this.lbSubtotal.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSubtotal.Location = new System.Drawing.Point(672, 222);
            this.lbSubtotal.Name = "lbSubtotal";
            this.lbSubtotal.Size = new System.Drawing.Size(66, 17);
            this.lbSubtotal.TabIndex = 21;
            this.lbSubtotal.Text = "Subtotal:";
            // 
            // lbIVA
            // 
            this.lbIVA.AutoSize = true;
            this.lbIVA.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIVA.Location = new System.Drawing.Point(672, 245);
            this.lbIVA.Name = "lbIVA";
            this.lbIVA.Size = new System.Drawing.Size(61, 17);
            this.lbIVA.TabIndex = 22;
            this.lbIVA.Text = "IVA 16%:";
            // 
            // lbAnticipo
            // 
            this.lbAnticipo.AutoSize = true;
            this.lbAnticipo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAnticipo.Location = new System.Drawing.Point(672, 268);
            this.lbAnticipo.Name = "lbAnticipo";
            this.lbAnticipo.Size = new System.Drawing.Size(66, 17);
            this.lbAnticipo.TabIndex = 23;
            this.lbAnticipo.Text = "Anticipo:";
            // 
            // lbDescuento
            // 
            this.lbDescuento.AutoSize = true;
            this.lbDescuento.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDescuento.Location = new System.Drawing.Point(672, 293);
            this.lbDescuento.Name = "lbDescuento";
            this.lbDescuento.Size = new System.Drawing.Size(81, 17);
            this.lbDescuento.TabIndex = 24;
            this.lbDescuento.Text = "Descuento:";
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotal.Location = new System.Drawing.Point(672, 318);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(43, 17);
            this.lbTotal.TabIndex = 25;
            this.lbTotal.Text = "Total:";
            // 
            // Ventas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 611);
            this.Controls.Add(this.lbTotal);
            this.Controls.Add(this.lbDescuento);
            this.Controls.Add(this.lbAnticipo);
            this.Controls.Add(this.lbIVA);
            this.Controls.Add(this.lbSubtotal);
            this.Controls.Add(this.lbNumeroArticulos);
            this.Controls.Add(this.listaProductos);
            this.Controls.Add(this.btnPresupuesto);
            this.Controls.Add(this.btnUltimoTicket);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnServicioRapido);
            this.Controls.Add(this.btnProductoRapido);
            this.Controls.Add(this.btnEliminarTodos);
            this.Controls.Add(this.btnEliminarUltimo);
            this.Controls.Add(this.DGVentas);
            this.Controls.Add(this.txtBuscadorProducto);
            this.Controls.Add(this.tituloSeccion);
            this.Name = "Ventas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ventas";
            this.Load += new System.EventHandler(this.Ventas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label tituloSeccion;
        private System.Windows.Forms.TextBox txtBuscadorProducto;
        private System.Windows.Forms.DataGridView DGVentas;
        private System.Windows.Forms.Button btnEliminarUltimo;
        private System.Windows.Forms.Button btnEliminarTodos;
        private System.Windows.Forms.ToolTip tituloBoton;
        private System.Windows.Forms.ListBox listaProductos;
        private System.Windows.Forms.Button btnServicioRapido;
        private System.Windows.Forms.Button btnProductoRapido;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnUltimoTicket;
        private System.Windows.Forms.Button btnPresupuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescuentoTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe;
        private System.Windows.Forms.DataGridViewImageColumn AgregarMultiple;
        private System.Windows.Forms.DataGridViewImageColumn AgregarIndividual;
        private System.Windows.Forms.DataGridViewImageColumn RestarIndividual;
        private System.Windows.Forms.DataGridViewImageColumn EliminarIndividual;
        private System.Windows.Forms.Label lbNumeroArticulos;
        private System.Windows.Forms.Label lbSubtotal;
        private System.Windows.Forms.Label lbIVA;
        private System.Windows.Forms.Label lbAnticipo;
        private System.Windows.Forms.Label lbDescuento;
        private System.Windows.Forms.Label lbTotal;
    }
}