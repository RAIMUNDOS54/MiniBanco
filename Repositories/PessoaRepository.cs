namespace MiniBanco.Repositories
{
    public class PessoaRepository
    {
        private readonly MiniBancoContext dbContext = new();

        public async Task<List<Pessoa>> GetAllPessoas()
        {
            return await dbContext.Pessoas.ToListAsync();
        }

        public async Task<List<Pessoa>> GetPessoas(string uf)
        {
            return await dbContext.Pessoas.Where(p => p.Uf == uf).ToListAsync();
        }

       public async Task<Pessoa> GetPessoa(long codigo)
        {
            return await dbContext.Pessoas.Where(p => p.Codigo == codigo).FirstOrDefaultAsync();
        }

        public async Task<Pessoa> CreatePessoa(Pessoa pessoa)
        {
            _ = await dbContext.Pessoas.AddAsync(pessoa);

            _ = await dbContext.SaveChangesAsync();

            return pessoa;
        }

        internal Task<bool> DeletePessoaAsync(long codigo)
        {
            bool blnReturn = false;

            try
            {
                dbContext.Pessoas.Remove(new Pessoa { Codigo = codigo });

                dbContext.SaveChangesAsync();

                blnReturn = true;
            }
            catch
            {
                blnReturn = false;
            }

            return Task.Run(() => blnReturn);
        }

        internal Task<Pessoa> UpdatePessoaAsync(Pessoa pessoa)
        {
            dbContext.Pessoas.Update(pessoa);

            dbContext.SaveChangesAsync();

            return Task.Run(() => pessoa);
        }
    }
}
