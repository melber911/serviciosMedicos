using Ent.Sql.ClinicaE.OtrosE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dat.Sql.ClinicaAD.OtrosAD
{
    public class SisCorreodestinatarioMaeAD
    {
        private SisCorreodestinatarioMaeE LlenarEntidad(IDataReader dr, SisCorreodestinatarioMaeE pSisCorreodestinatarioMaeE)
        {
            SisCorreodestinatarioMaeE oSisCorreodestinatarioMaeE = new SisCorreodestinatarioMaeE();
            oSisCorreodestinatarioMaeE.DscDestinatario = (string)dr["destinatario"];
            return oSisCorreodestinatarioMaeE;
        }

        public List<SisCorreodestinatarioMaeE> Sp_CorreoDestinatario_Consulta(SisCorreodestinatarioMaeE pSisCorreodestinatarioMaeE)
        {
            IDataReader dr;
            SisCorreodestinatarioMaeE oSisCorreodestinatarioMaeE = null/* TODO Change to default(_) if this is not a reference type */;
            List<SisCorreodestinatarioMaeE> oListar = new List<SisCorreodestinatarioMaeE>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_CorreoDestinatario_Consulta", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@cod_lista", pSisCorreodestinatarioMaeE.CodLista);
                        cmd.Parameters.AddWithValue("@dsc_tipo", pSisCorreodestinatarioMaeE.CodTipo);
                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oSisCorreodestinatarioMaeE = LlenarEntidad(dr, pSisCorreodestinatarioMaeE);
                            oListar.Add(oSisCorreodestinatarioMaeE);
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
    }
}
