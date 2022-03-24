using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Timers;
//using System.Threading;
using System.Xml;
using Dat.Sql.ClinicaAD.MedisynAD;
using Ent.Sql.ClinicaE.OtrosE;
using Dat.Sql.ClinicaAD.OtrosAD;
using Ent.Oracle.MedisynE.CorreosE;
using Dat.Oracle.MedisynAD.CorreosAD;
using System.Data;

namespace Bus.AgendaClinica.Clinica
{
    public class CorreoAgenda
    {
        public struct CorreoLista
        {
            public const string Medisy_AgendaWebErrorServicio = "MEDISYN_AGENDAWEBERRORSERVICIO";
            public const string Medisyn_AgendaWebPaciente = "MEDISYN_AGENDAWEBPACIENTE";
        }

        public struct CorreoTipo
        {
            public const string CorreoTo = "TO";
            public const string CorreoCC = "CC";
            public const string CorreoCCo = "CCO";
        }

        public void Load_Initial()
        {
            Utilities.Net oNet = new Utilities.Net();
            oNet.Load_Net();

            VariablesGlobales.LoadConectionString("CnnMedisynOracle", VariablesGlobales.ListDataBase.medisyn);
            VariablesGlobales.LoadConectionString("cnnClinicaSql", VariablesGlobales.ListDataBase.clinica);
        }


        private System.Timers.Timer oTimerEnvioCorreo;
        public int TiempoIntervalo = 0;
        public int IdMail = 0;
        public string PerfilNameCorreo = "";
        private int ConteoReinicio = 0;

        private SisCorreoE oSisCorreoE = new SisCorreoE();
        private SisCorreoAD oSisCorreoAD = new SisCorreoAD();
        private TablasAD oTablasAD = new TablasAD();

