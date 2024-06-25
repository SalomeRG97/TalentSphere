using System;
using System.Collections.Generic;

namespace Admin.Entities.Models;

public partial class Empleado
{
    public int Id { get; set; }

    public int TipoDocumento { get; set; }

    public string NumeroDocumento { get; set; } = null!;

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string CorreoPersonal { get; set; } = null!;

    public string CorreoEmpresarial { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public long Telefono { get; set; }

    public long ContactoEmergencia { get; set; }

    public long TelefonoContactoEmergencia { get; set; }

    public string Guid { get; set; } = null!;

    public DateTime Created { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public DateTime ModifiedDate { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<ContratosLaborale> ContratosLaborales { get; set; } = new List<ContratosLaborale>();
}
