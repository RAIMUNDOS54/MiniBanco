using System.ComponentModel.DataAnnotations;

namespace MiniBanco.Validators
{
    public static class PessoaValidator
    {
        public static IEnumerable<ValidationResult> GetValidationErrors(object obj)
        {
            List<ValidationResult> vlrValidationResult = new();

            ValidationContext vcValidationContext = new(obj, null, null);

            Validator.TryValidateObject(obj, vcValidationContext, vlrValidationResult, true);

            return vlrValidationResult;
        }

        public static async Task<string> Validate(object obj)
        {
            string strReturn = string.Empty;

            IEnumerable<ValidationResult> vlrErrors = GetValidationErrors(obj);

            int intErrorsCount = 0;

            foreach (ValidationResult vr in vlrErrors)
            {
                intErrorsCount++;

                strReturn += intErrorsCount + "º Erro: " + vr.ErrorMessage + "\n";
            }

            return await Task.Run(() => strReturn);
        }
    }
}
