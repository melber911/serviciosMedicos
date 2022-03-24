using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Bus.Utilities;
//using Bus.Utilities.ConnectionsString;
using System.Configuration;

namespace Bus.AgendaClinica
{
    public static class VariablesGlobales
    {
        public static string gAsegParticular = "0001";
        public const string gAsegPacifico = "0025";
        public const string gAsegPacificoVida = "0257";
        public const string gAsegPacificoEps = "0121";
        public const string gAsegRimac = "0013";
        public const string gAsegRimacEps = "0111";
        public const string gAsegNovasalud = "0109";
        public const string gAsegPositiva = "0053";
        public const string gAsegGenerali = "0017";
        public const string gAsegFenix = "0035";
        public const string gAsegWiese = "0077";
        public const string gAsegMapfreEps = "0205";
        public const string gAsegMapfreSeguros = "0028";
        public const string gAsegColsanitas = "0207";
        public const string gAsegFeban = "0237";
        public const string gAsegCardif = "0235";

        public static string CodTerminal { get; set; } = "000";

        public static System.ServiceModel.EndpointAddress? EndPoint;
        public static System.ServiceModel.BasicHttpBinding? BindingNormal;
        public static System.ServiceModel.BasicHttpsBinding? BindingSecure;
        public static System.ServiceModel.Channels.Binding? Binding;

        public static System.ServiceModel.BasicHttpBinding? BindingTci;

        public static bool ActivarLogGuardar { get; set; }

        public static string HorarioRestringidoPresencial { get; set; } = "";
        public static string HorarioRestringidoVirtual { get; set; } = "";
        public static string MsjRestringidoPresencial { get; set; } = "";
        public static string MsjRestringidoVirtual { get; set; } = "";

        private static string _Synapsis_ApiKey="";
        /// <summary>
        ///     ''' Llave primaria enviada por Synapsis.
        ///     ''' </summary>
        ///     ''' <returns></returns>
        public static string Synapsis_ApiKey
        {
            get
            {
                return _Synapsis_ApiKey;
            }
        }

        private static string _Synapsis_SignatureKey="";
        /// <summary>
        ///     ''' Llave de firma enviada por synapsis
        ///     ''' </summary>
        ///     ''' <returns></returns>
        public static string Synapsis_SignatureKey
        {
            get
            {
                return _Synapsis_SignatureKey;
            }
        }

        private static string _Synapsis_Ws_Url="";
        /// <summary>
        ///     ''' Url para conectarse al Api de Synapsis
        ///     ''' </summary>
        ///     ''' <returns></returns>
        public static string Synapsis_Ws_Url
        {
            get
            {
                return _Synapsis_Ws_Url;
            }
        }

        private static string _RutaWsAgendaCitasMedisyn="";
        public static string RutaWsAgendaCitasMedisyn
        {
            get
            {
                return _RutaWsAgendaCitasMedisyn;
            }
        }

        private static string _CnnClinica="";
        /// <summary>
        ///     ''' Devuelve la cadena de conexión para conectarse a la Base de Datos de Clinica.
        ///     ''' </summary>
        ///     ''' <returns></returns>
        public static string CnnClinica
        {
            get
            {
                return _CnnClinica;
            }
        }

        private static string _CnnLogistica = "";
        /// <summary>
        ///     ''' Devuelve la cadena de conexión para conectarse a la Baase de Datos de Logistica
        ///     ''' </summary>
        ///     ''' <returns></returns>
        public static string CnnLogistica
        {
            get
            {
                return _CnnLogistica;
            }
        }

        private static string _CnnMedisynOracle="";
        public static string CnnMedisynOracle
        {
            get
            {
                return _CnnMedisynOracle;
            }
        }

        private static double _IGV;
        /// <summary>
        ///     ''' IGV, se obtiene de la Base de Datos
        ///     ''' </summary>
        ///     ''' <returns></returns>
        public static double IGV
        {
            get
            {
                return _IGV;
            }
        }

        private static string _CentroCosto = "";

        public static string CentroCosto
        {
            get
            {
                return _CentroCosto;
            }
        }

        private static string _CodUser = "";
        public static string CodUser
        {
            get
            {
                return _CodUser;
            }
        }

        /// <summary>
        ///     ''' Lista Numerada con las Bases de Datos disponibles a conectar en SQL Server.
        ///     ''' </summary>
        public enum ListDataBase
        {
            clinica = 1,
            logistica = 2,
            seguridad = 3,
            dw_clinica = 4,
            medisyn = 11
        }

