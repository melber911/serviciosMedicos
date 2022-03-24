using Dat.Sql.ClinicaAD.OtrosAD;
using Ent.Sql.ClinicaE.RceE;
using Dat.Sql.ClinicaAD.RceAD;
using Ent.Sql.ClinicaE.HospitalE;
using Dat.Sql.ClinicaAD.HospitalAD;
using Ent.Oracle.MedisynE.PacientesE;
using Dat.Oracle.MedisynAD.PacientesAD;
using Ent.Sql.ClinicaE.OtrosE;
using System.Data;
using System.Text.Json;

namespace Bus.AgendaClinica.Clinica
{
    public class AdmisionHospitalariaWs
    {

        private string RutaCorreo = "";

        public class ConsultaHospitalizacionRequest
        {
            public string idAmbulatorio { get; set; } = "";
            public string ApiKey { get; set; } = "";
        }

        public class ConsultaHospitalizacionResponse
        {
            // Public Property oDatosGenerales() As DatosGeneralesResponse

            public string codAtencion { get; set; } = "";
            public string fechaHora { get; set; } = "";
            public string idAmbulatorio { get; set; } = "";
            public string grupoFamiliar { get; set; } = "";
            public string codTipoDocumento { get; set; } = "";
            public string desTipoDocumento { get; set; } = "";
            public string numeroDocumento { get; set; } = "";
            public string fechaNacimiento { get; set; } = "";
            public string nombres { get; set; } = "";
            public string apellidoPaterno { get; set; } = "";
            public string apellidoMaterno { get; set; } = "";
            public string correo { get; set; } = "";
            public string telefono { get; set; } = "";
            public string sexo { get; set; } = "";
            public string codMedico { get; set; } = "";
            public string nomMedico { get; set; } = "";
            public string codEspecialidad { get; set; } = "";
            public string desEspecialidad { get; set; } = "";
            public string nivelAtencion { get; set; } = "";
            public string codEstado { get; set; } = "";
            public string desEstado { get; set; } = "";
            public string ultimoPaso { get; set; } = "";
            public string codFamiliar { get; set; } = "";
            public string desFamiliar { get; set; } = "";


            public class DatosGeneralesResponse
            {
                public string codAtencion { get; set; } = "";
                public string fechaHora { get; set; } = "";
                public string idAmbulatorio { get; set; } = "";
                public string grupoFamiliar { get; set; } = "";
                public string codTipoDocumento { get; set; } = "";
                public string desTipoDocumento { get; set; } = "";
                public string numeroDocumento { get; set; } = "";
                public string fechaNacimiento { get; set; } = "";
                public string nombres { get; set; } = "";
                public string apellidoPaterno { get; set; } = "";
                public string apellidoMaterno { get; set; } = "";
                public string correo { get; set; } = "";
                public string telefono { get; set; } = "";
                public string sexo { get; set; } = "";
                public string codMedico { get; set; } = "";
                public string nomMedico { get; set; } = "";
                public string codEspecialidad { get; set; } = "";
                public string desEspecialidad { get; set; } = "";
                public string nivelAtencion { get; set; } = "";
                public string codEstado { get; set; } = "";
                public string desEstado { get; set; } = "";
                public string ultimoPaso { get; set; } = "";
            }
        }

        public class MedicamentosRiesgoItems
        {
            public int IdeMedicacionDet { get; set; } = 0;

            /// <summary>
            ///         ''' Código es igual a ide_medicacion_items_mae
            ///         ''' </summary>
            ///         ''' <returns></returns>
            public int Codigo { get; set; }
            /// <summary>
            ///         ''' Hace referencia al respuesta del paciente 'S' y 'N'
            ///         ''' </summary>
            ///         ''' <returns></returns>
            public string Indicador { get; set; } = "";

            public string DscItem { get; set; } = "";
            public string DscSubItem { get; set; } = "";


            public MedicamentosRiesgoItems()
            {
            }

            public MedicamentosRiesgoItems(int pIdeMedicacionDet)
            {
                IdeMedicacionDet = pIdeMedicacionDet;
            }

            public MedicamentosRiesgoItems(int pIdeMedicacionDet, int pCodigo, string pIndicador)
            {
                Codigo = pCodigo;
                Indicador = pIndicador;
                IdeMedicacionDet = pIdeMedicacionDet;
            }

            public MedicamentosRiesgoItems(int pIdeMedicacionDet, int pCodigo, string pIndicador, string pDscItem, string pDscSubItem)
            {
                Codigo = pCodigo;
                Indicador = pIndicador;
                IdeMedicacionDet = pIdeMedicacionDet;
                DscItem = pDscItem;
                DscSubItem = pDscSubItem;
            }
        }

        public class MedicamentosResponse
        {
            public int IdeAlergiaMedicamentosDet = 0;
            public string Codigo = "";
            public string Descripcion = "";

            public MedicamentosResponse()
            {
            }

            public MedicamentosResponse(string pCodigo, string pDescripcion)
            {
                Codigo = pCodigo;
                Descripcion = pDescripcion;
            }

            public MedicamentosResponse(string pCodigo, string pDescripcion, int pIdeAlergiaMedicamentosDet)
            {
                Codigo = pCodigo;
                Descripcion = pDescripcion;
                IdeAlergiaMedicamentosDet = pIdeAlergiaMedicamentosDet;
            }
        }

        public class MedicamentosRiesgoItemMaeRequest
        {
            public string ApiKey = "";
            public int Orden;
        }

        public class MedicamentosRiesgoItemMaeResponse
        {
            public int IdeMedicacionItemsMae;
            public string DscItem;
            public string DscSubItem;

            public MedicamentosRiesgoItemMaeResponse()
            {
            }

            public MedicamentosRiesgoItemMaeResponse(int pIdeMedicacionItemsMae, string pDscItem, string pDscSubItem)
            {
                IdeMedicacionItemsMae = pIdeMedicacionItemsMae;
                DscItem = pDscItem;
                DscSubItem = pDscSubItem;
            }
        }

        public class AlergiaConsultaRequest
        {
            public string idAmbulatorio { get; set; }
            public string codAtencion { get; set; }
            public string ApiKey { get; set; }
        }

        public class AlergiaConsultaResponse
        {
            public string indAlergia { get; set; }
            public string hospitalizado { get; set; }
            public string representante { get; set; }
            public string habitacion { get; set; }
            public List<MedicamentosResponse> medicamentos { get; set; }
            public string alimentos { get; set; }
            public string otros { get; set; }

