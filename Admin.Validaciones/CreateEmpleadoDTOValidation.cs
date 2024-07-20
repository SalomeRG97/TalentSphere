using FluentValidation;
using Admin.DTO.Maestros;

namespace Admin.Validaciones
{
    public class CreateEmpleadoDTOValidation : AbstractValidator<CreateEmpleadoDTO>
    {
        public CreateEmpleadoDTOValidation()
        {

            RuleFor(x => x.TipoDocumento).InclusiveBetween(1, 5).WithMessage("El TipoDocumento debe estar entre 1 y 4.");

            RuleFor(x => x.NumeroDocumento)
                .NotEmpty().WithMessage("El NumeroDocumento no puede estar vacío.")
                .Length(6, 20).WithMessage("El NumeroDocumento debe tener entre 6 y 20 caracteres.");

            RuleFor(x => x.Nombres)
                .NotEmpty().WithMessage("Los Nombres no pueden estar vacíos.")
                .MaximumLength(50).WithMessage("Los Nombres no pueden tener más de 50 caracteres.");

            RuleFor(x => x.Apellidos)
                .NotEmpty().WithMessage("Los Apellidos no pueden estar vacíos.")
                .MaximumLength(50).WithMessage("Los Apellidos no pueden tener más de 50 caracteres.");

            RuleFor(x => x.CorreoPersonal)
                .EmailAddress().WithMessage("El CorreoPersonal no es una dirección de correo electrónico válida.");

            RuleFor(x => x.CorreoEmpresarial)
                .EmailAddress().WithMessage("El CorreoEmpresarial no es una dirección de correo electrónico válida.");

            RuleFor(x => x.Direccion)
                .NotEmpty().WithMessage("La Dirección no puede estar vacía.")
                .MaximumLength(100).WithMessage("La Dirección no puede tener más de 100 caracteres.");

            RuleFor(x => x.Telefono)
                .GreaterThan(0).WithMessage("El Teléfono debe ser un número positivo.");

            RuleFor(x => x.ContactoEmergencia)
                .GreaterThan(0).WithMessage("El ContactoEmergencia debe ser un número positivo.");

            RuleFor(x => x.TelefonoContactoEmergencia)
                .GreaterThan(0).WithMessage("El TelefonoContactoEmergencia debe ser un número positivo.");

            RuleFor(x => x.Guid)
                .NotEmpty().WithMessage("El Guid no puede estar vacío.")
                .Length(36).WithMessage("El Guid debe tener 36 caracteres.");

            RuleFor(x => x.Created).NotEmpty().WithMessage("La fecha de creación no puede estar vacía.");

            RuleFor(x => x.ModifiedBy)
                .NotEmpty().WithMessage("El ModifiedBy no puede estar vacío.")
                .MaximumLength(50).WithMessage("El ModifiedBy no puede tener más de 50 caracteres.");

            RuleFor(x => x.ModifiedDate).NotEmpty().WithMessage("La fecha de modificación no puede estar vacía.");

            RuleFor(x => x.Status).NotNull().WithMessage("El Status no puede ser nulo.");

            RuleFor(x => x)
                .Must(model => model.ModifiedDate >= model.Created)
                .WithMessage("La fecha de modificación no puede ser menor que la fecha de creación.");
        }
    }
}
