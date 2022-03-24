using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Dat.Oracle.MedisynAD.HisADTAD
{
    public class HisADTAD
    {
        public string Insert_HIS_ADT(int COD_EMPRESA, string COD_SUCURSAL, string EVENT_ID, string EVENT_DATETIME, string EVENT_TYPE_ID, string ID_PACIENTE, string RUT_PACIENTE, string TIPO_PACIENTE, string DEATH_INDICATOR, string CAT_NAME, string LAST_NAME, string FIRST_NAME, string BIRTH_DATE, string GENDER_KEY, string LAST_UPDATED, string STREET_ADDRESS, string CITY, string COUNTRY, string PHONE_NUMBER, string PRIMARY, string PATIENT_CLASS_KEY)
        {
            try
            {
                try
                {
                    string wSqlQuery = "";

                    wSqlQuery = "" + "PKG_HIS_XML_EVENTS.INSERT_HIS_XML_EVENTS_ADT";

                    using (OracleConnection cnn = new OracleConnection(VariablesGlobales.CnnMedisyn))
                    {
                        using (OracleCommand cmd = new OracleCommand(wSqlQuery, cnn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add(new OracleParameter("T_COD_EMPRESA", OracleDbType.Int32)).Value =  COD_EMPRESA;
                            cmd.Parameters.Add(new OracleParameter("T_COD_SUCURSAL", OracleDbType.Varchar2)).Value = COD_SUCURSAL;
                            cmd.Parameters.Add(new OracleParameter("T_EVENT_ID", OracleDbType.Varchar2)).Value = EVENT_ID;
                            cmd.Parameters.Add(new OracleParameter("T_EVENT_DATETIME", OracleDbType.Date)).Value = EVENT_DATETIME;
                            cmd.Parameters.Add(new OracleParameter("T_EVENT_TYPE_ID", OracleDbType.Varchar2)).Value = EVENT_TYPE_ID;
                            cmd.Parameters.Add(new OracleParameter("X_ID_PACIENTE", OracleDbType.Varchar2)).Value = ID_PACIENTE;
                            cmd.Parameters.Add(new OracleParameter("X_RUT_PACIENTE", OracleDbType.NVarchar2)).Value = RUT_PACIENTE;
                            cmd.Parameters.Add(new OracleParameter("X_TIPO_PACIENTE", OracleDbType.Varchar2)).Value = TIPO_PACIENTE;
                            cmd.Parameters.Add(new OracleParameter("X_DEATH_INDICATOR", OracleDbType.Varchar2)).Value = DEATH_INDICATOR;
                            cmd.Parameters.Add(new OracleParameter("X_CAT_NAME", OracleDbType.Varchar2)).Value = CAT_NAME;
                            cmd.Parameters.Add(new OracleParameter("X_LAST_NAME", OracleDbType.Varchar2)).Value = LAST_NAME;
                            cmd.Parameters.Add(new OracleParameter("X_FIRST_NAME", OracleDbType.Varchar2)).Value = FIRST_NAME;
                            cmd.Parameters.Add(new OracleParameter("X_BIRTH_DATE", OracleDbType.Varchar2)).Value = BIRTH_DATE;
                            cmd.Parameters.Add(new OracleParameter("X_GENDER_KEY", OracleDbType.Varchar2)).Value = GENDER_KEY;
                            cmd.Parameters.Add(new OracleParameter("X_LAST_UPDATED", OracleDbType.Varchar2)).Value = LAST_UPDATED;
                            cmd.Parameters.Add(new OracleParameter("X_STREET_ADDRESS", OracleDbType.Varchar2)).Value = STREET_ADDRESS;
                            cmd.Parameters.Add(new OracleParameter("X_CITY", OracleDbType.Varchar2)).Value = CITY;
                            cmd.Parameters.Add(new OracleParameter("X_COUNTRY", OracleDbType.Varchar2)).Value = COUNTRY;
                            cmd.Parameters.Add(new OracleParameter("X_PHONE_NUMBER", OracleDbType.Varchar2)).Value = PHONE_NUMBER;
                            cmd.Parameters.Add(new OracleParameter("X_PRIMARY", OracleDbType.Varchar2)).Value = PRIMARY;
                            cmd.Parameters.Add(new OracleParameter("X_PATIENT_CLASS_KEY", OracleDbType.Varchar2)).Value = PATIENT_CLASS_KEY;

                            cnn.Open();
                            OracleDataAdapter da = new OracleDataAdapter(cmd);
                            try
                            {
                                DataSet ds = new DataSet();
                                da.Fill(ds);
                                return "OK-WS-ADT";
                            }
                            catch (Exception ex)
                            {
                                return "Error al actualizar datos desde el Web Service - WS" + ex.Message;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("ConsultarReservasPacientes: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                return "Error de conexión - WS" + ex.Message;
            }
        }
    }
}
