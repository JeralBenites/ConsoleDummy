using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDummy
{
    public class RespuestaHttp
    {
        public HttpResponseMessage RespuestaOriginal { get; set; }
        public bool Ok { get; set; }
        public string Resultado { get; set; }
        public Exception Exception { get; set; }
    }
}
