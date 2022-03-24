using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

[assembly: ClassInterface(System.Runtime.InteropServices.ClassInterfaceType.None)]

// Creamos las interfaces que seran llamadas desde vb 6.0, tanto propiedades, 
// funciones, metodos o lo que necesitemos
public interface IDll
{
    Bus.Utilities.Apis.ResponseRuc GetRuc(string Ruc, string Url = "");
    string GetRucDeserializado(string Ruc, string Url = "");
}

namespace Bus.Utilities
{
    public class Apis : IDll
    {
        public Apis()
        {
        }

        public ResponseRuc PostRuc(string Ruc, string Url = "")
        {
            ResponseRuc? oResponseRuc = new ResponseRuc();

            string WsUrl = (Url.Trim() == "" ? "https://api.sunat.cloud/ruc/{ruc}" : Url);
            WsUrl = WsUrl.Replace("{ruc}", Ruc);

            string rpta = Json.MethodSignature(Json.MethodJson.GET, WsUrl, "", false, new Json.Parameters("accept", "application/json", Json.TipoFormat.Header));

            oResponseRuc = JsonSerializer.Deserialize<ResponseRuc>(rpta);

            return oResponseRuc;
        }

        public ResponseRuc GetRuc(string Ruc, string Url = "")
        {
            string WsUrl = (Url.Trim() == "" ? "https://api.migo.pe/api/v1/ruc" : Url);
            // WsUrl = WsUrl.Replace("{ruc}", Ruc)

            string rpta = Json.MethodSignature(Json.MethodJson.POST, WsUrl, "{\"token\":\"2PtUfsQGQzjP92jgUnxakaNWrvW3pLdn0SlAuwry1XxBjLPFni3Zq3r17KvL\", \"ruc\":\"" + Ruc + "\"}", false, new Json.Parameters("accept", "application/json", Json.TipoFormat.Header));

            ResponseRuc? oResponseRuc = JsonSerializer.Deserialize<ResponseRuc>(rpta);

            return oResponseRuc;
        }


        private ResponseRuc IDll_GetRuc(string Ruc, string Url = "")
        {
            throw new NotImplementedException();
        }

        public string GetRucDeserializado(string Ruc, string Url = "")
        {
            // Dim oResponseRuc As New ResponseRuc
            string WsUrl = (Url.Trim() == "" ? "https://api.sunat.cloud/ruc/{ruc}" : Url);

            string rpta = Json.MethodSignature(Json.MethodJson.GET, WsUrl.Replace("{ruc}", Ruc), "", false, new Json.Parameters("accept",
                                                                                                                                "application/json",
                                                                                                                                Json.TipoFormat.Header));

            return rpta;
        }

        private string IDll_GetRucDeserializado(string Ruc, string Url = "")
        {
            throw new NotImplementedException();
        }

        public class ResponseRuc
        {
            public bool success { get; set; }
            public string ruc { get; set; } = "";
            public string nombre_o_razon_social { get; set; } = "";
            public string estado_del_contribuyente { get; set; } = "";
            public string condicion_de_domicilio { get; set; } = "";
            public string ubigeo { get; set; } = "";
            public string tipo_de_via { get; set; } = "";
            public string nombre_de_via { get; set; } = "";
            public string codigo_de_zona { get; set; } = "";
            public string tipo_de_zona { get; set; } = "";
            public string numero { get; set; } = "";
            public string interior { get; set; } = "";
            public string lote { get; set; } = "";
            public string dpto { get; set; } = "";
            public string manzana { get; set; } = "";
            public string kilometro { get; set; } = "";
            public string distrito { get; set; } = "";
            public string provincia { get; set; } = "";
            public string departamento { get; set; } = "";
            public string direccion { get; set; } = "";
            public string actualizado_en { get; set; } = "";
        }
    }
}