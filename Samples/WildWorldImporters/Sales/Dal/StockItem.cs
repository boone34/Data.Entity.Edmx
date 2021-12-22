using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace WildWorldImporters.Sales.Dal
{
    public partial class StockItem
    {
        #region Persistance Properties

        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int SupplierId { get; set; }
        public virtual int? ColorId { get; set; }
        public virtual int UnitPackageTypeId { get; set; }
        public virtual int OuterPackageTypeId { get; set; }
        public virtual string Brand { get; set; }
        public virtual string Size { get; set; }
        public virtual int LeadTimeDays { get; set; }
        public virtual int QuantityPerOuter { get; set; }
        public virtual bool IsChillerStock { get; set; }
        public virtual string Barcode { get; set; }
        public virtual decimal TaxRate { get; set; }
        public virtual decimal UnitPrice { get; set; }
        public virtual decimal? RecommendedRetailPrice { get; set; }
        public virtual decimal TypicalWeightPerUnit { get; set; }
        public virtual string MarketingComments { get; set; }
        public virtual string InternalComments { get; set; }
        public virtual byte [] Photo { get; set; }
        public virtual string CustomFields { get; set; }
        public virtual string Tags { get; set; }
        public virtual string SearchDetails { get; set; }
        public virtual int LastEditedById { get; set; }
        public virtual DateTime ValidFrom { get; set; }
        public virtual DateTime ValidTo { get; set; }

        #endregion
        #region Parent Properties

        public virtual Person LastEditedBy { get; set; }
        public virtual PackageType OuterPackageType { get; set; }
        public virtual PackageType UnitPackageType { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual Color Color { get; set; }

        #endregion
        #region Child Collections

        public virtual ICollection<InvoiceLine> InvoiceLines { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; }
        public virtual ICollection<SpecialDeal> SpecialDeals { get; set; }

        #endregion
    }
}
