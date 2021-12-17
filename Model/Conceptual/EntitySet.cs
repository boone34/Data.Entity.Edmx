using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using TechNoir.Data.Entity.Edmx.Serialization;
using TechNoir.Data.Entity.Edmx.Model.Map;

namespace TechNoir.Data.Entity.Edmx.Model.Conceptual
{
    public class EntitySet
    {
        public EntityContainer                    EntityContainer { get; }
        public IReadOnlyCollection<Documentation> Documentations  { get; }
        public IReadOnlyCollection<XmlAttribute>  AnyAttributes   { get; }
        public string                             Name            { get; }
        public string                             EntityTypeName  { get; }
        public TAccess                            GetterAccess    { get; }

        private EntityType _EntityType;
        public  EntityType EntityType => _EntityType ??= EntityContainer.Schema.EntityTypes.Single(et => et.Name == EntityTypeName.StripNamespace());

        private EntitySetMapping _EntitySetMapping;
        public  EntitySetMapping EntitySetMapping => _EntitySetMapping ??= EntityContainer.Schema.Runtime.Mapping.EntityContainerMapping.EntitySetMappings.Single(esm => esm.ConceptualEntitySetName == Name);

        internal EntitySet(EntityContainer entity_container, TCsdlEntitySet t_csdl_entity_set)
        {
            EntityContainer = entity_container ?? throw new ArgumentNullException(nameof(entity_container));
            Documentations  = t_csdl_entity_set.Documentations.Select(d => new Documentation(d)).ToList();
            AnyAttributes   = t_csdl_entity_set.AnyAttr;
            Name            = t_csdl_entity_set.Name;
            EntityTypeName  = t_csdl_entity_set.EntityType;
            GetterAccess    = t_csdl_entity_set.GetterAccess;
        }
    }
}
