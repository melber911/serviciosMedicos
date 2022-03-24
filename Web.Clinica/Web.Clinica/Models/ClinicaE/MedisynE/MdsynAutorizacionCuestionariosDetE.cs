using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Sql.ClinicaE.MedisynE
{
    public class MdsynAutorizacionCuestionariosDetE
    {
        public int IdeAutorizacionDet { get; set; } = 0;
        public int IdeAutorizacionCab { get; set; } = 0;
        public string DscTextoAutorizacion { get; set; } = "";
        public string DscRespuesta { get; set; } = "";
        public DateTime FecRegistro { get; set; } = DateTime.Now;

        // ---     EXTENSIONES    ---
        public string NuevoValor { get; set; } = "";
        public string Campo { get; set; } = "";
        public int Orden { get; set; } = 0;
        public int i { get; set; } = 0;
        public string CodTipoCuestionario { get; set; } = "";


        public MdsynAutorizacionCuestionariosDetE()
        {
        }

        public MdsynAutorizacionCuestionariosDetE(int pIdeAutorizacionDet)
        {
            IdeAutorizacionDet = pIdeAutorizacionDet;
        }

        public MdsynAutorizacionCuestionariosDetE(int pIdeAutorizacionDet, string pNuevoValor, string pCampo)
        {
            IdeAutorizacionDet = pIdeAutorizacionDet;
            NuevoValor = pNuevoValor;
            Campo = pCampo;
        }

        public MdsynAutorizacionCuestionariosDetE(int pIdeAutorizacionDet, int pIdeAutorizacionCab, string pDscTextoAutorizacion, string pDscRespuesta)
        {
            IdeAutorizacionDet = pIdeAutorizacionDet;
            IdeAutorizacionCab = pIdeAutorizacionCab;
            DscTextoAutorizacion = pDscTextoAutorizacion;
            DscRespuesta = pDscRespuesta;
        }

        public MdsynAutorizacionCuestionariosDetE(int pIdeAutorizacionDet, int pIdeAutorizacionCab, string pDscTextoAutorizacion, string pDscRespuesta, int pI, string pCodTipoCuestionario)
        {
            IdeAutorizacionDet = pIdeAutorizacionDet;
            IdeAutorizacionCab = pIdeAutorizacionCab;
            DscTextoAutorizacion = pDscTextoAutorizacion;
            DscRespuesta = pDscRespuesta;
            i = pI;
            CodTipoCuestionario = pCodTipoCuestionario;
        }
    }
}
