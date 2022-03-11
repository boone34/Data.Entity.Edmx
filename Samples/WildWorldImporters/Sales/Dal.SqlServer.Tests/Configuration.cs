using System.Data.Common;

namespace WildWorldImporters.Sales.Dal.SqlServer.Tests
{
    internal static class Configuration
    {
        public const string ConnectionString = "Data Source=.;Integrated Security=SSPI;Initial Catalog=WideWorldImporters;app=WildWorldImporters.Sales.Dal.SqlServer.Tests;MultipleActiveResultSets=true";
    }
}
