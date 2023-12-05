using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using SportsECommerce.Models;

namespace SportsECommerce.Data
{
    public class SportsContext : DbContext
    {
        public SportsContext(DbContextOptions<SportsContext> options) : base(options) { }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Tamanho> Tamanhos { get; set; }
    }
}
