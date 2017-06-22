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
    public partial class QueHacer : Form
    {
        public QueHacer()
        {
            InitializeComponent();
        }

        public Stack<ElementoPila> pila;

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void QueHacer_Load(object sender, EventArgs e)
        {

        }

        private Stack<ElementoPila> crearPila(Form formActual)
        {
            Stack<ElementoPila> pila = new Stack<ElementoPila>();
            ElementoPila elemento = new ElementoPila(this, this.Name, null, null,null);
            pila.Push(elemento);
            return pila;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Agregar formulario = new Agregar();
            formulario.pila = crearPila(this);
            Funciones.cambiarFormA(this, formulario);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscador formulario = new Buscador();
            formulario.pila = crearPila(this);
            Funciones.cambiarFormA(this, formulario);
        }
    }
}
