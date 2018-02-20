
using EmprestimoJogos.Domain.IRepository;
using EmprestimoJogos.Domain.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EmprestimoJogos.Domain.Infra
{
    public class DataContext : DbContext
    {
        public DataContext() : base("Emprestimo")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Amigo> Amigo { get; set; }
        public DbSet<Jogo> Jogo { get; set; }
        public DbSet<Emprestimo> Emprestimo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Properties<string>().Configure(p=> p.HasColumnType("varchar"));
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new UsuarioConfigurations());
            Database.SetInitializer < DataContext > (new DropCreateDatabaseIfModelChanges<DataContext>());

            //base.OnModelCreating(modelBuilder);
        }
    }
}
