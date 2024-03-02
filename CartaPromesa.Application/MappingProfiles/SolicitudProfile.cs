using AutoMapper;
using CartaPromesa.Application.Features.Solicitudes.Commands.CreateSolicitud;
using CartaPromesa.Application.Features.Solicitudes.Queries.GetSolicitudByFecha;
using CartaPromesa.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartaPromesa.Application.MappingProfiles
{
    public class SolicitudProfile : Profile
    {
        public SolicitudProfile()
        {
            CreateMap<Solicitud, SolicitudDto>().ReverseMap();
            CreateMap<CreateSolicitudCommand, Solicitud>().ReverseMap();
        }
    }
}
