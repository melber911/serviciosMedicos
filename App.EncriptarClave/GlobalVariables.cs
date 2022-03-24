using System.Data;
using System.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;

namespace App.EncriptarClave
{
    public static class GlobalVariables
    {
        #region CnnMasterSQL
        /// <summary>
        ///     ''' Cadena de Conexión de la Base de Datos "Master" SQL
        ///     ''' </summary>
        public static string CnnMasterSQL = "";
        #endregion

        #region CnnOracle
        /// <summary>
        ///     ''' Cadena de Conexión a la Base de Datos Oracle
        ///     ''' </summary>
        public static string CnnOracle = "";
        #endregion

        #region VerifyConnectionsDataBaseSQL
        /// <summary>
        ///     ''' Verificar la conexión a la Base de Datos en SQL Server con la Base de Datos "Master"
        ///     ''' </summary>
        ///     ''' <returns></returns>
        public static bool VerifyConnectionsDataBaseSQL()
        {
            bool xResultado = false;
            IDataReader dr;
            string xSqlString = "select top 1 database_id, name from sys.databases";

            try
            {
                using (SqlConnection cnn = new SqlConnection(CnnMasterSQL))
                {
                    using (SqlCommand Cmd = new SqlCommand(xSqlString, cnn))
                    {
                        Cmd.CommandType = CommandType.Text;
                        cnn.Open();
                        dr = Cmd.ExecuteReader();
                        while (dr.Read())
                            xResultado = true;
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            return xResultado;
        }
        #endregion

        #region LoadDataBaseSQL
        public static DataTable LoadDataBaseSQL(string pSqlString, int pNroColumna)
        {
            IDataReader dr;
            DataTable xDataTable = new DataTable();
            try
            {
                using (SqlConnection cnn = new SqlConnection(CnnMasterSQL))
                {
                    using (SqlCommand Cmd = new SqlCommand(pSqlString, cnn))
                    {
                        Cmd.CommandType = CommandType.Text;
                        cnn.Open();
                        dr = Cmd.ExecuteReader();

                        if (pNroColumna >= 1)
                            xDataTable.Columns.Add("id");
                        if (pNroColumna >= 2)
                            xDataTable.Columns.Add("name");
                        if (pNroColumna >= 3)
                            xDataTable.Columns.Add("column3");
                        if (pNroColumna >= 4)
                            xDataTable.Columns.Add("column4");

                        while (dr.Read())
                        {
                            if (pNroColumna == 1)
                                xDataTable.Rows.Add(dr[0]);
                            if (pNroColumna == 2)
                                xDataTable.Rows.Add(dr[0], dr[1]);
                            if (pNroColumna == 3)
                                xDataTable.Rows.Add(dr[0], dr[1], dr[2]);
                            if (pNroColumna == 4)
                                xDataTable.Rows.Add(dr[0], dr[1], dr[2], dr[3]);
                        }
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            return xDataTable;
        }
        #endregion

        #region VerifyConnectionsDataBaseOracle
        public static bool VerifyConnectionsDataBaseOracle(ref string pServerName)
        {
            bool xResultado = false;
            IDataReader dr;
            string xSqlString = "select value as server_name from v$parameter where name like '%service_name%'";

            try
            {
                using (OracleConnection cnn = new OracleConnection(CnnOracle))
                {
                    using (OracleCommand Cmd = new OracleCommand(xSqlString, cnn))
                    {
                        Cmd.CommandType = CommandType.Text;
                        cnn.Open();
                        dr = Cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            pServerName = Convert.ToString(dr[0] + "");
                            xResultado = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            return xResultado;
        }
        #endregion
    }
}