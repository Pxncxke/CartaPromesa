using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartaPromesa.Application.Features.Solicitudes.Commands.CreateSolicitud
{
    public class CreateSolicitudCommand :IRequest<Unit>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string NombreOrdenante { get; set; }
        public string ApellidoOrdenante { get; set; }
        public string NombreBeneficiario { get; set; }
        public string ApellidoBeneficiario { get; set; }
        public DateTimeOffset FechaSolicitud { get; set; }
        public DateTimeOffset? FechaVencimiento { get; set; }
        public decimal Monto { get; set; }
        public bool Estado { get; set; } = false;
    }
}
