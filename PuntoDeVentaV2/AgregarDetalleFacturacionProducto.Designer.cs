﻿namespace PuntoDeVentaV2
{
    partial class AgregarDetalleFacturacionProducto
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
            this.btnAceptarDetalle = new System.Windows.Forms.Button();
            this.btnCancelarDetalle = new System.Windows.Forms.Button();
            this.cbLinea1_1 = new System.Windows.Forms.ComboBox();
            this.cbLinea1_2 = new System.Windows.Forms.ComboBox();
            this.cbLinea1_3 = new System.Windows.Forms.ComboBox();
            this.cbLinea1_4 = new System.Windows.Forms.ComboBox();
            this.tbLinea1_2 = new System.Windows.Forms.TextBox();
            this.btnExtra = new System.Windows.Forms.Button();
            this.btnImpLocal = new System.Windows.Forms.Button();
            this.panelContenedor = new System.Windows.Forms.FlowLayoutPanel();
            this.tbLinea1_1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClaveGenerica = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClaveUnidad = new System.Windows.Forms.TextBox();
            this.cbUnidadMedida = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtClaveProducto = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtBoxBase = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbExcento = new System.Windows.Forms.RadioButton();
            this.rb16porCiento = new System.Windows.Forms.RadioButton();
            this.rb8porCiento = new System.Windows.Forms.RadioButton();
            this.rb0porCiento = new System.Windows.Forms.RadioButton();
            this.txtIVA = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAceptarDetalle
            // 
            this.btnAceptarDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptarDetalle.BackColor = System.Drawing.Color.Green;
            this.btnAceptarDetalle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAceptarDetalle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LimeGreen;
            this.btnAceptarDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptarDetalle.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptarDetalle.ForeColor = System.Drawing.Color.White;
            this.btnAceptarDetalle.Location = new System.Drawing.Point(1063, 676);
            this.btnAceptarDetalle.Margin = new System.Windows.Forms.Padding(4);
            this.btnAceptarDetalle.Name = "btnAceptarDetalle";
            this.btnAceptarDetalle.Size = new System.Drawing.Size(192, 34);
            this.btnAceptarDetalle.TabIndex = 25;
            this.btnAceptarDetalle.Text = "Aceptar";
            this.btnAceptarDetalle.UseVisualStyleBackColor = false;
            this.btnAceptarDetalle.Click += new System.EventHandler(this.btnAceptarDetalle_Click);
            // 
            // btnCancelarDetalle
            // 
            this.btnCancelarDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelarDetalle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancelarDetalle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelarDetalle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btnCancelarDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarDetalle.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarDetalle.ForeColor = System.Drawing.Color.White;
            this.btnCancelarDetalle.Location = new System.Drawing.Point(863, 676);
            this.btnCancelarDetalle.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelarDetalle.Name = "btnCancelarDetalle";
            this.btnCancelarDetalle.Size = new System.Drawing.Size(192, 34);
            this.btnCancelarDetalle.TabIndex = 24;
            this.btnCancelarDetalle.Text = "Cancelar";
            this.btnCancelarDetalle.UseVisualStyleBackColor = false;
            this.btnCancelarDetalle.Click += new System.EventHandler(this.btnCancelarDetalle_Click);
            // 
            // cbLinea1_1
            // 
            this.cbLinea1_1.BackColor = System.Drawing.SystemColors.Window;
            this.cbLinea1_1.FormattingEnabled = true;
            this.cbLinea1_1.Items.AddRange(new object[] {
            "...",
            "Traslado",
            "Retención"});
            this.cbLinea1_1.Location = new System.Drawing.Point(32, 230);
            this.cbLinea1_1.Margin = new System.Windows.Forms.Padding(4);
            this.cbLinea1_1.Name = "cbLinea1_1";
            this.cbLinea1_1.Size = new System.Drawing.Size(132, 24);
            this.cbLinea1_1.TabIndex = 26;
            // 
            // cbLinea1_2
            // 
            this.cbLinea1_2.FormattingEnabled = true;
            this.cbLinea1_2.Location = new System.Drawing.Point(192, 230);
            this.cbLinea1_2.Margin = new System.Windows.Forms.Padding(4);
            this.cbLinea1_2.Name = "cbLinea1_2";
            this.cbLinea1_2.Size = new System.Drawing.Size(132, 24);
            this.cbLinea1_2.TabIndex = 27;
            // 
            // cbLinea1_3
            // 
            this.cbLinea1_3.FormattingEnabled = true;
            this.cbLinea1_3.Location = new System.Drawing.Point(352, 230);
            this.cbLinea1_3.Margin = new System.Windows.Forms.Padding(4);
            this.cbLinea1_3.Name = "cbLinea1_3";
            this.cbLinea1_3.Size = new System.Drawing.Size(132, 24);
            this.cbLinea1_3.TabIndex = 28;
            // 
            // cbLinea1_4
            // 
            this.cbLinea1_4.FormattingEnabled = true;
            this.cbLinea1_4.Location = new System.Drawing.Point(512, 230);
            this.cbLinea1_4.Margin = new System.Windows.Forms.Padding(4);
            this.cbLinea1_4.Name = "cbLinea1_4";
            this.cbLinea1_4.Size = new System.Drawing.Size(132, 24);
            this.cbLinea1_4.TabIndex = 29;
            // 
            // tbLinea1_2
            // 
            this.tbLinea1_2.Location = new System.Drawing.Point(832, 232);
            this.tbLinea1_2.Margin = new System.Windows.Forms.Padding(4);
            this.tbLinea1_2.Name = "tbLinea1_2";
            this.tbLinea1_2.ReadOnly = true;
            this.tbLinea1_2.Size = new System.Drawing.Size(132, 22);
            this.tbLinea1_2.TabIndex = 30;
            this.tbLinea1_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnExtra
            // 
            this.btnExtra.BackColor = System.Drawing.Color.Green;
            this.btnExtra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExtra.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnExtra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExtra.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExtra.ForeColor = System.Drawing.Color.White;
            this.btnExtra.Location = new System.Drawing.Point(1063, 358);
            this.btnExtra.Margin = new System.Windows.Forms.Padding(4);
            this.btnExtra.Name = "btnExtra";
            this.btnExtra.Size = new System.Drawing.Size(192, 31);
            this.btnExtra.TabIndex = 31;
            this.btnExtra.Text = "+ Agregar Extra";
            this.btnExtra.UseVisualStyleBackColor = false;
            this.btnExtra.Click += new System.EventHandler(this.btnExtra_Click);
            // 
            // btnImpLocal
            // 
            this.btnImpLocal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImpLocal.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnImpLocal.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImpLocal.Location = new System.Drawing.Point(1063, 299);
            this.btnImpLocal.Margin = new System.Windows.Forms.Padding(4);
            this.btnImpLocal.Name = "btnImpLocal";
            this.btnImpLocal.Size = new System.Drawing.Size(192, 31);
            this.btnImpLocal.TabIndex = 32;
            this.btnImpLocal.Text = "+ Agregar Imp. local";
            this.btnImpLocal.UseVisualStyleBackColor = true;
            this.btnImpLocal.Click += new System.EventHandler(this.btnImpLocal_Click);
            // 
            // panelContenedor
            // 
            this.panelContenedor.AutoScroll = true;
            this.panelContenedor.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panelContenedor.Location = new System.Drawing.Point(8, 279);
            this.panelContenedor.Margin = new System.Windows.Forms.Padding(4);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(1029, 123);
            this.panelContenedor.TabIndex = 33;
            this.panelContenedor.WrapContents = false;
            // 
            // tbLinea1_1
            // 
            this.tbLinea1_1.Enabled = false;
            this.tbLinea1_1.Location = new System.Drawing.Point(672, 231);
            this.tbLinea1_1.Margin = new System.Windows.Forms.Padding(4);
            this.tbLinea1_1.Name = "tbLinea1_1";
            this.tbLinea1_1.Size = new System.Drawing.Size(132, 22);
            this.tbLinea1_1.TabIndex = 34;
            this.tbLinea1_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(76, 524);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 21);
            this.label1.TabIndex = 35;
            this.label1.Text = "Clave de producto:";
            // 
            // btnClaveGenerica
            // 
            this.btnClaveGenerica.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnClaveGenerica.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClaveGenerica.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClaveGenerica.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClaveGenerica.ForeColor = System.Drawing.Color.White;
            this.btnClaveGenerica.Location = new System.Drawing.Point(545, 520);
            this.btnClaveGenerica.Margin = new System.Windows.Forms.Padding(4);
            this.btnClaveGenerica.Name = "btnClaveGenerica";
            this.btnClaveGenerica.Size = new System.Drawing.Size(227, 31);
            this.btnClaveGenerica.TabIndex = 37;
            this.btnClaveGenerica.Text = "Agregar clave génerica";
            this.btnClaveGenerica.UseVisualStyleBackColor = false;
            this.btnClaveGenerica.Click += new System.EventHandler(this.btnClaveGenerica_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(81, 582);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 49);
            this.label2.TabIndex = 38;
            this.label2.Text = "Clave de unidad de medida:";
            // 
            // txtClaveUnidad
            // 
            this.txtClaveUnidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtClaveUnidad.Location = new System.Drawing.Point(324, 581);
            this.txtClaveUnidad.Margin = new System.Windows.Forms.Padding(4);
            this.txtClaveUnidad.Name = "txtClaveUnidad";
            this.txtClaveUnidad.Size = new System.Drawing.Size(145, 22);
            this.txtClaveUnidad.TabIndex = 39;
            this.txtClaveUnidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtClaveUnidad.Leave += new System.EventHandler(this.txtClaveUnidad_Leave);
            // 
            // cbUnidadMedida
            // 
            this.cbUnidadMedida.FormattingEnabled = true;
            this.cbUnidadMedida.ItemHeight = 16;
            this.cbUnidadMedida.Location = new System.Drawing.Point(545, 581);
            this.cbUnidadMedida.Margin = new System.Windows.Forms.Padding(4);
            this.cbUnidadMedida.Name = "cbUnidadMedida";
            this.cbUnidadMedida.Size = new System.Drawing.Size(649, 24);
            this.cbUnidadMedida.TabIndex = 40;
            this.cbUnidadMedida.SelectedIndexChanged += new System.EventHandler(this.cbUnidadMedida_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 203);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 19);
            this.label3.TabIndex = 41;
            this.label3.Text = "Es";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(188, 203);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 19);
            this.label4.TabIndex = 42;
            this.label4.Text = "Impuesto";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(348, 203);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 19);
            this.label5.TabIndex = 43;
            this.label5.Text = "Tipo factor";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(508, 203);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 19);
            this.label6.TabIndex = 44;
            this.label6.Text = "Tasa / Cuota";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(859, 204);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 19);
            this.label7.TabIndex = 45;
            this.label7.Text = "Importe";
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Location = new System.Drawing.Point(109, 418);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(1000, 2);
            this.label8.TabIndex = 46;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Location = new System.Drawing.Point(111, 500);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(1000, 2);
            this.label9.TabIndex = 47;
            // 
            // txtClaveProducto
            // 
            this.txtClaveProducto.Location = new System.Drawing.Point(324, 523);
            this.txtClaveProducto.Margin = new System.Windows.Forms.Padding(4);
            this.txtClaveProducto.MaxLength = 8;
            this.txtClaveProducto.Name = "txtClaveProducto";
            this.txtClaveProducto.Size = new System.Drawing.Size(145, 22);
            this.txtClaveProducto.TabIndex = 48;
            this.txtClaveProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Location = new System.Drawing.Point(114, 655);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(1000, 2);
            this.label10.TabIndex = 49;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(150, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 23);
            this.label11.TabIndex = 50;
            this.label11.Text = "Base";
            // 
            // txtBoxBase
            // 
            this.txtBoxBase.Enabled = false;
            this.txtBoxBase.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxBase.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtBoxBase.Location = new System.Drawing.Point(215, 53);
            this.txtBoxBase.Name = "txtBoxBase";
            this.txtBoxBase.Size = new System.Drawing.Size(282, 32);
            this.txtBoxBase.TabIndex = 51;
            this.txtBoxBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbExcento);
            this.groupBox1.Controls.Add(this.rb16porCiento);
            this.groupBox1.Controls.Add(this.rb8porCiento);
            this.groupBox1.Controls.Add(this.rb0porCiento);
            this.groupBox1.Location = new System.Drawing.Point(32, 104);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(772, 81);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Imouesto al Valor Agregado: ";
            // 
            // rbExcento
            // 
            this.rbExcento.AutoSize = true;
            this.rbExcento.Location = new System.Drawing.Point(631, 35);
            this.rbExcento.Name = "rbExcento";
            this.rbExcento.Size = new System.Drawing.Size(101, 21);
            this.rbExcento.TabIndex = 3;
            this.rbExcento.Text = "IVA  Exento";
            this.rbExcento.UseVisualStyleBackColor = true;
            this.rbExcento.CheckedChanged += new System.EventHandler(this.rbExcento_CheckedChanged);
            // 
            // rb16porCiento
            // 
            this.rb16porCiento.AutoSize = true;
            this.rb16porCiento.Location = new System.Drawing.Point(421, 35);
            this.rb16porCiento.Name = "rb16porCiento";
            this.rb16porCiento.Size = new System.Drawing.Size(82, 21);
            this.rb16porCiento.TabIndex = 2;
            this.rb16porCiento.Text = "IVA 16%";
            this.rb16porCiento.UseVisualStyleBackColor = true;
            this.rb16porCiento.CheckedChanged += new System.EventHandler(this.rb16porCiento_CheckedChanged);
            // 
            // rb8porCiento
            // 
            this.rb8porCiento.AutoSize = true;
            this.rb8porCiento.Location = new System.Drawing.Point(204, 35);
            this.rb8porCiento.Name = "rb8porCiento";
            this.rb8porCiento.Size = new System.Drawing.Size(74, 21);
            this.rb8porCiento.TabIndex = 1;
            this.rb8porCiento.Text = "IVA 8%";
            this.rb8porCiento.UseVisualStyleBackColor = true;
            this.rb8porCiento.CheckedChanged += new System.EventHandler(this.rb8porCiento_CheckedChanged);
            // 
            // rb0porCiento
            // 
            this.rb0porCiento.AutoSize = true;
            this.rb0porCiento.Checked = true;
            this.rb0porCiento.Location = new System.Drawing.Point(22, 35);
            this.rb0porCiento.Name = "rb0porCiento";
            this.rb0porCiento.Size = new System.Drawing.Size(74, 21);
            this.rb0porCiento.TabIndex = 0;
            this.rb0porCiento.TabStop = true;
            this.rb0porCiento.Text = "IVA 0%";
            this.rb0porCiento.UseVisualStyleBackColor = true;
            this.rb0porCiento.CheckedChanged += new System.EventHandler(this.rb0porCiento_CheckedChanged);
            // 
            // txtIVA
            // 
            this.txtIVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.txtIVA.Location = new System.Drawing.Point(832, 138);
            this.txtIVA.Name = "txtIVA";
            this.txtIVA.Size = new System.Drawing.Size(132, 22);
            this.txtIVA.TabIndex = 53;
            this.txtIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(985, 139);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 19);
            this.label12.TabIndex = 54;
            this.label12.Text = "IVA";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label13.Location = new System.Drawing.Point(985, 446);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 19);
            this.label13.TabIndex = 55;
            this.label13.Text = "Total";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(832, 445);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(132, 22);
            this.textBox1.TabIndex = 56;
            // 
            // AgregarDetalleFacturacionProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1270, 745);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtIVA);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtBoxBase);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtClaveProducto);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbUnidadMedida);
            this.Controls.Add(this.txtClaveUnidad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClaveGenerica);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbLinea1_1);
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.btnImpLocal);
            this.Controls.Add(this.btnExtra);
            this.Controls.Add(this.tbLinea1_2);
            this.Controls.Add(this.cbLinea1_4);
            this.Controls.Add(this.cbLinea1_3);
            this.Controls.Add(this.cbLinea1_2);
            this.Controls.Add(this.cbLinea1_1);
            this.Controls.Add(this.btnAceptarDetalle);
            this.Controls.Add(this.btnCancelarDetalle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AgregarDetalleFacturacionProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PUDVE - Detalles de Facturación";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AgregarDetalleFacturacionProducto_FormClosing);
            this.Load += new System.EventHandler(this.AgregarDetalleFacturacionProducto_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAceptarDetalle;
        private System.Windows.Forms.Button btnCancelarDetalle;
        private System.Windows.Forms.ComboBox cbLinea1_1;
        private System.Windows.Forms.ComboBox cbLinea1_2;
        private System.Windows.Forms.ComboBox cbLinea1_3;
        private System.Windows.Forms.ComboBox cbLinea1_4;
        private System.Windows.Forms.TextBox tbLinea1_2;
        private System.Windows.Forms.Button btnExtra;
        private System.Windows.Forms.Button btnImpLocal;
        private System.Windows.Forms.FlowLayoutPanel panelContenedor;
        private System.Windows.Forms.TextBox tbLinea1_1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClaveGenerica;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtClaveUnidad;
        private System.Windows.Forms.ComboBox cbUnidadMedida;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtClaveProducto;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb0porCiento;
        private System.Windows.Forms.RadioButton rbExcento;
        private System.Windows.Forms.RadioButton rb16porCiento;
        private System.Windows.Forms.RadioButton rb8porCiento;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.TextBox txtBoxBase;
        public System.Windows.Forms.TextBox txtIVA;
    }
}