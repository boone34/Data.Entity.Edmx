using System;
using System.Collections.Generic;
using System.Xml;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Conceptual
{
    public class PropertyRef<TParent>
        where TParent: class
    {
        public TParent                         Parent      { get; }
        public IReadOnlyCollection<XmlElement> AnyElements { get; }
        public string                          Name        { get; }

        internal PropertyRef(TParent parent, TCsdlPropertyRef t_csdl_property_refs)
        {
            if (t_csdl_property_refs == null) throw new ArgumentNullException(nameof(t_csdl_property_refs));

            Parent      = parent ?? throw new ArgumentNullException(nameof(parent));
            AnyElements = t_csdl_property_refs.Any;
            Name        = t_csdl_property_refs.Name;
        }

        internal PropertyRef(TParent parent, TSsdlPropertyRef t_ssdl_property_refs)
        {
            if (t_ssdl_property_refs == null) throw new ArgumentNullException(nameof(t_ssdl_property_refs));

            Parent      = parent ?? throw new ArgumentNullException(nameof(parent));
            AnyElements = t_ssdl_property_refs.Any;
            Name        = t_ssdl_property_refs.Name;
        }
    }
}
