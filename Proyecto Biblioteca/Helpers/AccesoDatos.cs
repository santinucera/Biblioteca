using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Data;
using System.Data.OleDb;


namespace Helpers {
	/// <summary>
	/// Summary description for Principal.
	/// </summary>
	public static class AccesoDatos{
        ///
        /// <summary>
        ///     Esta property se lee del App.Config
        /// </summary>
        /// 
        /// Ejemplo de ConnectionString en el archivo de configuracion
        ///     <add key="ConnectionString" value="Provider=Microsoft.Jet.Oledb.4.0;Data Source=D:\Base.mdb;Persist Security Info=False;"/>
        /// 
        public static string ConnectionString {
            get { return ConfigurationManager.AppSettings["ConnectionString"]; }
        }
        
        /// <summary>
        ///     Retorna instancia y abre y retorna un 'OleDbConnection', segun la propiedad 'ConnectionString'.
        /// </summary>
        /// <returns></returns>
        public static OleDbConnection ObtenerConexion() {
            OleDbConnection cnnConexion = null;
            try {
                cnnConexion = new OleDbConnection(AccesoDatos.ConnectionString);
                cnnConexion.Open();
            } catch (Exception ex) {
                GrabarLog(ex.Message);
            }
            return cnnConexion;
        }
        
        /// <summary>
        /// Dado un 'OleDbConnection', chequea que no sea null y si su estado es distinto de 'Open' lo cierra.
        /// </summary>
        /// <param name="cnnConexion"></param>
        public static void CerrarConexion(OleDbConnection cnnConexion) {
            if ((cnnConexion != null) && (cnnConexion.State != ConnectionState.Closed)) {
                try {
                    cnnConexion.Close();
                } catch (Exception ex) {
                    GrabarLog(ex.Message);
                }
            }
        }
    
        #region ExecuteReader
        public static OleDbDataReader ExecuteReader(string strComando) {
            return ExecuteReader(strComando, CommandType.StoredProcedure, null);
        }

        public static OleDbDataReader ExecuteReader(string strComando, CommandType Tipo) {
            return ExecuteReader(strComando, Tipo, null);
        }

        public static OleDbDataReader ExecuteReader(string strComando, List<OleDbParameter> parametersList) {
            return ExecuteReader(strComando, CommandType.StoredProcedure, parametersList);
        }

        public static OleDbDataReader ExecuteReader(string strComando, CommandType Tipo, List<OleDbParameter> parametersList) {
            OleDbConnection cnnConexion;
            OleDbCommand    cmdComando;
            OleDbDataReader rdrLector = null;

            cnnConexion = AccesoDatos.ObtenerConexion();                    // Obtengo la Conexion
            cmdComando = new OleDbCommand(strComando, cnnConexion);		    // Creo el Commando
            cmdComando.CommandType = Tipo;								    // Le asigno el Tipo de Command
            // Si hay Parametros los agrego al command.
            if ((parametersList != null) && (parametersList.Count > 0)) {
                foreach (OleDbParameter oParamActual in parametersList) {
                    cmdComando.Parameters.AddWithValue(oParamActual.ParameterName, oParamActual.Value);
                }
            }
            
            try {
                rdrLector = cmdComando.ExecuteReader(CommandBehavior.CloseConnection); // Ejecuto el Reader.
            } catch (Exception ex) {
                GrabarLog(ex.Message);
            }

            // Libero Recursos
            cmdComando.Dispose();

            return rdrLector;
        } 
        #endregion

        #region ExecuteNonQuery
        public static int ExecuteNonQuery(string strComando) {
            return ExecuteNonQuery(strComando, CommandType.StoredProcedure, null);
        }

        public static int ExecuteNonQuery(string strComando, CommandType Tipo) {
            return ExecuteNonQuery(strComando, Tipo, null);
        }

        public static int ExecuteNonQuery(string strComando, List<OleDbParameter> parametersList) {
            return ExecuteNonQuery(strComando, CommandType.StoredProcedure, parametersList);
        }

        public static int ExecuteNonQuery(string strComando, CommandType Tipo, List<OleDbParameter> parametersList) {
            OleDbConnection cnnConexion;
            OleDbCommand    cmdComando;
            int             intRegsAffected = 0;

            cnnConexion = AccesoDatos.ObtenerConexion();                      // Obtengo la Conexion
            cmdComando = new OleDbCommand(strComando, cnnConexion);		    // Creo el Commando
            cmdComando.CommandType = Tipo;								    // Le asigno el Tipo de Command
            // Si hay Parametros los agrego al command.
            if ((parametersList != null) && (parametersList.Count > 0)) {
                foreach (OleDbParameter oParamActual in parametersList) {
                    cmdComando.Parameters.AddWithValue(oParamActual.ParameterName, oParamActual.Value);
                }
            }

            try {
                intRegsAffected = cmdComando.ExecuteNonQuery(); // Ejecuto el Command.
            } catch (Exception ex) {
                GrabarLog(ex.Message);
            }

            // Libero Recursos
            cmdComando.Dispose();
            CerrarConexion(cnnConexion);

            return intRegsAffected;
        }
        #endregion

