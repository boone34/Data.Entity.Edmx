using System;
using System.Collections.Generic;
using System.Linq;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Map
{
    public class FunctionImportMappingResultMapping
    {
        public FunctionImportMapping                                 FunctionImportMapping { get; }
        public IReadOnlyCollection<FunctionImportComplexTypeMapping> ComplexTypeMappings   { get; }
        public IReadOnlyCollection<FunctionImportEntityTypeMapping>  EntityTypeMappings    { get; }

        internal FunctionImportMappingResultMapping(FunctionImportMapping function_import_mapping, TFunctionImportMappingResultMapping t)
        {
            if (t == null) throw new ArgumentNullException(nameof(t));

            FunctionImportMapping = function_import_mapping ?? throw new ArgumentNullException(nameof(function_import_mapping));
            ComplexTypeMappings   = t.ComplexTypeMappings.Select(ctm => new FunctionImportComplexTypeMapping(this, ctm)).ToList();
            EntityTypeMappings    = t.EntityTypeMappings.Select(etm => new FunctionImportEntityTypeMapping(this, etm)).ToList();
        }
    }
}
