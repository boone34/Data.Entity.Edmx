using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace WildWorldImporters.Sales.Dal
{
    public partial class BuyingGroup
    {
        #region Persistance Properties

        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int LastEditedById { get; set; }
        public virtual DateTime ValidFrom { get; set; }
        public virtual DateTime ValidTo { get; set; }

        #endregion
        #region Parent Properties

        public virtual Person LastEditedBy { get; set; }

        #endregion
        #region Child Collections

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<SpecialDeal> SpecialDeals { get; set; }

        #endregion
    }
}
