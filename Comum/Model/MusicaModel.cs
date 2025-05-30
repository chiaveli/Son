using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dap = Dapper.Contrib.Extensions;

namespace Son.Comum.Model
{
    [Dap.Table("Musica")]
    public class MusicaModel
    {
        [Dap.Key]
        public int IdMusica { get; set; }
        [Required(ErrorMessage = "ID da pessoa obrigatório")]
        public int IdPessoa { get; set; }
        [Required(ErrorMessage = "ID da classificação obrigatório")]
        public int IdClassificacao { get; set; }
        [Required(ErrorMessage = "Título obrigatório")]
        [MaxLength(100,ErrorMessage = "O título deve ter no máximo 100 caracteres.")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Informe o texto da letra da música.")]
        [MaxLength(10000,ErrorMessage = "Texto da letra muito grande, no máximo 10.000 caracteres.")]
        public string Letra { get; set; }
        [Required(ErrorMessage = "Campo (Ativo) obrigatório")]
        public string Ativo { get; set; }
        [Dap.Write(false)]
        public PessoaModel Pessoa { get; set; }
    }
}
