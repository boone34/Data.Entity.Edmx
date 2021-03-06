//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WildWorldImporters.Sales.Edmx
{
    using System;
    using System.Collections.Generic;
    
    public partial class SpecialDeal
    {
        public int Id { get; set; }
        public Nullable<int> StockItemId { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public Nullable<int> BuyingGroupId { get; set; }
        public Nullable<int> CustomerCategoryId { get; set; }
        public Nullable<int> StockGroupId { get; set; }
        public string DealDescription { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public Nullable<decimal> DiscountAmount { get; set; }
        public Nullable<decimal> DiscountPercentage { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public int LastEditedById { get; set; }
        public System.DateTime LastEditedWhen { get; set; }
    
        public virtual BuyingGroup BuyingGroup { get; set; }
        public virtual CustomerCategory CustomerCategory { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Person LastEditedBy { get; set; }
        public virtual StockItem StockItem { get; set; }
    }
}
