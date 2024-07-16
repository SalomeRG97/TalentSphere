using System;
using System.Collections.Generic;

namespace Admin.Entities.Models;

public partial class Empleado
{
    public int Id { get; set; }

    public int TipoDocumento { get; set; }

    public string NumeroDocumento { get; set; }

    public string Nombres { get; set; }

    public string Apellidos { get; set; }

    public string CorreoPersonal { get; set; }

    public string CorreoEmpresarial { get; set; }

    public string Direccion { get; set; }

    public long Telefono { get; set; }

    public long ContactoEmergencia { get; set; }

    public long TelefonoContactoEmergencia { get; set; }

    public string Guid { get; set; }

    public DateTime Created { get; set; }

    public string ModifiedBy { get; set; }

    public DateTime ModifiedDate { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<ContratosLaborale> ContratosLaborales { get; set; } = new List<ContratosLaborale>();
}
