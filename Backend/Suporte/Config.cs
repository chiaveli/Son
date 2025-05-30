namespace SonApi.Suporte
{
    public static class Config
    {
        private static IConfigurationRoot config;        

        public static string? StrConexao;
        static Config()
        {
            var diretorio = System.IO.Directory.GetCurrentDirectory();
            config = new ConfigurationBuilder()
                .SetBasePath(diretorio)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();

            StrConexao = config["ConexaoDB"]!.ToString();
        }
    }
}