        public int CargarIdMailMedisyn()
        {
            //TablasE oTablasE = new TablasE();
            List<TablasE> oListTablasE = new List<TablasE>();

            try
            {
                oListTablasE = oTablasAD.Sp_Tablas_Consulta(new TablasE("MEDISYN_IDMAILORACLE", "", 34, 0, -1));
                foreach (var oTablasE in oListTablasE)
                {
                    if (oTablasE.Estado.Trim() == "A")
                        IdMail = (int)oTablasE.Valor;
                }

                return IdMail;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string getCorreoEnvio(string pCorreoLista, string pCorreoTipo)
        {
            List<SisCorreodestinatarioMaeE> oListSisCorreodestinatarioMaeE = new List<SisCorreodestinatarioMaeE>();
            SisCorreodestinatarioMaeAD oSisCorreodestinatarioMaeAD = new SisCorreodestinatarioMaeAD();
            string xResult = "";

            oListSisCorreodestinatarioMaeE = oSisCorreodestinatarioMaeAD.Sp_CorreoDestinatario_Consulta(new SisCorreodestinatarioMaeE(pCorreoLista, pCorreoTipo));
            if (oListSisCorreodestinatarioMaeE.Count != 0)
                xResult = oListSisCorreodestinatarioMaeE[0].DscDestinatario;

            return xResult;
        }

        public void StarStopServicesMail(string pBody)
        {
            SisCorreoE oSisCorreoE = new SisCorreoE();
            string xTo = getCorreoEnvio(CorreoLista.Medisy_AgendaWebErrorServicio, CorreoTipo.CorreoTo);
            string xCC = getCorreoEnvio(CorreoLista.Medisy_AgendaWebErrorServicio, CorreoTipo.CorreoCC);

            oSisCorreoE.PerfilName = PerfilNameCorreo;
            oSisCorreoE.Asunto = "Correo Servicio Agenda Web";
            oSisCorreoE.Cuerpo = pBody;
            oSisCorreoE.EnviarA = xTo;
            oSisCorreoE.CopiarA = xCC;
            oSisCorreoAD.Ut_EnviarCorreov3(oSisCorreoE);
        }

        public void CargarDatosIni()
        {
            //TablasE oTablasE = new TablasE();
            List<TablasE> oListTablasE = new List<TablasE>();
            TablasAD oTablasAD = new TablasAD();

            oListTablasE = oTablasAD.Sp_Tablas_Consulta(new TablasE("MEDISYN_TIEMPOENVIOCORREO", "", 34, 0, -1));
            foreach (var oTablasE in oListTablasE)
            {
                if (oTablasE.Estado.Trim() == "A")
                    TiempoIntervalo = (int)oTablasE.Valor;
            }

            oListTablasE = oTablasAD.Sp_Tablas_Consulta(new TablasE("MEDISYN_LOGERRORGUARDAR", "", 50, 0, -1));
            foreach (var oTablasE in oListTablasE)
            {
                if (oTablasE.Estado.Trim() == "A")
                {
                    if (oTablasE.Codigo.Trim() == "A")
                        VariablesGlobales.ActivarLogGuardar = true;
                    else
                        VariablesGlobales.ActivarLogGuardar = false;
                }
            }

            oListTablasE = oTablasAD.Sp_Tablas_Consulta(new TablasE("MEDISYN_PERFILNAMECORREO", "", 34, 0, -1));
            foreach (var oTablasE in oListTablasE)
            {
                if (oTablasE.Estado.Trim() == "A")
                {
                    PerfilNameCorreo = oTablasE.Nombre.Trim();
                    break;
                }
            }
        }

        public void GuardarMensajeNotepad(string pMensaje, string pMetodo)
        {
            string pathDirectory = @"c:\Log\";
            string NameFileLog = "Log Servicio Envio Correo.txt";
            string pathLog = pathDirectory + NameFileLog;

            if (Directory.Exists(pathDirectory) == false)
                Directory.CreateDirectory(pathDirectory);

            TextWriter xFile = new StreamWriter(pathLog, true);
            xFile.WriteLine("FECHA Y HORA: " + DateTime.Now.ToString());
            xFile.WriteLine("MENSAJE: " + pMensaje);
            xFile.WriteLine("METODO: " + pMetodo + "\n");
            xFile.Close();
        }

        private string MailBody(string pMailBody)
        {
            pMailBody = pMailBody.Replace("horas en www.csf.cl", "su cita en <strong>www.clinicasanfelipe.com</strong>");
            pMailBody = pMailBody.Replace("www.csf.cl", "<strong>www.clinicasanfelipe.com</strong><br /><br /><img src=\"http://200.41.84.84/WebReserva/imagenes/logoclinica.png\"/>");
            pMailBody = pMailBody.Replace("<font face=\"" + "Arial" + "\" size=\"2\">", "<font face='Arial size='2' style='font-family: Arial, Verdana; font-size: 12px; color:#134b8d;'>");
            pMailBody = pMailBody.Replace("<b>", "<b style='color:#8dc73f'>");
            pMailBody = pMailBody.Replace("color=\"#cccccc\"", "color=\"#999999\"");

            return pMailBody;
        }

        public void ServicioEnvioCorreoPaciente()
        {
            string[] msj = new[] { "Se reinicio el Servicio por problemas. <br >Nro de Reinicio: " };

            try
            {

                GenEnvioMailAD oGenEnvioMailLN = new GenEnvioMailAD();
                GenEnvioMailE oGenEnvioMailE = new GenEnvioMailE();
                List<GenEnvioMailE> oListGenEnvioMailE = new List<GenEnvioMailE>();

                string xTo = getCorreoEnvio(CorreoLista.Medisyn_AgendaWebPaciente, CorreoTipo.CorreoTo); // "mgonzales@clinicasanfelipe.com"
                string xCC = getCorreoEnvio(CorreoLista.Medisyn_AgendaWebPaciente, CorreoTipo.CorreoCC); // "jcaicedos@clinicasanfelipe.com; jkai_91@hotmail.com" 
                string xCCo = getCorreoEnvio(CorreoLista.Medisyn_AgendaWebPaciente, CorreoTipo.CorreoCCo);

                IdMail = CargarIdMailMedisyn();

                // IdMail = 182187 'Ejemplo de Demo, tiene anulacion de reservas, cambiar clave y reserva de citas.
                oListGenEnvioMailE = oGenEnvioMailLN.ConsultarEnvioMail(ref IdMail);

                for (int i = 0; i <= oListGenEnvioMailE.Count - 1; i++)
                {
                    oGenEnvioMailE = oListGenEnvioMailE[i];

                    oSisCorreoE.PerfilName = PerfilNameCorreo;
                    oSisCorreoE.Asunto = oGenEnvioMailE.MailSubjet;
                    oSisCorreoE.Cuerpo = MailBody(oGenEnvioMailE.MailBody);

                    if (oSisCorreoE.Asunto == "Su reserva en Clínica San Felipe")
                    {
                        oSisCorreoE.Cuerpo = HeaderHtml("Detalle de la Reserva de su Cita"); // Header - HTML
                        oSisCorreoE.Cuerpo = oSisCorreoE.Cuerpo + BodyCorreoReservaCita(oGenEnvioMailE.MailBody); // Body - HTML
                    }
                    else if (oSisCorreoE.Asunto == "Su anulación en Clínica San Felipe")
                    {
                        oSisCorreoE.Cuerpo = HeaderHtml("Detalle de la Anulación de su Cita"); // Header - HTML
                        oSisCorreoE.Cuerpo = oSisCorreoE.Cuerpo + BodyCorreoAnulacionCita(oGenEnvioMailE.MailBody); // Body - HTML
                    }
                    else if (oSisCorreoE.Asunto == "Recuperación de clave")
                    {
                        oSisCorreoE.Cuerpo = HeaderHtml("Recuperación de Clave"); // Header - HTML
                        oSisCorreoE.Cuerpo = oSisCorreoE.Cuerpo + BodyCorreoRecuperacionClave(oGenEnvioMailE.MailBody); // Body - HTML
                        xCC = "";
                        xCCo = "";
                    }
                    else if (oSisCorreoE.Asunto == "Registro de Usuario")
                    {
                        oSisCorreoE.Cuerpo = HeaderHtml("Código de Validación de Datos"); // Header - HTML
                        oSisCorreoE.Cuerpo = oSisCorreoE.Cuerpo + BodyCorreoValidacionOTP(oGenEnvioMailE.MailBody); // Body - HTML
                    }
                    else
                    {
                        oSisCorreoE.Cuerpo = HeaderHtml(oSisCorreoE.Asunto); // Header - HTML
                        oSisCorreoE.Cuerpo = oSisCorreoE.Cuerpo + BodyCorreoGenerico(oGenEnvioMailE.MailBody); // Body - HTML
                    }

                    oSisCorreoE.Cuerpo = oSisCorreoE.Cuerpo + FooterHtml(); // Footer - HTML
                    if (VariablesGlobales.CnnClinica.IndexOf(".42.") >= 0)
                    {
                        oSisCorreoE.EnviarA = (xTo.Trim() == "" ? oGenEnvioMailE.MailTo : xTo);
                        oSisCorreoE.CopiarA = ""; // xCC
                        oSisCorreoE.Copiarh = "jcaicedos@clinicasanfelipe.com"; // xCco
                        oSisCorreoE.PerfilName = ""; // "PosMaster"
                    }
                    else
                    {
                        oSisCorreoE.EnviarA = (xTo.Trim() == "" ? oGenEnvioMailE.MailTo : xTo);
                        oSisCorreoE.CopiarA = xCC;
                        oSisCorreoE.Copiarh = xCCo;
                    }

                    IdMail = Convert.ToInt32(oGenEnvioMailE.IdMail);

                    try
                    {
                        oSisCorreoAD.Ut_EnviarCorreov3(oSisCorreoE);
                        if (oSisCorreoE.Mailid != 0)
                            oTablasAD.Sp_Tablas_Update(new TablasE("MEDISYN_IDMAILORACLE", "01", oGenEnvioMailE.IdMail, "valor"));
                        else
                            VariablesGlobales.Guardar_Error_BaseDatos("Id Mail Medisyn: " + oGenEnvioMailE.IdMail + '\r' + oSisCorreoE.Asunto + '\r' + oSisCorreoE.EnviarA + '\r' + oSisCorreoE.Cuerpo, "Error al Enviar Correo");
                    }
                    catch (Exception ex)
                    {
                        // Se realiza el conteo de cuantas veces se esta reiniciando el servicio
                        ConteoReinicio += 1;
                        VariablesGlobales.Guardar_Error_BaseDatos(ex.Message + "<br>" + msj[0] + ConteoReinicio.ToString(), "ServicioEnvioCorreoPaciente");
                    }
                }

                new TablasAD().Sp_Tablas_Update(new TablasE("MEDISYN_FECHAULTIMAEJECUCION", "01", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), "nombre"));
            }
            catch (Exception ex)
            {
                // Se realiza el conteo de cuantas veces se esta reiniciando el servicio
                ConteoReinicio += 1;
                // msj(0) = msj(0) + ConteoReinicio.ToString()
                VariablesGlobales.Guardar_Error_BaseDatos(ex.ToString() + "<br/>" + ex.Message + "<br>" + msj[0] + ConteoReinicio.ToString(), "ServicioEnvioCorreoPaciente");
            }
        }

        /// <summary>
        ///     ''' Devuelver
        ///     ''' </summary>
        ///     ''' <param name="pTitulo"></param>
        ///     ''' <returns></returns>
        private string HeaderHtml(string pTitulo)
        {
            string xResult = "";

            xResult = @"<div style=""justify-content: center; display: flex;"">
                <div style=""font-family: Arial, Verdana, Calibri; color: #666;margin: 10px;min-width: 440px; max-width:500px; "">
                    <div style=""display: block;background: #2d5f8a;border-radius: 5px;border: 1px solid #EEE;padding: 20px 8px;border-bottom-left-radius: 0;border-bottom-right-radius: 0;color: #ffffff;font-size: 16px;text-align: center;vertical-align: middle;font-weight: 600;"" class='Cabecera'>
                        " + pTitulo + "</div>";

            return xResult;
        }

        /// <summary>
        ///     ''' Devuelve el footer del contenido del correo
        ///     ''' </summary>
        ///     ''' <returns></returns>
        private string FooterHtml()
        {
            string xResult = "";

            xResult = @"   <div style=""font-size: 12px;font-weight: 400;border: 1px solid #DADADA;border-radius: 3px;padding: 15px 0px;background: #F7F7F7;color: #2d5f8a;border-top-left-radius: 0;border-top-right-radius: 0;position: relative;border-top-width: 0px;"" class='PiePagina'>
                            <div style=""text-align: center;"" class='Sub2'>
                                <span>""Esto es un correo autogenerado, por favor no responder"".</span>
                            </div>
                            <br/>
                            <div style=""text-align:center;"">
                                <img alt='cabecera' src='https://www.clinicasanfelipe.com/sites/default/files/logo-clinicasanfelipe.png' style='width: 100px;' />
                            </div>
                        </div>
                    </div>
                </div>";

            return xResult;
        }

        /// <summary>
        ///     ''' Devuelve el body del contenido html de la reserva de la cita.
        ///     ''' </summary>
        ///     ''' <param name="pCuerpoCorreo"></param>
        ///     ''' <returns></returns>
        private string BodyCorreoReservaCita(string pCuerpoCorreo)
        {
            XmlDocument xml = new XmlDocument();
            string xBodyHtml = "";
            xml.LoadXml(pCuerpoCorreo);
            DataTable dt = Utilities.XmlHelp.DevolverTabla_XML(xml, "table", "tr", "td", "td");

            xBodyHtml = "<div style=\"background: #FDFDFD;padding: 20px 20px 30px 20px;border: 1px solid #EEE;border-bottom: 0px;border-top: 0px;font-size: 14px;color: #989797;\">" + '\r' + "<table style=\"width: 100%;color: #666;font-size: 14px;border-spacing: 0px;border-radius: 3px;padding: 5px;font-family: Arial, Verdana;color: #666666;\">" + '\r';

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                dt.Rows[i][0] = dt.Rows[i][0].ToString().Replace("+", "");
                dt.Rows[i][0] = dt.Rows[i][0].ToString().Replace("Correlativo Reserva:", "Correlativo Cita:");
                dt.Rows[i][0] = dt.Rows[i][0].ToString().Replace("Hora Reserva:", "Hora Cita:");
                dt.Rows[i][0] = dt.Rows[i][0].ToString().Replace("Fecha Reserva:", "Fecha Cita:");
                dt.Rows[i][0] = dt.Rows[i][0].ToString().Replace("Nombre Profesional:", "Nombre de Médico:");

                switch (dt.Rows[i][0].ToString())
                {
                    case "Código Presentación:":
                    case "Sucursal:":
                        {
                            break;
                        }

                    case "Fecha Cita:":
                        {
                            string FechaCita = Convert.ToDateTime(dt.Rows[i][1].ToString()).ToString(@"dddd dd \de MMMM \del yyyy");
                            FechaCita = FechaCita.Substring(0, 1).ToUpper() + FechaCita.Substring(1).ToLower();

                            System.Globalization.CultureInfo FechaCitaEspanol = new System.Globalization.CultureInfo("es-Es");
                            string FechaCitay = Convert.ToDateTime(dt.Rows[i][1].ToString(), FechaCitaEspanol).ToString(@"dddd dd \de MMMM \del yyyy"); // 24/07/2020

                            xBodyHtml = xBodyHtml + "<tr>" + "<th style=\"text-align: left;color: #2d5f8a;font-weight: 500;\">" + dt.Rows[i][0].ToString + "</th><td style=\"border: 0px;border-bottom: 1px;border-style: solid;border-color: #8dc640;padding: 8px 0px 8px 8px;\">" + FechaCita + "</td>" + "</tr>" + '\r';
                            break;
                        }

                    default:
                        {
                            xBodyHtml = xBodyHtml + "<tr>" + "<th style=\"text-align: left;color: #2d5f8a;font-weight: 500;\">" + dt.Rows[i][0].ToString + "</th><td style=\"border: 0px;border-bottom: 1px;border-style: solid;border-color: #8dc640;padding: 8px 0px 8px 8px;\">" + dt.Rows[i][1] + "</td>" + "</tr>" + '\r';
                            break;
                        }
                }
            }

            List<Ent.Oracle.MedisynE.ReservasE.AmReservaE> oList = new List<Ent.Oracle.MedisynE.ReservasE.AmReservaE>();
            oList = new Dat.Oracle.MedisynAD.ReservasAD.AmReservaAD().ConsultarReservaPacienteId(Convert.ToString(dt.Rows[0][1]));

            List<Ent.Sql.ClinicaE.MedisynE.MdsynVideoLlamadaE> oList2 = new List<Ent.Sql.ClinicaE.MedisynE.MdsynVideoLlamadaE>();
            oList2 = new MdsynVideoLlamadaAD().Sp_MdsynVideoLlamada_Consulta(new Ent.Sql.ClinicaE.MedisynE.MdsynVideoLlamadaE(0, System.Convert.ToInt32(dt.Rows[0][1].ToString()), "", "", 1));
            if (oList2.Count != 0)
            {
                if (oList2[0].FlgTeleConsulta == "S")
                    oList[0].DescUnidad = oList2[0].DscTeleConsulta;
            }

            if ((oList.Count >= 1))
            {
                xBodyHtml = xBodyHtml + "<tr>" + "<th style=\"text-align: left;color: #2d5f8a;font-weight: 500;\">Sede:</th>" + "<td style=\"border: 0px;border-bottom: 1px;border-style: solid;border-color: #8dc640;padding: 8px 0px 8px 8px;\">" + oList[0].DescUnidad.Replace("JESUS MAR.", "JESUS MARIA") + "</td>" + "</tr>" + '\r';

                if (oList[0].BoxReserva != "0")
                    xBodyHtml = xBodyHtml + "<tr>" + "<th style=\"text-align: left;color: #2d5f8a;font-weight: 500;\">Piso:</th>" + "<td style=\"border: 0px;border-bottom: 1px;border-style: solid;border-color: #8dc640;padding: 8px 0px 8px 8px;\">" + oList[0].BoxReserva.Substring(0, 1) + "</td>" + "</tr>" + '\r' + "<tr>" + "<th style=\"text-align: left;color: #2d5f8a;font-weight: 500;\">Consultorio:</th>" + "<td style=\"border: 0px;border-bottom: 1px;border-style: solid;border-color: #8dc640;padding: 8px 0px 8px 8px;\">" + oList[0].BoxReserva + "</td>" + "</tr>" + '\r';
            }

            if (oList2.Count != 0)
            {
                if (oList2[0].FlgTeleConsulta != "S")
                    xBodyHtml = xBodyHtml + @"<tr>
	                    <th colspan='2' style='text-align:left;color: #2d5f8a;font-weight:500;font-family:verdana,arial;'>
                            <br><br>
                            <table style='border: 1px dotted #8dc640; border-radius: 5px; padding: 0px 10px 0px 10px; text-align: justify; background: #FFF; font-size: 13px; color: #2d5f8a;'>
                                <tr>
                                    <th style='font-weight: 600; text-decoration: solid; text-align: center; text-decoration-line: underline;'><br/>Importante:<br/><br/></th>
                                </tr>
                                <tr>
                                    <td>                                        
                                        Para ingresar deberá usar doble mascarilla obligatoriamente.<br/>
                                        Menores de edad o personas dependientes podrán ingresar con un (1) acompañante y ambos deberán portar los elementos de bioseguridad.
                                        <br>
                                        <br/>
                                    </td>
                                </tr>
                            </table>
                        </th>
                    </tr>" + '\r';
            }

            // xBodyHtml =
            // xBodyHtml +
            // "<tr>" +
            // "   <td/><strong>" + "Encuentranos en la Play y App Store" + "</strong></td>" +
            // "</tr>" + Chr(13)
            // "<td colspan=""2"" style=""border: 0px; font-weight: 900;"">" + "<br/>Tener en cuenta que la cita es por Teleconsulta tiene un plazo de dos horas para realizar el pago a traves de nuestra App de Citas." +

            xBodyHtml = xBodyHtml + "</table>" + '\r' + "</div>";

            return xBodyHtml;
        }

