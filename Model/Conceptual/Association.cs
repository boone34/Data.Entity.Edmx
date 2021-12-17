using System;
using System.Collections.Generic;
using System.Linq;
using TechNoir.Data.Entity.Edmx.Model.Map;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Conceptual
{
    public class Association : AnyDocumentation
    {
        public Schema                              Schema     { get; }
        public string                              Name       { get; }
        public Constraint                          Constraint { get; }
        public IReadOnlyCollection<AssociationEnd> Ends       { get; }

        private readonly LazyProperty<AssociationSetMapping> _AssociationSetMapping;
        public           AssociationSetMapping               AssociationSetMapping => _AssociationSetMapping.Value;

        internal Association(Schema schema, TCsdlAssociation t_csdl_association) : base(t_csdl_association.Any, t_csdl_association.AnyAttr, t_csdl_association.Documentation)
        {
            _AssociationSetMapping = new LazyProperty<AssociationSetMapping>(() => Schema.Runtime.Mapping.EntityContainerMapping.AssociationSetMappings.SingleOrDefault(asm => asm.ConceptualAssociationName.StripNamespace() == Name));

            Schema     = schema ?? throw new ArgumentNullException(nameof(schema));
            Name       = t_csdl_association.Name;
            Constraint = new Constraint(this, t_csdl_association.ReferentialConstraint);
            Ends       = t_csdl_association.End.Select(e => new AssociationEnd(this, e)).ToList();
        }
    }
}
