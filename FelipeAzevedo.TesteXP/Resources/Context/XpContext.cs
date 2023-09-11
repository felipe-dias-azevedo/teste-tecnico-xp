using FelipeAzevedo.TesteXP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FelipeAzevedo.TesteXP.Resources.Context
{
    public class XpContext : DbContext
    {
        private readonly IConfiguration _config;
        
        public XpContext(DbContextOptions<XpContext> options, IConfiguration config)
            : base(options)
        {
            _config = config;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClienteModel>()
                .HasMany(s => s.Enderecos)
                .WithOne(a => a.Cliente)
                .HasForeignKey(e => e.IdCliente);
        }

        public DbSet<ClienteModel> Clientes { get; set; }
        
        public DbSet<EnderecoModel> Enderecos { get; set; }
    }
}