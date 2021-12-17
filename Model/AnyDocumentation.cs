using System;
using System.Collections.Generic;
using System.Xml;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model
{
    public class AnyDocumentation : Any
    {
        public Documentation Documentation { get; }

        internal AnyDocumentation(IReadOnlyCollection<XmlElement> any_elements, IReadOnlyCollection<XmlAttribute> any_attributes, TCsdlDocumentation csdl_documentation) : base(any_elements, any_attributes)
        {
            if (csdl_documentation == null) throw new ArgumentNullException(nameof(csdl_documentation));

            Documentation = new Documentation(csdl_documentation);
        }

        internal AnyDocumentation(IReadOnlyCollection<XmlElement> any_elements, IReadOnlyCollection<XmlAttribute> any_attributes, TSsdlDocumentation ssdl_documentation) : base(any_elements, any_attributes)
        {
            if (ssdl_documentation == null) throw new ArgumentNullException(nameof(ssdl_documentation));

            Documentation = new Documentation(ssdl_documentation);
        }
    }
}
