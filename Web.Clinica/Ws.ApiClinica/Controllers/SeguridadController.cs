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
    public class SeguridadController : ControllerBase
    {
        private readonly IConfiguration Configuration;
        private readonly ILogger Logger;
        private Seguridad objSeguridadBL;
        public SeguridadController(IConfiguration IConfiguration, ILoggerFactory LoggerFactory)
        {
            Configuration = IConfiguration;
            Logger = LoggerFactory.CreateLogger<SeguridadController>();
            objSeguridadBL = new Seguridad(Configuration["ConnectionStrings:CLINICA"]);
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginE model)
        {
            try
            {
                Logger.LogWarning("Ingreso");

                GenericoE response = new GenericoE();
                SeguridadE Security = objSeguridadBL.GetLogin(model);

                if (Security != null)
                {
                    if (Security.Estado!="A")
                    {
                        response.code = (int)Enums.eCodeError.VAL;
                        response.message = "El Usuario Se Encuentra Bloqueado";
                    }
                    else
                    {
                        response.code = (int)Enums.eCodeError.OK;
                        response.message = "Acceso Correcto";
                        response.data = Security.TokenCode;
                    }
                }
                else
                {
                    response.code = (int)Enums.eCodeError.ERROR;
                    response.message = "Usuario o clave Incorrectos";
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                Logger.LogWarning(ex.Message);
                Logger.LogError(ex.Message);
                throw;
            }
        }


    }
}
