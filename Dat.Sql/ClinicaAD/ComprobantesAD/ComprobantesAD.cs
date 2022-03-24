using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using Ent.Sql.ClinicaE.ComprobantesE;
using System.Data;

namespace Dat.Sql.ClinicaAD.ComprobantesAD
{
    public class ComprobantesAD
    {
        private ComprobantesE LlenarEntidad(IDataReader dr, ComprobantesE pComprobantesE)
        {
            ComprobantesE oComprobantesE = new ComprobantesE();
            switch (pComprobantesE.Orden)
            {
                case 1:
                    {
                        oComprobantesE.CodComprobante = (string)dr["codcomprobante"];
                        oComprobantesE.CodLiquidacion = (string)dr["codliquidacion"];
                        oComprobantesE.CodAtencion = (string)dr["codatencion"];
                        oComprobantesE.ANombreDeQuien = (string)dr["anombredequien"];
                        oComprobantesE.Ruc = (string)dr["ruc"];
                        oComprobantesE.FechaEmision = (DateTime)dr["fechaemision"];
                        oComprobantesE.FechaFacturacion = (DateTime)dr["fechafacturacion"];
                        oComprobantesE.FechaCancelacion = (DateTime)dr["fechacancelacion"];
                        oComprobantesE.Estado = (string)dr["estado"];
                        oComprobantesE.SaldoPago = (double)dr["saldopago"];
                        oComprobantesE.Interes = (double)dr["interes"];
                        oComprobantesE.NumeroLetras = (double)dr["numeroletras"];
                        oComprobantesE.Porcentajeimpuesto = (double)dr["porcentajeimpuesto"];
                        oComprobantesE.CodImpuesto = (string)dr["codimpuesto"];
                        oComprobantesE.MontoImpuesto = (double)dr["montoimpuesto"];
                        oComprobantesE.Monto = (double)dr["monto"];
                        oComprobantesE.Fechaanulacion = (DateTime)dr["fechaanulacion"];
                        oComprobantesE.Codturno = (string)dr["codturno"];
                        oComprobantesE.Correlativo = (string)dr["correlativo"];
                        oComprobantesE.Fechagenerafactura = (DateTime)dr["fechagenerafactura"];
                        oComprobantesE.Flagprocesada = (bool)dr["flagprocesada"];
                        oComprobantesE.Paraquien = (string)dr["paraquien"];
                        oComprobantesE.Direccion = (string)dr["direccion"];
                        oComprobantesE.Nuevocomprobante = (string)dr["nuevocomprobante"];
                        oComprobantesE.Observacion = (string)dr["observacion"];
                        oComprobantesE.Quiencreoregistro = (string)dr["quiencreoregistro"];
                        oComprobantesE.Flagdolares = (string)dr["flagdolares"];
                        oComprobantesE.Montodolares = (double)dr["montodolares"];
                        oComprobantesE.Montoimpuestodolares = (double)dr["montoimpuestodolares"];
                        oComprobantesE.Tipodecambio = (double)dr["tipodecambio"];
                        oComprobantesE.Concepto = (string)dr["concepto"];
                        oComprobantesE.Tipoimpresion = (string)dr["tipoimpresion"];
                        oComprobantesE.Codaseguradora = (string)dr["codaseguradora"];
                        oComprobantesE.Codpaciente = (string)dr["codpaciente"];
                        oComprobantesE.Numeroplanilla = (string)dr["numeroplanilla"];
                        oComprobantesE.Correlativoletra = (string)dr["correlativoletra"];
                        oComprobantesE.Provision = (string)dr["provision"];
                        oComprobantesE.Fechaprovision = (DateTime)dr["fechaprovision"];
                        oComprobantesE.CodEmpresa = (string)dr["codempresa"];
                        oComprobantesE.Codmedicotercero = (string)dr["codmedicotercero"];
                        oComprobantesE.Tipofactura = (string)dr["tipofactura"];
                        oComprobantesE.CodTipoFactura = (string)dr["codtipofactura"];
                        oComprobantesE.Codcia = (string)dr["codcia"];
                        oComprobantesE.Tipooperacion = (string)dr["tipooperacion"];
                        oComprobantesE.Fechaoperacion = (DateTime)dr["fechaoperacion"];
                        oComprobantesE.Codigo = (string)dr["codigo"];
                        oComprobantesE.Montoinafecto = (double)dr["montoinafecto"];
                        oComprobantesE.Montoinafectodolares = (double)dr["montoinafectodolares"];
                        oComprobantesE.Cuenta = (string)dr["cuenta"];
                        oComprobantesE.Codpersonal = (string)dr["codpersonal"];
                        oComprobantesE.Fechaprovisiontributaria = (DateTime)dr["fechaprovisiontributaria"];
                        oComprobantesE.Provisiontributaria = (string)dr["provisiontributaria"];
                        oComprobantesE.Tipdocidentidad = (string)dr["tipdocidentidad"];
                        oComprobantesE.Docidentidad = (string)dr["docidentidad"];
                        oComprobantesE.UsrRegistra = (int)dr["usr_registra"];
                        oComprobantesE.FecRegistra = (DateTime)dr["fec_registra"];
                        oComprobantesE.Codcomprobantee = (string)dr["codcomprobantee"];
                        oComprobantesE.FlgElectronico = (bool)dr["flg_electronico"];
                        oComprobantesE.FlgGratuito = (bool)dr["flg_gratuito"];
                        oComprobantesE.Cardcode = (string)dr["cardcode"];
                        break;
                    }
            }
            return oComprobantesE;
        }

