using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace WildWorldImporters.Sales.Dal
{
    public partial class CustomerTransaction
    {
        #region Persistance Properties

        public virtual int Id { get; set; }
        public virtual int CustomerId { get; set; }
        public virtual int TransactionTypeId { get; set; }
        public virtual int? InvoiceId { get; set; }
        public virtual int? PaymentMethodId { get; set; }
        public virtual DateTime TransactionDate { get; set; }
        public virtual decimal AmountExcludingTax { get; set; }
        public virtual decimal TaxAmount { get; set; }
        public virtual decimal TransactionAmount { get; set; }
        public virtual decimal OutstandingBalance { get; set; }
        public virtual DateTime? FinalizationDate { get; set; }
        public virtual bool? IsFinalized { get; set; }
        public virtual int LastEditedById { get; set; }
        public virtual DateTime LastEditedWhen { get; set; }

        #endregion
        #region Parent Properties

        public virtual Customer Customer { get; set; }
        public virtual Invoice Invoice { get; set; }
        public virtual Person LastEditedBy { get; set; }

        #endregion
    }
}
