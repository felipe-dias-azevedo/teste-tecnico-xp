using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FelipeAzevedo.TesteXP.Models
{
    [Table("TAB_END")]
    public class EnderecoModel
    {
        [Key]
        [Column("ID_END")]
        public string Id { get; set; }
        
        [Column("ID_CLI")]
        public string IdCliente { get; set; }

        [Column("CEP")]
        public string Cep { get; set; }
        
        [ForeignKey("IdCliente")]
        public virtual ClienteModel Cliente { get; set; }
    }
}