        /// <summary>
        ///     ''' Se arma el cuerpo del correo de la anulación, damos formato al contenido
        ///     ''' </summary>
        ///     ''' <param name="pCuerpoCorreo"></param>
        ///     ''' <returns></returns>
        private string BodyCorreoAnulacionCita(string pCuerpoCorreo)
        {
            XmlDocument xml = new XmlDocument();
            string xBodyHtml = "";
            xml.LoadXml(pCuerpoCorreo);
            DataTable dt = Utilities.XmlHelp.DevolverTabla_XML(xml, "table", "tr", "td", "td");

            xBodyHtml = "<div style=\"background: #FDFDFD;padding: 20px 20px 30px 20px;border: 1px solid #EEE;border-bottom: 0px;border-top: 0px;font-size: 14px;color: #989797;\" class='Body'>" + '\r' + "<table style=\"width: 100%;color: #666;font-size: 14px;border-spacing: 0px;border-radius: 3px;padding: 5px;font-family: Arial, Verdana;color: #666666;\">" + '\r';

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                dt.Rows[i][0] = dt.Rows[i][0].ToString().Replace("+", " ");
                dt.Rows[i][0] = dt.Rows[i][0].ToString().Replace("Correlativo Reserva:", "Correlativo Cita:");
                dt.Rows[i][0] = dt.Rows[i][0].ToString().Replace("Hora Reserva:", "Hora Cita:");
                dt.Rows[i][0] = dt.Rows[i][0].ToString().Replace("Fecha Reserva:", "Fecha Cita:");
                dt.Rows[i][0] = dt.Rows[i][0].ToString().Replace("Nombre Profesional:", "Nombre de Médico:");
                dt.Rows[i][0] = dt.Rows[i][0].ToString().Replace("Sucursal:", "Sede:");

                switch (dt.Rows[i][0].ToString())
                {
                    case "Correlativo Cita:":
                        {
                            break;
                        }

                    case "Código Presentación:" // No hará nada
           :
                        {
                            break;
                        }

                    case "Fecha Cita:":
                        {
                            string FechaCita = Convert.ToDateTime(dt.Rows[i][1]).ToString(@"dddd dd \de MMMM \del yyyy");
                            FechaCita = FechaCita.Substring(0, 1).ToUpper() + FechaCita.Substring(1).ToLower();
                            xBodyHtml = xBodyHtml + "<tr>" + "<th style=\"text-align: left;color: #2d5f8a;font-weight: 500;\">" + dt.Rows[i][0].ToString() + "</th><td style=\"border: 0px;border-bottom: 1px;border-style: solid;border-color: #8dc640;padding: 8px 0px 8px 8px;\">" + FechaCita + "</td>" + "</tr>" + '\r';
                            break;
                        }

                    case "Sede:":
                        {
                            xBodyHtml = xBodyHtml + "<tr>" + "<th style=\"text-align: left;color: #2d5f8a;font-weight: 500;\">" + dt.Rows[i][0].ToString() + "</th><td style=\"border: 0px;border-bottom: 1px;border-style: solid;border-color: #8dc640;padding: 8px 0px 8px 8px;\">" + dt.Rows[i][1].ToString().Replace("JESUS MAR.", "JESUS MARIA") + "</td>" + "</tr>" + '\r';
                            break;
                        }

                    default:
                        {
                            xBodyHtml = xBodyHtml + "<tr>" + "<th style=\"text-align: left;color: #2d5f8a;font-weight: 500;\">" + dt.Rows[i][0].ToString() + "</th><td style=\"border: 0px;border-bottom: 1px;border-style: solid;border-color: #8dc640;padding: 8px 0px 8px 8px;\">" + dt.Rows[i][1].ToString() + "</td>" + "</tr>" + '\r';
                            break;
                        }
                }
            }

