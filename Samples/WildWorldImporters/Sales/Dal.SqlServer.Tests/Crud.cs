using System;
using System.Linq;
using System.Transactions;
using Xunit;

namespace WildWorldImporters.Sales.Dal.SqlServer.Tests
{
    public class Crud
    {
        private static Color AddSetup()
        {
            using var context = new SalesContext(Configuration.ConnectionString);
            var color         = new Color { LastEditedById = 1, Name = Guid.NewGuid().ToString().Substring(0, 20) };
            context.Colors.Add(color);
            context.SaveChanges();

            return color;
        }

        [Fact]
        public void Add()
        {
            using var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted });

            var color_added = AddSetup();

            using var context = new SalesContext(Configuration.ConnectionString);
            var color         = context.Colors.SingleOrDefault(c => c.Id == color_added.Id);
            Assert.NotNull(color);
            Assert.Equal(color_added.LastEditedById, color.LastEditedById);
            Assert.Equal(color_added.Name, color.Name);
        }

        private static Color DeleteSetup()
        {
            var color_added = AddSetup();

            using var context = new SalesContext(Configuration.ConnectionString);
            context.Colors.Remove(context.Colors.Single(c => c.Id == color_added.Id));
            context.SaveChanges();

            return color_added;
        }

        [Fact]
        public void Delete()
        {
            using var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted });

            var color_added = DeleteSetup();

            using var context = new SalesContext(Configuration.ConnectionString);
            Assert.True(context.Colors.All(c => c.Id != color_added.Id), "!context.Colors.All(c => c.Id != color_added.Id)");
        }

        private static Color ModifySetup()
        {
            var color_added = AddSetup();

            using var context = new SalesContext(Configuration.ConnectionString);
            var color         = context.Colors.Single(c => c.Id == color_added.Id);
            color.Name        = new string(color_added.Name.Reverse().ToArray());
            context.SaveChanges();

            return color;
        }

        [Fact]
        public void Modify()
        {
            using var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted });

            var color_modified = ModifySetup();

            using var context = new SalesContext(Configuration.ConnectionString);
            var color         = context.Colors.SingleOrDefault(c => c.Id == color_modified.Id);
            Assert.NotNull(color);
            Assert.Equal(color_modified.LastEditedById, color.LastEditedById);
            Assert.Equal(color_modified.Name, color.Name);
        }
    }
}
