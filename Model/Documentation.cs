using System.Collections.Generic;
using System.Xml;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model
{
    public class Documentation
    {
        public XmlElement                        Summary         { get; }
        public XmlElement                        LongDescription { get; }
        public IReadOnlyCollection<XmlAttribute> Attributes      { get; }

        internal Documentation(TCsdlDocumentation csdl_documentation)
        {
            Summary         = csdl_documentation.Summary;
            LongDescription = csdl_documentation.LongDescription;
            Attributes      = csdl_documentation.AnyAttr;
        }

        internal Documentation(TSsdlDocumentation ssdl_documentation)
        {
            Summary         = ssdl_documentation.Summary;
            LongDescription = ssdl_documentation.LongDescription;
            Attributes      = ssdl_documentation.AnyAttr;
        }
    }
}
