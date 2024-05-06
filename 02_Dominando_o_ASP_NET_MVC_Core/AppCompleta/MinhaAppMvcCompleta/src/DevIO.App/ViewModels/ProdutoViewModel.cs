using System.ComponentModel.DataAnnotations;

namespace DevIO.App.ViewModels;

/// <summary>
/// Classe que representa um produto.
/// </summary>
public class ProdutoViewModel
{
    [Key]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres.", MinimumLength = 2)]
    public string Nome { get; set; } = string.Empty;

    [Display(Name = "Descrição")]
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres.", MinimumLength = 2)]
    public string Descricao { get; set; } = string.Empty;

    public IFormFile? ImagemUpload { get; set; } // IFormFile é um tipo de arquivo que pode ser enviado via formulário

    public string Imagem { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public decimal Valor { get; set; }

    [ScaffoldColumn(false)]
    public DateTime DataCadastro { get; set; }

    [Display(Name = "Ativo?")]
    public bool Ativo { get; set; }

    public FornecedorViewModel? Fornecedor { get; set; }
}
