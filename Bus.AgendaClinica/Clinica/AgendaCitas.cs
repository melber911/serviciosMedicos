using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ent.Sql.ClinicaE.OtrosE;
using Ent.Sql.ClinicaE.MedicosE;
using Dat.Sql.ClinicaAD.MedicosAD;
using Ent.Sql.ClinicaE.MedisynE;
using Dat.Sql.ClinicaAD.MedisynAD;
using Ent.Sql.ClinicaE.EspecialidadesE;
using Dat.Sql.ClinicaAD.EspecialidadesAD;
using Dat.Sql.ClinicaAD.OtrosAD;
using Ent.Oracle.MedisynE.ReservasE;
using Dat.Oracle.MedisynAD.ReservasAD;
using Ent.Sql.ClinicaE.PacientesE;
using Dat.Sql.ClinicaAD.PacientesAD;
using Ent.Sql.LogisticaE.ClientesE;
using Dat.Sql.LogisticaAD.ClientesAD;
//using Bus.AgendaClinica.WsReservaWebTisal;
using System.Xml;
using System.Data;
using WsReservaWebTisal;
using System.Text.Json;

namespace Bus.AgendaClinica.Clinica
{
    public class AgendaCitas
    {
        public string Rut_Paciente { get; private set; }


        /// <summary>
        ///     ''' Este método recorre toda las columnas de la fila y los concatena en texto para devolver el resultado
        ///     ''' </summary>
        ///     ''' <param name="row">Fila del Registro</param>
        ///     ''' <param name="columns">Columnas del Registro</param>
        ///     ''' <returns></returns>
        private string fnStringBodyXML(DataRow row, DataColumnCollection columns)
        {
            string stringResultXml = "";

            for (int i = 0; i <= columns.Count - 1; i++)
                stringResultXml = stringResultXml + "<" + columns[i].ColumnName + ">" + row[columns[i].ColumnName] + "</" + columns[i].ColumnName + ">";

            return stringResultXml;
        }

        public string fnReservaHoraError(string pMensaje = "No se pudo realizar la reserva, por favor intente en un momento.")
        {
            return @"<XML>
                    <ReservaHora>
                        <Datos_Reserva>
                        <COD_ESTADO>80</COD_ESTADO>
                        <DESC_ESTADO>" + pMensaje + @"</DESC_ESTADO>
                        </Datos_Reserva>
                    </ReservaHora>
                    <Mensaje>
                        <CodMensaje>0</CodMensaje>
                        <DescMensaje></DescMensaje>
                    </Mensaje>
                    <Error>
                        <Error_Cod>0</Error_Cod>
                        <ErrorDesc>SIN ERRORES</ErrorDesc>
                    </Error>
                </XML>";
        }


        public int fnSede(TipoConsultaMedica pTipoConsultaMedica)
        {
            int xResult = 0;

            if (pTipoConsultaMedica == TipoConsultaMedica.PresencialCM)
                xResult = 1;
            else if (pTipoConsultaMedica == TipoConsultaMedica.PresencialJM)
                xResult = 2;

            return xResult;
        }

        /// <summary>
        ///     ''' Obtener la información de la sub especialidad desde el SIC.
        ///     ''' </summary>
        ///     ''' <param name="CodProfMedisyn">Cod. Profesional del medisyn</param>
        ///     ''' <returns></returns>
        public string fnGetSubEspecialidadDatos(string CodProfMedisyn)
        {
            string xResult = "";
            List<MedicosE> oList = new MedicosAD().Sp_Medicos_Consulta(new MedicosE(CodProfMedisyn, 0, 0, 11));

            if (oList.Count >= 1)
                xResult = oList[0].DscObservacionSubEspecialidad;

            return xResult;
        }

        /// <summary>
        ///     ''' Obtener la información de la sub especialidad desde el SIC.
        ///     ''' </summary>
        ///     ''' <param name="CodProfMedisyn">Cod. Profesional del medisyn</param>
        ///     ''' <returns></returns>
        public TarifaParticular MtDatosMedicosSic(string CodProfMedisyn)
        {
            TarifaParticular xResult = new TarifaParticular();
            List<MedicosE> oList = new MedicosAD().Sp_Medicos_Consulta(new MedicosE(CodProfMedisyn, 0, 0, 11));

            if (oList.Count >= 1)
            {
                xResult.CodProf = oList[0].DscObservacionSubEspecialidad;
                xResult.Descripcion = oList[0].DscTituloTarifa;
                xResult.MontoTarifa = oList[0].MntTarifaParticular;
                xResult.Moneda = oList[0].TipMoneda;
                xResult.TipoConsultaMedica = oList[0].CodTipoConsulta;
                xResult.DscSubEspecialidad = oList[0].DscObservacionSubEspecialidad;
            }

            // oMedicosE.CodMedico = dr("codmedico") + ""
            // oMedicosE.CodProfMedisyn = dr("cod_prof_medisyn") + ""
            // oMedicosE.CodTipoConsulta = dr("cod_tipo_consulta") + ""
            // oMedicosE.DscObservacionSubEspecialidad = dr("dsc_observacion_sub_especialidad") + ""
            // oMedicosE.DscTituloTarifa = dr("dsc_titulo_tarifa") + ""
            // oMedicosE.MntTarifaParticular = dr("mnt_tarifa_particular")
            // oMedicosE.TipMoneda = dr("tip_moneda") + ""
            // oMedicosE.TipoConsultaMedica = dr("cod_tipo_consulta") + ""

            return xResult;
        }

        public string fnAgendaApellidoEspecialidad(string responseXML, string pNodoLista, string pMedico, TipoMetodoAgenda pTipoMetodo, TipoConsultaMedica pTipoConsultaMedica)
        {
            XmlDocument oXML = new XmlDocument();
            DataTable dtAgendaApellido = new DataTable();
            string stringXML = "";
            int RowCount = 0;
            List<MedicosE> oListMedicosE = new List<MedicosE>();
            oListMedicosE = new MedicosAD().Sp_Medicos_Consulta(new MedicosE(pMedico, 0, 0, (int)pTipoConsultaMedica));

            oXML.LoadXml(responseXML);

            if (pTipoMetodo == TipoMetodoAgenda.WM_ObtenerAgendaXApellido | pTipoMetodo == TipoMetodoAgenda.WM_ObtenerAgendaEspecialidad)
            {
                dtAgendaApellido = DevolverTabla_XML(oXML, pNodoLista, "Datos", "COD_SUCURSAL", "SUCURSAL", "COD_PROF", "RUT_PROF", "APEPAT_PROF", "APEMAT_PROF", "NOMBRE1_PROF", "COD_ESPECIALIDAD", "DESC_ITEM", "CORRAGENDA", "FECHAINICPROX_AGENDA", "FECHA_SISTEMA", "COD_UNIDAD", "DESC_UNIDAD", "HMUL", "VERSTAFF", "PROXIMA_HORA_DISPONIBLE", "PROXIMA_HORA_DISPONIBLE_CHAR");
                RowCount = dtAgendaApellido.Rows.Count;
            }
            else if (pTipoMetodo == TipoMetodoAgenda.WM_ObtenerAgendaMedico)
            {
                dtAgendaApellido = DevolverTabla_XML(oXML, pNodoLista, "Datos", "COD_SUCURSAL", "SUCURSAL", "COD_PROF", "APEPAT_PROF", "APEMAT_PROF", "NOMBRE1_PROF", "COD_ESPECIALIDAD", "DESC_ITEM", "CORRAGENDA", "FECHAINICPROX_AGENDA", "FECHA_SISTEMA", "COD_UNIDAD", "DESC_UNIDAD", "HMUL", "VERSTAFF", "PROXIMA_HORA_DISPONIBLE", "PROXIMA_HORA_DISPONIBLE_CHAR");
                RowCount = dtAgendaApellido.Rows.Count / 2;
            }

            int Sucursal = fnSede(pTipoConsultaMedica);
            for (int i = 0; i <= (RowCount) - 1; i++)
            {
                for (int j = 0; j <= oListMedicosE.Count - 1; j++)
                {
                    if (Sucursal == 0)
                    {
                        if (oListMedicosE[j].CodProfMedisyn == dtAgendaApellido.Rows[i]["COD_PROF"].ToString())
                        {
                            TarifaParticular obj = new TarifaParticular();
                            obj = MtDatosMedicosSic(dtAgendaApellido.Rows[i]["COD_PROF"].ToString());

                            stringXML = stringXML + "<Datos>";
                            stringXML = stringXML + fnStringBodyXML(dtAgendaApellido.Rows[i], dtAgendaApellido.Columns);
                            // stringXML = stringXML + "<DSC_ESPECIALIDAD_ALTERNO>" + fnGetSubEspecialidadDatos(dtAgendaApellido.Rows[i]("COD_PROF").ToString) + "</DSC_ESPECIALIDAD_ALTERNO>"
                            stringXML = stringXML + "<DSC_ESPECIALIDAD_ALTERNO>" + obj.DscSubEspecialidad + "</DSC_ESPECIALIDAD_ALTERNO>";
                            stringXML = stringXML + "<MONTO_TARIFA_PARTICULAR>" + obj.MontoTarifa + "</MONTO_TARIFA_PARTICULAR>";
                            stringXML = stringXML + "<MONEDA_TARIFA_PARTICULAR>" + obj.Moneda + "</MONEDA_TARIFA_PARTICULAR>";
                            stringXML = stringXML + "<TIPO_CONSULTA_MEDICA>" + obj.TipoConsultaMedica + "</TIPO_CONSULTA_MEDICA>";
                            // MtDatosMedicosSic
                            // xResult.CodProf = oList(0).DscObservacionSubEspecialidad
                            // xResult.Descripcion = oList(0).DscTituloTarifa
                            // xResult.MontoTarifa = oList(0).MntTarifaParticular
                            // xResult.Moneda = oList(0).TipMoneda
                            // xResult.TipoConsultaMedica = oList(0).CodTipoConsulta
                            // xResult.DscSubEspecialidad = oList(0).DscObservacionSubEspecialidad
                            stringXML = stringXML + "</Datos>";

                            break;
                        }
                    }
                    else if ((oListMedicosE[j].CodProfMedisyn == dtAgendaApellido.Rows[i]["COD_PROF"].ToString() && (int)dtAgendaApellido.Rows[i]["COD_SUCURSAL"] == Sucursal))
                    {
                        TarifaParticular obj = new TarifaParticular();
                        obj = MtDatosMedicosSic((string)dtAgendaApellido.Rows[i]["COD_PROF"].ToString());

                        stringXML = stringXML + "<Datos>";
                        stringXML = stringXML + fnStringBodyXML(dtAgendaApellido.Rows[i], dtAgendaApellido.Columns);
                        // stringXML = stringXML + "<DSC_ESPECIALIDAD_ALTERNO>" + fnGetSubEspecialidadDatos(dtAgendaApellido.Rows[i]("COD_PROF").ToString) + "</DSC_ESPECIALIDAD_ALTERNO>"
                        stringXML = stringXML + "<DSC_ESPECIALIDAD_ALTERNO>" + obj.DscSubEspecialidad + "</DSC_ESPECIALIDAD_ALTERNO>";
                        stringXML = stringXML + "<MONTO_TARIFA_PARTICULAR>" + obj.MontoTarifa + "</MONTO_TARIFA_PARTICULAR>";
                        stringXML = stringXML + "<MONEDA_TARIFA_PARTICULAR>" + obj.Moneda + "</MONEDA_TARIFA_PARTICULAR>";
                        stringXML = stringXML + "<TIPO_CONSULTA_MEDICA>" + obj.TipoConsultaMedica + "</TIPO_CONSULTA_MEDICA>";
                        stringXML = stringXML + "</Datos>";
                        break;
                    }
                }
            }

            return stringXML;
        }

        public string fnObtenerEspecialidades(string responseXML, AppCitasEspecialidadesActivas pAppCitasEspecialidadesActivas)
        {
            XmlDocument oXML = new XmlDocument();
            DataTable dtAgendaApellido;
            string stringXML = "";

            List<EspecialidadesE> oListEspecialidadesE = new List<EspecialidadesE>();
            oListEspecialidadesE = new EspecialidadesAD().Sp_Especialidades_Consulta(new EspecialidadesE("", 0, 0, (int)pAppCitasEspecialidadesActivas));

            oXML.LoadXml(responseXML);
            dtAgendaApellido = DevolverTabla_XML(oXML, "Especialidades", "Especialidad", "COD_ITEM", "DESC_ITEM");
            for (int i = 0; i <= dtAgendaApellido.Rows.Count - 1; i++)
            {
                for (int j = 0; j <= oListEspecialidadesE.Count - 1; j++)
                {
                    if (oListEspecialidadesE[j].CodEspMedisyn == dtAgendaApellido.Rows[i]["COD_ITEM"].ToString())
                    {
                        stringXML = stringXML + "<Especialidad>" + fnStringBodyXML(dtAgendaApellido.Rows[i], dtAgendaApellido.Columns) + "</Especialidad>";
                        break;
                    }
                }
            }

            return stringXML;
        }

        /// <summary>
        ///     ''' Esta función sirve para mostrar las sedes activas.
        ///     ''' </summary>
        ///     ''' <returns></returns>
        public string fnObtenerSedes()
        {
            string stringXML = "";

            List<TablasE> oListSedes = new List<TablasE>();
            oListSedes = new TablasAD().Sp_Tablas_Consulta(new TablasE("MEDISYN_SEDES", "", 0, 0, 19));

            for (int i = 0; i <= oListSedes.Count - 1; i++)
                stringXML = stringXML + "<Datos>" + "<COD_ITEM>" + oListSedes[i].Codigo.Trim() + "</COD_ITEM>" + "<DESC_ITEM>" + oListSedes[i].Nombre.Trim() + "</DESC_ITEM>" + "</Datos>";

            return stringXML;
        }

        public string fnObtenerEspecialidadesFinal(string responseXML)
        {
            XmlDocument oXML = new XmlDocument();
            DataTable dt;
            DataTable dtAgendaApellido;
            string stringXML = "";
            string CodItemPrevios = "";

            oXML.LoadXml(responseXML);
            dtAgendaApellido = DevolverTabla_XML(oXML, "Especialidades", "Especialidad", "COD_ITEM", "DESC_ITEM");

            dtAgendaApellido.DefaultView.Sort = "DESC_ITEM Asc";
            dt = dtAgendaApellido.DefaultView.ToTable();
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                if (CodItemPrevios != (string)dt.Rows[i]["COD_ITEM"])
                    stringXML = stringXML + "<Especialidad>" + fnStringBodyXML(dt.Rows[i], dt.Columns) + "</Especialidad>";

                CodItemPrevios = (string)dt.Rows[i]["COD_ITEM"];
            }

            return stringXML;
        }

        // ''' <summary>
        // ''' Validar si el token enviado es correcto. Se valida si el doc. de identidad y el cod. paciente corresponde al token.
        // ''' </summary>
        // ''' <param name="Token">Token</param>
        // ''' <returns></returns>
        // Private Function fnValidarTokenPaciente(ByVal Token As String) As Boolean
        // 'Se puede generar el token con el usuario y clave.
        // 'Para recuperar contraseña, se pedira el usuario y el token y se pedirá el correo electrónico o mobile para validar los datos.
        // Dim result As Boolean = False
        // 'Dim tokenString As String = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpZCI6Ijk5MTM3NyIsImRvYyI6IjA2ODQxODE0IiwiaWF0IjoxNTkwNzAzOTkyMDEzfQ.X_D9LcR2C6X1NtI86_6Os-W2jU7gIWYkxpo9AQIBr4U"
        // Try
        // Dim SecurityToken As JwtSecurityToken = New JwtSecurityToken(Token)
        // Dim CodPaciente As String = SecurityToken.Claims(0).Value,
        // DocIdentidad As String = SecurityToken.Claims(1).Value

        // Dim oList As New List(Of PacientesE)
        // oList = New PacientesAD().Sp_Pacientes_Consulta(New PacientesE(CodPaciente, 0, 0, 15, DocIdentidad))

        // If oList.Count <> 0 Then
        // If oList(0).CodPaciente = CodPaciente Then
        // result = True
        // End If
        // End If
        // Catch ex As Exception

        // End Try
        // Return result
        // End Function

        public class ApiKey
        {
            public string USR { get; set; } = "";
            public string PSW { get; set; } = "";
            public string TipUser { get; set; } = "";
        }

