using Microsoft.AspNetCore.Mvc;
using api_tcc.Repositorio;
using api_tcc.Models;
using System.Collections;

namespace api_tcc.Controllers
{
    [Route("api/cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        // GET: api/cliente
        [HttpGet]
        public IEnumerable ListarCliente()
        {
            ClienteRepositorio clienteRepositorio = new ClienteRepositorio();
            return clienteRepositorio.ListarCliente();
        }

        // GET: api/cliente/{id}
        [HttpGet("{id}")]
        public Cliente ConsultarCliente(int id)
        {
            ClienteRepositorio clienteRepositorio = new ClienteRepositorio();
            return clienteRepositorio.ConsultarCliente(id);
        }

        // GET: api/cliente/{nome}
        [HttpGet("nome/{nome}")]
        public Cliente ConsultarNomeCliente(string nome)
        {
            ClienteRepositorio clienteRepositorio = new ClienteRepositorio();
            return clienteRepositorio.ConsultarNomeCliente(nome);
        }

        // GET: api/cliente/{user}
        [HttpGet("user/{user}")]
        public Cliente ConsultarUserCliente(string user)
        {
            ClienteRepositorio clienteRepositorio = new ClienteRepositorio();
            return clienteRepositorio.ConsultarUserCliente(user);
        }

        // POST: api/cliente
        [HttpPost]
        public long CadastrarCliente([FromBody] Cliente value)
        {
            ClienteRepositorio clienteRepositorio = new ClienteRepositorio();
            return clienteRepositorio.CadastrarCliente(value);
        }

        // PUT: api/cliente
        [HttpPut]
        public long EditarCliente([FromBody] Cliente value)
        {
            ClienteRepositorio clienteRepositorio = new ClienteRepositorio();
            return clienteRepositorio.EditarCliente(value, value.IdCli);
        }

        // DELETE: api/cliente/{id}
        [HttpDelete("{id}")]
        public void DeletarCliente(int id)
        {
            ClienteRepositorio clienteRepositorio = new ClienteRepositorio();
            clienteRepositorio.DeletarCliente(id);
        }

        // POST: api/cliente/login
        [HttpPost("login")]
        public Cliente LogarCliente([FromBody] Cliente value)
        { 
            ClienteRepositorio clienteRepositorio = new ClienteRepositorio();
            return clienteRepositorio.ConsultarLoginCliente(value);
        }
    }
}
