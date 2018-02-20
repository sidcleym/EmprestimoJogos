using EmprestimoJogos.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoJogos.Domain.IRepository
{
    public class UsuarioConfigurations : EntityTypeConfiguration<Usuario>
    {

        public UsuarioConfigurations()
        {
            Property(x=> x.Nome).HasColumnName("Nome").HasMaxLength(100).IsRequired();
            Property(x => x.Email).HasColumnName("Emal").HasMaxLength(100)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new  IndexAnnotation(new IndexAttribute("IX_Email",1) {IsUnique =true }));
        }
    }
}
