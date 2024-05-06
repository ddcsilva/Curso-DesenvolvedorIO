using Microsoft.AspNetCore.Mvc;
using DevIO.App.ViewModels;
using DevIO.Business.Interfaces;
using AutoMapper;
using DevIO.Business.Models;

namespace DevIO.App.Controllers
{
    public class ProdutosController(IProdutoRepository produtoRepository, IFornecedorRepository fornecedorRepository, IMapper mapper) : BaseController
    {
        private readonly IProdutoRepository _produtoRepository = produtoRepository;
        private readonly IFornecedorRepository _fornecedorRepository = fornecedorRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<IActionResult> Index()
        {
            // 1. Obtém todos os produtos do banco de dados.
            // 2. Mapeia a lista de produtos para uma lista de ProdutoViewModel.
            // 3. Retorna a view com a lista de produtos mapeada.

            return View(_mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.ObterProdutosComFornecedoresAsync()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            // 1. Obtém o produto com fornecedor por ID.
            // 2. Retorna o produto mapeado.
            // 3. Se o produto não existir, retorna NotFound.
            // 4. Retorna a view com o produto mapeado.

            var produtoViewModel = await ObterProdutoComFornecedorPorIdAsync(id);

            if (produtoViewModel == null) return NotFound();

            return View(produtoViewModel);
        }

        public async Task<IActionResult> Create()
        {
            // 1. Cria um novo produtoViewModel.
            // 2. Popula a lista de fornecedores no produtoViewModel.
            // 3. Retorna a view de criação de produto com o produtoViewModel.

            ProdutoViewModel produtoViewModel = await PopularFornecedores(new ProdutoViewModel());
            return View(produtoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdutoViewModel produtoViewModel)
        {
            // 1. Popula a lista de fornecedores no produtoViewModel.
            // 2. Se o modelo não for válido, retorna a view com o produtoViewModel.
            // 3. Adiciona o produto ao banco de dados.
            // 4. Retorna a view com o produtoViewModel.

            produtoViewModel = await PopularFornecedores(produtoViewModel);

            if (!ModelState.IsValid) return View(produtoViewModel);

            await _produtoRepository.AdicionarAsync(_mapper.Map<Produto>(produtoViewModel));

            return View(produtoViewModel);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var produtoViewModel = await ObterProdutoComFornecedorPorIdAsync(id);

            if (produtoViewModel == null) return NotFound();

            return View(produtoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProdutoViewModel produtoViewModel)
        {
            // 1. Se o ID do produto não for igual ao ID do produtoViewModel, retorna NotFound.
            // 2. Se o modelo não for válido, retorna a view com o produtoViewModel.
            // 3. Atualiza o produto no banco de dados.
            // 4. Redireciona para a ação Index.

            if (id != produtoViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(produtoViewModel);

            await _produtoRepository.AtualizarAsync(_mapper.Map<Produto>(produtoViewModel));

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            // 1. Obtém o produto com fornecedor por ID.
            // 2. Se o produto não existir, retorna NotFound.
            // 3. Retorna a view com o produto.

            var produto = await ObterProdutoComFornecedorPorIdAsync(id);

            if (produto == null) return NotFound();

            return View(produto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            // 1. Obtém o produto por ID.
            // 2. Se o produto não existir, retorna NotFound.
            // 3. Remove o produto do banco de dados.
            // 4. Redireciona para a ação Index.

            var produto = await _produtoRepository.ObterPorIdAsync(id);

            if (produto == null) return NotFound();

            await _produtoRepository.RemoverAsync(id);

            return RedirectToAction(nameof(Index));
        }

        private async Task<ProdutoViewModel> ObterProdutoComFornecedorPorIdAsync(Guid id)
        {
            // 1. Obtém um produto com fornecedor por ID.
            // 2. Mapeia o produto para um produtoViewModel.
            // 3. Retorna o produtoViewModel.

            var produto = _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterProdutoComFornecedorPorIdAsync(id));
            produto.Fornecedores = _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterTodosAsync());
            return produto;
        }

        private async Task<ProdutoViewModel> PopularFornecedores(ProdutoViewModel produto)
        {
            // 1. Obtém todos os fornecedores do banco de dados.
            // 2. Mapeia a lista de fornecedores para uma lista de FornecedorViewModel.
            // 3. Adiciona a lista de fornecedores ao produtoViewModel.
            // 4. Retorna o produtoViewModel.

            produto.Fornecedores = _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterTodosAsync());
            return produto;
        }
    }
}
