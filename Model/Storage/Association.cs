using System;
using System.Collections.Generic;
using System.Linq;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Storage
{
    public class Association : AnyDocumentation
    {
        public Schema                              Schema     { get; }
        public string                              Name       { get; }
        public Constraint                          Constraint { get; }
        public IReadOnlyCollection<AssociationEnd> Ends       { get; }

        internal Association(Schema schema, TSsdlAssociation t_ssdl_association) : base(t_ssdl_association.Any, t_ssdl_association.AnyAttr, t_ssdl_association.Documentation)
        {
            Schema     = schema ?? throw new ArgumentNullException(nameof(schema));
            Name       = t_ssdl_association.Name;
            Constraint = new Constraint(this, t_ssdl_association.ReferentialConstraint);
            Ends       = t_ssdl_association.End.Select(e => new AssociationEnd(this, e)).ToList();
        }
    }
}
