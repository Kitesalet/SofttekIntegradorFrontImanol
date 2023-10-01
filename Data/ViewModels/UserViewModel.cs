using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "El campo de Nombre es requerido!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo de Dni es requerido!")]
        public int Dni { get; set; }

        [Required(ErrorMessage = "El campo de Password es requerido!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "El campo de Tipo es requerido!")]
        public int Type { get; set; }

        public int CodUser { get;set; }


    }
}