        public List<ComprobantesE> Sp_Comprobantes_Consulta(ComprobantesE pComprobantesE)
        {
            IDataReader dr;
            ComprobantesE oComprobantesE;
            List<ComprobantesE> oListar = new List<ComprobantesE>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Comprobantes_Consulta", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@orden", pComprobantesE.Orden);
                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oComprobantesE = LlenarEntidad(dr, pComprobantesE);
                            oListar.Add(oComprobantesE);
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

        public List<ComprobantesE> Sp_Comprobante_Buscando(ComprobantesE pComprobantesE)
        {
            IDataReader dr;
            ComprobantesE oComprobantesE;
            List<ComprobantesE> oListar = new List<ComprobantesE>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Comprobante_Buscando", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@codigo", pComprobantesE.CodComprobante);
                        cmd.Parameters.AddWithValue("@codempresa", pComprobantesE.CodEmpresa);
                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oComprobantesE = LlenarEntidad(dr, pComprobantesE);
                            oListar.Add(oComprobantesE);
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

        public int Sp_Comprobante_Insert(ref ComprobantesE pComprobantesE)
        {
            bool xResult = false;
            int xReturn;
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Comprobante_Insert", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@return", "").Direction = ParameterDirection.ReturnValue;
                        cmd.Parameters.AddWithValue("@tipocomprobante", pComprobantesE.TipoComprobante);
                        cmd.Parameters.AddWithValue("@codliquidacion", pComprobantesE.CodLiquidacion);
                        cmd.Parameters.AddWithValue("@monto", pComprobantesE.Monto);
                        cmd.Parameters.AddWithValue("@anombredequien", pComprobantesE.ANombreDeQuien);
                        cmd.Parameters.AddWithValue("@ruc", pComprobantesE.Ruc);
                        cmd.Parameters.AddWithValue("@direccion", pComprobantesE.Direccion);
                        cmd.Parameters.AddWithValue("@tipopago", pComprobantesE.TipoPago);
                        cmd.Parameters.AddWithValue("@nombreentidad", pComprobantesE.NombreEntidad);
                        cmd.Parameters.AddWithValue("@numeroentidad", pComprobantesE.NumeroEntidad);
                        cmd.Parameters.AddWithValue("@operacion", pComprobantesE.Operacion);
                        cmd.Parameters.AddWithValue("@variostipopago", pComprobantesE.VariosTipoPago);
                        // cmd.Parameters.Add(ParametroSql("@codcomprobante", ParameterDirection.Output, SqlDbType.VarChar, 11, pComprobantesE.CodComprobante))
                        cmd.Parameters.Add(VariablesGlobales.ParametroSql("@codcomprobante", ParameterDirection.InputOutput, SqlDbType.VarChar, 11, pComprobantesE.CodComprobante));
                        cmd.Parameters.AddWithValue("@moneda", pComprobantesE.Moneda);
                        cmd.Parameters.AddWithValue("@codempresa", pComprobantesE.CodEmpresa);
                        cmd.Parameters.AddWithValue("@codterminal", pComprobantesE.CodTerminal);
                        cnn.Open();
                        cmd.ExecuteNonQuery();
                        xReturn = System.Convert.ToInt32(cmd.Parameters["@return"].Value);
                        pComprobantesE.CodComprobante = cmd.Parameters["@codcomprobante"].Value + "";
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

        public bool Sp_Comprobante_Update(ComprobantesE pComprobantesE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Comprobante_Update", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@campo", pComprobantesE.Campo);
                        cmd.Parameters.AddWithValue("@codigo", pComprobantesE.CodComprobante);
                        cmd.Parameters.AddWithValue("@codempresa", pComprobantesE.CodEmpresa);
                        cmd.Parameters.AddWithValue("@nuevovalor", pComprobantesE.NuevoValor);
                        cnn.Open();

                        int rowResult = cmd.ExecuteNonQuery();
                        cnn.Close();
                        cmd.Dispose();
                        if (rowResult >= 1)
                            return true;
                        else
                            return false;

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
