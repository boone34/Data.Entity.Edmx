using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace WildWorldImporters.Sales.Dal
{
    public partial class Invoice
    {
        #region Persistance Properties

        public virtual int Id { get; set; }
        public virtual int CustomerId { get; set; }
        public virtual int BillToCustomerId { get; set; }
        public virtual int? OrderId { get; set; }
        public virtual int DeliveryMethodId { get; set; }
        public virtual int ContactPersonId { get; set; }
        public virtual int AccountsPersonId { get; set; }
        public virtual int SalespersonPersonId { get; set; }
        public virtual int PackedByPersonId { get; set; }
        public virtual DateTime InvoiceDate { get; set; }
        public virtual string CustomerPurchaseOrderNumber { get; set; }
        public virtual bool IsCreditNote { get; set; }
        public virtual string CreditNoteReason { get; set; }
        public virtual string Comments { get; set; }
        public virtual string DeliveryInstructions { get; set; }
        public virtual string InternalComments { get; set; }
        public virtual int TotalDryItems { get; set; }
        public virtual int TotalChillerItems { get; set; }
        public virtual string DeliveryRun { get; set; }
        public virtual string RunPosition { get; set; }
        public virtual string ReturnedDeliveryData { get; set; }
        public virtual DateTime? ConfirmedDeliveryTime { get; set; }
        public virtual string ConfirmedReceivedBy { get; set; }
        public virtual int LastEditedById { get; set; }
        public virtual DateTime LastEditedWhen { get; set; }

        #endregion
        #region Parent Properties

        public virtual Customer BillToCustomer { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Order Order { get; set; }
        public virtual Person AccountsPerson { get; set; }
        public virtual Person LastEditedBy { get; set; }
        public virtual Person ContactPerson { get; set; }
        public virtual Person PackedByPerson { get; set; }
        public virtual Person Salesperson { get; set; }
        public virtual DeliveryMethod DeliveryMethod { get; set; }

        #endregion
        #region Child Collections

        public virtual ICollection<CustomerTransaction> CustomerTransactions { get; set; }
        public virtual ICollection<InvoiceLine> InvoiceLines { get; set; }

        #endregion
    }
}
