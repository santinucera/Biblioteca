using Managers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Managers.Managers
{
    public class FuncionesManager
    {
        public static bool esMayuscula(string cadena)
        {

            byte[] asciiInput = Encoding.ASCII.GetBytes(cadena);
            foreach (byte element in asciiInput)
            {
                if (element < 65 && element > 90)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool esNumero(string cadena)
        {
            try
            {
                int num = Convert.ToInt32(cadena);
            }
            catch
            {
                return false;
            }
            return true;
            
        }

        public static List<int> ObtenerNumerosCodigo(List<Libro> lista)
        {
            List<int> listaCodigos = new List<int>();
            int num;
            foreach (Libro item in lista)
            {
                string cod = item.codigo.Substring(4, 2);
                num = Convert.ToInt32(cod);
                listaCodigos.Add(num);
            }
            listaCodigos.Sort();
            return listaCodigos;
        }
        public static string obtenerCodigo(string texto)
        {
            int cantLetras = texto.Length;
            return texto.Substring(cantLetras - 3, 2);
        }
        
        public static bool noEsVacio(string texto)
        {
            return texto != null && texto != "";
        }
        
        

        
    }

}

public class ElementoPila
{
    public  Form formulario;
    public string nombreForm;
    public LibroEntreForms libro;
    public string codigo;
    public string buscador;

    public ElementoPila(Form formu, string nombre, LibroEntreForms libr,string cod,string busque)
    {
        formulario = formu;
        nombreForm = nombre;
        libro = libr;
        codigo = cod;
        buscador = busque;
    }

}
