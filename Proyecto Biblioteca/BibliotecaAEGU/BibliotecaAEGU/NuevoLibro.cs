using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Managers.Models;
using Managers.Managers;

namespace BibliotecaAEGU
{
    public partial class NuevoLibro : Form
    {
        public NuevoLibro()
        {
            InitializeComponent();
        }

         
        public Stack<ElementoPila> pila;
        public string ubicacionImagen;

        private void button1_Click(object sender, EventArgs e)
        {
            lblErrorTitulo.Visible = false;
            lblErrorPaginas.Visible = false;
            lblErrorEditorial.Visible = false;
            lblErrorAutor.Visible = false;
            lblErrorAnio.Visible = false;
            lblErroCategoria.Visible = false;

           
            bool anioValido = FuncionesManager.esNumero(txtAnios.Text) && FuncionesManager.noEsVacio(txtAnios.Text);
            bool paginaValido = FuncionesManager.esNumero(txtPaginas.Text) && FuncionesManager.noEsVacio(txtPaginas.Text);
            bool tituloValido = FuncionesManager.noEsVacio(txtTitulo.Text);
            bool autorValido = FuncionesManager.noEsVacio(cmbAutor.Text);
            bool editorialValida = FuncionesManager.noEsVacio(cmbEditorial.Text);
            bool categoriaValida = FuncionesManager.noEsVacio(cmbCategoria.Text);


            if (anioValido && paginaValido && tituloValido && autorValido && categoriaValida && editorialValida)
            {
                
                string codCategoria = FuncionesManager.obtenerCodigo(cmbCategoria.Text);
                string codEditorial = FuncionesManager.obtenerCodigo(cmbEditorial.Text);
                string codAutor = FuncionesManager.obtenerCodigo(cmbAutor.Text);

                Libro nuevoLibro = new Libro();
                nuevoLibro.codigo = LibrosManager.CrearCodigo(codCategoria,codAutor,codEditorial);
                nuevoLibro.titulo = txtTitulo.Text;
                nuevoLibro.cantPaginas = Convert.ToInt32(txtPaginas.Text);
                nuevoLibro.anioPublicacion = Convert.ToInt32(txtAnios.Text);
                nuevoLibro.idAutor = codAutor;
                nuevoLibro.descripcion = txtDescripcion.Text;
                nuevoLibro.idEditorial = codEditorial;
                nuevoLibro.idCategoria = codCategoria;

                int intRegistrosAfectados = LibrosManager.Insertar(nuevoLibro);

                if (intRegistrosAfectados > 0)
                {

                    if (picLibro.Image != null)
                    {
                        ubicacionImagen = "C:/Users/Usuario/Desktop/Proyecto Biblioteca/BibliotecaAEGU/Imagenes/Libros/" + nuevoLibro.codigo + ".jpg";
                        picLibro.Image.Save(ubicacionImagen);
                    }

                    DetalleLibro formi = new DetalleLibro();
                    formi.codigo = nuevoLibro.codigo;
                    formi.pila = pila;
                    Funciones.cambiarFormA(this, formi);
                }
            }
            else
            {
                if(!FuncionesManager.noEsVacio(txtTitulo.Text))
                {
                    lblErrorTitulo.Text = "El campo Titulo no puede ser vacio";
                    lblErrorTitulo.Visible = true;
                }

                if (!FuncionesManager.noEsVacio(cmbAutor.Text))
                {
                    lblErrorAutor.Text = "El campo Autor no puede ser vacio";
                    lblErrorAutor.Visible = true;
                }

                if (!FuncionesManager.noEsVacio(cmbCategoria.Text))
                {
                    lblErroCategoria.Text = "El campo Categoria no puede ser vacio";
                    lblErroCategoria.Visible = true;
                }

                if (!FuncionesManager.noEsVacio(cmbEditorial.Text))
                {
                    lblErrorEditorial.Text = "El campo Editorial no puede ser vacio";
                    lblErrorEditorial.Visible = true;
                }

                if (!FuncionesManager.noEsVacio(txtAnios.Text))
                {
                    lblErrorAnio.Text = "El campo Año de Publicacion no puede ser vacio";
                    lblErrorAnio.Visible = true;
                }
                else
                {
                    if (!FuncionesManager.esNumero(txtAnios.Text))
                    {
                        lblErrorAnio.Text = "El campo Año de Publicacion debe ser un numero";
                        lblErrorAnio.Visible = true;
                    }
                }

                if (!FuncionesManager.noEsVacio(txtPaginas.Text))
                {
                    lblErrorPaginas.Text = "El campo Cantidad de Paginas no puede ser vacio";
                    lblErrorPaginas.Visible = true;
                }
                else
                {
                    if (!FuncionesManager.esNumero(txtPaginas.Text))
                    {
                        lblErrorPaginas.Text = "El campo Cantidad de Paginas debe ser un numero";
                        lblErrorPaginas.Visible = true;
                    }
                }

                

                

            }



        }

