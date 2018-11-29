using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SistemaVenta.Models
{
    public class LoginViewModels
    {
        //Esta libreria es Microsoft.AspNetCore.Mvc;
        [BindProperty]
        public inputModel input { get; set; }
        [TempData]
        public string ErrorMessaje { get; set; }
        public class inputModel
        {
            //estos coddigo o validacion se hacen con la libreria using System.ComponentModel.DataAnnotations;
            [Required(ErrorMessage = "<font Color='Red'>El Correo Eletronico Es Obligatorio</font>")]
            [EmailAddress(ErrorMessage = "<font Color='Red'>El Correo Eletronico No Es Valido</font>")]
            public string Email { get; set; }
            [Required(ErrorMessage ="<font color='Red'>La contrasena es Obligatoria</font>")]
            [DataType(DataType.Password)]
            [StringLength(100, ErrorMessage ="<font color='Red'>El Numero de Caracteres {0} debe ser al menos {2} </font>",MinimumLength = 6)]
            public string Password { get; set; }
        }
    }
}
