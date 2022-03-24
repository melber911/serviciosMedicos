using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus.Utilities
{
    public class ConnectionsString
    {
        #region CnnSQL
        /// <summary>
        ///     ''' Cadena de Conexión del SQL Server concatenada, sirve para conectarnos al SQL Server.
        ///     ''' </summary>
        ///     ''' <param name="HostServer">Nombre del Servidor o Ip</param>
        ///     ''' <param name="UserServer">Usuario del Servidor</param>
        ///     ''' <param name="PasswordServer">Contraseña del Servidor</param>
        ///     ''' <param name="DataBase">Base de Datos a la cual nos conectaremos</param>
        ///     ''' <returns></returns>
        public static string CnnSQL(string HostServer, string UserServer, string PasswordServer, string DataBase)
        {
            return "data source=" + HostServer + "; user id=" + UserServer + "; password=" + PasswordServer + "; initial catalog=" + DataBase + ";";
        }
        #endregion

        #region CnnOracle
        /// <summary>
        ///     ''' Cadena de Conexión del Oracle concatenada, sirve para conectarnos al Motor de Base de Datos del Oracle.
        ///     ''' </summary>
        ///     ''' <param name="HostServer">Nombre del Servidor o Ip</param>
        ///     ''' <param name="PortServer">Puerto al cual nos conectaremos, por defecto es 1521</param>
        ///     ''' <param name="ServerInstanceName">Nombre de la Instancia al cual nos conectaremos</param>
        ///     ''' <param name="ServerName">Nombre del Servidor</param>
        ///     ''' <param name="UserServer">Usuario del Servidor</param>
        ///     ''' <param name="PasswordServer">Contraseña del Servidor</param>
        ///     ''' <returns></returns>
        public static string CnnOracle(string HostServer, string PortServer, string ServerInstanceName, string ServerName, string UserServer, string PasswordServer)
        {
            return "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" + HostServer + ")(PORT=" + PortServer + ")))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=" + ServerName + ")(INSTANCE_NAME=" + ServerInstanceName + "))); User Id=" + UserServer + "; Password=" + PasswordServer + ";";
        }
        #endregion

        #region Server
        /// <summary>
        ///     ''' Nombre o Ip del Servidor al cual queremos conectarnos
        ///     ''' </summary>
        ///     ''' <returns></returns>
        public static string Server { get; set; } = "";
        #endregion

        #region DataBase
        /// <summary>
        ///     ''' Nombre de la Base de Datos a conectar.
        ///     ''' </summary>
        ///     ''' <returns></returns>
        public static string DataBase { get; set; } = "";
        #endregion

        #region UserServer
        /// <summary>
        ///     ''' Nombre de Usuario de la Base de Datos
        ///     ''' </summary>
        ///     ''' <returns></returns>
        public static string UserServer { get; set; } = "";
        #endregion

        #region PasswordServer
        /// <summary>
        ///     ''' Contraseña de la Base de Datos
        ///     ''' </summary>
        ///     ''' <returns></returns>
        public static string PasswordServer { get; set; } = "";
        #endregion

        #region getDataString
        /// <summary>
        ///     ''' Obtener el valor del parametro de la cadena de conexion.
        ///     ''' </summary>
        ///     ''' <param name="pParametro">Nombre del Parámetro</param>
        ///     ''' <param name="pCadenaConexion">Cadena completa del app.config o web.config</param>
        ///     ''' <returns></returns>
        public static string getDataString(string pParametro, string pCadenaConexion)
        {
            string result = "";
            int index = pCadenaConexion.ToUpper().IndexOf(pParametro.ToUpper()) + pParametro.Length + 1;
            int length = ((pCadenaConexion.IndexOf(";", index) == -1) ? (pCadenaConexion.Length - index) : (pCadenaConexion.IndexOf(";", index) - index));

            result = pCadenaConexion.Substring(index, length);

            return result;
        }
        #endregion
    }
}


//using Microsoft.VisualBasic;

//public class ConnectionsString
//{

//    /// <summary>
//    ///     ''' Cadena de Conexión del SQL Server concatenada, sirve para conectarnos al SQL Server.
//    ///     ''' </summary>
//    ///     ''' <param name="HostServer">Nombre del Servidor o Ip</param>
//    ///     ''' <param name="UserServer">Usuario del Servidor</param>
//    ///     ''' <param name="PasswordServer">Contraseña del Servidor</param>
//    ///     ''' <param name="DataBase">Base de Datos a la cual nos conectaremos</param>
//    ///     ''' <returns></returns>
//    public static string CnnSQL(string HostServer, string UserServer, string PasswordServer, string DataBase)
//    {
//        return "data source=" + HostServer + "; user id=" + UserServer + "; password=" + PasswordServer + "; initial catalog=" + DataBase + ";";
//    }

//    /// <summary>
//    ///     ''' Cadena de Conexión del Oracle concatenada, sirve para conectarnos al Motor de Base de Datos del Oracle.
//    ///     ''' </summary>
//    ///     ''' <param name="HostServer">Nombre del Servidor o Ip</param>
//    ///     ''' <param name="PortServer">Puerto al cual nos conectaremos, por defecto es 1521</param>
//    ///     ''' <param name="ServerInstanceName">Nombre de la Instancia al cual nos conectaremos</param>
//    ///     ''' <param name="ServerName">Nombre del Servidor</param>
//    ///     ''' <param name="UserServer">Usuario del Servidor</param>
//    ///     ''' <param name="PasswordServer">Contraseña del Servidor</param>
//    ///     ''' <returns></returns>
//    public static string CnnOracle(string HostServer, string PortServer, string ServerInstanceName, string ServerName, string UserServer, string PasswordServer)
//    {
//        return "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" + HostServer + ")(PORT=" + PortServer + ")))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=" + ServerName + ")(INSTANCE_NAME=" + ServerInstanceName + "))); User Id=" + UserServer + "; Password=" + PasswordServer + ";";
//    }

//    /// <summary>
//    ///     ''' Nombre o Ip del Servidor al cual queremos conectarnos
//    ///     ''' </summary>
//    ///     ''' <returns></returns>
//    public static string Server { get; set; } = "";

//    /// <summary>
//    ///     ''' Nombre de la Base de Datos a conectar.
//    ///     ''' </summary>
//    ///     ''' <returns></returns>
//    public static string DataBase { get; set; } = "";

//    /// <summary>
//    ///     ''' Nombre de Usuario de la Base de Datos
//    ///     ''' </summary>
//    ///     ''' <returns></returns>
//    public static string UserServer { get; set; } = "";

//    /// <summary>
//    ///     ''' Contraseña de la Base de Datos
//    ///     ''' </summary>
//    ///     ''' <returns></returns>
//    public static string PasswordServer { get; set; } = "";

//    /// <summary>
//    ///     ''' Obtener el valor del parametro de la cadena de conexion.
//    ///     ''' </summary>
//    ///     ''' <param name="pParametro">Nombre del Parámetro</param>
//    ///     ''' <param name="pCadenaConexion">Cadena completa del app.config o web.config</param>
//    ///     ''' <returns></returns>
//    public static string getDataString(string pParametro, string pCadenaConexion)
//    {
//        string result = "";
//        int index = pCadenaConexion.ToUpper().IndexOf(pParametro.ToUpper()) + pParametro.Length + 1;
//        int length = Interaction.IIf(pCadenaConexion.IndexOf(";", index) == -1, pCadenaConexion.Length - index, pCadenaConexion.IndexOf(";", index) - index);

//        result = pCadenaConexion.Substring(index, length);

//        return result;
//    }
//}
