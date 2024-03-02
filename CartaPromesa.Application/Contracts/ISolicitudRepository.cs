using CartaPromesa.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartaPromesa.Application.Contracts
{
    public interface ISolicitudRepository
    {
        Task<List<Solicitud>> GetSolicitudesAsync();
        Task<Solicitud> GetSolicitudByIdAsync(Guid id);
        Task<List<Solicitud>> GetSolicitudesByFechaAsync(DateTimeOffset fechaSolicitud);
        Task<List<Solicitud>> GetSolicitudesByFechaAsync(DateTimeOffset fechaSolicitud, DateTimeOffset fechaVencimiento);
        Task CreateSolicitudAsync(Solicitud solicitud);
        Task UpdateSolicitudAsync(Solicitud solicitud);
        Task DeleteSolicitudAsync(Guid id);
    }
}
