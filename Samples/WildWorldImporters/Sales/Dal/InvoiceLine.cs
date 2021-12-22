using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace WildWorldImporters.Sales.Dal
{
    public partial class InvoiceLine
    {
        #region Persistance Properties

        public virtual int Id { get; set; }
        public virtual int InvoiceId { get; set; }
        public virtual int StockItemId { get; set; }
        public virtual string Description { get; set; }
        public virtual int PackageTypeId { get; set; }
        public virtual int Quantity { get; set; }
        public virtual decimal? UnitPrice { get; set; }
        public virtual decimal TaxRate { get; set; }
        public virtual decimal TaxAmount { get; set; }
        public virtual decimal LineProfit { get; set; }
        public virtual decimal ExtendedPrice { get; set; }
        public virtual int LastEditedById { get; set; }
        public virtual DateTime LastEditedWhen { get; set; }

        #endregion
        #region Parent Properties

        public virtual Invoice Invoice { get; set; }
        public virtual Person LastEditedBy { get; set; }
        public virtual PackageType PackageType { get; set; }
        public virtual StockItem StockItem { get; set; }

        #endregion
    }
}
