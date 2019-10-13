using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFDatabaseFirts.Models
{
    [Table("endereco")]
    public partial class Endereco
    {
        [Key]
        public int IdEndereco { get; set; }
        [Column("Endereco")]
        [StringLength(150)]
        public string Endereco1 { get; set; }
        public int? IdCadastro { get; set; }

        [ForeignKey(nameof(IdCadastro))]
        [InverseProperty(nameof(Cadastro.Endereco))]
        public virtual Cadastro IdCadastroNavigation { get; set; }
    }
}
