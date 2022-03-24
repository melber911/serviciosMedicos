using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Sql.ClinicaE.OtrosE
{
    public class SisCorreoE
    {
        public int Idcorreo { get; set; } = 0;
        public DateTime Fecharegistro { get; set; } = DateTime.Now;
        public string EnviarA { get; set; } = "";
        public string CopiarA { get; set; } = "";
        public string Copiarh { get; set; } = "";
        public string Asunto { get; set; } = "";
        public string Cuerpo { get; set; } = "";
        public string Archivo { get; set; } = "";
        public string Hostname { get; set; } = "";
        public string Username { get; set; } = "";
        public string Appname { get; set; } = "";
        public int Mailid { get; set; } = 0;
        public int Errorreturn { get; set; } = 0;
        // Extensiones
        public string NuevoValor { get; set; } = "";
        public string Campo { get; set; } = "";
        public int Orden { get; set; } = 0;
        public string PerfilName { get; set; } = "PostMaster";
        public string FormatoCuerpo { get; set; } = "HTML";
    }
}
