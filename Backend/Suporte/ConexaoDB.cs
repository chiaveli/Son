using MySql.Data.MySqlClient;
using System.Data;

namespace SonApi.Suporte
{
    public static class ConexaoDB
    {      
        private static string? strConexao;

        static ConexaoDB()
        {
            strConexao = Config.StrConexao;
        }

        public static IDbConnection Instancia()
        {
            IDbConnection conexao = new MySqlConnection(strConexao);
            return conexao;
        }
    }
}
