﻿
namespace PuntoDeVentaV2
{
    partial class Complemento_pago_impuestos
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_base0_7 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb_exento = new System.Windows.Forms.RadioButton();
            this.rb_dieciseis = new System.Windows.Forms.RadioButton();
            this.rb_cero = new System.Windows.Forms.RadioButton();
            this.rb_ocho = new System.Windows.Forms.RadioButton();
            this.txt_importe0_6 = new System.Windows.Forms.TextBox();
            this.btn_aceptar = new System.Windows.Forms.Button();
            this.btn_agregar = new System.Windows.Forms.Button();
            this.pnl_impuestos = new System.Windows.Forms.FlowLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(157, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(675, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Agregar los impuestos del documento a pagar y/o abonar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(146, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Es";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(211, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Impúesto";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(282, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tipo factor";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(369, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 21);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tasa / cuota";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(484, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 21);
            this.label6.TabIndex = 5;
            this.label6.Text = "Definir %";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(610, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 21);
            this.label7.TabIndex = 6;
            this.label7.Text = "Importe";
            // 
            // txt_base0_7
            // 
            this.txt_base0_7.Cursor = System.Windows.Forms.Cursors.No;
            this.txt_base0_7.Location = new System.Drawing.Point(19, 82);
            this.txt_base0_7.Name = "txt_base0_7";
            this.txt_base0_7.ReadOnly = true;
            this.txt_base0_7.Size = new System.Drawing.Size(95, 30);
            this.txt_base0_7.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb_exento);
            this.groupBox1.Controls.Add(this.rb_dieciseis);
            this.groupBox1.Controls.Add(this.rb_cero);
            this.groupBox1.Controls.Add(this.rb_ocho);
            this.groupBox1.Location = new System.Drawing.Point(132, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(427, 54);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Impuesto al valor agregado";
            // 
            // rb_exento
            // 
            this.rb_exento.AutoSize = true;
            this.rb_exento.Location = new System.Drawing.Point(323, 23);
            this.rb_exento.Name = "rb_exento";
            this.rb_exento.Size = new System.Drawing.Size(136, 25);
            this.rb_exento.TabIndex = 13;
            this.rb_exento.Text = "IVA Exento";
            this.rb_exento.UseVisualStyleBackColor = true;
            this.rb_exento.CheckedChanged += new System.EventHandler(this.radio_impuest_exento);
            // 
            // rb_dieciseis
            // 
            this.rb_dieciseis.AutoSize = true;
            this.rb_dieciseis.Location = new System.Drawing.Point(218, 23);
            this.rb_dieciseis.Name = "rb_dieciseis";
            this.rb_dieciseis.Size = new System.Drawing.Size(109, 25);
            this.rb_dieciseis.TabIndex = 14;
            this.rb_dieciseis.Text = "IVA 16%";
            this.rb_dieciseis.UseVisualStyleBackColor = true;
            this.rb_dieciseis.CheckedChanged += new System.EventHandler(this.radio_impuest_16);
            // 
            // rb_cero
            // 
            this.rb_cero.AutoSize = true;
            this.rb_cero.Location = new System.Drawing.Point(26, 23);
            this.rb_cero.Name = "rb_cero";
            this.rb_cero.Size = new System.Drawing.Size(99, 25);
            this.rb_cero.TabIndex = 13;
            this.rb_cero.Text = "IVA 0%";
            this.rb_cero.UseVisualStyleBackColor = true;
            this.rb_cero.CheckedChanged += new System.EventHandler(this.radio_impuest_0);
            // 
            // rb_ocho
            // 
            this.rb_ocho.AutoSize = true;
            this.rb_ocho.Location = new System.Drawing.Point(121, 23);
            this.rb_ocho.Name = "rb_ocho";
            this.rb_ocho.Size = new System.Drawing.Size(99, 25);
            this.rb_ocho.TabIndex = 13;
            this.rb_ocho.Text = "IVA 8%";
            this.rb_ocho.UseVisualStyleBackColor = true;
            this.rb_ocho.CheckedChanged += new System.EventHandler(this.radio_impuest_8);
            // 
            // txt_importe0_6
            // 
            this.txt_importe0_6.Location = new System.Drawing.Point(576, 82);
            this.txt_importe0_6.Name = "txt_importe0_6";
            this.txt_importe0_6.ReadOnly = true;
            this.txt_importe0_6.Size = new System.Drawing.Size(119, 30);
            this.txt_importe0_6.TabIndex = 4;
            // 
            // btn_aceptar
            // 
            this.btn_aceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_aceptar.BackColor = System.Drawing.Color.Green;
            this.btn_aceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_aceptar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_aceptar.ForeColor = System.Drawing.Color.White;
            this.btn_aceptar.Location = new System.Drawing.Point(732, 286);
            this.btn_aceptar.Name = "btn_aceptar";
            this.btn_aceptar.Size = new System.Drawing.Size(110, 30);
            this.btn_aceptar.TabIndex = 11;
            this.btn_aceptar.Text = "Aceptar";
            this.btn_aceptar.UseVisualStyleBackColor = false;
            this.btn_aceptar.Click += new System.EventHandler(this.btn_aceptar_Click);
            // 
            // btn_agregar
            // 
            this.btn_agregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_agregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_agregar.Location = new System.Drawing.Point(753, 153);
            this.btn_agregar.Name = "btn_agregar";
            this.btn_agregar.Size = new System.Drawing.Size(89, 25);
            this.btn_agregar.TabIndex = 12;
            this.btn_agregar.Text = "Agregar fila";
            this.btn_agregar.UseVisualStyleBackColor = true;
            this.btn_agregar.Click += new System.EventHandler(this.btn_agregar_Click);
            // 
            // pnl_impuestos
            // 
            this.pnl_impuestos.AutoScroll = true;
            this.pnl_impuestos.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnl_impuestos.Location = new System.Drawing.Point(12, 153);
            this.pnl_impuestos.Name = "pnl_impuestos";
            this.pnl_impuestos.Size = new System.Drawing.Size(735, 120);
            this.pnl_impuestos.TabIndex = 13;
            this.pnl_impuestos.WrapContents = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(47, 132);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 21);
            this.label9.TabIndex = 14;
            this.label9.Text = "Base";
            // 
            // Complemento_pago_impuestos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 328);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.pnl_impuestos);
            this.Controls.Add(this.btn_agregar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_aceptar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_importe0_6);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_base0_7);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Complemento_pago_impuestos";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Impuestos";
            this.Load += new System.EventHandler(this.Complemento_pago_impuestos_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Complemento_pago_impuestos_Paint);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_base0_7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_importe0_6;
        private System.Windows.Forms.Button btn_aceptar;
        private System.Windows.Forms.Button btn_agregar;
        private System.Windows.Forms.RadioButton rb_cero;
        private System.Windows.Forms.RadioButton rb_ocho;
        private System.Windows.Forms.RadioButton rb_dieciseis;
        private System.Windows.Forms.RadioButton rb_exento;
        private System.Windows.Forms.FlowLayoutPanel pnl_impuestos;
        private System.Windows.Forms.Label label9;
    }
}