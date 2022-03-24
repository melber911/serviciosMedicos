using Dat.Sql.ClinicaAD.UsuarioAD;
using Ent.Sql;
using Ent.Sql.ClinicaE.UsuariosE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus.Clinica.Clinica
{
    public class Seguridad
    {
        private SeguridadAD objSeguridadDL;

        public Seguridad(string ConStr)
        {
            objSeguridadDL = new SeguridadAD(ConStr);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public SeguridadE GetLogin(LoginE Login)
        {
            SeguridadE Security = objSeguridadDL.GetLogin(Login);

            if (Security != null)
            {
                if (Security.Estado != "X")
                {
                    TokenResponseE Token = objSeguridadDL.GetNewToken(Security.ide_usuario, (int)Enums.TokenType.LOGIN);
                    Security.TokenCode = Token.TokenCode;
                }
            }
            return Security;
        }
    }
}
