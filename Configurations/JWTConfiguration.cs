using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace MiniBanco.Configurations
{
    public class JWTConfiguration : MiniBancoConfiguration
    {
        public static string? ValidIssuer { get; set; }
        public static string? ValidAudience { get; set; }
        public static string? SigningKey { get; set; }

        public JWTConfiguration()
        {
            ValidIssuer = builder?.Configuration["JWT:ValidIssuer"];
            ValidAudience = builder?.Configuration["JWT:ValidAudience"];
            SigningKey = builder?.Configuration["JWT:SigningKey"];

            Config();
        }

        internal override void Config()
        {
            builder?.Services.AddAuthorization();
            builder?.Services.AddAuthentication(opt =>
            {
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = ValidIssuer,
                    ValidAudience = ValidAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SigningKey))
                };
            });
        }

        public string? Login(User user)
        {
            if (user.UserName == "user" && user.Password == "user")
            {
                return GenerateJWT();
            }
            else
            {
                throw new ($"ERRO 00: Dados incorretos para autenticação com os dados informados. Usuário: {user.UserName}, Senha: {user.Password}");
            }
        }

        private string GenerateJWT()
        {
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SigningKey));
            var credentials = new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
            issuer: ValidIssuer,
            audience: ValidAudience,
            claims: null,
            expires: System.DateTime.Now.AddMinutes(120),
            signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static void UseJWT()
        {
            Program.WA.UseAuthentication();
            Program.WA.UseAuthorization();
        }
    }
}
