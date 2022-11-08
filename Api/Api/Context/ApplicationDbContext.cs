using Api.Maps;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users {get;set;}
        public DbSet<Cliente> Clientes {get;set;}
        public DbSet<Endereco> Enderecos {get;set;}
        public DbSet<Pedido> Pedidos {get;set;}
        public DbSet<Produto> Produtos {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new EnderecoMap());
            modelBuilder.ApplyConfiguration(new PedidoMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
