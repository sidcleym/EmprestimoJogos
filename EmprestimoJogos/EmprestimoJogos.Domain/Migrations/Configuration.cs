namespace EmprestimoJogos.Domain.Migrations
{
    using EmprestimoJogos.Domain.Helpers;
    using EmprestimoJogos.Domain.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EmprestimoJogos.Domain.Infra.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(EmprestimoJogos.Domain.Infra.DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Usuario.AddOrUpdate(new Usuario() { Nome="Sidcley Mendes", Email="sidcleym@gmail.com", SenhaCriptografada = CriptografiaHelper.CriptografarSenha("123456"), DtInclusao = DateTime.Now });
            context.Amigo.AddOrUpdate(new Amigo() { Nome = "Sidcley Mendes", Email = "sidcleym@gmail.com",  DtInclusao = DateTime.Now });
            context.Jogo.AddOrUpdate(new Jogo() { Descricao = "Street Figther", Ano=1998, DtInclusao = DateTime.Now });
        }
    }
}
