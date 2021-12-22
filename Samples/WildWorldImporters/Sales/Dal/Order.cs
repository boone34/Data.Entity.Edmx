using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace WildWorldImporters.Sales.Dal
{
    public partial class Order
    {
        #region Persistance Properties

        public virtual int Id { get; set; }
        public virtual int CustomerId { get; set; }
        public virtual int SalespersonPersonId { get; set; }
        public virtual int? PickedByPersonId { get; set; }
        public virtual int ContactPersonId { get; set; }
        public virtual int? BackorderOrderId { get; set; }
        public virtual DateTime OrderDate { get; set; }
        public virtual DateTime ExpectedDeliveryDate { get; set; }
        public virtual string CustomerPurchaseOrderNumber { get; set; }
        public virtual bool IsUndersupplyBackordered { get; set; }
        public virtual string Comments { get; set; }
        public virtual string DeliveryInstructions { get; set; }
        public virtual string InternalComments { get; set; }
        public virtual DateTime? PickingCompletedWhen { get; set; }
        public virtual int LastEditedById { get; set; }
        public virtual DateTime LastEditedWhen { get; set; }

        #endregion
        #region Parent Properties

        public virtual Customer Customer { get; set; }
        public virtual Order BackOrder { get; set; }
        public virtual Person LastEditedBy { get; set; }
        public virtual Person ContactPerson { get; set; }
        public virtual Person PickedByPerson { get; set; }
        public virtual Person Salesperson { get; set; }

        #endregion
        #region Child Collections

        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        #endregion
    }
}
