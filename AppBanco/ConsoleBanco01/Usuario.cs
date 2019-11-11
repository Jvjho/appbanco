using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Adicionar referencia dessa anotação para que ela possa ser usada aqui
using System.ComponentModel.DataAnnotations;

namespace ConsoleBanco01
{
    class Usuario
    {
        // digitar "prop" e dar Tab duas vezes
        //Estrutura basica para montar os atributos
        public int MyProperty { get; set; }

        [Required]
        public int IdUsu { get; set; }

        [Required]
        [MaxLength(50)]
        public string NomeUsu { get; set; }

        [Required]
        [MaxLength(50)]
        public string Cargo { get; set; }

        public DateTime DataNasc { get; set; }

    }
}
