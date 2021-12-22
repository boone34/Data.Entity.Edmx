using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace WildWorldImporters.Sales.Dal
{
    public partial class SpecialDeal
    {
        #region Persistance Properties

        public virtual int Id { get; set; }
        public virtual int? StockItemId { get; set; }
        public virtual int? CustomerId { get; set; }
        public virtual int? BuyingGroupId { get; set; }
        public virtual int? CustomerCategoryId { get; set; }
        public virtual int? StockGroupId { get; set; }
        public virtual string DealDescription { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual decimal? DiscountAmount { get; set; }
        public virtual decimal? DiscountPercentage { get; set; }
        public virtual decimal? UnitPrice { get; set; }
        public virtual int LastEditedById { get; set; }
        public virtual DateTime LastEditedWhen { get; set; }

        #endregion
        #region Parent Properties

        public virtual BuyingGroup BuyingGroup { get; set; }
        public virtual CustomerCategory CustomerCategory { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Person LastEditedBy { get; set; }
        public virtual StockItem StockItem { get; set; }

        #endregion
    }
}
