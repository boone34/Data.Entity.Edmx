using System;
using System.Collections.Generic;
using System.Linq;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Conceptual
{
    public class AssociationEnd : AnyDocumentation
    {
        public Association                   Association  { get; }
        public string                        Type         { get; }
        public string                        Role         { get; }
        public Multiplicity                  Multiplicity { get; }
        public IReadOnlyCollection<OnAction> OnDeletes    { get; }

        private EntityType _EntityType;
        public  EntityType EntityType => _EntityType ??= Association.Schema.EntityTypes.Single(et => et.Name == Type.StripNamespace());

        internal AssociationEnd(Association association, TCsdlAssociationEnd t_csdl_association_end) : base(t_csdl_association_end.Any, t_csdl_association_end.AnyAttr, t_csdl_association_end.Documentation)
        {
            Association  = association ?? throw new ArgumentNullException(nameof(association));
            Type         = t_csdl_association_end.Type;
            Role         = t_csdl_association_end.Role;
            Multiplicity = t_csdl_association_end.Multiplicity.ToMultiplicity();
            OnDeletes    = t_csdl_association_end.OnDelete.Select(od => new OnAction(this, od)).ToList();
        }
    }
}
