﻿using System;
using System.Collections.Generic;

namespace MiniBanco.Models
{
    public partial class ContasApagar
    {
        public long Numero { get; set; }
        public long CodigoFornecedor { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime? DataProrrogacao { get; set; }
        public decimal Valor { get; set; }
        public decimal Acrescimo { get; set; }
        public decimal Desconto { get; set; }

        public virtual Pessoa CodigoFornecedorNavigation { get; set; } = null!;
    }
}
