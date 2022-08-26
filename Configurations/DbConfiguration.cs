namespace MiniBanco.Configurations
{
    public class DbConfiguration : MiniBancoConfiguration
    {
        private readonly string? ConnectionString;

        public DbConfiguration()
        {
            ConnectionString = builder?.Configuration?.GetSection("ConnectionStrings")["prod"]?.ToString();

            Config();
        }

        internal sealed override void Config()
        {
            DbContext();
        }

        private void DbContext() => builder?.Services.AddDbContext<MiniBancoContext>(o => o.UseSqlServer(ConnectionString));
    }
}
