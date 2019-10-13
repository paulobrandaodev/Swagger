using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFDatabaseFirts.Models
{
    [Table("cadastro")]
    public partial class Cadastro
    {
        public Cadastro()
        {
            Endereco = new HashSet<Endereco>();
        }

        [Key]
        public int IdCadastro { get; set; }
        [StringLength(50)]
        public string Nome { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCadastro { get; set; }

        [InverseProperty("IdCadastroNavigation")]
        public virtual ICollection<Endereco> Endereco { get; set; }
    }
}
