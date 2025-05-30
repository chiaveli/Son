using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dap = Dapper.Contrib.Extensions;

namespace Son.Comum.Model
{
    [Dap.Table("Pessoa")]
    public class PessoaModel
    {
        [Dap.Key]
        public long IdPessoa { get; set; }

        [Required(ErrorMessage = "Nome obrigatório")]
        [MaxLength(70, ErrorMessage = "Nome deve conter no máximo 70 caracteres")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [MaxLength(15, ErrorMessage = "Fone no máximo 15 caracteres")]
        public string Fone { get; set; }
        
        [Required(ErrorMessage = "Email obrigatório")]
        [EmailAddress(ErrorMessage = "Informe um email válido.")]
        [MaxLength(150, ErrorMessage = "Email no máximo 150 caracteres")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Data de nascimento obrigatório")]
        [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        public DateTime? DataNasc { get; set; }

        [Required(ErrorMessage = "Definição de sexo obrigatório")]
        [MaxLength(1, ErrorMessage = "Campo sexo no máximo 1 caracter")]
        public string Sexo { get; set; }
        
        [Required(ErrorMessage = "Data de cadastro obrigatório")]        
        public DateTime DataCadastro { get; set; }
        
        [Required(ErrorMessage = "Senha obrigatório")]        
        [MinLength(8, ErrorMessage = "Senha deve ter no mínimo 8 caracteres.")]        
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        
        [Required(ErrorMessage = "Confirmação da senha obrigatória")]
        [Dap.Write(false)]
        [Compare("Senha", ErrorMessage = "Senha não confere.")]       
        public string ConfirmarSenha { get; set; }
        
        [Required(ErrorMessage = "Tipo Ativo/Inativo obrigatório")]
        public string Ativo { get; set; }

        [Required(ErrorMessage = "Perfil obrigatório")]
        public string Perfil { get; set; }
    }    
}
