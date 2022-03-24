using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Sql.ClinicaE.DiagnosticoE
{
    public class DiagnosticoxHospitalE
    {
        public string Codatencion { get; set; } = "";
        public string Tipo { get; set; } = "";
        public string Coddiagnostico { get; set; } = "";
        public string Tipodiagnostico { get; set; } = "";
        public string Clasificaciondiagnostico { get; set; } = "";
        public DateTime FecRegistro { get; set; } = DateTime.Now;
        // ---     EXTENSIONES    ---
        public string NuevoValor { get; set; } = "";
        public string Campo { get; set; } = "";
        public int Orden { get; set; } = 0;


        public DiagnosticoxHospitalE() { }

        public DiagnosticoxHospitalE(string pCodatencion)
        { Codatencion = pCodatencion; }

        public DiagnosticoxHospitalE(string pCodatencion, string pTipo, string pCodDiagnostico)
        {
            Codatencion = pCodatencion;
            Tipo = pTipo;
            Coddiagnostico = pCodDiagnostico;
        }

        public DiagnosticoxHospitalE(string pCodatencion, string pTipo, string pCodDiagnostico, string pNuevoValor, string pCampo)
        {
            Codatencion = pCodatencion;
            NuevoValor = pNuevoValor;
            Campo = pCampo;
        }
    }
}
