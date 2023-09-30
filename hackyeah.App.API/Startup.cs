using hackyeah.App.Application;
using hackyeah.App.Application.DataAccess;
using hackyeah.App.Infrastructure.DataAccess;
using Shared.BaseModels.LoginObject;
using Shared.Extensions.ConfigureApp;
using Shared.Extensions.ConfigureServices;

namespace hackyeah.App.API;

public class Startup
{
    public Startup(IConfiguration configuration) => Configuration = configuration;

    private IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        var connectionString = Configuration["ConnectionString"];
        var serviceName = Configuration["ServiceName"];

        //Configure Service
        services.Configure<string>(Configuration);
        services.AddSharedServices<AssemblyEntryPoint, DataContext, IUnitOfWork>(JwtLogin.FromConfiguration(Configuration), connectionString, serviceName);
        
        //services.AddMessageBusConnection(c => c.ApplyConfiguration(Configuration.GetSection("RabbitMQ")));
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) => app.ConfigureApplication(Configuration);
}