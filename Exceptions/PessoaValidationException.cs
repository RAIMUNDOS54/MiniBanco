namespace MiniBanco.Exceptions
{
    public class PessoaValidationException : PessoaException
    {
        public PessoaValidationException(string? message) : base(message)
        {
        }
    }
}
