using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Sql.ClinicaE.MedicosE
{
    public class MedicosE
    {
        public string CodMedico { get; set; } = "";
        public string NombresMedico { get; set; } = "";
        public string DocIdentidad { get; set; } = "";
        public string ColMedico { get; set; } = "";

        public string CodProfMedisyn { get; set; } = "";
        public string CodTipoConsulta { get; set; } = "";

        public string FlgTeleConsulta { get; set; } = "";
        public string FlgPresencialJM { get; set; } = "";
        public string FlgPresencialCM { get; set; } = "";

        public string MntTarifaParticular { get; set; } = "";
        public string DscObservacionSubEspecialidad { get; set; } = "";
        public string DscEmail { get; set; } = "";

        // 
        public string Buscar { get; set; } = "";
        public int Key { get; set; } = 0;
        public int NumeroLineas { get; set; } = 0;
        public int Orden { get; set; } = 0;

        public string Campo { get; set; } = "";
        public string NuevoValor { get; set; } = "";

        // Extensiones
        public string DscTituloTarifa { get; set; } = "";
        public string TipMoneda { get; set; } = "";
        public string TipoConsultaMedica { get; set; } = ""; // 


        public MedicosE()        {        }

        #region Sp_Medicos_Update
        /// <summary>
        ///         ''' [Sp_Medicos_Update]
        ///         ''' </summary>
        ///         ''' <param name="pCampo"></param>
        ///         ''' <param name="pCodMedico"></param>
        ///         ''' <param name="pNuevoValor"></param>
        public MedicosE(string pCampo, string pCodMedico, string pNuevoValor)
        {
            Campo = pCampo;
            CodMedico = pCodMedico;
            NuevoValor = pNuevoValor;
        }
        #endregion

        #region Sp_Medicos_Consulta
        /// <summary>
        ///         ''' [Sp_Medicos_Consulta]
        ///         ''' </summary>
        ///         ''' <param name="pBuscar"></param>
        ///         ''' <param name="pKey"></param>
        ///         ''' <param name="pNumeroLineas"></param>
        ///         ''' <param name="pOrden"></param>
        public MedicosE(string pBuscar, int pKey, int pNumeroLineas, int pOrden)
        {
            Buscar = pBuscar;
            Key = pKey;
            NumeroLineas = pNumeroLineas;
            Orden = pOrden;
        }
        #endregion
    }
}
