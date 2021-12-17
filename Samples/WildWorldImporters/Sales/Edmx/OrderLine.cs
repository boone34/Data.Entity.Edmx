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
    
    public partial class OrderLine
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int StockItemId { get; set; }
        public string Description { get; set; }
        public int PackageTypeId { get; set; }
        public int Quantity { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public decimal TaxRate { get; set; }
        public int PickedQuantity { get; set; }
        public Nullable<System.DateTime> PickingCompletedWhen { get; set; }
        public int LastEditedById { get; set; }
        public System.DateTime LastEditedWhen { get; set; }
    
        public virtual Order Order { get; set; }
        public virtual Person LastEditedBy { get; set; }
        public virtual PackageType PackageType { get; set; }
        public virtual StockItem StockItem { get; set; }
    }
}
