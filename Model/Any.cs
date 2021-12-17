using System;
using System.Collections.Generic;
using System.Xml;

namespace TechNoir.Data.Entity.Edmx.Model
{
    public class Any
    {
        public IReadOnlyCollection<XmlElement>   AnyElements   { get; }
        public IReadOnlyCollection<XmlAttribute> AnyAttributes { get; }

        internal Any(IReadOnlyCollection<XmlElement> any_elements, IReadOnlyCollection<XmlAttribute> any_attributes)
        {
            AnyElements   = any_elements   ?? throw new ArgumentNullException(nameof(any_elements));
            AnyAttributes = any_attributes ?? throw new ArgumentNullException(nameof(any_attributes));
        }
    }
}
