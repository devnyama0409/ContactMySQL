namespace ContactMySQL.Migrations
{
    using MySql.Data.Entity;
    using System.Data.Common;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.History;

    internal sealed class Configuration : DbMigrationsConfiguration<ContactMySQL.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            CodeGenerator = new MySqlMigrationCodeGenerator();
        }

        public class MysqlConfiguration : DbConfiguration
        {
            public MysqlConfiguration()
            {
                SetMigrationSqlGenerator(MySqlProviderInvariantName.ProviderName, () => new MySqlMigrationSqlGenerator());

                SetHistoryContext("MySql.Data.MySqlClient", (dbConnection, defaultSchema) => new MysqlHistoryContext(dbConnection, defaultSchema));
            }
        }

        public class MysqlHistoryContext : HistoryContext
        {
            public MysqlHistoryContext(DbConnection dbConnection, string defaultSchema)
                : base(dbConnection, defaultSchema)
            {
            }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<HistoryRow>().Property(h => h.MigrationId).HasMaxLength(255).IsRequired();
                modelBuilder.Entity<HistoryRow>().Property(h => h.ContextKey).HasMaxLength(255).IsRequired();
            }
        }

        protected override void Seed(ContactMySQL.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
