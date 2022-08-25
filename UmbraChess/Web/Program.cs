using Azure.Identity;

namespace UmbraChess.Web
{
    public class Program
    {
        public static void Main(string[] args)
            => CreateHostBuilder(args)
                .Build()
                .Run();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureUmbracoDefaults()
                .ConfigureAppConfiguration((context, config) =>
                {
                    var settings = config.Build();
                    var keyVaultEndpoint = settings["Azure:KeyVaultEndpoint"];
                    if (!string.IsNullOrEmpty(keyVaultEndpoint) && Uri.TryCreate(keyVaultEndpoint, UriKind.Absolute, out var validUri))
                    {
                        config.AddAzureKeyVault(validUri, new DefaultAzureCredential());
                    }
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
