using System.Collections.Generic;
using System.Linq;

namespace TechNoir.Data.Entity.Edmx.Serialization
{
    public partial class TFunctionImportMappingResultMapping
    {
        private List<TFunctionImportComplexTypeMapping>                _ComplexTypeMappings;
		public  IReadOnlyCollection<TFunctionImportComplexTypeMapping> ComplexTypeMappings => _ComplexTypeMappings ??= Items.OfType<TFunctionImportComplexTypeMapping>().ToList();

        private List<TFunctionImportEntityTypeMapping>                _EntityTypeMappings;
		public  IReadOnlyCollection<TFunctionImportEntityTypeMapping> EntityTypeMappings => _EntityTypeMappings ??= Items.OfType<TFunctionImportEntityTypeMapping>().ToList();
    }
}
