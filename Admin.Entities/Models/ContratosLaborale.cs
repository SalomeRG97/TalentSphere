using System;
using System.Collections.Generic;

namespace Admin.Entities.Models;

public partial class ContratosLaborale
{
    public int Id { get; set; }

    public int EmpleadoId { get; set; }

    public int ServicioId { get; set; }

    public int CargoId { get; set; }

    public decimal Salario { get; set; }

    public int Arlid { get; set; }

    public int FondoPensionId { get; set; }

    public int Epsid { get; set; }

    public int TipoContratoId { get; set; }

    public DateTime FechaIngreso { get; set; }

    public DateTime? FechaSalida { get; set; }

    public string? HojaVidaRef { get; set; }

    public string? SoportesRef { get; set; }

    public virtual Arl Arl { get; set; } = null!;

    public virtual Cargo Cargo { get; set; } = null!;

    public virtual Empleado Empleado { get; set; } = null!;

    public virtual Ep Eps { get; set; } = null!;

    public virtual FondosPensione FondoPension { get; set; } = null!;

    public virtual Servicio Servicio { get; set; } = null!;

    public virtual TiposContrato TipoContrato { get; set; } = null!;
}
