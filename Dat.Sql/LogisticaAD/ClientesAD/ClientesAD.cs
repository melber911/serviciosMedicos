using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Ent.Sql.LogisticaE.ClientesE;


namespace Dat.Sql.LogisticaAD.ClientesAD
{
    public class ClientesAD
    {
        private ClientesE LlenarEntidad(IDataReader dr, ClientesE pClientesE)
        {
            ClientesE oClientesE = new ClientesE();
            switch (pClientesE.Orden)
            {
                case 4:
                    {
                        oClientesE.CodCliente = (string)dr["codcliente"];
                        // oClientesE.CodPaciente = dr("codpaciente")
                        // oClientesE.Nombre = dr("nombre")
                        // oClientesE.DocIdentidad = dr("docidentidad")
                        // oClientesE.Direccion = dr("direccion")
                        // oClientesE.CodDistrito = dr("coddistrito")
                        // oClientesE.CodProvincia = dr("codprovincia")
                        // oClientesE.Telefono = dr("telefono")
                        // oClientesE.CodCivil = dr("codcivil")
                        // oClientesE.FechaNacimiento = dr("fechanacimiento")
                        // oClientesE.Sexo = dr("sexo")
                        // oClientesE.TipDocIdentidad = dr("tipdocidentidad")
                        oClientesE.Ruc = (string)dr["ruc"];
                        break;
                    }
            }
            return oClientesE;
        }

        public List<ClientesE> Sp_Clientes_Consulta(ClientesE pClientesE)
        {
            IDataReader dr;
            ClientesE oClientesE;
            List<ClientesE> oListar = new List<ClientesE>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnLogistica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Clientes_Consulta", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@buscar", pClientesE.Buscar);
                        cmd.Parameters.AddWithValue("@key", pClientesE.Key);
                        cmd.Parameters.AddWithValue("@numerolineas", pClientesE.NumeroLineas);
                        cmd.Parameters.AddWithValue("@orden", pClientesE.Orden);
                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oClientesE = LlenarEntidad(dr, pClientesE);
                            oListar.Add(oClientesE);
                        }
                        dr.Close(); // Se cierre la conexión.
                        dr.Dispose(); // Se liberan todos los recursos del data reader.
                        cmd.Dispose(); // Se liberan todos los recursos del comando de ejecución.
                        cnn.Close(); // Se cierre la conexión.
                        cnn.Dispose(); // Se liberan todos los recursos de la conexión.

