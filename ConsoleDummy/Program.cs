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
            string urlDummyInfo = "http://dummy.restapiexample.com/api/v1/employees";
            int port = 44335;
            string urlBackend = $"https://localhost:{port}/api/Dummies";

            var helper = new Helper();

            var response = await helper.CallRestService(urlDummyInfo, string.Empty, Constante.GET); 
            
            if (!response.Ok)
                Console.WriteLine("Servicio Dummy Respondio de forma Incorrecta");

            var listaDummy = JsonConvert.DeserializeObject<Respuesta>(response.Resultado);

            foreach (var item in listaDummy.data)
            {

                var dummyDTO = DummyDtoHelpers.dummyMap(item);
                var responseInsert = await helper.CallRestService(urlBackend, JsonConvert.SerializeObject(dummyDTO), Constante.POST); 
                
                if (!responseInsert.Ok)
                    Console.WriteLine($"No se pudo Insertar el registro con el ID {item.id}.");

                var dummy = JsonConvert.DeserializeObject<Dummy>(responseInsert.Resultado);
                
                if(dummy.id > 0)
                    Console.WriteLine($"Se Creo a {dummy.name}.");

            }

        }
    }
}
