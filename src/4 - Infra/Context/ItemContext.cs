using Domain.Entities;
using Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context
{

    public class ItemContext : DbContext
    {
        public ItemContext() { }
        public ItemContext(DbContextOptions<ItemContext> options) : base(options) { }

        public DbSet<Item> Itens { get; set; }

       /*  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseMySql(@"Server=192.168.0.2;Port=3306;Database=wishlistapi;Uid=porps12;Pwd=porpeta12;");
        } */

        protected override void OnModelCreating(ModelBuilder builder) 
        {
            builder.ApplyConfiguration(new ItemMap());
        }
    }


}
