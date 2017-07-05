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

namespace BibliotecaAEGU
{
    public partial class EditarLibro : Form
    {
        public EditarLibro()
        {
            InitializeComponent();
        }

        public Stack<ElementoPila> pila;
        public string codigo;
        public Libro unLibro;
        public Image imagenAnterior;

        public EditarLibro(string cod,Stack<ElementoPila> pil)
        {
            InitializeComponent();
            codigo = cod;
            pila = pil;
        }


        private void EditarLibro_Load(object sender, EventArgs e)
        {
            unLibro = LibrosManager.Obtener(codigo);
            txtPaginas.Text = unLibro.cantPaginas.ToString();
            txtTitulo.Text = unLibro.titulo;
            txtDescripcion.Text = unLibro.descripcion;

            lblAutor.Text = AutoresManager.ObtenerNombre(unLibro.idAutor);
            txtAnios.Text = unLibro.anioPublicacion.ToString();
            lblCategoria.Text = CategoriasManager.ObtenerNombre(unLibro.idCategoria);
            lblEditorial.Text = EditorialesManager.ObtenerNombre(unLibro.idEditorial);

            picLibro.ImageLocation = "C:/Users/Usuario/Desktop/Proyecto Biblioteca/BibliotecaAEGU/Imagenes/" + codigo + ".jpg";
            imagenAnterior = picLibro.Image;
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (unLibro.anioPublicacion.ToString() != txtAnios.Text)
            {
                if (!FuncionesManager.noEsVacio(txtAnios.Text))
                {
                    lblErrorAnio.Text = "El campo Año de Publicacion no puede ser vacio";
                    lblErrorAnio.Visible = true;
                }
                else if (!FuncionesManager.esNumero(txtAnios.Text))
                {
                    lblErrorAnio.Text = "El campo Año de Publicacion debe ser un numero";
                    lblErrorAnio.Visible = true;
                }
                int regsAffected = LibrosManager.Modificar("AnioPublicacion", txtAnios.Text, unLibro.codigo);
            }

            if (unLibro.descripcion != txtDescripcion.Text)
            {
                int regsAffected1 = LibrosManager.Modificar("Descripcion", txtDescripcion.Text, unLibro.codigo);
            }

            if (unLibro.cantPaginas.ToString() !=txtPaginas.Text )
            {
                if (!FuncionesManager.noEsVacio(txtPaginas.Text))
                {
                    lblErrorPaginas.Text = "El campo Cantidad de Paginas no puede ser vacio";
                    lblErrorPaginas.Visible = true;
                }
                else if (!FuncionesManager.esNumero(txtPaginas.Text))
                { 
                    lblErrorPaginas.Text = "El campo Cantidad de Paginas debe ser un numero";
                    lblErrorPaginas.Visible = true;                    
                }
                int regsAffected2 = LibrosManager.Modificar("CantPaginas", txtPaginas.Text, unLibro.codigo);
            }

            if (unLibro.titulo != txtTitulo.Text)
            {
                if (!FuncionesManager.noEsVacio(txtTitulo.Text))
                {
                    lblErrorTitulo.Text = "El campo Titulo no puede ser vacio";
                    lblErrorTitulo.Visible = true;
                }
                int regsAffected3 = LibrosManager.Modificar("Titulo", txtTitulo.Text, unLibro.codigo);
            }

            if (picLibro.Image != imagenAnterior)
            {
                picLibro.Image.Save("C:/Users/Usuario/Desktop/Proyecto Biblioteca/BibliotecaAEGU/Imagenes/Libros/" + unLibro.codigo + ".jpg");
            }
            
            Funciones.volver(pila, this);

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Funciones.volver(pila, this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Imagenes del Cliente";
            dialog.Filter = "JPeg Image|*.jpg";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                picLibro.ImageLocation = dialog.FileName;
            }
        }
    }
}