        /// <summary>
        ///     ''' Validar si el token enviado es correcto. Se valida si el doc. de identidad y el cod. paciente corresponde al token.
        ///     ''' </summary>
        ///     ''' <param name="ApiKey">Validar ApiKey </param>
        ///     ''' <returns></returns>
        public bool fnValidarApiKey(string ApiKey)
        {
            bool result = false;
            // ATqxwV+o6Q1x9Ik4frbCfgijsHdX1inC5qntZyzrg2JXyBf8WcT/hNsTcVjoH3pT            
            try
            {
                string SecurityApiKey = Utilities.Criptography.DecryptConectionString(ApiKey);

                // Dim x As String = Utilities.Criptography.EncryptConectionString("{""USR"":""CSF"",""PSW"":""P@ssw0rd"",""Tipo"":""PreAdmisionHospitalaria""}")
                // Dim SecurityApiKey2 As String = Utilities.Criptography.DecryptConectionString(x)
                // USR:SOLERA,PSW:s0l3r@_andr01d,TipUser:Android
                try
                {
                    //xApiKey = (ApiKey)Newtonsoft.Json.JsonConvert.DeserializeObject(SecurityApiKey, typeof(ApiKey));
                    //ResponseRuc? oResponseRuc = JsonSerializer.Deserialize<ResponseRuc>(rpta);                    
                    ApiKey? xApiKey = JsonSerializer.Deserialize<ApiKey>(SecurityApiKey);
                    if (xApiKey.USR == "SOLERA" & xApiKey.PSW == "s0l3r@_andr01d" & xApiKey.TipUser == "Android")
                        result = true;
                }
                catch (Exception ex)
                {
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        /// <summary>
        ///     ''' Función que serializa la entidad y devuelve el XML del objeto
        ///     ''' </summary>
        ///     ''' <param name="oXML">Clase XML de Tisal</param>
        ///     ''' <returns></returns>
        private string fnSerializeXML(Response_XML.XML oXML)
        {
            using (System.IO.StringWriter stringwriter = new System.IO.StringWriter())
            {
                System.Xml.Serialization.XmlSerializer Serializer = new System.Xml.Serialization.XmlSerializer(oXML.GetType());
                Serializer.Serialize(stringwriter, oXML);
                return stringwriter.ToString();
            }
        }



        /// <summary>
        ///     ''' Devolver en una Tabla el XML enviado.
        ///     ''' </summary>
        ///     ''' <param name="oXML">Cargar el XML Document</param>
        ///     ''' <param name="NameTableNode">Nombre desde el Node de donde se quiere leer, ya que el Nodo Principal puede contener Varias tablas.</param>
        ///     ''' <param name="NameEntidadNode">Nombre de la Tabla</param>
        ///     ''' <param name="Columns">Declarar todos los nombre de las columnas que se quiere leer del XML, el nombre tiene que ser un atributo de la tabla XML</param>
        ///     ''' <returns></returns>
        public DataTable DevolverTabla_XML(XmlDocument oXML, string NameTableNode, string NameEntidadNode, params string[] Columns)
        {
            DataTable dt = new DataTable();
            int i = 0;
            for (i = 1; i <= Columns.LongCount(); i++)
                dt.Columns.Add(Columns[i - 1]);

            DataRow rows;
            XmlNodeList nodes = oXML.SelectNodes("//" + NameTableNode);
            foreach (XmlNode childrenNodes in nodes)
            {
                XmlNodeList nodes2 = childrenNodes.SelectNodes(NameEntidadNode);
                foreach (XmlNode childrennodes2 in nodes2)
                {
                    {
                        var withBlock = childrennodes2;
                        rows = dt.NewRow();    //Table();  
                        for (i = 1; i <= Columns.LongCount(); i++)
                        {
                            try
                            {
                                rows[Columns[i - 1]] = withBlock.SelectNodes(Columns[i - 1]).Item(0).InnerText;

                            }
                            catch (Exception ex)
                            {
                            }
                        }

                        dt.Rows.Add(rows); // Agregar la fila que se necesita.
                    }
                }
            }

            return dt;
        }

        /// <summary>
        ///     ''' Verificar si el médico solo acepta pago como particular o también por aseguradora
        ///     ''' </summary>
        ///     ''' <param name="pCodMedicoMedisyn">Código del medico del medisyn</param>
        ///     ''' <param name="pIdeCorrelReserva">Correlativo de la reserva</param>
        ///     ''' <returns></returns>
        private MdsynDatosPagosE GetDatosAdicionalesPagos(string pCodMedicoMedisyn, int pIdeCorrelReserva)
        {
            MedicosE oMedicosE = new MedicosE();
            List<MedicosE> oListMedicosE = new List<MedicosE>();
            MdsynDatosPagosE oMdsynDatosPagosE = new MdsynDatosPagosE();
            List<MdsynDatosPagosE> oListE = new List<MdsynDatosPagosE>();

            // Dim result As String = "S"

            // oMdsynDatosPagosE.CodTipoConsultaMedico = "S"
            // Verificar si el tipo de consulta del médico es "P", significa que atiende solo con efectivo.
            // oListMedicosE = New MedicosAD().Sp_Medicos_Consulta(New MedicosE(pCodMedicoMedisyn, 0, 0, 11))
            // If oListMedicosE.Count >= 1 Then oMedicosE = oListMedicosE(0)

            oListE = new MdsynDatosPagosAD().Sp_MdsynDatosPagos_Consulta(new MdsynDatosPagosE("", "", "", pIdeCorrelReserva, 8, "", "", "", "", pCodMedicoMedisyn));
            if (oListE.Count >= 1)
                oMdsynDatosPagosE = oListE[0];
            // If oMedicosE.CodTipoConsulta = "P" Then
            // result = "N"
            // oMdsynDatosPagosE.CodTipoConsultaMedico = "N"
            // End If

            return oMdsynDatosPagosE;
        }

        /// <summary>
        ///     ''' Validar la anulación de la cita, 
        ///     ''' </summary>
        ///     ''' <param name="pIdeCorrelReserva"></param>
        ///     ''' <returns></returns>
        private RespuestaE ValidarAnulacionCita(int pIdeCorrelReserva)
        {
            RespuestaE oRespuesta = new RespuestaE(true, "Exitoso"); // Por defecto el estado de la respuesta es true.
            MdsynDatosPagosE oMdsynDatosPagosE = new MdsynDatosPagosE("", "", "", pIdeCorrelReserva, 7);
            List<MdsynDatosPagosE> oListMdsynDatos = new MdsynDatosPagosAD().Sp_MdsynDatosPagos_Consulta(oMdsynDatosPagosE);

            try
            {
                if (oListMdsynDatos.Count >= 1)
                {
                    oMdsynDatosPagosE = oListMdsynDatos[0];
                    if (oMdsynDatosPagosE.FlgRecepcion == "S")
                        throw new Exception("No se puede anular la cita debido a que el paciente ya confirmo al Counter.");
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Respuesta = false;
                oRespuesta.Descripcion = ex.Message;
            }

            return oRespuesta;
        }

        public string DemoFechaOracle(int IdeCorrelreserva)
        {
            AmReservaE objAmReservaE = new AmReservaE(3, IdeCorrelreserva.ToString());
            string xMsg = string.Empty;
            try
            {
                MdsynDatosPagosE oMdsynDatosPagosE = new MdsynDatosPagosE();
                objAmReservaE = new AmReservaAD().ObtenerInfoReserva(objAmReservaE);

                oMdsynDatosPagosE.CodPaciente = objAmReservaE.IdAmbulatorio; // CodPaciente
                oMdsynDatosPagosE.CodProfMedico = objAmReservaE.CodProf; // CodProfMedico
                oMdsynDatosPagosE.CodEspecialidadMedisyn = objAmReservaE.CodEspecialidad.ToString(); // CodEspecialidad
                                                                                                     // FecCita.ToString("MM/dd/yyyy HH:mm")
                oMdsynDatosPagosE.FecCita = objAmReservaE.FecReserva.ToString("MM/dd/yyyy") + " " + objAmReservaE.HoraReserva.ToString("HH:mm");
            }
            catch (Exception ex)
            {
                //Interaction.MsgBox(ex.Message.ToString() + (char)13 + ex.StackTrace);
                //  MsgBox.Show(ex.Message.ToString() + (char)13 + ex.StackTrace);  //Strings.Chr(13)  MessageBox.Show

                xMsg = ex.Message.ToString() + (char)13 + ex.StackTrace;
            }

            return xMsg;
        }



        public enum TipoMetodoAgenda
        {
            WM_ObtenerAgendaXApellido = 1,
            WM_ObtenerAgendaEspecialidad = 2,
            WM_ObtenerAgendaMedico = 3
        }

        public enum TipoConsultaMedica
        {
            TeleConsulta = 12,
            PresencialCM = 14,
            PresencialJM = 15
        }

        public enum AppCitasEspecialidadesActivas
        {
            TeleConsulta = 4,
            PresencialJM = 5,
            PresencialCM = 6
        }



        /// <summary>
        ///     ''' Consulta los médicos favoritos de los pacientes.
        ///     ''' </summary>
        ///     ''' <param name="pIdAmbulatorio">Cod. del paciente o id. ambulatorio del medisyn</param>
        ///     ''' <returns></returns>
        public List<MedFavoritoE> MedicosFavoritosConsultar(string pIdAmbulatorio)
        {
            List<MedFavoritoE> oListMedicosFavoritosE = new List<MedFavoritoE>();
            MedFavoritoE objMedFavoritoE = new MedFavoritoE();
            MedFavoritoAD objMedFavoritoAD = new MedFavoritoAD();

            objMedFavoritoE.CodPaciente = pIdAmbulatorio;
            objMedFavoritoE.Orden = 1;
            oListMedicosFavoritosE = objMedFavoritoAD.Sp_MedFavorito_Consulta(objMedFavoritoE);

            return oListMedicosFavoritosE;
        }

        /// <summary>
        ///     ''' Inserta el médico favorito del paciente para listar en la App de Citas.
        ///     ''' </summary>
        ///     ''' <param name="pIdAmbulatorio">Id ambulatorio del medisyn, en clinica es el cod. paciente</param>
        ///     ''' <param name="pRutMedico">Dni del Médico</param>
        ///     ''' <returns></returns>
        public RespuestaE MedicosFavoritosInsertar(string pIdAmbulatorio, string pRutMedico)
        {
            MedFavoritoE objMedFavoritoE = new MedFavoritoE();
            MedFavoritoAD objMedFavoritoAD = new MedFavoritoAD();
            RespuestaE xResult = new RespuestaE();
            xResult.Respuesta = false;

            try
            {
                objMedFavoritoE.CodPaciente = pIdAmbulatorio;
                objMedFavoritoE.DniMedico = pRutMedico;
                xResult.Respuesta = objMedFavoritoAD.Sp_MedFavorito_Insert(objMedFavoritoE);
            }
            catch (Exception ex)
            {
                xResult.Descripcion = ex.Message;
            }

            return xResult;
        }

        /// <summary>
        ///     ''' Eliminar un médico favorito del paciente.
        ///     ''' </summary>
        ///     ''' <param name="pIdAmbulatorio">Id ambulatorio del medisyn, en clinica es el cod. paciente</param>
        ///     ''' <param name="pRutMedico">Dni del Médico</param>
        ///     ''' <returns></returns>
        public RespuestaE MedicosFavoritosDelete(string pIdAmbulatorio, string pRutMedico)
        {
            MedFavoritoE objMedFavoritoE = new MedFavoritoE();
            MedFavoritoAD objMedFavoritoAD = new MedFavoritoAD();
            RespuestaE xResult = new RespuestaE();
            xResult.Respuesta = false;

            try
            {
                objMedFavoritoE.CodPaciente = pIdAmbulatorio;
                objMedFavoritoE.DniMedico = pRutMedico;
                objMedFavoritoE.NuevoValor = "";
                objMedFavoritoE.Campo = "fec_eliminado";
                xResult.Respuesta = objMedFavoritoAD.Sp_MedFavorito_UpdatexCampo(objMedFavoritoE);
            }
            catch (Exception ex)
            {
                xResult.Descripcion = ex.Message;
            }

            return xResult;
        }

        /// <summary>
        ///     ''' Listar los médicos que no se deben agendar en la App y Web de Citas.
        ///     ''' </summary>
        ///     ''' <param name="pNombresMedico">Actualmente no esta funcionando</param>
        ///     ''' <returns></returns>
        public string MedicosVIP(string pNombresMedico)
        {
            List<MedicoDatosMedisynE> oList;
            string stringXML = "<XML><AgendaApellido>";

            oList = new MedicoDatosMedisynAD().Sp_MedicoDatosMedisyn_Consulta(pNombresMedico);

            int i = 0;
            for (i = 0; i <= oList.Count - 1; i++)
            {
                stringXML = stringXML + "<Datos>";

                stringXML = stringXML + "<COD_PROF>" + oList[i].COD_PROF + "</COD_PROF>";

                stringXML = stringXML + "</Datos>";
            }

            stringXML = stringXML + "</AgendaApellido><Mensaje><CodMensaje>0</CodMensaje><DescMensaje/></Mensaje><Error><Error_Cod>0</Error_Cod><ErrorDesc>SIN ERRORES</ErrorDesc></Error></XML>";
            return stringXML;
        }

        /// <summary>
        ///     ''' Obtener el código QR del paciente, solo devuelve las atenciones del día de la cita.
        ///     ''' </summary>
        ///     ''' <param name="pCodPaciente"></param>
        ///     ''' <returns></returns>
        public QR GetQrEstacionamiento(string pCodPaciente)
        {
            QR xQR = new QR();
            byte[] xCodQR = new byte[] { };
            RespuestaE xRespuesta = new RespuestaE();
            List<RespuestaE> xListRespuesta = new List<RespuestaE>();
            string xMsg = "";
            bool xResult = false;

            try
            {
                List<TablasE> oList = new List<TablasE>();
                string xCodAtencion = "";
                string xFechaQR = "";
                string xNombresPaciente = "";
                string xCodComprobante = "";
                string xTarifa = "";
                string xDias = "";
                string xCadenaQR = "";

                xRespuesta.Respuesta = true; // Asignamos por defecto la respuesta "true".

                // Obtener tarifa del QR.
                oList = new TablasAD().Sp_Tablas_Consulta(new TablasE("QR_TARIFA", "01", 0, 0, 8));
                xTarifa = (oList.Count >= 0 ? oList[0].Nombre : "");

                // Obtener vigencia del QR.
                oList = new TablasAD().Sp_Tablas_Consulta(new TablasE("QR_VIGENCIA", "A", 0, 0, 8));
                xDias = (oList.Count >= 0 ? oList[0].Valor.ToString() : "");

                MdsynDatosPagosE oMdsynDatosPagosE = new MdsynDatosPagosE();
                List<MdsynDatosPagosE> oListPagos = new List<MdsynDatosPagosE>();

                oMdsynDatosPagosE.Orden = 3;
                oMdsynDatosPagosE.CodPaciente = pCodPaciente;
                oListPagos = new MdsynDatosPagosAD().Sp_MdsynDatosPagos_Consulta(oMdsynDatosPagosE);

                for (int i = 0; i <= oListPagos.Count - 1; i++)
                {
                    xResult = true;
                    xCodComprobante = oListPagos[0].CodComprobante;
                    xFechaQR = oListPagos[0].FechaQR;
                    xCodAtencion = oListPagos[0].CodAtencion;
                    xNombresPaciente = oListPagos[0].NombresPacientes;

                    // Concatenar la cadena del qr
                    xCadenaQR = "P|" + xTarifa + "|" + xCodComprobante + "|" + xFechaQR + "|" + xDias + "|" + xCodAtencion + "|" + xNombresPaciente;
                    xRespuesta.Descripcion = xCadenaQR;
                    xListRespuesta.Add(xRespuesta);
                }

                if (oListPagos.Count == 0)
                    throw new Exception("El paciente no cuenta con QR para mostrar.");
            }
            catch (Exception ex)
            {
                xMsg = ex.Message.ToString();
                xRespuesta.Respuesta = false;
                xRespuesta.Descripcion = xMsg;
            }

            xQR = new QR(xResult, xMsg, xListRespuesta);

            return xQR;
        }


        /// <summary>
        ///     ''' Guardar los datos del Pago de la App de Citas (Pago).
        ///     ''' </summary>
        ///     ''' <param name="CodAsegurado">codigo del asegurado del siteds</param>
        ///     ''' <param name="TipDocumento">Tipo de documento de identidad</param>
        ///     ''' <param name="NumDocumento">Documento de identidad</param>
        ///     ''' <param name="TipPrt"></param>
        ///     ''' <param name="TipParentesco">Tipo de parentesco</param>
        ///     ''' <param name="NroPlan">Número de plan del asegurado</param>
        ///     ''' <param name="TipDocempresa">Tipo de documento de la empresa</param>
        ///     ''' <param name="NumDocempresa"></param>
        ///     ''' <param name="FecNacimiento">fecha de nacimiento del paciente</param>
        ///     ''' <param name="FecIniciovigencia"></param>
        ///     ''' <param name="FecAfilicacion">Fecha de afiliacion</param>
        ///     ''' <param name="CodCobertura">Codigo de la cobertura del paciente</param>
        ///     ''' <param name="CoPagofijo">Monto del paciente a pagar</param>
        ///     ''' <param name="CoPagovariable">% Porcentaje del paciente a pagar en algunos consumos adicionales</param>
        ///     ''' <param name="TipMoneda">Tipo de moneda en la que se realiza el pago</param>
        ///     ''' <param name="IdeCorrelreserva">Es el id. correlativo de la reserva del medisyn</param>
        ///     ''' <param name="TipAtencion">Por defecto es "A" de Ambulatorio</param>
        ///     ''' <param name="CodPaciente">Codigo del paciente de Clinica</param>
        ///     ''' <param name="CodPacienteTitular">Codigo del Paciente de Clinica (Titular)</param>
        ///     ''' <param name="CodIAFAS">Codigo de la aseguradora</param>
        ///     ''' <param name="CodSede">Cod. de la Sede 1:Camacho; 2:Jesús Maria</param>
        ///     ''' <param name="CodProfMedico">Cod. Profesional del médico (medisyn)</param>
        ///     ''' <param name="FecCita">Fecha de la cita</param>
        ///     ''' <param name="NroOperacion">Nro. de Operación o Transacción</param>
        ///     ''' <param name="DscMensajeRespuesta">Mensaje de la transacción</param>
        ///     ''' <param name="EstPagoExitoso">Estado del Pago S: Exitoso; N:Error en el pago</param>
        ///     ''' <param name="TipoTarjeta">Tipo de Tarjeta, Visa, Mastercard, etc.</param>
        ///     ''' <param name="NumeroTarjeta">Cuatro últimos digitos de la tarjeta.</param>
        ///     ''' <param name="Comp_TipoComprobante">Tipo de Comprobante B: Boleta, F: Factura.</param>
        ///     ''' <param name="Comp_TipDocIdentidad">Tipo de Documento de Identidad</param>
        ///     ''' <param name="Comp_Rut_DocIdentidad">Rut o Documento de identidad.</param>
        ///     ''' <param name="Comp_DscTabla">Tabla al cual se esta consultando la data.</param>
        ///     ''' <param name="Comp_Correo">Correo del paciente al cual se enviará el comprobante.</param>
        ///     ''' <param name="TipoEnvio">Tipo de Envio si es Web o Mobile.</param>
        ///     ''' <param name="ResponsableEnvio">Se refiere a los usuarios, WEB / UANDROID / UIOS.</param>
        ///     ''' <param name="TipoConsultaMedica">Tipo de consulta médica Particular "P" o Aseguradora "A".</param>
        ///     ''' <param name="TransactionIdNiubiz">Id de la transacción de Niubiz.</param>
        ///     ''' <param name="Version">Versión del store.</param>
        ///     ''' <returns></returns>
        public RespuestaE SetPagosApp(string CodAsegurado, string TipDocumento, string NumDocumento, string TipPrt, string TipParentesco, string NroPlan, string TipDocempresa, string NumDocempresa, DateTime FecNacimiento, DateTime FecIniciovigencia, DateTime FecAfilicacion, string CodCobertura, decimal CoPagofijo, decimal CoPagovariable, string TipMoneda, int IdeCorrelreserva, string TipAtencion, string CodPaciente, string CodPacienteTitular, string CodIAFAS, string CodSede, string CodProfMedico, DateTime FecCita, string NroOperacion, string DscMensajeRespuesta, string EstPagoExitoso, string TipoTarjeta, string NumeroTarjeta, string Comp_TipoComprobante = "B", string Comp_TipDocIdentidad = "0", string Comp_Rut_DocIdentidad = "", string Comp_DscTabla = "P", string Comp_Correo = "", string TipoEnvio = "", string ResponsableEnvio = "", string TipoConsultaMedica = "A", string TransactionIdNiubiz = "", string Version = "V2")
        {
            RespuestaE oRespuesta = new RespuestaE();
            MdsynDatosPagosE oMdsynDatosPagosE = new MdsynDatosPagosE();
            MdsynDatosPagosAD oMdsynDatosPagosAD = new MdsynDatosPagosAD();

            try
            {
                // Obtenemos datos de la reserva desde el medisyn
                AmReservaE objAmReservaE = new AmReservaE(3, IdeCorrelreserva.ToString());
                objAmReservaE = new AmReservaAD().ObtenerInfoReserva(objAmReservaE);

                oMdsynDatosPagosE.CodPaciente = objAmReservaE.IdAmbulatorio; // CodPaciente
                oMdsynDatosPagosE.CodProfMedico = objAmReservaE.CodProf; // CodProfMedico
                oMdsynDatosPagosE.CodEspecialidadMedisyn = objAmReservaE.CodEspecialidad.ToString();

                oMdsynDatosPagosE.FecCita = objAmReservaE.FecReserva.ToString("MM/dd/yyyy") + " " + objAmReservaE.HoraReserva.ToString("HH:mm");

                // Asignamos los demás valores al objeto
                oMdsynDatosPagosE.CodAsegurado = CodAsegurado;
                oMdsynDatosPagosE.TipDocumento = TipDocumento;
                oMdsynDatosPagosE.NumDocumento = NumDocumento;
                oMdsynDatosPagosE.TipPrt = TipPrt;
                oMdsynDatosPagosE.TipParentesco = TipParentesco;
                oMdsynDatosPagosE.NroPlan = NroPlan;
                oMdsynDatosPagosE.TipDocempresa = TipDocempresa;
                oMdsynDatosPagosE.NumDocempresa = NumDocempresa;
                oMdsynDatosPagosE.FecNacimiento = FecNacimiento.ToString("MM/dd/yyyy");
                oMdsynDatosPagosE.FecIniciovigencia = FecIniciovigencia.ToString("MM/dd/yyyy");
                oMdsynDatosPagosE.FecAfilicacion = FecAfilicacion.ToString("MM/dd/yyyy");
                oMdsynDatosPagosE.CodCobertura = CodCobertura.Replace(":", "");
                oMdsynDatosPagosE.CoPagofijo = CoPagofijo;
                oMdsynDatosPagosE.CoPagovariable = CoPagovariable;
                oMdsynDatosPagosE.TipMoneda = TipMoneda;

                oMdsynDatosPagosE.IdeCorrelreserva = IdeCorrelreserva;
                oMdsynDatosPagosE.TipAtencion = TipAtencion;
                oMdsynDatosPagosE.CodPacienteTitular = CodPacienteTitular;
                oMdsynDatosPagosE.CodIAFAS = CodIAFAS;

                oMdsynDatosPagosE.CodSede = CodSede;
                oMdsynDatosPagosE.NroOperacion = NroOperacion;
                oMdsynDatosPagosE.DscMensajeRespuesta = DscMensajeRespuesta;
                oMdsynDatosPagosE.EstPagoExitoso = EstPagoExitoso;

                oMdsynDatosPagosE.TipTarjeta = TipoTarjeta;
                oMdsynDatosPagosE.NumTarjeta = NumeroTarjeta;

                oMdsynDatosPagosE.Comp_TipoComprobante = Comp_TipoComprobante;
                oMdsynDatosPagosE.Comp_TipDocIdentidad = Comp_TipDocIdentidad;
                oMdsynDatosPagosE.Comp_RutDocIdentidad = Comp_Rut_DocIdentidad;
                oMdsynDatosPagosE.Comp_DscTabla = Comp_DscTabla;
                oMdsynDatosPagosE.Comp_Correo = Comp_Correo;

                oMdsynDatosPagosE.TipoEnvio = TipoEnvio; // MOBILE/WEB
                oMdsynDatosPagosE.ResponsableEnvio = ResponsableEnvio; // UIOS/ANDROID/WEB
                oMdsynDatosPagosE.CodTipoConsultaMedica = TipoConsultaMedica;
                oMdsynDatosPagosE.TransaccionIdNiubiz = TransactionIdNiubiz;

                if (TipoEnvio.Trim() == "")
                    oRespuesta.Respuesta = oMdsynDatosPagosAD.Sp_MdsynDatosPagos_Insert(oMdsynDatosPagosE);
                else if (Version == "V2")
                    oRespuesta.Respuesta = oMdsynDatosPagosAD.Sp_MdsynDatosPagos_Insert_V2(oMdsynDatosPagosE);
                else if (Version == "V3")
                    oRespuesta.Respuesta = oMdsynDatosPagosAD.Sp_MdsynDatosPagos_Insert_V3(oMdsynDatosPagosE);

                if (oRespuesta.Respuesta == true)
                    oRespuesta.Descripcion = oMdsynDatosPagosE.IdeDatospagos.ToString();

                RegistrarClienteRuc(Comp_TipoComprobante, Comp_Rut_DocIdentidad, Comp_Correo);
            }

            // Call New MdsynAmReservaAD().Sp_MdsynAmReserva_Insert(New MdsynAmReservaE(0, oMdsynDatosPagosE.IdeCorrelreserva, CodSede, CodPaciente, NumDocumento, "codmedico", CodProfMedico,
            // "Cod_Especialidad", FecCita, "USARIO_APP", "P"))
            catch (Exception ex)
            {
                // oRespuesta.Descripcion = "SetPagosApp: <br/> " + ex.Message + Chr(13) + ex.StackTrace
                oRespuesta = new RespuestaE(false, ex.Message, ex.StackTrace, false);
            }

            return oRespuesta;
        }

        public void RegistrarClienteRuc(string Comp_TipoComprobante, string Comp_Rut_DocIdentidad, string Comp_Correo)
        {
            if (Comp_TipoComprobante == "F")
            {
                List<ClientesE> oList = new List<ClientesE>();
                oList = new ClientesAD().Sp_Clientes_Consulta(new ClientesE(Comp_Rut_DocIdentidad, 0.ToString(), 0.ToString(), 4));
                if (oList.Count == 0)
                {
                    Bus.Utilities.Apis.ResponseRuc oResponseRuc = new Bus.Utilities.Apis.ResponseRuc();
                    Bus.Utilities.Apis oApis = new Bus.Utilities.Apis();
                    oResponseRuc = oApis.GetRuc(Comp_Rut_DocIdentidad);

                    RegistrarCliente(oResponseRuc.nombre_o_razon_social, "", "", "", "", "", oResponseRuc.direccion, DateTime.Now, "", "M", Comp_Correo, "PE150113", "", "TPJ", Comp_Rut_DocIdentidad, "Registrado por el Api de Sunat");
                }
            }
        }

        /// <summary>
        ///     ''' Grabar Datos del pago que envia la 
        ///     ''' </summary>
        ///     ''' <param name="IdeCorrelReserva">Id. Correlativo de la reserva.</param>
        ///     ''' <param name="authorizationCode"></param>
        ///     ''' <param name="bin"></param>
        ///     ''' <param name="shippingCountry"></param>
        ///     ''' <param name="reserved1"></param>
        ///     ''' <param name="reserved2"></param>
        ///     ''' <param name="shippingLastName"></param>
        ///     ''' <param name="errorCode"></param>
        ///     ''' <param name="idCommerce"></param>
        ///     ''' <param name="shippingCity"></param>
        ///     ''' <param name="txDateTime"></param>
        ///     ''' <param name="purchaseCurrencyCode"></param>
        ///     ''' <param name="commerceAssociated"></param>
        ///     ''' <param name="shippingFirstName"></param>
        ///     ''' <param name="purchaseOperationNumber"></param>
        ///     ''' <param name="shippingPhone"></param>
        ///     ''' <param name="shippingAddress"></param>
        ///     ''' <param name="reserved22"></param>
        ///     ''' <param name="answerMessage"></param>
        ///     ''' <param name="cuota"></param>
        ///     ''' <param name="paymentReferenceCode"></param>
        ///     ''' <param name="shippingState"></param>
        ///     ''' <param name="brand"></param>
        ///     ''' <param name="mcc"></param>
        ///     ''' <param name="shippingEmail"></param>
        ///     ''' <param name="shippingZIP"></param>
        ///     ''' <param name="acquirerId"></param>
        ///     ''' <param name="purchaseAmount"></param>
        ///     ''' <param name="purchaseVerification"></param>
        ///     ''' <param name="IDTransaction"></param>
        ///     ''' <param name="answerCode"></param>
        ///     ''' <param name="errorMessage"></param>
        ///     ''' <param name="authorizationResult"></param>
        ///     ''' <param name="reserved23"></param>
        ///     ''' <returns></returns>
        public RespuestaE SetDataServerToServer(long IdeCorrelReserva, string authorizationCode, string bin, string shippingCountry, string reserved1, string reserved2, string shippingLastName, string errorCode, string idCommerce, string shippingCity, string txDateTime, string purchaseCurrencyCode, string commerceAssociated, string shippingFirstName, string purchaseOperationNumber, string shippingPhone, string shippingAddress, string reserved22, string answerMessage, string cuota, string paymentReferenceCode, string shippingState, string brand, string mcc, string shippingEmail, string shippingZIP, string acquirerId, string purchaseAmount, string purchaseVerification, string IDTransaction, string answerCode, string errorMessage, string authorizationResult, string reserved23)
        {
            RespuestaE oRespuestaE = new RespuestaE(true, "");

            try
            {
                MdsynPagosPaymeE oMdsynPagosPaymeE = new MdsynPagosPaymeE(0, IdeCorrelReserva, authorizationCode, bin, shippingCountry, reserved1, reserved2, shippingLastName, errorCode, idCommerce, shippingCity, txDateTime, purchaseCurrencyCode, commerceAssociated, shippingFirstName, purchaseOperationNumber, shippingPhone, shippingAddress, reserved22, answerMessage, cuota, paymentReferenceCode, shippingState, brand, mcc, shippingEmail, shippingZIP, acquirerId, purchaseAmount, purchaseVerification, IDTransaction, answerCode, errorMessage, authorizationResult, reserved23);

                if (new MdsynPagosPaymeAD().Sp_MdsynPagosPayme_Insert(oMdsynPagosPaymeE) == false)
                    throw new Exception("Sp_MdsynPagosPayme_Insert: <br/>No se pudo registrar los datos, por favor vuelva a intentar más tarde.");
            }
            catch (Exception ex)
            {
                oRespuestaE.Respuesta = false;
                oRespuestaE.Descripcion = "SetDataServerToServer: <br/> " + ex.Message + (char)13 + ex.StackTrace;  //Strings.Chr(13)
            }

            return oRespuestaE;
        }

        /// <summary>
        ///     ''' Método que indica si se procedera con el pago desde la App de citas (Pagos).
        ///     ''' </summary>
        ///     ''' <param name="CodPaciente">Cod. del Paciente</param>
        ///     ''' <param name="Cod_Medico">Cod. Profesional del médico del medisyn</param>
        ///     ''' <returns></returns>
        public RespuestaE GetProcesarPago(string CodPaciente, string Cod_Medico = "")
        {
            RespuestaE oRespuesta = new RespuestaE();

            try
            {
                oRespuesta.Respuesta = true;
                oRespuesta.Descripcion = "Proceder con Pago";
            }
            catch (Exception ex)
            {
                oRespuesta.Respuesta = false;
                oRespuesta.Descripcion = ex.Message + (char)13 + ex.StackTrace;  //Strings.Chr(13)
            }
            return oRespuesta;
        }

        public RespuestaE ConfirmarAutorizacionCuestionario(int IdeCorrelReserva, string CodTipoCuestionario, string IdePaciente, string IdePacienteTitular, string IpCliente, string ApiKey, List<AutorizacionDetalle> AutorizacionDet)
        {
            RespuestaE objRespuestaE = new RespuestaE(true, "Se registraron los datos correctamente.", "", true);
            int IdeAutorizacionCab = 0;
            MdsynAutorizacionCuestionariosCabE oAutorizacionCuestCab = new MdsynAutorizacionCuestionariosCabE();
            MdsynAutorizacionCuestionariosDetE oAutorizacionCuestDetE = new MdsynAutorizacionCuestionariosDetE();
            bool xResult = false;

            oAutorizacionCuestCab = new MdsynAutorizacionCuestionariosCabE(IdeAutorizacionCab, IdeCorrelReserva, CodTipoCuestionario, IdePaciente, IdePacienteTitular, IpCliente);

            if (fnValidarApiKey(ApiKey) == true)
            {
                using (System.Transactions.TransactionScope xTrans = new System.Transactions.TransactionScope())
                {
                    try
                    {
                        new MdsynAutorizacionCuestionariosCabAD().Sp_MdsynAutorizacionCuestionariosCab_Insert(oAutorizacionCuestCab);

                        for (int i = 0; i <= AutorizacionDet.Count - 1; i++)
                        {
                            oAutorizacionCuestDetE = new MdsynAutorizacionCuestionariosDetE(0, oAutorizacionCuestCab.IdeAutorizacionCab, AutorizacionDet[i].DscTextoAutorizacion, AutorizacionDet[i].DscRespuesta, i, CodTipoCuestionario);
                            xResult = new MdsynAutorizacionCuestionariosDetAD().Sp_MdsynAutorizacionCuestionariosDet_Insert(oAutorizacionCuestDetE);

                            if (oAutorizacionCuestDetE.IdeAutorizacionDet == -1)
                            {
                                objRespuestaE = new RespuestaE(true, "Por tu seguridad y la de todos nosotros, tu cita no podrá realizarse de manera presencial. Debido a que cuentas con uno o más síntomas relacionados al COVID-19, te recomendamos dirigirte a Emergencia COVID de la Clínica para una evaluación.", "", false);
                                xResult = false;
                                break;
                            }
                            else if (oAutorizacionCuestDetE.IdeAutorizacionDet == -2)
                            {
                                objRespuestaE = new RespuestaE(true, "Por tu seguridad y la de todos nosotros, tu cita no podrá realizarse de manera presencial. Te recomendamos solicitar una Consulta Médica Virtual, para que puedas atenderte con el especialista de tu preferencia a través de una videollamada.", "", false);
                                xResult = false;
                                break;
                            }

                            if (xResult == false)
                            {
                                objRespuestaE = new RespuestaE(false, "Hubo problemas al registrar la confirmación.");
                                xTrans.Dispose();
                                break;
                            }
                        }

                        if (xResult == true)
                        {
                            xTrans.Complete();
                            if (oAutorizacionCuestCab.IdeAutorizacionCab == 0)
                                objRespuestaE = new RespuestaE(true, "Validación conforme.", "", true);
                        }
                    }
                    catch (Exception ex)
                    {
                        //objRespuestaE = new RespuestaE(false, ex.Message, "SOURCE: " + ex.Source +  Constant.vbCrLf + " | STACKTRACE: " + ex.StackTrace, false);
                        objRespuestaE = new RespuestaE(false, ex.Message, "SOURCE: " + ex.Source + " | STACKTRACE: " + ex.StackTrace, false);
                        xTrans.Dispose();
                    }
                }
            }
            else
                objRespuestaE = new RespuestaE(false, "NO TIENE ACCESO A CONSULTAR LOS DATOS", "", false);

            return objRespuestaE;
        }

        public class AutorizacionDetalle
        {
            public string DscTextoAutorizacion { get; set; } = "";
            public string DscRespuesta { get; set; } = "";

            public AutorizacionDetalle()
            {
            }

            public AutorizacionDetalle(string pDscTextoAutorizacion, string pDscRespuesta)
            {
                DscTextoAutorizacion = pDscTextoAutorizacion;
                DscRespuesta = pDscRespuesta;
            }
        }


        public RespuestaE ConfirmarAutorizacionCuestionarioV2(int IdeCorrelReserva, string CodTipoCuestionario, string IdePaciente, string IdePacienteTitular, string IpCliente, string ApiKey, List<AutorizacionDetalle> AutorizacionDet)
        {
            RespuestaE objRespuestaE = new RespuestaE(true, "Se registraron los datos correctamente.", "", true);
            int IdeAutorizacionCab = 0;
            MdsynAutorizacionCuestionariosCabE oAutorizacionCuestCab = new MdsynAutorizacionCuestionariosCabE();
            MdsynAutorizacionCuestionariosDetE oAutorizacionCuestDetE = new MdsynAutorizacionCuestionariosDetE();
            bool xResult = false;

            oAutorizacionCuestCab = new MdsynAutorizacionCuestionariosCabE(IdeAutorizacionCab, IdeCorrelReserva, CodTipoCuestionario, IdePaciente, IdePacienteTitular, IpCliente);

            if (fnValidarApiKey(ApiKey) == true)
            {
                using (System.Transactions.TransactionScope xTrans = new System.Transactions.TransactionScope())
                {
                    try
                    {
                        new MdsynAutorizacionCuestionariosCabAD().Sp_MdsynAutorizacionCuestionariosCab_Insert(oAutorizacionCuestCab);

                        for (int i = 0; i <= AutorizacionDet.Count - 1; i++)
                        {
                            oAutorizacionCuestDetE = new MdsynAutorizacionCuestionariosDetE(0, oAutorizacionCuestCab.IdeAutorizacionCab, AutorizacionDet[i].DscTextoAutorizacion, AutorizacionDet[i].DscRespuesta, i, CodTipoCuestionario);
                            xResult = new MdsynAutorizacionCuestionariosDetAD().Sp_MdsynAutorizacionCuestionariosDet_Insert(oAutorizacionCuestDetE);

                            if (oAutorizacionCuestDetE.IdeAutorizacionDet == -1)
                            {
                                objRespuestaE = new RespuestaE(true, "Por tu seguridad y la de todos nosotros, tu cita no podrá realizarse de manera presencial. Te recomendamos solicitar una Consulta Médica Virtual, para que puedas atenderte con el especialista de tu preferencia a través de una videollamada.", "", false);
                                xResult = false;
                                break;
                            }

                            if (xResult == false)
                            {
                                objRespuestaE = new RespuestaE(false, "Hubo problemas al registrar la confirmación.");
                                xTrans.Dispose();
                                break;
                            }
                        }

                        if (xResult == true)
                        {
                            xTrans.Complete();
                            if (oAutorizacionCuestCab.IdeAutorizacionCab == 0)
                                objRespuestaE = new RespuestaE(true, "Validación conforme.", "", true);
                        }
                    }
                    catch (Exception ex)
                    {
                        //objRespuestaE = new RespuestaE(false, ex.Message, "SOURCE: " + ex.Source + Constants.vbCrLf + " | STACKTRACE: " + ex.StackTrace, false);
                        objRespuestaE = new RespuestaE(false, ex.Message, "SOURCE: " + ex.Source + " | STACKTRACE: " + ex.StackTrace, false);
                        xTrans.Dispose();
                    }
                }
            }
            else
                objRespuestaE = new RespuestaE(false, "NO TIENE ACCESO A CONSULTAR LOS DATOS", "", false);

            return objRespuestaE;
        }

        public List<GetAseguradoras> fnGetAseguradoras(Ent.Sql.ClinicaE.HospitalE.AseguradorasE pAseguradorasE)
        {
            List<GetAseguradoras> oListGetAseguradoras = new List<GetAseguradoras>();
            List<Ent.Sql.ClinicaE.HospitalE.AseguradorasE> oLAseguradoras = new List<Ent.Sql.ClinicaE.HospitalE.AseguradorasE>();

            oLAseguradoras = new Dat.Sql.ClinicaAD.HospitalAD.AseguradorasAD().Sp_Aseguradoras_Consulta(pAseguradorasE);
            for (int i = 0; i <= oLAseguradoras.Count - 1; i++)
            {
                {
                    var withBlock = oLAseguradoras[i];
                    oListGetAseguradoras.Add(new GetAseguradoras(withBlock.Codaseguradora, withBlock.Nombre, withBlock.CodEpss));
                }
            }

            return oListGetAseguradoras;
        }

        public class GetAseguradoras
        {
            public string CodAseguradora { get; set; } = "";
            public string Nombre { get; set; } = "";
            public string CodIAFAS { get; set; } = "";

            public GetAseguradoras()
            {
            }

            public GetAseguradoras(string pCodAseguradora, string pNombre, string pCodIAFAS)
            {
                CodAseguradora = pCodAseguradora;
                Nombre = pNombre;
                CodIAFAS = pCodIAFAS;
            }
        }

        public string RecuperarClaveMail(int Cod_Empresa, long Rut_Paciente, string Dv_Paciente, string Email_Paciente, string ApiKey, string SistemaEnvio, string Responsable)
        {
            string responseXML = "";
            XmlDocument oXML = new XmlDocument();
            DataTable dt = new DataTable();
            Response_XML.XML oXML_Response = new Response_XML.XML();

            string Estado = "";
            string EmailPaciente = "";

            oXML_Response.RecuperaAcceso = new Response_XML.XML.RecuperaAccesoE(); // XML.RecuperaAccesoE
            oXML_Response.RecuperaAcceso.DatosAcceso.ESTADO = "N";

            if (fnValidarApiKey(ApiKey) == true)
            {
                VariablesGlobales.OpenConfigWebServices(VariablesGlobales.RutaWsAgendaCitasMedisyn);
                using (var oWsTisal = new ServicioReservaHoraWebSoapClient(VariablesGlobales.Binding, VariablesGlobales.EndPoint))
                {
                    responseXML = oWsTisal.WM_TraeDatosAccesoAsync(Cod_Empresa, Rut_Paciente, Dv_Paciente).Result;
                }
                VariablesGlobales.CloseConfigWebServices();

                oXML.LoadXml(responseXML);
                dt = DevolverTabla_XML(oXML, "RecuperaAcceso", "DatosAcceso", "ESTADO", "NOMBRE_PACIENTE", "PREGUNTA_CLAVE", "RESPUESTA_CLAVE", "CLAVE_USUARIO", "EMAIL_PACIENTE");

                // Recorremos la fila para recuperar la contraseña
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    Estado = (string)dt.Rows[i]["ESTADO"];  //.Item("ESTADO");
                    EmailPaciente = (string)dt.Rows[i]["EMAIL_PACIENTE"]; //.Item("EMAIL_PACIENTE");

                    if (EmailPaciente.ToUpper() != Email_Paciente.ToUpper())
                    {
                        string EmailEncriptado = EmailPaciente.Substring(0, 3) + "***********" + EmailPaciente.Substring(EmailPaciente.LastIndexOf("."));
                        oXML_Response.RecuperaAcceso.DatosAcceso.DESC_ESTADO = "EL CORREO ELECTRONICO INGRESADO NO COINCIDE CON EL QUE TENEMOS REGISTRADO. CORREO REGISTRADO: " + EmailEncriptado;
                        oXML_Response.RecuperaAcceso.DatosAcceso.ESTADO = "N";
                    }
                    else if (Estado == "S")
                    {
                        oXML_Response.RecuperaAcceso.DatosAcceso.ESTADO = "S";
                        oXML_Response.RecuperaAcceso.DatosAcceso.DESC_ESTADO = "SE ENVIO CONTRASEÑA A CORREO DEL PACIENTE";

                        string ClaveUsuario = (string)dt.Rows[i]["CLAVE_USUARIO"];    //dt.Rows[i].Item("CLAVE_USUARIO");
                        string MailBody = "<p>Este es el sistema de reservas de la Clínica San Felipe.</p><p>Su clave de usuario es: " + ClaveUsuario + ".</p>";

                        VariablesGlobales.OpenConfigWebServices(VariablesGlobales.RutaWsAgendaCitasMedisyn);
                        using (var oWsTisal = new ServicioReservaHoraWebSoapClient(VariablesGlobales.Binding, VariablesGlobales.EndPoint))
                        {
                            responseXML = oWsTisal.WM_EnvioMailAsync(Cod_Empresa, EmailPaciente, "", "", MailBody, "Recuperación de clave", SistemaEnvio, Responsable).Result;
                        }
                        VariablesGlobales.CloseConfigWebServices();
                    }
                    else
                    {
                        oXML_Response.RecuperaAcceso.DatosAcceso.ESTADO = "N";
                        oXML_Response.RecuperaAcceso.DatosAcceso.DESC_ESTADO = "SIN INFORMACION, PACIENTE NO TIENE REGISTRO WEB";
                    }
                }
            }
            else
            {
                oXML_Response.Mensaje = new Response_XML.XML.MensajeE(); // XML.MensajeE
                oXML_Response.RecuperaAcceso.DatosAcceso.DESC_ESTADO = "NO TIENE ACCESO A CONSULTAR LOS DATOS";
            }

            responseXML = fnSerializeXML(oXML_Response);

            return responseXML;
        }

        /// <summary>
        ///     ''' Obtener si la cita fue pagado o no.
        ///     ''' </summary>
        ///     ''' <param name="pIdeCorrelReserva">Id correlativo de la reserva</param>
        ///     ''' <returns></returns>
        public string fnCitaPagado(int pIdeCorrelReserva)
        {
            string xResult = "N";
            try
            {
                List<MdsynAmReservaE> oList = new List<MdsynAmReservaE>();
                oList = new MdsynAmReservaAD().Sp_MdsynAmReserva_Consulta(new MdsynAmReservaE(0, pIdeCorrelReserva, "", "", "", "", "", "", 10.ToString()));

                if (oList.Count != 0)
                    xResult = oList[0].EstPago;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return xResult;
        }

        /// <summary>
        ///     ''' Obtenemos los datos personales
        ///     ''' </summary>
        ///     ''' <param name="pNombres"></param>
        ///     ''' <param name="pDocIdentidad"></param>
        ///     ''' <param name="pTipDocIdentidad"></param>
        ///     ''' <param name="pApiKey"></param>
        ///     ''' <param name="pCodPacienteAud"></param>
        ///     ''' <returns></returns>
        public List<DatosPacientesE> GetDatosPersonaBoleta(string pNombres, string pDocIdentidad, string pTipDocIdentidad, string pApiKey, string pCodPacienteAud)
        {
            List<DatosPacientesE> oListDatosPacientes = new List<DatosPacientesE>();
            List<PacientesE> oList = new List<PacientesE>();
            PacientesE oPacientesE = new PacientesE();
            oPacientesE.Nombres = pNombres;
            oPacientesE.Docidentidad = pDocIdentidad;
            oPacientesE.Tipdocidentidad = pTipDocIdentidad;
            oPacientesE.Orden = 1;
            oPacientesE.CodPacienteAuditor = pCodPacienteAud;

            if (fnValidarApiKey(pApiKey) == true)
            {
                if ((pCodPacienteAud).Trim() != "")
                // if (Strings.Trim(pCodPacienteAud) != "")
                {
                    oList = new PacientesAD().Sp_BuscarPacienteTercero_Consulta(oPacientesE);
                    for (int i = 0; i <= oList.Count - 1; i++)
                    {
                        {
                            var withBlock = oList[i];
                            oListDatosPacientes.Add(new DatosPacientesE(withBlock.Codigo, withBlock.Nombres, withBlock.Docidentidad, withBlock.Direccion, withBlock.Tabla, withBlock.Nombre, withBlock.ApPaterno, withBlock.ApMaterno, withBlock.Parentesco, withBlock.Correo, withBlock.Celular));
                        }
                    }
                }
            }

            return oListDatosPacientes;
        }

        public class DatosPacientesE
        {
            public string Codigo { get; set; } = "";
            public string Nombres { get; set; } = "";
            public string DocIdentidad { get; set; } = "";
            public string Direccion { get; set; } = "";
            public string Nombre { get; set; } = "";
            public string ApPaterno { get; set; } = "";
            public string ApMaterno { get; set; } = "";
            public string Parentesco { get; set; } = "";
            public string Correo { get; set; } = "";
            public string Celular { get; set; } = "";

            public string Tabla { get; set; } = "";

            public DatosPacientesE()
            {
            }

            public DatosPacientesE(string pCodigo, string pNombres, string pDocIdentidad, string pDireccion, string pTabla)
            {
                Codigo = pCodigo;
                Nombres = pNombres;
                DocIdentidad = pDocIdentidad;
                Direccion = pDireccion;
                Tabla = pTabla;
            }

            public DatosPacientesE(string pCodigo, string pNombres, string pDocIdentidad, string pDireccion, string pTabla, string pNombre, string pApPaterno, string pApMaterno, string pParentesco, string pCorreo, string pCelular)
            {
                Codigo = pCodigo;
                Nombres = pNombres;
                DocIdentidad = pDocIdentidad;
                Direccion = pDireccion;
                Tabla = pTabla;
                Nombre = pNombre;
                ApPaterno = pApPaterno;
                ApMaterno = pApMaterno;
                Parentesco = pParentesco;
                Correo = pCorreo;
                Celular = pCelular;
            }
        }

        public RespuestaE RegistrarCliente(string PrimerNombre, string SegundoNombre, string ApPaterno, string ApMaterno, string DocIdentidad, string TipDocIdentidad, string Direccion, DateTime FechaNacimiento, string Telefono, string Sexo, string Correo, string CodUbigeo, string ApiKey, string CodTipoPersona = "TPN", string Ruc = "", string Observaciones = "", string CodCivil = "")
        {
            RespuestaE oRespuestaE = new RespuestaE(false, "");
            string CodCliente = "";
            ClientesE oClientesE = new ClientesE(CodCliente, "", PrimerNombre, SegundoNombre, ApPaterno, ApMaterno, DocIdentidad, TipDocIdentidad, Direccion, Telefono, Sexo, Correo, CodUbigeo, FechaNacimiento, Ruc, CodTipoPersona, Observaciones, CodCivil);

            try
            {
                if (fnValidarApiKey(ApiKey) == true | CodTipoPersona == "TPJ")
                {
                    oRespuestaE.Respuesta = new ClientesAD().Sp_Clientes_Insert_App(oClientesE);
                    if ((oRespuestaE.Respuesta == true))
                        oRespuestaE.Descripcion = "Se insertaron los datos correctamente.";
                    else
                        oRespuestaE.Descripcion = "Hubo un problema al registrar los datos del cliente.";
                }
                else
                    oRespuestaE = new RespuestaE(false, "No tiene acceso para registrar la info.");
            }
            catch (Exception ex)
            {
                // oRespuestaE = new RespuestaE(false, ex.Message, "SOURCE: " + ex.Source + Constants.vbCrLf + " | STACKTRACE: " + ex.StackTrace);
                oRespuestaE = new RespuestaE(false, ex.Message, "SOURCE: " + ex.Source + " | STACKTRACE: " + ex.StackTrace);
            }

            return oRespuestaE;
        }

        public TarifaParticular ObtenerTarifa(string CodProf)
        {
            TarifaParticular objTarifaParticular = null;
            List<MedicosE> oList = new MedicosAD().Sp_Medicos_Consulta(new MedicosE(CodProf, 0, 0, 11));
            if (oList.Count >= 1)
            {
                objTarifaParticular = new TarifaParticular();
                objTarifaParticular.CodProf = oList[0].CodProfMedisyn;
                objTarifaParticular.Descripcion = oList[0].DscTituloTarifa;
                objTarifaParticular.MontoTarifa = oList[0].MntTarifaParticular;
                objTarifaParticular.Moneda = oList[0].TipMoneda;
                objTarifaParticular.TipoConsultaMedica = oList[0].TipoConsultaMedica;
            }

            return objTarifaParticular;
        }

        public class TarifaParticular
        {
            public string CodProf { get; set; } = "";
            public string Descripcion { get; set; } = "";
            public string MontoTarifa { get; set; } = "";
            public string Moneda { get; set; } = "";
            public string TipoConsultaMedica { get; set; } = "";
            public string DscSubEspecialidad { get; set; } = "";
        }

        public string Insert_HIS_ADT(int COD_EMPRESA, string COD_SUCURSAL, string EVENT_ID, string EVENT_DATETIME, string EVENT_TYPE_ID, string ID_PACIENTE, string RUT_PACIENTE, string TIPO_PACIENTE, string DEATH_INDICATOR, string CAT_NAME, string LAST_NAME, string FIRST_NAME, string BIRTH_DATE, string GENDER_KEY, string LAST_UPDATED, string STREET_ADDRESS, string CITY, string COUNTRY, string PHONE_NUMBER, string PRIMARY, string PATIENT_CLASS_KEY)
        {
            return new Dat.Oracle.MedisynAD.HisADTAD.HisADTAD().Insert_HIS_ADT(COD_EMPRESA, COD_SUCURSAL, EVENT_ID, EVENT_DATETIME, EVENT_TYPE_ID, ID_PACIENTE, RUT_PACIENTE, TIPO_PACIENTE, DEATH_INDICATOR, CAT_NAME, LAST_NAME, FIRST_NAME, BIRTH_DATE, GENDER_KEY, LAST_UPDATED, STREET_ADDRESS, CITY, COUNTRY, PHONE_NUMBER, PRIMARY, PATIENT_CLASS_KEY);
        }

        public List<Ent.Oracle.MedisynE.PacientesE.TabPacienteE> ObtenerGrupoFamiliarPackAge(string IdPaciente)
        {
            return new Dat.Oracle.MedisynAD.PacientesAD.TabPacientesAD().ObtenerGrupoFamiliarPackAge(IdPaciente);
        }

        public class Departamentos
        {
            public string CodDpto { get; set; } = "";
            public string Descripcion { get; set; } = "";
            public Departamentos()
            {
            }

            public Departamentos(string pCodDpto, string pDescrpicion)
            {
                CodDpto = pCodDpto;
                Descripcion = pDescrpicion;
            }
        }
        //public List<Departamentos> ObtenerDepatamentos(int CodEmpresa)
        public List<Departamentos> ObtenerDepatamentos(String CodEmpresa)
        {
            List<Departamentos> oList = new List<Departamentos>();
            DataSet ds = new Dat.Oracle.MedisynAD.PacientesAD.TabPacientesAD().ObtenerDepatamentos(CodEmpresa);

            if (ds.Tables.Count >= 1)
            {
                for (var i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    {
                        var withBlock = ds.Tables[0].Rows[i];
                        //oList.Add(new Departamentos(withBlock.Item("CodDepto"), withBlock.Item("DescDepto")));
                        oList.Add(new Departamentos((string)withBlock["CodDepto"], (string)withBlock["DescDepto"]));
                    }
                }
            }

            return oList;
        }

        //public void VerificarCitaPacienteMedicoDia(string Fecha_Reserva, long Corr_Horario, long Id_Paciente)
        public bool VerificarCitaPacienteMedicoDia(string Fecha_Reserva, long Corr_Horario, long Id_Paciente)
        {
            AmReservaE obj = new AmReservaE();
            obj.FecReserva_String = Fecha_Reserva;
            obj.CorrelHorario = (int)Corr_Horario;
            obj.IdAmbulatorio = Id_Paciente.ToString();
            //return new AmReservaAD().VerificarCitaPacienteMedicoDia(obj);
            return new AmReservaAD().VerificarCitaPacienteMedicoDia(obj);
        }


        public List<AgendaDatos> ObtieneAgendaXApellido(int Cod_Empresa, int Cod_Sucursal, string ApelPat_prof)
        {
            try
            {
                return new AmReservaAD().ObtieneAgendaXApellido(Cod_Empresa, Cod_Sucursal, ApelPat_prof);
            }
            catch (Exception ex)
            {
                throw new Exception("cls: AmReservaAD - mtd: ObtieneAgendaXApellido: " + ex.Message);
            }
        }



        /// <summary>
        ///     ''' Invocamos al Método "WM_ObtieneReservasPaciente" de Tisal y agregamos el dni del paciente, este método se creo 
        ///     ''' con la intencion de manipular el resultado del método y agregar información adicional.
        ///     ''' </summary>
        ///     ''' <param name="pCodEmpresa">Codigo de Empresa de Tisal, por defecto es "16"</param>
        ///     ''' <param name="pIdAmbulatorio">Es el Cod. del Paciente de Clinica o Id. Ambulatorio del Medisyn</param>
        ///     ''' <param name="pIdGrupoFamiliar">Número del Grupo Familiar</param>
        ///     ''' <param name="pVervisitas">Indicar si se mostrara las visitas</param>
        ///     ''' <returns></returns>
        public string WM_ObtieneReservasPaciente(string pCodEmpresa, string pIdAmbulatorio, string pIdGrupoFamiliar, string pVervisitas)
        {
            XmlDocument oXML = new XmlDocument();
            string stringXml = "";
            string responseXml = "";
            string stringReserva = "";
            int j;
            int k;

            List<MdsynDatosPagosE> oListDatosE = new List<MdsynDatosPagosE>();
            MdsynDatosPagosE oMdsynDatosPagosE = new MdsynDatosPagosE();

            try
            {
                VariablesGlobales.OpenConfigWebServices(VariablesGlobales.RutaWsAgendaCitasMedisyn);
                using (ServicioReservaHoraWebSoapClient oWsTisal = new ServicioReservaHoraWebSoapClient(VariablesGlobales.Binding, VariablesGlobales.EndPoint))
                {
                    responseXml = oWsTisal.WM_ObtieneReservasPacienteAsync(Convert.ToInt32(pCodEmpresa), Convert.ToInt64(pIdAmbulatorio), Convert.ToInt64(pIdGrupoFamiliar), pVervisitas).Result;
                }
                VariablesGlobales.CloseConfigWebServices();

                oXML.LoadXml(responseXml);
                // Se puso en un controlador de error en caso el web services muestre error, indique el mensaje que devuelve el método de tisal.
                try
                {
                    // Indicamos el Xml e indicamos los campos que deseamos obtener como columna en una tabla
                    DataTable dt = DevolverTabla_XML(oXML, "ReservasPaciente", "Datos", "ESTADO", "FECHA_RESERVA", "HORA_RESERVA", "NOMBRE_PROFESIONAL", "ESPEC", "SUCURSAL", "CORREL_RESERVA", "NOMBRE_PACIENTE", "COD_UNIDAD", "COD_PROF", "CORREL_AGENDA", "COD_ESPECIALIDAD");
                    // Recorremos cada fila
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        stringXml = stringXml + "<Datos>";
                        stringXml = stringXml + fnStringBodyXML(dt.Rows[i], dt.Columns); // Obtenemos el cuerpo del XML que se obtuvo inicialmente

                        AmReservaE objAmReservaE = new AmReservaE(3, (string)dt.Rows[i]["CORREL_RESERVA"]); // Creamos el objeto AmReservaE para obtener algunos datos de la reserva
                        objAmReservaE = new AmReservaAD().ObtenerInfoReserva(objAmReservaE);
                        stringXml = stringXml + "<ID_AMBULATORIO>" + objAmReservaE.IdAmbulatorio + "</ID_AMBULATORIO>";
                        stringXml = stringXml + "<DNI_PACIENTE>" + objAmReservaE.RutPaciente + "</DNI_PACIENTE>";
                        stringXml = stringXml + "<SEDE_FISICA>" + objAmReservaE.CodSucursal.ToString() + "</SEDE_FISICA>";

                        oMdsynDatosPagosE = GetDatosAdicionalesPagos((string)dt.Rows[i]["COD_PROF"], (int)dt.Rows[i]["CORREL_RESERVA"]);
                        stringXml = stringXml + "<PAGAR_CONSULTA_MEDICO>" + oMdsynDatosPagosE.PuedePagarCita + "</PAGAR_CONSULTA_MEDICO>";
                        stringXml = stringXml + "<TIPO_CONSULTA_MEDICO>" + oMdsynDatosPagosE.CodTipoConsultaMedica + "</TIPO_CONSULTA_MEDICO>";
                        stringXml = stringXml + "<PAY>" + oMdsynDatosPagosE.EstPagoExitoso + "</PAY>";
                        stringXml = stringXml + "<TIPO_ATENCION>" + oMdsynDatosPagosE.TipoAtencion + "</TIPO_ATENCION>";

                        // stringXml = stringXml + "<DSC_SEDE>" + objAmReservaE.DscSucursal.ToString + "</DSC_SEDE>"
                        stringXml = stringXml + "<DSC_SEDE>" + (oMdsynDatosPagosE.DscSede != "" ? oMdsynDatosPagosE.DscSede : objAmReservaE.DscSucursal) + "</DSC_SEDE>";
                        stringXml = stringXml + "<REPROGRAMAR>" + oMdsynDatosPagosE.Reprogramar + "</REPROGRAMAR>";
                        stringXml = stringXml + "<DSC_REPROGRAMAR>" + oMdsynDatosPagosE.DscReprogramar + "</DSC_REPROGRAMAR>";

                        stringXml = stringXml + "<DSC_ESPECIALIDAD_ALTERNO>" + fnGetSubEspecialidadDatos((string)dt.Rows[i]["COD_PROF"]) + "</DSC_ESPECIALIDAD_ALTERNO>";

                        stringXml = stringXml + "</Datos>";
                    }

                    j = responseXml.IndexOf("<ReservasPaciente>") + ("<ReservasPaciente>").Length;
                    k = responseXml.LastIndexOf("</ReservasPaciente>");

                    stringXml = responseXml.Substring(0, j) + stringXml + responseXml.Substring(k);
                }
                catch (Exception ex)
                {
                    stringXml = responseXml;
                }

                oXML = null;
            }
            catch (Exception ex)
            {
                stringXml = ex.Message + '\r' + ex.StackTrace;
            }

            return stringXml;
        }

        /// <summary>
        ///     ''' Invocamos al Método "WM_ReservaHora" de Tisal y agregamos el dni del paciente, este método se creo 
        ///     ''' con la intencion de manipular el resultado del método y agregar información adicional.
        ///     ''' </summary>
        ///     ''' <param name="Cod_Empresa">Codigo de Empresa de Tisal, por defecto es "16"</param>
        ///     ''' <param name="Cod_Sucursal">Codigo de Sucursal</param>
        ///     ''' <param name="Cod_CentroMedico"></param>
        ///     ''' <param name="Cod_Especialidad"></param>
        ///     ''' <param name="Cod_Unidad"></param>
        ///     ''' <param name="Cod_Medico"></param>
        ///     ''' <param name="Corr_Agenda"></param>
        ///     ''' <param name="Cod_Isapre"></param>
        ///     ''' <param name="Box"></param>
        ///     ''' <param name="Multi"></param>
        ///     ''' <param name="Id_Paciente_Titular">Id. del paciente titular</param>
        ///     ''' <param name="Id_Paciente"></param>
        ///     ''' <param name="Corr_Horario"></param>
        ///     ''' <param name="Fecha_Reserva"></param>
        ///     ''' <param name="Hora_Reserva"></param>
        ///     ''' <param name="Mod_Reserva"></param>
        ///     ''' <param name="Prox_HoraLibre"></param>
        ///     ''' <param name="IP_Cliente">Ip del cliente</param>
        ///     ''' <param name="Usuario">Usuario, UINTERNET, UANDROID, UIOS, etc.</param>
        ///     ''' <param name="Url_VideoLlamada">Url para la videollamada para el HCE</param>
        ///     ''' <param name="TeleMedicina">Flag para saber si la reserva es por Telemedicina o Presencial</param>
        ///     ''' <returns></returns>
        public string WM_ReservaHora(int Cod_Empresa, int Cod_Sucursal, int Cod_CentroMedico, int Cod_Especialidad, int Cod_Unidad, int Cod_Medico, int Corr_Agenda, int Cod_Isapre, long Box, bool Multi, long Id_Paciente_Titular, long Id_Paciente, long Corr_Horario, string Fecha_Reserva, string Hora_Reserva, string Mod_Reserva, string Prox_HoraLibre, string IP_Cliente, string Usuario, string Url_VideoLlamada, string TeleMedicina)
        {
            XmlDocument oXML = new XmlDocument();
            string stringXML = "";
            string responseXML = "";
            int j;
            int k;

            List<MdsynDatosPagosE> oListDatosE = new List<MdsynDatosPagosE>();

            if (TeleMedicina == "N")
            {
                if (VariablesGlobales.HorarioRestringidoPresencial != "")
                {
                    if (Convert.ToDateTime(Hora_Reserva) >= Convert.ToDateTime(VariablesGlobales.HorarioRestringidoPresencial))
                    {
                        stringXML = fnReservaHoraError(VariablesGlobales.MsjRestringidoPresencial);
                        return stringXML;
                    }
                }
            }
            else if (TeleMedicina == "S")
            {
                if (VariablesGlobales.HorarioRestringidoVirtual != "")
                {
                    if (Convert.ToDateTime(Hora_Reserva) >= Convert.ToDateTime(VariablesGlobales.HorarioRestringidoVirtual))
                    {
                        stringXML = fnReservaHoraError(VariablesGlobales.MsjRestringidoVirtual);
                        return stringXML;
                    }
                }
            }

            AmReservaE obj = new AmReservaE();
            obj.FecReserva_String = Fecha_Reserva;
            obj.CorrelHorario = (int)Corr_Horario;
            obj.IdAmbulatorio = Convert.ToString(Id_Paciente);
            if (new AmReservaAD().VerificarCitaPacienteMedicoDia(obj) == true)
            {
                stringXML = fnReservaHoraError("No se puede agendar una cita con el mismo médico el mismo día, por favor elija otro día.");
                return stringXML;
            }

            try
            {
                VariablesGlobales.OpenConfigWebServices(VariablesGlobales.RutaWsAgendaCitasMedisyn);
                using (var oWsTisal = new ServicioReservaHoraWebSoapClient(VariablesGlobales.Binding, VariablesGlobales.EndPoint))
                {
                    responseXML = oWsTisal.WM_ReservaHoraAsync(Cod_Empresa, Cod_Sucursal, Cod_CentroMedico, Cod_Especialidad, Cod_Unidad, Cod_Medico, Corr_Agenda, Cod_Isapre, Box, Multi, Id_Paciente_Titular, Id_Paciente, Corr_Horario, Fecha_Reserva, Hora_Reserva, Mod_Reserva, Prox_HoraLibre, IP_Cliente, Usuario).Result;
                    oXML.LoadXml(responseXML);
                    try
                    {
                        MdsynDatosPagosE oMdsynDatosPagosE = new MdsynDatosPagosE();
                        DataTable dtReservaHora = DevolverTabla_XML(oXML, "ReservaHora", "Datos_Reserva", "CORRELATIVO_RESERVA", "NOMBRE_PROFESIONAL", "FECHA_RESERVA", "HORA_RESERVA", "NOMBRE_PACIENTE", "EMAIL_PACIENTE", "ESPECIALIDAD", "SUCURSAL", "ISAPRE", "INDIMED", "MONTO_PAGAR", "COD_PRESTACION");
                        for (int i = 0; i <= dtReservaHora.Rows.Count - 1; i++)
                        {
                            System.Globalization.CultureInfo ciFechaCita = new System.Globalization.CultureInfo("es-Es");
                            DateTime FechaCita = DateTime.Parse(Fecha_Reserva + " " + Hora_Reserva, ciFechaCita);

                            stringXML = stringXML + "<Datos_Reserva>";
                            stringXML = stringXML + fnStringBodyXML(dtReservaHora.Rows[i], dtReservaHora.Columns);

                            AmReservaE objAmReservaE = new AmReservaE(3, (string)dtReservaHora.Rows[i]["CORRELATIVO_RESERVA"]);
                            objAmReservaE = new AmReservaAD().ObtenerInfoReserva(objAmReservaE);
                            stringXML = stringXML + "<DNI_PACIENTE>" + objAmReservaE.RutPaciente + "</DNI_PACIENTE>";

                            oMdsynDatosPagosE = GetDatosAdicionalesPagos(Convert.ToString(Cod_Medico), Convert.ToInt32(dtReservaHora.Rows[i]["CORRELATIVO_RESERVA"]));
                            oMdsynDatosPagosE.IdeCorrelreserva = Convert.ToInt32(dtReservaHora.Rows[i]["CORRELATIVO_RESERVA"]);

                            using (System.Transactions.TransactionScope xTrans = new System.Transactions.TransactionScope())
                            {
                                try
                                {
                                    new MdsynVideoLlamadaAD().Sp_MdsynVideoLlamada_Insert(new MdsynVideoLlamadaE(0, oMdsynDatosPagosE.IdeCorrelreserva, TeleMedicina, Url_VideoLlamada));
                                    new MdsynAmReservaAD().Sp_MdsynAmReserva_Insert(new MdsynAmReservaE(0, oMdsynDatosPagosE.IdeCorrelreserva, Cod_Sucursal.ToString(), Id_Paciente.ToString(), objAmReservaE.RutPaciente, oMdsynDatosPagosE.CodMedico, Cod_Medico.ToString(), Cod_Especialidad.ToString(), FechaCita, Usuario, (TeleMedicina == "S" ? "V" : "P")));

                                    oMdsynDatosPagosE = new MdsynDatosPagosE();
                                    oMdsynDatosPagosE = GetDatosAdicionalesPagos(Cod_Medico.ToString(), (int)dtReservaHora.Rows[i]["CORRELATIVO_RESERVA"]);
                                    oMdsynDatosPagosE.IdeCorrelreserva = (int)dtReservaHora.Rows[i]["CORRELATIVO_RESERVA"];
                                    stringXML = stringXML + "<PAGAR_CONSULTA_MEDICO>" + oMdsynDatosPagosE.PuedePagarCita + "</PAGAR_CONSULTA_MEDICO>";
                                    stringXML = stringXML + "<TIPO_CONSULTA_MEDICO>" + oMdsynDatosPagosE.CodTipoConsultaMedica + "</TIPO_CONSULTA_MEDICO>";

                                    stringXML = stringXML + "<PAY>" + oMdsynDatosPagosE.EstPagoExitoso + "</PAY>";

                                    stringXML = stringXML + "</Datos_Reserva>";

                                    j = responseXML.IndexOf("<ReservaHora>") + ("<ReservaHora>").Length;
                                    k = responseXML.LastIndexOf("</ReservaHora>");

                                    stringXML = responseXML.Substring(0, j) + stringXML + responseXML.Substring(k);

                                    xTrans.Complete();
                                }
                                catch (Exception ex)
                                {
                                    oWsTisal.WM_AnulacionHorasAsync(Cod_Empresa, Cod_Sucursal, Cod_Unidad, Cod_Medico, Corr_Agenda, Cod_Especialidad, Fecha_Reserva, Hora_Reserva, oMdsynDatosPagosE.IdeCorrelreserva, Id_Paciente_Titular, IP_Cliente, Usuario);
                                    stringXML = fnReservaHoraError();

                                    xTrans.Dispose();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        stringXML = responseXML;
                    }
                }
                VariablesGlobales.CloseConfigWebServices();

                oXML = null;
            }
            catch (Exception ex)
            {
                stringXML = ex.Message + '\r' + ex.StackTrace;
            }

            return stringXML;
        }



        /// <summary>
        ///     ''' Servicio que permite anular, adicional a nuestro caso antes de anular se realiza validaciones
        ///     ''' para indicar si se puede anular.
        ///     ''' </summary>
        ///     ''' <param name="Cod_Empresa">Cod. de la empresa = 16</param>
        ///     ''' <param name="Cod_Sucursal">Cod. de la Sucursal</param>
        ///     ''' <param name="Cod_Unidad">Cod. de la Unidad de la sucursal</param>
        ///     ''' <param name="Cod_Profesional">Cod. Profesional del médico del medisyn</param>
        ///     ''' <param name="Corr_Agenda">Correlativo de la agenda del médico</param>
        ///     ''' <param name="Cod_Especialidad">Cod. de la especialidad</param>
        ///     ''' <param name="Fecha_Reserva">Fecha de la reserva</param>
        ///     ''' <param name="Hora_Reserva">Hora de la reserva</param>
        ///     ''' <param name="mvarIDReserva">Id. de la reserva del paciente</param>
        ///     ''' <param name="Id_PacienteTitular">Id. del paciente titular</param>
        ///     ''' <param name="IP_Cliente">Ip del cliente</param>
        ///     ''' <param name="Usuario">Usuario, UINTERNET, UANDROID, UIOS, etc.</param>
        ///     ''' <returns></returns>
        public string WM_AnulacionHoras(int Cod_Empresa, int Cod_Sucursal, int Cod_Unidad, int Cod_Profesional, int Corr_Agenda, int Cod_Especialidad, string Fecha_Reserva, string Hora_Reserva, int mvarIDReserva, int Id_PacienteTitular, string IP_Cliente, string Usuario)
        {
            string stringXML = "";

            try
            {
                RespuestaE oRespuesta = ValidarAnulacionCita(mvarIDReserva);

                // En caso devuelva el mensaje "false", este indica que no se puede anular.
                if (oRespuesta.Respuesta == false)
                    throw new Exception(oRespuesta.Descripcion);
                else
                {
                    VariablesGlobales.OpenConfigWebServices(VariablesGlobales.RutaWsAgendaCitasMedisyn);

                    using (var oWsTisal = new ServicioReservaHoraWebSoapClient(VariablesGlobales.Binding, VariablesGlobales.EndPoint))
                    {
                        //stringXML = oWsTisal.WM_AnulacionHoras(Cod_Empresa, Cod_Sucursal, Cod_Unidad, Cod_Profesional, Corr_Agenda, Cod_Especialidad, Fecha_Reserva, Hora_Reserva, mvarIDReserva, Id_PacienteTitular, IP_Cliente, Usuario);
                        stringXML = Convert.ToString(oWsTisal.WM_AnulacionHorasAsync(Cod_Empresa, Cod_Sucursal, Cod_Unidad, Cod_Profesional,
                                                                    Corr_Agenda, Cod_Especialidad, Fecha_Reserva, Hora_Reserva,
                                                                    mvarIDReserva, Id_PacienteTitular, IP_Cliente, Usuario).ToString());

                        MdsynDatosPagosE oMdsynDatosPagosE = new MdsynDatosPagosE(0, "S", "flg_anulacion_correlativo")
                        {
                            IdeDatospagos = System.Convert.ToInt32(mvarIDReserva) // Se coloca el Id. de Pagos o Id. del Correlativo, debido
                        };

                        new MdsynDatosPagosAD().Sp_MdsynDatosPagos_UpdatexCampo(oMdsynDatosPagosE);
                        new MdsynAmReservaAD().Sp_MdsynAmReserva_Update(new MdsynAmReservaE(0, mvarIDReserva, "", "", "", "", "", "", DateTime.Now, "", 0, "", "update_reserva_anulada", 4, "S"));
                    }

                    VariablesGlobales.CloseConfigWebServices();
                }
            }
            catch (Exception ex)
            {
                stringXML = stringXML_AnulacionHoras(ex.Message);
            }

            return stringXML;
        }

        /// <summary>
        ///     ''' Sirve para comunicarse con el servicio del Medisyn para obtener los médicos. 
        ///     ''' En caso que sea sede "3" se invoca los médicos de la sede "1", "2" y se realiza un filtro.
        ///     ''' </summary>
        ///     ''' <param name="Cod_Empresa">Cod. Empresa</param>
        ///     ''' <param name="Cod_Sucursal">Cod. Sucursal</param>
        ///     ''' <param name="ApelPat_prof">Filtrar por apellido del médico</param>
        ///     ''' <returns></returns>
        public string WM_ObtenerAgendaXApellido(int Cod_Empresa, int Cod_Sucursal, string ApelPat_prof)
        {
            string stringXML = "";
            string responseXML = "";
            int j = 0;
            int k = 0;
            bool xResult = false;

            try
            {
                string NodoLista = "AgendaApellido";

                VariablesGlobales.OpenConfigWebServices(VariablesGlobales.RutaWsAgendaCitasMedisyn); // Abrimos conexión

                if (Cod_Sucursal == 3)
                {
                    using (var oWsTisal = new ServicioReservaHoraWebSoapClient(VariablesGlobales.Binding, VariablesGlobales.EndPoint))
                    {
                        responseXML = oWsTisal.WM_ObtenerAgendaXApellidoAsync(Cod_Empresa, 1, ApelPat_prof).Result;  // Sede 1: Camacho
                        stringXML = stringXML + fnAgendaApellidoEspecialidad(responseXML, NodoLista, ApelPat_prof, TipoMetodoAgenda.WM_ObtenerAgendaXApellido, TipoConsultaMedica.TeleConsulta);
                        if (stringXML != "")
                            xResult = true;

                        responseXML = oWsTisal.WM_ObtenerAgendaXApellidoAsync(Cod_Empresa, 2, ApelPat_prof).Result; // Sede 2: Jesús Maria
                        stringXML = stringXML + fnAgendaApellidoEspecialidad(responseXML, NodoLista, ApelPat_prof, TipoMetodoAgenda.WM_ObtenerAgendaXApellido, TipoConsultaMedica.TeleConsulta);
                        if (stringXML != "")
                            xResult = true;

                        j = responseXML.IndexOf("<" + NodoLista + ">") + ("<" + NodoLista + ">").Length; // Inicio, para indicar lo que no ira.
                        k = responseXML.LastIndexOf("</" + NodoLista + ">"); // Final, para indicar lo que no ira.

                        if (xResult == true)
                            stringXML = responseXML.Substring(0, j) + stringXML + responseXML.Substring(k);
                        else
                            stringXML = stringXML_ErrorAgendaApellidoEspecialidad();
                    }
                }
                else
                    using (var oWsTisal = new ServicioReservaHoraWebSoapClient(VariablesGlobales.Binding, VariablesGlobales.EndPoint))
                    {
                        responseXML = oWsTisal.WM_ObtenerAgendaXApellidoAsync(Cod_Empresa, Cod_Sucursal, ApelPat_prof).Result;

                        if (Cod_Sucursal == 1)
                            stringXML = stringXML + fnAgendaApellidoEspecialidad(responseXML, NodoLista, ApelPat_prof, TipoMetodoAgenda.WM_ObtenerAgendaXApellido, TipoConsultaMedica.PresencialCM);
                        else if (Cod_Sucursal == 2)
                            stringXML = stringXML + fnAgendaApellidoEspecialidad(responseXML, NodoLista, ApelPat_prof, TipoMetodoAgenda.WM_ObtenerAgendaXApellido, TipoConsultaMedica.PresencialJM);

                        if (stringXML == "")
                            stringXML = responseXML;
                        else
                        {
                            j = responseXML.IndexOf("<" + NodoLista + ">") + ("<" + NodoLista + ">").Length; // Inicio, para indicar lo que no ira.
                            k = responseXML.LastIndexOf("</" + NodoLista + ">"); // Final, para indicar lo que no ira.

                            stringXML = responseXML.Substring(0, j) + stringXML + responseXML.Substring(k);
                        }
                    }

                VariablesGlobales.CloseConfigWebServices(); // Cerramos la conexión
            }
            catch (Exception ex)
            {
                stringXML = ex.Message + (char)13 + ex.StackTrace;
            }

            return stringXML;
        }

        /// <summary>
        ///     ''' Sirve para comunicarse con el servicio del Medisyn para obtener los médicos. 
        ///     ''' En caso que sea sede "3" se invoca los médicos de la sede "1", "2" y se realiza un filtro.
        ///     ''' </summary>
        ///     ''' <param name="Cod_Empresa">Cod. Empresa</param>
        ///     ''' <param name="Cod_Sucursal">Cod. Sucursal</param>
        ///     ''' <param name="Cod_Especialidad">Filtrar por Cod. Especialidad</param>
        ///     ''' <returns></returns>
        public string WM_ObtenerAgendaEspecialidad(int Cod_Empresa, int Cod_Sucursal, int Cod_Especialidad)
        {
            XmlDocument oXML = new XmlDocument();
            string stringXML = "";
            string responseXML = "";
            bool xResult = false; // Por defecto mostrará el mensaje de error al paciente

            try
            {
                string NodoLista = "AgendaEspecialidad";

                VariablesGlobales.OpenConfigWebServices(VariablesGlobales.RutaWsAgendaCitasMedisyn); // Abrimos conexión

                if (Cod_Sucursal == 3)
                {
                    using (var oWsTisal = new ServicioReservaHoraWebSoapClient(VariablesGlobales.Binding, VariablesGlobales.EndPoint))
                    {
                        responseXML = oWsTisal.WM_ObtenerAgendaEspecialidadAsync(Cod_Empresa, 1, Cod_Especialidad).Result; // Sede CM
                        stringXML = stringXML + fnAgendaApellidoEspecialidad(responseXML, NodoLista, "", TipoMetodoAgenda.WM_ObtenerAgendaEspecialidad, TipoConsultaMedica.TeleConsulta);
                        if (stringXML != "")
                            xResult = true;

                        responseXML = oWsTisal.WM_ObtenerAgendaEspecialidadAsync(Cod_Empresa, 2, Cod_Especialidad).Result; // Sede 2: Jesús Maria
                        stringXML = stringXML + fnAgendaApellidoEspecialidad(responseXML, NodoLista, "", TipoMetodoAgenda.WM_ObtenerAgendaEspecialidad, TipoConsultaMedica.TeleConsulta);
                        if (stringXML != "")
                            xResult = true;
                    }
                }
                else
                    using (var oWsTisal = new ServicioReservaHoraWebSoapClient(VariablesGlobales.Binding, VariablesGlobales.EndPoint))
                    {
                        responseXML = oWsTisal.WM_ObtenerAgendaEspecialidadAsync(Cod_Empresa, Cod_Sucursal, Cod_Especialidad).Result;

                        if (Cod_Sucursal == 1)
                            stringXML = stringXML + fnAgendaApellidoEspecialidad(responseXML, NodoLista, "", TipoMetodoAgenda.WM_ObtenerAgendaEspecialidad, TipoConsultaMedica.PresencialCM);
                        else if (Cod_Sucursal == 2)
                            stringXML = stringXML + fnAgendaApellidoEspecialidad(responseXML, NodoLista, "", TipoMetodoAgenda.WM_ObtenerAgendaEspecialidad, TipoConsultaMedica.PresencialJM);
                    }

                if (stringXML != "")
                    stringXML = "<XML><AgendaEspecialidad>" + stringXML + "</AgendaEspecialidad><Mensaje><CodMensaje>0</CodMensaje><DescMensaje></DescMensaje></Mensaje><Error><Error_Cod>0</Error_Cod><ErrorDesc>SIN ERRORES</ErrorDesc></Error></XML>";
                else
                    stringXML = stringXML_ErrorAgendaApellidoEspecialidad();

                VariablesGlobales.CloseConfigWebServices(); // Cerramos la conexión
            }
            catch (Exception ex)
            {
                stringXML = ex.Message + (char)13 + ex.StackTrace;
            }

            return stringXML;
        }

        public string WM_ObtenerEspecialidades(int Cod_Empresa, int Cod_Sucursal, string Vigencia, string Internet)
        {
            XmlDocument oXML = new XmlDocument();
            string stringXML = "";
            string responseXML = "";
            int j = 0;
            int k = 0;
            bool xResult = false; // Por defecto mostrará el mensaje de error al paciente

            try
            {
                VariablesGlobales.OpenConfigWebServices(VariablesGlobales.RutaWsAgendaCitasMedisyn); // Abrimos conexión

                if (Cod_Sucursal == 3)
                {
                    using (var oWsTisal = new ServicioReservaHoraWebSoapClient(VariablesGlobales.Binding, VariablesGlobales.EndPoint))
                    {
                        responseXML = oWsTisal.WM_ObtenerEspecialidadesAsync(Cod_Empresa, 1, Vigencia, Internet).Result; // Sede CM
                        stringXML = stringXML + fnObtenerEspecialidades(responseXML, AppCitasEspecialidadesActivas.TeleConsulta);
                        if (stringXML != "")
                            xResult = true;

                        responseXML = oWsTisal.WM_ObtenerEspecialidadesAsync(Cod_Empresa, 2, Vigencia, Internet).Result; // Sede 2: Jesús Maria
                        stringXML = stringXML + fnObtenerEspecialidades(responseXML, AppCitasEspecialidadesActivas.TeleConsulta);
                        if (stringXML != "")
                            xResult = true;

                        if (xResult == true)
                        {
                            j = responseXML.IndexOf("<Especialidades>") + ("<Especialidades>").Length; // Inicio, para indicar lo que no ira.
                            k = responseXML.LastIndexOf("</Especialidades>"); // Final, para indicar lo que no ira.

                            stringXML = responseXML.Substring(0, j) + stringXML + responseXML.Substring(k);
                            stringXML = fnObtenerEspecialidadesFinal(stringXML);

                            j = responseXML.IndexOf("<Especialidades>") + ("<Especialidades>").Length; // Inicio, para indicar lo que no ira.
                            k = responseXML.LastIndexOf("</Especialidades>"); // Final, para indicar lo que no ira.
                            stringXML = responseXML.Substring(0, j) + stringXML + responseXML.Substring(k);
                        }
                        else
                            stringXML = stringXML_ErrorObtenerEspecialidades();
                    }
                }
                else
                    using (var oWsTisal = new ServicioReservaHoraWebSoapClient(VariablesGlobales.Binding, VariablesGlobales.EndPoint))
                    {
                        responseXML = oWsTisal.WM_ObtenerEspecialidadesAsync(Cod_Empresa, Cod_Sucursal, Vigencia, Internet).Result;

                        if (Cod_Sucursal == 1)
                            stringXML = stringXML + fnObtenerEspecialidades(responseXML, AppCitasEspecialidadesActivas.PresencialCM);
                        else if (Cod_Sucursal == 2)
                            stringXML = stringXML + fnObtenerEspecialidades(responseXML, AppCitasEspecialidadesActivas.PresencialJM);

                        j = responseXML.IndexOf("<Especialidades>") + ("<Especialidades>").Length; // Inicio, para indicar lo que no ira.
                        k = responseXML.LastIndexOf("</Especialidades>"); // Final, para indicar lo que no ira.

                        stringXML = responseXML.Substring(0, j) + stringXML + responseXML.Substring(k);
                        stringXML = fnObtenerEspecialidadesFinal(stringXML);

                        j = responseXML.IndexOf("<Especialidades>") + ("<Especialidades>").Length; // Inicio, para indicar lo que no ira.
                        k = responseXML.LastIndexOf("</Especialidades>"); // Final, para indicar lo que no ira.
                        stringXML = responseXML.Substring(0, j) + stringXML + responseXML.Substring(k);
                    }

                VariablesGlobales.CloseConfigWebServices(); // Cerramos la conexión
            }
            catch (Exception ex)
            {
                stringXML = ex.Message + (char)13 + ex.StackTrace;
            }

            return stringXML;
        }

        /// <summary>
        ///     ''' Sirve para comunicarse con el servicio del Medisyn para obtener los médicos. 
        ///     ''' En caso que sea sede "3" se invoca los médicos de la sede "1", "2" y se realiza un filtro.
        ///     ''' </summary>
        ///     ''' <param name="Cod_Empresa">Cod. Empresa</param>
        ///     ''' <param name="Cod_Sucursal">Cod. Sucursal</param>
        ///     ''' <param name="ApelPat_prof">Filtrar por apellido del médico</param>
        ///     ''' <param name="Cod_Isapre"></param>
        ///     ''' <param name="Internet"></param>
        ///     ''' <param name="Cod_Especialidad"></param>
        ///     ''' <param name="Cod_Profesional"></param>
        ///     ''' <param name="Rut_Profesional"></param>
        ///     ''' <returns></returns>
        public string WM_ObtenerAgendaMedico(int Cod_Empresa, int Cod_Sucursal, string ApelPat_prof, int Cod_Isapre, string Internet, int Cod_Especialidad, long Cod_Profesional, long Rut_Profesional)
        {
            string stringXML = "";
            string responseXML = "";
            // Dim j As Integer = 0, k As Integer = 0
            bool xResult = false;

            try
            {
                string NodoLista = "AgendaMedico";

                VariablesGlobales.OpenConfigWebServices(VariablesGlobales.RutaWsAgendaCitasMedisyn); // Abrimos conexión
                if (Cod_Sucursal == 3)
                {
                    using (var oWsTisal = new ServicioReservaHoraWebSoapClient(VariablesGlobales.Binding, VariablesGlobales.EndPoint))
                    {
                        responseXML = oWsTisal.WM_ObtenerAgendaMedicoAsync(Cod_Empresa, 1, ApelPat_prof, Cod_Isapre, Internet, Cod_Especialidad, Cod_Profesional, Rut_Profesional).Result; // Sede 1: Camacho
                        stringXML = stringXML + fnAgendaApellidoEspecialidad(responseXML, NodoLista, ApelPat_prof, TipoMetodoAgenda.WM_ObtenerAgendaMedico, TipoConsultaMedica.TeleConsulta);
                        if (stringXML != "")
                            xResult = true;

                        responseXML = oWsTisal.WM_ObtenerAgendaMedicoAsync(Cod_Empresa, 2, ApelPat_prof, Cod_Isapre, Internet, Cod_Especialidad, Cod_Profesional, Rut_Profesional).Result; // Sede 2: Jesús Maria
                        stringXML = stringXML + fnAgendaApellidoEspecialidad(responseXML, NodoLista, ApelPat_prof, TipoMetodoAgenda.WM_ObtenerAgendaMedico, TipoConsultaMedica.TeleConsulta);
                        if (stringXML != "")
                            xResult = true;

                        // j = responseXML.IndexOf("<" + NodoLista + ">") + Len("<" + NodoLista + ">") 'Inicio, para indicar lo que no ira.
                        // k = responseXML.LastIndexOf("</" + NodoLista + ">") 'Final, para indicar lo que no ira.

                        if (xResult == true)
                            stringXML = "<XML><AgendaMedico>" + stringXML + "</AgendaMedico><Error><Error_Cod>0</Error_Cod><ErrorDesc>SIN ERRORES</ErrorDesc></Error></XML>";
                        else
                            stringXML = stringXML_ErrorAgendaApellidoEspecialidad();
                    }
                }
                else
                    using (var oWsTisal = new ServicioReservaHoraWebSoapClient(VariablesGlobales.Binding, VariablesGlobales.EndPoint))
                    {
                        responseXML = oWsTisal.WM_ObtenerAgendaMedicoAsync(Cod_Empresa, Cod_Sucursal, ApelPat_prof, Cod_Isapre, Internet, Cod_Especialidad, Cod_Profesional, Rut_Profesional).Result;

                        if (Cod_Sucursal == 0)
                        {
                            stringXML = stringXML + fnAgendaApellidoEspecialidad(responseXML, NodoLista, ApelPat_prof, TipoMetodoAgenda.WM_ObtenerAgendaMedico, TipoConsultaMedica.PresencialCM);
                            stringXML = stringXML + fnAgendaApellidoEspecialidad(responseXML, NodoLista, ApelPat_prof, TipoMetodoAgenda.WM_ObtenerAgendaMedico, TipoConsultaMedica.PresencialJM);
                        }
                        else if (Cod_Sucursal == 1)
                            stringXML = stringXML + fnAgendaApellidoEspecialidad(responseXML, NodoLista, ApelPat_prof, TipoMetodoAgenda.WM_ObtenerAgendaMedico, TipoConsultaMedica.PresencialCM);
                        else if (Cod_Sucursal == 2)
                            stringXML = stringXML + fnAgendaApellidoEspecialidad(responseXML, NodoLista, ApelPat_prof, TipoMetodoAgenda.WM_ObtenerAgendaMedico, TipoConsultaMedica.PresencialJM);

                        if (stringXML != "")
                            stringXML = "<XML><AgendaMedico>" + stringXML + "</AgendaMedico><Error><Error_Cod>0</Error_Cod><ErrorDesc>SIN ERRORES</ErrorDesc></Error></XML>";
                        else
                            stringXML = stringXML_ErrorAgendaApellidoEspecialidad();
                    }

                VariablesGlobales.CloseConfigWebServices(); // Cerramos la conexión
            }
            catch (Exception ex)
            {
                stringXML = ex.Message + (char)13 + ex.StackTrace;
            }

            return stringXML;
        }

        /// <summary>
        ///     ''' Nos sirve para obtener las sucursales o sedes de la clinica.
        ///     ''' </summary>
        ///     ''' <param name="Cod_Empresa"></param>
        ///     ''' <returns></returns>
        public string WM_ObtenerSucursales(int Cod_Empresa)
        {
            string stringXML = "";

            try
            {
                stringXML = "<XML><Sucursales>" + fnObtenerSedes() + "</Sucursales><Error><Error_Cod>0</Error_Cod><ErrorDesc>SIN ERRORES</ErrorDesc></Error></XML>";
            }
            catch (Exception ex)
            {
                stringXML = "<XML>" + "<Error><Error_Cod>1</Error_Cod><ErrorDesc>" + ex.Message + (char)13 + ex.StackTrace + "</ErrorDesc></Error></XML>";
            }

            return stringXML;
        }

        /// <summary>
        ///     ''' Este método sirve para registrar y actualizar los datos de la carga familiar del paciente del medisyn. 
        ///     ''' Ahora también servirá para actualizar algunos datos del paciente al sistema de clinica.
        ///     ''' </summary>
        ///     ''' <param name="Cod_Empresa"></param>
        ///     ''' <param name="Cod_Sucursal"></param>
        ///     ''' <param name="Id_Grupofamiliar"></param>
        ///     ''' <param name="Id_Titular"></param>
        ///     ''' <param name="Id_Carga"></param>
        ///     ''' <param name="Id_Ambulatorio_Carga"></param>
        ///     ''' <param name="Rut_Carga"></param>
        ///     ''' <param name="Dv_Carga"></param>
        ///     ''' <param name="Cod_Carga"></param>
        ///     ''' <param name="Nombre_Carga"></param>
        ///     ''' <param name="Apepat_Carga"></param>
        ///     ''' <param name="Apemat_Carga"></param>
        ///     ''' <param name="FechaNac_Carga"></param>
        ///     ''' <param name="Parentesco_Carga"></param>
        ///     ''' <param name="Direccion_Carga"></param>
        ///     ''' <param name="Sexo_Carga"></param>
        ///     ''' <param name="EstadoCivil_Carga"></param>
        ///     ''' <param name="Email_Carga"></param>
        ///     ''' <param name="Telefono_Carga"></param>
        ///     ''' <param name="Celular_Carga"></param>
        ///     ''' <param name="IdDistrito_Carga"></param>
        ///     ''' <param name="CodComuna_Carga"></param>
        ///     ''' <param name="CodProvincia_Carga"></param>
        ///     ''' <param name="Ciudad_Carga"></param>
        ///     ''' <param name="CodLocalidad_Carga"></param>
        ///     ''' <param name="Prevision_Carga"></param>
        ///     ''' <param name="Accion"></param>
        ///     ''' <param name="IP_Cliente"></param>
        ///     ''' <param name="User"></param>
        ///     ''' <returns></returns>
        public string WM_MantCargas(int Cod_Empresa, int Cod_Sucursal, long Id_Grupofamiliar, long Id_Titular, long Id_Carga, long Id_Ambulatorio_Carga, long Rut_Carga, string Dv_Carga, long Cod_Carga, string Nombre_Carga, string Apepat_Carga, string Apemat_Carga, string FechaNac_Carga, string Parentesco_Carga, string Direccion_Carga, string Sexo_Carga, string EstadoCivil_Carga, string Email_Carga, string Telefono_Carga, string Celular_Carga, long IdDistrito_Carga, long CodComuna_Carga, long CodProvincia_Carga, string Ciudad_Carga, long CodLocalidad_Carga, int Prevision_Carga, string Accion, string IP_Cliente, string User)
        {
            string responseXML = "";
            VariablesGlobales.OpenConfigWebServices(VariablesGlobales.RutaWsAgendaCitasMedisyn);
            using (var oWsTisal = new ServicioReservaHoraWebSoapClient(VariablesGlobales.Binding, VariablesGlobales.EndPoint))
            {
                responseXML = oWsTisal.WM_MantCargasAsync(Cod_Empresa, Cod_Sucursal, Id_Grupofamiliar, Id_Titular, Id_Carga, Id_Ambulatorio_Carga, Rut_Carga, Dv_Carga, Cod_Carga, Nombre_Carga, Apepat_Carga, Apemat_Carga, FechaNac_Carga, Parentesco_Carga, Direccion_Carga, Sexo_Carga, EstadoCivil_Carga, Email_Carga, Telefono_Carga, Celular_Carga, IdDistrito_Carga, CodComuna_Carga, CodProvincia_Carga, Ciudad_Carga, CodLocalidad_Carga, Prevision_Carga, Accion, IP_Cliente, User).Result;

                new PacientesAD().Sp_Pacientes_Update(new PacientesE(Id_Ambulatorio_Carga.ToString(), "telefono", Telefono_Carga));
            }
            VariablesGlobales.CloseConfigWebServices();

            return responseXML;
        }

        /// <summary>
        ///     ''' Este método sirve para registrar y actualizar los datos del paciente del medisyn. 
        ///     ''' Ahora también servira para actualizar algunos datos del paciente al sistema de clinica.
        ///     ''' </summary>
        ///     ''' <param name="Cod_Empresa"></param>
        ///     ''' <param name="Cod_Sucursal"></param>
        ///     ''' <param name="Tipo_Usuario"></param>
        ///     ''' <param name="Id_Ambulatorio"></param>
        ///     ''' <param name="Rut_Paciente"></param>
        ///     ''' <param name="Dv_Paciente"></param>
        ///     ''' <param name="Nombre_Paciente"></param>
        ///     ''' <param name="Apepat_Paciente"></param>
        ///     ''' <param name="Apemat_Paciente"></param>
        ///     ''' <param name="Fechanac_Paciente"></param>
        ///     ''' <param name="Direccion_Paciente"></param>
        ///     ''' <param name="Comuna_Paciente"></param>
        ///     ''' <param name="Distrito_Paciente"></param>
        ///     ''' <param name="Cod_Ciudad"></param>
        ///     ''' <param name="Ciudad_Paciente"></param>
        ///     ''' <param name="Localidad_Paciente"></param>
        ///     ''' <param name="Fono1_Paciente"></param>
        ///     ''' <param name="Fono2_Paciente"></param>
        ///     ''' <param name="Email_Paciente"></param>
        ///     ''' <param name="Sexo_Paciente"></param>
        ///     ''' <param name="EstadoCivil_Paciente"></param>
        ///     ''' <param name="Prevision_Paciente"></param>
        ///     ''' <param name="Clave_Usuario"></param>
        ///     ''' <param name="Pregunta_Clave"></param>
        ///     ''' <param name="RespuestaClave"></param>
        ///     ''' <param name="Estado"></param>
        ///     ''' <param name="Accion"></param>
        ///     ''' <param name="IP_Cliente"></param>
        ///     ''' <param name="Usuario"></param>
        ///     ''' <returns></returns>
        public string WM_MantUsuario(long Cod_Empresa, int Cod_Sucursal, string Tipo_Usuario, int Id_Ambulatorio, int Rut_Paciente, string Dv_Paciente, string Nombre_Paciente, string Apepat_Paciente, string Apemat_Paciente, string Fechanac_Paciente, string Direccion_Paciente, int Comuna_Paciente, int Distrito_Paciente, int Cod_Ciudad, string Ciudad_Paciente, int Localidad_Paciente, string Fono1_Paciente, string Fono2_Paciente, string Email_Paciente, string Sexo_Paciente, string EstadoCivil_Paciente, int Prevision_Paciente, string Clave_Usuario, string Pregunta_Clave, string RespuestaClave, string Estado, string Accion, string IP_Cliente, string Usuario)
        {
            string responseXML = "";
            PacientesAD oPacientesAD = new PacientesAD();
            VariablesGlobales.OpenConfigWebServices(VariablesGlobales.RutaWsAgendaCitasMedisyn);
            using (var oWsTisal = new ServicioReservaHoraWebSoapClient(VariablesGlobales.Binding, VariablesGlobales.EndPoint))
            {
                responseXML = oWsTisal.WM_MantUsuarioAsync(Cod_Empresa, Cod_Sucursal, Tipo_Usuario, Id_Ambulatorio, Rut_Paciente, Dv_Paciente,
                                                           Nombre_Paciente, Apepat_Paciente, Apemat_Paciente, Fechanac_Paciente, Direccion_Paciente,
                                                           Comuna_Paciente, Distrito_Paciente, Cod_Ciudad, Ciudad_Paciente, Localidad_Paciente,
                                                           Fono1_Paciente, Fono2_Paciente, Email_Paciente, Sexo_Paciente, EstadoCivil_Paciente,
                                                           Prevision_Paciente, Clave_Usuario, Pregunta_Clave, RespuestaClave, Estado, Accion,
                                                           IP_Cliente, Usuario).Result;

                oPacientesAD.Sp_Pacientes_Update(new PacientesE(Id_Ambulatorio.ToString(), "telefono", Fono1_Paciente));
                oPacientesAD.Sp_Pacientes_Update(new PacientesE(Id_Ambulatorio.ToString(), "correo", Email_Paciente));
            }
            VariablesGlobales.CloseConfigWebServices();

            GC.Collect();
            return responseXML;
        }

        public string WM_TraeDatosAcceso(int Cod_Empresa, long Rut_Paciente, string Dv_Paciente, string Email_Paciente, string ApiKey)
        {
            string responseXML = "";
            if (fnValidarApiKey(ApiKey) == true)
            {
                VariablesGlobales.OpenConfigWebServices(VariablesGlobales.RutaWsAgendaCitasMedisyn);
                using (var oWsTisal = new ServicioReservaHoraWebSoapClient(VariablesGlobales.Binding, VariablesGlobales.EndPoint))
                {
                    responseXML = oWsTisal.WM_TraeDatosAccesoAsync(Cod_Empresa, Rut_Paciente, Dv_Paciente).Result;
                }
                VariablesGlobales.CloseConfigWebServices();
            }
            else
            {
                Response_XML.XML oXML = new Response_XML.XML();
                oXML.Mensaje = new Response_XML.XML.MensajeE(); // XML.MensajeE
                oXML.RecuperaAcceso = new Response_XML.XML.RecuperaAccesoE(); // XML.RecuperaAccesoE
                oXML.RecuperaAcceso.DatosAcceso.ESTADO = "N";
                oXML.RecuperaAcceso.DatosAcceso.DESC_ESTADO = "NO TIENE ACCESO A CONSULTAR LOS DATOS";

                responseXML = fnSerializeXML(oXML);
            }

            return responseXML;
        }

        public string WM_TraeDatosAccesoSinValidacion(int Cod_Empresa, long Rut_Paciente, string Dv_Paciente)
        {
            string responseXML = "";

            VariablesGlobales.OpenConfigWebServices(VariablesGlobales.RutaWsAgendaCitasMedisyn);
            using (var oWsTisal = new ServicioReservaHoraWebSoapClient(VariablesGlobales.Binding, VariablesGlobales.EndPoint))
            {
                responseXML = oWsTisal.WM_TraeDatosAccesoAsync(Cod_Empresa, Rut_Paciente, Dv_Paciente).Result;
            }
            VariablesGlobales.CloseConfigWebServices();

            return responseXML;
        }

        public string WM_ValidaRutEnSistema(int Cod_Empresa, int Cod_Sucursal, long Rut_Paciente, string Dv_Paciente, string Fecha_NacPac, string TitularCarga, string ApiKey)
        {
            string responseXML = "";
            if (fnValidarApiKey(ApiKey) == true)
            {
                VariablesGlobales.OpenConfigWebServices(VariablesGlobales.RutaWsAgendaCitasMedisyn);
                using (var oWsTisal = new ServicioReservaHoraWebSoapClient(VariablesGlobales.Binding, VariablesGlobales.EndPoint))
                {
                    responseXML = oWsTisal.WM_ValidaRutEnSistemaAsync(Cod_Empresa, Cod_Sucursal, Rut_Paciente, Dv_Paciente, Fecha_NacPac, TitularCarga).Result;
                }
                VariablesGlobales.CloseConfigWebServices();
            }
            else
            {
                Response_XML.XML oXML = new Response_XML.XML();

                Response_XML.XML.DatosPaciente DatosPaciente = new Response_XML.XML.DatosPaciente();
                DatosPaciente.ESTADO = "X";
                DatosPaciente.DESC_ESTADO = "NO TIENE ACCESO A CONSULTAR LOS DATOS";

                oXML.Paciente = new List<Response_XML.XML.DatosPaciente>();
                oXML.Paciente.Add(DatosPaciente);

                responseXML = fnSerializeXML(oXML);
            }

            return responseXML;
        }

        public string WM_LogeoPaciente(int Cod_Empresa, int Cod_Sucursal, int Rut_PacienteTitular, string Dv_PacienteTitular, string IP_Cliente, string Clave_Paciente, string ApiKey)
        {
            string responseXML = "";
            if (fnValidarApiKey(ApiKey) == true)
            {
                VariablesGlobales.OpenConfigWebServices(VariablesGlobales.RutaWsAgendaCitasMedisyn);
                using (var oWsTisal = new ServicioReservaHoraWebSoapClient(VariablesGlobales.Binding, VariablesGlobales.EndPoint))
                {
                    responseXML = oWsTisal.WM_LogeoPacienteAsync(Cod_Empresa, Cod_Sucursal, Rut_PacienteTitular, Dv_PacienteTitular, IP_Cliente, Clave_Paciente).Result;
                }
                VariablesGlobales.CloseConfigWebServices();
            }
            else
            {
                Response_XML.XML oXML = new Response_XML.XML();
                Response_XML.XML.InformacionLogeo InformacionLogeo = new Response_XML.XML.InformacionLogeo();
                InformacionLogeo.ESTADO = "X";
                InformacionLogeo.DESC_ESTADO = "NO TIENE ACCESO A CONSULTAR LOS DATOS";

                oXML.LogeoPaciente = new List<Response_XML.XML.InformacionLogeo>();
                oXML.LogeoPaciente.Add(InformacionLogeo);

                responseXML = fnSerializeXML(oXML);
            }

            return responseXML;
        }

        public string WM_CambiarClaveWeb(int Cod_Empresa, int Cod_Sucursal, int Id_Paciente, string Pregunta_Clave, string Respuesta_Clave, string Clave_Actual, string Clave_Nueva, string IP_Cliente, string User, string ApiKey)
        {
            string responseXML = "";
            if (fnValidarApiKey(ApiKey) == true)
            {
                VariablesGlobales.OpenConfigWebServices(VariablesGlobales.RutaWsAgendaCitasMedisyn);
                using (var oWsTisal = new ServicioReservaHoraWebSoapClient(VariablesGlobales.Binding, VariablesGlobales.EndPoint))
                {
                    responseXML = oWsTisal.WM_CambiarClaveWebAsync(Cod_Empresa, Cod_Sucursal, Id_Paciente, Pregunta_Clave, Respuesta_Clave, Clave_Actual, Clave_Nueva, IP_Cliente, User).Result;
                }
                VariablesGlobales.CloseConfigWebServices();
            }
            else
            {
                Response_XML.XML oXML = new Response_XML.XML();
                Response_XML.XML.DatosCambio DatosCambio = new Response_XML.XML.DatosCambio();
                DatosCambio.CODMENSAJE = "X";
                DatosCambio._x0027_CLAVEACTUALINVALIDA_x0027_ = "NO TIENE ACCESO A CONSULTAR LOS DATOS";

                oXML.CambioClaveWeb = new List<Response_XML.XML.DatosCambio>();
                oXML.CambioClaveWeb.Add(DatosCambio);
                oXML.Mensaje = new Response_XML.XML.MensajeE();

                responseXML = fnSerializeXML(oXML);
            }

            return responseXML;
        }

        public string WM_EnvioMail(int Cod_Empresa, string Mail_To, string Mail_Bcc, string Mail_Cc, string Mail_Body, string Mail_Subject, string Sistema_Envio, string Responsable, string ApiKey)
        {
            string responseXML = "";
            if (fnValidarApiKey(ApiKey) == true)
            {
                VariablesGlobales.OpenConfigWebServices(VariablesGlobales.RutaWsAgendaCitasMedisyn);
                using (var oWsTisal = new ServicioReservaHoraWebSoapClient(VariablesGlobales.Binding, VariablesGlobales.EndPoint))
                {
                    responseXML = oWsTisal.WM_EnvioMailAsync(Cod_Empresa, Mail_To, Mail_Bcc, Mail_Cc, Mail_Body, Mail_Subject, Sistema_Envio, Responsable).Result;
                }
                VariablesGlobales.CloseConfigWebServices();
            }
            else
                responseXML = "false";

            return responseXML;
        }

        // ----

        public string WM_BuscaCargas(int Cod_Empresa, int Id_GrupoFamiliar)
        {
            string responseXML = "";
            string stringXML = "";
            XmlDocument oXML = new XmlDocument();

            VariablesGlobales.OpenConfigWebServices(VariablesGlobales.RutaWsAgendaCitasMedisyn);
            using (var oWsTisal = new ServicioReservaHoraWebSoapClient(VariablesGlobales.Binding, VariablesGlobales.EndPoint))
            {
                responseXML = oWsTisal.WM_BuscaCargasAsync(Cod_Empresa, Id_GrupoFamiliar).Result;
            }
            VariablesGlobales.CloseConfigWebServices();

            oXML.LoadXml(responseXML);

            try
            {
                DataTable dtReservaHora = DevolverTabla_XML(oXML, "CargasAsociadas", "InfoCarga", "ESTADO", "ID_AMBULATORIO", "RUT_PACIENTE", "DV_PACIENTE", "COD_CARGA", "RUT_PACIENTE_STR", "NOMBRE_PACIENTE", "APEPAT_PACIENTE", "APEMAT_PACIENTE", "DIRECCION_PACIENTE", "CIUDAD_PACIENTE", "FONO_PRINC_PACIENTE", "FONO_ALTER_PACIENTE", "FECHA_NAC_PACIENTE", "SEXO_PACIENTE", "PREVISION", "DESC_PREVISION", "PARENTESCO", "DESC_PARENTESCO");

                stringXML = stringXML + "<XML><CargasAsociadas>";
                for (int i = 0; i <= dtReservaHora.Rows.Count - 1; i++)
                {
                    stringXML = stringXML + "<InfoCarga>";
                    stringXML = stringXML + fnStringBodyXML(dtReservaHora.Rows[i], dtReservaHora.Columns);

                    string RutPaciente = (string)dtReservaHora.Rows[i][("RUT_PACIENTE")];
                    //stringXML = stringXML + "<ENCRYPTED_ID>" + Utilities.Criptography.EncryptConectionString(Right("0000" + Rut_Paciente, 8)) + "</ENCRYPTED_ID>";

                    stringXML = stringXML + "<ENCRYPTED_ID>" + Utilities.Criptography.EncryptConectionString(Bus.Utilities.General.Rigth("0000" + Rut_Paciente, 8)) + "</ENCRYPTED_ID>";

                    stringXML = stringXML + "</InfoCarga>";
                }
                stringXML = stringXML + "</CargasAsociadas><Mensaje><CodMensaje>0</CodMensaje><DescMensaje></DescMensaje></Mensaje><Error><Error_Cod>0</Error_Cod><ErrorDesc>SIN ERRORES</ErrorDesc></Error></XML>";
            }
            catch (Exception ex)
            {
                stringXML = responseXML;
            }


            return stringXML;
        }



        public string WM_BuscaPacienteTitular(int Cod_Empresa, int Cod_Sucursal, long Rut_Paciente, string Dv_Paciente, string Usuario, string CodPacienteConsulta = "")
        {
            string responseXML = "";
            string stringXML = "";
            XmlDocument oXML = new XmlDocument();

            VariablesGlobales.OpenConfigWebServices(VariablesGlobales.RutaWsAgendaCitasMedisyn);
            using (var oWsTisal = new ServicioReservaHoraWebSoapClient(VariablesGlobales.Binding, VariablesGlobales.EndPoint))
            {
                responseXML = oWsTisal.WM_BuscaPacienteTitularAsync(Cod_Empresa, Cod_Sucursal, Rut_Paciente, Dv_Paciente, Usuario).Result;
            }
            VariablesGlobales.CloseConfigWebServices();

            oXML.LoadXml(responseXML);

            try
            {
                DataTable dtReservaHora = DevolverTabla_XML(oXML, "Paciente", "DatosPaciente", "ESTADO", "DESC_ESTADO", "ID_AMBULATORIO", "NOMBRE_PACIENTE", "APEPAT_PACIENTE", "APEMAT_PACIENTE", "SEXO_PACIENTE", "ESTADO_CIVIL_PACIENTE", "DIRECCION_PACIENTE", "COMUNA_PACIENTE", "DISTRITO_PACIENTE", "CIUDAD_PACIENTE", "COD_CIUDAD", "LOCALIDAD_PACIENTE", "FONO_PRINC_PACIENTE", "FONO_ALTER_PACIENTE", "FECHA_NAC_PACIENTE", "PREVISION_PACIENTE", "DESC_PREVISION", "EMAIL_PACIENTE", "ID_GRUPO_FAMILIAR", "TIPO_ESTADO_PAC", "NUMERO_CELULAR");

                stringXML = stringXML + "<XML><Paciente>";
                for (int i = 0; i <= dtReservaHora.Rows.Count - 1; i++)
                {
                    stringXML = stringXML + "<DatosPaciente>";
                    stringXML = stringXML + fnStringBodyXML(dtReservaHora.Rows[i], dtReservaHora.Columns);

                    List<PacientesE> oPacientes = new List<PacientesE>();
                    oPacientes = new PacientesAD().Sp_Pacientes_Consulta(new PacientesE((string)dtReservaHora.Rows[i]["ID_AMBULATORIO"], 0, 0, 16, ""));
                    if (oPacientes.Count != 0)
                        stringXML = stringXML + "<FECHA_REGISTRO>" + oPacientes[0].FechaRegistro.ToString("dd/MM/yyyy HH:mm:ss") + "</FECHA_REGISTRO>";
                    else
                        stringXML = stringXML + "<FECHA_REGISTRO>" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "</FECHA_REGISTRO>";

                    stringXML = stringXML + "<ENCRYPTED_ID>" + Utilities.Criptography.EncryptConectionString(Bus.Utilities.General.Rigth("0000" + Rut_Paciente, 8)) + "</ENCRYPTED_ID>";

                    stringXML = stringXML + "</DatosPaciente>";
                }
                stringXML = stringXML + "</Paciente><Mensaje><CodMensaje>3</CodMensaje><DescMensaje></DescMensaje></Mensaje><Error><Error_Cod>0</Error_Cod><ErrorDesc>SIN ERRORES</ErrorDesc></Error></XML>";
            }
            catch (Exception ex)
            {
                stringXML = responseXML;
            }

            return stringXML;
        }

        public string WM_CreaXmlCalendario(int intEmpresa, int lngCodSucursal, int lngCodUnidad, long lngCodEspecialidad, long lngCod_Prof, long Corr_Agenda, string Fecha_ProximaHora)
        {
            string responseXML = "";
            string Fecha = "";
            // Dim result As String = stringXML.Substring(0, stringXML.IndexOf(";"))
            Fecha = Fecha_ProximaHora;
            VariablesGlobales.OpenConfigWebServices(VariablesGlobales.RutaWsAgendaCitasMedisyn);
            using (var oWsTisal = new ServicioReservaHoraWebSoapClient(VariablesGlobales.Binding, VariablesGlobales.EndPoint))
            {
                responseXML = oWsTisal.WM_CreaXmlCalendarioAsync(intEmpresa, lngCodSucursal, lngCodUnidad, lngCodEspecialidad, lngCod_Prof, Corr_Agenda, Fecha).Result;
                responseXML = responseXML.Substring(0, responseXML.IndexOf(";"));

                // 18/10/2021
                // 1234567890
                // MM/dd/yyyy
                Fecha = Fecha.Substring(3, 2) + "/" + Fecha.Substring(0, 2) + "/" + Fecha.Substring(6, 4);
                Fecha = Convert.ToDateTime(Fecha).AddDays(31).ToString("dd/MM/yyyy");
                responseXML = responseXML + oWsTisal.WM_CreaXmlCalendarioAsync(intEmpresa, lngCodSucursal, lngCodUnidad, lngCodEspecialidad, lngCod_Prof, Corr_Agenda, Fecha).Result;
                responseXML = responseXML.Substring(0, responseXML.IndexOf(";"));

                Fecha = Fecha.Substring(3, 2) + "/" + Fecha.Substring(0, 2) + "/" + Fecha.Substring(6, 4);
                Fecha = Convert.ToDateTime(Fecha).AddDays(31).ToString("dd/MM/yyyy");
                responseXML = responseXML + oWsTisal.WM_CreaXmlCalendarioAsync(intEmpresa, lngCodSucursal, lngCodUnidad, lngCodEspecialidad, lngCod_Prof, Corr_Agenda, Fecha);
            }

            VariablesGlobales.CloseConfigWebServices();

            return responseXML;
        }

        public string WM_CreaXMLDetalleDiaCalendario(int Cod_Empresa, int Cod_Sucursal, int Cod_CentMedico, int Cod_Unidad, int Cod_Especialidad, int Cod_Prof, long Corr_Agenda, string Fecha, string Fecha_proxhoradisp)
        {
            string responseXML = "";
            XmlDocument oXML = new XmlDocument();

            VariablesGlobales.OpenConfigWebServices(VariablesGlobales.RutaWsAgendaCitasMedisyn);
            using (var oWsTisal = new ServicioReservaHoraWebSoapClient(VariablesGlobales.Binding, VariablesGlobales.EndPoint))
            {
                responseXML = oWsTisal.WM_CreaXmlDetalleDiaCalendarioAsync(Cod_Empresa, Cod_Sucursal, Cod_CentMedico, Cod_Unidad, Cod_Especialidad, Cod_Prof, Corr_Agenda, Fecha, Fecha_proxhoradisp) + "";
            }
            VariablesGlobales.CloseConfigWebServices();

            return responseXML;
        }

        public string WM_CreaXMLDetalleDiaCalendarioV2(int Cod_Empresa, int Cod_Sucursal, int Cod_CentMedico, int Cod_Unidad, int Cod_Especialidad, int Cod_Prof, long Corr_Agenda, string Fecha, string Fecha_proxhoradisp, string TeleMedicina)
        {
            string responseXML = "";
            XmlDocument oXML = new XmlDocument();

            VariablesGlobales.OpenConfigWebServices(VariablesGlobales.RutaWsAgendaCitasMedisyn);
            using (var oWsTisal = new ServicioReservaHoraWebSoapClient(VariablesGlobales.Binding, VariablesGlobales.EndPoint))
            {
                responseXML = oWsTisal.WM_CreaXmlDetalleDiaCalendarioAsync(Cod_Empresa, Cod_Sucursal, Cod_CentMedico, Cod_Unidad, Cod_Especialidad, Cod_Prof, Corr_Agenda, Fecha, Fecha_proxhoradisp).Result;

                if (VariablesGlobales.HorarioRestringidoPresencial != "" | VariablesGlobales.HorarioRestringidoVirtual != "")
                {
                    oXML.LoadXml(responseXML);
                    DataTable dtReservaHora = DevolverTabla_XML(oXML, "Horas", "DetalleDia", "Hora", "CorrelativoHorario", "Box", "Multiplicidad", "Lleno", "Item");

                    string stringXML = "";
                    stringXML = "<XML><Horas>";

                    for (int i = 0; i <= dtReservaHora.Rows.Count - 1; i++)
                    {
                        if (TeleMedicina == "S")
                        {
                            if (Convert.ToDateTime(dtReservaHora.Rows[i]["Hora"] + "") <= Convert.ToDateTime(VariablesGlobales.HorarioRestringidoVirtual))
                                stringXML = stringXML + "<DetalleDia>" + fnStringBodyXML(dtReservaHora.Rows[i], dtReservaHora.Columns) + "</DetalleDia>";
                        }
                        else if (Convert.ToDateTime(dtReservaHora.Rows[i]["Hora"] + "") <= Convert.ToDateTime(VariablesGlobales.HorarioRestringidoPresencial))
                            stringXML = stringXML + "<DetalleDia>" + fnStringBodyXML(dtReservaHora.Rows[i], dtReservaHora.Columns) + "</DetalleDia>";
                    }

                    stringXML = stringXML + "</Horas>";

                    stringXML = stringXML + "<Mensaje><CodMensaje>0</CodMensaje><DescMensaje></DescMensaje></Mensaje><Error><Error_Cod>0</Error_Cod><ErrorDesc>SIN ERRORES</ErrorDesc></Error><MaximoDias>365</MaximoDias></XML>";

                    responseXML = stringXML;
                }
            }
            VariablesGlobales.CloseConfigWebServices();

            return responseXML;
        }

        public string WM_ObtenerComunas(int Cod_Empresa, int Cod_Sucursal, string User, long Cod_Ubigeo)
        {
            string responseXML = "";

            VariablesGlobales.OpenConfigWebServices(VariablesGlobales.RutaWsAgendaCitasMedisyn);
            using (var oWsTisal = new ServicioReservaHoraWebSoapClient(VariablesGlobales.Binding, VariablesGlobales.EndPoint))
            {
                responseXML = oWsTisal.WM_ObtenerComunasAsync(Cod_Empresa, Cod_Sucursal, User, Cod_Ubigeo) + "";
            }

            VariablesGlobales.CloseConfigWebServices();

            return responseXML;
        }

        public string WM_ObtenerDepto(int Cod_Empresa)
        {
            string responseXML = "";

            VariablesGlobales.OpenConfigWebServices(VariablesGlobales.RutaWsAgendaCitasMedisyn);
            using (var oWsTisal = new ServicioReservaHoraWebSoapClient(VariablesGlobales.Binding, VariablesGlobales.EndPoint))
            {
                responseXML = oWsTisal.WM_ObtenerDeptoAsync(Cod_Empresa).Result;
            }
            VariablesGlobales.CloseConfigWebServices();

            return responseXML;
        }

        public string WM_ObtenerInfoEmpresa(int Cod_Empresa)
        {
            string responseXML = "";

            VariablesGlobales.OpenConfigWebServices(VariablesGlobales.RutaWsAgendaCitasMedisyn);
            using (var oWsTisal = new ServicioReservaHoraWebSoapClient(VariablesGlobales.Binding, VariablesGlobales.EndPoint))
            {
                responseXML = oWsTisal.WM_ObtenerInfoEmpresaAsync(Cod_Empresa).Result;
            }
            VariablesGlobales.CloseConfigWebServices();

            return responseXML;
        }

        public string WM_ObtenerProvincias(int Cod_Empresa, long Cod_Ubigeo)
        {
            string responseXML = "";

            VariablesGlobales.OpenConfigWebServices(VariablesGlobales.RutaWsAgendaCitasMedisyn);
            using (var oWsTisal = new ServicioReservaHoraWebSoapClient(VariablesGlobales.Binding, VariablesGlobales.EndPoint))
            {
                responseXML = oWsTisal.WM_ObtenerProvinciasAsync(Cod_Empresa, Cod_Ubigeo).Result;
            }
            VariablesGlobales.CloseConfigWebServices();

            return responseXML;
        }

        public string WM_ObtenerReservasMedico(int Cod_Empresa, int Cod_Sucursal, int Cod_CentroMedico, int Cod_Medico, long Corr_Agenda, string Fecha)
        {
            string responseXML = "";

            VariablesGlobales.OpenConfigWebServices(VariablesGlobales.RutaWsAgendaCitasMedisyn);
            using (var oWsTisal = new ServicioReservaHoraWebSoapClient(VariablesGlobales.Binding, VariablesGlobales.EndPoint))
            {
                responseXML = oWsTisal.WM_ObtenerReservasMedicoAsync(Cod_Empresa, Cod_Sucursal, Cod_CentroMedico, Cod_Medico, Corr_Agenda, Fecha).Result;
            }
            VariablesGlobales.CloseConfigWebServices();

            DataTable dt = new DataTable();
            XmlDocument oXML = new XmlDocument();
            int RowCount = 0;
            string stringXml = "";
            string stringResult = "";

            oXML.LoadXml(responseXML);

            dt = DevolverTabla_XML(oXML, "ReservasMedico", "Datos", "CORREL_RESERVA", "HORA_RESERVA", "NUMERO_FICHA", "RECEPCIONADO", "COD_PAC", "COD_CARGA", "COD_ISAPRE", "OBS_STD", "OBS_LIB", "ISAPRE", "COD_CONVENIO", "CONVENIO", "RESP", "PATERNO", "MATERNO", "NOMBRES", "SEXO_PACIENTE");
            RowCount = dt.Rows.Count / 2;

            for (int i = 0; i <= (RowCount) - 1; i++)
            {
                stringXml = stringXml + "<Datos>";
                stringXml = stringXml + fnStringBodyXML(dt.Rows[i], dt.Columns);
                stringXml = stringXml + "</Datos>";
            }

            stringResult = stringResult + "<XML><ReservasMedico>";
            stringResult = stringResult + stringXml;
            stringResult = stringResult + "</ReservasMedico><Mensaje><CodMensaje>0</CodMensaje><DescMensaje/></Mensaje><Error><Error_Cod>0</Error_Cod><ErrorDesc>SIN ERRORES</ErrorDesc></Error></XML>";

            return stringResult;
        }

        public string WM_ValidaPacienteWeb(int Cod_Empresa, string Rut_Paciente, string DV_Paciente, string Clave_Paciente)
        {
            string responseXML = "";

            VariablesGlobales.OpenConfigWebServices(VariablesGlobales.RutaWsAgendaCitasMedisyn);
            using (var oWsTisal = new ServicioReservaHoraWebSoapClient(VariablesGlobales.Binding, VariablesGlobales.EndPoint))
            {
                responseXML = oWsTisal.WM_ValidaPacienteWebAsync(Cod_Empresa, Rut_Paciente, DV_Paciente, Clave_Paciente).Result;
                //(Cod_Empresa, Rut_Paciente, DV_Paciente, Clave_Paciente);
            }
            VariablesGlobales.CloseConfigWebServices();

            return responseXML;
        }



        public class Response_XML
        {
            public XML _Xml { get; set; } = new XML();
            public class XML
            {
                public RecuperaAccesoE RecuperaAcceso { get; set; }
                public List<DatosPaciente> Paciente { get; set; }
                public List<InformacionLogeo> LogeoPaciente { get; set; }
                public List<DatosCambio> CambioClaveWeb { get; set; }
                public MensajeE Mensaje { get; set; }
                public ErrorE Error { get; set; } = new ErrorE();

                public class RecuperaAccesoE
                {
                    public DatosAccesoE DatosAcceso { get; set; } = new DatosAccesoE();
                    public class DatosAccesoE
                    {
                        public string ESTADO { get; set; }
                        public string DESC_ESTADO { get; set; }
                        public string NOMBRE_PACIENTE { get; set; }
                        public string PREGUNTA_CLAVE { get; set; }
                        public string RESPUESTA_CLAVE { get; set; }
                        public string CLAVE_USUARIO { get; set; }
                        public string EMAIL_PACIENTE { get; set; }
                    }
                }

                public class DatosPaciente
                {
                    public string ESTADO { get; set; }
                    public string DESC_ESTADO { get; set; }
                    public string ID_AMBULATORIO { get; set; }
                    public string NOMBRE_PACIENTE { get; set; }
                    public string APEPAT_PACIENTE { get; set; }
                    public string APEMAT_PACIENTE { get; set; }
                    public string SEXO_PACIENTE { get; set; }
                    public string DIRECCION_PACIENTE { get; set; }
                    public string COMUNA_PACIENTE { get; set; }
                    public string CIUDAD_PACIENTE { get; set; }
                    public string FONO_PRINC_PACIENTE { get; set; }
                    public string FONO_ALTER_PACIENTE { get; set; }
                    public string FECHA_NAC_PACIENTE { get; set; }
                    public string PREVISION_PACIENTE { get; set; }
                    public string EMAIL_PACIENTE { get; set; }
                    public string TIPO_ESTADO_PAC { get; set; }
                    public string FONO_CONFIRMACION { get; set; }
                    public string VIA_CONFIRMACION { get; set; }
                    public string RECIBE_INFORMACION { get; set; }
                    public string PREFIJO_CELULAR1 { get; set; }
                    public string NUMERO_CELULAR1 { get; set; }
                    public string PREFIJO_CELULAR2 { get; set; }
                    public string NUMERO_CELULAR2 { get; set; }
                }

                public class InformacionLogeo
                {
                    public string ESTADO { get; set; }
                    public string DESC_ESTADO { get; set; }
                    public string CLAVE_TEMP { get; set; }
                    public string ID_AMBULATORIO { get; set; }
                    public string NOMBRE_PACIENTE { get; set; }
                    public string APEPAT_PACIENTE { get; set; }
                    public string APEMAT_PACIENTE { get; set; }
                }

                public class DatosCambio
                {
                    public string CODMENSAJE { get; set; }
                    public string _x0027_CLAVEACTUALINVALIDA_x0027_ { get; set; }
                }

                public class MensajeE
                {
                    public int CodMensaje { get; set; } = 0;
                    public string DescMensaje { get; set; } = "";
                }

                public class ErrorE
                {
                    /// <remarks/>
                    public int Error_Cod { get; set; } = 0;
                    /// <remarks/>
                    public string ErrorDesc { get; set; } = "SIN ERRORES";
                }
            }
        }

        private string stringXML_ErrorAgendaApellidoEspecialidad()
        {
            return "<XML><Mensaje><CodMensaje>1</CodMensaje><DescMensaje></DescMensaje></Mensaje><Error><Error_Cod>0</Error_Cod><ErrorDesc>SIN ERRORES</ErrorDesc></Error></XML>";
        }

        private string stringXML_ErrorObtenerEspecialidades()
        {
            return "<XML><Error><Error_Cod>0</Error_Cod><ErrorDesc>SIN ERRORES</ErrorDesc></Error></XML>";
        }

        private string stringXML_AnulacionHoras(string pMsgError)
        {
            string stringXML = "";
            stringXML = "<XML>" + "<Anulacion_Reserva>";

            stringXML = stringXML + "<ESTADO>" + "N" + "</ESTADO>";
            stringXML = stringXML + "<DESC_ESTADO>" + pMsgError + "</DESC_ESTADO>";

            stringXML = stringXML + "</Anulacion_Reserva>" + "<Mensaje><CodMensaje>0</CodMensaje><DescMensaje></DescMensaje></Mensaje><Error><Error_Cod>0</Error_Cod><ErrorDesc>SIN ERRORES</ErrorDesc></Error>" + "</XML>";

            return stringXML;
        }
    }
}