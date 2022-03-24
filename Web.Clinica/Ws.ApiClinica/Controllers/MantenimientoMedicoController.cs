using Bus.Clinica;
using Ent.Sql;
using Ent.Sql.ClinicaE.Mantenimiento;
using Ent.Sql.ClinicaE.UsuariosE;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace Ws.ApiClinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MantenimientoMedicoController : ControllerBase
    {

        private readonly IConfiguration Configuration;
        private readonly ILogger Logger;
        private Medicos objMedicos;

        public MantenimientoMedicoController(IConfiguration IConfiguration, ILoggerFactory LoggerFactory)
        {
            Configuration = IConfiguration;
            Logger = LoggerFactory.CreateLogger<MantenimientoMedicoController>();
            objMedicos = new Medicos(Configuration["ConnectionStrings:CLINICA"]);
        }

        [HttpPost]
        [Route("GuardarMedicosMantenimiento")]
        public IActionResult GuardarMedicosMantenimiento(MedicoContratoRequestE objMedicosE)
        {
            try
            {
                GenericoE response = new GenericoE();
                var valor = objMedicos.GuardarMedicosMantenimiento(objMedicosE);

                if (valor == true)
                {
                    response.code = (int)Enums.eCodeError.OK;
                    response.message = "Se Guardo Correctmante";
                }
                else
                {
                    response.code = (int)Enums.eCodeError.VAL;
                    response.message = "Ocurrio un error al intentar guardar";
                }
                return Ok(response);

            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                throw ex;
            }
        }


    }
}
