using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public class ProjectViewModel
    {
        public int CodProject { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int State { get; set; }

    }
}
