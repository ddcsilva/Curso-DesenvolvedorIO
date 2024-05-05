namespace DevIO.Business.Models;

/// <summary>
/// Classe que representa um endereço de um fornecedor.
/// </summary>
public class Endereco : Entity
{
    public Guid FornecedorId { get; set; }
    public string Logradouro { get; set; } = string.Empty;
    public string Numero { get; set; } = string.Empty;
    public string Complemento { get; set; } = string.Empty;
    public string Cep { get; set; } = string.Empty;
    public string Bairro { get; set; } = string.Empty;
    public string Cidade { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;

    // Relacionamentos do Entity Framework
    public Fornecedor? Fornecedor { get; set; }
}
