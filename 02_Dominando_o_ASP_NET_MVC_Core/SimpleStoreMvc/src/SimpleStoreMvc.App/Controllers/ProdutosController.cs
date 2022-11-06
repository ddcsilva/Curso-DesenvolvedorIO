using AutoMapper;
using DevIO.Business.Models;
using Microsoft.AspNetCore.Mvc;
using SimpleStoreMvc.App.ViewModels;
using SimpleStoreMvc.Business.Interfaces;

namespace SimpleStoreMvc.App.Controllers
{
    public class ProdutosController : BaseController
    {
        private readonly IProdutoRepository produtoRepository;
        private readonly IFornecedorRepository fornecedorRepository;
        private readonly IMapper mapper;

        public ProdutosController(IProdutoRepository produtoRepository, IFornecedorRepository fornecedorRepository, IMapper mapper)
        {
            this.produtoRepository = produtoRepository;
            this.fornecedorRepository = fornecedorRepository;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(this.mapper.Map<IEnumerable<ProdutoViewModel>>(await this.produtoRepository.ObterProdutosFornecedores()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var produtoViewModel = await ObterProduto(id);

            if (produtoViewModel == null)
            {
                return NotFound();
            }

            return View(produtoViewModel);
        }

        public async Task<IActionResult> Create()
        {
            var produtoViewModel = await PopularFornecedores(new ProdutoViewModel());

            return View(produtoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FornecedorId,Nome,Descricao,ImagemUpload,Valor,Ativo")] ProdutoViewModel produtoViewModel)
        {
            produtoViewModel = await PopularFornecedores(produtoViewModel);

            if (!ModelState.IsValid)
            {
                return View(produtoViewModel);
            }

            await this.produtoRepository.Adicionar(this.mapper.Map<Produto>(produtoViewModel));

            return View(produtoViewModel);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var produtoViewModel = await ObterProduto(id);

            if (produtoViewModel == null)
            {
                return NotFound();
            }

            return View(produtoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProdutoViewModel produtoViewModel)
        {
            if (id != produtoViewModel.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(produtoViewModel);
            }

            await this.produtoRepository.Atualizar(this.mapper.Map<Produto>(produtoViewModel));

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var produto = await ObterProduto(id);

            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var produto = await ObterProduto(id);

            if (produto == null)
            {
                return NotFound();
            }

            await this.produtoRepository.Remover(id);

            return RedirectToAction(nameof(Index));
        }

        private async Task<ProdutoViewModel> ObterProduto(Guid id)
        {
            var produto = this.mapper.Map<ProdutoViewModel>(await this.produtoRepository.ObterProdutoFornecedor(id));
            produto.Fornecedores = this.mapper.Map<IEnumerable<FornecedorViewModel>>(await this.fornecedorRepository.ObterTodos());
            return produto;
        }

        private async Task<ProdutoViewModel> PopularFornecedores(ProdutoViewModel produto)
        {
            produto.Fornecedores = this.mapper.Map<IEnumerable<FornecedorViewModel>>(await this.fornecedorRepository.ObterTodos());
            return produto;
        }
    }
}
