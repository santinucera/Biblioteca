using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managers.Models
{
    public class Libro
    {
        public string codigo;
        public string titulo;
        public string idAutor;
        public string idEditorial;
        public string idCategoria;
        public string descripcion;
        public int cantPaginas;
        public int anioPublicacion;




      // public Libro(string cod, string tit, string idAut, string idEd, string idCate, string descr, int cantP, int anio)
      // {
      //     codigo = cod;
      //     titulo = tit;
      //     idAut = idAutor;
      //     idEditorial = idEd;
      //     idCategoria = idCate;
      //     descripcion = descr;
      //     cantPaginas = cantP;
      //     anioPublicacion = anio;
      // }
    }

    public class LibroEntreForms
    {
        public string titulo;
        public string editorial;
        public string categoria;
        public string autor;
        public string paginas;
        public string descripcion;
        public string anios;
        public string codigo;
        public string ubicacioImagen;

        public LibroEntreForms(string titul, string edi, string cate, string au, string pagi, string desc, string ani, string cod,string ubicacio)
        {
            titulo = titul;
            editorial = edi;
            categoria = cate;
            autor = au;
            paginas = pagi;
            descripcion = desc;
            anios = ani;
            codigo = cod;
            ubicacioImagen = ubicacio;
        }


    }
}
