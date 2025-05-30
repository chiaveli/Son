using Son.Comum.Infra;

namespace Son.Infra
{
    public static class UsuarioLogado
    {
        public static long IdPessoa { get; private set; }
        public static string? Nome { get; private set; }
        public static string? Email { get; private set; }
        public static string? Perfil { get; private set; }

        public static void CarregarLogin(DadosLogin pDadosLogin)
        {
            IdPessoa = pDadosLogin.IdPessoa;
            Nome     = pDadosLogin.Nome;
            Email    = pDadosLogin.Email;
            Perfil   = pDadosLogin.Perfil;
        }
    }
}
