using ArquiteturaDDD.Application.Interfaces;
using ArquiteturaDDD.Domain.Entities;
using ArquiteturaDDD.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaDDD.Application
{
    public class ProdutoAppService : AppServiceBase<Produto>, IProdutoAppService
    {

        private readonly IProdutoService _produtoService;

        public ProdutoAppService(IProdutoService produtoService) 
            : base(produtoService)
        {
            _produtoService = produtoService;
        }

        public IEnumerable<Produto> BuscarProdutoPorNome(string nome)
        {
            return _produtoService.BuscarPorNome(nome);
        }
    }
}