        private void Form3_Load(object sender, EventArgs e)
        {
            List<Categoria> listaCategorias = CategoriasManager.ObtenerTodos();

            foreach (Categoria item in listaCategorias)
            {
                string textoListBox = item.nombre + " (" + item.id + ")";
                cmbCategoria.Items.Add(textoListBox);
            }

            List<Autor> listaAutor = AutoresManager.ObtenerTodos();

            foreach (Autor item in listaAutor)
            {
                string textoListBox = item.nombre + " (" + item.id + ")";
                cmbAutor.Items.Add(textoListBox);
            }

            List<Editorial> listaEditorial = EditorialesManager.ObtenerTodos();

            foreach (Editorial item in listaEditorial)
            {
                string textoListBox = item.nombre + " (" + item.id + ")";
                cmbEditorial.Items.Add(textoListBox);
            }

            ElementoPila elemento = pila.Pop();
            if(elemento.nombreForm == "NuevaCategoria" || elemento.nombreForm == "NuevoAutor" || elemento.nombreForm == "NuevaEditorial")
            {
                txtAnios.Text = elemento.libro.anios;
                txtPaginas.Text = elemento.libro.paginas;
                cmbAutor.Text = elemento.libro.autor;
                cmbCategoria.Text = elemento.libro.categoria;
                cmbEditorial.Text = elemento.libro.editorial;
                txtTitulo.Text = elemento.libro.titulo;
                txtDescripcion.Text = elemento.libro.descripcion;
                picLibro.ImageLocation = elemento.libro.ubicacioImagen;
            }
            else
            {
                pila.Push(elemento);
            }
        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            NuevaCategoria formulario = new NuevaCategoria();
            Funciones.cambiarFormA(this, formulario);
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Imagenes del Cliente";
            dialog.Filter = "JPeg Image|*.jpg";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                picLibro.ImageLocation = dialog.FileName;
            }
            ubicacionImagen = picLibro.ImageLocation;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            LibroEntreForms unLibro = new LibroEntreForms(txtTitulo.Text,cmbEditorial.Text,cmbCategoria.Text,null,txtPaginas.Text,txtDescripcion.Text,txtAnios.Text,null,ubicacionImagen);
            NuevoAutor formulario = new BibliotecaAEGU.NuevoAutor();
            ElementoPila elemento = new ElementoPila(this, this.Name, unLibro, null,null);
            pila.Push(elemento);
            formulario.pila = pila;
            Funciones.cambiarFormA(this, formulario);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LibroEntreForms unLibro = new LibroEntreForms(txtTitulo.Text,cmbEditorial.Text,null,cmbAutor.Text,txtPaginas.Text,txtDescripcion.Text,txtAnios.Text, null,ubicacionImagen);
            NuevaCategoria formulario = new NuevaCategoria();
            ElementoPila elemento = new ElementoPila(this, this.Name, unLibro, null,null);
            pila.Push(elemento);
            formulario.pila = pila;
            Funciones.cambiarFormA(this, formulario);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LibroEntreForms unLibro = new LibroEntreForms(txtTitulo.Text,null ,cmbCategoria.Text,cmbAutor.Text,txtPaginas.Text,txtDescripcion.Text,txtAnios.Text,null ,ubicacionImagen);
            NuevaEditorial formulario = new NuevaEditorial();
            ElementoPila elemento = new ElementoPila(this, this.Name, unLibro, null,null);
            pila.Push(elemento); 
            formulario.pila = pila;
            Funciones.cambiarFormA(this, formulario);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Funciones.volver(pila, this);
        }
    }
}


