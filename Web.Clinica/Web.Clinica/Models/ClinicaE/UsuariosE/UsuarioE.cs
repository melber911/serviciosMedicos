using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent.Sql.ClinicaE.UsuariosE
{
    public class UsuarioE
    {
        public string? UserCode { get; set; }
        public string? Login { get; set; }
        public string? Fullname { get; set; }
        public int DocumentType { get; set; }
        public string? DocumentNumber { get; set; }
        public string? Email { get; set; }
        public int ProfileId { get; set; }
        public string? Status { get; set; }
        public decimal IdUsuario { get; set; }
        public string? Sexo { get; set; }
    }
}
