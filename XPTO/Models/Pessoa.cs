using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace XPTO
{
    [Table("pessoa")]
    public class Pessoa
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public String SobreNome { get; set; }
        public DateTime DataNascimento { get; set; }
        public String Sexo { get; set; }
        public String Email { get; set; }
        public bool Booleano { get; set; }
    }
}
