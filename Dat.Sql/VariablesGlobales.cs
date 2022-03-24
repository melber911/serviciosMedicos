using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dat.Sql
{
    public static class VariablesGlobales
    {

        /// <summary>
        ///     ''' Conection string a clinica
        ///     ''' </summary>
        public static string CnnClinica = "";

        /// <summary>
        ///     ''' Conection string a logistica
        ///     ''' </summary>
        public static string CnnLogistica = "";

        /// <summary>
        ///     ''' Permite enviar los tipos de parametros hacia SQL con valor de retorno para los parametros de salida.
        ///     ''' </summary>
        ///     ''' <param name="pNombreParametro">Nombre del parámetro que esta en el store</param>
        ///     ''' <param name="pDireccion">Entrada o Salida del parámetro</param>
        ///     ''' <param name="pSqlDBType">Tipo de Dato del store</param>
        ///     ''' <param name="pSize">Tamaño en caso sea un varchar</param>
        ///     ''' <param name="pValor">El campo el cual se está enviando</param>
        ///     ''' <returns></returns>
        public static SqlParameter ParametroSql(string pNombreParametro, ParameterDirection pDireccion, SqlDbType pSqlDBType, int pSize, object pValor)
        {
            //var _SqlParameter = new SqlParameter(pNombreParametro, pSqlDBType, pSize, pDireccion);
            var _SqlParameter = new SqlParameter(pNombreParametro, pSqlDBType, pSize);
            _SqlParameter.Value = pValor;
            _SqlParameter.Direction = pDireccion;
            return _SqlParameter;
        }

        public static bool ExecuteQueryString(string pQueryString)
        {
            int exito = 0;
            bool xResult = false;
            try
            {
                using (SqlConnection cnn = new SqlConnection(CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand(pQueryString, cnn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cnn.Open();
                        exito = cmd.ExecuteNonQuery();
                        xResult = (exito >= 1 ? true : false);
                        cmd.Dispose();
                        cnn.Close();
                        cnn.Close();
                    }
                }

                return xResult;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable ExecuteQueryStringDT(string pQueryString)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection cnn = new SqlConnection(CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand(pQueryString, cnn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cnn.Open();
                        SqlDataAdapter ad = new SqlDataAdapter(cmd);
                        ad.Fill(dt);

                        ad.Dispose();
                        cmd.Dispose();
                        cnn.Close();
                        cnn.Close();
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static bool Sp_VentaxFirma_Update(string pIdPK, byte[] pArchivo, int pOrden)
        {
            int exito = 0;
            bool xResult = false;
            try
            {
                using (SqlConnection cnn = new SqlConnection(CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("logistica.dbo.Sp_VentaxFirma_Update", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id_PK", pIdPK);
                        cmd.Parameters.AddWithValue("@Archivo", pArchivo);
                        cmd.Parameters.AddWithValue("@Orden", pOrden);
                        cnn.Open();
                        exito = cmd.ExecuteNonQuery();
                        xResult = (exito >= 1 ? true : false);
                        cmd.Dispose();
                        cnn.Close();
                        cnn.Close();
                    }
                }

                return xResult;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static bool Sp_VentaxFirma_Insert(string pCodVenta, byte[] pImagen, int pCodUser)
        {
            int exito = 0;
            bool xResult = false;
            try
            {
                using (SqlConnection cnn = new SqlConnection(CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_VentaxFirma_Insert", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@codventa", pCodVenta);
                        cmd.Parameters.AddWithValue("@imagen", pImagen);
                        cmd.Parameters.AddWithValue("@coduser", pCodUser);
                        cnn.Open();
                        exito = cmd.ExecuteNonQuery();
                        xResult = (exito >= 1 ? true : false);
                        cmd.Dispose();
                        cnn.Close();
                        cnn.Close();
                    }
                }

                return xResult;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}