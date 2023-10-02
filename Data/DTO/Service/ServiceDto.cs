using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO
{
    public class ServiceDto
    {
        public string Descr { get; set; }
        public bool State { get; set; }
        public decimal HourValue { get; set; }

        public int CodService { get; set; }

    }
}
