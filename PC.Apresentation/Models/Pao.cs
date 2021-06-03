using System.ComponentModel.DataAnnotations;

namespace PC.Apresentation.Models
{
    public class Pao
    {
        [Key]
        public int Id { get; private set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
    }
}
