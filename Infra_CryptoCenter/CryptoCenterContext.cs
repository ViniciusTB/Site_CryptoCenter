using System;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Infrastructure;
using Domain_CryptoCenter.Domain;

namespace Infra_CryptoCenter
{
    public class CryptoCenterContext : DbContext
    {
        public CryptoCenterContext() : base("CryptoCenterDB")
        {

        }

        public DbSet<Moeda> Moeda { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Transacao> Transacao { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

        }

    }
}
