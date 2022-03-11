using System.Data;
using Microsoft.EntityFrameworkCore;

namespace WildWorldImporters.Sales.Dal.SqlServer
{
    public class SalesContext : SalesContext<SalesContext>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options_builder)
        {
            options_builder.UseLazyLoadingProxies();
            options_builder.UseSqlServer(ob => ob.UseNetTopologySuite());
        }

        protected override void OnModelCreating(ModelBuilder model_builder)
        {
            base.OnModelCreating(model_builder);

            model_builder.Entity<BuyingGroup>
            (
                eb
                    =>
                {
                    eb.Property(e => e.ValidFrom).HasComputedColumnSql();
                    eb.Property(e => e.ValidTo).HasComputedColumnSql();
                }
            )
            ;

            model_builder.Entity<City>
            (
                eb
                    =>
                {
                    eb.Property(e => e.ValidFrom).HasComputedColumnSql();
                    eb.Property(e => e.ValidTo).HasComputedColumnSql();
                }
            )
            ;

            model_builder.Entity<Color>
            (
                eb
                    =>
                {
                    eb.Property(e => e.ValidFrom).HasComputedColumnSql();
                    eb.Property(e => e.ValidTo).HasComputedColumnSql();
                }
            )
            ;

            model_builder.Entity<Country>
            (
                eb
                    =>
                {
                    eb.Property(e => e.ValidFrom).HasComputedColumnSql();
                    eb.Property(e => e.ValidTo).HasComputedColumnSql();
                }
            )
            ;

            model_builder.Entity<Customer>
            (
                eb
                    =>
                {
                    eb.Property(e => e.ValidFrom).HasComputedColumnSql();
                    eb.Property(e => e.ValidTo).HasComputedColumnSql();
                }
            )
            ;

            model_builder.Entity<CustomerCategory>
            (
                eb
                    =>
                {
                    eb.Property(e => e.ValidFrom).HasComputedColumnSql();
                    eb.Property(e => e.ValidTo).HasComputedColumnSql();
                }
            )
            ;

            model_builder.Entity<DeliveryMethod>
            (
                eb
                    =>
                {
                    eb.Property(e => e.ValidFrom).HasComputedColumnSql();
                    eb.Property(e => e.ValidTo).HasComputedColumnSql();
                }
            )
            ;

            model_builder.Entity<PackageType>
            (
                eb
                    =>
                {
                    eb.Property(e => e.ValidFrom).HasComputedColumnSql();
                    eb.Property(e => e.ValidTo).HasComputedColumnSql();
                }
            )
            ;

            model_builder.Entity<Person>
            (
                eb
                    =>
                {
                    eb.Property(e => e.ValidFrom).HasComputedColumnSql();
                    eb.Property(e => e.ValidTo).HasComputedColumnSql();
                }
            )
            ;

            model_builder.Entity<StateProvince>
            (
                eb
                    =>
                {
                    eb.Property(e => e.ValidFrom).HasComputedColumnSql();
                    eb.Property(e => e.ValidTo).HasComputedColumnSql();
                }
            )
            ;

            model_builder.Entity<StockItem>
            (
                eb
                    =>
                {
                    eb.Property(e => e.ValidFrom).HasComputedColumnSql();
                    eb.Property(e => e.ValidTo).HasComputedColumnSql();
                }
            )
            ;

            model_builder.Entity<Supplier>
            (
                eb
                    =>
                {
                    eb.Property(e => e.ValidFrom).HasComputedColumnSql();
                    eb.Property(e => e.ValidTo).HasComputedColumnSql();
                }
            )
            ;

            model_builder.Entity<SupplierCategory>
            (
                eb
                    =>
                {
                    eb.Property(e => e.ValidFrom).HasComputedColumnSql();
                    eb.Property(e => e.ValidTo).HasComputedColumnSql();
                }
            )
            ;
        }

        public int GetNextSequence(string name)
        {
            using var command = Database.GetDbConnection().CreateCommand();

            command.CommandType = CommandType.Text;
            command.CommandText = $"SELECT NEXT VALUE FOR Sequences.{name} as NextId";

            Database.OpenConnection();

            using var reader = command.ExecuteReader();
            reader.Read();
            return (int)reader["NextId"];
        }

        public SalesContext()                                                                                                                     { }
        public SalesContext(DbContextOptions<SalesContext> options) : base(options)                                                               { }
        public SalesContext(string connection_string) : this(new DbContextOptionsBuilder<SalesContext>().UseSqlServer(connection_string).Options) { }
    }
}
