using AutoMapper;
using DevIO.Business.Models;
using Microsoft.AspNetCore.Mvc;
using SimpleStoreMvc.App.ViewModels;
using SimpleStoreMvc.Business.Interfaces;

namespace SimpleStoreMvc.App.Controllers
{
    public class FornecedoresController : BaseController
    {
        private readonly IFornecedorRepository fornecedorRepository;
        private readonly IMapper mapper;

        public FornecedoresController(IFornecedorRepository fornecedorRepository, IMapper mapper)
        {
            this.fornecedorRepository = fornecedorRepository;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(this.mapper.Map<IEnumerable<FornecedorViewModel>>(await this.fornecedorRepository.ObterTodos()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var fornecedorViewModel = await ObterFornecedorEndereco(id);

            if (fornecedorViewModel == null)
            {
                return NotFound();
            }

            return View(fornecedorViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FornecedorViewModel fornecedorViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(fornecedorViewModel);
            }

            var fornecedor = this.mapper.Map<Fornecedor>(fornecedorViewModel);
            await this.fornecedorRepository.Adicionar(fornecedor);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var fornecedorViewModel = await ObterFornecedorProdutosEndereco(id);

            if (fornecedorViewModel == null)
            {
                return NotFound();
            }

            return View(fornecedorViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, FornecedorViewModel fornecedorViewModel)
        {
            if (id != fornecedorViewModel.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(fornecedorViewModel);
            }

            var fornecedor = this.mapper.Map<Fornecedor>(fornecedorViewModel);
            await this.fornecedorRepository.Atualizar(fornecedor);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var fornecedorViewModel = await ObterFornecedorEndereco(id);

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
            var fornecedorViewModel = await ObterFornecedorEndereco(id);

            if (fornecedorViewModel == null)
            {
                return NotFound();
            }

            await this.fornecedorRepository.Remover(id);

            return RedirectToAction(nameof(Index));
        }

        private async Task<FornecedorViewModel> ObterFornecedorEndereco(Guid id)
        {
            return this.mapper.Map<FornecedorViewModel>(await this.fornecedorRepository.ObterFornecedorEndereco(id));
        }

        private async Task<FornecedorViewModel> ObterFornecedorProdutosEndereco(Guid id)
        {
            return this.mapper.Map<FornecedorViewModel>(await this.fornecedorRepository.ObterFornecedorProdutosEndereco(id));
        }
    }
}
