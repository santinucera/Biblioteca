
using Managers.Managers;
using Managers.Models;
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
    public partial class DetalleEditorial : Form
    {
        public DetalleEditorial()
        {
            InitializeComponent();
        }

        public string codigo;
        public Stack<ElementoPila> pila;


        public DetalleEditorial(string cod, Stack<ElementoPila> pil)
        {
            InitializeComponent();
            codigo = cod;
            pila = pil;
        }

        private void DetalleEditorial_Load(object sender, EventArgs e)
        {
            Editorial unaEditorial = EditorialesManager.ObtenerPorCodigo(codigo);
            lblCodigo.Text = codigo;
            lblNombre.Text = unaEditorial.nombre;

            List<Libro> listaLibros = new List<Managers.Models.Libro>();
            listaLibros = EditorialesManager.ObtenerLibros(codigo);

            foreach (Libro item in listaLibros)
            {
                Autor autor = AutoresManager.ObtenerPorCodigo(item.idAutor);
                Editorial editorial = EditorialesManager.ObtenerPorCodigo(item.idEditorial);
                Categoria categoria = CategoriasManager.ObtenerPorCodigo(item.idCategoria);
                dgvLibros.Rows.Add(item.codigo, item.titulo, autor.nombre, editorial.nombre, categoria.nombre, "Ver libro");

            }
            dgvLibros.Visible = true;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Funciones.volver(pila, this);
        }

        private void dgvLibros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int? fila = dgvLibros.CurrentCell.RowIndex;
            if (fila != null)
            {
                DetalleLibro formulario = new DetalleLibro();
                formulario.codigo = dgvLibros.Rows[fila.Value].Cells[1].Value.ToString();
                ElementoPila elemento = new ElementoPila(this, this.Name, null, codigo, null);
                pila.Push(elemento);
                formulario.pila = pila;
                Funciones.cambiarFormA(this, formulario);
            }
        }
    }
}
