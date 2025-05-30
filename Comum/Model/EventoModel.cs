using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dap = Dapper.Contrib.Extensions;

namespace Son.Comum.Model
{
    [Dap.Table("Evento")]
    public class EventoModel
    {
        [Dap.Key]
        public int IdEvento { get; set; }
        [Required(ErrorMessage = "ID da pessoa obrigatório")]
        public int IdPessoa { get; set; }
        [Required(ErrorMessage = "Data obrigatória")]
        public DateTime Data { get; set; }
        [Dap.Write(false)]
        public List<MusicaEventoModel> MusicaEvento { get; set; }

    }
}
