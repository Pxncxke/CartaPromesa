using AutoMapper;
using CartaPromesa.Application.Contracts;
using CartaPromesa.Application.Exceptions;
using CartaPromesa.Domain.Models;
using MediatR;

namespace CartaPromesa.Application.Features.Solicitudes.Commands.CreateSolicitud
{
    public class CreateSolicitudCommandHandler : IRequestHandler<CreateSolicitudCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ISolicitudRepository _solicitudRepository;

        public CreateSolicitudCommandHandler(IMapper mapper, ISolicitudRepository solicitudRepository)
        {
            _mapper = mapper;
            _solicitudRepository = solicitudRepository;
        }

        public async Task<Unit> Handle(CreateSolicitudCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateSolicitudCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new BadRequestException("Operacion Invalida", validationResult);
            }

            var solicitud = _mapper.Map<Solicitud>(request);

            await _solicitudRepository.CreateSolicitudAsync(solicitud);

            return Unit.Value;
        }
    }
}
