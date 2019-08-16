using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ApiContact.Models
{
    public class Contato
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }
        [Required]
        [MaxLength(50)]
        public string Canal { get; set; }
        [Required]
        [MaxLength(50)]
        public string Valor { get; set; }
        [MaxLength(50)]
        public string Obs { get; set; }
    }
}