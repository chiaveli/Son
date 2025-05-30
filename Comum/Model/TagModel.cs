using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dap = Dapper.Contrib.Extensions;

namespace Son.Comum.Model
{
    [Dap.Table("Tag")]
    public class TagModel
    {
        [Dap.Key]
        public int IdTag { get; set; }
        [Required(ErrorMessage = "Informe o ID da música.")]
        public int IdMusica { get; set; }
        [Required(ErrorMessage = "Nome obrigatório")]
        [MaxLength(20, ErrorMessage = "Máximo de 20 caracteres")]
        public string Nome { get; set; }
    }
}
