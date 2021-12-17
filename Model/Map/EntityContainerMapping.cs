using System;
using System.Collections.Generic;
using System.Linq;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Map
{
    public class EntityContainerMapping
    {
        public Mapping                                    Mapping                 { get; }
        public string                                     ConceptualContainerName { get; }
        public string                                     StorageContainerName    { get; }
        public bool                                       GenerateUpdateViews     { get; }
        public IReadOnlyCollection<AssociationSetMapping> AssociationSetMappings  { get; }
        public IReadOnlyCollection<EntitySetMapping>      EntitySetMappings       { get; }
        public IReadOnlyCollection<FunctionImportMapping> FunctionImportMappings  { get; }

        internal EntityContainerMapping(Mapping mapping, TEntityContainerMapping t)
        {
            if (t == null) throw new ArgumentNullException(nameof(t));

            Mapping                 = mapping ?? throw new ArgumentNullException(nameof(mapping));
            ConceptualContainerName = t.CdmEntityContainer;
            StorageContainerName    = t.StorageEntityContainer;
            GenerateUpdateViews     = t.GenerateUpdateViews;
            AssociationSetMappings  = t.AssociationSetMappings.Select(asm => new AssociationSetMapping(this, asm)).ToList();
            EntitySetMappings       = t.EntitySetMappings.Select(esm => new EntitySetMapping(this, esm)).ToList();
            FunctionImportMappings  = t.FunctionImportMapping.Select(fim => new FunctionImportMapping(this, fim)).ToList();
        }
    }
}
