using Microsoft.AspNetCore.Mvc;

namespace SonApi.Suporte
{
    public interface IController<T>
    {
        ActionResult<String> Inserir(T pObjeto);
        ActionResult<String> Alterar(T pObjeto);
        ActionResult<String> Excluir(T pObjeto);
        ActionResult<String> Excluir(long pIdObjeto);
        ActionResult<String> Excluir(string pCondicaoWhere);
        ActionResult<T> Obter(long pIdObjeto);
        ActionResult<List<T>> Obter(string pCondicaoWhere);
    }
}
