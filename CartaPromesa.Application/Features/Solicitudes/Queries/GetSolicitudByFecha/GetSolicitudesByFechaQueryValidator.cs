using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartaPromesa.Application.Features.Solicitudes.Queries.GetSolicitudByFecha
{
    public class GetSolicitudesByFechaQueryValidator : AbstractValidator<GetSolicitudesByFechaQuery>
    {
        public GetSolicitudesByFechaQueryValidator()
        {
            RuleFor(p => p.FechaSolicitud)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacío.")
                .NotNull().WithMessage("{PropertyName} no puede estar vacío.");

            RuleFor(p => p.FechaVencimiento)
                .GreaterThan(p=> p.FechaSolicitud).WithMessage("{PropertyName} debe ser mayor a la fecha de solicitud.");
        }
    }
}
