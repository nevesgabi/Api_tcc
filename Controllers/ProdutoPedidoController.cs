using Microsoft.AspNetCore.Mvc;
using api_tcc.Repositorio;
using api_tcc.Models;
using System.Collections;

namespace api_tcc.Controllers
{
    [Route("api/produtoPedido")]
    [ApiController]
    public class ProdutoPedidoController : ControllerBase
    {
        // GET: api/produtoPedido
        [HttpGet]
        public IEnumerable ListarProdutoPedido()
        {
            Produto_PedidoRepositorio produto_PedidoRepositorio = new Produto_PedidoRepositorio();
            return produto_PedidoRepositorio.ListarProdutoPedido();
        }

        // GET: api/produtoPedido/{id}
        [HttpGet("{id}")]
        public Produto_pedido ConsultarProdutoPedido(int id)
        {
            Produto_PedidoRepositorio produto_PedidoRepositorio = new Produto_PedidoRepositorio();
            return produto_PedidoRepositorio.ConsultarProdutoPedido(id);
        }

        // POST: api/produtoPedido
        [HttpPost]
        public long CadastrarProduto([FromBody] Produto_pedido value)
        {
            Produto_PedidoRepositorio produto_PedidoRepositorio = new Produto_PedidoRepositorio();
            return produto_PedidoRepositorio.CadastrarProdutoPedido(value);
        }

        // PUT: api/produtoPedido
        [HttpPut]
        public long EditarProduto([FromBody] Produto_pedido value)
        {
            Produto_PedidoRepositorio produto_PedidoRepositorio = new Produto_PedidoRepositorio();
            return produto_PedidoRepositorio.EditarProdutoPedido(value, value.IdProdutoPedido);
        }

        // DELETE: api/produtoPedido/{id}
        [HttpDelete("{id}")]
        public void DeletarProduto(int id)
        {
            Produto_PedidoRepositorio produto_PedidoRepositorio = new Produto_PedidoRepositorio();
            produto_PedidoRepositorio.DeletarProdutoPedido(id);
        }
    }
}