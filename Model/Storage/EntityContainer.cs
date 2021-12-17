using System;
using System.Collections.Generic;
using System.Linq;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Storage
{
    public class EntityContainer : AnyDocumentation
    {
        public Schema                              Schema          { get; }
        public IReadOnlyCollection<AssociationSet> AssociationSets { get; }
        public IReadOnlyCollection<EntitySet>      EntitySets      { get; }

        internal EntityContainer(Schema schema, TSsdlEntityContainer t_ssdl_entity_container) : base(t_ssdl_entity_container.Any, t_ssdl_entity_container.AnyAttr, t_ssdl_entity_container.Documentation)
        {
            Schema          = schema ?? throw new ArgumentNullException(nameof(schema));
            AssociationSets = t_ssdl_entity_container.AssociationSets.Select(a_s => new AssociationSet(this, a_s)).ToList();
            EntitySets      = t_ssdl_entity_container.EntitySets.Select(es => new EntitySet(this, es)).ToList();
        }
    }
}
