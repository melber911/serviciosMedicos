using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ent.Sql.ClinicaE.EspecialidadesE;
using Dat.Sql.ClinicaAD.EspecialidadesAD;

namespace Bus.Clinica
{
    public class Especialidades
    {
        public List<EspecialidadxMedicoE> ConsultarEspecialidadxMedicos(EspecialidadxMedicoE objEspecialidadxMedico)
        {
            List<EspecialidadxMedicoE> oList = new List<EspecialidadxMedicoE>();
            oList = new EspecialidadxMedicoAD().Sp_EspecialidadxMed_Consulta(objEspecialidadxMedico);
            return oList;
        }
    }
}
