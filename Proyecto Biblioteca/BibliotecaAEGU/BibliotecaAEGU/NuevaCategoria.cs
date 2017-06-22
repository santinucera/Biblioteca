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
    public partial class NuevaCategoria : Form
    {
        public NuevaCategoria()
        {
            InitializeComponent();
        }

        public LibroEntreForms libroRecivido;
        public Stack<ElementoPila> pila;

        private void btnValidar_Click(object sender, EventArgs e)
        {
            string codMayuscula = txtCodigo.Text.ToUpper();
            if (txtCodigo.TextLength == 2 && FuncionesManager.esMayuscula(codMayuscula))
            {
                Categoria unaCategoria = CategoriasManager.ObtenerPorCodigo(codMayuscula);
                if (unaCategoria == null)
                {
                    lblValido.Text = "Es valido";
                    lblValido.Visible = true;
                    btnValidar.Enabled = false;
                    btnAgregar.Enabled = true;
                }
                else
                {
                    lblValido.Text = "Ya existe una categoria con ese codigo. Pruebe con otro";
                    lblValido.Visible = true;
                }
            }
            else
            {
                lblValido.Text = "El codigo debe ser 2 letras";
                lblValido.Visible = true;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Categoria unaCategoria = new Categoria();
            unaCategoria.nombre = txtNombre.Text;
            unaCategoria.descripcion = txtDescripcion.Text;
            unaCategoria.id = txtCodigo.Text;
            int intRegsAffected = CategoriasManager.Insertar(unaCategoria);

            if (intRegsAffected > 0)
            {
                ElementoPila elemento = pila.Pop();
                if(elemento.nombreForm == "NuevoLibro")
                {
                    pila.Push(elemento);
                    Funciones.agregarParaLibro(pila, this);
                }
                else
                {
                    pila.Push(elemento);
                    DetalleCategoria formulario = new DetalleCategoria(unaCategoria.id, pila);
                    Funciones.cambiarFormA(this, formulario);
                }
            }
        }

        private void NuevaCategoria_Load(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Funciones.volver(pila, this);
        }
    }
}
