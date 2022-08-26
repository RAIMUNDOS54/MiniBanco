using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MiniBanco.Models
{
    public partial class Pessoa
    {
        public Pessoa()
        {
            ContasAPagar = new HashSet<ContasApagar>();
            ContasPagas = new HashSet<ContasPaga>();
        }

        public long Codigo { get; set; }

        [Display(Name = "Nome Completo", Description = "Nome.")]
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(255, ErrorMessage = "O nome não deve exceder 255 caracteres.")]
        public string Nome { get; set; } = null!;

        [Display(Name = "CPF/CNPJ", Description = "CPF ou CNPJ usando apenas números.")]
        [Required(ErrorMessage = "O campo CPF/CNPJ obrigatório.")]
        [StringLength(14, ErrorMessage = "O CPF/CNPJ não deve exceder 14 caracteres.")]
        [RegularExpression(@"^([0-9]{3}\.?[0-9]{3}\.?[0-9]{3}\-?[0-9]{2}|[0-9]{2}\.?[0-9]{3}\.?[0-9]{3}\/?[0-9]{4}\-?[0-9]{2})$",
            ErrorMessage = "CPF/CNPJ inválido.")]
        public string Cpfcnpj { get; set; } = null!;

        [Display(Name = "UF", Description = "Sigla do Estado. Exemplo: DF.")]
        [Required(ErrorMessage = "O campo UF é obrigatório. Digite a sigla do Estado.")]
        [StringLength(2, ErrorMessage = "A sigla da Unidade Federativa deve possuir apenas 2 caracteres. Exemplo: BA.")]
        public string Uf { get; set; } = null!;

        [Display(Name = "Data de Nascimento", Description = "Data de Nascimento no formato dd/mm/aaaa")]
        [DisplayFormat(DataFormatString = "dd/MM/yyyy")]
        [Required(ErrorMessage = "O campo Data de Nascimento é obrigatório. Digite a Data de Nascimento no formato: aaaa-mm-dd.")]
        public DateTime DataNascimento { get; set; }

        public virtual ICollection<ContasApagar> ContasAPagar { get; set; }
        public virtual ICollection<ContasPaga> ContasPagas { get; set; }
    }
}
