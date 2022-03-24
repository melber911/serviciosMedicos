using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ent.Sql.ClinicaE.MedicosE;
using Dat.Sql.ClinicaAD.MedicosAD;
using Ent.Sql.ClinicaE.Mantenimiento;

namespace Bus.Clinica
{
    public class Medicos : IDisposable
    {

        private MedicosAD objMedicosAD;

        public Medicos(string ConStr)
        {
            objMedicosAD = new MedicosAD(ConStr);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public List<MedicosE> ConsultarMedicos(MedicosE objMedicosE)
        {
            List<MedicosE> oList = new List<MedicosE>();
            oList =  objMedicosAD.Sp_Medicos_Consulta(objMedicosE);
            return oList;
        }

        public bool ActualizarMedicoxCampo(MedicosE objMedicosE)
        {
            bool xResult = false;

            xResult = objMedicosAD.Sp_Medicos_Update(objMedicosE);

            return xResult;
        }

        public bool ActualizarMedicosAgendamiento(MedicosE objMedicosE)
        {
            bool xResult = false;
            xResult = objMedicosAD.Sp_Medicos_Update_Agendamiento(objMedicosE);
            return xResult;
        }

        public bool GuardarMedicosMantenimiento(MedicoContratoRequestE objMedicosE)
        {
            bool xResult = false;
            xResult = objMedicosAD.GuardarMedicosMantenimiento(objMedicosE);
            return xResult;
        }

    }
}