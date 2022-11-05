﻿
namespace PuntoDeVentaV2
{
    partial class SugerenciasGoogle
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DGVSugerencias = new System.Windows.Forms.DataGridView();
            this.Sugerencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Agregar = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGVSugerencias)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVSugerencias
            // 
            this.DGVSugerencias.AllowUserToAddRows = false;
            this.DGVSugerencias.AllowUserToDeleteRows = false;
            this.DGVSugerencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVSugerencias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sugerencia,
            this.Agregar});
            this.DGVSugerencias.Location = new System.Drawing.Point(30, 38);
            this.DGVSugerencias.Name = "DGVSugerencias";
            this.DGVSugerencias.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVSugerencias.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGVSugerencias.RowHeadersVisible = false;
            this.DGVSugerencias.RowHeadersWidth = 62;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DGVSugerencias.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DGVSugerencias.RowTemplate.Height = 28;
            this.DGVSugerencias.Size = new System.Drawing.Size(555, 264);
            this.DGVSugerencias.TabIndex = 0;
            this.DGVSugerencias.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVSugerencias_CellClick);
            this.DGVSugerencias.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVSugerencias_CellMouseEnter);
            this.DGVSugerencias.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVSugerencias_CellMouseLeave);
            // 
            // Sugerencia
            // 
            this.Sugerencia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sugerencia.DefaultCellStyle = dataGridViewCellStyle1;
            this.Sugerencia.HeaderText = "SUGERENCIA";
            this.Sugerencia.MinimumWidth = 8;
            this.Sugerencia.Name = "Sugerencia";
            this.Sugerencia.ReadOnly = true;
            // 
            // Agregar
            // 
            this.Agregar.HeaderText = "";
            this.Agregar.MinimumWidth = 8;
            this.Agregar.Name = "Agregar";
            this.Agregar.ReadOnly = true;
            this.Agregar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Agregar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // SugerenciasGoogle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 330);
            this.Controls.Add(this.DGVSugerencias);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SugerenciasGoogle";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SUGERENCIAS";
            this.Load += new System.EventHandler(this.SugerenciasGoogle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVSugerencias)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVSugerencias;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sugerencia;
        private System.Windows.Forms.DataGridViewImageColumn Agregar;
    }
}