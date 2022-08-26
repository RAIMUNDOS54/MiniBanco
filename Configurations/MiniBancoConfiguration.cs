namespace MiniBanco.Configurations
{
    public abstract class MiniBancoConfiguration
    {
        protected readonly WebApplicationBuilder? builder = Program.WAB;

        protected readonly WebApplication? app = Program.WA;

        internal abstract void Config();
    }
}