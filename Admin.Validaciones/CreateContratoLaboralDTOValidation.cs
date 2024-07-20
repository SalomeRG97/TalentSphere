using FluentValidation;
using Admin.DTO.Maestros;

namespace Admin.Validaciones
{
    public class CreateContratoLaboralDTOValidation : AbstractValidator<CreateContratoLaboralDTO>
    {
        public CreateContratoLaboralDTOValidation()
        {
            RuleFor(x => x.EmpleadoId).GreaterThan(0).WithMessage("El EmpleadoId debe ser mayor que 0.");

            RuleFor(x => x.ServicioId).GreaterThan(0).WithMessage("El ServicioId debe ser mayor que 0.");

            RuleFor(x => x.CargoId).GreaterThan(0).WithMessage("El CargoId debe ser mayor que 0.");

            RuleFor(x => x.Salario)
                .GreaterThan(0).WithMessage("El Salario debe ser mayor que 0.");

            RuleFor(x => x.Arlid).GreaterThan(0).WithMessage("El Arlid debe ser mayor que 0.");

            RuleFor(x => x.FondoPensionId).GreaterThan(0).WithMessage("El FondoPensionId debe ser mayor que 0.");

            RuleFor(x => x.Epsid).GreaterThan(0).WithMessage("El Epsid debe ser mayor que 0.");

            RuleFor(x => x.TipoContratoId).GreaterThan(0).WithMessage("El TipoContratoId debe ser mayor que 0.");
        }
    }
}
