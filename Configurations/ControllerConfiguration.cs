using MiniBanco.Controllers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace MiniBanco.Configurations
{
    public class ControllerConfiguration : MiniBancoConfiguration
    {
        public ControllerConfiguration()
        {
            Config();
        }

        internal sealed override void Config()
        {
            ConfigAuthentication();

            ConfigPessoas();
        }

        internal void ConfigAuthentication()
        {
            app?.MapPost("/api/auth",
            async (User user) =>
            {
                return await new LoginController().LoginAsync(user);
            });
        }

        internal void ConfigPessoas()
        {
            app?.MapGet("/api/pessoas",
            [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
            async (string? uf ) =>
            {
                if (string.IsNullOrEmpty(uf))
                {
                    return await new PessoaController().GetPessoasAsync();
                }
                else
                {
                    return await new PessoaController().GetPessoasAsync(uf);
                }
            });

            app?.MapDelete("/api/pessoas/{Codigo}",
            [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
            async (long codigo) =>
            {
                return await new PessoaController().DeletePessoaAsync(codigo);
            });

            app?.MapPut("/api/pessoas/",
                        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
            async (Pessoa pessoa) =>
                        {
                            return await new PessoaController().UpdatePessoaAsync(pessoa);
                        });

            app?.MapGet("/api/pessoas/{Codigo}",
            [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
            async (long codigo) =>
            {
                return await new PessoaController().GetPessoaAsync(codigo);
            });

            app?.MapPost("/api/pessoas/pessoa",
            [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
            async (Pessoa pessoa) =>
            {
                return await new PessoaController().CreatePessoaAsync(pessoa);
            });
        }
    }
}
