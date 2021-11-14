using Microsoft.AspNetCore.Mvc;
using api_tcc.Repositorio;
using api_tcc.Models;
using System.Collections;

namespace api_tcc.Controllers
{
    [Route("api/comanda")]
    [ApiController]
    public class ComandaController : ControllerBase
    {
        // GET: api/comanda
        [HttpGet]
        public IEnumerable ListarComanda()
        {
            ComandaRepositorio comandaRepositorio = new ComandaRepositorio();
            return comandaRepositorio.ListarComanda();
        }

        // GET: api/comanda/{id}
        [HttpGet("{id}")]
        public Comanda ConsultarComanda(int id)
        {
            ComandaRepositorio comandaRepositorio = new ComandaRepositorio();
            return comandaRepositorio.ConsultarComanda(id);
        }

        // POST: api/comanda
        [HttpPost]
        public long CadastrarComanda([FromBody] Comanda value)
        {
            ComandaRepositorio comandaRepositorio = new ComandaRepositorio();
            return comandaRepositorio.CadastrarComanda(value);
        }

        // PUT: api/comanda
        [HttpPut]
        public long EditarComanda([FromBody] Comanda value)
        {
            ComandaRepositorio comandaRepositorio = new ComandaRepositorio();
            return comandaRepositorio.EditarComanda(value, value.IdComanda);
        }

        // DELETE: api/comanda/{id}
        [HttpDelete("{id}")]
        public void DeletarComanda(int id)
        {
            ComandaRepositorio comandaRepositorio = new ComandaRepositorio();
            comandaRepositorio.DeletarComanda(id);
        }
    }
}
