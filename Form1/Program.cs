using Microsoft.Extensions.DependencyInjection;
using WinFormsApp2.Classes;
using WinFormsApp2.Interfaces;

namespace WinFormsApp2;
class Program
{
    public static IServiceProvider ServiceProvider { get; private set; }

    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.EnableVisualStyles();
        
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);

        ServiceProvider = serviceCollection.BuildServiceProvider();
        Application.Run(ServiceProvider.GetRequiredService<JsonLocalizator>());
    }   
    private static void ConfigureServices(ServiceCollection services)
    {
        services.AddTransient<ICast, Cast>();
        services.AddTransient<ICreateJson, JsonCreator>();
        services.AddTransient<IGetFileText, GetFileText>();
        services.AddTransient<ITranslate, JsonTranslate>();
        services.AddTransient<IViewList, ViewList>();
        services.AddTransient<IUpdateList, ListUpdater>();
        services.AddTransient<JsonLocalizator>();
        services.AddTransient<IAddControls, ControlsAdder>();
        services. AddSingleton<IClearControls, ControlsCleaner>();
        services. AddTransient<ICreateDirectory, DirectoryCreator>();
        services. AddTransient<ICreateResx, ResxCreator>();
    }
}   