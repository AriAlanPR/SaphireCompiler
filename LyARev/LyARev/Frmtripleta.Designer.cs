namespace LyARev
{
    partial class Frmtripleta
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
            this.dgvtripleta = new System.Windows.Forms.DataGridView();
            this.DatoObjeto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatoFuente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvtripleta)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvtripleta
            // 
            this.dgvtripleta.AllowUserToDeleteRows = false;
            this.dgvtripleta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvtripleta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvtripleta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DatoObjeto,
            this.DatoFuente,
            this.Operador});
            this.dgvtripleta.Location = new System.Drawing.Point(12, 12);
            this.dgvtripleta.Name = "dgvtripleta";
            this.dgvtripleta.ReadOnly = true;
            this.dgvtripleta.Size = new System.Drawing.Size(418, 384);
            this.dgvtripleta.TabIndex = 0;
            // 
            // DatoObjeto
            // 
            this.DatoObjeto.HeaderText = "Dato Objeto";
            this.DatoObjeto.Name = "DatoObjeto";
            this.DatoObjeto.ReadOnly = true;
            // 
            // DatoFuente
            // 
            this.DatoFuente.HeaderText = "Dato Fuente";
            this.DatoFuente.Name = "DatoFuente";
            this.DatoFuente.ReadOnly = true;
            // 
            // Operador
            // 
            this.Operador.HeaderText = "Operador";
            this.Operador.Name = "Operador";
            this.Operador.ReadOnly = true;
            // 
            // Frmtripleta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 408);
            this.Controls.Add(this.dgvtripleta);
            this.Name = "Frmtripleta";
            this.Text = "TRIPLETA";
            this.Load += new System.EventHandler(this.Frmtripleta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvtripleta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvtripleta;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatoObjeto;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatoFuente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Operador;
    }
}