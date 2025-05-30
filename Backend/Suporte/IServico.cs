namespace SonApi.Suporte
{
    public interface IServico<T>
    {
        Result Inserir(T pObjeto);
        Result Alterar(T pObjeto);
        Result Excluir(T pObjeto);
        Result Excluir(long pIdObjetp);
        Result Excluir(string pCondicaoWhere);
        Result<T> Obter(long pIdObjeto);
        Result<List<T>> Obter(string pCondicaoWhere);
    }
}
