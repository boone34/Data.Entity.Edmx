using System;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Storage
{
    public class EntityProperty : PropertyBase
    {
        public EntityType             EntityType            { get; }
        public TStoreGeneratedPattern StoreGeneratedPattern { get; }

        internal EntityProperty(EntityType entity_type, TSsdlEntityProperty t_ssdl_entity_property) : base(t_ssdl_entity_property)
        {
            EntityType            = entity_type ?? throw new ArgumentNullException(nameof(entity_type));
            StoreGeneratedPattern = t_ssdl_entity_property.StoreGeneratedPattern;
        }
    }
}
