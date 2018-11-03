using System.Data.Entity;

namespace XPTO
{
    public class XPTOContext : DbContext
    {
        public XPTOContext() : base()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<XPTOContext, XPTO.Migrations.Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}
