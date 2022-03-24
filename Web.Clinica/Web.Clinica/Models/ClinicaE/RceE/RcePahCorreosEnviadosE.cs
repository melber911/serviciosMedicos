using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Sql.ClinicaE.RceE
{
    public class RcePahCorreosEnviadosE
    {
        private int _IdeCorreoEnviado = 0;
        public int IdeCorreoEnviado
        {
            get
            {
                return _IdeCorreoEnviado;
            }
            set
            {
                _IdeCorreoEnviado = value;
            }
        }

        private string _CodAtencion = "";
        public string CodAtencion
        {
            get
            {
                return _CodAtencion;
            }
            set
            {
                _CodAtencion = value;
            }
        }

        private string _DscEmail = "";
        public string DscEmail
        {
            get
            {
                return _DscEmail;
            }
            set
            {
                _DscEmail = value;
            }
        }

        private string _DscTelefono = "";
        public string DscTelefono
        {
            get
            {
                return _DscTelefono;
            }
            set
            {
                _DscTelefono = value;
            }
        }

        private int _UsrEnvio = 0;
        public int UsrEnvio
        {
            get
            {
                return _UsrEnvio;
            }
            set
            {
                _UsrEnvio = value;
            }
        }

        private DateTime _FecEnvio = DateTime.Now;
        public DateTime FecEnvio
        {
            get
            {
                return _FecEnvio;
            }
            set
            {
                _FecEnvio = value;
            }
        }

        // ---     EXTENSIONES    ---
        private string _NuevoValor = "";
        public string NuevoValor
        {
            get
            {
                return _NuevoValor;
            }
            set
            {
                _NuevoValor = value;
            }
        }

        private string _Campo = "";
        public string Campo
        {
            get
            {
                return _Campo;
            }
            set
            {
                _Campo = value;
            }
        }

        private int _Orden = 0;
        public int Orden
        {
            get
            {
                return _Orden;
            }
            set
            {
                _Orden = value;
            }
        }

        // Public Property DscMail As String
        public int MailItemId { get; set; }
        public string IdePrimary { get; set; } = "";
        public string RutaArchivoAdjunto { get; set; } = "";


        public RcePahCorreosEnviadosE()
        {
        }

        public RcePahCorreosEnviadosE(int pOrden, string pCodAtencion, string pRutaArchivoAdjunto, int pMailItemId, string pIdePrimary)
        {
            Orden = pOrden;
            CodAtencion = pCodAtencion;
            RutaArchivoAdjunto = pRutaArchivoAdjunto;
            MailItemId = pMailItemId;
            IdePrimary = pIdePrimary;
        }

        public RcePahCorreosEnviadosE(int pIdeCorreEnviado, string pCodAtencion, int pUsrEnvio, string pDscMail, string pDscTelefono, int pMailItemId)
        {
            IdeCorreoEnviado = pIdeCorreEnviado;
            CodAtencion = pCodAtencion;
            UsrEnvio = pUsrEnvio;
            DscEmail = pDscMail;
            DscTelefono = pDscTelefono;
            MailItemId = pMailItemId;
        }
    }
}
