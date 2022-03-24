using Bus.Utilities;
using Ent.Sql.ClinicaE.Mantenimiento;
using Ent.Sql.ClinicaE.UsuariosE;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace SistemaSanFelipe.Web.Controllers
{
    public class MantenimientoController : Controller
    {
        private readonly IConfiguration Configuration;
        private readonly ILogger Logger;
        private readonly IHostingEnvironment HostingEnvironment;

        public MantenimientoController(IConfiguration IConfiguration, ILoggerFactory LoggerFactory, IHostingEnvironment IHostingEnvironment)
        {
            HostingEnvironment = IHostingEnvironment;
            Configuration = IConfiguration;
            Logger = LoggerFactory.CreateLogger<MainController>();
            GeneralModel.UrlWebApi = Configuration["Urls:UrlWebApi"];
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GuardarMedicosContrato (MedicoContratoRequest request)
        {
            var Response = new ObjetoGenericoE();
            try
            {
       
                var IdUsuario = HttpContext.Session.GetString("LOGIN");
                request.usr_registro = IdUsuario;   
                request.cod_sede ="001";
             
   
                var Url = GeneralModel.UrlWebApi + "MantenimientoMedico/GuardarMedicosMantenimiento";
                var Result = RestCliente.ProcessPostRequest(Url, request);
                Response.data = Result;

                //var ResultJson = JsonConvert.SerializeObject(Response.data);
                //var User = JsonConvert.DeserializeObject<GenericoE>(ResultJson);
            }
            catch (Exception ex)
            {
                Logger.LogWarning(ex, ex.Message);
                Response.message = ex.Message;
            }
            return Json(Response);
        }



    }
}
