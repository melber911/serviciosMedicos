using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Sql.ClinicaE.MedisynE
{
    public class MdsynAutorizacionCuestionariosCabE
    {
        public int IdeAutorizacionCab { get; set; } = 0;
        public int IdeCorrelReserva { get; set; } = 0;
        public string CodTipoCuestionario { get; set; } = "";
        public string CodPaciente { get; set; } = "";
        public string CodPacienteTitular { get; set; } = "";
        public string DscIpCliente { get; set; } = "";
        public DateTime FecRegistro { get; set; } = DateTime.Now;

        // ---     EXTENSIONES    ---
        public string NuevoValor { get; set; } = "";
        public string Campo { get; set; } = "";
        public int Orden { get; set; } = 0;


        public MdsynAutorizacionCuestionariosCabE() { }

        public MdsynAutorizacionCuestionariosCabE(int pIdeAutorizacionCab)
        { IdeAutorizacionCab = pIdeAutorizacionCab; }

        public MdsynAutorizacionCuestionariosCabE(int pIdeAutorizacionCab, string pNuevoValor, string pCampo)
        {
            IdeAutorizacionCab = pIdeAutorizacionCab;
            NuevoValor = pNuevoValor;
            Campo = pCampo;
        }

        public MdsynAutorizacionCuestionariosCabE(int pIdeAutorizacionCab, int pIdeCorrelReserva, string pCodTipoCuestionario, string pCodPaciente, string pCodPacienteTitular, string pDscIpCliente)
        {
            IdeAutorizacionCab = pIdeAutorizacionCab;
            IdeCorrelReserva = pIdeCorrelReserva;
            CodTipoCuestionario = pCodTipoCuestionario;
            CodPaciente = pCodPaciente;
            CodPacienteTitular = pCodPacienteTitular;
            DscIpCliente = pDscIpCliente;
        }
    }
}
