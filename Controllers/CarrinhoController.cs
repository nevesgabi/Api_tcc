using Microsoft.AspNetCore.Mvc;
using api_tcc.Repositorio;
using api_tcc.Models;
using System.Collections;
using System;

namespace api_tcc.Controllers
{
    [Route("api/carrinho")]
    [ApiController]
    public class CarrinhoController : ControllerBase
    {

        // GET: api/carrinho
        [HttpGet]
        public IEnumerable ListarCarrinho()
        {
            CarrinhoRepositorio carrinhoRepositorio = new CarrinhoRepositorio();
            return carrinhoRepositorio.ListarCarrinho();
        }

        // GET: api/carrinho/{id}
        [HttpGet("{id}")]
        public Carrinho ConsultarCarrinho(int id)
        {
                CarrinhoRepositorio carrinhoRepositorio = new CarrinhoRepositorio();
                return carrinhoRepositorio.ConsultarCarrinho(id);    
        }

        // POST: api/carrinho
        [HttpPost]
        public long CadastrarCarrinho([FromBody] Carrinho value)
        {
            CarrinhoRepositorio carrinhoRepositorio = new CarrinhoRepositorio();
            return carrinhoRepositorio.CadastrarCarrinho(value);
        }

        // PUT: api/carrinho
        [HttpPut]
        public long EditarCarrinho([FromBody] Carrinho value)
        {
            CarrinhoRepositorio carrinhoRepositorio = new CarrinhoRepositorio();
            return carrinhoRepositorio.EditarCarrinho(value, value.IdCarrinho);
        }

        // DELETE: api/carrinho/{id}
        [HttpDelete("{id}")]
        public void DeletarCarrinho(int id)
        {
            CarrinhoRepositorio carrinhoRepositorio = new CarrinhoRepositorio();
            carrinhoRepositorio.DeletarCarrinho(id);
        }
    }
}
