using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Sql.ClinicaE.MedisynE
{
    public class MdsynReservalogErrorE
    {
        public int IdeReservalogerror { get; set; } = 0;
        public string DscMensaje { get; set; } = "";
        public string DscPC { get; set; } = "";
        public string DscIP { get; set; } = "";
        public DateTime FecRegistro { get; set; }

        public MdsynReservalogErrorE()
        {
        }

        public MdsynReservalogErrorE(string pDscMensaje)
        {
            DscMensaje = pDscMensaje;
        }

        public MdsynReservalogErrorE(string pDscMensaje, string pDscPC, string pDscIP)
        {
            DscMensaje = pDscMensaje;
            DscPC = pDscPC;
            DscIP = pDscIP;
        }
    }
}
