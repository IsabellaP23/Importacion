namespace Importacion
{
    partial class FrmInicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dtgDatos = new System.Windows.Forms.DataGridView();
            this.btnCargarArchivo = new System.Windows.Forms.Button();
            this.btnGuardarDB = new System.Windows.Forms.Button();
            this.txtNombreTabla = new System.Windows.Forms.TextBox();
            this.lblNombreTabla = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgDatos
            // 
            this.dtgDatos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(232)))), ((int)(((byte)(220)))));
            this.dtgDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDatos.Location = new System.Drawing.Point(36, 141);
            this.dtgDatos.Name = "dtgDatos";
            this.dtgDatos.RowHeadersWidth = 51;
            this.dtgDatos.RowTemplate.Height = 24;
            this.dtgDatos.Size = new System.Drawing.Size(935, 330);
            this.dtgDatos.TabIndex = 0;
            // 
            // btnCargarArchivo
            // 
            this.btnCargarArchivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(124)))), ((int)(((byte)(112)))));
            this.btnCargarArchivo.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarArchivo.Location = new System.Drawing.Point(36, 82);
            this.btnCargarArchivo.Name = "btnCargarArchivo";
            this.btnCargarArchivo.Size = new System.Drawing.Size(158, 43);
            this.btnCargarArchivo.TabIndex = 0;
            this.btnCargarArchivo.Text = "Cargar archivo";
            this.btnCargarArchivo.UseVisualStyleBackColor = false;
            this.btnCargarArchivo.Click += new System.EventHandler(this.btnCargarArchivo_Click);
            // 
            // btnGuardarDB
            // 
            this.btnGuardarDB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(124)))), ((int)(((byte)(112)))));
            this.btnGuardarDB.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarDB.Location = new System.Drawing.Point(829, 507);
            this.btnGuardarDB.Name = "btnGuardarDB";
            this.btnGuardarDB.Size = new System.Drawing.Size(142, 43);
            this.btnGuardarDB.TabIndex = 2;
            this.btnGuardarDB.Text = "Guardar";
            this.btnGuardarDB.UseVisualStyleBackColor = false;
            this.btnGuardarDB.Click += new System.EventHandler(this.btnGuardarDB_Click);
            // 
            // txtNombreTabla
            // 
            this.txtNombreTabla.Font = new System.Drawing.Font("Mongolian Baiti", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreTabla.Location = new System.Drawing.Point(495, 528);
            this.txtNombreTabla.Name = "txtNombreTabla";
            this.txtNombreTabla.Size = new System.Drawing.Size(234, 25);
            this.txtNombreTabla.TabIndex = 1;
            // 
            // lblNombreTabla
            // 
            this.lblNombreTabla.AutoSize = true;
            this.lblNombreTabla.Font = new System.Drawing.Font("Mongolian Baiti", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreTabla.Location = new System.Drawing.Point(492, 507);
            this.lblNombreTabla.Name = "lblNombreTabla";
            this.lblNombreTabla.Size = new System.Drawing.Size(221, 19);
            this.lblNombreTabla.TabIndex = 3;
            this.lblNombreTabla.Text = "Inserte el nombre de la tabla:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(87)))), ((int)(((byte)(82)))));
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(333, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(357, 40);
            this.label1.TabIndex = 4;
            this.label1.Text = "Importación de Datos";
            // 
            // FrmInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(180)))), ((int)(((byte)(134)))));
            this.ClientSize = new System.Drawing.Size(1011, 571);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNombreTabla);
            this.Controls.Add(this.txtNombreTabla);
            this.Controls.Add(this.btnGuardarDB);
            this.Controls.Add(this.btnCargarArchivo);
            this.Controls.Add(this.dtgDatos);
            this.Name = "FrmInicio";
            this.Text = "Inicio";
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dtgDatos;
        private System.Windows.Forms.Button btnCargarArchivo;
        private System.Windows.Forms.Button btnGuardarDB;
        private System.Windows.Forms.TextBox txtNombreTabla;
        private System.Windows.Forms.Label lblNombreTabla;
        private System.Windows.Forms.Label label1;
    }
}

