using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Conceptual
{
    public class ComplexType
    {
        public Schema                                   Schema         { get; }
        public Documentation                            Documentation  { get; }
        public string                                   Name           { get; }
        public TPublicOrInternalAccess                  TypeAccess     { get; }
        public IReadOnlyCollection<XmlAttribute>        AnyAttributes  { get; }
        public IReadOnlyCollection<ComplexTypeProperty> Properties     { get; }

        internal ComplexType(Schema schema, TComplexType t_complex_type)
        {
            if (t_complex_type == null) throw new ArgumentNullException(nameof(t_complex_type));

            Schema        = schema ?? throw new ArgumentNullException(nameof(schema));
            Documentation = new Documentation(t_complex_type.Documentation);
            Name          = t_complex_type.Name;
            TypeAccess    = t_complex_type.TypeAccess;
            AnyAttributes = t_complex_type.AnyAttr;
            Properties    = t_complex_type.ComplexTypeProperties.Select(ctp => new ComplexTypeProperty(this, ctp)).ToList();
        }
    }
}
