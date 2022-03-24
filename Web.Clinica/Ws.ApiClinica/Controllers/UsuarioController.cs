using Bus.Clinica.Clinica;
using Ent.Sql;
using Ent.Sql.ClinicaE.UsuariosE;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaSanFelipe.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IConfiguration Configuration;
        private readonly ILogger Logger;
        private Seguridad objSecurityBL;
        private Token objTokenBL;
        public UsuarioController(IConfiguration IConfiguration, ILoggerFactory LoggerFactory)
        {
            Configuration = IConfiguration;
            Logger = LoggerFactory.CreateLogger<UsuarioController>();
            objSecurityBL = new Seguridad(Configuration["ConnectionStrings:CLINICA"]);
            objTokenBL = new Token(Configuration["ConnectionStrings:CLINICA"]);
        }

        [HttpGet]
        [Route("GetUserDataByToken")]
        public IActionResult GetUserDataByToken()
        {
            try
            {
                //Obtener el Token
                string secretTokenName = "Auth-Token";
                var tokenCode = HttpContext.Request.Headers[secretTokenName].ToString();

                TokenRequestE Request = new TokenRequestE();
                Request.TokenCode = tokenCode;
                Request.TokenType = (int)Enums.TokenType.LOGIN;

                var Result = objTokenBL.GetUserByToken(Request);

                return Ok(Result);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpGet]
        [Route("GetPortalTablas")]
        public IActionResult GetPortalTablas()
        {
            
            try
            {
                //Obtener el Token
                string secretTokenName = "Auth-Token";
                var tokenCode = HttpContext.Request.Headers[secretTokenName].ToString();

                TokenRequestE Request = new TokenRequestE();
                Request.TokenCode = tokenCode;
                Request.TokenType = (int)Enums.TokenType.LOGIN;

                var Result = objTokenBL.GetPortalTablas();
                return Ok(Result);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
