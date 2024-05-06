using AutoMapper;
using DevIO.App.ViewModels;
using DevIO.Business.Models;

namespace DevIO.App.AutoMapper;

/// <summary>
/// Classe que representa a configuração do AutoMapper.
/// </summary>
public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap(); // Mapeia Fornecedor para FornecedorViewModel e vice-versa
        CreateMap<Endereco, EnderecoViewModel>().ReverseMap(); // Mapeia Endereco para EnderecoViewModel e vice-versa
        CreateMap<Produto, ProdutoViewModel>().ReverseMap(); // Mapeia Produto para ProdutoViewModel e vice-versa
    }
}