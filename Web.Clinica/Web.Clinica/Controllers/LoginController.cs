using Bus.Utilities;
using Ent.Sql;
using Ent.Sql.ClinicaE.UsuariosE;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace SistemaSanFelipe.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IConfiguration Configuration;
        
        private readonly ILogger Logger;
        //private readonly IServiceCollection ServiceCollection;

        public LoginController(IConfiguration IConfiguration, ILoggerFactory LoggerFactory, IHostingEnvironment IHostingEnvironment/*, IServiceCollection services*/)
        {
         
            Configuration = IConfiguration;
            Logger = LoggerFactory.CreateLogger<LoginController>();
            GeneralModel.UrlWebApi = Configuration["Urls:UrlWebApi"];
            //ServiceCollection = services;
            //ServiceCollection.AddSession();
            //ServiceCollection.AddMvc();
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Validate(LoginE Request)
        {
            var Response = new ObjetoGenericoE();
            try
            {
                var Url = GeneralModel.UrlWebApi + "seguridad/Login";
                var Result = RestCliente.ProcessPostRequest(Url, Request);

                Response.data = Result;
                 
                var ResultJson = JsonConvert.SerializeObject(Response.data);
                var User = JsonConvert.DeserializeObject<GenericoE>(ResultJson);

                switch (User.code)
                {
                    case (int)Enums.eCodeError.OK:
                        var UrlUser = GeneralModel.UrlWebApi + "Usuario/GetUserDataByToken";
                        var ResultUser = RestCliente.ProcessGetRequest(UrlUser, User.data);
                        var ResultUserJson = JsonConvert.SerializeObject(ResultUser);
                        var UserData = JsonConvert.DeserializeObject<UsuarioE>(ResultUserJson);

                        HttpContext.Session.SetString("TOKEN", User.data);
                        HttpContext.Session.SetInt32("PROFILE_ID", UserData.ProfileId);
                        HttpContext.Session.SetString("USUARIO_ID", Convert.ToString(UserData.IdUsuario));
                        //HttpContext.Session.SetString("SEXO_ID", UserData.Sexo);
                        HttpContext.Session.SetString("LOGIN", UserData.Login);

                        break;
                    default:
                        Response.message = User.message;
                        break;
                }
            }
            catch (Exception ex)
            {
                Logger.LogWarning(ex, ex.Message);
                Response.message = ex.Message;
            }
            return  Json(Response);
        }


         
         

    }
}
