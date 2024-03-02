using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartaPromesa.Domain.Models
{
    public class Solicitud
    {
        public Guid Id { get; set; }
        public string NombreOrdenante { get; set; }
        public string ApellidoOrdenante { get; set; }
        public string NombreBeneficiario { get; set; }
        public string ApellidoBeneficiario { get; set; }
        public DateTimeOffset FechaSolicitud { get; set; }
        public DateTimeOffset? FechaVencimiento { get; set; }
        [Precision(18, 2)]
        public decimal Monto { get; set; }
        public bool Estado { get; set; }
    }
}