            public List<MedicamentosRiesgoItems> medicamentosRiesgos { get; set; } = new List<MedicamentosRiesgoItems>();

            public int idRegistro { get; set; }
        }


        public class AlergiaMedicamentosRiesgoGrabarRequest
        {
            public string codAtencion { get; set; }
            public string idAmbulatorio { get; set; }

            /// <summary>
            ///         ''' Valor devuelvo 'S' y 'N'
            ///         ''' </summary>
            ///         ''' <returns></returns>
            public string indAlergia { get; set; }
            public string hospitalizado { get; set; }
            public string representante { get; set; }
            public string habitacion { get; set; }
            public List<MedicamentosResponse> medicamentos { get; set; } = new List<MedicamentosResponse>();
            public string alimentos { get; set; }
            public string otros { get; set; }
            public List<MedicamentosRiesgoItems> medicamentosRiesgos { get; set; } = new List<MedicamentosRiesgoItems>();

            public string documentoAlergias { get; set; }
            public string documentoRiesgos { get; set; }

            public string accion { get; set; }
            public int IdRegistro { get; set; }
            public string RespEnvio { get; set; }
            public string ApiKey { get; set; }
        }

        public class AlergiaMedicamentosRiesgoGrabarResponse
        {
            public string codEstado { get; set; }
            public string desEstado { get; set; }

            public AlergiaMedicamentosRiesgoGrabarResponse()
            {
            }

            public AlergiaMedicamentosRiesgoGrabarResponse(string pCodEstado, string pDesEstado)
            {
                codEstado = pCodEstado;
                desEstado = pDesEstado;
            }
        }


        public class TerminosAdmisionGrabarRequest
        {
            public string codAtencion { get; set; }
            public string idAmbulatorio { get; set; }
            /// <summary>
            ///         ''' Respuesta 'S' o 'N'
            ///         ''' </summary>
            ///         ''' <returns></returns>
            public string indTerminosAdmision { get; set; }
            public string documento { get; set; }
            public string DscTexto { get; set; }
            public string DscRpta { get; set; }

            /// <summary>
            ///         ''' 'I' Ingresar - 'A' Actualizar
            ///         ''' </summary>
            ///         ''' <returns></returns>
            public string accion { get; set; }
            public int idRegistro { get; set; }
            public string ResponsableEnvio { get; set; }
            public string ApiKey { get; set; }
        }

        public class TerminosAdmisionGrabarResponse
        {
            public string codEstado { get; set; }
            public string desEstado { get; set; }

            public TerminosAdmisionGrabarResponse()
            {
            }

            public TerminosAdmisionGrabarResponse(string pCodEstado, string pDesEstado)
            {
                codEstado = pCodEstado;
                desEstado = pDesEstado;
            }
        }

        public class TerminosDocumentoAdmisionConsultaRequest
        {
            public string codAtencion { get; set; }
            public string idAmbulatorio { get; set; }
            public string ApiKey { get; set; }
        }

        public class TerminosDocumentoAdmisionConsultaResponse
        {
            public string indTerminosAdmision { get; set; }
            public string idRegistro { get; set; }
        }

        public class AutorizacionContactosPreFacturasGrabarRequest
        {
            public string codAtencion { get; set; }
            public string idAmbulatorio { get; set; }
            public List<AutorizacionContactosPreFacturasGrabarPersonasRequest> personas { get; set; }
            public string documento { get; set; }
            public string accion { get; set; }
            public int idRegistro { get; set; }
            public string ResponsableEnvio { get; set; }
            public string ApiKey { get; set; }
        }

        public class AutorizacionContactosPreFacturasGrabarPersonasRequest
        {
            public int IdRegistroDet { get; set; }
            public string apellidos { get; set; }
            public string nombres { get; set; }
            public string parentesco { get; set; }
            public string dni { get; set; }
            public string correo { get; set; }
            public string telefono { get; set; }
        }

        public class AutorizacionContactosPreFacturasGrabarResponse
        {
            public string codEstado { get; set; }
            public string desEstado { get; set; }

            public AutorizacionContactosPreFacturasGrabarResponse()
            {
            }

            public AutorizacionContactosPreFacturasGrabarResponse(string pCodEstado, string pDesEstado)
            {
                codEstado = pCodEstado;
                desEstado = pDesEstado;
            }
        }

        public class AutorizacionContactosPreFacturaConsultaRequest
        {
            public string codAtencion { get; set; }
            public string idAmbulatorio { get; set; }
            public string ApiKey { get; set; }
        }

        public class AutorizacionContactosPreFacturaConsultaResponse
        {
            public int IdRegistroCab { get; set; }
            public List<AutorizacionContactosPreFacturasPersonasResponse> Persona { get; set; } = new List<AutorizacionContactosPreFacturasPersonasResponse>();
        }

        public class AutorizacionContactosPreFacturasPersonasResponse
        {
            public int IdRegistroDet { get; set; }
            public string apellidos { get; set; }
            public string nombres { get; set; }
            public string dni { get; set; }
            public string correo { get; set; }
            public string telefono { get; set; }
            public string parentesco { get; set; }

            public AutorizacionContactosPreFacturasPersonasResponse()
            {
            }

            public AutorizacionContactosPreFacturasPersonasResponse(int pIdRegistroDet, string pApellidos, string pNombres, string pDni, string pCorreo)
            {
                IdRegistroDet = pIdRegistroDet;
                apellidos = pApellidos;
                nombres = pNombres;
                dni = pDni;
                correo = pCorreo;
            }

