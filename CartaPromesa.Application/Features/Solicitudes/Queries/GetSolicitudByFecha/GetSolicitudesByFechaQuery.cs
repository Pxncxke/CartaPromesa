using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartaPromesa.Application.Features.Solicitudes.Queries.GetSolicitudByFecha
{
    public record GetSolicitudesByFechaQuery(DateTimeOffset FechaSolicitud, DateTimeOffset? FechaVencimiento) : IRequest<List<SolicitudDto>>;
}
