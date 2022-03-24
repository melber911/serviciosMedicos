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
    public class TokenAD
    {
        private string ConStr;
        public TokenAD(string ConStr)
        {
            this.ConStr = ConStr;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public UsuarioE GetUserByToken(TokenRequestE Token)
        {
            UsuarioE Entity = null;

            using (var Ado = new SQLServer(ConStr))
            {
                var Parameters = new SqlParameter[]
                {
                    new SqlParameter{ParameterName="@TokenCode",SqlDbType=SqlDbType.VarChar,Size=50,SqlValue=Token.TokenCode},
                    new SqlParameter{ParameterName="@TokenType",SqlDbType=SqlDbType.Int,SqlValue=Token.TokenType}
                };
                var Dr = Ado.ExecDataReader("usp_GetUserByToken @TokenCode,@TokenType ", Parameters);

                if (!Dr.HasRows)
                {
                    return Entity;
                }

                while (Dr.Read())
                {
                    Entity = new UsuarioE();
                    //Entity.UserCode = Convert.ToString(Dr["UsuarioCodeGuid"]);
                    Entity.UserCode = Convert.ToString(Dr["TokenCodeGuid"]);
                    Entity.Login = (string)Dr["dsc_login"];
                    Entity.Fullname = (string)Dr["dsc_nombres"];
                    //Entity.DocumentType = Convert.ToInt32(Dr["TipoDocumento"]);
                    //Entity.DocumentNumber = (string)Dr["DocumentoIdentidad"];
                    Entity.Email = (string)Dr["dsc_email"];
                    Entity.ProfileId = (int)Dr["cod_perfil"];
                    Entity.Status = Convert.ToString(Dr["std_usuario"]);
                    Entity.IdUsuario = (decimal)Dr["ide_usuario"];
                    //Entity.Sexo = (string)Dr["sexo"]; ;
                    break;
                }
                Dr.Close();
            }
            return Entity;
        }


        public List<ListaPortalTablasE> GetPortalTablas()
        {
            using (var Ado = new SQLServer(ConStr))
            {
                try
                {
                    List<ListaPortalTablasE> List = new List<ListaPortalTablasE>();
                    var Dr = Ado.ExecDataReaderProc("sp_Get_PotalTablas", null);
                    {
                        if (!Dr.HasRows) 
                        { 
                            return List; 
                        }
                        while (Dr.Read())
                        {
                            var Entity = new ListaPortalTablasE();

                            if (Dr["Id"] != DBNull.Value) { Entity.Id = (int)Dr["Id"]; }
                            if (Dr["cod_tabla"] != DBNull.Value) { Entity.cod_tabla = (string)Dr["cod_tabla"]; }
                            if (Dr["nro_linea"] != DBNull.Value) { Entity.nro_linea = (string)Dr["nro_linea"]; }
                            if (Dr["dsc_nombre"] != DBNull.Value) { Entity.dsc_nombre = (string)Dr["dsc_nombre"]; }
                            if (Dr["dsc_nombre2"] != DBNull.Value) { Entity.dsc_nombre2 = (string)Dr["dsc_nombre2"]; }
                            if (Dr["flg_estado"] != DBNull.Value) { Entity.flg_estado = (string)Dr["flg_estado"]; }

                            List.Add(Entity);
                        }
                        return List;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }







    }
}
