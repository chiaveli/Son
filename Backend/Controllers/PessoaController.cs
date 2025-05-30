using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Son.Comum.Infra;
using Son.Comum.Model;
using SonApi.Servicos;
using SonApi.Suporte;

namespace SonApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase //, IController<PessoaModel>
    {
        [HttpDelete]
        [Route("Excluir")]
        public ActionResult<String> Excluir(PessoaModel pObjeto)
        {
            var pessoa = new PessoaServico();

            Result result = pessoa.Excluir(pObjeto);

            if (result.Erro)
                return result.Mensagem! + "\n" + result.Excecao!.Message;
            else
                return Ok();
        }

        [HttpDelete]
        [Route("Excluir/{pIdObjeto:int}")]
        public ActionResult<String> Excluir([FromRoute] long pIdObjeto)
        {
            var pessoa = new PessoaServico();

            Result result = pessoa.Excluir(pIdObjeto);

            if (result.Erro)
                return result.Mensagem! + "\n" + result.Excecao!.Message;
            else
                return Ok();
        }

        [HttpDelete]
        [Route("Excluir/pCondicaoWhere:alpha")]
        public ActionResult<String> Excluir([FromRoute] string pCondicaoWhere)
        {
            var pessoa = new PessoaServico();

            Result result = pessoa.Excluir(pCondicaoWhere);

            if (result.Erro)
                return result.Mensagem! + "\n" + result.Excecao!.Message;
            else
                return Ok();
        }

        [HttpPost("Inserir")]
        public ActionResult<String> Inserir(PessoaModel pObjeto)
        {
            var pessoa = new PessoaServico();

            pObjeto.Senha = CriptografiaAES.Criptografar(pObjeto.Senha);
            pObjeto.ConfirmarSenha = pObjeto.Senha;

            Result result = pessoa.Inserir(pObjeto);

            if (result.Erro)
                return result.Mensagem! + "\n" + result.Excecao!.Message;
            else
                return Ok();
        }

        [HttpGet]
        [Route("Obter/{pCondicaoWhere}")]
        public ActionResult<List<PessoaModel>> Obter(string pCondicaoWhere)
        {
            var pessoa = new PessoaServico();

            Result<List<PessoaModel>> result = pessoa.Obter(pCondicaoWhere);

            if (result.Erro)
                return BadRequest(result.Mensagem! + "\n" + result.Excecao!.Message);
            else
                return Ok(result.Objeto);
        }

        [HttpGet]
        [Route("Obter/{pIdObjeto:int}")]
        public ActionResult<PessoaModel> Obter([FromRoute] long pIdObjeto)
        {
            var pessoa = new PessoaServico();

            Result<PessoaModel> result = pessoa.Obter(pIdObjeto);

            if (result.Erro)
                return BadRequest(result.Mensagem! + "\n" + result.Excecao!.Message);
            else
                return Ok(result.Objeto);
        }

        [HttpPost("Alterar")]
        public ActionResult<String> Alterar(PessoaModel pObjeto)
        {
            var pessoa = new PessoaServico();

            pObjeto.Senha = CriptografiaAES.Criptografar(pObjeto.Senha);
            pObjeto.ConfirmarSenha = pObjeto.Senha;

            Result result = pessoa.Alterar(pObjeto);

            if (result.Erro)
                return result.Mensagem! + "\n" + result.Excecao!.Message;
            else
                return Ok();

        }

    }
}
