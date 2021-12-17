using System;
using System.Collections.Generic;
using System.Linq;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Map
{
    public class EntitySetMapping : IHaveRuntime
    {
        public EntityContainerMapping                                 EntityContainerMapping   { get; }
        public string                                                 ConceptualEntitySetName  { get; }
        public string                                                 ConceptualEntityTypeName { get; }
        public string                                                 StorageEntitySetName     { get; }
        public bool                                                   MakeColumnsDistinct      { get; }
        public IReadOnlyCollection<ComplexProperty<EntitySetMapping>> ComplexProperties        { get; }
        public IReadOnlyCollection<Condition<EntitySetMapping>>       Conditions               { get; }
        public IReadOnlyCollection<EntityTypeMapping>                 EntityTypeMappings       { get; }
        public IReadOnlyCollection<MappingFragment<EntitySetMapping>> MappingFragments         { get; }
        public IReadOnlyCollection<QueryView>                         QueryViews               { get; }
        public IReadOnlyCollection<ScalarProperty<EntitySetMapping>>  ScalarProperties         { get; }

        public Runtime Runtime => EntityContainerMapping.Mapping.Runtime;

        private Conceptual.EntitySet _ConceptualEntitySet;
        public  Conceptual.EntitySet ConceptualEntitySet => _ConceptualEntitySet ??= EntityContainerMapping.Mapping.Runtime.ConceptualSchema.EntityContainer.EntitySets.Single(es => es.Name == ConceptualEntitySetName);

        private Storage.EntitySet _StorageEntitySet;
        public  Storage.EntitySet StorageEntitySet => _StorageEntitySet ??= EntityContainerMapping.Mapping.Runtime.StorageSchema.EntityContainer.EntitySets.SingleOrDefault(es => es.Name == StorageEntitySetName);

        internal EntitySetMapping(EntityContainerMapping entity_container_mapping, TEntitySetMapping t)
        {
            if (t == null) throw new ArgumentNullException(nameof(t));

            EntityContainerMapping   = entity_container_mapping ?? throw new ArgumentNullException(nameof(entity_container_mapping));
            ConceptualEntitySetName  = t.Name;
            ConceptualEntityTypeName = t.TypeName;
            StorageEntitySetName     = t.StoreEntitySet;
            MakeColumnsDistinct      = t.MakeColumnsDistinct;
            ComplexProperties        = t.ComplexProperties.Select(cp => new ComplexProperty<EntitySetMapping>(this, cp)).ToList();
            Conditions               = t.Conditions.Select(c => new Condition<EntitySetMapping>(this, c)).ToList();
            EntityTypeMappings       = t.EntityTypeMappings.Select(etm => new EntityTypeMapping(this, etm)).ToList();
            MappingFragments         = t.MappingFragments.Select(mf => new MappingFragment<EntitySetMapping>(this, mf)).ToList();
            QueryViews               = t.QueryViews.Select(qv => new QueryView(this, qv)).ToList();
            ScalarProperties         = t.ScalarProperties.Select(sp => new ScalarProperty<EntitySetMapping>(this, sp)).ToList();
        }
    }
}
