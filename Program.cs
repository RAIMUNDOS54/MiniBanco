using MiniBanco.Configurations;

internal class Program
{
    public static WebApplicationBuilder? WAB;
    public static WebApplication? WA;

    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        WAB = builder;

        _ = new MainConfiguration();

        var app = builder.Build();

        WA = app;

        _ = new ControllerConfiguration();

        _ = new UseConfiguration();
    }
}
