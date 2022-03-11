using System.Collections.Generic;
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

        [Fact]
        public void Take()
        {
            using var context = new SalesContext(Configuration.ConnectionString);
            var customers = context.Customers.OrderBy(c => c.Id).Take(1).ToList();
            Assert.True(customers.Count == 1, "customers.Count != 1");
        }

        [Fact]
        public void Select()
        {
            using var context = new SalesContext(Configuration.ConnectionString);
            var customers = context.Customers.OrderBy(c => c.Id).Select(c => c.PostalPostalCode).Take(1).ToList();
            Assert.True(customers is List<string>, "customers is not List<string>");
        }

        [Fact]
        public void CountWhere()
        {
            using var context = new SalesContext(Configuration.ConnectionString);
            var postal_code = context.Customers.OrderBy(c => c.Id).Select(c => c.PostalPostalCode).First();
            Assert.True(context.Customers.Count(c => c.PostalPostalCode == postal_code) > 0, "context.Customers.Count(c => c.PostalPostalCode == postal_code) <= 0");
        }
    }
}
