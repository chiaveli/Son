using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dap = Dapper.Contrib.Extensions;

namespace Son.Comum.Model
{
    [Dap.Table("MusicaEvento")]
    public class MusicaEventoModel
    {
        [Dap.Key]
        public int IdMusicaEvento { get; set; }
        [Required(ErrorMessage = "ID da música obrigatório")]
        public int IdMusica { get; set; }
        [Required(ErrorMessage = "ID do evento obrigatório.")]
        public int IdEvento { get; set; }
        public int Sequencia { get; set; }
        [Required(ErrorMessage = "Descrição obrogatória.")]
        [MaxLength(45, ErrorMessage = "No máximo 45 caracteres")]
        public string Descricao { get; set; }
        [Dap.Write(false)]
        public MusicaModel Musica { get; set; }
    }
}
