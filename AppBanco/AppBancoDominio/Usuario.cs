using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Adicionar referencia dessa anotação para que ela possa ser usada aqui
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AppBancoDominio
{
    public class Usuario
    {
       // digitar "prop" e dar Tab duas vezes
       //Estrutura basica para montar os atributos
       // public int MyProperty { get; set; }

        [DisplayName("Identificação")]
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public int IdUsu { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [MaxLength(50)]
        public string NomeUsu { get; set; }

        [DisplayName("Cargo")]
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [MaxLength(50)]
        public string Cargo { get; set; }

        [DisplayName("Data de nascimento")]
        [Required(ErrorMessage = "Este campo é obrigatório!")]         
        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNasc { get; set; }

    }
}
