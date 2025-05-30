using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dap = Dapper.Contrib.Extensions;

namespace Son.Comum.Model
{
    [Dap.Table("PessoaEvento")]
    public class PessoaEventoModel
    {
        [Dap.Key]
        public int IdPessoaEvento { get; set; }
        [Required(ErrorMessage = "ID da pessoa obrigatório")]
        public int IdPessoa { get; set; }
        [Required(ErrorMessage = "ID do evento obrogatório.")]
        public int IdEvento { get; set; }
    }
}
