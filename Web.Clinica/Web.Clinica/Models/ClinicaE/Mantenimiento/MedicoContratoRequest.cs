using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Sql.ClinicaE.Mantenimiento
{
    public class MedicoContratoRequest
    {

        public string? cod_medico { get; set; }
        public string? cod_sede { get; set; }
        public string? flg_forma_pago { get; set; }
        public float mnt_mensual { get; set; }
        public DateTime fec_inicio { get; set; }
        public DateTime fec_fin { get; set; }

        public string? usr_registro { get; set; }
        public string? flg_estado { get; set; }

        public int UsuarioId { get; set; }
        

    }
}
