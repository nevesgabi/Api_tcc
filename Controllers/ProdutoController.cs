using Microsoft.AspNetCore.Mvc;
using api_tcc.Repositorio;
using api_tcc.Models;
using System.Collections;

namespace api_tcc.Controllers
{
    [Route("api/produto")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        // GET: api/produto
        [HttpGet]
        public IEnumerable ListarProduto()
        {
            ProdutoRepositorio produtoRepositorio = new ProdutoRepositorio();
            return produtoRepositorio.ListarProduto();
        }

        // GET: api/produto/{id}
        [HttpGet("{id}")]
        public Produto ConsultarProduto(int id)
        {
            ProdutoRepositorio produtoRepositorio = new ProdutoRepositorio();
            return produtoRepositorio.ConsultarProduto(id);
        }

        // GET: api/produto/nome/{nome}
        [HttpGet("nome/{nome}")]
        public Produto ConsultarNomeProduto(string nome)
        {
            ProdutoRepositorio produtoRepositorio = new ProdutoRepositorio();
            return produtoRepositorio.ConsultarNomeProduto(nome);
        }

        // POST: api/produto
        [HttpPost]
        public long CadastrarProduto([FromBody] Produto value)
        {
            ProdutoRepositorio produtoRepositorio = new ProdutoRepositorio();
            return produtoRepositorio.CadastrarProduto(value);
        }

        // PUT: api/produto
        [HttpPut]
        public long EditarProduto([FromBody] Produto value)
        {
            ProdutoRepositorio produtoRepositorio = new ProdutoRepositorio();
            return produtoRepositorio.EditarProduto(value, value.IdProd);
        }

        // DELETE: api/produto/{id}
        [HttpDelete("{id}")]
        public void DeletarProduto(int id)
        {
            ProdutoRepositorio produtoRepositorio = new ProdutoRepositorio();
            produtoRepositorio.DeletarProduto(id);
        }
    }
}
