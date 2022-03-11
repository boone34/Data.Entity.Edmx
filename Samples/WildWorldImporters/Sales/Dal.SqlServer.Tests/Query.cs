using System.Linq;
using Xunit;

namespace WildWorldImporters.Sales.Dal.SqlServer.Tests
{
    public class Query
    {
        [Fact]
        public void Any()
        {
            using var context = new SalesContext(Configuration.ConnectionString);
            Assert.True(context.Customers.Any(), "!context.Customers.Any()");
        }

        [Fact]
        public void Count()
        {
            using var context = new SalesContext(Configuration.ConnectionString);
            Assert.True(context.Customers.Count() > 0, "context.Customers.Count() <= 0");
        }

        [Fact]
        public void FirstOrDefault()
        {
            using var context = new SalesContext(Configuration.ConnectionString);
            var customer = context.Customers.OrderBy(c => c.Id).FirstOrDefault();
            Assert.NotNull(customer);
        }
    }
}
