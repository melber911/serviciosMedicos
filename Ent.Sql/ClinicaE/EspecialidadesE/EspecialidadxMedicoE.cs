using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Sql.ClinicaE.EspecialidadesE
{
    public class EspecialidadxMedicoE
    {
        public string CodEspecialidad { get; set; } = "";
        public string CodMedico { get; set; } = "";
        public string RegistroEspecialidad { get; set; } = "";
        public string Especialidad { get; set; } = "";
        // ---     EXTENSIONES    ---

        public string NuevoValor { get; set; } = "";
        public string Campo { get; set; } = "";
        public int Orden { get; set; } = 0;

        public string Buscar { get; set; } = "";
        public string Key { get; set; } = "";
        public int NumeroLineas { get; set; } = 0;

        public EspecialidadxMedicoE()
        { }

        public EspecialidadxMedicoE(string pBuscar, string pKey, int pNumeroLineas, int pOrden)
        {
            Buscar = pBuscar;
            Key = pKey;
            NumeroLineas = pNumeroLineas;
            Orden = pOrden;
        }
    }
}
