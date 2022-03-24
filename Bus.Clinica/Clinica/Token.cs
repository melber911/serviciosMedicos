using Dat.Sql.ClinicaAD.UsuarioAD;
using Ent.Sql.ClinicaE.UsuariosE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus.Clinica.Clinica
{
    public class Token
    {
        private TokenAD objTokenDL;
        public Token (string ConStr)
        {
            objTokenDL = new TokenAD(ConStr);
        }
        public void Disponse()
        {
            GC.SuppressFinalize(this);
        }
        public UsuarioE GetUserByToken(TokenRequestE Token)
        {
            return objTokenDL.GetUserByToken(Token);
        }

        public List<ListaPortalTablasE> GetPortalTablas()
        {
            return objTokenDL.GetPortalTablas();
        }
    }
}
