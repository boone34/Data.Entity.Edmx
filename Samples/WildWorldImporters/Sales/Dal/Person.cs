using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace WildWorldImporters.Sales.Dal
{
    public partial class Person
    {
        #region Persistance Properties

        public virtual int Id { get; set; }
        public virtual string FullName { get; set; }
        public virtual string PreferredName { get; set; }
        public virtual string SearchName { get; set; }
        public virtual bool IsPermittedToLogon { get; set; }
        public virtual string LogonName { get; set; }
        public virtual bool IsExternalLogonProvider { get; set; }
        public virtual byte [] HashedPassword { get; set; }
        public virtual bool IsSystemUser { get; set; }
        public virtual bool IsEmployee { get; set; }
        public virtual bool IsSalesperson { get; set; }
        public virtual string UserPreferences { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual string FaxNumber { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual byte [] Photo { get; set; }
        public virtual string CustomFields { get; set; }
        public virtual string OtherLanguages { get; set; }
        public virtual int LastEditedById { get; set; }
        public virtual DateTime ValidFrom { get; set; }
        public virtual DateTime ValidTo { get; set; }

        #endregion
        #region Parent Properties

        public virtual Person LastEditedBy { get; set; }

        #endregion
        #region Child Collections

        public virtual ICollection<Person> LastEditedPeople { get; set; }
        public virtual ICollection<BuyingGroup> BuyingGroups { get; set; }
        public virtual ICollection<CustomerCategory> CustomerCategories { get; set; }
        public virtual ICollection<Customer> AlternateContactCustomers { get; set; }
        public virtual ICollection<Customer> LastEditedByCustomers { get; set; }
        public virtual ICollection<Customer> PrimaryContactCustomers { get; set; }
        public virtual ICollection<CustomerTransaction> CustomerTransactions { get; set; }
        public virtual ICollection<InvoiceLine> LastEditedByInvoiceLines { get; set; }
        public virtual ICollection<Invoice> AccountsInvoices { get; set; }
        public virtual ICollection<Invoice> LastEditedInvoices { get; set; }
        public virtual ICollection<Invoice> ContactPersonInvoices { get; set; }
        public virtual ICollection<Invoice> PackedByInvoices { get; set; }
        public virtual ICollection<Invoice> SalespersonInvoices { get; set; }
        public virtual ICollection<OrderLine> LastEditedByOrderLines { get; set; }
        public virtual ICollection<Order> LastEditedOrders { get; set; }
        public virtual ICollection<Order> ContactPersonOrders { get; set; }
        public virtual ICollection<Order> PickedByOrders { get; set; }
        public virtual ICollection<Order> SalespersonOrders { get; set; }
        public virtual ICollection<SpecialDeal> LastEditedSpecialDeals { get; set; }
        public virtual ICollection<DeliveryMethod> DeliveryMethods { get; set; }
        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<PackageType> LastEditedByPackageTypes { get; set; }
        public virtual ICollection<StockItem> LastEditedByStockItems { get; set; }
        public virtual ICollection<Country> LastEditedByCountries { get; set; }
        public virtual ICollection<StateProvince> LastEditedByStateProvinces { get; set; }
        public virtual ICollection<Supplier> AlternateContactSuppliers { get; set; }
        public virtual ICollection<Supplier> LastEditedBySuppliers { get; set; }
        public virtual ICollection<Supplier> PrimaryContactSuppliers { get; set; }
        public virtual ICollection<Color> LastEditedByColors { get; set; }
        public virtual ICollection<SupplierCategory> LastEditedBySupplierCategories { get; set; }

        #endregion
    }
}
