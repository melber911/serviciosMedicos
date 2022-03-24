using Dat.Sql.ClinicaAD.OtrosAD;
using Ent.Sql.ClinicaE.OtrosE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus.Clinica
{
    public class Otros
    {
        public List<TablasE> ConsultarTablas(TablasE objTablasE)
        {
            List<TablasE> oList = new List<TablasE>();
            oList = new TablasAD().Sp_Tablas_Consulta(objTablasE);
            return oList;
        }
    }
}