        /// <summary>
        ///     ''' Cargar e iniciar la cadena de conection sobre la Base de Datos a la cual se va a trabajar.
        ///     ''' </summary>
        ///     ''' <param name="pNameConectionString">Nombre de la Cadena de conexión del App.Config o Web.Config.</param>
        ///     ''' <param name="pDataBaseServer">"Base de Datos sobre la cual se trabajara."</param>
        public static void LoadConectionString(string pNameConectionString, ListDataBase pDataBaseServer)
        {
            string StringConection = ConfigurationManager.ConnectionStrings[pNameConectionString].ConnectionString;

            if (StringConection.ToLower().IndexOf("data source") == -1)
                StringConection = Criptography.DecryptConectionString(StringConection);

            ConnectionsString.Server = ConnectionsString.getDataString("source", StringConection);
            ConnectionsString.DataBase = ConnectionsString.getDataString("catalog", StringConection);
            ConnectionsString.UserServer = ConnectionsString.getDataString("id", StringConection);
            ConnectionsString.PasswordServer = ConnectionsString.getDataString("password", StringConection);

            switch (pDataBaseServer)
            {
                case ListDataBase.clinica:
                    {
                        _CnnClinica = StringConection;
                        Dat.Sql.VariablesGlobales.CnnClinica = _CnnClinica;
                        break;
                    }

                case ListDataBase.logistica:
                    {
                        _CnnLogistica = StringConection;
                        Dat.Sql.VariablesGlobales.CnnLogistica = _CnnLogistica;
                        break;
                    }

                case ListDataBase.medisyn:
                    {
                        _CnnMedisynOracle = StringConection;
                        Dat.Oracle.VariablesGlobales.CnnMedisyn = _CnnMedisynOracle;                        
                        break;
                    }
            }
        }

        /// <summary>
        ///     ''' Cargar los datos iniciales del Negocio Agenda Clinica
        ///     ''' </summary>
        public static void LoadInitialData()
        {
            Dat.Sql.ClinicaAD.OtrosAD.TablasAD objTablasAD = new Dat.Sql.ClinicaAD.OtrosAD.TablasAD();
            List<Ent.Sql.ClinicaE.OtrosE.TablasE> oListTablasE = new List<Ent.Sql.ClinicaE.OtrosE.TablasE>();

            oListTablasE = objTablasAD.Sp_Tablas_Consulta(new Ent.Sql.ClinicaE.OtrosE.TablasE("IMPUESTOS", "01", 50, 1, -1));
            if (oListTablasE.Count > 0)
                _IGV = oListTablasE[0].Valor; // Obtener IGV

            oListTablasE = new List<Ent.Sql.ClinicaE.OtrosE.TablasE>();
            oListTablasE = objTablasAD.Sp_Tablas_Consulta(new Ent.Sql.ClinicaE.OtrosE.TablasE("MEDISYN_CENTROCOSTO_APP", "01", 50, 1, -1));
            if (oListTablasE.Count > 0)
                _CentroCosto = oListTablasE[0].Nombre.Trim(); // Obtener Centro de Costo

            oListTablasE = new List<Ent.Sql.ClinicaE.OtrosE.TablasE>();
            oListTablasE = objTablasAD.Sp_Tablas_Consulta(new Ent.Sql.ClinicaE.OtrosE.TablasE("MEDISYN_USUARIO_GLOBAL", "", 50, 1, -1));
            if (oListTablasE.Count > 0)
                _CodUser = oListTablasE[0].Codigo.Trim(); // Obtener Usuario Global

            oListTablasE = new List<Ent.Sql.ClinicaE.OtrosE.TablasE>();
            oListTablasE = objTablasAD.Sp_Tablas_Consulta(new Ent.Sql.ClinicaE.OtrosE.TablasE("MEDISYN_CODTERMINAL_PAGOS", "", 50, 0, -1));
            if (oListTablasE.Count > 0)
                CodTerminal = oListTablasE[0].Nombre.Trim(); // Obtener el COD. TERMINAL DEL PAGO

            // oListTablasE = New List(Of Ent.Sql.ClinicaE.OtrosE.TablasE)()
            // oListTablasE = objTablasAD.Sp_Tablas_Consulta(New Ent.Sql.ClinicaE.OtrosE.TablasE("RCE_CODTERMINAL_PAGOS", "", 50, 0, -1))
            // If oListTablasE.Count > 0 Then CodTerminal = oListTablasE(0).Nombre.Trim 'Obtener el COD. TERMINAL DEL PAGO

            oListTablasE = new List<Ent.Sql.ClinicaE.OtrosE.TablasE>();
            oListTablasE = objTablasAD.Sp_Tablas_Consulta(new Ent.Sql.ClinicaE.OtrosE.TablasE("MEDISYN_WS_SITEDS", "", 0, 0, 19));
            if (oListTablasE.Count > 0)
                Clinica.SitedsWs.RutaWS_Siteds = oListTablasE[0].Nombre.Trim(); // Ruta del Ws de Siteds
        }

