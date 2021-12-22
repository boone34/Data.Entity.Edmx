using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace WildWorldImporters.Sales.Dal
{
    public partial class StateProvince
    {
        #region Persistance Properties

        public virtual int Id { get; set; }
        public virtual string Code { get; set; }
        public virtual string Name { get; set; }
        public virtual int CountryId { get; set; }
        public virtual string SalesTerritory { get; set; }
        public virtual Geometry Border { get; set; }
        public virtual long? LatestRecordedPopulation { get; set; }
        public virtual int LastEditedById { get; set; }
        public virtual DateTime ValidFrom { get; set; }
        public virtual DateTime ValidTo { get; set; }

        #endregion
        #region Parent Properties

        public virtual Country Country { get; set; }
        public virtual Person LastEditedBy { get; set; }

        #endregion
        #region Child Collections

        public virtual ICollection<City> Cities { get; set; }

        #endregion
    }
}
