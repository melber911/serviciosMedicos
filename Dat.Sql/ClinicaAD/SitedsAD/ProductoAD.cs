using Ent.Sql.ClinicaE.SitedsE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dat.Sql.ClinicaAD.SitedsAD
{
    public class ProductoAD
    {
        private ProductoE LlenarEntidad(IDataReader dr, ProductoE PProducto)
        {
            ProductoE oProductoE = new ProductoE();
            // Select Case PDatosGenerales.OR .Orden
            // Case 1

            oProductoE.cIafasCode = (string) dr["cIafasCode"];
            oProductoE.cProdCode = (string) dr["cProdCode"];
            oProductoE.nProdName = (string) dr["nProdName"];
            oProductoE.dTipoProducto = (string) dr["dTipoProducto"];
            oProductoE.cIafaCodeCia = (string) dr["cIafaCodeCia"];
            oProductoE.dEstado = (string) dr["dEstado"];
            // End Select
            return oProductoE;
        }

        public int Sp_Producto_Insert(ref ProductoE pProductoE)
        {
            bool xResult = false;
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Producto_Insert", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@pcIafasCode", pProductoE.cIafasCode);
                        cmd.Parameters.AddWithValue("@pcProdCode", pProductoE.cProdCode);
                        cmd.Parameters.AddWithValue("@pnProdName", pProductoE.nProdName);
                        cmd.Parameters.AddWithValue("@pdTipoProducto", pProductoE.dTipoProducto);
                        cmd.Parameters.AddWithValue("@pcIafaCodeCia", pProductoE.cIafaCodeCia);
                        cmd.Parameters.AddWithValue("@pdEstado", pProductoE.dEstado);
                        cmd.Parameters.Add(VariablesGlobales.ParametroSql("@p_codllaveProd", ParameterDirection.Output, SqlDbType.VarChar, 20, pProductoE.codllaveProd));
                        cnn.Open();

                        cmd.ExecuteNonQuery();
                        pProductoE.codllaveProd = cmd.Parameters["@p_codllaveProd"].Value + "";
                        xResult = true;

                        cnn.Close();
                        cmd.Dispose();
                    }
                }

                return Convert.ToInt32(xResult);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
