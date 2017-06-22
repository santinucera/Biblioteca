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
    public partial class NuevaEditorial : Form
    {
        public NuevaEditorial()
        {
            InitializeComponent();
        }

        public LibroEntreForms libroRecivido;
        public Stack<ElementoPila> pila;


        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        private void NuevaEditorial_Load(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click_1(object sender, EventArgs e)
        {
            Funciones.volver(pila, this);
        }

        private void btnAgregar_Click_2(object sender, EventArgs e)
        {
            Editorial unaEditorial = new Editorial();
            unaEditorial.nombre = txtNombre.Text;
            unaEditorial.id = txtCodigo.Text;
            int intRegsAffected = EditorialesManager.Insertar(unaEditorial);
            ElementoPila elemento = pila.Pop();
            if (elemento.nombreForm == "NuevoLibro")
            {
                pila.Push(elemento);
                Funciones.agregarParaLibro(pila, this);
            }
            else
            {
                pila.Push(elemento);
                DetalleEditorial formulario = new DetalleEditorial(unaEditorial.id, pila);
                Funciones.cambiarFormA(this, formulario);
            }
        }

        private void btnValidar_Click_1(object sender, EventArgs e)
        {
            string codMayuscula = txtCodigo.Text.ToUpper();
            if (txtCodigo.TextLength == 2 && FuncionesManager.esMayuscula(codMayuscula))
            {
                Editorial unaEditorial = EditorialesManager.ObtenerPorCodigo(codMayuscula);
                if (unaEditorial == null)
                {
                    lblValido.Text = "Es valido";
                    lblValido.Visible = true;
                    btnValidar.Enabled = false;
                    btnAgregar.Enabled = true;
                }
                else
                {
                    lblValido.Text = "Ya existe una editorial con ese codigo. Pruebe con otro";
                    lblValido.Visible = true;
                }
            }
            else
            {
                lblValido.Text = "El codigo debe ser 2 letras";
                lblValido.Visible = true;
            }
        }
    }
}
