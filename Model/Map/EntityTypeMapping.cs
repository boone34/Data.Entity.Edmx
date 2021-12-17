using System;
using System.Collections.Generic;
using System.Linq;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Map
{
    public class EntityTypeMapping : IHaveRuntime
    {
        public EntitySetMapping                                        EntitySetMapping            { get; }
        public string                                                  ConceptualEntityTypeName    { get; }
        public EntityTypeModificationFunctionMapping                   ModificationFunctionMapping { get; }
        public IReadOnlyCollection<MappingFragment<EntityTypeMapping>> MappingFragments            { get; }

        public Runtime Runtime => EntitySetMapping.EntityContainerMapping.Mapping.Runtime;

        private Conceptual.EntityType _ConceptualEntityType;
        public  Conceptual.EntityType ConceptualEntityType => _ConceptualEntityType ??= EntitySetMapping.EntityContainerMapping.Mapping.Runtime.ConceptualSchema.EntityTypes.Single(et => et.Name == ConceptualEntityTypeName.StripNamespace());

        internal EntityTypeMapping(EntitySetMapping entity_set_mapping, TEntityTypeMapping t)
        {
            if (t == null) throw new ArgumentNullException(nameof(t));

            EntitySetMapping            = entity_set_mapping ?? throw new ArgumentNullException(nameof(entity_set_mapping));
            ConceptualEntityTypeName    = t.TypeName;
            ModificationFunctionMapping = new EntityTypeModificationFunctionMapping(this, t.ModificationFunctionMapping);
            MappingFragments            = t.MappingFragment.Select(mf => new MappingFragment<EntityTypeMapping>(this, mf)).ToList();
        }
    }
}
