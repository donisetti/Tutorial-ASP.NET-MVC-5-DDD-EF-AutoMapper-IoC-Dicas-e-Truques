using ArquiteturaDDD.Domain.Entities;
using ArquiteturaDDD.Domain.Interfaces;
using ArquiteturaDDD.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaDDD.Infra.Data.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente> , IClienteRepository
    {
        //Definir buscas mais expecificas(caso necessario).
    }
}
