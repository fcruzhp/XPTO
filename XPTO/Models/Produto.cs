using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XPTO
{
    [Table("produto")]
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        public int Coluna1 { get; set; }

        public int Coluna2 { get; set; }

        public String NomeProduto { get; set; }

    }
}
