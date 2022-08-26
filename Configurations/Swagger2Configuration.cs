namespace MiniBanco.Configurations
{
    public class Swagger2Configuration : MiniBancoConfiguration
    {
        public Swagger2Configuration()
        {
            Config();
        }

        internal sealed override void Config()
        {
            ConfigSwagger();
        }

        private void ConfigSwagger()
        {
            builder?.Services.AddEndpointsApiExplorer();

            builder?.Services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = AppConfiguration.AppName, Version = "v1" });
            });
        }

        public static void UseSwagger()
        {
            Program.WA.UseSwagger();

            Program.WA.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", AppConfiguration.AppName);
            });
        }
    }
}
