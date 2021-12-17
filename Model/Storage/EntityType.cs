using System;
using System.Collections.Generic;
using System.Linq;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Storage
{
    public class EntityType : AnyDocumentation
    {
        public Schema                              Schema           { get; }
        public string                              Name             { get; }
        public IReadOnlyCollection<EntityProperty> EntityProperties { get; }

        private EntitySet _EntitySet;
        public  EntitySet EntitySet => _EntitySet ??= Schema.EntityContainer.EntitySets.Single(es => es.EntityTypeName.StripNamespace() == Name);

        internal EntityType(Schema schema, TSsdlEntityType t_ssdl_entity_type) : base(t_ssdl_entity_type.Any, t_ssdl_entity_type.AnyAttr, t_ssdl_entity_type.Documentation)
        {
            Schema           = schema ?? throw new ArgumentNullException(nameof(schema));
            Name             = t_ssdl_entity_type.Name;
            EntityProperties = t_ssdl_entity_type.Items.Select(ep => new EntityProperty(this, ep)).ToList();
        }
    }
}
