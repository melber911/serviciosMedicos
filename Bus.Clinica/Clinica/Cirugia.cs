using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ent.Sql.ClinicaE.CirugiaE;
using Dat.Sql.ClinicaAD.CirugiaAD;

namespace Bus.Clinica
{
    public class Cirugia
    {
        public List<RolSalaOperacionesE> Sp_RolSalaOperaciones3_Consulta(RolSalaOperacionesE pRolSalaOperaciones)
        {
            List<RolSalaOperacionesE> oList = new List<RolSalaOperacionesE>();
            oList = new RolSalaOperacionesAD().Sp_RolSalaOperaciones3_Consulta( pRolSalaOperaciones);
            return oList;
        }

        public List<RolSalaOperacionesE> Sp_RolSalaAdmisionHospitalaria_Consulta(RolSalaOperacionesE pRolSalaOperaciones)
        {
            List<RolSalaOperacionesE> oList = new List<RolSalaOperacionesE>();
            oList = new RolSalaOperacionesAD().Sp_RolSalaAdmisionHospitalaria_Consulta(pRolSalaOperaciones);
            return oList;
        }

    }
}