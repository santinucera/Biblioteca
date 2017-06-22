using System.Collections.Generic;
using System.Data.OleDb;
using Helpers;
using Managers.Models;
using System;

namespace Managers.Managers
{
    public class LibrosManager
    {
        public static int Insertar(Libro unLibro)
        {
            int intRegistrosAfectados = 0;
            List<OleDbParameter> parametersList = new List<OleDbParameter>();
            // Si hay Parametros los agrego al command.
            parametersList.Add(new OleDbParameter("strCodigo", unLibro.codigo));
            parametersList.Add(new OleDbParameter("strTitulo", unLibro.titulo));
            parametersList.Add(new OleDbParameter("strIdAutor", unLibro.idAutor));
            parametersList.Add(new OleDbParameter("strIdEditorial", unLibro.idEditorial));
            parametersList.Add(new OleDbParameter("strIdCategoria", unLibro.idCategoria));
            parametersList.Add(new OleDbParameter("strDescripcion", unLibro.descripcion));
            parametersList.Add(new OleDbParameter("intAnioPublicacion", unLibro.anioPublicacion));
            parametersList.Add(new OleDbParameter("intCantPaginas", unLibro.cantPaginas));


            intRegistrosAfectados = AccesoDatos.ExecuteNonQuery("Libro_Insertar", parametersList);

            return intRegistrosAfectados;
        }

        public static Libro Obtener(string strBuscador)
        {
            Libro unLibro = null;
            OleDbDataReader rdrLector = null; ;
            List<OleDbParameter> parametersList = new List<OleDbParameter>();

            parametersList.Add(new OleDbParameter("strId", strBuscador));
            rdrLector = AccesoDatos.ExecuteReader("Libro_Obtener", parametersList);
            if (rdrLector.HasRows)
            {
                // Obtengo los Valores
                rdrLector.Read();
                unLibro = DataReaderALibro(rdrLector);
            }
            rdrLector.Close();
            rdrLector.Dispose();
            return unLibro;
        }

        public static List<Libro> ObtenerPor(string tipoBusqueda,string strBuscador)
        {
            List<Libro> returnList = new List<Libro>();
            Libro unLibro = null;
            OleDbDataReader rdrLector = null; 
            List<OleDbParameter> parametersList = new List<OleDbParameter>();
            parametersList.Add(new OleDbParameter("strBuscador", strBuscador));
            switch (tipoBusqueda)
            {
                case "Titulo":
                    rdrLector = AccesoDatos.ExecuteReader("Libro_ObtenerPorTitulo", parametersList);
                    break;

                case "Codigo":
                    rdrLector = AccesoDatos.ExecuteReader("Libro_ObtenerPorCodigo", parametersList);
                    break;

                case "Autor":
                    rdrLector = AccesoDatos.ExecuteReader("Libro_ObtenerPorAutor", parametersList);
                    break;

                case "Editorial":
                    rdrLector = AccesoDatos.ExecuteReader("Libro_ObtenerPorEditorial", parametersList);
                    break;
            }
            
            if (rdrLector.HasRows)
            {
                while (rdrLector.Read())
                {
                    unLibro = DataReaderALibro(rdrLector);
                    returnList.Add(unLibro);
                }
            }
            rdrLector.Close();
            rdrLector.Dispose();
            return returnList;
        }

        public static List<Libro> ObtenerPorTitulo(string buscador)
        {
            Libro unLibro;
            List<OleDbParameter> parametersList = new List<OleDbParameter>();
            buscador = buscador.Trim();
            parametersList.Add(new OleDbParameter("strBuscador", buscador));
            OleDbDataReader rdrLector = null;
            List<Libro> returnList = new List<Libro>();
            rdrLector = AccesoDatos.ExecuteReader("Libro_ObtenerPorTitulo", parametersList);
            if (rdrLector.HasRows)
            {
                while (rdrLector.Read())
                {
                    unLibro = DataReaderALibro(rdrLector);
                    returnList.Add(unLibro);
                }
            }
            rdrLector.Close();
            rdrLector.Dispose();
            return returnList;
        }

