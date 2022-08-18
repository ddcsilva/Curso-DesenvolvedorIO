using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhandoComFormularios.Models
{
    public class Filme
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Título é obrigatório")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "O campo Título precisa ter entre 3 ou 60 caracteres")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo Data de Lançamento é obrigatório")]
        [DataType(DataType.DateTime, ErrorMessage = "O campo Data de Lançamento em formato incorreto")]
        [Display(Name = "Data de Lançamento")]
        public DateTime DataLancamento { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\u00C0-\u00FF""\w-]*$", ErrorMessage = "O campo Gênero está em formato incorreto")]
        [StringLength(30, ErrorMessage = "O campo Gênero deve possuir no máximo 30 caracteres"), Required(ErrorMessage = "O campo Genero é obrigatório")]
        [Display(Name = "Gênero")]
        public string Genero { get; set; }

        [Range(1, 1000, ErrorMessage = "O campo Valor deve ter um valor de 1 a 1000")]
        [Required(ErrorMessage = "O campo Valor é obrigatório")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "O campo Avaliação é obrigatório")]
        [RegularExpression(@"^[0-5]*$", ErrorMessage = "O campo Avaliacao está em formato incorreto")]
        [Display(Name = "Avaliação")]
        public int Avaliacao { get; set; }
    }
}
