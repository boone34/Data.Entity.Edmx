using System;
using System.Collections.Generic;
using System.Linq;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Conceptual
{
    public class AssociationSet : AnyDocumentation
    {
        public EntityContainer                        EntityContainer { get; }
        public string                                 Name            { get; }
        public string                                 AssociationName { get; }
        public IReadOnlyCollection<AssociationSetEnd> Ends            { get; }

        private Association _Association;
        public  Association Association => _Association ??= EntityContainer.Schema.Associations.Single(a => a.Name == AssociationName.StripNamespace());

        internal AssociationSet(EntityContainer entity_container, TCsdlAssociationSet t_csdl_association_set) : base(t_csdl_association_set.Any, t_csdl_association_set.AnyAttr, t_csdl_association_set.Documentation)
        {
            EntityContainer = entity_container ?? throw new ArgumentNullException(nameof(entity_container));
            Name            = t_csdl_association_set.Name;
            AssociationName = t_csdl_association_set.Association;
            Ends            = t_csdl_association_set.End.Select(e => new AssociationSetEnd(this, e)).ToList();
        }
    }
}
