namespace DevIO.Business.Models;

/// <summary>
/// Classe que representa um produto.
/// </summary>
public class Produto : Entity
{
    public Guid FornecedorId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string Imagem { get; set; } = string.Empty;
    public decimal Valor { get; set; }
    public DateTime DataCadastro { get; set; }
    public bool Ativo { get; set; }

    // Relacionamentos do Entity Framework
    public Fornecedor? Fornecedor { get; set; }
}
