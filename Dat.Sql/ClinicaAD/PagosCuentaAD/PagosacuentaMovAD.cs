using Ent.Sql.ClinicaE.PagosCuentaE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dat.Sql.ClinicaAD.PagosCuentaAD
{
    public class PagosacuentaMovAD
    {
        private PagosaCuentaMovE LlenarEntidad(IDataReader dr, PagosaCuentaMovE pPagosacuentaMovE)
        {
            PagosaCuentaMovE oPagosacuentaMovE = new PagosaCuentaMovE();
            switch (pPagosacuentaMovE.Orden)
            {
                case 1:
                    {
                        oPagosacuentaMovE.CodTipopago = (string) dr["cod_tipopago"];
                        oPagosacuentaMovE.Monto = (double) dr["monto"];
                        oPagosacuentaMovE.CodPresotor = (string) dr["codpresotor"];
                        oPagosacuentaMovE.IdePagosacuenta = (int) dr["ide_pagosacuenta"];
                        break;
                    }
            }
            return oPagosacuentaMovE;
        }

        public List<PagosaCuentaMovE> Sp_PagosacuentaMov_Consulta(PagosaCuentaMovE pPagosacuentaMovE)
        {
            IDataReader dr;
            PagosaCuentaMovE oPagosacuentaMovE = null/* TODO Change to default(_) if this is not a reference type */;
            List<PagosaCuentaMovE> oListar = new List<PagosaCuentaMovE>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_PagosacuentaMov_Consulta", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@ide_pagosacuenta", pPagosacuentaMovE.IdePagosacuenta);
                        cmd.Parameters.AddWithValue("@orden", pPagosacuentaMovE.Orden);
                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oPagosacuentaMovE = LlenarEntidad(dr, pPagosacuentaMovE);
                            oListar.Add(oPagosacuentaMovE);
                        }
                        dr.Close();
                        cnn.Close();

                        return oListar;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Sp_PagoaCuentaMov_Insert(PagosaCuentaMovE pPagosacuentaMovE)
        {
            bool Result = false;
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_PagoaCuentaMov_Insert", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@codtipopago", pPagosacuentaMovE.CodTipopago);
                        cmd.Parameters.AddWithValue("@monto", pPagosacuentaMovE.Monto);
                        cmd.Parameters.AddWithValue("@codpresotor", pPagosacuentaMovE.CodPresotor);
                        cnn.Open();
                        if (cmd.ExecuteNonQuery() >= 1)
                            Result = true;

                        cmd.Dispose(); // Se liberan todos los recursos de la 
                        cnn.Close(); // Se cierre la conexión
                        cnn.Dispose(); // Se liberan todos los recursos de la conexión
                        return Result;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
