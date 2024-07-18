using System;
using System.Collections.Generic;

namespace Admin.Entities.Models;

public partial class Ceco
{
    public int Id { get; set; }

    public string Nombre { get; set; }

    public virtual ICollection<Servicio> Servicios { get; set; } = new List<Servicio>();
}
