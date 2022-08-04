using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDummy
{
    public class Helper
    {
        public async Task<RespuestaHttp> CallRestService(string url, string body , string method)
        {
            try
            {
                HttpResponseMessage response;
                using HttpClient client = new();
                switch (method)
                {
                    case Constante.PUT:
                        response = await client.PutAsync(url, new StringContent(body, Encoding.UTF8, "application/json"));
                        break;
                    case Constante.POST:
                        response = await client.PostAsync(url, new StringContent(body, Encoding.UTF8, "application/json"));
                        break;
                    case Constante.GET:
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        response = await client.GetAsync(url);
                        break;
                    default:
                        throw new ArgumentException("No se ha ingreso un método correcto para la solicitud HTTP o es un método no implementado");
                }

                return new RespuestaHttp
                {
                    RespuestaOriginal = response,
                    Resultado = response.IsSuccessStatusCode ? await response.Content.ReadAsStringAsync() : "",
                    Ok = response.IsSuccessStatusCode
                };
            }
            catch (Exception exception)
            {
                return new RespuestaHttp
                {
                    Exception = exception,
                    Resultado = exception.ToString(),
                    Ok = false
                };
            }
        }
    }
    public class Constante
    {

        //CONSTANTES
        public const string POST = "POST";
        public const string GET = "GET";
        public const string PUT = "PUT";
        public const string DELETE = "DELETE";


    }
}
