using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Sql.ClinicaE.OtrosE
{
    public class QR
    {
        public bool EstadoRespuesta { get; set; } = false;

        public string DscRespuesta { get; set; } = "";

        public List<RespuestaE> Respuesta { get; set; } = new List<RespuestaE>();

        public QR() { }

        public QR(bool pEstadoRespuesta, string pDscRespuesta, List<RespuestaE> pListRespuesta)
        {
            Respuesta = pListRespuesta;
            EstadoRespuesta = pEstadoRespuesta;
            DscRespuesta = pDscRespuesta;
        }
    }
}
