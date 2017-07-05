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
    public partial class Buscador : Form
    {
        public Buscador()
        {
            InitializeComponent();
        }

        public string busqueda;
        public Stack<ElementoPila> pila;

        public Buscador(string bus, Stack<ElementoPila> pil)
        {
            InitializeComponent();
            busqueda = bus;
            pila = pil;
        }

        private void Buscador_Load(object sender, EventArgs e)
        {
            cmbOpciones.SelectedIndex = 0;
            if (busqueda != null)
            {
                List<Libro> listaLibros = new List<Managers.Models.Libro>();
                listaLibros = LibrosManager.ObtenerPorTitulo(busqueda);

                foreach (Libro item in listaLibros)
                {
                    Autor autor = AutoresManager.ObtenerPorCodigo(item.idAutor);
                    Editorial editorial = EditorialesManager.ObtenerPorCodigo(item.idEditorial);
                    Categoria categoria = CategoriasManager.ObtenerPorCodigo(item.idCategoria);
                    dgvLibros.Rows.Add(item.codigo,item.titulo, autor.nombre, editorial.nombre, categoria.nombre, "Ver libro");

                }
                dgvLibros.Visible = true;
                txtBuscador.Text = busqueda;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            dgvLibros.Rows.Clear();
            List<Libro> listaLibros = new List<Managers.Models.Libro>();
            listaLibros = LibrosManager.ObtenerPor(cmbOpciones.Text,txtBuscador.Text);
            
           foreach (Libro item in listaLibros)
           {
                Autor autor = AutoresManager.ObtenerPorCodigo(item.idAutor);
                Editorial editorial = EditorialesManager.ObtenerPorCodigo(item.idEditorial);
                Categoria categoria = CategoriasManager.ObtenerPorCodigo(item.idCategoria);
                dgvLibros.Rows.Add(item.codigo, item.titulo, autor.nombre, editorial.nombre,categoria.nombre,"Ver libro");
                
           }
            dgvLibros.Visible = true;
        }

        private void dgvLibros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int? fila = dgvLibros.CurrentCell.RowIndex;
            try
            {
                DetalleLibro formulario = new DetalleLibro();
                formulario.codigo = dgvLibros.Rows[fila.Value].Cells[0].Value.ToString();
                ElementoPila elemento = new ElementoPila(this, this.Name, null, null, txtBuscador.Text);
                pila.Push(elemento);
                formulario.pila = pila;
                Funciones.cambiarFormA(this, formulario);
            }
            catch (NullReferenceException ex)
            {
                
            }            
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Funciones.volver(pila, this);
        }
    }
}
