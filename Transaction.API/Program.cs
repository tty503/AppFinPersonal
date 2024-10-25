using TransactionApplication;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Configurar los servicios
        ConfigureServices(builder.Services, builder.Configuration);

        // Construir la aplicación
        var app = builder.Build();

        // Configurar el pipeline HTTP
        ConfigureApplication(app, builder.Environment);

        // Iniciar la aplicación
        app.Run();
    }

    private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TransactionContext>(options =>
        {
            var connectionStr = configuration.GetConnectionString("DefaultConnection");
            //var serverVersion = ServerVersion.AutoDetect(connectionStr);
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 0));
            options.UseMySql(connectionStr, serverVersion);
        });

        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddAutoMapper(typeof(TransactionApplication.Queries.GetAllTransaction).Assembly);
        services.AddAutoMapper(typeof(TransactionApplication.Queries.GetOneTransaction).Assembly);
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

        ConfigureExceptionHandling(services, configuration);
    }

    private static void ConfigureExceptionHandling(IServiceCollection services, IConfiguration configuration)
    {
        try
        {
            using (var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                connection.Close();
            }
        }
        catch (MySqlException ex)
        {
            if (ex.Number == (int)MySqlErrorCode.AccessDenied)
            {
                services.AddSingleton<ILogger<TransactionContext>>((provider) =>
                {
                    var logger = provider.GetRequiredService<ILoggerFactory>().CreateLogger<TransactionContext>();
                    logger.LogError(ex, "Error de permisos de acceso a la base de datos");
                    return logger;
                });
            }
            else
            {
                services.AddSingleton<ILogger<TransactionContext>>((provider) =>
                {
                    var logger = provider.GetRequiredService<ILoggerFactory>().CreateLogger<TransactionContext>();
                    logger.LogError(ex, "Error de conexión a la base de datos");
                    return logger;
                });
            }

            throw;
        }
        catch (Exception ex)
        {
            services.AddSingleton<ILogger<TransactionContext>>((provider) =>
            {
                var logger = provider.GetRequiredService<ILoggerFactory>().CreateLogger<TransactionContext>();
                logger.LogError(ex, "Error inesperado al configurar la conexión a la base de datos");
                return logger;
            });

            throw;
        }
    }

    private static void ConfigureApplication(WebApplication app, IWebHostEnvironment environment)
    {
        app.UseHttpsRedirection();
        app.UseAuthorization();

        if (environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });
        }

        app.MapGet("/who", () => "Transaction.API");
        app.MapControllers();
    }
}