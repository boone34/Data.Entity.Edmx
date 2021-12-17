using System;
using System.Collections.Generic;
using System.Linq;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Map
{
    public class FunctionImportComplexTypeMapping
    {
        public FunctionImportMappingResultMapping                                    MappingResultMapping { get; }
        public string                                                                TypeName             { get; }
        public IReadOnlyCollection<ScalarProperty<FunctionImportComplexTypeMapping>> ScalarProperties     { get; }

        internal FunctionImportComplexTypeMapping(FunctionImportMappingResultMapping mapping_result_mapping, TFunctionImportComplexTypeMapping t)
        {
            if (t == null) throw new ArgumentNullException(nameof(t));

            MappingResultMapping = mapping_result_mapping ?? throw new ArgumentNullException(nameof(mapping_result_mapping));
            TypeName             = t.TypeName;
            ScalarProperties     = t.ScalarProperty.Select(sp => new ScalarProperty<FunctionImportComplexTypeMapping>(this, sp)).ToList();
        }
    }
}
