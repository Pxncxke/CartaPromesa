using CartaPromesa.Application.Contracts;
using CartaPromesa.Domain.Models;
using CartaPromesa.Persistence.DataBaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartaPromesa.Persistence.Repositories
{
    public class SolicitudRepository : ISolicitudRepository
    {
        private readonly CartaPromesaDbContext _context;

        public SolicitudRepository(CartaPromesaDbContext context)
        {
            _context = context;
        }
        public async Task CreateSolicitudAsync(Solicitud solicitud)
        {
            await _context.Solicitudes.AddAsync(solicitud);
            await _context.SaveChangesAsync();
        }

        public Task DeleteSolicitudAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Solicitud> GetSolicitudByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Solicitud>> GetSolicitudesAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<List<Solicitud>> GetSolicitudesByFechaAsync(DateTimeOffset fechaSolicitud)
        {
                return await _context.Solicitudes.AsNoTracking().Where(x => x.FechaSolicitud.Date == fechaSolicitud.Date).ToListAsync();
        }

        public async Task<List<Solicitud>> GetSolicitudesByFechaAsync(DateTimeOffset fechaSolicitud, DateTimeOffset fechaVencimiento)
        {
           return await _context.Solicitudes.AsNoTracking().Where(x => x.FechaSolicitud.Date == fechaSolicitud.Date && x.FechaVencimiento.Value.Date ==  fechaVencimiento.Date).ToListAsync();
        }

        public Task UpdateSolicitudAsync(Solicitud solicitud)
        {
            throw new NotImplementedException();
        }
    }
}