        public static void LoadInitial_WS_AgendaCitas()
        {
            Dat.Sql.ClinicaAD.OtrosAD.TablasAD objTablasAD = new Dat.Sql.ClinicaAD.OtrosAD.TablasAD();
            List<Ent.Sql.ClinicaE.OtrosE.TablasE> oListTablasE = new List<Ent.Sql.ClinicaE.OtrosE.TablasE>();

            oListTablasE = objTablasAD.Sp_Tablas_Consulta(new Ent.Sql.ClinicaE.OtrosE.TablasE("MEDISYN_WS_AGENDA_CITAS", "", 0, 0, 19));
            if (oListTablasE.Count > 0)
                _RutaWsAgendaCitasMedisyn = oListTablasE[0].Nombre; // OBTENER RUTA DEL WEB SERVICES DE LOS SERVICIOS 

            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
        }

        public static void LoadInitial_WS_Solo_AgendaCitas()
        {
            Dat.Sql.ClinicaAD.MedisynAD.MdsynTablasAD objMdsynTablasAD = new Dat.Sql.ClinicaAD.MedisynAD.MdsynTablasAD();
            List<Ent.Sql.ClinicaE.MedisynE.MdsynTablasE> oListMdsynTablasE = new List<Ent.Sql.ClinicaE.MedisynE.MdsynTablasE>();

            oListMdsynTablasE = objMdsynTablasAD.Sp_MdsynTablas_Consulta(new Ent.Sql.ClinicaE.MedisynE.MdsynTablasE("MEDISYN_RESTRINGIR_HOR_PRESENC", "", "A", "", 1));
            if (oListMdsynTablasE.Count > 0)
                HorarioRestringidoPresencial = oListMdsynTablasE[0].Nombre; // OBTENER HORARIO PARA RESTRINGIR CITAS PRESENCIAL

            oListMdsynTablasE = objMdsynTablasAD.Sp_MdsynTablas_Consulta(new Ent.Sql.ClinicaE.MedisynE.MdsynTablasE("MEDISYN_RESTRINGIR_HOR_VIRTUAL", "", "A", "", 1));
            if (oListMdsynTablasE.Count > 0)
                HorarioRestringidoVirtual = oListMdsynTablasE[0].Nombre; // OBTENER HORARIO PARA RESTRINGIR CITAS VIRTUALES

            oListMdsynTablasE = objMdsynTablasAD.Sp_MdsynTablas_Consulta(new Ent.Sql.ClinicaE.MedisynE.MdsynTablasE("MEDISYN_RESTRINGIR_MSJ_PRESENC", "", "A", "", 1));
            if (oListMdsynTablasE.Count > 0)
                MsjRestringidoPresencial = oListMdsynTablasE[0].Nombre; // OBTENER HORARIO PARA RESTRINGIR CITAS PRESENCIAL

            oListMdsynTablasE = objMdsynTablasAD.Sp_MdsynTablas_Consulta(new Ent.Sql.ClinicaE.MedisynE.MdsynTablasE("MEDISYN_RESTRINGIR_MSJ_VIRTUAL", "", "A", "", 1));
            if (oListMdsynTablasE.Count > 0)
                MsjRestringidoVirtual = oListMdsynTablasE[0].Nombre; // OBTENER HORARIO PARA RESTRINGIR CITAS VIRTUALES
        }

        /// <summary>
        ///     ''' Cargar los datos iniciales que se necesita para consumir los servicios de Synapsis.
        ///     ''' </summary>
        public static void Load_Initial_Synapsis()
        {
            Dat.Sql.ClinicaAD.OtrosAD.TablasAD objTablasAD = new Dat.Sql.ClinicaAD.OtrosAD.TablasAD();
            List<Ent.Sql.ClinicaE.OtrosE.TablasE> oListTablasE = new List<Ent.Sql.ClinicaE.OtrosE.TablasE>();

            oListTablasE = objTablasAD.Sp_Tablas_Consulta(new Ent.Sql.ClinicaE.OtrosE.TablasE("MEDISYN_SYNAPSIS_APIKEY", "01", 50, 1, -1));
            if (oListTablasE.Count > 0)
                _Synapsis_ApiKey = oListTablasE[0].Nombre.Trim();

            oListTablasE = objTablasAD.Sp_Tablas_Consulta(new Ent.Sql.ClinicaE.OtrosE.TablasE("MEDISYN_SYNAPSIS_SECRETKEY", "01", 50, 1, -1));
            if (oListTablasE.Count > 0)
                _Synapsis_SignatureKey = oListTablasE[0].Nombre.Trim();

            oListTablasE = objTablasAD.Sp_Tablas_Consulta(new Ent.Sql.ClinicaE.OtrosE.TablasE("MEDISYN_SYNAPSIS_URL", "01", 50, 1, -1));
            if (oListTablasE.Count > 0)
                _Synapsis_Ws_Url = oListTablasE[0].Nombre.Trim();
        }

