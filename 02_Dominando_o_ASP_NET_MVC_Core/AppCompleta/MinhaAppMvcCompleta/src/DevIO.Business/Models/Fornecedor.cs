namespace DevIO.Business.Models;

/// <summary>
/// Classe que representa um fornecedor.
/// </summary>
public class Fornecedor : Entity
{
    public string Nome { get; set; } = string.Empty;
    public string Documento { get; set; } = string.Empty;
    public TipoFornecedor TipoFornecedor { get; set; }
    public bool Ativo { get; set; }

    // Relacionamentos do Entity Framework
    public Endereco? Endereco { get; set; }
    public IEnumerable<Produto> Produtos { get; set; } = [];
}
