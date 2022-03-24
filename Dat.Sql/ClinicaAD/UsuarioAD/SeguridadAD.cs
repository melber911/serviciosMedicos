using Ent.Sql.ClinicaE.UsuariosE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dat.Sql.ClinicaAD.UsuarioAD
{
    public class SeguridadAD
    {
        private string ConStr;
        public SeguridadAD(string ConStr)
        {
            this.ConStr = ConStr;
        }
        public void Disponse()
        {
            GC.SuppressFinalize(this);

        }
        public SeguridadE GetLogin(LoginE Login)
        {
            var Entity = new SeguridadE();
            using (var Ado = new SQLServer(ConStr))
            {
                var Parameters = new SqlParameter[]
                {
                    new SqlParameter{ParameterName="@Login",SqlDbType=SqlDbType.VarChar,Size=50,SqlValue=Login.Login},
                    new SqlParameter{ParameterName="@Password",SqlDbType=SqlDbType.VarChar,Size=50,SqlValue=Login.Password}
                };

                var Dr = Ado.ExecDataReader("usp_login @Login, @Password", Parameters);

                if (!Dr.HasRows) 
                {
                    return null;
                }
                while (Dr.Read())
                {
                    Entity.IdPerfil = Convert.ToInt32(Dr["cod_perfil"]);
                    //Entity.UsuarioCodeGuid = Convert.ToString(Dr["UsuarioCodeGuid"]);
                    //Entity.UsuarioCodeGuid = Convert.ToString(Dr["sesion_web"]);
                    Entity.Login = Convert.ToString(Dr["dsc_login"]);
                    Entity.Password = Convert.ToString(Dr["dsc_clave"]);
                    Entity.NombreCompleto = Convert.ToString(Dr["dsc_nombres"]);
                    // Entity.TipoDocumento = Convert.ToInt32(Dr["TipoDocumento"]);
                    //Entity.DocumentoIdentidad = Convert.ToString(Dr["DocumentoIdentidad"]);
                    Entity.Email = Convert.ToString(Dr["dsc_email"]);
                    //Entity.Estado = Convert.ToBoolean(Dr["std_usuario"]);
                    Entity.Estado = Convert.ToString(Dr["std_usuario"]);
                    //Entity.Locked = (bool)Dr["Locked"];
                    Entity.ide_usuario = Convert.ToInt32(Dr["ide_usuario"]);
                    break;
                }
                Dr.Close();
            }
            return Entity;
        }

        public TokenResponseE GetNewToken(int ide_usuario, int Tokentype)
        {
            var Entity = new TokenResponseE();
            using (var Ado = new SQLServer(ConStr))
            {
                var Parameters = new SqlParameter[]
                {
                    new SqlParameter{ParameterName="@ide_usuario",SqlDbType=SqlDbType.Int,SqlValue=ide_usuario},
                    new SqlParameter{ParameterName="@TokenType",SqlDbType=SqlDbType.Int,SqlValue=Tokentype}
                };

                var Dr = Ado.ExecDataReader("usp_GetNewToken @ide_usuario,@TokenType", Parameters);

                if (!Dr.HasRows)
                {
                    return null;
                }

                while (Dr.Read())
                {
                    Entity.TokenCode = Convert.ToString(Dr["TokenCode"]);
                    break;
                }
                Dr.Close();
            }
            return Entity;
        }
    }
}
