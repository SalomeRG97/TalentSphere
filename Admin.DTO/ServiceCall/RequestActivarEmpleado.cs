using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.DTO.ServiceCall
{
    public class RequestActivarEmpleado
    {
        public string NumeroDocumento { get; set; }
        public string CorreoEmpresarial { get; set; }
        public int CargoId { get; set; }

    }
}