                        return oListar;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Sp_Clientes_Insert(ClientesE pClientesE)
        {
            try
            {
                bool result = false;
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnLogistica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Clientes_Insert", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@codcliente", pClientesE.CodCliente);
                        cmd.Parameters.AddWithValue("@codpaciente", pClientesE.CodPaciente);
                        cmd.Parameters.AddWithValue("@nombre", pClientesE.Nombre);
                        cmd.Parameters.AddWithValue("@docidentidad", pClientesE.DocIdentidad);
                        cmd.Parameters.AddWithValue("@direccion", pClientesE.Direccion);
                        cmd.Parameters.AddWithValue("@coddistrito", pClientesE.CodDistrito);
                        cmd.Parameters.AddWithValue("@codprovincia", pClientesE.CodProvincia);
                        cmd.Parameters.AddWithValue("@telefono", pClientesE.Telefono);
                        cmd.Parameters.AddWithValue("@codcivil", pClientesE.CodCivil);
                        cmd.Parameters.AddWithValue("@fechanacimiento", pClientesE.FechaNacimiento);
                        cmd.Parameters.AddWithValue("@sexo", pClientesE.Sexo);
                        cmd.Parameters.AddWithValue("@tipdocidentidad", pClientesE.TipDocIdentidad);
                        cmd.Parameters.AddWithValue("@ruc", pClientesE.Ruc);
                        cmd.Parameters.AddWithValue("@observaciones", pClientesE.Observaciones);
                        cmd.Parameters.AddWithValue("@estado", pClientesE.Estado);
                        cmd.Parameters.AddWithValue("@vip", pClientesE.Vip);
                        cmd.Parameters.AddWithValue("@correo", pClientesE.Correo);
                        cmd.Parameters.AddWithValue("@cod_tipopersona", pClientesE.CodTipoPersona);
                        cmd.Parameters.AddWithValue("@dsc_appaterno", pClientesE.DscApPaterno);
                        cmd.Parameters.AddWithValue("@dsc_apmaterno", pClientesE.DscApMaterno);
                        cmd.Parameters.AddWithValue("@dsc_segundonombre", pClientesE.DscSegundoNombre);
                        cmd.Parameters.AddWithValue("@dsc_primernombre", pClientesE.DscPrimerNombre);
                        cmd.Parameters.AddWithValue("@cod_ubigeo", pClientesE.CodUbigeo);
                        cmd.Parameters.AddWithValue("@cardcode", pClientesE.CardCode);
                        cmd.Parameters.AddWithValue("@flg_enviosap", pClientesE.FlgEnvioSap);
                        cmd.Parameters.AddWithValue("@fec_enviosap", pClientesE.FecEnvioSap);
                        cmd.Parameters.AddWithValue("@ide_docentrysap", pClientesE.IdeDocentrySap);
                        cmd.Parameters.AddWithValue("@fec_docentrysap", pClientesE.FecDocentrySap);
                        cmd.Parameters.AddWithValue("@cod_clienteanterior", pClientesE.CodClienteAnterior);
                        cmd.Parameters.AddWithValue("@fec_baja", pClientesE.FecBaja);
                        cmd.Parameters.AddWithValue("@usr_baja", pClientesE.UsrBaja);
                        cmd.Parameters.AddWithValue("@fec_recepcionsap", pClientesE.FecRecepcionSap);
                        cnn.Open();
                        if (cmd.ExecuteNonQuery() >= 1)
                            result = true;
                        cmd.Dispose(); // Se liberan todos los recursos del comando de ejecución.
                        cnn.Close(); // Se cierre la conexión.
                        cnn.Dispose(); // Se liberan todos los recursos de la conexión.
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Sp_Clientes_Insert_App(ClientesE pClientesE)
        {
            try
            {
                bool result = false;
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnLogistica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Clientes_Insert_App", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@cod_paciente", pClientesE.CodPaciente);

                        cmd.Parameters.AddWithValue("@dsc_primernombre", pClientesE.DscPrimerNombre);
                        cmd.Parameters.AddWithValue("@dsc_segundonombre", pClientesE.DscSegundoNombre);
                        cmd.Parameters.AddWithValue("@dsc_appaterno", pClientesE.DscApPaterno);
                        cmd.Parameters.AddWithValue("@dsc_apmaterno", pClientesE.DscApMaterno);

                        cmd.Parameters.AddWithValue("@docidentidad", pClientesE.DocIdentidad);
                        cmd.Parameters.AddWithValue("@tipdocidentidad", pClientesE.TipDocIdentidad);

                        cmd.Parameters.AddWithValue("@direccion", pClientesE.Direccion);
                        cmd.Parameters.AddWithValue("@telefono", pClientesE.Telefono);
                        cmd.Parameters.AddWithValue("@sexo", pClientesE.Sexo);
                        cmd.Parameters.AddWithValue("@correo", pClientesE.Correo);
                        cmd.Parameters.AddWithValue("@cod_ubigeo", pClientesE.CodUbigeo);
                        cmd.Parameters.AddWithValue("@fechanacimiento", pClientesE.FechaNacimiento);

                        cmd.Parameters.AddWithValue("@ruc", pClientesE.Ruc);
                        cmd.Parameters.AddWithValue("@cod_tipopersona", pClientesE.CodTipoPersona);

                        cmd.Parameters.AddWithValue("@observaciones", pClientesE.Observaciones);
                        cmd.Parameters.AddWithValue("@codcivil", pClientesE.CodCivil);

                        cmd.Parameters.Add(VariablesGlobales.ParametroSql("@codcliente", ParameterDirection.Output, SqlDbType.VarChar, 8, pClientesE.CodCliente));

                        cnn.Open();
                        if (cmd.ExecuteNonQuery() >= 1)
                        {
                            pClientesE.CodCliente = (string)cmd.Parameters["@codcliente"].Value;
                            result = true;
                        }

                        cmd.Dispose(); // Se liberan todos los recursos del comando de ejecución.
                        cnn.Close(); // Se cierre la conexión.
                        cnn.Dispose(); // Se liberan todos los recursos de la conexión.
                    }
                }
                return result;
            }
            catch (Exception ex)
            { throw new Exception(ex.Message); }
        }

        public bool Sp_Clientes_Update(ClientesE pClientesE)
        {
            try
            {
                bool result = false;
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnLogistica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Clientes_Update", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@codcliente", pClientesE.CodCliente);
                        cmd.Parameters.AddWithValue("@codpaciente", pClientesE.CodPaciente);
                        cmd.Parameters.AddWithValue("@nombre", pClientesE.Nombre);
                        cmd.Parameters.AddWithValue("@docidentidad", pClientesE.DocIdentidad);
                        cmd.Parameters.AddWithValue("@direccion", pClientesE.Direccion);
                        cmd.Parameters.AddWithValue("@coddistrito", pClientesE.CodDistrito);
                        cmd.Parameters.AddWithValue("@codprovincia", pClientesE.CodProvincia);
                        cmd.Parameters.AddWithValue("@telefono", pClientesE.Telefono);
                        cmd.Parameters.AddWithValue("@codcivil", pClientesE.CodCivil);
                        cmd.Parameters.AddWithValue("@fechanacimiento", pClientesE.FechaNacimiento);
                        cmd.Parameters.AddWithValue("@sexo", pClientesE.Sexo);
                        cmd.Parameters.AddWithValue("@tipdocidentidad", pClientesE.TipDocIdentidad);
                        cmd.Parameters.AddWithValue("@ruc", pClientesE.Ruc);
                        cmd.Parameters.AddWithValue("@observaciones", pClientesE.Observaciones);
                        cmd.Parameters.AddWithValue("@estado", pClientesE.Estado);
                        cmd.Parameters.AddWithValue("@vip", pClientesE.Vip);
                        cmd.Parameters.AddWithValue("@correo", pClientesE.Correo);
                        cmd.Parameters.AddWithValue("@cod_tipopersona", pClientesE.CodTipoPersona);
                        cmd.Parameters.AddWithValue("@dsc_appaterno", pClientesE.DscApPaterno);
                        cmd.Parameters.AddWithValue("@dsc_apmaterno", pClientesE.DscApMaterno);
                        cmd.Parameters.AddWithValue("@dsc_segundonombre", pClientesE.DscSegundoNombre);
                        cmd.Parameters.AddWithValue("@dsc_primernombre", pClientesE.DscPrimerNombre);
                        cmd.Parameters.AddWithValue("@cod_ubigeo", pClientesE.CodUbigeo);
                        cmd.Parameters.AddWithValue("@cardcode", pClientesE.CardCode);
                        cmd.Parameters.AddWithValue("@flg_enviosap", pClientesE.FlgEnvioSap);
                        cmd.Parameters.AddWithValue("@fec_enviosap", pClientesE.FecEnvioSap);
                        cmd.Parameters.AddWithValue("@ide_docentrysap", pClientesE.IdeDocentrySap);
                        cmd.Parameters.AddWithValue("@fec_docentrysap", pClientesE.FecDocentrySap);
                        cmd.Parameters.AddWithValue("@cod_clienteanterior", pClientesE.CodClienteAnterior);
                        cmd.Parameters.AddWithValue("@fec_baja", pClientesE.FecBaja);
                        cmd.Parameters.AddWithValue("@usr_baja", pClientesE.UsrBaja);
                        cmd.Parameters.AddWithValue("@fec_recepcionsap", pClientesE.FecRecepcionSap);
                        cnn.Open();
                        if (cmd.ExecuteNonQuery() >= 1)
                            result = true;

                        cmd.Dispose(); // Se liberan todos los recursos del comando de ejecución.
                        cnn.Close(); // Se cierre la conexión.
                        cnn.Dispose(); // Se liberan todos los recursos de la conexión.
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Sp_Clientes_UpdatexCampo(ClientesE pClientesE)
        {
            try
            {
                bool result = false;
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnLogistica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Clientes_UpdatexCampo", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@nuevo_valor", pClientesE.NuevoValor);
                        cmd.Parameters.AddWithValue("@campo", pClientesE.Campo);
                        cnn.Open();
                        if (cmd.ExecuteNonQuery() >= 1)
                            result = true;

                        cmd.Dispose(); // Se liberan todos los recursos del comando de ejecución.
                        cnn.Close(); // Se cierre la conexión.
                        cnn.Dispose(); // Se liberan todos los recursos de la conexión.
                    }
                }
                return (result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Sp_Clientes_Delete(ClientesE pClientesE)
        {
            try
            {
                bool result = false;
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnLogistica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Clientes_Delete", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cnn.Open();
                        if (cmd.ExecuteNonQuery() >= 1)
                            result = true;

                        cmd.Dispose(); // Se liberan todos los recursos del comando de ejecución.
                        cnn.Close(); // Se cierre la conexión.
                        cnn.Dispose(); // Se liberan todos los recursos de la conexión.
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}