        #region ExecuteDataSet
        public static DataSet ExecuteDataSet(string strComando) {
            return ExecuteDataSet(null, strComando, CommandType.StoredProcedure, "Resultado", null);
        }

        public static DataSet ExecuteDataSet(string strComando, CommandType Tipo) {
            return ExecuteDataSet(null, strComando, Tipo, "Resultado", null);
        }

        public static DataSet ExecuteDataSet(string strComando, CommandType Tipo, string strTabla) {
            return ExecuteDataSet(null, strComando, Tipo, strTabla, null);
        }

        public static DataSet ExecuteDataSet(DataSet ds, string strComando, CommandType Tipo, string strTabla) {
            return ExecuteDataSet(ds, strComando, Tipo, strTabla, null);
        }

        public static DataSet ExecuteDataSet(DataSet ds, string strComando, CommandType Tipo, string strTabla, List<OleDbParameter> parametersList) {
            OleDbConnection cnnConexion;
            OleDbCommand    cmdComando;
            OleDbDataAdapter daAdapter;
            DataSet dsDatos;

            if (ds == null) {
                dsDatos = new DataSet();
            } else {
                dsDatos = ds;
            }

            cnnConexion = AccesoDatos.ObtenerConexion();				// Obtengo la Conexion
            cmdComando = new OleDbCommand(strComando, cnnConexion);		// Creo el Commando
            cmdComando.CommandType = Tipo;								// Le asigno el Tipo de Command

            // Si hay Parametros los agrego al command.
            if ((parametersList != null) && (parametersList.Count > 0)) {
                foreach (OleDbParameter oParamActual in parametersList) {
                    cmdComando.Parameters.AddWithValue(oParamActual.ParameterName, oParamActual.Value);
                }
            }


            daAdapter = new OleDbDataAdapter(cmdComando);
            // Lleno el DataSet, creando una tabla 'strTabla' con los datos del comando.
            try {
                daAdapter.Fill(dsDatos, strTabla);
            } catch (Exception ex) {
                GrabarLog(ex.Message);
            }

            // Libero Recursos
            cmdComando.Dispose();
            CerrarConexion(cnnConexion);

            return dsDatos;
        }
        #endregion

        #region Metodos Utiles
        /// <summary>
        ///     Guarda en el Log de Errores, creando el archivo o agregando en el caso de que no exista.
        /// </summary>
        /// <param name="strMensaje"></param>
        private static void GrabarLog(string strMensaje) {
            // Compose a string that consists of three lines.
            string strPathFile = ConfigurationManager.AppSettings["ErrorLog"];
            string strLog;
            // Grabo en el archivo.
            try {
                using (StreamWriter file = new StreamWriter(strPathFile, true)) {
                    strLog = string.Format("{0}|{1}|{2}", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), Environment.MachineName, strMensaje);
                    file.WriteLine(strLog);
                    file.WriteLine("--------------------------------------------------------------------------------");
                    file.Close();
                }
            } catch (Exception ex) {
                // No hago nada
            }
        }
        #endregion

        #region ObtenerValor 
        public static string ObtenerValor(OleDbDataReader rdrLector, string strNombreColumna, string strDefaultValue) {
            string strReturnValue = strDefaultValue;
            strReturnValue = (!rdrLector.IsDBNull(rdrLector.GetOrdinal(strNombreColumna))) ? Convert.ToString(rdrLector[strNombreColumna]) : strDefaultValue;
            return strReturnValue;
        }

        public static double ObtenerValor(OleDbDataReader rdrLector, string strNombreColumna, double dblDefaultValue) {
            double dblReturnValue = dblDefaultValue;
            dblReturnValue = (!rdrLector.IsDBNull(rdrLector.GetOrdinal(strNombreColumna))) ? Convert.ToDouble(rdrLector[strNombreColumna]) : dblDefaultValue;
            return dblReturnValue;
        }

        public static DateTime ObtenerValor(OleDbDataReader rdrLector, string strNombreColumna, DateTime dtmDefaultValue) {
            DateTime dtmReturnValue = dtmDefaultValue;
            dtmReturnValue = (!rdrLector.IsDBNull(rdrLector.GetOrdinal(strNombreColumna))) ? Convert.ToDateTime(rdrLector[strNombreColumna]) : dtmDefaultValue;
            return dtmReturnValue;
        }

        public static int ObtenerValor(OleDbDataReader rdrLector, string strNombreColumna, int intDefaultValue) {
            int intReturnValue = intDefaultValue;
            intReturnValue = (!rdrLector.IsDBNull(rdrLector.GetOrdinal(strNombreColumna))) ? Convert.ToInt32(rdrLector[strNombreColumna]) : intDefaultValue;
            return intReturnValue;
        }

        public static bool ObtenerValor(OleDbDataReader rdrLector, string strNombreColumna, bool blnDefaultValue) {
            bool blnReturnValue = blnDefaultValue;
            blnReturnValue = (!rdrLector.IsDBNull(rdrLector.GetOrdinal(strNombreColumna))) ? Convert.ToBoolean(rdrLector[strNombreColumna]) : blnDefaultValue;
            return blnReturnValue;
        }
        #endregion

    }
}
