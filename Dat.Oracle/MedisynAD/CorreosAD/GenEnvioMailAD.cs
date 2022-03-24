using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Oracle.ManagedDataAccess.Client;
using Ent.Oracle.MedisynE.CorreosE;
using System.Data;

namespace Dat.Oracle.MedisynAD.CorreosAD
{
    public class GenEnvioMailAD
    {
        private GenEnvioMailE LlenarEntidad(IDataReader dr)
        {
            GenEnvioMailE oGenEnvioMailE = new GenEnvioMailE();

            oGenEnvioMailE.IdMail = (string)dr["id_mail"];
            oGenEnvioMailE.MailTo = (string)dr["mail_to"];
            oGenEnvioMailE.MailCC = (string)dr["mail_cc"];
            oGenEnvioMailE.MailBody = (string)dr["mail_body"];
            oGenEnvioMailE.MailSubjet = (string)dr["mail_subjet"];

            return oGenEnvioMailE;
        }

        public List<GenEnvioMailE> ConsultarEnvioMail(ref int IdMailUltimo)
        {
            IDataReader dr;
            List<GenEnvioMailE> ListGenEnvioMailE = new List<GenEnvioMailE>();
            string wSqlQuery = "";

            try
            {
                wSqlQuery = "" + "select m.id_mail, nvl2(m.mail_to, m.mail_to, ' ') as mail_to, " + " nvl2(m.mail_cc, m.mail_cc, ' ') as mail_cc, nvl2(m.mail_body, m.mail_body, ' ') as mail_body, m.mail_subjet " + "from gen_envio_mail m " + "where to_number( m.id_mail, 9999999999) > " + IdMailUltimo.ToString() + " " + "order by to_number( m.id_mail, 9999999999)";

                using (OracleConnection cnn = new OracleConnection(VariablesGlobales.CnnMedisyn))
                {
                    using (OracleCommand cmd = new OracleCommand(wSqlQuery, cnn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                            ListGenEnvioMailE.Add(LlenarEntidad(dr));
                        dr.Dispose();
                        dr.Close();
                        cmd.Dispose();
                        cnn.Dispose();
                        cnn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("GenEnvioMailAD - ConsultarEnvioMail: " + ex.Message);
            }
            return ListGenEnvioMailE;
        }
    }
}
