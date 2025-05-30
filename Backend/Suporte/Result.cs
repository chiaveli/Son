namespace SonApi.Suporte
{
    public class Result: Result<Object>
    {

    }

    public class Result<T>
    {
        public bool Erro { get; set; }
        public T? Objeto { get; set; }
        public string? Mensagem { get; set; }
        public Exception? Excecao { get; set; }

        public Result(T pObjeto)
        {
            Objeto = pObjeto;
            Erro = false;
            Mensagem = "";
            Excecao = null;
        }
        public Result()
        {
            Erro = false;
            Mensagem = "";
            Objeto = default(T);
            Excecao = null;
        }
    }
}