        /// <summary>
        ///     ''' Abrimos la configuración del Web Service apuntando a la URL
        ///     ''' </summary>
        ///     ''' <param name="pUrlWS">Url del Web Service al cual se desea apuntar.</param>
        public static void OpenConfigWebServices(string pUrlWS)
        {
            EndPoint = new System.ServiceModel.EndpointAddress(pUrlWS);

            if (EndPoint.Uri.Scheme == "https")
            {
                BindingSecure = new System.ServiceModel.BasicHttpsBinding();
                // Tamaño maximo para envio de información dado en Byte. Ejemplo: 2097152 Byte -> 2048 KB -> 2 MB
                BindingSecure.MaxReceivedMessageSize = 2097152;
                BindingSecure.MaxBufferPoolSize = 2097152;
                BindingSecure.MaxBufferSize = 2097152;

                Binding = BindingSecure;
            }
            else
            {
                BindingNormal = new System.ServiceModel.BasicHttpBinding();
                // Tamaño maximo para envio de información dado en Byte. Ejemplo: 2097152 Byte -> 2048 KB -> 2 MB
                BindingNormal.MaxReceivedMessageSize = 2097152;
                BindingNormal.MaxBufferPoolSize = 2097152;
                BindingNormal.MaxBufferSize = 2097152;

                Binding = BindingNormal;
            }
        }

        /// <summary>
        ///     ''' Cerramos la conexión con el Web Service
        ///     ''' </summary>
        public static void CloseConfigWebServices()
        {
            BindingNormal = null;
            BindingSecure = null;

            Binding = null;
            EndPoint = null;
        }

        /// <summary>
        ///     ''' Abrimos la configuración del Web Service apuntando a la URL de TCI
        ///     ''' </summary>
        ///     ''' <param name="pUrlWS">Url del Web Service al cual se desea apuntar.</param>
        public static void OpenConfigWebServicesTci(string pUrlWS)
        {
            EndPoint = new System.ServiceModel.EndpointAddress(pUrlWS);

            BindingTci = new System.ServiceModel.BasicHttpBinding();
            // Tamaño maximo para envio de información dado en Byte. Ejemplo: 2097152 Byte -> 2048 KB -> 2 MB
            BindingTci.MaxReceivedMessageSize = 2097152;
            BindingTci.MaxBufferPoolSize = 2097152;
            BindingTci.MaxBufferSize = 2097152;
        }

        /// <summary>
        ///     ''' Cerramos la conexión con el Web Service de TCI
        ///     ''' </summary>
        public static void CloseConfigWebServicesTci()
        {
            BindingTci = null;
            EndPoint = null;
        }

        public static void Guardar_Error_BaseDatos(string pMensaje, string pMetodo)
        {
            if (ActivarLogGuardar == true)
            {
                Dat.Sql.ClinicaAD.MedisynAD.MdsynReservalogErrorAD oMdsynReservalogErrorAD = new Dat.Sql.ClinicaAD.MedisynAD.MdsynReservalogErrorAD();
                pMensaje = pMensaje + "<br/><br/>" + "METODO ERROR: " + pMetodo;
                oMdsynReservalogErrorAD.Sp_MdsynReservalogError_Insert(new Ent.Sql.ClinicaE.MedisynE.MdsynReservalogErrorE(pMensaje, "", ""));   //System.Net.PcName, System.Net.PcIPv4));

                new Clinica.CorreoAgenda().GuardarMensajeNotepad(pMensaje, pMetodo);
            }
        }

        /// <summary>
        ///     ''' Tipo de Pago para la orden del Bot
        ///     ''' </summary>
        public enum ListTipoPagoOrdenBot
        {
            Reserva = 1,
            Farmacia = 2,
            ReprogramarCitas = 3,
            MantenimientoMedicos = 4,
            PantallaCitasReservadas = 5,
            RecuperarContrasenia = 6,
            PreAdmision_EnviarCorreo = 11,
            PreAdmision_SeguimientoDigital = 12
        }
    }
}