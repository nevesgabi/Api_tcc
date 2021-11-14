using Microsoft.AspNetCore.Mvc;
using api_tcc.Repositorio;
using api_tcc.Models;
using System.Collections;

namespace api_tcc.Controllers
{
    [Route("api/pagamento")]
    [ApiController]
    public class PagamentoController : ControllerBase
    {
        // GET: api/pagamento
        [HttpGet]
        public IEnumerable ListarPagamento()
        {
            PagamentoRepositorio pagamentoRepositorio = new PagamentoRepositorio();
            return pagamentoRepositorio.ListarPagamento();
        }

        // GET: api/pagamento/{id}
        [HttpGet("{id}")]
        public Pagamento ConsultarPagamento(int id)
        {
            PagamentoRepositorio pagamentoRepositorio = new PagamentoRepositorio();
            return pagamentoRepositorio.ConsultarPagamento(id);
        }

        // POST: api/pagamento
        [HttpPost]
        public long CadastrarPagamento([FromBody] Pagamento value)
        {
            PagamentoRepositorio pagamentoRepositorio = new PagamentoRepositorio();
            return pagamentoRepositorio.CadastrarPagamento(value);
        }

        // PUT: api/pagamento
        [HttpPut]
        public long EditarPagamento([FromBody] Pagamento value)
        {
            PagamentoRepositorio pagamentoRepositorio = new PagamentoRepositorio();
            return pagamentoRepositorio.EditarPagamento(value, value.IdPag);
        }

        // DELETE: api/pagamento/{id}
        [HttpDelete("{id}")]
        public void DeletarPagamento(int id)
        {
            PagamentoRepositorio pagamentoRepositorio = new PagamentoRepositorio();
            pagamentoRepositorio.DeletarPagamento(id);
        }
    }
}
