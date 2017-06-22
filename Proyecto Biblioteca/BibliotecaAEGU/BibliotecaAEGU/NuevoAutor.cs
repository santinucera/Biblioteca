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
    public partial class NuevoAutor : Form
    {
        public NuevoAutor()
        {
            InitializeComponent();
        }

        public LibroEntreForms libroRecivido;
        public Stack<ElementoPila> pila;

        private void NuevoAutor_Load(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click_1(object sender, EventArgs e)
        {
            Funciones.volver(pila, this);
        }

        private void btnValidar_Click_1(object sender, EventArgs e)
        {
            string codMayuscula = txtCodigo.Text.ToUpper();
            if (txtCodigo.TextLength == 2 && FuncionesManager.esMayuscula(codMayuscula))
            {
                Autor unAutor = AutoresManager.ObtenerPorCodigo(codMayuscula);
                if (unAutor == null)
                {
                    lblValido.Text = "Es valido";
                    lblValido.Visible = true;
                    btnValidar.Enabled = false;
                    btnAgregar.Enabled = true;
                }
                else
                {
                    lblValido.Text = "Ya existe un autor con ese codigo. Pruebe con otro";
                    lblValido.Visible = true;
                }
            }
            else
            {
                lblValido.Text = "El codigo debe ser 2 letras";
                lblValido.Visible = true;
            }
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            Autor unAutor = new Autor();
            unAutor.nombre = txtNombre.Text;
            unAutor.id = txtCodigo.Text;
            int intRegsAffected = AutoresManager.Insertar(unAutor);

            if (intRegsAffected > 0)
            {
                ElementoPila elemento = pila.Pop();
                if (elemento.nombreForm == "NuevoLibro")
                {
                    pila.Push(elemento);
                    Funciones.agregarParaLibro(pila, this);
                }
                else
                {
                    DetalleAutor formulario = new DetalleAutor(unAutor.id,pila);
                    pila.Push(elemento);
                    Funciones.cambiarFormA(this, formulario);
                }

            }
        }
    }
}
