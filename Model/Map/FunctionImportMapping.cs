using System;
using System.Collections.Generic;
using System.Linq;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Map
{
    public class FunctionImportMapping
    {
        public EntityContainerMapping                                  EntityContainerMapping { get; }
        public string                                                  FunctionName           { get; }
        public string                                                  FunctionImportName     { get; }
        public IReadOnlyCollection<FunctionImportMappingResultMapping> ResultMappings         { get; }

        internal FunctionImportMapping(EntityContainerMapping entity_container_mapping, TFunctionImportMapping t)
        {
            if (t == null) throw new ArgumentNullException(nameof(t));

            EntityContainerMapping = entity_container_mapping ?? throw new ArgumentNullException(nameof(entity_container_mapping));
            FunctionName           = t.FunctionName;
            FunctionImportName     = t.FunctionImportName;
            ResultMappings         = t.ResultMapping.Select(rm => new FunctionImportMappingResultMapping(this, rm)).ToList();
        }
    }
}
