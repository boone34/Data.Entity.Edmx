using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace WildWorldImporters.Sales.Dal
{
    public partial class Country
    {
        #region Persistance Properties

        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string FormalName { get; set; }
        public virtual string IsoAlpha3Code { get; set; }
        public virtual int? IsoNumericCode { get; set; }
        public virtual string CountryType { get; set; }
        public virtual long? LatestRecordedPopulation { get; set; }
        public virtual string Continent { get; set; }
        public virtual string Region { get; set; }
        public virtual string Subregion { get; set; }
        public virtual Geometry Border { get; set; }
        public virtual int LastEditedById { get; set; }
        public virtual DateTime ValidFrom { get; set; }
        public virtual DateTime ValidTo { get; set; }

        #endregion
        #region Parent Properties

        public virtual Person LastEditedBy { get; set; }

        #endregion
        #region Child Collections

        public virtual ICollection<StateProvince> StateProvinces { get; set; }

        #endregion
    }
}
