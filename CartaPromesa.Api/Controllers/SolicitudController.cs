using CartaPromesa.Application.Features.Solicitudes.Commands.CreateSolicitud;
using CartaPromesa.Application.Features.Solicitudes.Queries.GetSolicitudByFecha;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CartaPromesa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudController : ControllerBase
    {
        private readonly ISender _sender;

        public SolicitudController(ISender sender)
        {
            _sender = sender;
        }

        // GET: api/<SolicitudController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SolicitudController>/5
        [HttpGet("fecha/{solicitud}")]
        public async Task<IActionResult> Get(DateTimeOffset solicitud, DateTimeOffset? vencimiento = null)
        {
            var solicitudes = await _sender.Send(new GetSolicitudesByFechaQuery(solicitud, vencimiento));
            
            if(!solicitudes.Any())
            {
                return NotFound();
            }

            return Ok(solicitudes);
        }

        // POST api/<SolicitudController>
        [HttpPost]
        public async Task<IActionResult> Post(CreateSolicitudCommand command)
        {
            await _sender.Send(command);
            return Ok();
        }

        // PUT api/<SolicitudController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SolicitudController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
