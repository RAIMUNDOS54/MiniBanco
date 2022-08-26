using MiniBanco.Repositories;

namespace MiniBanco.Services
{
    public class PessoaService
    {
        private readonly PessoaRepository pessoaRepository = new();

        public async Task<List<Pessoa>> GetAllPessoasAsync()
        {
            return await pessoaRepository.GetAllPessoas();
        }

        public async Task<List<Pessoa>> GetAllPessoasAsync(string uf)
        {
            return await pessoaRepository.GetPessoas(uf);
        }

        public async Task<Pessoa> GetPessoaAsync(long codigo)
        {
            return await pessoaRepository.GetPessoa(codigo);
        }

        public async Task<Pessoa> CreatePessoaAsync(Pessoa pessoa)
        {
            return await pessoaRepository.CreatePessoa(pessoa);
        }

        internal Task<bool> DeletePessoaAsync(long codigo)
        {
            return pessoaRepository.DeletePessoaAsync(codigo);
        }

        internal Task<Pessoa> UpdatePessoaAsync(Pessoa pessoa)
        {
            return pessoaRepository.UpdatePessoaAsync(pessoa);
        }
    }
}
