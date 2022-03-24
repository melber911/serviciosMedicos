using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Sql.ClinicaE.MedisynE
{
    public class MdsynVideoLlamadaE
    {
        public int IdeVideoLlamada { get; set; } = 0;
        public int IdecorrelReserva { get; set; } = 0;
        public string FlgTeleConsulta { get; set; } = "";
        public string DscUrlVideollamada { get; set; } = "";
        public DateTime FecRegistro { get; set; } = DateTime.Now;
        // ---     EXTENSIONES    ---
        public string DscTeleConsulta { get; set; } = "";

        public string NuevoValor { get; set; } = "";
        public string Campo { get; set; } = "";
        public int Orden { get; set; } = 0;


        public MdsynVideoLlamadaE()
        {
        }

        public MdsynVideoLlamadaE(int pIdeVideollamada)
        {
            IdeVideoLlamada = pIdeVideollamada;
        }

        public MdsynVideoLlamadaE(int pIdeVideollamada, int pOrden)
        {
            IdeVideoLlamada = pIdeVideollamada;
            Orden = pOrden;
        }

        public MdsynVideoLlamadaE(int pIdeVideollamada, string pNuevoValor, string pCampo)
        {
            IdeVideoLlamada = pIdeVideollamada;
            NuevoValor = pNuevoValor;
            Campo = pCampo;
        }

        public MdsynVideoLlamadaE(int pIdeVideollamada, int pIdeCorrelReserva, string pFlgTeleConsulta, string pDscUrlVideoLlamada)
        {
            IdeVideoLlamada = pIdeVideollamada;
            IdecorrelReserva = pIdeCorrelReserva;
            FlgTeleConsulta = pFlgTeleConsulta;
            DscUrlVideollamada = pDscUrlVideoLlamada;
        }

        public MdsynVideoLlamadaE(int pIdeVideollamada, int pIdeCorrelReserva, string pFlgTeleConsulta, string pDscUrlVideoLlamada, int pOrden)
        {
            IdeVideoLlamada = pIdeVideollamada;
            IdecorrelReserva = pIdeCorrelReserva;
            FlgTeleConsulta = pFlgTeleConsulta;
            DscUrlVideollamada = pDscUrlVideoLlamada;
            Orden = pOrden;
        }
    }
}