            xBodyHtml = xBodyHtml + "</table>" + '\r' + "</div>";

            return xBodyHtml;
        }

        private string BodyCorreoRecuperacionClave(string pCuerpoCorreo)
        {
            string xResult = "";
            xResult = "<div style=\"background: #FDFDFD;padding: 20px 20px 30px 20px;border: 1px solid #EEE;border-bottom: 0px;border-top: 0px;font-size: 14px;color: #2d5f8a;\" class='Body'>" + '\r' + "<br/>" + pCuerpoCorreo + '\r' + "</div>";
            return xResult;
        }

        private string BodyCorreoValidacionOTP(string pCuerpoCorreo)
        {
            string xResult = "";
            xResult = "<div style=\"background: #FDFDFD;padding: 20px 20px 30px 20px;border: 1px solid #EEE;border-bottom: 0px;border-top: 0px;font-size: 14px;color: #2d5f8a;\" class='Body'>" + '\r' + "<br/>" + pCuerpoCorreo + '\r' + "</div>";
            return xResult;
        }

        private string BodyCorreoGenerico(string pCuerpoCorreo)
        {
            string xResult = "";
            xResult = "<div style=\"background: #FDFDFD;padding: 20px 20px 30px 20px;border: 1px solid #EEE;border-bottom: 0px;border-top: 0px;font-size: 14px;color: #2d5f8a;\" class='Body'>" + '\r' + "<br/>" + pCuerpoCorreo + '\r' + "</div>";
            return xResult;
        }
    }
}