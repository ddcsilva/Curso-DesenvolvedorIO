using Microsoft.AspNetCore.Mvc;
using DevIO.App.ViewModels;
using DevIO.Business.Interfaces;
using AutoMapper;
using DevIO.Business.Models;

namespace DevIO.App.Controllers;

/// <summary>
/// Classe que representa o controlador de fornecedores.
/// </summary>
/// <param name="fornecedorRepository">Repositório de fornecedores.</param>
public class FornecedoresController(IFornecedorRepository fornecedorRepository, IMapper mapper) : BaseController
{
    private readonly IFornecedorRepository _fornecedorRepository = fornecedorRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IActionResult> Index()
    {
        // 1. Obtém todos os fornecedores do banco de dados.
        // 2. Mapeia a lista de fornecedores para uma lista de FornecedorViewModel.
        // 3. Retorna a view com a lista de fornecedores mapeada.

        return View(_mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterTodosAsync()));
    }

    public async Task<IActionResult> Details(Guid id)
    {
        // 1. Obtém o fornecedor com endereço por ID.
        // 2. Retorna o fornecedor mapeado.
        // 3. Se o fornecedor não existir, retorna NotFound.
        // 4. Retorna a view com o fornecedor mapeado.

        var fornecedorViewModel = await ObterFornecedorComEnderecoPorIdAsync(id);

        if (fornecedorViewModel == null) return NotFound();

        return View(fornecedorViewModel);
    }

    public IActionResult Create()
    {
        // 1. Retorna a view de criação de fornecedor.

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(FornecedorViewModel fornecedorViewModel)
    {
        // 1. Se o modelo não for válido, retorna a view com o fornecedor.
        // 2. Mapeia o fornecedorViewModel para um fornecedor.
        // 3. Adiciona o fornecedor ao banco de dados.
        // 4. Redireciona para a ação Index.

        if (!ModelState.IsValid) return View(fornecedorViewModel);

        var fornecedor = _mapper.Map<Fornecedor>(fornecedorViewModel);
        await _fornecedorRepository.AdicionarAsync(fornecedor);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        // 1. Obtém o fornecedor com endereço por ID.
        // 2. Retorna o fornecedor mapeado.
        // 3. Se o fornecedor não existir, retorna NotFound.
        // 4. Retorna a view com o fornecedor mapeado.

        var fornecedorViewModel = await ObterFornecedorComEnderecoPorIdAsync(id);

        if (fornecedorViewModel == null) return NotFound();

        return View(fornecedorViewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, FornecedorViewModel fornecedorViewModel)
    {
        // 1. Se o ID for diferente do ID do fornecedor, retorna NotFound.
        // 2. Se o modelo não for válido, retorna a view com o fornecedor.
        // 3. Mapeia o fornecedorViewModel para um fornecedor.
        // 4. Atualiza o fornecedor no banco de dados.
        // 5. Redireciona para a ação Index.

        if (id != fornecedorViewModel.Id) return NotFound();

        if (!ModelState.IsValid) return View(fornecedorViewModel);

        var fornecedor = _mapper.Map<Fornecedor>(fornecedorViewModel);
        await _fornecedorRepository.AtualizarAsync(fornecedor);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(Guid id)
    {
        // 1. Obtém o fornecedor com endereço por ID.
        // 2. Retorna o fornecedor mapeado.
        // 3. Se o fornecedor não existir, retorna NotFound.
        // 4. Retorna a view com o fornecedor mapeado.

        var fornecedorViewModel = await ObterFornecedorComEnderecoPorIdAsync(id);

        if (fornecedorViewModel == null)
        {
            return NotFound();
        }

        return View(fornecedorViewModel);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        // 1. Obtém o fornecedor com endereço por ID.
        // 2. Se o fornecedor não existir, retorna NotFound.
        // 3. Remove o fornecedor do banco de dados.
        // 4. Redireciona para a ação Index.

        var fornecedorViewModel = await ObterFornecedorComEnderecoPorIdAsync(id);

        if (fornecedorViewModel == null) return NotFound();

        await _fornecedorRepository.RemoverAsync(id);

        return RedirectToAction(nameof(Index));
    }

    private async Task<FornecedorViewModel> ObterFornecedorComEnderecoPorIdAsync(Guid id)
    {
        return _mapper.Map<FornecedorViewModel>(await _fornecedorRepository.ObterFornecedorComEnderecoPorIdAsync(id));
    }

    private async Task<FornecedorViewModel> ObterFornecedorComProdutosEEnderecoPorIdAsync(Guid id)
    {
        return _mapper.Map<FornecedorViewModel>(await _fornecedorRepository.ObterFornecedorComProdutosEEnderecoPorIdAsync(id));
    }
}
