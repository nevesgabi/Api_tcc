using Microsoft.AspNetCore.Mvc;
using api_tcc.Repositorio;
using api_tcc.Models;
using System.Collections;

namespace api_tcc.Controllers
{
    [Route("api/mesa")]
    [ApiController]
    public class MesaController : ControllerBase
    {
        // GET: api/mesa
        [HttpGet]
        public IEnumerable ListarMesa()
        {
            MesaRepositorio mesaRepositorio = new MesaRepositorio();
            return mesaRepositorio.ListarMesa();
        }

        // GET: api/mesa/{id}
        [HttpGet("{id}")]
        public Mesa ConsultarMesa(int id)
        {
            MesaRepositorio mesaRepositorio = new MesaRepositorio();
            return mesaRepositorio.ConsultarMesa(id);
        }

        // POST: api/mesa
        [HttpPost]
        public long CadastrarMesa([FromBody] Mesa value)
        {
            MesaRepositorio mesaRepositorio = new MesaRepositorio();
            return mesaRepositorio.CadastrarMesa(value);
        }

        // PUT: api/mesa
        [HttpPut]
        public long EditarMesa([FromBody] Mesa value)
        {
            MesaRepositorio mesaRepositorio = new MesaRepositorio();
            return mesaRepositorio.EditarMesa(value, value.IdMesa);
        }

        // DELETE: api/mesa/{id}
        [HttpDelete("{id}")]
        public void DeletarMesa(int id)
        {
            MesaRepositorio mesaRepositorio = new MesaRepositorio();
            mesaRepositorio.DeletarMesa(id);
        }
    }
}
