using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using Helpers;
using Managers.Models;

namespace Managers.Managers
{
    public class AutoresManager
    {
        public static int Insertar(Autor unAutor)
        {

            int intRegistrosAfectados = 0;
            List<OleDbParameter> parametersList = new List<OleDbParameter>();
            // Si hay Parametros los agrego al command.
            parametersList.Add(new OleDbParameter("strId", unAutor.id));
            parametersList.Add(new OleDbParameter("strNombre", unAutor.nombre));
            


            intRegistrosAfectados = AccesoDatos.ExecuteNonQuery("Autor_Insertar", parametersList);

            return intRegistrosAfectados;
        }

        public static Autor ObtenerPorCodigo(string strBuscador)
        {
            Autor unAutor = null;
            OleDbDataReader rdrLector = null; ;
            List<OleDbParameter> parametersList = new List<OleDbParameter>();

            parametersList.Add(new OleDbParameter("strBuscador", strBuscador));
            rdrLector = AccesoDatos.ExecuteReader("Autor_ObtenerPorCodigo", parametersList);
            if (rdrLector.HasRows)
            {
                // Obtengo los Valores
                rdrLector.Read();
                unAutor = DataReaderAAutor(rdrLector);
            }
            rdrLector.Close();
            rdrLector.Dispose();
            return unAutor;
        }

        public static string ObtenerNombre(string strBuscador)
        {
            Autor unAutor = AutoresManager.ObtenerPorCodigo(strBuscador);
            return unAutor.nombre;
        }

        public static List<Autor> ObtenerTodos()
        {
            Autor unAutor = null;
            List<Autor> returnList = new List<Autor>();
            OleDbDataReader rdrLector = null; ;

            rdrLector = AccesoDatos.ExecuteReader("Autor_ObtenerTodos");
            if (rdrLector.HasRows)
            {


                while (rdrLector.Read())
                {
                    unAutor = DataReaderAAutor(rdrLector);
                    returnList.Add(unAutor);
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
            rdrLector = AccesoDatos.ExecuteReader("Autor_ObtenerLibros", parametersList);
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

        private static Autor DataReaderAAutor(OleDbDataReader rdrLector)
        {
            Autor unAutor = new Autor();
            unAutor.nombre = rdrLector["Nombre"].ToString();
            unAutor.id = rdrLector["Id"].ToString();


            return unAutor;
        }
    }
}