        public static List<Libro> ObtenerPorCategoriaYAutor(string categoria, string autor)
        {
            Libro unLibro;
            List<OleDbParameter> parametersList = new List<OleDbParameter>();
            parametersList.Add(new OleDbParameter("strIdCategoria", categoria));
            parametersList.Add(new OleDbParameter("strIdAutor", autor));
            OleDbDataReader rdrLector = null;
            List<Libro> returnList = new List<Libro>();
            rdrLector = AccesoDatos.ExecuteReader("Libro_ObtenerPorCategoriaYAutor", parametersList);
            if (rdrLector.HasRows)
            {
                while (rdrLector.Read())
                {
                    unLibro = DataReaderALibro(rdrLector);
                    returnList.Add(unLibro);
                }
            }
            rdrLector.Close();
            rdrLector.Dispose();
            return returnList;
        }

        public static string CrearCodigo(string categoria, string autor,string editorial)
        {
            List<Libro> lista = LibrosManager.ObtenerPorCategoriaYAutor(categoria, autor);
            List<int> listaCodigos = FuncionesManager.ObtenerNumerosCodigo(lista);
            int numAnterior = 0;
            string codigo = categoria + autor+editorial;
            foreach (int num in listaCodigos)
            {
                if (num != numAnterior + 1)
                {
                    if (num > 9)
                    {
                        return codigo + (numAnterior + 1).ToString();
                    }
                    else
                    {
                        return codigo +"0" +(numAnterior + 1).ToString();
                    }
                }
                numAnterior++;
            }
            if (lista.Count > 9)
            {
                codigo = codigo + lista.Count.ToString();
            }
            else
            {
                codigo = codigo +"0" + (lista.Count+1).ToString();
            }
            return codigo;
        }

        public static string CodigoLibre(string categoria, string autor)
        {
            List<Libro> lista = LibrosManager.ObtenerPorCategoriaYAutor(categoria, autor);
            
            
            return null;


        }

    public static int Modificar(string tipoModificacion,string cambio,string codigo)
        {
            int intRegistrosAfectados = 0;
            List<OleDbParameter> parametersList = new List<OleDbParameter>();
            

            switch (tipoModificacion)
            {
                case "Titulo":
                    parametersList.Add(new OleDbParameter("strCambio", cambio));
                    parametersList.Add(new OleDbParameter("strCodigo", codigo));
                    intRegistrosAfectados = AccesoDatos.ExecuteNonQuery("Libro_ModificarTitulo", parametersList);
                    break;

                case "CantPaginas":
                    int intCambio = Convert.ToInt32(cambio);
                    parametersList.Add(new OleDbParameter("strCambio", intCambio));
                    parametersList.Add(new OleDbParameter("strCodigo", codigo));
                    intRegistrosAfectados = AccesoDatos.ExecuteNonQuery("Libro_ModificarCantPaginas", parametersList);
                    break;

                case "AnioPublicacion":
                    int intCambi = Convert.ToInt32(cambio);
                    parametersList.Add(new OleDbParameter("strCambio", intCambi));
                    parametersList.Add(new OleDbParameter("strCodigo", codigo));
                    intRegistrosAfectados = AccesoDatos.ExecuteNonQuery("Libro_ModificarAnioPublicacion", parametersList);
                    break;

                case "Descripcion":
                    parametersList.Add(new OleDbParameter("strCambio", cambio));
                    parametersList.Add(new OleDbParameter("strCodigo", codigo));
                    intRegistrosAfectados = AccesoDatos.ExecuteNonQuery("Libro_ModificarDescripcion", parametersList);
                    break;
            }

            
            return intRegistrosAfectados;
        }

        public static int EliminarLibro(string codigo)
        {
            int intRegistrosAfectados = 0;
            List<OleDbParameter> parametersList = new List<OleDbParameter>();
            parametersList.Add(new OleDbParameter("strCodigo", codigo));
            intRegistrosAfectados = AccesoDatos.ExecuteNonQuery("Libro_Eliminar", parametersList);
            return intRegistrosAfectados;
        }

        public static Libro DataReaderALibro(OleDbDataReader rdrLector)
        {
            Libro unLibro = new Libro();
            unLibro.codigo = rdrLector["Codigo"].ToString();
            unLibro.titulo= rdrLector["Titulo"].ToString();
            unLibro.idAutor= rdrLector["IdAutor"].ToString();
            unLibro.idCategoria= rdrLector["IdCategoria"].ToString();
            unLibro.idEditorial = rdrLector["IdEditorial"].ToString();
            unLibro.descripcion= rdrLector["Descripcion"].ToString();
            unLibro.cantPaginas = Convert.ToInt32(rdrLector["CantPaginas"]);
            unLibro.anioPublicacion= Convert.ToInt32(rdrLector["AnioPublicacion"]);
            return unLibro;
        }
    }
}
