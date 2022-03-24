using Bus.Utilities;
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
    public class MainController : Controller
    {
        private readonly IConfiguration Configuration;
        private readonly ILogger Logger;
        private readonly IHostingEnvironment HostingEnvironment;

        public MainController(IConfiguration IConfiguration, ILoggerFactory LoggerFactory, IHostingEnvironment IHostingEnvironment)
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

        public IActionResult BandejaComercial()
        {
            return View();
        }
        public IActionResult GetUserData()
        {
            var Response = new ObjetoGenericoE();
            try
            {
                var token = HttpContext.Session.GetString("TOKEN");
                var UrlUser = GeneralModel.UrlWebApi + "Usuario/GetUserDataByToken";

                var ResultUser = RestCliente.ProcessGetRequest(UrlUser, token);

                var ResultUserJson = JsonConvert.SerializeObject(ResultUser);
                var UserData = JsonConvert.DeserializeObject<UserE>(ResultUserJson);
                Response.data = UserData;


            }
            catch (Exception ex)
            {
                Logger.LogWarning(ex, ex.Message);
                Response.message = ex.Message;
            }
            return Ok(Response);
        }

         
        [HttpGet]
        public IActionResult GetPortalTablas()
        {
            var Response = new ObjetoGenericoE();
            try
            {
                var token = HttpContext.Session.GetString("TOKEN");
                var UrlUser = GeneralModel.UrlWebApi + "Usuario/GetPortalTablas";

                var ResultUser = RestCliente.ProcessGetRequest(UrlUser, token);

                //var ResultJson = JsonConvert.SerializeObject(ResultUser);
                //var UserData = JsonConvert.DeserializeObject<ListaPortalTablasE>(ResultJson);
                Response.data = ResultUser;


            }
            catch (Exception ex)
            {
                Logger.LogWarning(ex, ex.Message);
                Response.message = ex.Message;
            }
            return Ok(Response);
        }

    }
}
