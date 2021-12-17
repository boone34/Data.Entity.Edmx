using System;
using System.Collections.Generic;
using System.Linq;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Map
{
    public class FunctionImportEntityTypeMapping
    {
        public FunctionImportMappingResultMapping                                   MappingResultMapping { get; }
        public string                                                               TypeName             { get; }
        public IReadOnlyCollection<FunctionImportCondition>                         Conditions           { get; }
        public IReadOnlyCollection<ScalarProperty<FunctionImportEntityTypeMapping>> ScalarProperties     { get; }

        internal FunctionImportEntityTypeMapping(FunctionImportMappingResultMapping mapping_result_mapping, TFunctionImportEntityTypeMapping t)
        {
            if (t == null) throw new ArgumentNullException(nameof(t));

            MappingResultMapping = mapping_result_mapping ?? throw new ArgumentNullException(nameof(mapping_result_mapping));
            TypeName = t.TypeName;
            Conditions = t.Conditions.Select(c => new FunctionImportCondition(this, c)).ToList();
            ScalarProperties = t.ScalarProperties.Select(sp => new ScalarProperty<FunctionImportEntityTypeMapping>(this, sp)).ToList();
        }
    }
}
