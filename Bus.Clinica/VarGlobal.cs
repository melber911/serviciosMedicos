using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bus.Utilities;

namespace Bus.Clinica
{
    public class VarGlobal
    {
        #region CnnClinica
        private static string _CnnClinica = "";
        public static string CnnClinica
        { get { return _CnnClinica; } }
        #endregion

        #region CnnLogistica
        private static string _CnnLogistica = "";
        public static string CnnLogistica
        { get { return _CnnLogistica; } }
        #endregion

        #region CnnMedisynOracle
        private string _CnnMedisynOracle = "";
        public string CnnMedisynOracle
        { get { return _CnnMedisynOracle; } }
        #endregion

        #region ListDataBase
        /// <summary>
        /// Lista Numerada con las Bases de Datos disponibles a conectar en SQL Server.
        /// </summary>
        public enum ListDataBase
        {
            clinica = 1,
            logistica = 2,
            seguridad = 3,
            dw_clinica = 4,

            medisyn = 11
        }
        #endregion

        #region LoadConectionString
        /// <summary>
        /// Cargar e iniciar la cadena de conection sobre la Base de Datos a la cual se va a trabajar.
        /// </summary>
        /// <param name="pNameConectionString">Nombre de la Cadena de conexión del App.Config o Web.Config.</param>
        /// <param name="pDataBaseServer">"Base de Datos sobre la cual se trabajara."</param>
        public static void LoadConectionString(string pNameConectionString, ListDataBase pDataBaseServer)
        {
            string StringConection = ConfigurationManager.ConnectionStrings[pNameConectionString].ConnectionString;

            //Verificar si la cadena esta encriptada, si esta encriptada la desencriptamos.
            if (StringConection.ToLower().IndexOf("data source") == -1)
                StringConection = Criptography.DecryptConectionString(StringConection);

            ConnectionsString.Server = getDataString("source", StringConection);
            ConnectionsString.DataBase = getDataString("catalog", StringConection);
            ConnectionsString.UserServer = getDataString("id", StringConection);
            ConnectionsString.PasswordServer = getDataString("password", StringConection);

            switch (pDataBaseServer)
            {
                case ListDataBase.clinica:
                    _CnnClinica = StringConection;
                    Dat.Sql.VariablesGlobales.CnnClinica = _CnnClinica;
                    break;
                case ListDataBase.logistica:
                    _CnnLogistica = StringConection;
                    Dat.Sql.VariablesGlobales.CnnLogistica = _CnnLogistica;
                    break;
                case ListDataBase.seguridad:
                    break;
                case ListDataBase.dw_clinica:
                    break;
                case ListDataBase.medisyn:
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region getDataString
        /// <summary>
        /// Obtener el valor del parametro de la cadena de conexion.
        /// </summary>
        /// <param name="pParametro">Nombre del Parámetro</param>
        /// <param name="pCadenaConexion">Cadena completa del app.config o web.config</param>
        /// <returns></returns>
        public static string getDataString(string pParametro, string pCadenaConexion)
        {
            string result = "";
            int index = pCadenaConexion.ToUpper().IndexOf(pParametro.ToUpper()) + pParametro.Length + 1;
            int length = 0;
            if (pCadenaConexion.IndexOf(";", index) == -1)
                length = pCadenaConexion.Length - index;
            else
                length = pCadenaConexion.IndexOf(";", index) - index;

            result = pCadenaConexion.Substring(index, length);
            return result;
        }
        #endregion
    }
}