using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace WildWorldImporters.Sales.Dal
{
    public partial class City
    {
        #region Persistance Properties

        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int StateProvinceId { get; set; }
        public virtual Geometry Location { get; set; }
        public virtual long? LatestRecordedPopulation { get; set; }
        public virtual int LastEditedById { get; set; }
        public virtual DateTime ValidFrom { get; set; }
        public virtual DateTime ValidTo { get; set; }

        #endregion
        #region Parent Properties

        public virtual Person LastEditedBy { get; set; }
        public virtual StateProvince StateProvince { get; set; }

        #endregion
        #region Child Collections

        public virtual ICollection<Customer> DeliveryCustomers { get; set; }
        public virtual ICollection<Customer> PostalCustomers { get; set; }
        public virtual ICollection<Supplier> DeliverySuppliers { get; set; }
        public virtual ICollection<Supplier> PostalSuppliers { get; set; }

        #endregion
    }
}
