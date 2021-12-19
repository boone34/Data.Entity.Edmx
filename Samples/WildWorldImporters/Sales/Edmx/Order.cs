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
    
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            this.Invoices = new HashSet<Invoice>();
            this.OrderLines = new HashSet<OrderLine>();
            this.Orders = new HashSet<Order>();
        }
    
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int SalespersonPersonId { get; set; }
        public Nullable<int> PickedByPersonId { get; set; }
        public int ContactPersonId { get; set; }
        public Nullable<int> BackorderOrderId { get; set; }
        public System.DateTime OrderDate { get; set; }
        public System.DateTime ExpectedDeliveryDate { get; set; }
        public string CustomerPurchaseOrderNumber { get; set; }
        public bool IsUndersupplyBackordered { get; set; }
        public string Comments { get; set; }
        public string DeliveryInstructions { get; set; }
        public string InternalComments { get; set; }
        public Nullable<System.DateTime> PickingCompletedWhen { get; set; }
        public int LastEditedById { get; set; }
        public System.DateTime LastEditedWhen { get; set; }
    
        public virtual Customer Customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invoice> Invoices { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderLine> OrderLines { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
        public virtual Order BackOrder { get; set; }
        public virtual Person LastEditedBy { get; set; }
        public virtual Person ContactPerson { get; set; }
        public virtual Person PickedByPerson { get; set; }
        public virtual Person Salesperson { get; set; }
    }
}