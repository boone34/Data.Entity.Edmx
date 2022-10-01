using System;
using System.Linq;
using TechNoir.Data.Entity.Edmx.Serialization;
using TechNoir.Data.Entity.Edmx.Model.Map;

namespace TechNoir.Data.Entity.Edmx.Model.Storage
{
    public class EntitySet : AnyDocumentation
    {
        public EntityContainer EntityContainer { get; }
        public string          Schema          { get; }
        public string          Name            { get; }
        public string          Table           { get; }
        public string          EntityTypeName  { get; }
        public TSourceType     SourceType      { get; }
        public string          DefiningQuery  { get; }

        private EntityType _EntityType;
        public  EntityType EntityType => _EntityType ??= EntityContainer.Schema.EntityTypes.Single(et => et.Name == EntityTypeName.StripNamespace());

        private EntitySetMapping _EntitySetMapping;
        public  EntitySetMapping EntitySetMapping => _EntitySetMapping ??= EntityContainer.Schema.Runtime.Mapping.EntityContainerMapping.EntitySetMappings.SingleOrDefault(esm => esm.StorageEntitySetName == Name);

        public EntitySet(EntityContainer entity_container, TSsdlEntitySet t_ssdl_entity_set) :  base(t_ssdl_entity_set.Any, t_ssdl_entity_set.AnyAttr, t_ssdl_entity_set.Documentation)
        {
            EntityContainer = entity_container ?? throw new ArgumentNullException(nameof(entity_container));
            Schema          = string.IsNullOrWhiteSpace(t_ssdl_entity_set.Schema) ? t_ssdl_entity_set.Schema1 : t_ssdl_entity_set.Schema;
            Name            = string.IsNullOrWhiteSpace(t_ssdl_entity_set.Name) ? t_ssdl_entity_set.Name1 : t_ssdl_entity_set.Name;
            Table           = string.IsNullOrWhiteSpace(t_ssdl_entity_set.Table) ? Name : t_ssdl_entity_set.Table;
            EntityTypeName  = t_ssdl_entity_set.EntityType;
            SourceType      = t_ssdl_entity_set.Type;
            DefiningQuery   = t_ssdl_entity_set.DefiningQuery;
        }
    }
}
