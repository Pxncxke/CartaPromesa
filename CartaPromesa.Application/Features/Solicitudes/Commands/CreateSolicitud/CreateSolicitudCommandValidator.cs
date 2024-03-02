using FluentValidation;

namespace CartaPromesa.Application.Features.Solicitudes.Commands.CreateSolicitud
{
    public class CreateSolicitudCommandValidator : AbstractValidator<CreateSolicitudCommand>
    {
        public CreateSolicitudCommandValidator()
        {
            RuleFor(p => p.NombreOrdenante)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .NotNull().WithMessage("{PropertyName} no puede estar vacío.");

            RuleFor(p => p.ApellidoOrdenante)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .NotNull().WithMessage("{PropertyName} no puede estar vacío.");

            RuleFor(p => p.NombreBeneficiario)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .NotNull().WithMessage("{PropertyName} no puede estar vacío.");

            RuleFor(p => p.ApellidoBeneficiario)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .NotNull().WithMessage("{PropertyName} no puede estar vacío.");

            RuleFor(p => p.FechaSolicitud)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .NotNull().WithMessage("{PropertyName} no puede estar vacío.")
                .GreaterThan(DateTimeOffset.Now).WithMessage("{PropertyName} no puede ser el dia de hoy.")
                .Custom((x, context) =>
                {

                    if (x.LocalDateTime.Hour < 8 || x.LocalDateTime.Hour > 14 ||
                    (x.LocalDateTime.Minute != 0 && x.LocalDateTime.Minute != 30) ||
                    (x.LocalDateTime.DayOfWeek == DayOfWeek.Saturday || x.LocalDateTime.DayOfWeek == DayOfWeek.Sunday) || x.LocalDateTime.TimeOfDay > new TimeSpan(14, 0, 0))
                    {
                        context.AddFailure($"{x} no es una fecha valida");
                    }
                }); 

            RuleFor(p => p.FechaVencimiento)
                .GreaterThan(p => p.FechaSolicitud).WithMessage("{PropertyName} debe ser mayor a la fecha de solicitud.");


            RuleFor(p => p.Monto)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .NotNull().WithMessage("{PropertyName} no puede estar vacío.")
                .GreaterThan(100).WithMessage("{PropertyName} debe ser mayor a 100.");
        }
    }
}
