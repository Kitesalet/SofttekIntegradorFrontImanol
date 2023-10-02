using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO
{
    public class UserUpdateDto
    {
        public int CodUser { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public string Password { get; set; }


    }
}
