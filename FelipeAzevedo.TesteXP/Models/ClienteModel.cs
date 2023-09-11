using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FelipeAzevedo.TesteXP.Models
{
    [Table("TAB_CLI")]
    public class ClienteModel
    {
        [Key]
        [Column("ID_CLI")]
        public string Id { get; set; }

        [Column("CPF")]
        public string Cpf { get; set; }

        [Column("NM")]
        public string Nome { get; set; }

        [Column("TEL")]
        public string Telefone { get; set; }

        [Column("EMAIL")]
        public string Email { get; set; }
        
        public virtual List<EnderecoModel> Enderecos { get; set; }
    }
}
