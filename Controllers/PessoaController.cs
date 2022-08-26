using MiniBanco.Exceptions;
using MiniBanco.Services;
using MiniBanco.Validators;

namespace MiniBanco.Controllers
{
    public class PessoaController
    {
        private readonly PessoaService pessoaService = new();

        public async Task<List<Pessoa>> GetPessoasAsync()
        {
            return await pessoaService.GetAllPessoasAsync();
        }

        public async Task<List<Pessoa>> GetPessoasAsync(string uf)
        {
            return await pessoaService.GetAllPessoasAsync(uf);
        }

        public async Task<Pessoa> GetPessoaAsync(long codigo)
        {
            return await pessoaService.GetPessoaAsync(codigo);
        }

        public async Task<Pessoa> CreatePessoaAsync(Pessoa pessoa)
        {
            string strValidator = await PessoaValidator.Validate(pessoa);

            if (string.IsNullOrEmpty(strValidator))
            {
                return await pessoaService.CreatePessoaAsync(pessoa);
            }
            else
            {
                throw new PessoaValidationException(strValidator);
            }
        }

        internal Task<bool> DeletePessoaAsync(long codigo)
        {
            return pessoaService.DeletePessoaAsync(codigo);
        }

        internal Task<Pessoa> UpdatePessoaAsync(Pessoa pessoa)
        {
            return pessoaService.UpdatePessoaAsync(pessoa);
        }
    }
}
