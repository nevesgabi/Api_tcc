using Microsoft.AspNetCore.Mvc;
using api_tcc.Repositorio;
using api_tcc.Models;
using System.Collections;

namespace api_tcc.Controllers
{
    [Route("api/funcionario")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        // GET: api/funcionario
        [HttpGet]
        public IEnumerable ListarFuncionario()
        {
            FuncionarioRepositorio funcionarioRepositorio = new FuncionarioRepositorio();
            return funcionarioRepositorio.ListarFuncionario();
        }

        // GET: api/funcionario/{id}
        [HttpGet("{id}")]
        public Funcionario ConsultarFuncionario(int id)
        {
            FuncionarioRepositorio funcionarioRepositorio = new FuncionarioRepositorio();
            return funcionarioRepositorio.ConsultarFuncionario(id);
        }

        // GET: api/funcionario/nome/{nome}
        [HttpGet("nome/{nome}")]
        public Funcionario ConsultarNomeFuncionario(string nome)
        {
            FuncionarioRepositorio funcionarioRepositorio = new FuncionarioRepositorio();
            return funcionarioRepositorio.ConsultarNomeFuncionario(nome);
        }

        // GET: api/funcionario/user/{user}
        [HttpGet("user/{user}")]
        public Funcionario ConsultarUserFuncionario(string user)
        {
            FuncionarioRepositorio funcionarioRepositorio = new FuncionarioRepositorio();
            return funcionarioRepositorio.ConsultarUserFuncionario(user);
        }

        // POST: api/funcionario
        [HttpPost]
        public long CadastrarFuncionario([FromBody] Funcionario value)
        {
            FuncionarioRepositorio funcionarioRepositorio = new FuncionarioRepositorio();
            return funcionarioRepositorio.CadastrarFuncionario(value);
        }

        // PUT: api/funcionario
        [HttpPut]
        public long EditarFuncionario([FromBody] Funcionario value)
        {
            FuncionarioRepositorio funcionarioRepositorio = new FuncionarioRepositorio();
            return funcionarioRepositorio.EditarFuncionario(value, value.IdFunc);
        }

        // DELETE: api/funcionario/{id}
        [HttpDelete("{id}")]
        public void DeletarFuncionario(int id)
        {
            FuncionarioRepositorio funcionarioRepositorio = new FuncionarioRepositorio();
            funcionarioRepositorio.DeletarFuncionario(id);
        }

        // POST: api/funcionario/login
        [HttpPost("login")]
        public Funcionario LogarFuncionario([FromBody] Funcionario value)
        {
            FuncionarioRepositorio funcionarioRepositorio = new FuncionarioRepositorio();
            return funcionarioRepositorio.ConsultarLoginFuncionario(value);
        }
    }
}

