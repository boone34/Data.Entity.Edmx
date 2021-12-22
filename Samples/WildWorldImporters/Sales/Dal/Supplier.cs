using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace WildWorldImporters.Sales.Dal
{
    public partial class Supplier
    {
        #region Persistance Properties

        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int SupplierCategoryId { get; set; }
        public virtual int PrimaryContactPersonId { get; set; }
        public virtual int AlternateContactPersonId { get; set; }
        public virtual int? DeliveryMethodId { get; set; }
        public virtual int DeliveryCityId { get; set; }
        public virtual int PostalCityId { get; set; }
        public virtual string SupplierReference { get; set; }
        public virtual string BankAccountName { get; set; }
        public virtual string BankAccountBranch { get; set; }
        public virtual string BankAccountCode { get; set; }
        public virtual string BankAccountNumber { get; set; }
        public virtual string BankInternationalCode { get; set; }
        public virtual int PaymentDays { get; set; }
        public virtual string InternalComments { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual string FaxNumber { get; set; }
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

        public virtual City DeliveryCity { get; set; }
        public virtual City PostalCity { get; set; }
        public virtual DeliveryMethod DeliveryMethod { get; set; }
        public virtual Person AlternateContactPerson { get; set; }
        public virtual Person LastEditedBy { get; set; }
        public virtual Person PrimaryContactPerson { get; set; }
        public virtual SupplierCategory SupplierCategory { get; set; }

        #endregion
        #region Child Collections

        public virtual ICollection<StockItem> StockItems { get; set; }

        #endregion
    }
}
