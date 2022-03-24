
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus.Utilities
{
    public static class Json
    {

        /// <summary>
        ///     ''' Consumir el servicio web.
        ///     ''' </summary>
        ///     ''' <param name="Url">Url del método</param>
        ///     ''' <param name="StringJsonBody">Cuerpo Json del string, en caso no desee enviar utilizar el formato JSON enviar vacio.</param>
        ///     ''' <param name="parametros">Parametros del método a consumir, puede ser parametros del Header y Body</param>
        ///     ''' <returns></returns>
        public static string MethodPostSignature(string Url, string StringJsonBody, params Parameters[] parametros)
        {
            
            RestClient Client = new RestClient(Url);
            RestRequest Request = new RestRequest();

            Request.Method = Method.Post;

            // Cargar los request del header
            for (int i = 0; i <= parametros.LongLength - 1; i++)
            {
                if (parametros[i].Tipo == TipoFormat.Header)
                    Request.AddHeader(parametros[i].Key, parametros[i].Value);
            }

            // Cargar los request del body.
            for (int i = 0; i <= parametros.LongLength - 1; i++)
            {
                if (parametros[i].Tipo == TipoFormat.Body)
                    Request.AddParameter(parametros[i].Key, parametros[i].Value);
            }

            // StringJsonBody = stringBody()
            if (Url.IndexOf("https") >= 0)
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

            Request.AddParameter("application/json", StringJsonBody, ParameterType.RequestBody);

            //IRestResponse response = Client.Execute(Request);
            RestResponse response = Client.ExecuteAsync(Request).Result;
            // Client = Nothing
            // Request = Nothing            
            return response.Content;
        }

        /// <summary>
        ///     ''' Método para invocar de manera simple a los servicios web en Json
        ///     ''' </summary>
        ///     ''' <param name="Url">Url del método incluido el método a invocar</param>
        ///     ''' <param name="parametros">Parametros del método, esto es </param>
        ///     ''' <returns></returns>
        public static string MethodPost(string Url, params Parameters[] parametros)
        {
            RestClient oRestClient = new RestClient(Url);
            RestRequest oRestRequest = new RestRequest();
            oRestRequest.Method = Method.Post;

            for (int i = 0; i <= parametros.LongLength - 1; i++)
                oRestRequest.AddParameter(parametros[i].Key, parametros[i].Value);



            var response = oRestClient.ExecuteAsync(oRestRequest).Result; //.Execute(oRestRequest);            
            oRestClient = null;
            oRestRequest = null;
            return response.Content;
        }

        /// <summary>
        ///     ''' Consumir el servicio web.
        ///     ''' </summary>
        ///     ''' <param name="TypeMethodJson">Ingresar tipo de metodo Json</param>
        ///     ''' <param name="Url">Url del método</param>
        ///     ''' <param name="StringJsonBody">Cuerpo Json del string, en caso no desee enviar utilizar el formato JSON enviar vacio.</param>
        ///     ''' <param name="parametros">Parametros del método a consumir, puede ser parametros del Header y Body</param>
        ///     ''' <returns></returns>
        public static string MethodSignature(MethodJson TypeMethodJson, string Url, string StringJsonBody, bool ValidarCertificado, params Parameters[] parametros)
        {
            Method TypeMethod = getMethod(TypeMethodJson);
            RestClient Client = new RestClient(Url);
            RestRequest Request = new RestRequest(Url, TypeMethod);

            // Cargar los request del header
            for (int i = 0; i <= parametros.LongLength - 1; i++)
            {
                if (parametros[i].Tipo == TipoFormat.Header)
                    Request.AddHeader(parametros[i].Key, parametros[i].Value);
            }

            // Cargar los request del body.
            for (int i = 0; i <= parametros.LongLength - 1; i++)
            {
                if (parametros[i].Tipo == TipoFormat.Body)
                    Request.AddParameter(parametros[i].Key, parametros[i].Value);
            }

            // StringJsonBody = stringBody()
            if (Url.IndexOf("https") >= 0)
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

            if (ValidarCertificado == false)
                System.Net.ServicePointManager.ServerCertificateValidationCallback = null;
            // (object se, System.Security.Cryptography.X509Certificates.X509Certificate cert, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslerror) => true;

            Request.AddParameter("application/json", StringJsonBody, ParameterType.RequestBody);

            //IRestResponse response = Client.Execute(Request);
            RestResponse response = Client.ExecuteAsync(Request).Result;
            Client = null;
            Request = null;
            return response.Content;
        }

        public static string Pacs(string wUser, string wPass, string wIdPatient, string wOrden)
        {
            string wLink = "https://pacs.clinicasanfelipe.com/portal/default.aspx?urltoken=";
            string Url = "https://pacs.clinicasanfelipe.com/CSPublicQueryService/CSPublicQueryService.svc/json/EncryptQS?";
            string Params = "user_name=%U&password=%P&patient_id=%H&accession_number=%O";

            Params = (Params + "").Replace("%U", wUser);//Strings.Replace(Strings.Trim(Params + ""), "%U", wUser, 1);
            Params = (Params + "").Replace("%P", wPass);
            Params = (Params + "").Replace("%O", wOrden);
            Params = (Params + "").Replace("%H", wIdPatient);

            var client = new RestClient(Url + Params);
            var request = new RestRequest();
            request.Method = Method.Post;

            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");

            request.AddParameter("application/json", "\"user_name=" + wUser + "&password=" + wPass + "&patient_id=" + wIdPatient + "&accession_number=" + wOrden + "\"", ParameterType.RequestBody);

            //IRestResponse response = client.ExecuteAsync(request).Wait;
            var response = client.ExecuteAsync(request).Result;
            //response.Content = (response.Content + "") != "" ? response.Content : "";            
            wLink = wLink + response.Content.Substring(2, response.Content.Length - 2);    //Mid(response.Content, 2, Len(response.Content.len) - 2); // response.Content
            return wLink;
        }


        private static bool ValidateRemoteCertificate(object sender, System.Security.Cryptography.X509Certificates.X509Certificate cert, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors policyErrors)
        {
            bool result = false;

            if (cert.Subject.ToUpper().Contains("YourServerName"))
                result = true;

            return result;
        }

        private static Method getMethod(MethodJson pTypeMethod)
        {
            Method xResult = Method.Get;
            switch (pTypeMethod)
            {
                case MethodJson.GET:
                    {
                        xResult = Method.Get;
                        break;
                    }

                case MethodJson.POST:
                    {
                        xResult = Method.Post;
                        break;
                    }
                case MethodJson.PUT:
                    {
                        xResult = Method.Put;
                        break;
                    }
                case MethodJson.DELETE:
                    {
                        xResult = Method.Delete;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return xResult;
        }

        public enum MethodJson
        {
            GET = 0,
            POST = 1,
            PUT = 2,
            DELETE = 3,
            HEAD = 4,
            OPTIONS = 5,
            PATCH = 6,
            MERGE = 7
        }

        public enum TipoFormat
        {
            Body = 1,
            Header = 2
        }
        public class Parameters
        {
            public string Key { get; set; } = "";
            public string Value { get; set; } = "";
            public TipoFormat Tipo { get; set; }

            public Parameters()
            {
            }

            public Parameters(string pKey, string pValue)
            {
                Key = pKey;
                Value = pValue;
            }

            public Parameters(string pKey, string pValue, TipoFormat pTipo)
            {
                Key = pKey;
                Value = pValue;
                Tipo = pTipo;
            }
        }
    }
}