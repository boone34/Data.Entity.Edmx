using System;
using System.Collections.Generic;
using System.Linq;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Conceptual
{
    public class ComplexTypeProperty : PropertyBase
    {
        public ComplexType                        ComplexType    { get; }
        public IReadOnlyCollection<Documentation> Documentations { get; }

        internal ComplexTypeProperty(ComplexType complex_type, TComplexTypeProperty t_complex_type_property) : base(t_complex_type_property)
        {
            ComplexType    = complex_type ?? throw new ArgumentNullException(nameof(complex_type));
            Documentations = t_complex_type_property.Documentations.Select(td => new Documentation(td)).ToList();
        }
    }
}
