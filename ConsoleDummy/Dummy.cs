using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDummy
{
    public class Dummy
    {
        public int id { get; set; }
        public string name { get; set; }
        public string document_number { get; set; }
        public decimal salary { get; set; }
        public int age { get; set; }
        public string profile { get; set; }
        public string address { get; set; }
        public string phone_number { get; set; }
    }
    public class DummyDto
    {
        public int id { get; set; }
        public string employee_name { get; set; }
        public decimal employee_salary { get; set; }
        public int employee_age { get; set; }
        public string profile_image { get; set; }
    }
    public class Respuesta
    {
        public string status { get; set; }
        public ICollection<DummyDto> data { get; set; }
    }
}
