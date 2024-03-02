using AutoMapper;
using CartaPromesa.Application.Contracts;
using CartaPromesa.Application.Exceptions;
using CartaPromesa.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartaPromesa.Application.Features.Solicitudes.Queries.GetSolicitudByFecha
{
    public class GetSolicitudesByFechaQueryHandler : IRequestHandler<GetSolicitudesByFechaQuery, List<SolicitudDto>>
    {
        private readonly IMapper _mapper;
        private readonly ISolicitudRepository _solicitudRepository;

        public GetSolicitudesByFechaQueryHandler(IMapper mapper, ISolicitudRepository solicitudRepository)
        {
            _mapper = mapper;
            _solicitudRepository = solicitudRepository;
        }

        public async Task<List<SolicitudDto>> Handle(GetSolicitudesByFechaQuery request, CancellationToken cancellationToken)
        {
            var solicitudes = new List<Solicitud>();
            var validator = new GetSolicitudesByFechaQueryValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new BadRequestException("Operacion Invalida", validationResult);
            }

            if (request.FechaVencimiento == null)
            {
                solicitudes = await _solicitudRepository.GetSolicitudesByFechaAsync(request.FechaSolicitud);
            }
            else
            {
                solicitudes = await _solicitudRepository.GetSolicitudesByFechaAsync(request.FechaSolicitud, request.FechaVencimiento.Value);
            }

            var dto = _mapper.Map<List<SolicitudDto>>(solicitudes);

            return dto;
        }
    }
}
