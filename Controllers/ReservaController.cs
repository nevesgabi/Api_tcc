using Microsoft.AspNetCore.Mvc;
using api_tcc.Repositorio;
using api_tcc.Models;
using System.Collections;

namespace api_tcc.Controllers
{
    [Route("api/reserva")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        // GET: api/reserva
        [HttpGet]
        public IEnumerable ListarReserva()
        {
            ReservaRepositorio reservaRepositorio = new ReservaRepositorio();
            return reservaRepositorio.ListarReserva();
        }

        // GET: api/reserva/{id}
        [HttpGet("{id}")]
        public Reserva ConsultarReserva(int id)
        {
            ReservaRepositorio reservaRepositorio = new ReservaRepositorio();
            return reservaRepositorio.ConsultarReserva(id);
        }

        // POST: api/reserva
        [HttpPost]
        public long CadastrarReserva([FromBody] Reserva value)
        {
            ReservaRepositorio reservaRepositorio = new ReservaRepositorio();
            return reservaRepositorio.CadastrarReserva(value);
        }

        // PUT: api/reserva
        [HttpPut]
        public long EditarReserva([FromBody] Reserva value)
        {
            ReservaRepositorio reservaRepositorio = new ReservaRepositorio();
            return reservaRepositorio.EditarReserva(value, value.IdReserva);
        }

        // DELETE: api/reserva/{id}
        [HttpDelete("{id}")]
        public void DeletarReserva(int id)
        {
            ReservaRepositorio reservaRepositorio = new ReservaRepositorio();
            reservaRepositorio.DeletarReserva(id);
        }
    }
}