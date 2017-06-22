using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;

namespace BibliotecaAEGU
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Inicio());
        }
    }

    public class Funciones
    {
        public static void volver(Stack<ElementoPila> pila, Form formulario)
        {

            ElementoPila elemento = pila.Pop();
            switch (elemento.nombreForm)
            {
                case "QueHacer":
                    Funciones.cambiarFormA(formulario, elemento.formulario);
                    break;

                case "DetalleLibro":
                    DetalleLibro formula = new DetalleLibro(elemento.codigo,pila);
                    Funciones.cambiarFormA(formulario, formula);
                    break;

                case "DetalleCategoria":
                    DetalleCategoria formul = new DetalleCategoria(elemento.codigo,pila);
                    Funciones.cambiarFormA(formulario, formul);
                    break;

                case "NuevoLibro":
                    NuevoLibro form = new NuevoLibro();
                    ElementoPila nuevoElemento = new ElementoPila(formulario, formulario.Name, elemento.libro, null,null);
                    pila.Push(nuevoElemento);
                    form.pila = pila;
                    Funciones.cambiarFormA(formulario, form);
                    break;

                case "DetalleAutor":
                    DetalleLibro formularioA = new DetalleLibro(elemento.codigo, pila);
                    Funciones.cambiarFormA(formulario, formularioA);
                    break;

                case "DetalleEditorial":
                    DetalleLibro formularioE = new DetalleLibro(elemento.codigo, pila);
                    Funciones.cambiarFormA(formulario, formularioE);
                    break;

                case "Buscador":
                    Buscador formularioBus = new Buscador(elemento.buscador, pila);
                    Funciones.cambiarFormA(formulario, formularioBus);
                    break;

                case "EditarLibro":
                    EditarLibro formularioEL = new EditarLibro(elemento.codigo, pila);
                    Funciones.cambiarFormA(formulario, formularioEL);
                    break;


            }

        }

        public static void agregarParaLibro(Stack<ElementoPila> pila, Form formulario)
        {
            ElementoPila elemento = pila.Pop();
            switch(elemento.nombreForm) 
            {
                case "NuevoLibro":
                    NuevoLibro form = new NuevoLibro();
                    ElementoPila nuevoElemento = new ElementoPila(formulario, formulario.Name, elemento.libro, null,null);
                    pila.Push(nuevoElemento);
                    form.pila = pila;
                    Funciones.cambiarFormA(formulario, form);
                    break;
            }
        }

        public static void cambiarFormA(Form formAnterior,Form formNuevo)
        {
            formAnterior.Hide();
            formNuevo.Show();
        }
    }
}
