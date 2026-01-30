using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace projeto01.Models
{
    public class modelo01
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Nome é um campo obrigatorio")]
        [MaxLength(50, ErrorMessage ="Nome precisa ter no maximo 50 caracteres")]

        public string Nome { get; set; }

        [Required(ErrorMessage ="Tipo é um campo obrigatorio")]
        [MaxLength(20, ErrorMessage ="Tipo precisa ter no maximo 20 caracteres")]
        public string Tipo { get; set; }
    }
}