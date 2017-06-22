using System.Collections.Generic;
using System.Data.OleDb;
using Helpers;
using Managers.Models;
using System;

namespace Managers.Managers
{
    public class EditorialesManager
    {
        public static int Insertar(Editorial unaEditorial)
        {

            int intRegistrosAfectados = 0;
            List<OleDbParameter> parametersList = new List<OleDbParameter>();
            // Si hay Parametros los agrego al command.
            parametersList.Add(new OleDbParameter("strId", unaEditorial.id));
            parametersList.Add(new OleDbParameter("strNombre", unaEditorial.nombre));



            intRegistrosAfectados = AccesoDatos.ExecuteNonQuery("Editorial_Insertar", parametersList);

            return intRegistrosAfectados;
        }

        public static Editorial ObtenerPorCodigo(string strBuscador)
        {
            Editorial unaEditorial = null;
            OleDbDataReader rdrLector = null; ;
            List<OleDbParameter> parametersList = new List<OleDbParameter>();

            parametersList.Add(new OleDbParameter("strBuscador", strBuscador));
            rdrLector = AccesoDatos.ExecuteReader("Editorial_ObtenerPorCodigo", parametersList);
            if (rdrLector.HasRows)
            {
                // Obtengo los Valores
                rdrLector.Read();
                unaEditorial = DataReaderAEditorial(rdrLector);
            }
            rdrLector.Close();
            rdrLector.Dispose();
            return unaEditorial;
        }

        public static string ObtenerNombre(string strBuscador)
        {
            Editorial unaEditorial = EditorialesManager.ObtenerPorCodigo(strBuscador);
            return unaEditorial.nombre;
        }

        public static List<Editorial> ObtenerTodos()
        {
            Editorial unaEditorial = null;
            List<Editorial> returnList = new List<Editorial>();
            OleDbDataReader rdrLector = null; ;

            rdrLector = AccesoDatos.ExecuteReader("Editorial_ObtenerTodos");
            if (rdrLector.HasRows)
            {


                while (rdrLector.Read())
                {
                    unaEditorial = DataReaderAEditorial(rdrLector);
                    returnList.Add(unaEditorial);
                }
            }
            rdrLector.Close();
            rdrLector.Dispose();
            return returnList;
        }

        public static List<Libro> ObtenerLibros(string codigo)
        {
            Libro unLibro = null;
            List<Libro> returnList = new List<Libro>();
            OleDbDataReader rdrLector = null; ;

            List<OleDbParameter> parametersList = new List<OleDbParameter>();

            parametersList.Add(new OleDbParameter("strId", codigo));
            rdrLector = AccesoDatos.ExecuteReader("Editorial_ObtenerLibros", parametersList);
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

        private static Editorial DataReaderAEditorial(OleDbDataReader rdrLector)
        {
            Editorial unaEditorial = new Editorial();
            unaEditorial.nombre = rdrLector["Nombre"].ToString();
            unaEditorial.id = rdrLector["Id"].ToString();
            return unaEditorial;
        }
    }
}
