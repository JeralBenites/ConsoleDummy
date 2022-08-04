using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleDummy
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string urlConsulta = "http://dummy.restapiexample.com/api/v1/employees";
            string urlBackend = "https://localhost:44335/api/Dummies";

            var helper = new Helper();

            var response = await helper.CallRestService(urlConsulta, string.Empty, Constante.GET); 
            
            if (!response.Ok)
                throw new ArgumentException("Servicio Dummy Respondio de forma Incorrecta");

            var listaDummy = JsonConvert.DeserializeObject<Respuesta>(response.Resultado);

            foreach (var item in listaDummy.data)
            {

                var usuario = DummyDto.dummyMap(item);
                var insert = await helper.CallRestService(urlBackend, JsonConvert.SerializeObject(usuario), Constante.POST); 
                
                if (!response.Ok)
                    throw new ArgumentException("No se pudo Insertar");

                var responseInsert = JsonConvert.DeserializeObject<Dummy>(response.Resultado);

            }

        }
    }
}
