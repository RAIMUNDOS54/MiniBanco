using System.Runtime.Serialization;

namespace MiniBanco.Exceptions
{
    public class PessoaException : APIException
    {
        public PessoaException(string? message) : base(message)
        {
        }
    }
}
