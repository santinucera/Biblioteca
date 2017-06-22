namespace BibliotecaAEGU
{
    partial class NuevoLibro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NuevoLibro));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPaginas = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAnios = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.picLibro = new System.Windows.Forms.PictureBox();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.cmbAutor = new System.Windows.Forms.ComboBox();
            this.cmbEditorial = new System.Windows.Forms.ComboBox();
            this.lblErrorTitulo = new System.Windows.Forms.Label();
            this.lblErrorAutor = new System.Windows.Forms.Label();
            this.lblErroCategoria = new System.Windows.Forms.Label();
            this.lblErrorEditorial = new System.Windows.Forms.Label();
            this.lblErrorAnio = new System.Windows.Forms.Label();
            this.lblErrorPaginas = new System.Windows.Forms.Label();
            this.btnNuevoAutor = new System.Windows.Forms.Button();
            this.btnNuevaCategoria = new System.Windows.Forms.Button();
            this.btnNuevaEditorial = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picLibro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SandyBrown;
            this.button1.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(545, 323);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 64);
            this.button1.TabIndex = 0;
            this.button1.Text = "Agregar Libro";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(58, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Titulo:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(205, 335);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(225, 51);
            this.txtDescripcion.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(58, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Autor:";
            // 
            // txtPaginas
            // 
            this.txtPaginas.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaginas.Location = new System.Drawing.Point(205, 294);
            this.txtPaginas.Name = "txtPaginas";
            this.txtPaginas.Size = new System.Drawing.Size(100, 23);
            this.txtPaginas.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(58, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Categoria:";
            // 
            // txtAnios
            // 
            this.txtAnios.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnios.Location = new System.Drawing.Point(205, 250);
            this.txtAnios.Name = "txtAnios";
            this.txtAnios.Size = new System.Drawing.Size(100, 23);
            this.txtAnios.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(58, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Editorial";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(58, 250);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "Año de publicacion:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(58, 294);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 15);
            this.label6.TabIndex = 1;
            this.label6.Text = "Cantidad de paginas:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(58, 335);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 15);
            this.label7.TabIndex = 1;
            this.label7.Text = "Descripcion";
            // 
            // txtTitulo
            // 
            this.txtTitulo.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitulo.Location = new System.Drawing.Point(205, 61);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(192, 23);
            this.txtTitulo.TabIndex = 2;
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(205, 156);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(148, 23);
            this.cmbCategoria.TabIndex = 5;
            // 
            // picLibro
            // 
            this.picLibro.Location = new System.Drawing.Point(530, 39);
            this.picLibro.Name = "picLibro";
            this.picLibro.Size = new System.Drawing.Size(160, 140);
            this.picLibro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLibro.TabIndex = 6;
            this.picLibro.TabStop = false;
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.BackColor = System.Drawing.Color.SandyBrown;
            this.btnSeleccionar.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionar.Location = new System.Drawing.Point(575, 195);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(85, 46);
            this.btnSeleccionar.TabIndex = 7;
            this.btnSeleccionar.Text = "Seleccionar foto";
            this.btnSeleccionar.UseVisualStyleBackColor = false;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // cmbAutor
            // 
            this.cmbAutor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAutor.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAutor.FormattingEnabled = true;
            this.cmbAutor.Location = new System.Drawing.Point(205, 112);
            this.cmbAutor.Name = "cmbAutor";
            this.cmbAutor.Size = new System.Drawing.Size(148, 23);
            this.cmbAutor.TabIndex = 8;
            // 
            // cmbEditorial
            // 
            this.cmbEditorial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEditorial.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEditorial.FormattingEnabled = true;
            this.cmbEditorial.Location = new System.Drawing.Point(205, 199);
            this.cmbEditorial.Name = "cmbEditorial";
            this.cmbEditorial.Size = new System.Drawing.Size(148, 23);
            this.cmbEditorial.TabIndex = 9;
            // 
            // lblErrorTitulo
            // 
            this.lblErrorTitulo.AutoSize = true;
            this.lblErrorTitulo.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorTitulo.ForeColor = System.Drawing.Color.Red;
            this.lblErrorTitulo.Location = new System.Drawing.Point(319, 62);
            this.lblErrorTitulo.Name = "lblErrorTitulo";
            this.lblErrorTitulo.Size = new System.Drawing.Size(0, 15);
            this.lblErrorTitulo.TabIndex = 10;
            this.lblErrorTitulo.Visible = false;
            this.lblErrorTitulo.Click += new System.EventHandler(this.label8_Click);
            // 
            // lblErrorAutor
            // 
            this.lblErrorAutor.AutoSize = true;
            this.lblErrorAutor.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorAutor.ForeColor = System.Drawing.Color.Red;
            this.lblErrorAutor.Location = new System.Drawing.Point(319, 114);
            this.lblErrorAutor.Name = "lblErrorAutor";
            this.lblErrorAutor.Size = new System.Drawing.Size(0, 15);
            this.lblErrorAutor.TabIndex = 10;
            this.lblErrorAutor.Visible = false;
            this.lblErrorAutor.Click += new System.EventHandler(this.label8_Click);
            // 
            // lblErroCategoria
            // 
            this.lblErroCategoria.AutoSize = true;
            this.lblErroCategoria.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErroCategoria.ForeColor = System.Drawing.Color.Red;
            this.lblErroCategoria.Location = new System.Drawing.Point(319, 158);
            this.lblErroCategoria.Name = "lblErroCategoria";
            this.lblErroCategoria.Size = new System.Drawing.Size(0, 15);
            this.lblErroCategoria.TabIndex = 10;
            this.lblErroCategoria.Visible = false;
            this.lblErroCategoria.Click += new System.EventHandler(this.label8_Click);
            // 
            // lblErrorEditorial
            // 
            this.lblErrorEditorial.AutoSize = true;
            this.lblErrorEditorial.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorEditorial.ForeColor = System.Drawing.Color.Red;
            this.lblErrorEditorial.Location = new System.Drawing.Point(319, 204);
            this.lblErrorEditorial.Name = "lblErrorEditorial";
            this.lblErrorEditorial.Size = new System.Drawing.Size(0, 15);
            this.lblErrorEditorial.TabIndex = 10;
            this.lblErrorEditorial.Visible = false;
            this.lblErrorEditorial.Click += new System.EventHandler(this.label8_Click);
            // 
            // lblErrorAnio
            // 
            this.lblErrorAnio.AutoSize = true;
            this.lblErrorAnio.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorAnio.ForeColor = System.Drawing.Color.Red;
            this.lblErrorAnio.Location = new System.Drawing.Point(319, 252);
            this.lblErrorAnio.Name = "lblErrorAnio";
            this.lblErrorAnio.Size = new System.Drawing.Size(0, 15);
            this.lblErrorAnio.TabIndex = 10;
            this.lblErrorAnio.Visible = false;
            this.lblErrorAnio.Click += new System.EventHandler(this.label8_Click);
            // 
            // lblErrorPaginas
            // 
            this.lblErrorPaginas.AutoSize = true;
            this.lblErrorPaginas.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorPaginas.ForeColor = System.Drawing.Color.Red;
            this.lblErrorPaginas.Location = new System.Drawing.Point(319, 296);
            this.lblErrorPaginas.Name = "lblErrorPaginas";
            this.lblErrorPaginas.Size = new System.Drawing.Size(0, 15);
            this.lblErrorPaginas.TabIndex = 10;
            this.lblErrorPaginas.Visible = false;
            this.lblErrorPaginas.Click += new System.EventHandler(this.label8_Click);
            // 
            // btnNuevoAutor
            // 
            this.btnNuevoAutor.BackColor = System.Drawing.Color.SandyBrown;
            this.btnNuevoAutor.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoAutor.Location = new System.Drawing.Point(386, 108);
            this.btnNuevoAutor.Name = "btnNuevoAutor";
            this.btnNuevoAutor.Size = new System.Drawing.Size(75, 23);
            this.btnNuevoAutor.TabIndex = 11;
            this.btnNuevoAutor.Text = "Nuevo";
            this.btnNuevoAutor.UseVisualStyleBackColor = false;
            this.btnNuevoAutor.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnNuevaCategoria
            // 
            this.btnNuevaCategoria.BackColor = System.Drawing.Color.SandyBrown;
            this.btnNuevaCategoria.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaCategoria.Location = new System.Drawing.Point(386, 154);
            this.btnNuevaCategoria.Name = "btnNuevaCategoria";
            this.btnNuevaCategoria.Size = new System.Drawing.Size(75, 23);
            this.btnNuevaCategoria.TabIndex = 11;
            this.btnNuevaCategoria.Text = "Nueva";
            this.btnNuevaCategoria.UseVisualStyleBackColor = false;
            this.btnNuevaCategoria.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnNuevaEditorial
            // 
            this.btnNuevaEditorial.BackColor = System.Drawing.Color.SandyBrown;
            this.btnNuevaEditorial.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaEditorial.Location = new System.Drawing.Point(386, 200);
            this.btnNuevaEditorial.Name = "btnNuevaEditorial";
            this.btnNuevaEditorial.Size = new System.Drawing.Size(75, 23);
            this.btnNuevaEditorial.TabIndex = 11;
            this.btnNuevaEditorial.Text = "Nueva";
            this.btnNuevaEditorial.UseVisualStyleBackColor = false;
            this.btnNuevaEditorial.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.SandyBrown;
            this.btnVolver.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.Location = new System.Drawing.Point(246, 421);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(190, 23);
            this.btnVolver.TabIndex = 12;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BibliotecaAEGU.Properties.Resources.LogoBig;
            this.pictureBox1.Location = new System.Drawing.Point(577, 408);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // NuevoLibro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(719, 456);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnNuevaEditorial);
            this.Controls.Add(this.btnNuevaCategoria);
            this.Controls.Add(this.btnNuevoAutor);
            this.Controls.Add(this.lblErrorPaginas);
            this.Controls.Add(this.lblErrorAnio);
            this.Controls.Add(this.lblErrorEditorial);
            this.Controls.Add(this.lblErroCategoria);
            this.Controls.Add(this.lblErrorAutor);
            this.Controls.Add(this.lblErrorTitulo);
            this.Controls.Add(this.cmbEditorial);
            this.Controls.Add(this.cmbAutor);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.picLibro);
            this.Controls.Add(this.cmbCategoria);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAnios);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPaginas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NuevoLibro";
            this.Text = "Biblioteca AEGU";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLibro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPaginas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAnios;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.PictureBox picLibro;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.ComboBox cmbAutor;
        private System.Windows.Forms.ComboBox cmbEditorial;
        private System.Windows.Forms.Label lblErrorTitulo;
        private System.Windows.Forms.Label lblErrorAutor;
        private System.Windows.Forms.Label lblErroCategoria;
        private System.Windows.Forms.Label lblErrorEditorial;
        private System.Windows.Forms.Label lblErrorAnio;
        private System.Windows.Forms.Label lblErrorPaginas;
        private System.Windows.Forms.Button btnNuevoAutor;
        private System.Windows.Forms.Button btnNuevaCategoria;
        private System.Windows.Forms.Button btnNuevaEditorial;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}