using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Managers.Models;
using Managers.Managers;
using System.IO;

namespace BibliotecaAEGU
{
    public partial class DetalleLibro : Form
    {
        public DetalleLibro()
        {
            InitializeComponent();
        }

        public string codigo;
        public string idAutor; 
        public string idEditorial;
        public string idCategoria;

        public Stack<ElementoPila> pila;

        public DetalleLibro(string cod, Stack<ElementoPila> pil)
        {
            InitializeComponent();
            codigo = cod;
            pila = pil;
        }

        private void DetalleLibro_Load(object sender, EventArgs e)
        {
            Libro unLibro = LibrosManager.Obtener(codigo);
            lblPaginas.Text = unLibro.cantPaginas.ToString();
            lblTitulo.Text = unLibro.titulo;
            lblDescripcion.Text = unLibro.descripcion;

            lblAutor.Text = AutoresManager.ObtenerNombre(unLibro.idAutor);
            lblAnios.Text = unLibro.anioPublicacion.ToString();
            lblCategoria.Text = CategoriasManager.ObtenerNombre(unLibro.idCategoria);
            lblEditorial.Text = EditorialesManager.ObtenerNombre(unLibro.idEditorial);
            lblCodigo.Text = unLibro.codigo;

            picLibro.ImageLocation = ("C:/Users/Usuario/Desktop/Proyecto Biblioteca/BibliotecaAEGU/Imagenes/Libros/" + codigo + ".jpg");

            idAutor = unLibro.idAutor;
            idEditorial= unLibro.idEditorial;
            idCategoria = unLibro.idCategoria;

        }

        private void lblPaginas_Click(object sender, EventArgs e)
        {

        }

        private void picLibro_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LibroEntreForms unLibro = new LibroEntreForms(lblTitulo.Text,lblEditorial.Text,lblCategoria.Text,lblAutor.Text,lblPaginas.Text,lblDescripcion.Text,lblAnios.Text,lblCodigo.Text,null);
            
            EditarLibro formulario = new EditarLibro();
            ElementoPila elemento = new ElementoPila(this, this.Name, null, codigo, null);
            pila.Push(elemento);
            formulario.codigo = codigo;
            formulario.pila = pila;
            Funciones.cambiarFormA(this, formulario);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            File.Delete("C: /Users/Usuario/Desktop/Proyecto Biblioteca/BibliotecaAEGU/Imagenes/Libro/" + codigo + ".jpg");
            int intRegsAff = LibrosManager.EliminarLibro(codigo);
            Funciones.volver(pila, this);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Funciones.volver(pila, this);
        }

        private void btnAutor_Click(object sender, EventArgs e)
        {
            DetalleAutor formulario = new DetalleAutor();
            ElementoPila elemento = new ElementoPila(this, this.Name, null, codigo, null);
            formulario.codigo = idAutor;
            pila.Push(elemento);
            formulario.pila = pila;
            Funciones.cambiarFormA(this, formulario);
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            DetalleCategoria formulario = new DetalleCategoria();
            formulario.codigo = idCategoria;
            ElementoPila elemento = new ElementoPila(this, this.Name, null, codigo, null);
            pila.Push(elemento);
            formulario.pila = pila;
            Funciones.cambiarFormA(this, formulario);
        }

        private void btnEditorial_Click(object sender, EventArgs e)
        {
            DetalleEditorial formulario = new DetalleEditorial();
            formulario.codigo = idEditorial;
            ElementoPila elemento = new ElementoPila(this, this.Name, null, codigo, null);
            pila.Push(elemento);
            formulario.pila = pila;
            Funciones.cambiarFormA(this, formulario);
        }
    }
    
}
