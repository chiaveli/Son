using Dapper;
using Dapper.Contrib.Extensions;
using MySql.Data.MySqlClient;
//using MySqlX.XDevAPI.Common;
using Son.Comum.Model;
using SonApi.Suporte;
using System.Data;
using System.Linq.Expressions;

namespace SonApi.Servicos
{
    public class PessoaServico : IServico<PessoaModel>
    {
        private IDbConnection conexao;

        public PessoaServico()
        {
            conexao = ConexaoDB.Instancia();
        }

        public Result Excluir(PessoaModel pObjeto)
        {
            Result result = new();

            try
            {
                conexao.Delete<PessoaModel>(pObjeto);
            }
            catch (Exception ex)
            {
                result.Erro = true;
                result.Mensagem = "Falha ao tentar excluir os dados da pessoa.";
                result.Excecao = ex;
            }

            return result;

        }

        public Result Excluir(long pIdObjetp)
        {
            PessoaModel pessoa = new() { IdPessoa = pIdObjetp };
            return Excluir(pessoa);
        }

        public Result Excluir(string pCondicaoWhere)
        {
            Result result = new();

            try
            {
                conexao.DeleteAll<PessoaModel>();
            }
            catch (Exception ex)
            {
                result.Erro = true;
                result.Mensagem = "Falha ao tentar excluir os dados da pessoa.";
                result.Excecao = ex;
            }

            return result;
        }

        public Result Inserir(PessoaModel pObjeto)
        {
            Result result = new();

            try
            {
                conexao.Insert<PessoaModel>(pObjeto);
            }
            catch (Exception ex)
            {
                result.Erro = true;
                result.Mensagem = "Falha ao tentar gravar os dados da pessoa.";
                result.Excecao = ex;
            }

            return result;
        }

        public Result<List<PessoaModel>> Obter(string pCondicaoWhere)
        {
            Result<List<PessoaModel>> result = new Result<List<PessoaModel>>();

            try
            {
                var pessoa = conexao.Query<PessoaModel>($"select * from Pessoa where {pCondicaoWhere}");
                result.Objeto = pessoa.ToList();
            }
            catch (Exception ex)
            {
                result.Erro = true;
                result.Mensagem = "Falha ao tentar obter os dados da pessoa.";
                result.Objeto = null;
                result.Excecao = ex;
            }

            return result;
        }

        public Result<PessoaModel> Obter(long pIdObjeto)
        {
            Result<List<PessoaModel>> resultLista = Obter($"IdPessoa = {pIdObjeto}");
            Result<PessoaModel> result = new Result<PessoaModel>();

            if (resultLista.Erro)
            {
                result.Erro = true;
                result.Mensagem = resultLista.Mensagem;
                result.Excecao = resultLista.Excecao;
            }
            else
            {
                if (resultLista.Objeto!.Count > 0)
                    result.Objeto = resultLista.Objeto[0];
            }

            return result;

        }

        public Result Alterar(PessoaModel pObjeto)
        {
            Result result = new();

            try
            {
                conexao.Update<PessoaModel>(pObjeto);
            }
            catch (Exception ex)
            {
                result.Erro = true;
                result.Mensagem = "Falha ao tentar atualizar os dados da pessoa.";
                result.Excecao = ex;
            }

            return result;

        }
    }
}
