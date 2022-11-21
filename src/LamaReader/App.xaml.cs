using LamaReader.Data;
using LamaReader.MainLogic;
using LamaReader.Pages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LamaReader
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost? AppHost { get; private set; }

        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {

                    var npgConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["LlamaReaderDb"].ConnectionString;

                    services.AddDbContext<LlamaReaderDbContext>(options =>
                        options.UseNpgsql(npgConnectionString));


                    services.AddScoped<IAuthService, AuthService>();
                    services.AddScoped<IAuth, Auth>();

                    services.AddSingleton<SignIn>();

                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost!.StartAsync();

            var startupForm = AppHost.Services.GetRequiredService<SignIn>();
            startupForm.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost!.StopAsync();

            base.OnExit(e);
        }

        public class YourDbContextFactory : IDesignTimeDbContextFactory<LlamaReaderDbContext>
        {
            public LlamaReaderDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<LlamaReaderDbContext>();
                optionsBuilder.UseNpgsql("Host=db.ikyuxfksnzysklzobngb.supabase.co;Database=postgres;User Id=postgres;Password=febL5712PTWDXh8M;");

                return new LlamaReaderDbContext(optionsBuilder.Options);
            }
        }
    }
}