namespace MiniBanco.Configurations
{
    public sealed class MainConfiguration
    {
        public MainConfiguration()
        {
            _ = new AppConfiguration();
            _ = new DbConfiguration();
            _ = new Swagger2Configuration();
            _ = new JWTConfiguration();
       }
    }
}
