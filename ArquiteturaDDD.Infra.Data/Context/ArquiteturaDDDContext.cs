using ArquiteturaDDD.Domain.Entities;
using ArquiteturaDDD.Infra.Data.EntityConfig;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaDDD.Infra.Data.Context
{
    public class ArquiteturaDDDContext : DbContext
    {
        public ArquiteturaDDDContext()
            : base("ArquiteturaDDD")//String de conexao
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();//REMOVE PLURALIZACAO
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();//REMOVE O DELETE EM CASCADA 1 -> n
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();//REMOVE O DELETE EM CASCADA n -> n

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());//Configura os id, ex: ClienteId é um id válido

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));//Configura as strings como varchar

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));//Configura um padrao de 100


            modelBuilder.Configurations.Add(new ClienteConfiguration());//Adiciona as configuraçoes extras da entidade cliente
            modelBuilder.Configurations.Add(new ProdutoConfiguration());//Adiciona as configuraçoes extras da entidade produto
        }

        public override int SaveChanges()//Sobreescreve o SaveChanges
        {

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            return base.SaveChanges();
        }
    }
}
