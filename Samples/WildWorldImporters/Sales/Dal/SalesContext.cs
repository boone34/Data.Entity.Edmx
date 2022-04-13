using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WildWorldImporters.Sales.Dal
{
    public partial class SalesContext<T> : DbContext
        where T: SalesContext<T>
    {
        #region Sets

        public DbSet<BuyingGroup> BuyingGroups { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerCategory> CustomerCategories { get; set; }
        public DbSet<CustomerTransaction> CustomerTransactions { get; set; }
        public DbSet<DeliveryMethod> DeliveryMethods { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceLine> InvoiceLines { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<PackageType> PackageTypes { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<SpecialDeal> SpecialDeals { get; set; }
        public DbSet<StateProvince> StateProvinces { get; set; }
        public DbSet<StockItem> StockItems { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SupplierCategory> SupplierCategories { get; set; }

        #endregion
        #region Configuration

        protected override void OnModelCreating(ModelBuilder model_builder)
        {
            model_builder
            .Entity<BuyingGroup>
            (
                entity_builder
                    =>
                {
                    entity_builder.ToTable("BuyingGroups", "Sales");

                    entity_builder.HasKey(e => e.Id);

                    entity_builder.Property(e => e.Id).HasColumnName("BuyingGroupID").HasDefaultValueSql();
                    entity_builder.Property(e => e.LastEditedById).HasColumnName("LastEditedBy");
                    entity_builder.Property(e => e.Name).HasColumnName("BuyingGroupName").IsRequired().HasMaxLength(50);

                    entity_builder.HasMany(e => e.Customers).WithOne(e => e.BuyingGroup).HasForeignKey(e => e.BuyingGroupId);
                    entity_builder.HasMany(e => e.SpecialDeals).WithOne(e => e.BuyingGroup).HasForeignKey(e => e.BuyingGroupId);
                }
            )
            ;

            model_builder
            .Entity<City>
            (
                entity_builder
                    =>
                {
                    entity_builder.ToTable("Cities", "Application");

                    entity_builder.HasKey(e => e.Id);

                    entity_builder.Property(e => e.Id).HasColumnName("CityID").HasDefaultValueSql();
                    entity_builder.Property(e => e.LastEditedById).HasColumnName("LastEditedBy");
                    entity_builder.Property(e => e.Name).HasColumnName("CityName").IsRequired().HasMaxLength(50);
                    entity_builder.Property(e => e.StateProvinceId).HasColumnName("StateProvinceID");

                    entity_builder.HasMany(e => e.DeliveryCustomers).WithOne(e => e.DeliveryCity).HasForeignKey(e => e.DeliveryCityId);
                    entity_builder.HasMany(e => e.DeliverySuppliers).WithOne(e => e.DeliveryCity).HasForeignKey(e => e.DeliveryCityId);
                    entity_builder.HasMany(e => e.PostalCustomers).WithOne(e => e.PostalCity).HasForeignKey(e => e.PostalCityId);
                    entity_builder.HasMany(e => e.PostalSuppliers).WithOne(e => e.PostalCity).HasForeignKey(e => e.PostalCityId);
                }
            )
            ;

            model_builder
            .Entity<Color>
            (
                entity_builder
                    =>
                {
                    entity_builder.ToTable("Colors", "Warehouse");

                    entity_builder.HasKey(e => e.Id);

                    entity_builder.Property(e => e.Id).HasColumnName("ColorID").HasDefaultValueSql();
                    entity_builder.Property(e => e.LastEditedById).HasColumnName("LastEditedBy");
                    entity_builder.Property(e => e.Name).HasColumnName("ColorName").IsRequired().HasMaxLength(20);

                    entity_builder.HasMany(e => e.StockItems).WithOne(e => e.Color).HasForeignKey(e => e.ColorId);
                }
            )
            ;

            model_builder
            .Entity<Country>
            (
                entity_builder
                    =>
                {
                    entity_builder.ToTable("Countries", "Application");

                    entity_builder.HasKey(e => e.Id);

                    entity_builder.Property(e => e.Continent).IsRequired().HasMaxLength(30);
                    entity_builder.Property(e => e.CountryType).HasMaxLength(20);
                    entity_builder.Property(e => e.FormalName).IsRequired().HasMaxLength(60);
                    entity_builder.Property(e => e.Id).HasColumnName("CountryID").HasDefaultValueSql();
                    entity_builder.Property(e => e.IsoAlpha3Code).HasMaxLength(3);
                    entity_builder.Property(e => e.LastEditedById).HasColumnName("LastEditedBy");
                    entity_builder.Property(e => e.Name).HasColumnName("CountryName").IsRequired().HasMaxLength(60);
                    entity_builder.Property(e => e.Region).IsRequired().HasMaxLength(30);
                    entity_builder.Property(e => e.Subregion).IsRequired().HasMaxLength(30);

                    entity_builder.HasMany(e => e.StateProvinces).WithOne(e => e.Country).HasForeignKey(e => e.CountryId);
                }
            )
            ;

            model_builder
            .Entity<Customer>
            (
                entity_builder
                    =>
                {
                    entity_builder.ToTable("Customers", "Sales");

                    entity_builder.HasKey(e => e.Id);

                    entity_builder.Property(e => e.AlternateContactPersonId).HasColumnName("AlternateContactPersonID");
                    entity_builder.Property(e => e.BillToCustomerId).HasColumnName("BillToCustomerID");
                    entity_builder.Property(e => e.BuyingGroupId).HasColumnName("BuyingGroupID");
                    entity_builder.Property(e => e.CustomerCategoryId).HasColumnName("CustomerCategoryID");
                    entity_builder.Property(e => e.DeliveryAddressLine1).IsRequired().HasMaxLength(60);
                    entity_builder.Property(e => e.DeliveryAddressLine2).HasMaxLength(60);
                    entity_builder.Property(e => e.DeliveryCityId).HasColumnName("DeliveryCityID");
                    entity_builder.Property(e => e.DeliveryMethodId).HasColumnName("DeliveryMethodID");
                    entity_builder.Property(e => e.DeliveryPostalCode).IsRequired().HasMaxLength(10);
                    entity_builder.Property(e => e.DeliveryRun).HasMaxLength(5);
                    entity_builder.Property(e => e.FaxNumber).IsRequired().HasMaxLength(20);
                    entity_builder.Property(e => e.Id).HasColumnName("CustomerID").HasDefaultValueSql();
                    entity_builder.Property(e => e.LastEditedById).HasColumnName("LastEditedBy");
                    entity_builder.Property(e => e.Name).HasColumnName("CustomerName").IsRequired().HasMaxLength(100);
                    entity_builder.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(20);
                    entity_builder.Property(e => e.PostalAddressLine1).IsRequired().HasMaxLength(60);
                    entity_builder.Property(e => e.PostalAddressLine2).HasMaxLength(60);
                    entity_builder.Property(e => e.PostalCityId).HasColumnName("PostalCityID");
                    entity_builder.Property(e => e.PostalPostalCode).IsRequired().HasMaxLength(10);
                    entity_builder.Property(e => e.PrimaryContactPersonId).HasColumnName("PrimaryContactPersonID");
                    entity_builder.Property(e => e.RunPosition).HasMaxLength(5);
                    entity_builder.Property(e => e.WebsiteURL).IsRequired().HasMaxLength(256);

                    entity_builder.HasMany(e => e.BillToCustomers).WithOne(e => e.BillToCustomer).HasForeignKey(e => e.BillToCustomerId);
                    entity_builder.HasMany(e => e.BillToInvoices).WithOne(e => e.BillToCustomer).HasForeignKey(e => e.BillToCustomerId);
                    entity_builder.HasMany(e => e.CustomerTransactions).WithOne(e => e.Customer).HasForeignKey(e => e.CustomerId);
                    entity_builder.HasMany(e => e.Invoices).WithOne(e => e.Customer).HasForeignKey(e => e.CustomerId);
                    entity_builder.HasMany(e => e.Orders).WithOne(e => e.Customer).HasForeignKey(e => e.CustomerId);
                    entity_builder.HasMany(e => e.SpecialDeals).WithOne(e => e.Customer).HasForeignKey(e => e.CustomerId);
                }
            )
            ;

            model_builder
            .Entity<CustomerCategory>
            (
                entity_builder
                    =>
                {
                    entity_builder.ToTable("CustomerCategories", "Sales");

                    entity_builder.HasKey(e => e.Id);

                    entity_builder.Property(e => e.Id).HasColumnName("CustomerCategoryID").HasDefaultValueSql();
                    entity_builder.Property(e => e.LastEditedById).HasColumnName("LastEditedBy");
                    entity_builder.Property(e => e.Name).HasColumnName("CustomerCategoryName").IsRequired().HasMaxLength(50);

                    entity_builder.HasMany(e => e.Customers).WithOne(e => e.CustomerCategory).HasForeignKey(e => e.CustomerCategoryId);
                    entity_builder.HasMany(e => e.SpecialDeals).WithOne(e => e.CustomerCategory).HasForeignKey(e => e.CustomerCategoryId);
                }
            )
            ;

            model_builder
            .Entity<CustomerTransaction>
            (
                entity_builder
                    =>
                {
                    entity_builder.ToTable("CustomerTransactions", "Sales");

                    entity_builder.HasKey(e => e.Id);

                    entity_builder.Property(e => e.CustomerId).HasColumnName("CustomerID");
                    entity_builder.Property(e => e.Id).HasColumnName("CustomerTransactionID").HasDefaultValueSql();
                    entity_builder.Property(e => e.InvoiceId).HasColumnName("InvoiceID");
                    entity_builder.Property(e => e.IsFinalized).HasComputedColumnSql();
                    entity_builder.Property(e => e.LastEditedById).HasColumnName("LastEditedBy");
                    entity_builder.Property(e => e.PaymentMethodId).HasColumnName("PaymentMethodID");
                    entity_builder.Property(e => e.TransactionTypeId).HasColumnName("TransactionTypeID");
                }
            )
            ;

            model_builder
            .Entity<DeliveryMethod>
            (
                entity_builder
                    =>
                {
                    entity_builder.ToTable("DeliveryMethods", "Application");

                    entity_builder.HasKey(e => e.Id);

                    entity_builder.Property(e => e.Id).HasColumnName("DeliveryMethodID").HasDefaultValueSql();
                    entity_builder.Property(e => e.LastEditedById).HasColumnName("LastEditedBy");
                    entity_builder.Property(e => e.Name).HasColumnName("DeliveryMethodName").IsRequired().HasMaxLength(50);

                    entity_builder.HasMany(e => e.Customers).WithOne(e => e.DeliveryMethod).HasForeignKey(e => e.DeliveryMethodId);
                    entity_builder.HasMany(e => e.Invoices).WithOne(e => e.DeliveryMethod).HasForeignKey(e => e.DeliveryMethodId);
                    entity_builder.HasMany(e => e.Suppliers).WithOne(e => e.DeliveryMethod).HasForeignKey(e => e.DeliveryMethodId);
                }
            )
            ;

            model_builder
            .Entity<Invoice>
            (
                entity_builder
                    =>
                {
                    entity_builder.ToTable("Invoices", "Sales");

                    entity_builder.HasKey(e => e.Id);

                    entity_builder.Property(e => e.AccountsPersonId).HasColumnName("AccountsPersonID");
                    entity_builder.Property(e => e.BillToCustomerId).HasColumnName("BillToCustomerID");
                    entity_builder.Property(e => e.ConfirmedDeliveryTime).HasComputedColumnSql();
                    entity_builder.Property(e => e.ConfirmedReceivedBy).HasComputedColumnSql().HasMaxLength(4000);
                    entity_builder.Property(e => e.ContactPersonId).HasColumnName("ContactPersonID");
                    entity_builder.Property(e => e.CustomerId).HasColumnName("CustomerID");
                    entity_builder.Property(e => e.CustomerPurchaseOrderNumber).HasMaxLength(20);
                    entity_builder.Property(e => e.DeliveryMethodId).HasColumnName("DeliveryMethodID");
                    entity_builder.Property(e => e.DeliveryRun).HasMaxLength(5);
                    entity_builder.Property(e => e.Id).HasColumnName("InvoiceID").HasDefaultValueSql();
                    entity_builder.Property(e => e.LastEditedById).HasColumnName("LastEditedBy");
                    entity_builder.Property(e => e.OrderId).HasColumnName("OrderID");
                    entity_builder.Property(e => e.PackedByPersonId).HasColumnName("PackedByPersonID");
                    entity_builder.Property(e => e.RunPosition).HasMaxLength(5);
                    entity_builder.Property(e => e.SalespersonPersonId).HasColumnName("SalespersonPersonID");

                    entity_builder.HasMany(e => e.CustomerTransactions).WithOne(e => e.Invoice).HasForeignKey(e => e.InvoiceId);
                    entity_builder.HasMany(e => e.InvoiceLines).WithOne(e => e.Invoice).HasForeignKey(e => e.InvoiceId);
                }
            )
            ;

            model_builder
            .Entity<InvoiceLine>
            (
                entity_builder
                    =>
                {
                    entity_builder.ToTable("InvoiceLines", "Sales");

                    entity_builder.HasKey(e => e.Id);

                    entity_builder.Property(e => e.Description).IsRequired().HasMaxLength(100);
                    entity_builder.Property(e => e.Id).HasColumnName("InvoiceLineID").HasDefaultValueSql();
                    entity_builder.Property(e => e.InvoiceId).HasColumnName("InvoiceID");
                    entity_builder.Property(e => e.LastEditedById).HasColumnName("LastEditedBy");
                    entity_builder.Property(e => e.PackageTypeId).HasColumnName("PackageTypeID");
                    entity_builder.Property(e => e.StockItemId).HasColumnName("StockItemID");
                }
            )
            ;

            model_builder
            .Entity<Order>
            (
                entity_builder
                    =>
                {
                    entity_builder.ToTable("Orders", "Sales");

                    entity_builder.HasKey(e => e.Id);

                    entity_builder.Property(e => e.BackorderOrderId).HasColumnName("BackorderOrderID");
                    entity_builder.Property(e => e.ContactPersonId).HasColumnName("ContactPersonID");
                    entity_builder.Property(e => e.CustomerId).HasColumnName("CustomerID");
                    entity_builder.Property(e => e.CustomerPurchaseOrderNumber).HasMaxLength(20);
                    entity_builder.Property(e => e.Id).HasColumnName("OrderID").HasDefaultValueSql();
                    entity_builder.Property(e => e.LastEditedById).HasColumnName("LastEditedBy");
                    entity_builder.Property(e => e.PickedByPersonId).HasColumnName("PickedByPersonID");
                    entity_builder.Property(e => e.SalespersonPersonId).HasColumnName("SalespersonPersonID");

                    entity_builder.HasMany(e => e.Invoices).WithOne(e => e.Order).HasForeignKey(e => e.OrderId);
                    entity_builder.HasMany(e => e.OrderLines).WithOne(e => e.Order).HasForeignKey(e => e.OrderId);
                    entity_builder.HasMany(e => e.Orders).WithOne(e => e.BackOrder).HasForeignKey(e => e.BackorderOrderId);
                }
            )
            ;

            model_builder
            .Entity<OrderLine>
            (
                entity_builder
                    =>
                {
                    entity_builder.ToTable("OrderLines", "Sales");

                    entity_builder.HasKey(e => e.Id);

                    entity_builder.Property(e => e.Description).IsRequired().HasMaxLength(100);
                    entity_builder.Property(e => e.Id).HasColumnName("OrderLineID").HasDefaultValueSql();
                    entity_builder.Property(e => e.LastEditedById).HasColumnName("LastEditedBy");
                    entity_builder.Property(e => e.OrderId).HasColumnName("OrderID");
                    entity_builder.Property(e => e.PackageTypeId).HasColumnName("PackageTypeID");
                    entity_builder.Property(e => e.StockItemId).HasColumnName("StockItemID");
                }
            )
            ;

            model_builder
            .Entity<PackageType>
            (
                entity_builder
                    =>
                {
                    entity_builder.ToTable("PackageTypes", "Warehouse");

                    entity_builder.HasKey(e => e.Id);

                    entity_builder.Property(e => e.Id).HasColumnName("PackageTypeID").HasDefaultValueSql();
                    entity_builder.Property(e => e.LastEditedById).HasColumnName("LastEditedBy");
                    entity_builder.Property(e => e.Name).HasColumnName("PackageTypeName").IsRequired().HasMaxLength(50);

                    entity_builder.HasMany(e => e.InvoiceLines).WithOne(e => e.PackageType).HasForeignKey(e => e.PackageTypeId);
                    entity_builder.HasMany(e => e.OrderLines).WithOne(e => e.PackageType).HasForeignKey(e => e.PackageTypeId);
                    entity_builder.HasMany(e => e.OuterStockItems).WithOne(e => e.OuterPackageType).HasForeignKey(e => e.OuterPackageTypeId);
                    entity_builder.HasMany(e => e.UnitStockItems).WithOne(e => e.UnitPackageType).HasForeignKey(e => e.UnitPackageTypeId);
                }
            )
            ;

            model_builder
            .Entity<Person>
            (
                entity_builder
                    =>
                {
                    entity_builder.ToTable("People", "Application");

                    entity_builder.HasKey(e => e.Id);

                    entity_builder.Property(e => e.EmailAddress).HasMaxLength(256);
                    entity_builder.Property(e => e.FaxNumber).HasMaxLength(20);
                    entity_builder.Property(e => e.FullName).IsRequired().HasMaxLength(50);
                    entity_builder.Property(e => e.Id).HasColumnName("PersonID").HasDefaultValueSql();
                    entity_builder.Property(e => e.LastEditedById).HasColumnName("LastEditedBy");
                    entity_builder.Property(e => e.LogonName).HasMaxLength(50);
                    entity_builder.Property(e => e.OtherLanguages).HasComputedColumnSql();
                    entity_builder.Property(e => e.PhoneNumber).HasMaxLength(20);
                    entity_builder.Property(e => e.PreferredName).IsRequired().HasMaxLength(50);
                    entity_builder.Property(e => e.SearchName).HasComputedColumnSql().IsRequired().HasMaxLength(101);

                    entity_builder.HasMany(e => e.AccountsInvoices).WithOne(e => e.AccountsPerson).HasForeignKey(e => e.AccountsPersonId);
                    entity_builder.HasMany(e => e.AlternateContactCustomers).WithOne(e => e.AlternateContactPerson).HasForeignKey(e => e.AlternateContactPersonId);
                    entity_builder.HasMany(e => e.AlternateContactSuppliers).WithOne(e => e.AlternateContactPerson).HasForeignKey(e => e.AlternateContactPersonId);
                    entity_builder.HasMany(e => e.BuyingGroups).WithOne(e => e.LastEditedBy).HasForeignKey(e => e.LastEditedById);
                    entity_builder.HasMany(e => e.Cities).WithOne(e => e.LastEditedBy).HasForeignKey(e => e.LastEditedById);
                    entity_builder.HasMany(e => e.ContactPersonInvoices).WithOne(e => e.ContactPerson).HasForeignKey(e => e.ContactPersonId);
                    entity_builder.HasMany(e => e.ContactPersonOrders).WithOne(e => e.ContactPerson).HasForeignKey(e => e.ContactPersonId);
                    entity_builder.HasMany(e => e.CustomerCategories).WithOne(e => e.LastEditedBy).HasForeignKey(e => e.LastEditedById);
                    entity_builder.HasMany(e => e.CustomerTransactions).WithOne(e => e.LastEditedBy).HasForeignKey(e => e.LastEditedById);
                    entity_builder.HasMany(e => e.DeliveryMethods).WithOne(e => e.LastEditedBy).HasForeignKey(e => e.LastEditedById);
                    entity_builder.HasMany(e => e.LastEditedByColors).WithOne(e => e.LastEditedBy).HasForeignKey(e => e.LastEditedById);
                    entity_builder.HasMany(e => e.LastEditedByCountries).WithOne(e => e.LastEditedBy).HasForeignKey(e => e.LastEditedById);
                    entity_builder.HasMany(e => e.LastEditedByCustomers).WithOne(e => e.LastEditedBy).HasForeignKey(e => e.LastEditedById);
                    entity_builder.HasMany(e => e.LastEditedByInvoiceLines).WithOne(e => e.LastEditedBy).HasForeignKey(e => e.LastEditedById);
                    entity_builder.HasMany(e => e.LastEditedByOrderLines).WithOne(e => e.LastEditedBy).HasForeignKey(e => e.LastEditedById);
                    entity_builder.HasMany(e => e.LastEditedByPackageTypes).WithOne(e => e.LastEditedBy).HasForeignKey(e => e.LastEditedById);
                    entity_builder.HasMany(e => e.LastEditedByStateProvinces).WithOne(e => e.LastEditedBy).HasForeignKey(e => e.LastEditedById);
                    entity_builder.HasMany(e => e.LastEditedByStockItems).WithOne(e => e.LastEditedBy).HasForeignKey(e => e.LastEditedById);
                    entity_builder.HasMany(e => e.LastEditedBySupplierCategories).WithOne(e => e.LastEditedBy).HasForeignKey(e => e.LastEditedById);
                    entity_builder.HasMany(e => e.LastEditedBySuppliers).WithOne(e => e.LastEditedBy).HasForeignKey(e => e.LastEditedById);
                    entity_builder.HasMany(e => e.LastEditedInvoices).WithOne(e => e.LastEditedBy).HasForeignKey(e => e.LastEditedById);
                    entity_builder.HasMany(e => e.LastEditedOrders).WithOne(e => e.LastEditedBy).HasForeignKey(e => e.LastEditedById);
                    entity_builder.HasMany(e => e.LastEditedPeople).WithOne(e => e.LastEditedBy).HasForeignKey(e => e.LastEditedById);
                    entity_builder.HasMany(e => e.LastEditedSpecialDeals).WithOne(e => e.LastEditedBy).HasForeignKey(e => e.LastEditedById);
                    entity_builder.HasMany(e => e.PackedByInvoices).WithOne(e => e.PackedByPerson).HasForeignKey(e => e.PackedByPersonId);
                    entity_builder.HasMany(e => e.PickedByOrders).WithOne(e => e.PickedByPerson).HasForeignKey(e => e.PickedByPersonId);
                    entity_builder.HasMany(e => e.PrimaryContactCustomers).WithOne(e => e.PrimaryContactPerson).HasForeignKey(e => e.PrimaryContactPersonId);
                    entity_builder.HasMany(e => e.PrimaryContactSuppliers).WithOne(e => e.PrimaryContactPerson).HasForeignKey(e => e.PrimaryContactPersonId);
                    entity_builder.HasMany(e => e.SalespersonInvoices).WithOne(e => e.Salesperson).HasForeignKey(e => e.SalespersonPersonId);
                    entity_builder.HasMany(e => e.SalespersonOrders).WithOne(e => e.Salesperson).HasForeignKey(e => e.SalespersonPersonId);
                }
            )
            ;

            model_builder
            .Entity<SpecialDeal>
            (
                entity_builder
                    =>
                {
                    entity_builder.ToTable("SpecialDeals", "Sales");

                    entity_builder.HasKey(e => e.Id);

                    entity_builder.Property(e => e.BuyingGroupId).HasColumnName("BuyingGroupID");
                    entity_builder.Property(e => e.CustomerCategoryId).HasColumnName("CustomerCategoryID");
                    entity_builder.Property(e => e.CustomerId).HasColumnName("CustomerID");
                    entity_builder.Property(e => e.DealDescription).IsRequired().HasMaxLength(30);
                    entity_builder.Property(e => e.Id).HasColumnName("SpecialDealID").HasDefaultValueSql();
                    entity_builder.Property(e => e.LastEditedById).HasColumnName("LastEditedBy");
                    entity_builder.Property(e => e.StockGroupId).HasColumnName("StockGroupID");
                    entity_builder.Property(e => e.StockItemId).HasColumnName("StockItemID");
                }
            )
            ;

            model_builder
            .Entity<StateProvince>
            (
                entity_builder
                    =>
                {
                    entity_builder.ToTable("StateProvinces", "Application");

                    entity_builder.HasKey(e => e.Id);

                    entity_builder.Property(e => e.Code).HasColumnName("StateProvinceCode").IsRequired().HasMaxLength(5);
                    entity_builder.Property(e => e.CountryId).HasColumnName("CountryID");
                    entity_builder.Property(e => e.Id).HasColumnName("StateProvinceID").HasDefaultValueSql();
                    entity_builder.Property(e => e.LastEditedById).HasColumnName("LastEditedBy");
                    entity_builder.Property(e => e.Name).HasColumnName("StateProvinceName").IsRequired().HasMaxLength(50);
                    entity_builder.Property(e => e.SalesTerritory).IsRequired().HasMaxLength(50);

                    entity_builder.HasMany(e => e.Cities).WithOne(e => e.StateProvince).HasForeignKey(e => e.StateProvinceId);
                }
            )
            ;

            model_builder
            .Entity<StockItem>
            (
                entity_builder
                    =>
                {
                    entity_builder.ToTable("StockItems", "Warehouse");

                    entity_builder.HasKey(e => e.Id);

                    entity_builder.Property(e => e.Barcode).HasMaxLength(50);
                    entity_builder.Property(e => e.Brand).HasMaxLength(50);
                    entity_builder.Property(e => e.ColorId).HasColumnName("ColorID");
                    entity_builder.Property(e => e.Id).HasColumnName("StockItemID").HasDefaultValueSql();
                    entity_builder.Property(e => e.LastEditedById).HasColumnName("LastEditedBy");
                    entity_builder.Property(e => e.Name).HasColumnName("StockItemName").IsRequired().HasMaxLength(100);
                    entity_builder.Property(e => e.OuterPackageTypeId).HasColumnName("OuterPackageID");
                    entity_builder.Property(e => e.SearchDetails).HasComputedColumnSql().IsRequired();
                    entity_builder.Property(e => e.Size).HasMaxLength(20);
                    entity_builder.Property(e => e.SupplierId).HasColumnName("SupplierID");
                    entity_builder.Property(e => e.Tags).HasComputedColumnSql();
                    entity_builder.Property(e => e.UnitPackageTypeId).HasColumnName("UnitPackageID");

                    entity_builder.HasMany(e => e.InvoiceLines).WithOne(e => e.StockItem).HasForeignKey(e => e.StockItemId);
                    entity_builder.HasMany(e => e.OrderLines).WithOne(e => e.StockItem).HasForeignKey(e => e.StockItemId);
                    entity_builder.HasMany(e => e.SpecialDeals).WithOne(e => e.StockItem).HasForeignKey(e => e.StockItemId);
                }
            )
            ;

            model_builder
            .Entity<Supplier>
            (
                entity_builder
                    =>
                {
                    entity_builder.ToTable("Suppliers", "Purchasing");

                    entity_builder.HasKey(e => e.Id);

                    entity_builder.Property(e => e.AlternateContactPersonId).HasColumnName("AlternateContactPersonID");
                    entity_builder.Property(e => e.BankAccountBranch).HasMaxLength(50);
                    entity_builder.Property(e => e.BankAccountCode).HasMaxLength(20);
                    entity_builder.Property(e => e.BankAccountName).HasMaxLength(50);
                    entity_builder.Property(e => e.BankAccountNumber).HasMaxLength(20);
                    entity_builder.Property(e => e.BankInternationalCode).HasMaxLength(20);
                    entity_builder.Property(e => e.DeliveryAddressLine1).IsRequired().HasMaxLength(60);
                    entity_builder.Property(e => e.DeliveryAddressLine2).HasMaxLength(60);
                    entity_builder.Property(e => e.DeliveryCityId).HasColumnName("DeliveryCityID");
                    entity_builder.Property(e => e.DeliveryMethodId).HasColumnName("DeliveryMethodID");
                    entity_builder.Property(e => e.DeliveryPostalCode).IsRequired().HasMaxLength(10);
                    entity_builder.Property(e => e.FaxNumber).IsRequired().HasMaxLength(20);
                    entity_builder.Property(e => e.Id).HasColumnName("SupplierID").HasDefaultValueSql();
                    entity_builder.Property(e => e.LastEditedById).HasColumnName("LastEditedBy");
                    entity_builder.Property(e => e.Name).HasColumnName("SupplierName").IsRequired().HasMaxLength(100);
                    entity_builder.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(20);
                    entity_builder.Property(e => e.PostalAddressLine1).IsRequired().HasMaxLength(60);
                    entity_builder.Property(e => e.PostalAddressLine2).HasMaxLength(60);
                    entity_builder.Property(e => e.PostalCityId).HasColumnName("PostalCityID");
                    entity_builder.Property(e => e.PostalPostalCode).IsRequired().HasMaxLength(10);
                    entity_builder.Property(e => e.PrimaryContactPersonId).HasColumnName("PrimaryContactPersonID");
                    entity_builder.Property(e => e.SupplierCategoryId).HasColumnName("SupplierCategoryID");
                    entity_builder.Property(e => e.SupplierReference).HasMaxLength(20);
                    entity_builder.Property(e => e.WebsiteURL).IsRequired().HasMaxLength(256);

                    entity_builder.HasMany(e => e.StockItems).WithOne(e => e.Supplier).HasForeignKey(e => e.SupplierId);
                }
            )
            ;

            model_builder
            .Entity<SupplierCategory>
            (
                entity_builder
                    =>
                {
                    entity_builder.ToTable("SupplierCategories", "Purchasing");

                    entity_builder.HasKey(e => e.Id);

                    entity_builder.Property(e => e.Id).HasColumnName("SupplierCategoryID").HasDefaultValueSql();
                    entity_builder.Property(e => e.LastEditedById).HasColumnName("LastEditedBy");
                    entity_builder.Property(e => e.Name).HasColumnName("SupplierCategoryName").IsRequired().HasMaxLength(50);

                    entity_builder.HasMany(e => e.Suppliers).WithOne(e => e.SupplierCategory).HasForeignKey(e => e.SupplierCategoryId);
                }
            )
            ;
        }

        #endregion
        #region Ctors

        public SalesContext() { }
        public SalesContext(DbContextOptions<T> options) : base(options) { }

        #endregion
    }
}
