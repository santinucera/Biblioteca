using System.Collections.Generic;
using System.Data.OleDb;
using Helpers;
using Managers.Models;
using System;

namespace Managers.Managers
{
    public class CategoriasManager
    {
        public static int Insertar(Categoria unaCategoria)
        {
            
            int intRegistrosAfectados = 0;
            List<OleDbParameter> parametersList = new List<OleDbParameter>();
            // Si hay Parametros los agrego al command.
            parametersList.Add(new OleDbParameter("strId", unaCategoria.id));
            parametersList.Add(new OleDbParameter("strNombre", unaCategoria.nombre));
            parametersList.Add(new OleDbParameter("strDescrpcion", unaCategoria.descripcion));
            
            
            intRegistrosAfectados = AccesoDatos.ExecuteNonQuery("Categoria_Insertar", parametersList);

            return intRegistrosAfectados;
        }

        public static List<Categoria> ObtenerTodos()
        {
            Categoria unaCategoria= null;
            List<Categoria> returnList = new List<Categoria>();
            OleDbDataReader rdrLector = null; ;
           
            rdrLector = AccesoDatos.ExecuteReader("Categoria_ObtenerTodos");
            if (rdrLector.HasRows)
            {
                

                while (rdrLector.Read())
                {
                    unaCategoria = DataReaderACategoria(rdrLector);
                    returnList.Add(unaCategoria);
                }
            }
            rdrLector.Close();
            rdrLector.Dispose();
            return returnList;
        }

        public static string ObtenerNombre(string strBuscador)
        {
            Categoria unaCategoria = CategoriasManager.ObtenerPorCodigo(strBuscador);
            return unaCategoria.nombre;
        }

        public static Categoria ObtenerPorCodigo(string strBuscador)
        {
            Categoria unaCategoria = null;
            OleDbDataReader rdrLector = null; ;
            List<OleDbParameter> parametersList = new List<OleDbParameter>();

            parametersList.Add(new OleDbParameter("strBuscador", strBuscador));
            rdrLector = AccesoDatos.ExecuteReader("Categoria_ObtenerPorCodigo", parametersList);
            if (rdrLector.HasRows)
            {
                // Obtengo los Valores
                rdrLector.Read();
                unaCategoria = DataReaderACategoria(rdrLector);
            }
            rdrLector.Close();
            rdrLector.Dispose();
            return unaCategoria;
        }

        public static List<Libro> ObtenerLibros(string codigo)
        {
            Libro unLibro = null;
            List<Libro> returnList = new List<Libro>();
            OleDbDataReader rdrLector = null; ;

            List<OleDbParameter> parametersList = new List<OleDbParameter>();

            parametersList.Add(new OleDbParameter("strId", codigo));
            rdrLector = AccesoDatos.ExecuteReader("Categoria_ObtenerLibros", parametersList);
            if (rdrLector.HasRows)
            {


                while (rdrLector.Read())
                {
                    unLibro = LibrosManager.DataReaderALibro(rdrLector);
                    returnList.Add(unLibro);
                }
            }
            rdrLector.Close();
            rdrLector.Dispose();
            return returnList;
        }

        public static Categoria DataReaderACategoria(OleDbDataReader rdrLector)
        {
            Categoria unaCategoria = new Categoria();
            unaCategoria.nombre = rdrLector["Nombre"].ToString();
            unaCategoria.descripcion = rdrLector["Descripcion"].ToString();
            unaCategoria.id= rdrLector["Id"].ToString();
            

            return unaCategoria;
        }

        
    }
}

