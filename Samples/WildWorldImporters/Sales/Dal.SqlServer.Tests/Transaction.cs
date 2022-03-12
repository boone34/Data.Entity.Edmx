using System;
using System.Linq;
using System.Transactions;
using Xunit;

namespace WildWorldImporters.Sales.Dal.SqlServer.Tests
{
    public class Transaction
    {
        private static int RollbackSetup()
        {
            using var context = new SalesContext(Configuration.ConnectionString);
            return context.Colors.Count();
        }

        [Fact]
        public void ConnectionRollback()
        {
            var count = RollbackSetup();

            using var context = new SalesContext(Configuration.ConnectionString);

            using (var transaction = context.Database.BeginTransaction())
            {
                context.Colors.Add(new Color { LastEditedById = 1, Name = Guid.NewGuid().ToString().Substring(0, 20) });
                context.SaveChanges();
            }

            Assert.Equal(count, context.Colors.Count());
        }

        [Fact]
        public void ScopeRollback()
        {
            var count = RollbackSetup();

            using var context = new SalesContext(Configuration.ConnectionString);

            using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
            {
                context.Colors.Add(new Color { LastEditedById = 1, Name = Guid.NewGuid().ToString().Substring(0, 20) });
                context.SaveChanges();
            }

            Assert.Equal(count, context.Colors.Count());
        }
    }
}
