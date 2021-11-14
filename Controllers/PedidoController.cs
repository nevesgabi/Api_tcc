using Microsoft.AspNetCore.Mvc;
using api_tcc.Repositorio;
using api_tcc.Models;
using System.Collections;

namespace api_tcc.Controllers
{
    [Route("api/pedido")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        // GET: api/pedido
        [HttpGet]
        public IEnumerable ListarPedido()
        {
            PedidoRepositorio pedidoRepositorio = new PedidoRepositorio();
            return pedidoRepositorio.ListarPedido();
        }

        // GET: api/pedido/{id}
        [HttpGet("{id}")]
        public Pedido ConsultarPedido(int id)
        {
            PedidoRepositorio pedidoRepositorio = new PedidoRepositorio();
            return pedidoRepositorio.ConsultarPedido(id);
        }

        // POST: api/pedido
        [HttpPost]
        public long CadastrarPedido([FromBody] Pedido value)
        {
            PedidoRepositorio pedidoRepositorio = new PedidoRepositorio();
            return pedidoRepositorio.CadastrarPedido(value);
        }

        // PUT: api/pedido
        [HttpPut]
        public long EditarPedido([FromBody] Pedido value)
        {
            PedidoRepositorio pedidoRepositorio = new PedidoRepositorio();
            return pedidoRepositorio.EditarPedido(value, value.IdPedido);
        }

        // DELETE: api/pedido/{id}
        [HttpDelete("{id}")]
        public void DeletarPedido(int id)
        {
            PedidoRepositorio pedidoRepositorio = new PedidoRepositorio();
            pedidoRepositorio.DeletarPedido(id);
        }
    }
}
