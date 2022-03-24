using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Oracle.MedisynE.PacientesE
{
    public class TabPacienteE
    {
        // p.id_ambulatorio, x.id_grupo_familiar, p.vigencia, x.vigencia
        public string IdAmbulatorio { get; set; }= "";
        public string Vigencia { get; set; }= "";


        public string UserW_IdGrupoFamiliar { get; set; }= "";
        public string UserW_Vigencia { get; set; }= "";
        public string UserW_CodParentesco { get; set; }= "";
        public string UserW_DscParentesco { get; set; }= "";
    }
}
