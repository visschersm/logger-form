using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace logger_form_demo;

static class Program
{
    public static IConfiguration? Configuration;

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
         //To register all default providers:
        //var host = Host.CreateDefaultBuilder(args).Build();
         var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        Configuration = builder.Build();
        
        ApplicationConfiguration.Initialize();

        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
        
        var serviceProvider = serviceCollection.BuildServiceProvider();
        var form = serviceProvider.GetRequiredService<Form1>();

        Application.Run(form);
    }

    private static IServiceCollection ConfigureServices(IServiceCollection services)
    {
        services.AddLogging(configure => 
        {
            configure.AddConsole();
            configure.AddRoundTheCodeFileLogger(options =>
            {
                
            });
        }).AddScoped<Form1>();

        return services;
    }    
}

public static class RoundTheCodeFileLoggerExtensions
{
    public static ILoggingBuilder AddRoundTheCodeFileLogger(this ILoggingBuilder builder, Action<RoundTheCodeFileLoggerOptions> configure)
    {
        builder.Services.AddSingleton<ILoggerProvider, RoundTheCodeFileLoggerProvider>();
        builder.Services.Configure(configure);
        return builder;
    }
}