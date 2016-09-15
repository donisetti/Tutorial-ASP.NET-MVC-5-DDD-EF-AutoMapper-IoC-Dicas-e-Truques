using ArquiteturaDDD.Domain.Entities;
using ArquiteturaDDD.Domain.Interfaces.Repositories;
using ArquiteturaDDD.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaDDD.Domain.Services
{
    public class ProdutoService : ServiceBase<Produto>, IProdutoService
    {
        private readonly IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public IEnumerable<Produto> BuscarPorNome(string nome)
        {
            return _repository.BuscarPorNome(nome);
        }
    }
}
