using MiniBanco.Exceptions;
using MiniBanco.Services;

namespace MiniBanco.Controllers
{
    public class LoginController
    {
        private readonly UserService userService = new();

        public async Task<string> LoginAsync(User user)
        {
            try
            {
                return await userService.GetUserAsync(user);
            }
            catch (LoginInvalidCredentialsException)
            {
                return $"ERRO 00: Dados incorretos para autenticação com os dados informados. Usuário: {user.UserName}, Senha: {user.Password}";
            }
        }
    }
}
