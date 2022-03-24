using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Sql.ClinicaE.HospitalE
{
    public class HospitalAdmisionE
    {
        public string Codatencion { get; set; } = "";
        public string Codtipo { get; set; } = "";
        public string Nombre { get; set; } = "";
        public string Tipdocidentidad { get; set; } = "";
        public string Docidentidad { get; set; } = "";
        public string Telefono { get; set; } = "";
        public string ApellidoPat { get; set; } = "";
        public string ApellidoMat { get; set; } = "";
        public string Correo { get; set; } = "";
        public string Flagcorreo { get; set; } = "";
        public DateTime Fecharegistro { get; set; } = DateTime.Now;
        public DateTime Fechamodificacion { get; set; } = DateTime.Now;
        public DateTime Fecharespuestavalidacion { get; set; } = DateTime.Now;
        public string Nombres { get; set; } = "";
        // ---     EXTENSIONES    ---
        public string NuevoValor { get; set; } = "";
        public string Campo { get; set; } = "";
        public int Orden { get; set; } = 0;


        public HospitalAdmisionE()
        {
        }

        public HospitalAdmisionE(string pCodatencion)
        {
            Codatencion = pCodatencion;
        }

        public HospitalAdmisionE(string pCodatencion, string pNuevoValor, string pCampo)
        {
            Codatencion = pCodatencion;
            NuevoValor = pNuevoValor;
            Campo = pCampo;
        }

        public HospitalAdmisionE(string pCodatencion, string pCodTipo, string pNuevoValor, string pCampo)
        {
            Codatencion = pCodatencion;
            NuevoValor = pNuevoValor;
            Campo = pCampo;
            Codtipo = pCodTipo;
        }
    }
}
