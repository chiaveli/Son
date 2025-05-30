using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Son.Comum.Infra;
using Son.Comum.Model;
using Son.Comum.Extensao;
using SonApi.Servicos;
using SonApi.Suporte;
using System.Text;

namespace SonApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public ActionResult<DadosLogin> Login(DadosLogin pDadosLogin)
        {
            string condicao = $"Email='{pDadosLogin.Email}'";
            PessoaServico pessoa = new();
            DadosLogin login = new();

            Result<List<PessoaModel>> usuarios =  pessoa.Obter(condicao);

            if (usuarios.Objeto!.Count == 0)
                return NotFound();           

            if (usuarios.Objeto[0].Senha != CriptografiaAES.Criptografar(pDadosLogin.Senha))
                return Unauthorized();

            //login.IdPessoa = usuarios.Objeto[0].IdPessoa;
            //login.Nome  = usuarios.Objeto[0].Nome;
            //login.Email = usuarios.Objeto[0].Email;
            //login.Perfil = usuarios.Objeto[0].Perfil;

            usuarios.Objeto[0].CopiarPara(login);

            return Ok(login);
        }
    }
}
