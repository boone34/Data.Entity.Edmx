using System;
using System.Collections.Generic;
using System.Linq;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Storage
{
    public class AssociationSet : AnyDocumentation
    {
        public EntityContainer                        EntityContainer { get; }
        public string                                 Name            { get; }
        public string                                 AssociationName { get; }
        public IReadOnlyCollection<AssociationSetEnd> Ends            { get; }

        private Association _Association;
        public  Association Association => _Association ??= EntityContainer.Schema.Associations.Single(a => a.Name == AssociationName.StripNamespace());

        internal AssociationSet(EntityContainer entity_container, TSsdlAssociationSet t_ssdl_association_set) : base(t_ssdl_association_set.Any, t_ssdl_association_set.AnyAttr, t_ssdl_association_set.Documentation)
        {
            EntityContainer = entity_container ?? throw new ArgumentNullException(nameof(entity_container));
            Name            = t_ssdl_association_set.Name;
            AssociationName = t_ssdl_association_set.Association;
            Ends            = t_ssdl_association_set.End.Select(e => new AssociationSetEnd(this, e)).ToList();
        }
    }
}
