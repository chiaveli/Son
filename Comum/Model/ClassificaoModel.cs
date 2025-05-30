using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dap = Dapper.Contrib.Extensions;

namespace Son.Comum.Model
{
    [Dap.Table("Classificacao")]
    public class ClassificaoModel
    {
        [Dap.Key]
        public int IdClassificacao { get; set; }
        [Required(ErrorMessage = "Descrição obrigatória")]
        [MaxLength(45,ErrorMessage = "No máximo 45 caracteres")]
        public string Descricao { get; set; }
    }
}
