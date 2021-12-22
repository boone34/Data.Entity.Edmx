using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace WildWorldImporters.Sales.Dal
{
    public partial class Customer
    {
        #region Persistance Properties

        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int BillToCustomerId { get; set; }
        public virtual int CustomerCategoryId { get; set; }
        public virtual int? BuyingGroupId { get; set; }
        public virtual int PrimaryContactPersonId { get; set; }
        public virtual int? AlternateContactPersonId { get; set; }
        public virtual int DeliveryMethodId { get; set; }
        public virtual int DeliveryCityId { get; set; }
        public virtual int PostalCityId { get; set; }
        public virtual decimal? CreditLimit { get; set; }
        public virtual DateTime AccountOpenedDate { get; set; }
        public virtual decimal StandardDiscountPercentage { get; set; }
        public virtual bool IsStatementSent { get; set; }
        public virtual bool IsOnCreditHold { get; set; }
        public virtual int PaymentDays { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual string FaxNumber { get; set; }
        public virtual string DeliveryRun { get; set; }
        public virtual string RunPosition { get; set; }
        public virtual string WebsiteURL { get; set; }
        public virtual string DeliveryAddressLine1 { get; set; }
        public virtual string DeliveryAddressLine2 { get; set; }
        public virtual string DeliveryPostalCode { get; set; }
        public virtual Geometry DeliveryLocation { get; set; }
        public virtual string PostalAddressLine1 { get; set; }
        public virtual string PostalAddressLine2 { get; set; }
        public virtual string PostalPostalCode { get; set; }
        public virtual int LastEditedById { get; set; }
        public virtual DateTime ValidFrom { get; set; }
        public virtual DateTime ValidTo { get; set; }

        #endregion
        #region Parent Properties

        public virtual BuyingGroup BuyingGroup { get; set; }
        public virtual CustomerCategory CustomerCategory { get; set; }
        public virtual Customer BillToCustomer { get; set; }
        public virtual Person AlternateContactPerson { get; set; }
        public virtual Person LastEditedBy { get; set; }
        public virtual Person PrimaryContactPerson { get; set; }
        public virtual DeliveryMethod DeliveryMethod { get; set; }
        public virtual City DeliveryCity { get; set; }
        public virtual City PostalCity { get; set; }

        #endregion
        #region Child Collections

        public virtual ICollection<Customer> BillToCustomers { get; set; }
        public virtual ICollection<CustomerTransaction> CustomerTransactions { get; set; }
        public virtual ICollection<Invoice> BillToInvoices { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<SpecialDeal> SpecialDeals { get; set; }

        #endregion
    }
}
