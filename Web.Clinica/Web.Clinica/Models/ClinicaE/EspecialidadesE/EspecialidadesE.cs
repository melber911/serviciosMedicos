using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Sql.ClinicaE.EspecialidadesE
{
    public class EspecialidadesE
    {
        public string Codespecialidad { get; set; } = "";
        public string Nombre { get; set; } = "";
        public bool Estado { get; set; } = false;
        public string Codgranespecialidad { get; set; } = "";
        public string Codsepsespecialidad { get; set; } = "";
        public string Codups { get; set; } = "";
        public string CodPrestacion { get; set; } = "";
        public string CodEspMedisyn { get; set; } = "";
        public string FlgTeleconsulta { get; set; } = "";

        // ---     EXTENSIONES    ---
        public string NuevoValor { get; set; } = "";
        public string Campo { get; set; } = "";
        public int Orden { get; set; } = 0;

        public string Buscar { get; set; } = "";
        public int Key { get; set; } = 0;
        public int NumeroLineas { get; set; } = 0;


        public EspecialidadesE()
        { }

        public EspecialidadesE(string pCodespecialidad)
        {
            Codespecialidad = pCodespecialidad;
        }

        public EspecialidadesE(string pCodespecialidad, string pNuevoValor, string pCampo)
        {
            Codespecialidad = pCodespecialidad;
            NuevoValor = pNuevoValor;
            Campo = pCampo;
        }

        public EspecialidadesE(string pBuscar, int pKey, int pNumeroLineas, int pOrden)
        {
            Buscar = pBuscar;
            Key = pKey;
            NumeroLineas = pNumeroLineas;
            Orden = pOrden;
        }
    }
}
