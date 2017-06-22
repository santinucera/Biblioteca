using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibliotecaAEGU
{
    public partial class Agregar : Form
    {
        public Stack<ElementoPila> pila;

        public Agregar()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            NuevaCategoria formulario = new NuevaCategoria();
            ElementoPila elemento = new ElementoPila(this, this.Name, null,null,null);
            pila.Push(elemento);
            formulario.pila = pila;
            Funciones.cambiarFormA(this, formulario);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NuevoAutor formulario = new NuevoAutor();
            ElementoPila elemento = new ElementoPila(this, this.Name, null,null,null);
            pila.Push(elemento);
            formulario.pila = pila;
            Funciones.cambiarFormA(this, formulario);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NuevaEditorial formulario = new NuevaEditorial();
            ElementoPila elemento = new ElementoPila(this, this.Name, null,null,null);
            pila.Push(elemento);
            formulario.pila = pila;
            Funciones.cambiarFormA(this, formulario);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NuevoLibro formulario = new NuevoLibro();
            ElementoPila elemento = new ElementoPila(this, this.Name, null,null,null);
            pila.Push(elemento);
            formulario.pila = pila;
            Funciones.cambiarFormA(this, formulario);
        }

        private void Agregar_Load(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Funciones.volver(pila, this);
        }
    }
}
