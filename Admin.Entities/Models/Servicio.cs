using System;
using System.Collections.Generic;

namespace Admin.Entities.Models;

public partial class Servicio
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int Cecoid { get; set; }

    public virtual Ceco Ceco { get; set; } = null!;

    public virtual ICollection<ContratosLaborale> ContratosLaborales { get; set; } = new List<ContratosLaborale>();
}