            public AutorizacionContactosPreFacturasPersonasResponse(int pIdRegistroDet, string pApellidos, string pNombres, string pDni, string pCorreo, string pTelefono, string pParentesco)
            {
                IdRegistroDet = pIdRegistroDet;
                apellidos = pApellidos;
                nombres = pNombres;
                dni = pDni;
                correo = pCorreo;
                telefono = pTelefono;
                parentesco = pParentesco;
            }
        }

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
            ApiKey? objApiKey = new ApiKey();
            try
            {
                string SecurityApiKey = Utilities.Criptography.DecryptConectionString(ApiKey);

                // Dim x As String = Utilities.Criptography.EncryptConectionString("{""USR"":""CSF"",""PSW"":""P@ssw0rd"",""Tipo"":""PreAdmisionHospitalaria""}")
                // Dim SecurityApiKey2 As String = Utilities.Criptography.DecryptConectionString(x)
                // USR:SOLERA,PSW:s0l3r@_andr01d,TipUser:Android

                try
                {
                    TablasE oTablasE = new TablasE();
                    oTablasE = new TablasAD().Sp_Tablas_ConsultaEntidad(new TablasE("RCE_PAH_WS_APIKEY", ApiKey, 0, 0, 4));
                    if (oTablasE.Nombre.Trim() == ApiKey)
                    {
                        objApiKey = JsonSerializer.Deserialize<ApiKey>(ApiKey);
                        // If objApiKey.USR = "SOLERA" And objApiKey.PSW = "s0l3r@_andr01d" And objApiKey.TipUser = "Android" Then
                        // result = True
                        // End If
                        result = true;
                    }
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

        public List<MedicamentosResponse> MtConsultarDatosMedicamentos(string Buscar)
        {
            DataSet oDataSet = new DataSet();
            List<MedicamentosResponse> oList = new List<MedicamentosResponse>();

            // If fnValidarApiKey(pMedicamentosRiesgoItemMaeRequest.ApiKey) Then
            oDataSet = new OtrosAD().Sp_Genericos_Consulta(Buscar, 0, 0, 2);

            if (oDataSet.Tables.Count >= 1)
            {
                for (var i = 0; i <= oDataSet.Tables[0].Rows.Count - 1; i++)
                {
                    {
                        var withBlock = oDataSet.Tables[0].Rows[i];
                        oList.Add(new MedicamentosResponse((string)withBlock["codgenerico"], ((string)withBlock["nombre"]).Trim()));
                    }
                }
            }
            // End If

            return oList;
        }

        public List<MedicamentosRiesgoItemMaeResponse> MtConsultarMedicacionItemsMae(MedicamentosRiesgoItemMaeRequest pMedicamentosRiesgoItemMaeRequest)
        {
            List<MedicamentosRiesgoItemMaeResponse> oListMedicamentos = new List<MedicamentosRiesgoItemMaeResponse>();

            if (fnValidarApiKey(pMedicamentosRiesgoItemMaeRequest.ApiKey))
            {
                List<RcePahMedicacionItemsMaeE> oList;

                oList = new RcePahMedicacionItemsMaeAD().Sp_RcePahMedicacionItemsMae_Consulta(new RcePahMedicacionItemsMaeE(pMedicamentosRiesgoItemMaeRequest.Orden));
                for (int i = 0; i <= oList.Count - 1; i++)
                {
                    {
                        var withBlock = oList[i];
                        oListMedicamentos.Add(new MedicamentosRiesgoItemMaeResponse(withBlock.IdeMedicacionItemsMae, withBlock.DscItem, withBlock.DscSubItem));
                    }
                }
            }

            return oListMedicamentos;
        }

        public List<ConsultaHospitalizacionResponse> MtConsultarHospitalizacion(ConsultaHospitalizacionRequest pObjConsultaHospitalizacionRequest)
        {
            List<ConsultaHospitalizacionResponse> oList = new List<ConsultaHospitalizacionResponse>();

            // Se agrego para guardar en auditoria los inputs que envian Solera y SoftVan.
            string JsonBody = JsonSerializer.Serialize(pObjConsultaHospitalizacionRequest);
            string SecurityApiKey = Utilities.Criptography.DecryptConectionString(pObjConsultaHospitalizacionRequest.ApiKey);

            ApiKey? objApiKey = JsonSerializer.Deserialize<ApiKey>(SecurityApiKey);
            new RcePahRequestJsonAD().Sp_RcePahRequestJson_Insert(new RcePahRequestJsonE(0, 0, "01", objApiKey.USR, JsonBody));

            if (fnValidarApiKey(pObjConsultaHospitalizacionRequest.ApiKey))
            {
                ConsultaHospitalizacionResponse oConsultaHospitalizacionResponse = new ConsultaHospitalizacionResponse();
                List<TabPacienteE> oLPacE = new List<TabPacienteE>();

                string wIdAmbulatorios = "";
                oLPacE = new TabPacientesAD().ObtenerGrupoFamiliarxIdAmbulatorio(pObjConsultaHospitalizacionRequest.idAmbulatorio);
                for (var i = 0; i <= oLPacE.Count - 1; i++)
                    wIdAmbulatorios = wIdAmbulatorios + oLPacE[i].IdAmbulatorio + ", ";

                DataSet oDS = new DataSet();
                oDS = new HospitalAD().Sp_ConsultarDatosHospitalarios(new HospitalE("", wIdAmbulatorios, "", ""));

                if (oDS.Tables.Count >= 1)
                {
                    for (int i = 0; i <= oDS.Tables[0].Rows.Count - 1; i++)
                    {
                        {
                            var withBlock = oDS.Tables[0].Rows[i];
                            oConsultaHospitalizacionResponse = new ConsultaHospitalizacionResponse();
                            oConsultaHospitalizacionResponse.codAtencion = (string)withBlock["codatencion"];
                            oConsultaHospitalizacionResponse.fechaHora = (string)withBlock["fechainicio"];
                            oConsultaHospitalizacionResponse.idAmbulatorio = (string)withBlock["codpaciente"];

                            oConsultaHospitalizacionResponse.codTipoDocumento = (string)withBlock["tipdocidentidad"];
                            oConsultaHospitalizacionResponse.desTipoDocumento = (string)withBlock["dscTipoDocumento"];
                            oConsultaHospitalizacionResponse.numeroDocumento = (string)withBlock["docidentidad"];
                            oConsultaHospitalizacionResponse.fechaNacimiento = (string)withBlock["fechanacimiento"];
                            oConsultaHospitalizacionResponse.nombres = (string)withBlock["nombre"];
                            oConsultaHospitalizacionResponse.apellidoPaterno = (string)withBlock["appaterno"];
                            oConsultaHospitalizacionResponse.apellidoMaterno = (string)withBlock["apmaterno"];
                            oConsultaHospitalizacionResponse.correo = (string)withBlock["email"];
                            oConsultaHospitalizacionResponse.telefono = (string)withBlock["telefono"];
                            oConsultaHospitalizacionResponse.sexo = (string)withBlock["sexo"];
                            oConsultaHospitalizacionResponse.codMedico = (string)withBlock["codmedico"];
                            oConsultaHospitalizacionResponse.nomMedico = (string)withBlock["nombres"];
                            oConsultaHospitalizacionResponse.codEspecialidad = (string)withBlock["codespecialidad"];
                            oConsultaHospitalizacionResponse.desEspecialidad = (string)withBlock["dscespecialidad"];
                            oConsultaHospitalizacionResponse.nivelAtencion = (string)withBlock["nivelAtencion"];
                            oConsultaHospitalizacionResponse.codEstado = (string)withBlock["codEstado"];
                            oConsultaHospitalizacionResponse.desEstado = (string)withBlock["desEstado"];
                            oConsultaHospitalizacionResponse.ultimoPaso = (string)withBlock["ultimoPaso"];

                            for (int j = 0; j <= oLPacE.Count - 1; j++)
                            {
                                if (oLPacE[j].IdAmbulatorio == oConsultaHospitalizacionResponse.idAmbulatorio)
                                {
                                    oConsultaHospitalizacionResponse.grupoFamiliar = oLPacE[j].UserW_IdGrupoFamiliar;
                                    oConsultaHospitalizacionResponse.codFamiliar = oLPacE[j].UserW_CodParentesco;
                                    oConsultaHospitalizacionResponse.desFamiliar = oLPacE[j].UserW_DscParentesco;
                                    break;
                                }
                            }

                            oList.Add(oConsultaHospitalizacionResponse);
                        }
                    }
                }
            }

            return oList;
        }

        public AlergiaMedicamentosRiesgoGrabarResponse MtGrabarAlergiasMedicacionRiesgoCasa(AlergiaMedicamentosRiesgoGrabarRequest pAlergiaConsultaRequest)
        {
            AlergiaMedicamentosRiesgoGrabarResponse oResponse = new AlergiaMedicamentosRiesgoGrabarResponse();

            // Se agrego para guardar en auditoria los inputs que envian Solera y SoftVan.
            string JsonBody = JsonSerializer.Serialize(pAlergiaConsultaRequest);
            string SecurityApiKey = Utilities.Criptography.DecryptConectionString(pAlergiaConsultaRequest.ApiKey);
            ApiKey? objApiKey = JsonSerializer.Deserialize<ApiKey>(SecurityApiKey);

            new RcePahRequestJsonAD().Sp_RcePahRequestJson_Insert(new RcePahRequestJsonE(0, pAlergiaConsultaRequest.IdRegistro, "02", objApiKey.USR, JsonBody));

            if (fnValidarApiKey(pAlergiaConsultaRequest.ApiKey))
            {
                RcePahEstadosCabE oRcePahEstadosCabE = new RcePahEstadosCabE();
                RcePahAlergiaCabE oRcePahAlergiaCabE = new RcePahAlergiaCabE();

                {
                    var withBlock = pAlergiaConsultaRequest;
                    oRcePahEstadosCabE = new RcePahEstadosCabE(0, withBlock.idAmbulatorio, withBlock.codAtencion, withBlock.accion);
                }

                using (System.Transactions.TransactionScope trans = new System.Transactions.TransactionScope())
                {
                    try
                    {
                        {
                            var withBlock = pAlergiaConsultaRequest;
                            new RcePahEstadosCabAD().Sp_RcePahEstadosCab_Insert(oRcePahEstadosCabE);

                            oRcePahAlergiaCabE = new RcePahAlergiaCabE(0, oRcePahEstadosCabE.IdePreAdmision, pAlergiaConsultaRequest.indAlergia, pAlergiaConsultaRequest.hospitalizado, pAlergiaConsultaRequest.representante, pAlergiaConsultaRequest.habitacion, pAlergiaConsultaRequest.alimentos, pAlergiaConsultaRequest.otros, pAlergiaConsultaRequest.RespEnvio, "A", pAlergiaConsultaRequest.accion);

                            if (oRcePahEstadosCabE.IdePreAdmision > 0)
                            {
                                if (pAlergiaConsultaRequest.accion == "A")
                                {
                                    new RcePahAlergiaCabAD().Sp_RcePahAlergiaCab_Delete(new RcePahAlergiaCabE(0, oRcePahEstadosCabE.CodAtencion, 0));
                                    new RcePahMedicacionCabAD().Sp_RcePahMedicacionCab_Delete(new RcePahMedicacionCabE(0, "", "", oRcePahEstadosCabE.CodAtencion));

                                    new RcePahEstadosCabAD().Sp_RcePahEstadosCab_UpdatexCampo(new RcePahEstadosCabE(0, "", oRcePahAlergiaCabE.CodAtencion, "AR", "est_envio_correo_por_enviar"));
                                }

                                new RcePahAlergiaCabAD().Sp_RcePahAlergiaCab_Insert(oRcePahAlergiaCabE);

                                byte[] Doc = Convert.FromBase64String(pAlergiaConsultaRequest.documentoAlergias);
                                RcePahDocumentosPdfE oRcePahDocumentosPdfE = new RcePahDocumentosPdfE(0, withBlock.codAtencion, oRcePahEstadosCabE.IdePreAdmision, "ALER", Doc);
                                new RcePahDocumentosPdfAD().Sp_RcePahDocumentosPdf_Insert(oRcePahDocumentosPdfE);
                                if (oRcePahDocumentosPdfE.IdeDocumentosPdf == 0)
                                    throw new Exception("No se pudo grabar el documento pdf de Alergias, revisar lo enviado por favor.");

                                RcePahAlergiaMedicamentosDetE oRcePahAlergiaMedicamentosDetE = new RcePahAlergiaMedicamentosDetE();
                                if (oRcePahAlergiaCabE.IdeAlergiaCab != 0)
                                {
                                    for (int i = 0; i <= withBlock.medicamentos.Count - 1; i++)
                                    {
                                        oRcePahAlergiaMedicamentosDetE = new RcePahAlergiaMedicamentosDetE(oRcePahAlergiaCabE.IdeAlergiaCab, withBlock.medicamentos[i].Codigo, withBlock.medicamentos[i].Descripcion);
                                        new RcePahAlergiaMedicamentosDetAD().Sp_RcePahAlergiaMedicamentosDet_Insert(oRcePahAlergiaMedicamentosDetE);
                                        if (oRcePahAlergiaMedicamentosDetE.IdeAlergiaMedicamentosDet == 0)
                                            throw new Exception("No se pudo grabar el método Sp_RcePahAlergiaMedicamentosDet_Insert");
                                    }
                                }
                                else
                                    throw new Exception("No se pudo grabar el método Sp_RcePahAlergiaCab_Insert");

                                RcePahMedicacionCabE oRcePahMedicacionCabE = new RcePahMedicacionCabE(0, withBlock.RespEnvio, "A");
                                new RcePahMedicacionCabAD().Sp_RcePahMedicacionCab_Insert(oRcePahMedicacionCabE);

                                Doc = Convert.FromBase64String(pAlergiaConsultaRequest.documentoRiesgos);
                                oRcePahDocumentosPdfE = new RcePahDocumentosPdfE(0, withBlock.codAtencion, oRcePahEstadosCabE.IdePreAdmision, "MED", Doc);
                                new RcePahDocumentosPdfAD().Sp_RcePahDocumentosPdf_Insert(oRcePahDocumentosPdfE);
                                if (oRcePahDocumentosPdfE.IdeDocumentosPdf == 0)
                                    throw new Exception("No se pudo grabar el documento pdf de medicación, revisar lo enviado por favor.");

                                RcePahMedicacionDetE oRcePahMedicacionDetE = new RcePahMedicacionDetE();
                                if (oRcePahMedicacionCabE.IdeMedicacionCab != 0)
                                {
                                    for (int i = 0; i <= withBlock.medicamentosRiesgos.Count - 1; i++)
                                    {
                                        oRcePahMedicacionDetE = new RcePahMedicacionDetE(0, oRcePahMedicacionCabE.IdeMedicacionCab, withBlock.medicamentosRiesgos[i].Codigo, withBlock.medicamentosRiesgos[i].Indicador);
                                        new RcePahMedicacionDetAD().Sp_RcePahMedicacionDet_Insert(oRcePahMedicacionDetE);
                                        if (oRcePahMedicacionDetE.IdeMedicacionDet == 0)
                                            throw new Exception("No se pudo grabar el método Sp_RcePahMedicacionDet_Insert");
                                    }
                                }
                                else
                                    throw new Exception("No se pudo grabar el método Sp_RcePahMedicacionCab_Insert");

                                new RcePahEstadosCabAD().Sp_RcePahEstadosCab_UpdatexCampo(new RcePahEstadosCabE(oRcePahEstadosCabE.IdePreAdmision, "", "", oRcePahAlergiaCabE.IdeAlergiaCab.ToString(), "ide_alergia_cab"));
                                new RcePahEstadosCabAD().Sp_RcePahEstadosCab_UpdatexCampo(new RcePahEstadosCabE(oRcePahEstadosCabE.IdePreAdmision, "", "", oRcePahMedicacionCabE.IdeMedicacionCab.ToString(), "ide_medicacion_cab"));

                                trans.Complete();
                                oResponse = new AlergiaMedicamentosRiesgoGrabarResponse("S", "Completado");
                            }
                            else if (pAlergiaConsultaRequest.accion == "A")
                                throw new Exception("No se pudo actualizar los datos sin antes haber registrado.");
                        }
                    }
                    catch (Exception ex)
                    {
                        trans.Dispose();
                        oResponse = new AlergiaMedicamentosRiesgoGrabarResponse("N", ex.Message);
                        throw new Exception(ex.Message);
                    }
                }
            }

            return oResponse;
        }

        public AlergiaConsultaResponse MtConsultarAlergiasMedicacionRiesgoCasa(AlergiaConsultaRequest pAlergiaConsultaRequest)
        {
            AlergiaConsultaResponse oAlergiaConsultaResponse = new AlergiaConsultaResponse();

            // Se agrego para guardar en auditoria los inputs que envian Solera y SoftVan.            
            string JsonBody = JsonSerializer.Serialize(pAlergiaConsultaRequest);
            string SecurityApiKey = Utilities.Criptography.DecryptConectionString(pAlergiaConsultaRequest.ApiKey);
            ApiKey? objApiKey = JsonSerializer.Deserialize<ApiKey>(SecurityApiKey);
            new RcePahRequestJsonAD().Sp_RcePahRequestJson_Insert(new RcePahRequestJsonE(0, 0, "03", objApiKey.USR, JsonBody));

            if (fnValidarApiKey(pAlergiaConsultaRequest.ApiKey))
            {
                List<RcePahAlergiaCabE> oListAlergiaCabE = new RcePahAlergiaCabAD().Sp_RcePahAlergiaCab_Consulta(new RcePahAlergiaCabE(0, pAlergiaConsultaRequest.codAtencion, 1));

                for (int i = 0; i <= oListAlergiaCabE.Count - 1; i++)
                {
                    RcePahAlergiaCabE oAlergiaCabE = oListAlergiaCabE[i];
                    List<RcePahAlergiaMedicamentosDetE> oLAlergiaMetDet = new RcePahAlergiaMedicamentosDetAD().Sp_RcePahAlergiaMedicamentosDet_Consulta(new RcePahAlergiaMedicamentosDetE(oAlergiaCabE.IdeAlergiaCab, "", "", 0, 1));
                    List<RcePahMedicacionDetE> oLMedicacionDet = new RcePahMedicacionDetAD().Sp_RcePahMedicacionDet_Consulta(new RcePahMedicacionDetE(0, oAlergiaCabE.IdeMedicacionCab, 1));
                    oAlergiaConsultaResponse.indAlergia = oAlergiaCabE.IndAlergia;
                    oAlergiaConsultaResponse.hospitalizado = oAlergiaCabE.DscHospitalizado;
                    oAlergiaConsultaResponse.representante = oAlergiaCabE.DscRepresentante;
                    oAlergiaConsultaResponse.habitacion = oAlergiaCabE.DscHabitacion;

                    oAlergiaConsultaResponse.alimentos = oAlergiaCabE.DscAlimentos;
                    oAlergiaConsultaResponse.otros = oAlergiaCabE.DscOtros;
                    oAlergiaConsultaResponse.idRegistro = oAlergiaCabE.IdePreAdmision;

                    oAlergiaConsultaResponse.medicamentos = new List<MedicamentosResponse>();
                    for (int j = 0; j <= oLAlergiaMetDet.Count - 1; j++)
                        oAlergiaConsultaResponse.medicamentos.Add(new MedicamentosResponse(oLAlergiaMetDet[j].CodGenerico, oLAlergiaMetDet[j].DscMedicamento, oLAlergiaMetDet[j].IdeAlergiaMedicamentosDet));

                    oAlergiaConsultaResponse.medicamentosRiesgos = new List<MedicamentosRiesgoItems>();
                    for (int j = 0; j <= oLMedicacionDet.Count - 1; j++)
                        oAlergiaConsultaResponse.medicamentosRiesgos.Add(new MedicamentosRiesgoItems(oLMedicacionDet[j].IdeMedicacionDet, oLMedicacionDet[j].IdeMedicacionItemsMae, oLMedicacionDet[j].FlgRespuesta, oLMedicacionDet[j].DscItem, oLMedicacionDet[j].DscSubItem));
                }
            }
            else
            {
            }

            return oAlergiaConsultaResponse;
        }

        public TerminosAdmisionGrabarResponse MtGrabarDocumentoAdmisionTerminos(TerminosAdmisionGrabarRequest pTerminosAdmisionGrabarRequest)
        {
            TerminosAdmisionGrabarResponse oTerminosAdmisionGrabarResponse = new TerminosAdmisionGrabarResponse();

            // Se agrego para guardar en auditoria los inputs que envian Solera y SoftVan.            
            string JsonBody = JsonSerializer.Serialize(pTerminosAdmisionGrabarRequest);
            string SecurityApiKey = Utilities.Criptography.DecryptConectionString(pTerminosAdmisionGrabarRequest.ApiKey);
            ApiKey? objApiKey = JsonSerializer.Deserialize<ApiKey>(SecurityApiKey);
            new RcePahRequestJsonAD().Sp_RcePahRequestJson_Insert(new RcePahRequestJsonE(0, pTerminosAdmisionGrabarRequest.idRegistro, "04", objApiKey.USR, JsonBody));

            if (fnValidarApiKey(pTerminosAdmisionGrabarRequest.ApiKey))
            {
                using (System.Transactions.TransactionScope trans = new System.Transactions.TransactionScope())
                {
                    try
                    {
                        {
                            var withBlock = pTerminosAdmisionGrabarRequest;
                            RcePahDocumentoAdmisionCabE oRcePahAdmisionCabE = new RcePahDocumentoAdmisionCabE(0, withBlock.codAtencion, withBlock.DscTexto, withBlock.indTerminosAdmision, withBlock.ResponsableEnvio, "A");

                            if (pTerminosAdmisionGrabarRequest.accion == "A")
                            {
                                new RcePahDocumentoAdmisionCabAD().Sp_RcePahDocumentoAdmisionCab_Delete(new RcePahDocumentoAdmisionCabE(0, withBlock.codAtencion, "", "", "", ""));
                                new RcePahEstadosCabAD().Sp_RcePahEstadosCab_UpdatexCampo(new RcePahEstadosCabE(0, "", withBlock.codAtencion, "TA", "est_envio_correo_por_enviar"));
                            }

                            byte[] Doc = Convert.FromBase64String(pTerminosAdmisionGrabarRequest.documento);
                            RcePahDocumentosPdfE oRcePahDocumentosPdfE = new RcePahDocumentosPdfE(0, withBlock.codAtencion, 0, "DOCADM", Doc);
                            new RcePahDocumentosPdfAD().Sp_RcePahDocumentosPdf_Insert(oRcePahDocumentosPdfE);
                            if (oRcePahDocumentosPdfE.IdeDocumentosPdf == 0)
                                throw new Exception("No se pudo grabar el documento pdf de documento de admisión, revisar lo enviado por favor.");

                            new RcePahDocumentoAdmisionCabAD().Sp_RcePahDocumentoAdmisionCab_Insert(oRcePahAdmisionCabE);
                            if (oRcePahAdmisionCabE.IdeDocumentoAdmisionCab != 0)
                                new RcePahEstadosCabAD().Sp_RcePahEstadosCab_UpdatexCampo(new RcePahEstadosCabE(0, "", withBlock.codAtencion, oRcePahAdmisionCabE.IdeDocumentoAdmisionCab.ToString(), "ide_documento_admision_cab_cod_atencion"));
                            else
                                throw new Exception("No se pudo grabar en el metodo: Sp_RcePahDocumentoAdmisionCab_Insert");
                        }

                        // Convert.FromBase64String(pTerminosAdmisionGrabarRequest.documento)

                        trans.Complete();
                        oTerminosAdmisionGrabarResponse = new TerminosAdmisionGrabarResponse("S", "Se grabaron los datos correctamente!");
                    }
                    catch (Exception ex)
                    {
                        trans.Dispose();
                        oTerminosAdmisionGrabarResponse = new TerminosAdmisionGrabarResponse("N", ex.Message);
                    }
                }
            }

            return oTerminosAdmisionGrabarResponse;
        }

        public TerminosDocumentoAdmisionConsultaResponse MtConsultarDocumentoAdmisionTerminos(TerminosDocumentoAdmisionConsultaRequest pTerminos)
        {
            TerminosDocumentoAdmisionConsultaResponse oLTerminos = new TerminosDocumentoAdmisionConsultaResponse();

            // Se agrego para guardar en auditoria los inputs que envian Solera y SoftVan.
            string JsonBody = JsonSerializer.Serialize(pTerminos);
            string SecurityApiKey = Utilities.Criptography.DecryptConectionString(pTerminos.ApiKey);
            ApiKey? objApiKey = JsonSerializer.Deserialize<ApiKey>(SecurityApiKey);

            new RcePahRequestJsonAD().Sp_RcePahRequestJson_Insert(new RcePahRequestJsonE(0, 0, "05", objApiKey.USR, JsonBody));

            if (fnValidarApiKey(pTerminos.ApiKey))
            {
                RcePahDocumentoAdmisionCabE oRcePahDocumentoAdmE = new RcePahDocumentoAdmisionCabE(0, pTerminos.codAtencion, "", "", "", "");
                oRcePahDocumentoAdmE.Orden = 1;

                List<RcePahDocumentoAdmisionCabE> oList = new RcePahDocumentoAdmisionCabAD().Sp_RcePahDocumentoAdmisionCab_Consulta(oRcePahDocumentoAdmE);

                for (int i = 0; i <= oList.Count - 1; i++)
                {
                    oLTerminos.idRegistro = oList[i].IdeDocumentoAdmisionCab.ToString();
                    oLTerminos.indTerminosAdmision = oList[i].DscRpta;
                }
            }

            return oLTerminos;
        }

        public AutorizacionContactosPreFacturasGrabarResponse MtGrabarContactosAutorizadosPreFacturas(AutorizacionContactosPreFacturasGrabarRequest pPreFacturas)
        {
            AutorizacionContactosPreFacturasGrabarResponse oResponse = new AutorizacionContactosPreFacturasGrabarResponse();

            // Se agrego para guardar en auditoria los inputs que envian Solera y SoftVan.            
            string JsonBody = JsonSerializer.Serialize(pPreFacturas);
            string SecurityApiKey = Utilities.Criptography.DecryptConectionString(pPreFacturas.ApiKey);            
            ApiKey? objApiKey = JsonSerializer.Deserialize<ApiKey>(SecurityApiKey);

            new RcePahRequestJsonAD().Sp_RcePahRequestJson_Insert(new RcePahRequestJsonE(0, pPreFacturas.idRegistro, "06", objApiKey.USR, JsonBody));

            {
                var withBlock = pPreFacturas;
                if (fnValidarApiKey(withBlock.ApiKey))
                {
                    using (System.Transactions.TransactionScope trans = new System.Transactions.TransactionScope())
                    {
                        try
                        {
                            if (pPreFacturas.accion == "A")
                            {
                                new RcePahAutorizacionPrefacturasCabAD().Sp_RcePahAutorizacionPrefacturasCab_Delete(new RcePahAutorizacionPrefacturasCabE(0, withBlock.codAtencion));

                                new RcePahEstadosCabAD().Sp_RcePahEstadosCab_UpdatexCampo(new RcePahEstadosCabE(0, "", withBlock.codAtencion, "PF", "est_envio_correo_por_enviar"));
                            }

                            byte[] Doc = Convert.FromBase64String(pPreFacturas.documento);
                            RcePahDocumentosPdfE oRcePahDocumentosPdfE = new RcePahDocumentosPdfE(0, withBlock.codAtencion, 0, "TERM", Doc);
                            new RcePahDocumentosPdfAD().Sp_RcePahDocumentosPdf_Insert(oRcePahDocumentosPdfE);
                            if (oRcePahDocumentosPdfE.IdeDocumentosPdf == 0)
                                throw new Exception("No se pudo grabar el documento pdf de pre facturas, revisar lo enviado por favor.");

                            RcePahAutorizacionPrefacturasCabE oPreFacturasCabE = new RcePahAutorizacionPrefacturasCabE(0, pPreFacturas.codAtencion);
                            new RcePahAutorizacionPrefacturasCabAD().Sp_RcePahAutorizacionPrefacturasCab_Insert(oPreFacturasCabE);
                            if (oPreFacturasCabE.IdeAutorizacionPrefacturasCab != 0)
                            {
                                for (int i = 0; i <= withBlock.personas.Count - 1; i++)
                                {
                                    RcePahAutorizacionPrefacturasDetE oPreFacturasDetE = new RcePahAutorizacionPrefacturasDetE(0, oPreFacturasCabE.IdeAutorizacionPrefacturasCab, withBlock.personas[i].apellidos, withBlock.personas[i].nombres, withBlock.personas[i].dni, withBlock.personas[i].correo, withBlock.ResponsableEnvio, "A", withBlock.personas[i].parentesco, withBlock.personas[i].telefono);
                                    new RcePahAutorizacionPrefacturasDetAD().Sp_RcePahAutorizacionPrefacturasDet_Insert(oPreFacturasDetE);

                                    if (oPreFacturasDetE.IdeAutorizacionPrefacturasDet == 0)
                                        throw new Exception("No se grabaron los datos correctamente!");
                                }
                            }

                            new RcePahEstadosCabAD().Sp_RcePahEstadosCab_UpdatexCampo(new RcePahEstadosCabE(0, "", withBlock.codAtencion, oPreFacturasCabE.IdeAutorizacionPrefacturasCab.ToString(), "ide_autorizacion_prefacturas_cab_cod_atencion"));
                            new RcePahEstadosCabAD().Sp_RcePahEstadosCab_UpdatexCampo(new RcePahEstadosCabE(0, "", withBlock.codAtencion, "T", "est_envio_correo_por_enviar"));

                            trans.Complete();
                            oResponse = new AutorizacionContactosPreFacturasGrabarResponse("S", "Se grabaron los datos correctamente!");
                        }
                        catch (Exception ex)
                        {
                            trans.Dispose();
                            oResponse = new AutorizacionContactosPreFacturasGrabarResponse("N", ex.Message);
                        }
                    }
                }
            }

            return oResponse;
        }

        public AutorizacionContactosPreFacturaConsultaResponse MtConsultarContactosAutorizadosPreFacturas(AutorizacionContactosPreFacturaConsultaRequest pContactosRequest)
        {
            AutorizacionContactosPreFacturaConsultaResponse oAutResponse = new AutorizacionContactosPreFacturaConsultaResponse();

            // Se agrego para guardar en auditoria los inputs que envian Solera y SoftVan.            
            string JsonBody = JsonSerializer.Serialize(pContactosRequest);
            string SecurityApiKey = Utilities.Criptography.DecryptConectionString(pContactosRequest.ApiKey);            
            ApiKey? objApiKey = JsonSerializer.Deserialize<ApiKey>(SecurityApiKey);

            new RcePahRequestJsonAD().Sp_RcePahRequestJson_Insert(new RcePahRequestJsonE(0, 0, "07", objApiKey.USR, JsonBody));

            if (fnValidarApiKey(pContactosRequest.ApiKey))
            {
                List<RcePahAutorizacionPrefacturasCabE> oLRcePahAutPrefactE = new RcePahAutorizacionPrefacturasCabAD().Sp_RcePahAutorizacionPrefacturasCab_Consulta(new RcePahAutorizacionPrefacturasCabE(0, pContactosRequest.codAtencion, 1));

                for (int i = 0; i <= oLRcePahAutPrefactE.Count - 1; i++)
                {
                    oAutResponse.IdRegistroCab = oLRcePahAutPrefactE[i].IdeAutorizacionPrefacturasCab;

                    {
                        var withBlock = oLRcePahAutPrefactE[i].oAutorizacionPreDetE;
                        oAutResponse.Persona.Add(new AutorizacionContactosPreFacturasPersonasResponse(withBlock.IdeAutorizacionPrefacturasDet, withBlock.DscApellidos, withBlock.DscNombres, withBlock.NroDni, withBlock.DscCorreos, withBlock.Telefono, withBlock.Parentesco));
                    }
                }
            }

            return oAutResponse;
        }

        public List<RcePahEstadosCabE> MtConsultarEstadosDocumentos(RcePahEstadosCabE pRcePahEstadosCabE)
        {
            return new RcePahEstadosCabAD().Sp_RcePahEstadosCab_Consulta(pRcePahEstadosCabE);
        }


        /// <summary>
        ///     ''' Cargar los datos iniciales que se necesita para enviar los correos a los pacientes.
        ///     ''' </summary>
        public void CargarIniCorreo()
        {
            TablasE oTablasE = new TablasE();

            oTablasE = new TablasAD().Sp_Tablas_ConsultaEntidad(new TablasE("RUTA_CORREO", "01", 0, 0, 8));
            RutaCorreo = oTablasE.Nombre;
        }

        public bool MtEnviarCorreosPacientesPreAdmision(RcePahCorreosEnviadosE pRcePahEstadosCabE)
        {
            return new RcePahCorreosEnviadosAD().Sp_RcePahCorreosEnviados_Insert(pRcePahEstadosCabE);
        }

        public bool MtEnviarCorreosGenerales(RcePahCorreosEnviadosE pRcePahEstadosCabE)
        {
            return new RcePahCorreosEnviadosAD().Sp_RcePahCorreosGenerales(pRcePahEstadosCabE);
        }

        /// <summary>
        ///     ''' Pre Admisión Hospitalaria: Enviar correos a los pacientes con sus archivos adjuntos. 
        ///     ''' Tiene dos flujos: T: Enviar todo los documentos o cualquier otro valor AR, TA, PF envía solo el documento que fue modificado.
        ///     ''' 
        ///     ''' </summary>
        public void MtEnviarCorreosDocumentosPacientes()
        {
            RcePahCorreosEnviadosE oRcePahCorreosEnviadosE = new RcePahCorreosEnviadosE();
            string CodAtencion = "";
            string RutaArchivoAdjunto = "";
            string RutaArchivo = "";
            string CodEnvioCorreo = "";
            bool FlgError = false;

            RcePahEstadosCabE oRcePahEstadosCabE = new RcePahEstadosCabE();
            List<RcePahEstadosCabE> oList = new List<RcePahEstadosCabE>();

            try
            {
                oRcePahEstadosCabE.Orden = 3;
                oList = new RcePahEstadosCabAD().Sp_RcePahEstadosCab_Consulta(oRcePahEstadosCabE);

                for (var i = 0; i <= oList.Count - 1; i++)
                {
                    CodAtencion = oList[i].CodAtencion;
                    CodEnvioCorreo = oList[i].CodEnvioCorreo;
                    RutaArchivoAdjunto = "";
                    RutaArchivo = "";

                    List<RcePahDocumentosPdfE> oListPDF = new List<RcePahDocumentosPdfE>();
                    if (CodEnvioCorreo == "T")
                        oListPDF = new RcePahDocumentosPdfAD().Sp_RcePahDocumentosPdf_Consulta(new RcePahDocumentosPdfE(0, CodAtencion, 0, "", new byte[0], 2));
                    else if (CodEnvioCorreo == "AR")
                    {
                        oListPDF = new RcePahDocumentosPdfAD().Sp_RcePahDocumentosPdf_Consulta(new RcePahDocumentosPdfE(0, CodAtencion, 0, "ALER", new byte[0], 1));
                        List<RcePahDocumentosPdfE> oListPDF2 = new RcePahDocumentosPdfAD().Sp_RcePahDocumentosPdf_Consulta(new RcePahDocumentosPdfE(0, CodAtencion, 0, "MED", new byte[0], 1));
                        for (var k = 0; k <= oListPDF2.Count - 1; k++)
                            oListPDF.Add(oListPDF2[k]);
                    }
                    else if (CodEnvioCorreo == "TA")
                        oListPDF = new RcePahDocumentosPdfAD().Sp_RcePahDocumentosPdf_Consulta(new RcePahDocumentosPdfE(0, CodAtencion, 0, "DOCADM", new byte[0], 1));
                    else if (CodEnvioCorreo == "PF")
                        oListPDF = new RcePahDocumentosPdfAD().Sp_RcePahDocumentosPdf_Consulta(new RcePahDocumentosPdfE(0, CodAtencion, 0, "TERM", new byte[0], 1));

                    for (var j = 0; j <= oListPDF.Count - 1; j++)
                    {
                        RutaArchivo = RutaCorreo + @"\" + CodAtencion + "-" + oListPDF[j].CodTipoDocumento + ".PDF";

                        if (j == 0)
                            RutaArchivoAdjunto = RutaArchivo;
                        else if (j >= 1)
                            RutaArchivoAdjunto = RutaArchivoAdjunto + ";" + RutaArchivo;

                        try
                        {
                            System.IO.File.WriteAllBytes(RutaArchivo, oListPDF[j].BlbDocumento);
                        }
                        catch (Exception ex)
                        {
                            VariablesGlobales.Guardar_Error_BaseDatos("Hay problemas al grabar el archivo del correo de Pre-Admisión en la siguiente ruta: <strong>" + RutaCorreo + "</strong> <br/>" + "Descripción TraceCodigo: " + ex.ToString(), "MtEnviarCorreosDocumentosPacientes");
                            break;
                        }
                    }

                    if (FlgError == true)
                        break;

                    if (CodEnvioCorreo == "T")
                        oRcePahCorreosEnviadosE = new RcePahCorreosEnviadosE(2, CodAtencion, RutaArchivoAdjunto, 0, (CodEnvioCorreo == "T" ? "" : CodEnvioCorreo));
                    else
                        oRcePahCorreosEnviadosE = new RcePahCorreosEnviadosE(3, CodAtencion, RutaArchivoAdjunto, 0, (CodEnvioCorreo == "T" ? "" : CodEnvioCorreo));

                    MtEnviarCorreosGenerales(oRcePahCorreosEnviadosE);
                    if (oRcePahCorreosEnviadosE.MailItemId != 0)
                        new RcePahEstadosCabAD().Sp_RcePahEstadosCab_UpdatexCampo(new RcePahEstadosCabE(0, "", CodAtencion, "", "est_envio_correo_enviado"));
                }
                new TablasAD().Sp_Tablas_Update(new TablasE("RCE_PAH_SERVICIO_FECHA_CORREO", "01", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), "nombre"));
            }
            catch (Exception ex)
            {
                VariablesGlobales.Guardar_Error_BaseDatos("<strong>Message: </strong>" + ex.Message + "<br/><strong>StackTrace: </strong>" + ex.StackTrace + "<br/>", "MtEnviarCorreosDocumentosPacientes");
            }
        }

        public List<RcePahDocumentosPdfE> MtObtenerDocumentoPDF(RcePahDocumentosPdfE pRcePahDocumentosPdfE)
        {
            return new RcePahDocumentosPdfAD().Sp_RcePahDocumentosPdf_Consulta(pRcePahDocumentosPdfE);
        }

    }
}